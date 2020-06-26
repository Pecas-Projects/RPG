using System;
using System.Collections.Generic;
using System.Text;

namespace MeuRPGZinCore
{
    /// <summary>
    /// Esperto, maligno, toxico e opressor (lixo em forma de ser vivo)
    ///Implementa a classe abstrata "Personagem" e a interface "PersonagemNPC".
    /// </summary>
    public class HumanoNPC : Personagem, PersonagemNPC
    {
        /// <summary>
        /// Função que cria Humano.
        /// Ele inicia o jogo com:
        /// Forca = 30; 
        /// PerdaEstamina = 0.2; 
        /// GanhoEstamnina = 0.1; 
        /// Escudo = 40;  
        /// </summary>
        public HumanoNPC()
        {
            this.Forca = 0;
            //this.Forca = 30;
            this.PerdaEstamina = 0.2;
            this.GanhoEstamnina = 0.1;
            this.Escudo = 40;
            this.ImagemPersonagem = new Uri("ms-appx:///Assets/humano.png");
        }

        public int Acao(Feiticeira inimiga, ControllerBatalha controller)
        {
            if (controller.ContAtaqueFeiticeira == 6 && this.Estamina >= 0.7 && inimiga.EscudoAtivo)
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
        /// Caso o a estamida seja maior que 80% ele pode desativar o escudo da feiticeira
        /// e dar um "Contra-Ataque"
        /// </summary>
        /// <param name="inimigo"></param>
        public override void AtaqueEspecial(Personagem inimigo)
        {
            if (this.Estamina > 0.8)
            {
                inimigo.EscudoAtivo = false;
                this.Atacar(inimigo);
            }
        }

        public int Inteligencia(Feiticeira inimiga)
        {
            //Sorteia os numeros para a inteligencia 
            Random radNum = new Random();
            int dado = radNum.Next(9);
            int decisao = radNum.Next(2);


            //Caso entre neste if ele ira preferir DEFENDER
            if (this.Estamina <= inimiga.Estamina && this.Vida < inimiga.Vida)
            {
                //Chance de 70% de defender
                if (dado >= 0 && dado < 7)
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
                //Chance de Ataque de 30%
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
            //Caso entre neste if ele prefere atacar
            else if (this.Estamina > inimiga.Estamina && this.Vida >= inimiga.Vida)
            {
                //cance de 90% de ataque
                if (dado >= 0 && dado < 9)
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
                // Chance de usar escudo de 10% 
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
                //Chance de usar escudo de 30%
                if (dado >= 0 && dado <= 3)
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
                // Chance de atacar de 70%
                else
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

            }

        }
    }
}
