using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    public class PocaoRadix : Item, ItemDesativado
    {
        double aux;
        public PocaoRadix()
        {
            this.nome = "Poção Radix";
            this.utilizado = false;
            this.preco = 4;
        }

        public void DesativarItem(Feiticeira jogador)
        {
            jogador.Forca -= aux;
            jogador.mochila.RemoverItem(jogador.mochila.bagRadix);
        }

        public override void Utilizar(Feiticeira jogador) //aumenta em 20% a força 
        {
            aux = jogador.Forca * 0.2;
            jogador.Forca += aux;
            this.utilizado = true;
        }
    }
}
