using FluentValidation;
using Core.DTOs.Publisher;
using Core.Services;

namespace Core.Validators.PublisherValidation
{
    public class PublisherUpdateValidator : AbstractValidator<PublisherUpdateDTO>
    {
        private readonly PublisherServices _publisherServices;

        public PublisherUpdateValidator(PublisherServices publisherServices)
        {
            _publisherServices = publisherServices;

            RuleFor(publisher => publisher.Id)
                .NotEmpty().WithMessage("Id is required!")
                .GreaterThan(0).WithMessage("Id must be greater than zero!")
                .Must(IsExistPublisher).WithMessage("Publisher with this ID does not exist!");

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
        private bool IsExistPublisher(int id) => _publisherServices.IsExistPublisher(id);
    }
}
