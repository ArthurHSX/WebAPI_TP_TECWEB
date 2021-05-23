using Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.Interfaces
{
    public interface IRepositorioBase<TEntity> where TEntity : EntidadeBase
    {
        TEntity Select(int id);        
        IList<TEntity> Select();
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(int id);
    }
}
