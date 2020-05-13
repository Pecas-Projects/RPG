using System;
using System.Collections.Generic;
using System.Text;

namespace MeuRPGZinCore
{
    class BarbaroNPC : Personagem, PersonagemNPC
    {
        public BarbaroNPC()
        {
            this.forca = 35;
            this.perdaEstamina = 0.3;
            this.ganhoEstamnina = 0.2;
            this.escudo = 70;
        }

        public override void ataqueEspecial(Personagem inimigo)
        {
            throw new NotImplementedException();
        }

        public void inteligencia(Feiticeira inimiga)
        {
            throw new NotImplementedException();
        }
    }
}
