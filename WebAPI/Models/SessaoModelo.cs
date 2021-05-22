using System;
using Dominio.Entidades;

namespace WebAPI.Models
{
    public class SessaoModelo
    {        
        public int ID { get; set; }
        public DateTime? Dtcriacao { get; set; }
        public Guid? Guid { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; }

    }
}