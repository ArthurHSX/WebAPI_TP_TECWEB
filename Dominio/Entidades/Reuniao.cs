using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public partial class Reuniao : EntidadeBase
    {
        public Reuniao()
        {
            ReuniaoPessoas = new HashSet<ReuniaoPessoa>();
        }
        
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? Dtcriacao { get; set; }
        public DateTime? Dataincio { get; set; }
        public DateTime? Datafim { get; set; }
        public bool? Excluido { get; set; }
        public int? Usuariocriador { get; set; }
        public int? IdLocal { get; set; }

        public virtual ReuniaoLocal IdLocalNavigation { get; set; }
        public virtual Usuario UsuariocriadorNavigation { get; set; }
        public virtual ICollection<ReuniaoPessoa> ReuniaoPessoas { get; set; }
    }
}
