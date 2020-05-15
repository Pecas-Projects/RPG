using System;
using System.Collections.Generic;
using System.Text;

namespace MeuRPGZinCore
{
    /// <summary>
    /// Morde dos personagens,
    /// Vencedor de uma Batalha,
    /// Turnos,
    /// Relatorio de turnos (quantitativo)
    /// Controle de estamina
    /// </summary>
    public class ControllerBatalha 
    {
        
        public Personagem FimDeJogo(Personagem jogadora, Personagem inimigo)
        {
            if(jogadora.EstaMorto())
            {
                return inimigo;
            }
            else
            {
                return jogadora;
            }

        }

        public void RecargaEstamina(Feiticeira jogadora, Personagem Inimigo)
        {

        }

        public void RelatorioTurno()
        {

        }



        public void Batalha()
        {

        }


        
    }
}
