using FluentValidation;
using Core.DTOs.Track;
using Core.Services;

namespace Core.Validators.TrackValidation
{
    public class TrackCreateValidator : AbstractValidator<TrackCreateDTO>
    {
        private readonly GenreServices _genreServices;

        public TrackCreateValidator(GenreServices genreServices)
        {
            _genreServices = genreServices;

            RuleFor(track => track.Title)
                .NotEmpty().WithMessage("Title is required!")
                .MinimumLength(1).WithMessage("Title must be more than 1 character!")
                .MaximumLength(160).WithMessage("The maximum number of characters for title is 160!");

            RuleFor(track => track.GenreId)
                .NotEmpty().WithMessage("Genre ID is required!")
                .GreaterThan(0).WithMessage("Genre ID must be greater than zero!")
                .Must(IsExistGenre).WithMessage("Genre with this ID does not exist!");

            RuleFor(track => track.Description)
                .NotEmpty().WithMessage("Description is required!")
                .MinimumLength(5).WithMessage("Description must be more than 5 character!")
                .MaximumLength(240).WithMessage("The maximum number of characters for description is 240!");

            RuleFor(track => track.Duration)
                .NotEmpty().WithMessage("Duration is required!")
                .GreaterThan(0).WithMessage("Duration must be greater than zero!");

            RuleFor(track => track.Track)
                .NotEmpty().WithMessage("Track or another music file is required!");

            RuleFor(track => track.Image)
                .NotEmpty().WithMessage("Image is required!");
        }
        private bool IsExistGenre(int id) => _genreServices.IsExistGenre(id);
    }
}
