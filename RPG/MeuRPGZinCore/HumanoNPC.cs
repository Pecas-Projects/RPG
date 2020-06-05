using System;
using System.Collections.Generic;
using System.Text;

namespace MeuRPGZinCore
{
    /// <summary>
    ///Implementa a classe abstrata "Personagem" e a interface "PersonagemNPC".
    /// </summary>
    public class HumanoNPC : Personagem, PersonagemNPC
    {
        /// <summary>
        /// Função que cria Humano.
        /// Ele inicia o jogo com:
        /// Forca = 30; 
        /// PerdaEstamina = 0.2; 
        /// GanhoEstamnina = 0.1; 
        /// Escudo = 40;  
        /// </summary>
        public HumanoNPC()
        {
            this.Forca = 30;
            this.PerdaEstamina = 0.2;
            this.GanhoEstamnina = 0.1;
            this.Escudo = 40;
            this.ImagemPersonagem = new Uri("ms-appx:///Assets/humano.png");
        }

        public int Acao(Feiticeira inimiga, ControllerBatalha controller)
        {
            //fazer
            return 9999;
        }

        /// <summary>
        /// Caso o a estamida seja maior que 80% ele pode desativar o escudo da feiticeira
        /// e dar um "Contra-Ataque"
        /// </summary>
        /// <param name="inimigo"></param>
        public override void AtaqueEspecial(Personagem inimigo)
        {
            if (this.Estamina > 0.8)
            {
                inimigo.EscudoAtivo = false;
                this.Atacar(inimigo);
            }
        }

        public int Inteligencia(Feiticeira inimiga)
        {
            //fazer
            return 9999;
        }
    }
}
