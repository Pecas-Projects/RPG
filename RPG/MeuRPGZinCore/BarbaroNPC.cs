using System;
using System.Collections.Generic;
using System.Text;

namespace MeuRPGZinCore
{
    /// <summary>
    ///Implementa a classe abstrata "Personagem" e a interface "PersonagemNPC".
    /// </summary>
    public class BarbaroNPC : Personagem, PersonagemNPC
    {
        /// <summary>
        /// Função que cria Bárbaro.
        /// Ela inicia o jogo com:
        /// Forca = 35; 
        /// PerdaEstamina = 0.30; 
        /// GanhoEstamnina = 0.2; 
        /// Escudo = 70;  
        /// </summary>
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

        public override void AtaqueEspecial(Personagem inimigo)
        {
            throw new NotImplementedException();
        }

        public int Inteligencia(Feiticeira inimiga)
        {
            throw new NotImplementedException();
        }
    }
}
