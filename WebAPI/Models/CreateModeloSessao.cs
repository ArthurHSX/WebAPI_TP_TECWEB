using System;
using Dominio.Entidades;

namespace WebAPI.Models
{
    public class CreateModeloSessao
    {
        //public string Guid { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? DtCriacao { get; set; }

        //public virtual Usuario IdusuarioNavigation { get; set; }
    }
}
