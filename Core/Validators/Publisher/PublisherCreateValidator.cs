using FluentValidation;
using Core.DTOs.Publisher;

namespace Core.Validators.PublisherValidation
{
    public class PublisherCreateValidator : AbstractValidator<PublisherCreateDTO>
    {
        public PublisherCreateValidator()
        {
            RuleFor(publisher => publisher.Name)
                .NotEmpty().WithMessage("Name is required!")
                .MinimumLength(1).WithMessage("Name must be more than 1 character!")
                .MaximumLength(160).WithMessage("The maximum number of characters for name is 160!");

            RuleFor(publisher => publisher.Image)
                .NotEmpty().WithMessage("Image is required!");

            RuleFor(publisher => publisher.Description)
                .NotEmpty().WithMessage("Description is required!")
                .MinimumLength(5).WithMessage("Description must be more than 5 character!")
                .MaximumLength(240).WithMessage("The maximum number of characters for description is 240!");
        }
    }
}
