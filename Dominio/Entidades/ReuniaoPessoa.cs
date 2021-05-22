using System;

namespace Dominio.Entidades
{
    public partial class ReuniaoPessoa : EntidadeBase
    {        
        public int? IdReuniao { get; set; }
        public int? IdPessoa { get; set; }
        public DateTime? Dtcriacao { get; set; }
        public bool? Exlcuido { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual Reuniao IdReuniaoNavigation { get; set; }
    }
}
