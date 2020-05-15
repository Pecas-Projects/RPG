using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    public abstract class Personagem
    {
        public double forca { get; set; }
        public double vida { get; set; } = 100;

        /// <summary>
        /// ATENÇÃO: A estamina é um numero entre 0 e 1
        /// </summary>
        public double estamina { get; set; } = 1;
        public double perdaEstamina { get; set; }
        public double ganhoEstamnina { get; set; }

        public double escudo { get; set; }
        public bool escudoAtivo { get; set; } = false;

        /// <summary>
        /// Metodo void que calcula o Dano dado no oponente.
        /// Leva em consideração a estamina e a força do personagem, o escudo do inimigo.
        /// </summary>
        public void atacar(Personagem inimigo)
        {
            double dano;

            if(this.estamina >= this.perdaEstamina)
            {

                if (inimigo.escudoAtivo)
                {
                    dano = (this.forca * this.estamina) - inimigo.escudo;
                    if(dano < 0)
                    {
                        //Caso o personagem seja atacado com o escudo ativo, o escudo se desgasta
                        inimigo.escudo -= (this.forca * this.estamina) * 0.35;
                    }
                    else
                    {
                        inimigo.vida -= dano;
                        inimigo.escudo -= (this.forca * this.estamina) * 0.25;
                    }
                    
                }
                else
                {
                    inimigo.vida -= (this.forca * this.estamina);

                }

                this.estamina -= this.perdaEstamina;
            }
            else
            {
                //Algo no fronte que impessa isso
                Console.WriteLine("Nao pode uiuiuiuiui!!");
            }

        }

        /// <summary>
        /// Função que pode variar para cada tipo de personagem, mudando as condiçoes para realizar o ataque 
        /// e o seu efeito
        /// </summary>
        /// <param name="inimigo"></param>
        public abstract void ataqueEspecial(Personagem inimigo);

        public void usarEscudo()
        {
            escudoAtivo = true;
        }

        /// <summary>
        /// O personagem recebe deixa sua recuperação 2x mais eficiente.
        /// </summary>
        public void descansar() 
        {
            this.estamina += this.ganhoEstamnina * 2;   
        }


        public bool EstaMorto()
        {
            if (this.vida == 0) return true;
            else return false;
            //ALGUMA COISA COM EVENTO NO FRONT
        }
    }
}
