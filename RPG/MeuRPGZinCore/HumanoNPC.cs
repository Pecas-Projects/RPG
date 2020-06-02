using System;
using System.Collections.Generic;
using System.Text;

namespace MeuRPGZinCore
{
    public class HumanoNPC : Personagem, PersonagemNPC
    {

        public HumanoNPC()
        {
            this.Forca = 30;
            this.PerdaEstamina = 0.2;
            this.GanhoEstamnina = 0.1;
            this.Escudo = 40;
            this.ImagemPersonagem = new Uri("ms-appx:///Assets/humano.png");
        }

        /// <summary>
        /// Caso o a estamida seja maior que 80% ele pode desativar o escudo da feiticeira
        /// e dar um "Contra-Ataque"
        /// </summary>
        /// <param name="inimigo"></param>
        public override void ataqueEspecial(Personagem inimigo)
        {
            if (this.Estamina > 0.8)
            {
                inimigo.EscudoAtivo = false;
                this.atacar(inimigo);
            }
        }

        public int Inteligencia(Feiticeira inimiga)
        {
            throw new NotImplementedException();
        }
    }
}
