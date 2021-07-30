namespace FootMark.Domain.Commands.Validations
{
    public class RemoveUserValidation : UserValidation<RemoveUserCommand>
    {
        public RemoveUserValidation()
        {
            ValidateId();
        }
    }
}
