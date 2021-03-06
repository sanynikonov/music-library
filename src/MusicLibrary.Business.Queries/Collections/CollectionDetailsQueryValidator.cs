using FluentValidation;

namespace MusicLibrary.Business.Collections;

public class CollectionDetailsQueryValidator : AbstractValidator<CollectionDetailsQuery>
{
    public CollectionDetailsQueryValidator()
    {
        RuleFor(x => x.CollectionId)
            .GreaterThan(0)
            .WithMessage("Collection id must be greater than 0");
    }
}