using System;
using System.Collections.Generic;

#nullable disable

namespace Dominio.Entidades
{
    public partial class Sessao : EntidadeBase
    {
        public DateTime? Dtcriacao { get; set; }
        public Guid? Guid { get; set; }        
        public int IdUsuario { get; set; }
    }
}
