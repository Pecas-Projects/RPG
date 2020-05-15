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
            this.Forca = 20;
            this.PerdaEstamina = 0.25;
            this.GanhoEstamnina = 0.15;
            this.Escudo = 50;
        }

        /// <summary>
        /// A cada quatro rodadas zera a estamina do seu oponente porem precisa
        /// estar com a sua estamina em no minimo 85% 
        /// FALTA TER O CONTROLE DOS TURNOS PARA COLOCAR COMO CONDIÇÃO DO ATAQUE!!
        /// </summary>
        /// <param name="inimigo"></param>
        public override void ataqueEspecial(Personagem inimigo)
        {
            if(this.Estamina >= 0.85)
            {
                inimigo.Estamina = 0;
            }
        }

        /// <summary>
        /// Se for ataque return 1
        /// Se for escudo return 0
        /// Se for descanço return -1
        /// </summary>
        /// <param name="inimiga"></param>
        /// <returns></returns>
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
                        usarEscudo();
                        return 0;
                    }
                    //Verifica se é vantajoso atacar
                    else if (this.Estamina >= 0.7)
                    {
                        if( decisao == 0 || decisao == 1)
                        {
                                atacar(inimiga);
                                return 1;
                        }
                        else
                        {
                            descansar();
                            return -1;
                        }
                    }
                    //Caso nao tenha nenhuma alternativa
                    else
                    {
                        descansar();
                        return -1;
                    }
                }
                //Chance de Ataque de 30%
                else if(dado >= 5 && dado < 8)
                {
                    //verifica se ele tem estamina
                    if( this.Estamina >= this.PerdaEstamina)
                    {
                        atacar(inimiga);
                        return 1;
                    }
                    else
                    {
                        descansar();
                        return -1;
                    }
                }
                else
                {
                    descansar();
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
                        atacar(inimiga);
                        return 1;
                    }
                    else
                    {
                        //decide entre defender e descansar
                        if(decisao ==0 || decisao == 1)
                        {
                            if( this.Escudo > 0)
                            {
                                usarEscudo();
                                return 0;
                            }
                            else
                            {
                                descansar();
                                return -1;
                            }
                        }
                        else
                        {
                            descansar();
                            return -1;
                        }
                    }
                }
                // Chance de usar escudo de 30% 
                else if( dado >= 6 && dado <= 8 )
                {
                    if(this.Escudo > 0)
                    {
                        usarEscudo();
                        return 0;
                    }
                    else
                    {
                        descansar();
                        return -1;
                    }
                }
                else
                {
                    descansar();
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
                        usarEscudo();
                        return 0;
                    }
                    //caso nao tenha ele verifica a estamina e ataca
                    else if( this.Estamina >= this.PerdaEstamina)
                    {
                        atacar(inimiga);
                        return 1;
                    }
                    else
                    {
                        descansar();
                        return -1;
                    }
                }
                // Chance de atacar de 40%
                else if (dado >=5 && dado <= 8)
                {
                    //verifica se ele tem estamina
                    if( this.Estamina >= this.PerdaEstamina)
                    {
                        atacar(inimiga);
                        return 1;
                    }
                    else if(this.Escudo > 0)
                    {
                        usarEscudo();
                        return 0;
                    }
                    else
                    {
                        descansar();
                        return -1;
                    }

                }
                //Chance de descançar de 10%
                else
                {
                    //Confere se vale a pena descansar
                    if( this.Estamina <= 0.7)
                    {
                        descansar();
                        return -1;
                    }
                    else if( this.Escudo > 15)
                    {
                        usarEscudo();
                        return 0;
                    }
                    else
                    {
                        atacar(inimiga);
                        return -1;
                    }
                }
            }
            
        }
    }
}
