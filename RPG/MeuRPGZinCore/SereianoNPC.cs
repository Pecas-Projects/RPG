using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{

    /// <summary>
    /// Arrogante, sorrateiro, cuidadoso e sabio.
    /// O personagem SAGAZ.
    /// Implementa a classe abstrata "Personagem" e a interface "PersonagemNPC".
    /// </summary>
    public class SereianosNPC : Personagem, PersonagemNPC
    {
        /// <summary>
        /// Função que cria Sereiano.
        /// Ele inicia o jogo com:
        /// Forca = 20; 
        /// PerdaEstamina = 0.25; 
        /// GanhoEstamnina = 0.15; 
        /// Escudo = 50;  
        /// </summary>
        public SereianosNPC()
        {
            this.Forca = 0;
            //this.Forca = 20;
            this.PerdaEstamina = 0.25;
            this.GanhoEstamnina = 0.15;
            this.Escudo = 50;
            this.ImagemPersonagem = new Uri("ms-appx:///Assets/rei_sereiano.png");
        }


        public int Acao(Feiticeira inimiga, ControllerBatalha controller)
        {
            if (controller.ContTurnos == 8 && this.Estamina >=0.85)
            {
                this.AtaqueEspecial(((Personagem)inimiga));
                controller.ContTurnos = 0;
                return 2;
            }
            else
            {
                return this.Inteligencia(inimiga);
            }
        }

        /// <summary>
        /// A cada oito rodadas zera a estamina do seu oponente, porém precisa
        /// estar com a sua estamina em no minimo 85% .
        /// </summary>
        /// <param name="inimigo"></param>
        public override void AtaqueEspecial(Personagem inimiga)
        {
            if(this.Estamina >= 0.85)
            {
                inimiga.Estamina = 0;

            }
        }


        public int Inteligencia(Feiticeira inimiga)
        {
            //Sorteia os numeros para a inteligencia 
            Random radNum = new Random();
            int dado =  radNum.Next(9);
            int decisao = radNum.Next(2);


            //Caso entre neste if ele ira preferir DEFENDER
            if(this.Estamina <= inimiga.Estamina && this.Vida < inimiga.Vida)
            {
                //Chance de 60% de defender
                if(dado >= 0 && dado < 5)
                {
                    //Verifica se ele tem escudo
                    if(this.Escudo > 0)
                    {
                        UsarEscudo();
                        return 0;
                    }
                    //Verifica se é vantajoso atacar
                    else if (this.Estamina >= 0.7)
                    {
                        if( decisao == 0 || decisao == 1)
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
                //Chance de Ataque de 30%
                else if(dado >= 5 && dado < 8)
                {
                    //verifica se ele tem estamina
                    if( this.Estamina >= this.PerdaEstamina)
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
            else if( this.Estamina > inimiga.Estamina && this.Vida >= inimiga.Vida)
            {
                //cance de 70% de ataque
                if( dado >= 0 && dado < 6)
                {
                    //verifica estamina
                    if(this.Estamina >= this.PerdaEstamina)
                    {
                        Atacar(inimiga);
                        return 1;
                    }
                    else
                    {
                        //decide entre defender e descansar
                        if(decisao ==0 || decisao == 1)
                        {
                            if( this.Escudo > 0)
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
                else if( dado >= 6 && dado <= 8 )
                {
                    if(this.Escudo > 0)
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
            // Caso nao se encaixe em nenhuma ocasião especifica entra neste else
            else
            {
                //Chance de usar escudo de 50%
                if( dado >= 0 && dado <= 4)
                {
                    //verifica se ele tem escudo
                    if(this.Escudo > 0)
                    {
                        UsarEscudo();
                        return 0;
                    }
                    //caso nao tenha ele verifica a estamina e ataca
                    else if( this.Estamina >= this.PerdaEstamina)
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
                else if (dado >=5 && dado <= 8)
                {
                    //verifica se ele tem estamina
                    if( this.Estamina >= this.PerdaEstamina)
                    {
                        Atacar(inimiga);
                        return 1;
                    }
                    else if(this.Escudo > 0)
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
                    if( this.Estamina <= 0.7)
                    {
                        Descansar();
                        return -1;
                    }
                    else if( this.Escudo > 15)
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
