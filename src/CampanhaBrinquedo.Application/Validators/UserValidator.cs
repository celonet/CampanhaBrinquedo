namespace CampanhaBrinquedo.Domain.Validators
{
    using CampanhaBrinquedo.Domain.Entities.User;
    using FluentValidation;

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(usuario => usuario.Name)
                .NotEmpty().WithMessage("Nome é obrigatorio!")
                .MinimumLength(3).WithMessage("Minimo de 3 caracteres!");
            RuleFor(usuario => usuario.Email)
                .NotEmpty().WithMessage("Email é obrigatorio!")
                .EmailAddress().WithMessage("Email inválido!");
            RuleFor(usuario => usuario.Password)
                .NotEmpty().WithMessage("Senha é obrigatoria")
                .MinimumLength(6).WithMessage("Minimo de 6 caracteres!");
        }
    }
}