namespace CampanhaBrinquedo.Domain.Validators
{
    using CampanhaBrinquedo.Domain.Entities.Child;
    using FluentValidation;

    public class ResponsibleValidator : AbstractValidator<Responsible>
    {
        public ResponsibleValidator()
        {
            RuleFor(responsavel => responsavel.Name)
                .NotEmpty().WithMessage("Nome Obrigatório");
            RuleFor(responsavel => responsavel.RG)
                .NotEmpty().WithMessage("RG Obrigatório")
                .MinimumLength(8).WithMessage("RG não tem os tamanho valido");
        }
        
    }
}