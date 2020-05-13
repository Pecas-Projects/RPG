using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    class Pirlimpimpim : Item, ItemDesativado, ItemUtilizavel
    {
        double aux;

        Pirlimpimpim()
        {
            this.nome = "Pó de Pirlimpimpim";
            this.utilizado = false;
        }

        public void DesativarItem(Personagem jogador)
        {
            jogador.forcaEspecial -= aux;

        }

        public void utilizar(Personagem jogador) //aumenta o ataque especial da feiticeira em 20%
        {
            aux = jogador.forcaEspecial * 0.2;

            jogador.forcaEspecial += aux;
            this.utilizado = true;
        }
    }
}
