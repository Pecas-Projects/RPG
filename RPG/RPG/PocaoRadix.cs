using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    class PocaoRadix : Item, ItemDesativado, ItemUtilizavel
    {
        double aux;
        PocaoRadix()
        {
            this.nome = "Poção Radix";
            this.utilizado = false;
        }

        public void DesativarItem(Personagem jogador)
        {
            jogador.forca -= aux;
        }

        public void utilizar(Personagem jogador) //aumenta em 20% a força 
        {
            aux = jogador.forca * 0.2;
            jogador.forca += aux;
            this.utilizado = true;
        }
    }
}
