using System;
using System.Collections.Generic;
using System.Text;


namespace MeuRPGZinCore
{
    class FadaNPC : Personagem, PersonagemNPC
    {
        public FadaNPC()
        {
            this.forca = 25;
            this.perdaEstamina = 0.2;
            this.ganhoEstamnina = 0.3;
            this.escudo = 60;
        }

        public override void ataqueEspecial(Personagem inimigo)
        {
            if(this.estamina > 0.6)
            {
                //alguma coisa para impedir que a feiticeira use o ataque especial dela por um tempo

            }
        }

        public void inteligencia(Feiticeira inimiga)
        {
            throw new NotImplementedException();
        }
    }
}
