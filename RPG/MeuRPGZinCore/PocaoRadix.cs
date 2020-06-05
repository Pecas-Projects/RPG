using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    /// <summary>
    /// Classe filha de "Item".
    /// Implementa a interface "ItemDesativado".
    /// Aumenta a força da Feiticeira em 20%.
    /// </summary>
    public class PocaoRadix : Item, ItemDesativado
    {
        public PocaoRadix()
        {
            //this.Nome = "Poção Radix";
            this.Utilizado = false;
            this.Preco = 6;
            this.ImagemItem = new Uri("ms-appx:///Assets/pocao_radix.png");
        }

        public void DesativarItem(Feiticeira jogadora)
        {
            double aux = jogadora.Forca * 0.2;
            jogadora.Forca -= aux;
            //jogador.mochila.RemoverItem(jogador.mochila.bagRadix);
        }
     
        public override void Utilizar(Feiticeira jogadora)
        {
            double aux = jogadora.Forca * 0.2;
            jogadora.Forca += aux;
            this.Utilizado = true;
        }
    }
}
