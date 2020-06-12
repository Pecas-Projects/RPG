using System;
using System.Collections.Generic;
using System.Text;

namespace MeuRPGZinCore
{
    /// <summary>
    ///Burro, forte, so quer saber de batata doce e Narcisista
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
            if (controller.ContDefesaFeiticeira == 5 && this.Estamina >= 0.3 && inimiga.Estamina > 0)
            {
                this.AtaqueEspecial(((Personagem)inimiga));
                controller.ContDefesaFeiticeira = 0;
                return 2;
            }
            else
            {
                return this.Inteligencia(inimiga);
            }
        }

        /// <summary>
        /// Rouba a metade da estamina da Feiticeira e em seguida ataca
        /// </summary>
        /// <param name="inimigo"></param>
        public override void AtaqueEspecial(Personagem inimiga)
        {
            if (this.Estamina >= 0.3 && inimiga.Estamina > 0)
            {
                this.Estamina += inimiga.Estamina * 0.5;
                inimiga.Estamina -= inimiga.Estamina * 0.5;
                this.Atacar(inimiga);
            }
        }

        public int Inteligencia(Feiticeira inimiga)
        {
            //Sorteia os numeros para a inteligencia 
            Random radNum = new Random();
            int dado = radNum.Next(9);
            int decisao = radNum.Next(2);


            //Caso entre neste if ele ira preferir ATACA
            if (this.Estamina <= inimiga.Estamina && this.Vida < inimiga.Vida)
            {
                //Chance de 40% de defender
                if (dado >= 0 && dado < 4)
                {
                    //Verifica se ele tem escudo
                    if (this.Escudo > 0)
                    {
                        UsarEscudo();
                        return 0;
                    }
                    //Verifica se é vantajoso atacar
                    else if (this.Estamina >= 0.7)
                    {
                        if (decisao == 0 || decisao == 1)
                        {
                            Atacar(inimiga);
                            return 1;
                        }
                        else
                        {
                            Descansar();
                            return -1;
                        }
                    }
                    //Caso nao tenha nenhuma alternativa
                    else
                    {
                        Descansar();
                        return -1;
                    }
                }
                //Chance de Ataque de 60%
                else
                {
                    //verifica se ele tem estamina
                    if (this.Estamina >= this.PerdaEstamina)
                    {
                        Atacar(inimiga);
                        return 1;
                    }
                    else
                    {
                        Descansar();
                        return -1;
                    }
                }
              
            }

            //SO ATACA
            else if (this.Estamina > inimiga.Estamina && this.Vida >= inimiga.Vida)
            {

                    //verifica estamina
                    if (this.Estamina >= this.PerdaEstamina)
                    {
                        Atacar(inimiga);
                        return 1;
                    }
                    else
                    {
                        //decide entre defender e descansar
                        if (decisao == 0 || decisao == 1)
                        {
                            if (this.Escudo > 0)
                            {
                                UsarEscudo();
                                return 0;
                            }
                            else
                            {
                                Descansar();
                                return -1;
                            }
                        }
                        else
                        {
                            Descansar();
                            return -1;
                        }
                    }

            }
            // Caso nao se encaixe em nenhuma ocasião especifica entra neste else
            else
            {
                //Chance de usar escudo de 30%
                if (dado >= 0 && dado <= 2)
                {
                    //verifica se ele tem escudo
                    if (this.Escudo > 0)
                    {
                        UsarEscudo();
                        return 0;
                    }
                    //caso nao tenha ele verifica a estamina e ataca
                    else if (this.Estamina >= this.PerdaEstamina)
                    {
                        Atacar(inimiga);
                        return 1;
                    }
                    else
                    {
                        Descansar();
                        return -1;
                    }
                }
                // Chance de atacar de 60%
                else if (dado >= 4 && dado <= 9)
                {
                    //verifica se ele tem estamina
                    if (this.Estamina >= this.PerdaEstamina)
                    {
                        Atacar(inimiga);
                        return 1;
                    }
                    else if (this.Escudo > 0)
                    {
                        UsarEscudo();
                        return 0;
                    }
                    else
                    {
                        Descansar();
                        return -1;
                    }

                }
                //Chance de descançar de 10%
                else
                {
                    //Confere se vale a pena descansar
                    if (this.Estamina <= 0.7)
                    {
                        Descansar();
                        return -1;
                    }
                    else if (this.Escudo > 15)
                    {
                        UsarEscudo();
                        return 0;
                    }
                    else
                    {
                        Atacar(inimiga);
                        return -1;
                    }
                }
            }

        }
    }
}
