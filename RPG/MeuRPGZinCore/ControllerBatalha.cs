using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MeuRPGZinCore
{
    /// <summary>
    /// Classe que controla a Batalha de turnos:
    /// Morte dos personagens, 
    /// Vencedor de uma Batalha, 
    /// Turnos, 
    /// Relatorio de turnos (quantitativo), 
    /// Controle de estamina dos personagens,
    /// Fase em que ocorre a batalha.
    /// </summary>
    public class ControllerBatalha
    {
        public int ContDefesaFeiticeira { get; set; } = 0;
        public int ContDefesaInimigo { get; set; } = 0;
        public int ContAtaqueFeiticeira { get; set; } = 0;
        public int ContAtaqueInimigo { get; set; } = 0;
        public int ContDescancarFeiticeira { get; set; } = 0;
        public int ContDescancarInimigo { get; set; } = 0;
        public int ContTurnos { get; set; } =  0;
        public int Fase { get; set; } = 0;

        public Feiticeira Feiticeira { get; set; }

        /// <summary>
        /// Metodo para identificar o vencedor da Batalha
        /// caso um dos personagens seja identificado como morto, o metodo retornara o vencedor.
        /// Caso ninguem esteja morto, retorna null.
        /// </summary>
        /// <param name="jogadora"></param>
        /// <param name="inimigo"></param>
        /// <returns></returns>
        public Personagem Vencedor(Personagem jogadora, Personagem inimigo)
        {
            if (jogadora.EstaMorto() && jogadora.Vida<inimigo.Vida)
            {
                return inimigo;
            }
            else if(inimigo.EstaMorto() && inimigo.Vida <= jogadora.Vida) 
            {
                return jogadora;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Controla a recarga de Estamina dos personagens após cada turno.
        /// </summary>
        /// <param name="jogadora"></param>
        /// <param name="inimigo"></param>
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

        /// <summary>
        /// Registra de forma quantitativa as ações realizadas durante um turno da batalha.
        /// Registra o número de turnos que ocorreram na batalha.
        /// </summary>
        /// <param name="jogadora"></param>
        /// <param name="inimigo"></param>
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

            this.ContTurnos++;
        }

        /// <summary>
        /// Realiza as atualizações de status apos o fim do turno da batalha: 
        /// Recarga estamina;
        /// Registra o relatorio;
        /// Desativa os escudos;
        /// Verifica se ha algum vencedor.
        /// </summary>
        /// <param name="jogadora"></param>
        /// <param name="inimigo"></param>
        /// <param name="acaoJogadora"></param>
        /// <param name="acaoInimigo"></param>
        /// <returns></returns>
        public Personagem FimDeTurno(Personagem jogadora, Personagem inimigo, int acaoJogadora, int acaoInimigo)
        {
            this.RecargaEstamina(jogadora, inimigo);

            this.RelatorioTurno(acaoJogadora, acaoInimigo);

            jogadora.EscudoAtivo = false;
            inimigo.EscudoAtivo = false;

            if (((Feiticeira)jogadora).ItemdeBatalha[0].Utilizado == true)
            {
               PocaoFortalecedora pocao = new PocaoFortalecedora();
               if (((Feiticeira)jogadora).ItemdeBatalha[0].GetType() == pocao.GetType())
                {
                    this.DesativarItemDesativavel(((Feiticeira)jogadora), (ItemDesativado)((Feiticeira)jogadora).ItemdeBatalha[0]);
                }
            }
            if (((Feiticeira)jogadora).ItemdeBatalha[1].Utilizado == true)
            {
                PocaoFortalecedora pocao = new PocaoFortalecedora();
                if (((Feiticeira)jogadora).ItemdeBatalha[1].GetType() == pocao.GetType())
                {
                    this.DesativarItemDesativavel(((Feiticeira)jogadora), (ItemDesativado)((Feiticeira)jogadora).ItemdeBatalha[1]);
                }
            }
            return this.Vencedor(jogadora, inimigo);
        }

        /// <summary>
        /// Faz com que a feiticeira use um item escolhido para a batalha.
        /// </summary>
        /// <param name="jogadora"></param>
        /// <param name="item"></param>
        public void UsarItemUtilizavel(Feiticeira jogadora, Item item)
        {
            item.Utilizar(jogadora);
        }

        /// <summary>
        /// Desativa os efeitos do item utilizado, caso ele implemente a interface
        /// "ItemDesativado"
        /// </summary>
        /// <param name="jogadora"></param>
        /// <param name="item"></param>
        public void DesativarItemDesativavel(Feiticeira jogadora, ItemDesativado item)
        {
            item.DesativarItem(jogadora);
        }

        /// <summary>
        /// Verifica as condições de ataque especial da Feiticeira.
        /// </summary>
        /// <param name="jogadora"></param>
        /// <param name="inimigo"></param>
        public void ControleAtaqueEspecialFeiticeira(Feiticeira jogadora, Personagem inimigo)
        {
            if(this.ContDefesaInimigo >= 4)
            {
                jogadora.AtaqueEspecial(inimigo);
                this.ContDefesaInimigo = 0;
            }
        }


    }
}
