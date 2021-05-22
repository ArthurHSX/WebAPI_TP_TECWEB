using System.Collections.Generic;

namespace Dominio.Entidades
{
    public partial class Pessoa : EntidadeBase
    {
        public Pessoa()
        {
            ReuniaoPessoas = new HashSet<ReuniaoPessoa>();
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public bool? Excluido { get; set; }
        public int? Idusuario { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<ReuniaoPessoa> ReuniaoPessoas { get; set; }
    }
}
