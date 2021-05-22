using Dominio.Entidades;
using Dominio.Interfaces;
using Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dados.Repositorio
{
    public class TecWEBRepositorio<TEntity> : IRepositorioBase<TEntity> where TEntity : EntidadeBase
    {
        private readonly SqlServerContext contexto;

        public TecWEBRepositorio(SqlServerContext _connection)
        {
            this.contexto = _connection;
        }

        public TEntity Select(int id)
        {
            return contexto.Set<TEntity>().Find(id);
        }

        public IList<TEntity> Select()
        {
            return contexto.Set<TEntity>().ToList();
        }        

        public void Update(TEntity obj)
        {
            contexto.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity obj)
        {
            contexto.Set<TEntity>().Add(obj);
            contexto.SaveChanges();
        }        
    }
}
