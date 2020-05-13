using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    class PocaoWhey : Item, ItemUtilizavel
    {
        PocaoWhey()
        {
            this.nome = "Poção de Whey";
            this.utilizado = false;
        }
        public void utilizar(Personagem jogador) //aumenta 30% da estamina
        {
            jogador.estamina += jogador.estamina * 0.3;
            this.utilizado = true;
        }
    }
}
