using FluentValidation;
using Dominio.Entidades;

namespace Servico.Validadores
{
    public class SessaoValidator : AbstractValidator<Sessao>
    {
        public SessaoValidator()
        {
            RuleFor(c => c.IdUsuario)
                .NotEmpty().WithMessage("O IdUsuario não pode ser vazio.")
                .NotNull().WithMessage("O IdUsuario não pode ser null.");

            RuleFor(c => c.Guid)
                    .NotEmpty().WithMessage("O Guid não pode ser vazio.")
                    .NotNull().WithMessage("O Guid não pode ser null.");
        }            
    }
}
