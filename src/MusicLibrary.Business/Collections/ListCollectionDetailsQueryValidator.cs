using FluentValidation;

namespace MusicLibrary.Business.Collections;

public class ListCollectionDetailsQueryValidator : AbstractValidator<ListCollectionDetailsQuery>
{
    public ListCollectionDetailsQueryValidator()
    {
        RuleFor(x => x.CollectionId)
            .GreaterThan(0)
            .WithMessage("Collection id must be greater than 0");
    }
}