using System;
using System.Collections.Generic;
using System.Text;

namespace MeuRPGZinCore
{
    public class Labirinto2 : Labirinto
    {
        public Labirinto2()
        {
            //setar moedas labirinto 2
            moedas.Add(new Moeda { X = 9, Y = 1 });
            moedas.Add(new Moeda { X = 9, Y = 2 });
            moedas.Add(new Moeda { X = 9, Y = 3 });
            moedas.Add(new Moeda { X = 8, Y = 3 });
            moedas.Add(new Moeda { X = 8, Y = 5 });
            moedas.Add(new Moeda { X = 7, Y = 5 });
            moedas.Add(new Moeda { X = 6, Y = 0 });
            moedas.Add(new Moeda { X = 6, Y = 1 });
            moedas.Add(new Moeda { X = 2, Y = 5 });
            moedas.Add(new Moeda { X = 1, Y = 4 });
            moedas.Add(new Moeda { X = 1, Y = 5 });

            //linha 1
            linha1.Add(new Parede { topo = true });
            linha1.Add(new Parede { topo = true, direita = true });
            linha1.Add(new Parede { esquerda = true, baixo = true });
            linha1.Add(new Parede { topo = true, baixo = true });
            linha1.Add(new Parede { topo = true, baixo = true });
            linha1.Add(new Parede { topo = true, direita = true });
            linha1.Add(new Parede { topo = true, esquerda = true, baixo = true });
            linha1.Add(new Parede { topo = true, baixo = true });
            linha1.Add(new Parede { topo = true, direita = true }); //linha coordenada da saida

            //linha2
            linha2.Add(new Parede { esquerda = true, direita = true });
            linha2.Add(new Parede { direita = true, esquerda = true });
            linha2.Add(new Parede { topo = true, esquerda = true });
            linha2.Add(new Parede { topo = true, direita = true });
            linha2.Add(new Parede { topo = true, esquerda = true, baixo = true });
            linha2.Add(new Parede()); //livre
            linha2.Add(new Parede { topo = true, direita = true });
            linha2.Add(new Parede { topo = true, esquerda = true });
            linha2.Add(new Parede { direita = true });

            //linha3
            linha3.Add(new Parede { direita = true, esquerda = true, baixo = true });
            linha3.Add(new Parede { direita = true, esquerda = true });
            linha3.Add(new Parede { direita = true, esquerda = true });
            linha3.Add(new Parede { esquerda = true, baixo = true });
            linha3.Add(new Parede { topo = true, direita = true });
            linha3.Add(new Parede { esquerda = true, direita = true });
            linha3.Add(new Parede { esquerda = true, direita = true });
            linha3.Add(new Parede { esquerda = true, direita = true });
            linha3.Add(new Parede { direita = true, baixo = true });

            //linha4
            linha4.Add(new Parede { topo = true, esquerda = true });
            linha4.Add(new Parede { direita = true, baixo = true });
            linha4.Add(new Parede { direita = true, esquerda = true });
            linha4.Add(new Parede { topo = true, esquerda = true, direita = true });
            linha4.Add(new Parede { direita = true, esquerda = true });
            linha4.Add(new Parede { esquerda = true, direita = true });
            linha4.Add(new Parede { esquerda = true, baixo = true });
            linha4.Add(new Parede { baixo = true });
            linha4.Add(new Parede { topo = true, direita = true });

            //linha 5
            linha5.Add(new Parede { direita = true, esquerda = true });
            linha5.Add(new Parede { topo = true, baixo = true, esquerda = true });
            linha5.Add(new Parede { baixo = true });
            linha5.Add(new Parede { direita = true });
            linha5.Add(new Parede { esquerda = true, baixo = true });
            linha5.Add(new Parede { direita = true, baixo = true });
            linha5.Add(new Parede { topo = true, esquerda = true });
            linha5.Add(new Parede { topo = true, direita = true });
            linha5.Add(new Parede { esquerda = true, direita = true });

            //linha 6
            linha6.Add(new Parede { esquerda = true, baixo = true });
            linha6.Add(new Parede { topo = true, direita = true });
            linha6.Add(new Parede { topo = true, direita = true, esquerda = true });
            linha6.Add(new Parede { esquerda = true, direita = true });
            linha6.Add(new Parede { topo = true, esquerda = true });
            linha6.Add(new Parede { topo = true, baixo = true });
            linha6.Add(new Parede { baixo = true, direita = true });
            linha6.Add(new Parede { esquerda = true, baixo = true });
            linha6.Add(new Parede { baixo = true, direita = true });

            //linha 7
            linha7.Add(new Parede { topo = true, esquerda = true, direita = true });
            linha7.Add(new Parede { esquerda = true, baixo = true });
            linha7.Add(new Parede { }); //livre
            linha7.Add(new Parede { direita = true, baixo = true });
            linha7.Add(new Parede { esquerda = true, direita = true });
            linha7.Add(new Parede { esquerda = true, topo = true });
            linha7.Add(new Parede { topo = true, direita = true });
            linha7.Add(new Parede { esquerda = true, topo = true });
            linha7.Add(new Parede { topo = true, direita = true });

            //linha 8 
            linha8.Add(new Parede { esquerda = true });
            linha8.Add(new Parede { topo = true, baixo = true });
            linha8.Add(new Parede { baixo = true, direita = true });
            linha8.Add(new Parede { esquerda = true, topo = true, direita = true });
            linha8.Add(new Parede { esquerda = true, direita = true });
            linha8.Add(new Parede { esquerda = true });
            linha8.Add(new Parede { baixo = true });
            linha8.Add(new Parede { baixo= true, direita = true });
            linha8.Add(new Parede { esquerda = true, direita = true });


            //linha9
            linha9.Add(new Parede { esquerda = true, baixo = true, direita = true });
            linha9.Add(new Parede { esquerda = true, topo = true, baixo = true });
            linha9.Add(new Parede { topo = true, baixo = true });
            linha9.Add(new Parede { baixo = true });
            linha9.Add(new Parede { baixo = true });
            linha9.Add(new Parede { baixo = true });
            linha9.Add(new Parede { topo = true, baixo = true });
            linha9.Add(new Parede { topo = true, baixo = true });
            linha9.Add(new Parede { baixo = true });

        }

        public override bool TemItem(int x, int y, Feiticeira bia)
        {
            bool pegou1 = false, pegou2 = false;
            PocaoRadix pocao_radix = new PocaoRadix();
            PocaoVitae pocao_vitae = new PocaoVitae();

            if (x == 7 && y == 0 && pegou1 == false) //radix
            {
                pegou1 = true;
                bia.mochila.AddItem(pocao_radix, bia.mochila.bagRadix);
                return true;

            }

            if(x == 1 && y == 6 && pegou2 == false) //vitae
            {
                pegou2 = true;
                bia.mochila.AddItem(pocao_vitae, bia.mochila.bagVitae);
                return true;

            }

            return false;
        }
    }

}