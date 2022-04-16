using FluentValidation;

namespace MusicLibrary.Business.Artists;

public class ListArtistsQueryValidator : AbstractValidator<ListArtistsQuery>
{
    public ListArtistsQueryValidator()
    {
        RuleFor(q => q.PageSize)
            .GreaterThan(0)
            .WithMessage("Page size must be greater than 0");

        RuleFor(q => q.PageNumber)
            .GreaterThan(0)
            .WithMessage("Page number must be greater than 0");

        RuleFor(q => q.SearchString)
            .NotEmpty()
            .WithMessage("Search string must not be empty");
    }
}