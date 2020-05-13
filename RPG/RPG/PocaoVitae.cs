using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    class PocaoVitae : Item, ItemUtilizavel
    {
        PocaoVitae() //era um construtor que se tentava fazer?
        {
            this.nome = "Poção Vitae";
            this.utilizado = false;

        }

        public void utilizar(Personagem jogador) //aumenta a vida do jogador em 50%
        {
            jogador.vida += jogador.vida * 0.5;
            this.utilizado = true;
        }
    }
}
