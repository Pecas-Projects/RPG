using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    public abstract class Personagem
    {
        public double Forca { get; set; }
        public double Vida { get; set; } = 100;

        /// <summary>
        /// ATENÇÃO: A estamina é um numero entre 0 e 1
        /// </summary>
        public double Estamina { get; set; } = 1;
        public double PerdaEstamina { get; set; }
        public double GanhoEstamnina { get; set; }

        public double Escudo { get; set; }
        public bool EscudoAtivo { get; set; } = false;

        /// <summary>
        /// Metodo void que calcula o Dano dado no oponente.
        /// Leva em consideração a estamina e a força do personagem, o escudo do inimigo.
        /// </summary>
        public void atacar(Personagem inimigo)
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
                    else
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
        /// Função que pode variar para cada tipo de personagem, mudando as condiçoes para realizar o ataque 
        /// e o seu efeito
        /// </summary>
        /// <param name="inimigo"></param>
        public abstract void ataqueEspecial(Personagem inimigo);

        public void usarEscudo()
        {
            if (this.Escudo > 0)
            {
                this.EscudoAtivo = true;
            }
            
        }

        /// <summary>
        /// O personagem recebe deixa sua recuperação 2x mais eficiente.
        /// </summary>
        public void descansar() 
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
