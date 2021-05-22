using System;

namespace Dominio.Entidades
{
    public partial class Sessao : EntidadeBase
    {
        public Guid? Guid { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? Dtcriacao { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; }
    }
}
