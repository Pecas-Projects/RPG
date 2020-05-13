using System;
using System.Collections.Generic;
using System.Text;

namespace MeuRPGZinCore
{
    class HumanoNPC : Personagem, PersonagemNPC
    {

        public HumanoNPC()
        {
            this.forca = 30;
            this.perdaEstamina = 0.2;
            this.ganhoEstamnina = 0.1;
            this.escudo = 40;
        }

        /// <summary>
        /// Caso o a estamida seja maior que 80% ele pode desativar o escudo da feiticeira
        /// e dar um "Contra-Ataque"
        /// </summary>
        /// <param name="inimigo"></param>
        public override void ataqueEspecial(Personagem inimigo)
        {
            if (this.estamina > 0.8)
            {
                inimigo.escudoAtivo = false;
                this.atacar(inimigo);
            }
        }

        public void inteligencia(Feiticeira inimiga)
        {
            throw new NotImplementedException();
        }
    }
}
