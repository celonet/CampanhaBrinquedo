namespace CampanhaBrinquedo.Domain.Validators
{
    using CampanhaBrinquedo.Domain.Entities.Child;
    using FluentValidation;

    public class CommunityValidator : AbstractValidator<Community>
    {
        public CommunityValidator()
        {
            RuleFor(comunidade => comunidade.Name)
                .NotEmpty().WithMessage("Nome não pode ser em branco!")
                .Length(3, 150).WithMessage("Nome deve ter ao menos 3 caracteres!");
            RuleFor(comunidade => comunidade.Neighborhood)
               .NotEmpty().WithMessage("Bairro não pode ser em branco!")
               .Length(3, 150).WithMessage("Bairro deve ter ao menos 3 caracteres!");
        }
    }
}