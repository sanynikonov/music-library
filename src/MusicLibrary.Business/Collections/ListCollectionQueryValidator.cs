using FluentValidation;

namespace MusicLibrary.Business.Collections;

public class ListCollectionQueryValidator : AbstractValidator<ListCollectionQuery>
{
    public ListCollectionQueryValidator()
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

        RuleFor(q => q.CollectionType)
            .NotEmpty()
            .WithMessage("Collection type must not be empty");
    }
}