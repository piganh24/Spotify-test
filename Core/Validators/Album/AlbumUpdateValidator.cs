using FluentValidation;
using Core.DTOs.Album;
using Core.Services;

namespace Core.Validators.Album
{
    public class AlbumUpdateValidator : AbstractValidator<AlbumUpdateDTO>
    {
        private readonly PublisherServices _publisherServices;
        private readonly GenreServices _genreServices;
        private readonly AlbumServices _albumServices;
        public AlbumUpdateValidator(PublisherServices publisherServices, GenreServices genreServices, AlbumServices albumServices)
        {
            _publisherServices = publisherServices;
            _genreServices = genreServices;
            _albumServices = albumServices;

            RuleFor(album => album.Id)
                .NotEmpty().WithMessage("Id is required!")
                .GreaterThan(0).WithMessage("Id cannot be negative or zero!")
                .Must(IsExistAlbum).WithMessage("Album with this ID does not exist!");

            RuleFor(album => album.Title)
                .NotEmpty().WithMessage("Title is required!")
                .MinimumLength(1).WithMessage("Title must be more than 1 character!")
                .MaximumLength(160).WithMessage("The maximum number of characters for title is 160!");

            RuleFor(album => album.PublisherId)
                .NotEmpty().WithMessage("Publisher ID is required!")
                .GreaterThan(0).WithMessage("Publisher ID cannot be negative or zero!")
                .Must(IsExistPublisher).WithMessage("Publiher with this ID does not exist!");

            RuleFor(album => album.GenreId)
                .NotEmpty().WithMessage("Genre ID is required!")
                .GreaterThan(0).WithMessage("Genre ID cannot be negative or zero!")
                .Must(IsExistGenre).WithMessage("Genre with this ID does not exist!");

            RuleFor(album => album.Duration)
                .NotEmpty().WithMessage("Duration is required!")
                .GreaterThan(0).WithMessage("Duration must be greater than 0!");

            RuleFor(album => album.Image)
                .NotEmpty().WithMessage("Image is required!");

            RuleFor(album => album.Description)
                .NotEmpty().WithMessage("Description is required!")
                .MinimumLength(5).WithMessage("Description must be more than 5 character!")
                .MaximumLength(240).WithMessage("The maximum number of characters for description is 240!");
        }
        private bool IsExistPublisher(int id) => _publisherServices.IsExistPublisher(id);
        private bool IsExistGenre(int id) => _genreServices.IsExistGenre(id);
        private bool IsExistAlbum(int id) => _albumServices.IsExistAlbum(id);
    }
}
