using System;
using System.Collections.Generic;
using System.Text;


namespace MeuRPGZinCore
{
    /// <summary>
    ///Mal carater, ladra, ozada, convencida e malandra
    /// </summary>
    public class FadaNPC : Personagem, PersonagemNPC
    {
        /// <summary>
        /// Função que cria Fada.
        /// Ela inicia o jogo com:
        /// Forca = 25; 
        /// PerdaEstamina = 0.2; 
        /// GanhoEstamnina = 0.3; 
        /// Escudo = 60;  
        /// </summary>
        public FadaNPC()
        {
            this.Forca = 25;
            this.PerdaEstamina = 0.2;
            this.GanhoEstamnina = 0.3;
            this.Escudo = 55;
            this.ImagemPersonagem = new Uri("ms-appx:///Assets/fada_de_chapeu.png");

        }

        public int Acao(Feiticeira inimiga, ControllerBatalha controller)
        {
            if (controller.ContAtaqueFeiticeira == 8 &&this.Escudo <= 30 && inimiga.Escudo > 0)
            {
                this.AtaqueEspecial(((Personagem)inimiga));
                controller.ContAtaqueFeiticeira = 0;
                return 2;
            }
            else
            {
                return this.Inteligencia(inimiga);
            }
        }

        /// <summary>
        /// Tendo mais de 60% de estamina a Fada consegue "Roubar o escudo da feiticeira 
        /// em 10 pontos
        /// </summary>
        /// <param name="inimigo"></param>
        public override void AtaqueEspecial(Personagem inimiga)
        {
            if (this.Escudo <= 30 && inimiga.Escudo > 0)
            {
                inimiga.Escudo -= 10;
                this.Escudo += 10;

                if(inimiga.Escudo < 0)
                {
                    inimiga.Escudo = 0;
                }
            }
        }

        public int Inteligencia(Feiticeira inimiga)
        {
            //Sorteia os numeros para a inteligencia 
            Random radNum = new Random();
            int dado = radNum.Next(9);
            int decisao = radNum.Next(2);

            //Caso entre neste if ela é neutra
            if (this.Estamina <= inimiga.Estamina && this.Vida < inimiga.Vida)
            {
                //Chance de 50% de defender
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
                //Chance de Ataque de 40%
                else if (dado >= 4 && dado < 8)
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
                else
                {
                    Descansar();
                    return -1;
                }
            }


            //Caso entre neste if ele prefere atacar
            else if (this.Estamina > inimiga.Estamina && this.Vida >= inimiga.Vida)
            {
                //cance de 90% de ataque
                if (dado >= 0 && dado < 8)
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
                // Chance de usar escudo de 30% 
                else
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

            }

            // Caso nao se encaixe em nenhuma ocasião especifica entra neste else
            else
            {
                //Chance de usar escudo de 50%
                if (dado >= 5 && dado <= 8)
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
                // Chance de atacar de 40%
                else if (dado >= 0 && dado <= 4) 
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
