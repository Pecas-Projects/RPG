using System;
using System.Collections.Generic;
using System.Text;


namespace MeuRPGZinCore
{
    class FadaNPC : Personagem, PersonagemNPC
    {
        public FadaNPC()
        {
            this.Forca = 25;
            this.PerdaEstamina = 0.2;
            this.GanhoEstamnina = 0.3;
            this.Escudo = 60;
        }

        public override void ataqueEspecial(Personagem inimigo)
        {
            if(this.Estamina > 0.6)
            {
                //alguma coisa para impedir que a feiticeira use o ataque especial dela por um tempo

            }
        }

        public int Inteligencia(Feiticeira inimiga)
        {
            throw new NotImplementedException();
        }
    }
}
