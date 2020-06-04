using System;
using System.Collections.Generic;
using System.Text;

namespace MeuRPGZinCore
{
    public class BarbaroNPC : Personagem, PersonagemNPC
    {
        public BarbaroNPC()
        {
            this.Forca = 35;
            this.PerdaEstamina = 0.3;
            this.GanhoEstamnina = 0.2;
            this.Escudo = 70;
            this.ImagemPersonagem = new Uri("ms-appx:///Assets/barbaro_front.png");
        }

        public int Acao(Feiticeira inimiga, ControllerBatalha controller)
        {
            throw new NotImplementedException();
        }

        public override void ataqueEspecial(Personagem inimigo)
        {
            throw new NotImplementedException();
        }

        public int Inteligencia(Feiticeira inimiga)
        {
            throw new NotImplementedException();
        }
    }
}
