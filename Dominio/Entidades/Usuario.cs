using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public partial class Usuario : EntidadeBase
    {
        //public Usuario()
        //{            
        //    Reunioes = new HashSet<Reuniao>();            
        //}
        
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime? Dtcriacao { get; set; }
        public bool Excluido { get; set; }
        
        //public virtual ICollection<Reuniao> Reunioes { get; set; }        
    }
}
