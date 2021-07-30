using FluentValidation.Results;
using FootMark.Domain.Models.Users;
using FootMark.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using NetDevPack.Domain;
using NetDevPack.Mediator;
using NetDevPack.Messaging;
using System.Linq;
using System.Threading.Tasks;


namespace FootMark.Infrastructure.Contexts
{
    public class FootMarkDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediator;

        public FootMarkDbContext(DbContextOptions<FootMarkDbContext> options, IMediatorHandler mediator) : base(options)
        {
            _mediator = mediator;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<AppUser> AppUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Ignore<ValidationResult>();
            builder.Ignore<Event>();

            foreach (var property in builder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            builder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(builder);
        }

        public async Task<bool> Commit()
        {

            await _mediator.PublishDomainEvents(this).ConfigureAwait(false);

            var success = await SaveChangesAsync() > 0;

            return success;
        }
    }

    public static class MediatorExtension
    {
        public static async Task PublishDomainEvents<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.PublishEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
