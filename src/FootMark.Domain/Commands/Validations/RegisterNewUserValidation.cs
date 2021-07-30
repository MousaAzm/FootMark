namespace FootMark.Domain.Commands.Validations
{
    public class RegisterNewUserValidation : UserValidation<RegisterNewUserCommand>
    {
        public RegisterNewUserValidation()
        {
            ValidateName();
            ValidateEmail();
        }
    }
}
