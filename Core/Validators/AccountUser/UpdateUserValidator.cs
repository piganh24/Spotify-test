using FluentValidation;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Core.DTOs.Account;

namespace Core.Validators.Account
{
    public class UpdateUserValidator : AbstractValidator<UserUpdateDTO>
    {
        private bool BeUniqueEmail(string email) => _userManager.FindByEmailAsync(email).Result == null;

        private readonly UserManager<UserEntity> _userManager;
        public UpdateUserValidator(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;

            RuleFor(user => user.Id)
                .NotEmpty().WithMessage("Id is required!")
                .GreaterThan(0).WithMessage("Id must be greater than zero!");

            RuleFor(updateUser => updateUser.FirstName)
                .NotEmpty().WithName("FirstName").WithMessage("FirstName is required!")
                .MinimumLength(1).WithName("FirstName").WithMessage("FirsName must to be more than 1 symbols")
                .MaximumLength(160).WithName("FirstName").WithMessage("FirstName cannot be more than 160 symbols");

            RuleFor(updateUser => updateUser.LastName)
                .NotEmpty().WithName("LastName").WithMessage("LastName is required!")
                .MinimumLength(1).WithName("LastName").WithMessage("LastName must to be more than 1 symbols")
                .MaximumLength(160).WithName("LastName").WithMessage("LastName cannot be more than 160 symbols");

            RuleFor(updateUser => updateUser.UserName)
                .NotEmpty().WithName("NickName").WithMessage("NickName is required!")
                .MinimumLength(1).WithName("NickName").WithMessage("NickName must to be more than 1 symbols")
                .MaximumLength(160).WithName("NickName").WithMessage("NickName cannot be more than 160 symbols");

            RuleFor(updateUser => updateUser.AboutMe)
                .NotEmpty().WithName("AboutMe").WithMessage("AboutMe is required!")
                .MinimumLength(1).WithName("AboutMe").WithMessage("AboutMe must to be more than 5 symbols")
                .MaximumLength(240).WithName("AboutMe").WithMessage("AboutMe cannot be more than 240 symbols");

            RuleFor(updateUser => updateUser.Email)
                .NotEmpty().WithMessage("Email is required !")
                .EmailAddress().WithMessage("Email not valid!")
                .DependentRules(() => { RuleFor(updateUser => updateUser.Email).Must(BeUniqueEmail).WithMessage("The email is alredy taken!"); });

            RuleFor(updateUser => updateUser.Image)
                .NotEmpty().WithMessage("Image is required!");

            RuleFor(updateUser => updateUser.Password)
                .NotEmpty().WithName("Password").WithMessage("Password is required !")
                .MinimumLength(8).WithName("Password").WithMessage("Password must contain at least 8 characters!")
                .Matches("[A-Z]").WithName("Password").WithMessage("Password must contain one or more capital letters.")
                .Matches("[a-z]").WithName("Password").WithMessage("Password must contain one or more lowercase letters.")
                .Matches(@"\d").WithName("Password").WithMessage("Password must contain one or more digits.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithName("Password").WithMessage("Password must contain one or more special characters.");

            RuleFor(updateUser => updateUser.ConfirmPassword)
                .NotEmpty().WithName("ConfirmPassword").WithMessage("Required!")
                .Equal(x => x.Password).WithMessage("Passwords do not match!");
        }
    }
}