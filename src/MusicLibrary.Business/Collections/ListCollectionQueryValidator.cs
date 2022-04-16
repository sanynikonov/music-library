using FluentValidation;
using MusicLibrary.Data.Entities;

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

        When(q => q.ReleaseType != null, () =>
        {
            RuleFor(q => q.ReleaseType)
                .IsEnumName(typeof(ReleaseType), caseSensitive: false)
                .WithMessage("Release type must one of: 'LongPlay', 'ExtendedPlay', 'Single', 'Compilation'");
        });
    }
}