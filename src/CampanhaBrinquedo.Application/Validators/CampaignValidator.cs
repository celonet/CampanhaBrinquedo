namespace CampanhaBrinquedo.Domain.Validators
{
    using CampanhaBrinquedo.Domain.Entities.Campaign;
    using FluentValidation;
    using System;

    public class CampaignValidator : AbstractValidator<Campaign>
    {
        public CampaignValidator()
        {
            RuleFor(campanha => campanha.Year)
                .GreaterThan(2005).WithMessage("Ano não pode ser menor que o primeiro ano da campanha ou maior que o ano vigente!")
                .LessThanOrEqualTo(DateTime.Now.AddYears(1).Year).WithMessage("Descrição não pode ser em branco!");
                
            RuleFor(campanha => campanha.Description)
                .NotEmpty().WithMessage("Descrição não pode ser em branco!");
        }
    }
}