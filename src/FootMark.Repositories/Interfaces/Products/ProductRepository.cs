using FootMark.Domain.Data.Contexts;
using FootMark.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Repositories.Interfaces.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly FootMarkDbContext _context;

        public ProductRepository(FootMarkDbContext context)
        {
            _context = context;
        }

        public Task<bool> Add(Product user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Product user)
        {
            throw new NotImplementedException();
        }
    }
}
