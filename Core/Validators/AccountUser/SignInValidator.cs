using FluentValidation;
using Core.DTOs.Identity.SignIn;

namespace Core.Validators.Account
{
    public class SignInValidator : AbstractValidator<SignInUserItemDTO>
    {
        public SignInValidator()
        {
            RuleFor(signIn => signIn.Email)
                .NotEmpty().WithMessage("Email is required !")
                .EmailAddress().WithMessage("Email not valid!");

            RuleFor(signIn => signIn.Password)
               .NotEmpty().WithName("Password").WithMessage("Password is required !");
        }
    }
}