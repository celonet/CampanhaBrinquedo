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
            RuleFor(crianca => crianca.Clothing)
                .NotEmpty().WithMessage("Tamanho de roupa obrigatório!");
            RuleForEach(crianca => crianca.Communities)
                .SetValidator(new CommunityValidator());
            RuleForEach(crianca => crianca.Responsiblies)
                .SetValidator(new ResponsibleValidator());
        }
    }
}