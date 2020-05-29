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
        public int ContDefesaFeiticeira { get; set; } = 0;
        public int ContDefesaInimigo { get; set; } = 0;
        public int ContAtaqueFeiticeira { get; set; } = 0;
        public int ContAtaqueInimigo { get; set; } = 0;
        public int ContDescancarFeiticeira { get; set; } = 0;
        public int ContDescancarInimigo { get; set; } = 0;

        public Personagem Vencedor(Personagem jogadora, Personagem inimigo)
        {
            if (jogadora.EstaMorto())
            {
                return inimigo;
            }
            else if(inimigo.EstaMorto())
            {
                return jogadora;
            }
            else
            {
                return null;
            }
        }

        public void RecargaEstamina(Personagem jogadora, Personagem inimigo)
        {
            jogadora.Estamina += jogadora.GanhoEstamnina;
            inimigo.Estamina += inimigo.GanhoEstamnina;

            if(jogadora.Estamina > 1)
            {
                jogadora.Estamina = 1;
            }

            if (inimigo.Estamina > 1)
            {
                inimigo.Estamina = 1;
            }

        }

        public void RelatorioTurno(int jogadora, int inimigo)
        {
            if(inimigo == -1)
            {
                this.ContDescancarInimigo++;
            }
            else if(inimigo == 0)
            {
                this.ContDefesaInimigo++;
            }
            else if(inimigo == 1)
            {
                this.ContAtaqueInimigo++;
            }

            if(jogadora == -1)
            {
                this.ContDescancarFeiticeira++;
            }
            else if(jogadora == 0)
            {
                this.ContDefesaFeiticeira++;
            }
            else if (jogadora == 1)
            {
                this.ContAtaqueFeiticeira++;
            }
        }



        public Personagem FimDeTurno(Personagem jogadora, Personagem inimigo, int acaoJogadora, int acaoInimigo)
        {
            this.RecargaEstamina(jogadora, inimigo);

            this.RelatorioTurno(acaoJogadora, acaoInimigo);

            jogadora.EscudoAtivo = false;
            inimigo.EscudoAtivo = false;

            return this.Vencedor(jogadora, inimigo);

        }

        public void UsarItemUtilizavel(Feiticeira jogadora, Item item)
        {
            item.Utilizar(jogadora);
        }

        public void DesativarItemDesativavel(Feiticeira jogadora, ItemDesativado item)
        {
            item.DesativarItem(jogadora);
        }



    }
}
