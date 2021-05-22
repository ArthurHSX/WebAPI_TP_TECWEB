using FluentValidation;
using Dominio.Entidades;

namespace Servico.Validadores
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c.Login)
                .NotEmpty().WithMessage("O Login não pode ser vazia.")
                .NotNull().WithMessage("O Login não pode ser null.");

            RuleFor(c => c.Senha)
                    .NotEmpty().WithMessage("A Senha não pode ser vazia.")
                    .NotNull().WithMessage("A Senha não pode ser null.");
        }            
    }
}
