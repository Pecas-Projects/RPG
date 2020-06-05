using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    /// <summary>
    /// Classe filha de "Item".
    /// Recupera 15 pontos de escudo da feiticeira.
    /// </summary>
    public class PocaoRadix : Item
    {
        public PocaoRadix()
        {
            //this.Nome = "Poção Radix";
            this.Utilizado = false;
            this.Preco = 6;
            this.ImagemItem = new Uri("ms-appx:///Assets/pocao_radix.png");
        }

        public override void Utilizar(Feiticeira jogadora)
        {
            jogadora.Escudo += 15;
            this.Utilizado = true;
        }
    }
}
