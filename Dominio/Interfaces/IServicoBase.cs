using Dominio.Entidades;
using FluentValidation;
using System.Collections.Generic;


namespace Dominio.Interfaces
{    
    public interface IServicoBase<TEntity> where TEntity : EntidadeBase
    {
        TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;

        void Delete(int id);

        IEnumerable<TOutputModel> Get<TOutputModel>() where TOutputModel : class;

        //TOutputModel GetByNome<TOutputModel>(string nome) where TOutputModel : class;

        TOutputModel GetById<TOutputModel>(int id) where TOutputModel : class;

        TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;
    }
}
