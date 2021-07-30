namespace FootMark.Domain.Commands.Validations
{
    public class UpdateUserValidation : UserValidation<UpdateUserCommand>
    {
        public UpdateUserValidation()
        {
            ValidateName();
            ValidateEmail();
        }
    }
}
