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
    /// Arrogante, sorrateiro, cuidadoso e sabio
    /// O personagem SAGAZ
    /// </summary>
   public class SereianosNPC : Personagem, PersonagemNPC
    {
       public SereianosNPC()
        {
            this.forca = 20;
            this.perdaEstamina = 0.25;
            this.ganhoEstamnina = 0.15;
            this.escudo = 50;
        }

        /// <summary>
        /// A cada quatro rodadas zera a estamina do seu oponente porem precisa
        /// estar com a sua estamina em no minimo 85% 
        /// FALTA TER O CONTROLE DOS TURNOS PARA COLOCAR COMO CONDIÇÃO DO ATAQUE!!
        /// </summary>
        /// <param name="inimigo"></param>
        public override void ataqueEspecial(Personagem inimigo)
        {
            if(this.estamina >= 0.85)
            {
                inimigo.estamina = 0;
            }
        }

        public void inteligencia(Feiticeira inimiga)
        {
            //Sorteia os numeros para a inteligencia 
            Random radNum = new Random();
            int dado =  radNum.Next(9);
            int decisao = radNum.Next(2);

            //Caso entre neste if ele ira preferir DEFENDER
            if(this.estamina <= inimiga.estamina && this.vida < inimiga.vida)
            {
                //Chance de 60% de defender
                if(dado >= 0 && dado < 5)
                {
                    //Verifica se ele tem escudo
                    if(this.escudo > 0)
                    {
                        usarEscudo();
                    }
                    //Verifica se é vantajoso atacar
                    else if (this.estamina >= 0.7)
                    {
                        if( decisao == 0 || decisao == 1)
                        {
                                atacar(inimiga);
                        }
                        else
                        {
                            descansar();
                        }
                    }
                    //Caso nao tenha nenhuma alternativa
                    else
                    {
                        descansar();
                    }
                }
                //Chance de Ataque de 30%
                else if(dado >= 5 && dado < 8)
                {
                    //verifica se ele tem estamina
                    if( this.estamina >= this.perdaEstamina)
                    {
                        atacar(inimiga);
                    }
                    else
                    {
                        descansar();
                    }
                }
                else
                {
                    descansar();

                }
            }
            //Caso entre neste if ele prefere atacar
            else if( this.estamina > inimiga.estamina && this.vida >= inimiga.vida)
            {
                //cance de 70% de ataque
                if( dado >= 0 && dado < 6)
                {
                    //verifica estamina
                    if(this.estamina >= this.perdaEstamina)
                    {
                        atacar(inimiga);
                    }
                    else
                    {
                        //decide entre defender e descansar
                        if(decisao ==0 || decisao == 1)
                        {
                            if( this.escudo > 0)
                            {
                                usarEscudo();
                            }
                            else
                            {
                                descansar();
                            }
                        }
                        else
                        {
                            descansar();
                        }
                    }
                }
                // Chance de usar escudo de 30% 
                else if( dado >= 6 && dado <= 8 )
                {
                    if(this.escudo > 0)
                    {
                        usarEscudo();
                    }
                    else
                    {
                        descansar();
                    }
                }
                else
                {
                    descansar();
                }
            }
            // Caso nao se encaixe em nenhuma ocasião especifica entra neste else
            else
            {
                //Chance de usar escudo de 50%
                if( dado >= 0 && dado <= 4)
                {
                    //verifica se ele tem escudo
                    if(this.escudo > 0)
                    {
                        usarEscudo();
                    }
                    //caso nao tenha ele verifica a estamina e ataca
                    else if( this.estamina >= this.perdaEstamina)
                    {
                        atacar(inimiga);
                    }
                    else
                    {
                        descansar();
                    }
                }
                // Chance de atacar de 40%
                else if (dado >=5 && dado <= 8)
                {
                    //verifica se ele tem estamina
                    if( this.estamina >= this.perdaEstamina)
                    {
                        atacar(inimiga);
                    }
                    else if(this.escudo > 0)
                    {
                        usarEscudo();
                    }
                    else
                    {
                        descansar();
                    }

                }
                //Chance de descançar de 10%
                else
                {
                    //Confere se vale a pena descansar
                    if( this.estamina <= 0.7)
                    {
                        descansar();
                    }
                    else if( this.escudo > 15)
                    {
                        usarEscudo();
                    }
                    else
                    {
                        atacar(inimiga);
                    }
                }
            }
            
        }
    }
}
