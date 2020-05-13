using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    class ObstaculoMortal : Obstaculo
    {
        /// <summary>
        /// Esse método mata o personagem no caso dele colidir com o objeto
        /// </summary>
        /// <param name="persona"></param>
        public override void danoCausado(Personagem persona)
        {
            persona.morrer();
        }
    }
}
