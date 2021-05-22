using System;

namespace WebAPI.Models
{
    public class UsuarioModelo
    {        
        public int ID { get; set; }        

        public string Login { get; set; }

        public string Senha { get; set; }

        public DateTime? Dtcriacao { get; set; }

        public bool? Excluido { get; set; }
        
        //public virtual ICollection<Pessoa> Pessoas { get; set; }
        //public virtual ICollection<Reuniao> Reuniaos { get; set; }

    }
}