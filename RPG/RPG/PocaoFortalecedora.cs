using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    class PocaoFortalecedora : Item, ItemDesativado, ItemUtilizavel
    {
        PocaoFortalecedora()
        {
            this.nome = "Poção Fortalecedora";
            this.utilizado = false;
        }

        public void DesativarItem(Personagem jogador)
        {
            throw new NotImplementedException();
        }

        public void utilizar(Personagem jogador) //aumenta 15% da forca
        {
            jogador.forca += jogador.forca * 0.15;
            this.utilizado = true;
        }
    }
}
