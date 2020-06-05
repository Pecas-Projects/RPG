using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    /// <summary>
    /// Classe abstrata, que define um Item, e possui a sua função de uso.
    /// Cada item possui um preço específico e uma imagem, que são definidos nas classes filhas.
    /// </summary>
   public abstract class Item
    {
        public int Preco { get; set; }

        /// <summary>
        /// Variável que controla o uso de um item durante a batalha de turnos.
        /// </summary>
        public bool Utilizado { get; set; }
        public Uri ImagemItem { get; set; }

         /// <summary>
         /// Método que define com um item é utilizado pela feiticeira.
         /// </summary>
         /// <param name="jogador"></param>
         public abstract void Utilizar(Feiticeira jogador);
    }

}
