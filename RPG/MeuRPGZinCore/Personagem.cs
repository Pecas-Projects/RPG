using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{   /// <summary>
    /// Classe abstrata que implementa todas as funções 
    ///básicas de um personagem:
    ///- Ataque (atacar)
    ///- Defesa (usar escudo)
    ///- Descansar
    ///- Verifica se o personagem morreu (EstaMorto)
    ///Além disso, possui o método abstrato "ataqueEspecial"
    ///que será implementado pelas classes filhas
    /// </summary>
    public abstract class Personagem
    {
        public double Forca { get; set; }
        public double Vida { get; set; } = 100;
        public Uri ImagemPersonagem { get; set; }

        /// <summary>
        /// ATENÇÃO: A estamina é um numero entre 0 e 1
        /// </summary>
        public double Estamina { get; set; } = 1;

        /// <summary>
        /// Quantidade de estamina que é perdida após realizar um ataque na batalha de turnos
        /// -Varia para cada classe filha
        /// </summary>
        public double PerdaEstamina { get; set; }

        /// <summary>
        /// Quantidade de estamina recebida a cada turno
        /// -Varia para cada classe filha
        /// </summary>
        public double GanhoEstamnina { get; set; }

        /// <summary>
        /// Valor que determina a capacidade de defesa do personagem
        /// -Varia para cada classe filha
        /// </summary>
        public double Escudo { get; set; }

        /// <summary>
        /// Variável que controla a função "usarEscudo()"
        /// </summary>
        public bool EscudoAtivo { get; set; } = false;

        /// <summary>
        /// Metodo void que calcula o Dano dado no oponente.
        /// Leva em consideração a estamina e a força do personagem, o escudo do inimigo.
        /// </summary>
        public void Atacar(Personagem inimigo)
        {
            double dano;

            if(this.Estamina >= this.PerdaEstamina)
            {

                if (inimigo.EscudoAtivo == true)
                {
                    dano = (this.Forca * this.Estamina) - inimigo.Escudo;
                    if(dano < 0)
                    {
                        //Caso o personagem seja atacado com o escudo ativo, o escudo se desgasta
                        inimigo.Escudo -= (this.Forca * this.Estamina) * 0.35;
                    }
                    else if (dano > 0)
                    {
                        inimigo.Vida -= dano;
                        inimigo.Escudo -= (this.Forca * this.Estamina) * 0.25;
                    }
                    
                }
                else
                {
                    inimigo.Vida -= (this.Forca * this.Estamina);

                }

                this.Estamina -= this.PerdaEstamina;
            }
            else
            {
                //Algo no fronte que impessa isso
                Console.WriteLine("Nao pode uiuiuiuiui!!");
            }

            if (inimigo.Escudo < 0)
            {
                inimigo.Escudo = 0;
            }

        }

        /// <summary>
        /// Função que varia para cada tipo de personagem, mudando as condiçoes para realizar o ataque 
        /// e o seu efeito
        /// </summary>
        /// <param name="inimigo"></param>
        public abstract void AtaqueEspecial(Personagem inimigo);

        public void UsarEscudo()
        {
            if (this.Escudo > 0)
            {
                this.EscudoAtivo = true;
            }
            
        }

        /// <summary>
        /// Ao descansar, o personagem deixa sua recuperação de estamina fica 2x mais eficiente.
        /// </summary>
        public void Descansar() 
        {
            this.Estamina += this.GanhoEstamnina * 2;   
        }


        public bool EstaMorto()
        {
            if (this.Vida <= 0) return true;
            else return false;
            //ALGUMA COISA COM EVENTO NO FRONT
        }
    }
}
