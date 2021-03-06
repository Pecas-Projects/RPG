﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MeuRPGZinCore
{
    /// <summary>
    /// Classe filha de Labirinto. 
    /// Classe que corresponde ao labirinto da primeira fase.
    /// </summary>
    public class Labirinto1 : Labirinto
    { 

        public Labirinto1()
        {
            moedas.Add(new Moeda { X = 1, Y = 4 });
            moedas.Add(new Moeda { X = 1, Y = 5 });
            moedas.Add(new Moeda { X = 1, Y = 7 });
            moedas.Add(new Moeda { X = 2, Y = 7 });
            moedas.Add(new Moeda { X = 3, Y = 7 });
            moedas.Add(new Moeda { X = 9, Y = 7 });
            moedas.Add(new Moeda { X = 9, Y = 6 });
            moedas.Add(new Moeda { X = 9, Y = 5 });

            linha1.Add(new Parede { topo = true, esquerda = true });
            linha1.Add(new Parede { topo = true, baixo = true });
            linha1.Add(new Parede { topo = true, direita = true, baixo = true });
            linha1.Add(new Parede { topo = true, esquerda = true });
            linha1.Add(new Parede { topo = true, baixo =true });
            linha1.Add(new Parede { topo = true });
            linha1.Add(new Parede { topo = true, direita = true});
            linha1.Add(new Parede { topo = true, esquerda = true });
            linha1.Add(new Parede { topo = true }); //linha coordenada da saida

            linha2.Add(new Parede { esquerda = true });
            linha2.Add(new Parede { direita = true, topo = true });
            linha2.Add(new Parede { topo = true, esquerda = true });
            linha2.Add(new Parede()); //linha2[3] tem todas as opcoes livre
            linha2.Add(new Parede { baixo = true, direita = true, topo = true });
            linha2.Add(new Parede { topo = true, esquerda = true });
            linha2.Add(new Parede { topo = true, direita = true });
            linha2.Add(new Parede { esquerda = true, direita = true });
            linha2.Add(new Parede { direita = true, esquerda = true });

            //linha3
            linha3.Add(new Parede { esquerda = true, baixo = true, direita = true });
            linha3.Add(new Parede { esquerda = true, direita = true });
            linha3.Add(new Parede { esquerda = true, direita = true });
            linha3.Add(new Parede { esquerda = true, direita = true });
            linha3.Add(new Parede { esquerda = true, topo = true });
            linha3.Add(new Parede { baixo = true, direita = true });
            linha3.Add(new Parede { esquerda = true, direita = true });
            linha3.Add(new Parede { esquerda = true, direita = true });
            linha3.Add(new Parede { esquerda = true, direita = true, baixo = true });

            //linha4
            linha4.Add(new Parede { esquerda = true, topo = true });
            linha4.Add(new Parede { baixo = true });
            linha4.Add(new Parede { baixo = true, direita = true });
            linha4.Add(new Parede { esquerda = true, direita = true });
            linha4.Add(new Parede { esquerda = true, direita = true });
            linha4.Add(new Parede { esquerda = true, topo = true, direita = true });
            linha4.Add(new Parede { esquerda = true, direita = true });
            linha4.Add(new Parede { esquerda = true, baixo = true });
            linha4.Add(new Parede { direita = true, topo = true });

            //linha 5
            linha5.Add(new Parede { direita = true, esquerda = true });
            linha5.Add(new Parede { topo = true, esquerda = true });
            linha5.Add(new Parede { direita = true, topo = true });
            linha5.Add(new Parede { baixo = true, esquerda = true });
            linha5.Add(new Parede { baixo = true, direita = true });
            linha5.Add(new Parede { esquerda = true });
            linha5.Add(new Parede { baixo = true });
            linha5.Add(new Parede { direita = true, topo = true, baixo = true });
            linha5.Add(new Parede { direita = true, baixo = true, esquerda = true });

            linha6.Add(new Parede { baixo = true, esquerda = true });
            linha6.Add(new Parede { direita = true, baixo = true });
            linha6.Add(new Parede { esquerda = true, baixo = true });
            linha6.Add(new Parede { topo = true, baixo = true });
            linha6.Add(new Parede { direita = true, topo = true });
            linha6.Add(new Parede { direita = true, esquerda = true });
            linha6.Add(new Parede { direita = true, esquerda = true, topo = true });
            linha6.Add(new Parede { topo = true, esquerda = true });
            linha6.Add(new Parede { direita = true });

            //linha7
            linha7.Add(new Parede { esquerda = true, topo = true });
            linha7.Add(new Parede { direita = true, topo = true });
            linha7.Add(new Parede { esquerda = true, topo = true });
            linha7.Add(new Parede { direita = true, topo = true });
            linha7.Add(new Parede { direita = true, esquerda = true });
            linha7.Add(new Parede { esquerda = true, baixo = true });
            linha7.Add(new Parede());//linha7[6] não tem restrições
            linha7.Add(new Parede { direita = true, baixo = true });
            linha7.Add(new Parede { direita = true, topo = true, esquerda = true });

            //linha 8
            linha8.Add(new Parede { direita = true, esquerda = true });
            linha8.Add(new Parede { baixo = true, esquerda = true });
            linha8.Add(new Parede { baixo = true });
            linha8.Add(new Parede { direita = true });
            linha8.Add(new Parede { direita = true, esquerda = true });
            linha8.Add(new Parede { direita = true, esquerda = true, topo = true });
            linha8.Add(new Parede { baixo = true, esquerda = true });
            linha8.Add(new Parede { baixo = true, topo = true });
            linha8.Add(new Parede { direita = true });

            //linha 9
            linha9.Add(new Parede { baixo = true, esquerda = true });
            linha9.Add(new Parede { baixo = true, topo = true });
            linha9.Add(new Parede { baixo = true, topo = true });
            linha9.Add(new Parede { baixo = true });
            linha9.Add(new Parede { baixo = true });
            linha9.Add(new Parede { baixo = true });
            linha9.Add(new Parede { baixo = true, topo = true });
            linha9.Add(new Parede { baixo = true, direita = true, topo = true });
            linha9.Add(new Parede { baixo = true, esquerda = true, direita = true });

        }

        public override bool TemItem(int x, int y, Feiticeira bia)
        {
            bool pegou = false;
            PocaoWhey pocao_whey = new PocaoWhey();

            if (x == 1 && y == 2 && pegou == false)
            {

                pegou = true;
                bia.mochila.AddItem(pocao_whey, bia.mochila.bagWhey);
                return true;
            }
            return false;
        }


    }
}





