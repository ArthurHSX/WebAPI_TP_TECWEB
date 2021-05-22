using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public partial class ReuniaoLocal : EntidadeBase
    {
        public ReuniaoLocal()
        {
            Reuniaos = new HashSet<Reuniao>();
        }
        
        public int? IdLocal { get; set; }
        public DateTime? Dtcriacao { get; set; }
        public bool? Excluido { get; set; }

        public virtual Local IdLocalNavigation { get; set; }
        public virtual ICollection<Reuniao> Reuniaos { get; set; }
    }
}
