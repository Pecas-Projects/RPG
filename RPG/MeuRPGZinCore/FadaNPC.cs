using System;
using System.Collections.Generic;
using System.Text;


namespace MeuRPGZinCore
{
    public class FadaNPC : Personagem, PersonagemNPC
    {
        public FadaNPC()
        {
            this.Forca = 25;
            this.PerdaEstamina = 0.2;
            this.GanhoEstamnina = 0.3;
            this.Escudo = 60;
            this.ImagemPersonagem = new Uri("ms-appx:///Assets/fada_de_chapeu.png");
        }

        public int Acao(Feiticeira inimiga, ControllerBatalha controller)
        {
            throw new NotImplementedException();
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
