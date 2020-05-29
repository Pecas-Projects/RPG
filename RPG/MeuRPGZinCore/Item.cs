using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
   public abstract class Item
    {
        public String nome { get; set; }
        public int preco { get; set; }
        public bool utilizado { get; set; } // se o item já foi utiilzado ele não deveria ser removido da mochila?

         public abstract void Utilizar(Feiticeira jogador);
    }

}
