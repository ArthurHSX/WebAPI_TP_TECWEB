using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public partial class Usuario : EntidadeBase
    {
        public Usuario()
        {
            Pessoas = new HashSet<Pessoa>();
            Reunioes = new HashSet<Reuniao>();
            Sessoes = new HashSet<Sessao>();
        }

        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime? Dtcriacao { get; set; }
        public bool? Excluido { get; set; }

        public virtual ICollection<Pessoa> Pessoas { get; set; }
        public virtual ICollection<Reuniao> Reunioes { get; set; }
        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}
