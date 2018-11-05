namespace CampanhaBrinquedo.Domain.Validators
{
    using CampanhaBrinquedo.Domain.Entities.Child;
    using FluentValidation;

    public class ChildValidator : AbstractValidator<Child>
    {
        public ChildValidator()
        {
            RuleFor(crianca => crianca.Name)
                .NotEmpty().WithMessage("Nome obrigatório!");
            RuleFor(crianca => crianca.Age)
                .NotEmpty().WithMessage("Idade Obrigatória!");
            RuleFor(crianca => crianca.Clothings)
                .NotEmpty().WithMessage("Tamanho de roupa obrigatório!");
            RuleFor(crianca => crianca.Communities)
                .NotNull()
                .SetCollectionValidator(new CommunityValidator());
            RuleFor(crianca => crianca.Responsiblies)
                .NotNull()
                .SetCollectionValidator(new ResponsibleValidator());
        }
    }
}