namespace CampanhaBrinquedo.Domain.Validators
{
    using CampanhaBrinquedo.Domain.Entities.Child;
    using FluentValidation;

    public class GodFatherValidator : AbstractValidator<GodFather>
    {
        public GodFatherValidator()
        {
            RuleFor(padrinho => padrinho.Name)
                .NotEmpty().WithMessage("Nome Obrigatório");
            RuleFor(padrinho => padrinho.Community)
                .SetValidator(new CommunityValidator());
            RuleFor(padrinho => padrinho.Telephone)
                .NotEmpty().WithMessage("Telefone é obrigatório");
            RuleFor(padrinho => padrinho.Email)
                .EmailAddress()
                .WithMessage("Email inválido");
        }
    }
}