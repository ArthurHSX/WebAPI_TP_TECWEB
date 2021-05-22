using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public partial class Local : EntidadeBase
    {
        public Local()
        {
            ReuniaoLocals = new HashSet<ReuniaoLocal>();
        }
        
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? Dtcriacao { get; set; }
        public bool? Excluido { get; set; }

        public virtual ICollection<ReuniaoLocal> ReuniaoLocals { get; set; }
    }
}
