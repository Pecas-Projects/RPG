using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    class ObstaculoNocivo : Obstaculo
    {
        /// <summary>
        /// Esse método desconta diretamente na vida do personagem atingido pelo objeto o dano que esse causou.
        /// No caso de sua vida ser zerada, ele morre.
        /// </summary>
        /// <param name="persona"></param>
        public override void danoCausado(Personagem persona)
        {
            if (this.dano >= persona.vida)
            {
                persona.morrer();
            }

            persona.vida -= this.dano;

        }
    }
}
