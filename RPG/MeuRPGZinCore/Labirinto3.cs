using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MeuRPGZinCore
{
    public class Labirinto3 : Labirinto
    {
        public Labirinto3()
        {
            moedas.Add(new Moeda { X = 9, Y = 6 });
            moedas.Add(new Moeda { X = 9, Y = 7 });
            moedas.Add(new Moeda { X = 8, Y = 1 });
            moedas.Add(new Moeda { X = 7, Y = 1 });
            moedas.Add(new Moeda { X = 7, Y = 6 });
            moedas.Add(new Moeda { X = 6, Y = 3 });
            moedas.Add(new Moeda { X = 5, Y = 4 });
            moedas.Add(new Moeda { X = 5, Y = 6 });
            moedas.Add(new Moeda { X = 5, Y = 7 });
            moedas.Add(new Moeda { X = 1, Y = 1 });
            moedas.Add(new Moeda { X = 1, Y = 2 });

            linha1.Add(new Parede { topo = true });
            linha1.Add(new Parede { topo = true, baixo = true });
            linha1.Add(new Parede { topo = true, baixo = true, direita = true });
            linha1.Add(new Parede { esquerda = true, topo = true });
            linha1.Add(new Parede { topo = true });
            linha1.Add(new Parede { topo = true });
            linha1.Add(new Parede { topo = true, baixo = true });
            linha1.Add(new Parede { topo = true, baixo = true, direita = true });
            linha1.Add(new Parede { topo = true, direita = true, esquerda = true });


            //linha2
            linha2.Add(new Parede { esquerda = true, direita = true });
            linha2.Add(new Parede { esquerda = true, topo = true });
            linha2.Add(new Parede { topo = true, direita = true });
            linha2.Add(new Parede { esquerda = true, direita = true });
            linha2.Add(new Parede { esquerda = true,  direita = true });
            linha2.Add(new Parede { esquerda = true, baixo = true, direita = true });
            linha2.Add(new Parede { topo = true, esquerda = true });
            linha2.Add(new Parede { topo = true, baixo = true });
            linha2.Add(new Parede { direita = true });

            //linha3
            linha3.Add(new Parede { esquerda = true, baixo = true });
            linha3.Add(new Parede { baixo = true, direita = true });
            linha3.Add(new Parede { esquerda = true, baixo = true });
            linha3.Add(new Parede { baixo = true, direita = true });
            linha3.Add(new Parede { esquerda = true, direita = true });
            linha3.Add(new Parede { esquerda = true, topo = true });
            linha3.Add(new Parede());
            linha3.Add(new Parede { topo = true });
            linha3.Add(new Parede { baixo = true, direita = true });

            //linha4
            linha4.Add(new Parede { esquerda = true, topo = true });
            linha4.Add(new Parede { topo = true, direita = true });
            linha4.Add(new Parede { esquerda = true, topo = true });
            linha4.Add(new Parede { topo = true, baixo = true });
            linha4.Add(new Parede { baixo = true, direita = true });
            linha4.Add(new Parede { esquerda = true, direita = true });
            linha4.Add(new Parede { esquerda = true, baixo = true });
            linha4.Add(new Parede { baixo = true });
            linha4.Add(new Parede { topo = true, direita = true });

            //linha5
            linha5.Add(new Parede { esquerda = true, direita = true });
            linha5.Add(new Parede { esquerda = true, baixo = true });
            linha5.Add(new Parede { baixo = true, direita = true });
            linha5.Add(new Parede { esquerda = true, topo = true });
            linha5.Add(new Parede { topo = true, direita = true, baixo = true });
            linha5.Add(new Parede { esquerda = true, baixo = true });
            linha5.Add(new Parede { topo = true });
            linha5.Add(new Parede { topo = true, direita = true, baixo = true });
            linha5.Add(new Parede { esquerda = true, direita = true });

            //linha6
            linha6.Add(new Parede { esquerda = true });
            linha6.Add(new Parede { topo = true });
            linha6.Add(new Parede { topo = true, direita = true });
            linha6.Add(new Parede { esquerda = true, baixo = true });
            linha6.Add(new Parede { topo = true, direita = true });
            linha6.Add(new Parede { esquerda = true, topo = true });
            linha6.Add(new Parede { direita = true });
            linha6.Add(new Parede { esquerda = true, topo = true });
            linha6.Add(new Parede { baixo = true, direita = true });

            //linha7
            linha7.Add(new Parede { esquerda = true, topo = true, direita = true });
            linha7.Add(new Parede { esquerda = true, direita = true });
            linha7.Add(new Parede { esquerda = true, direita = true });
            linha7.Add(new Parede { esquerda = true, topo = true });
            linha7.Add(new Parede { direita = true });
            linha7.Add(new Parede { esquerda = true, direita = true });
            linha7.Add(new Parede { esquerda = true, baixo = true, direita = true });
            linha7.Add(new Parede { esquerda = true, direita = true });
            linha7.Add(new Parede { esquerda = true, topo = true, direita = true });

            //linha8
            linha8.Add(new Parede { esquerda = true });
            linha8.Add(new Parede { baixo = true, direita = true });
            linha8.Add(new Parede { esquerda = true, baixo = true });
            linha8.Add(new Parede()); //todas as opções livres 
            linha8.Add(new Parede { baixo = true });
            linha8.Add(new Parede { baixo = true });
            linha8.Add(new Parede { topo = true, baixo = true, direita = true });
            linha8.Add(new Parede { esquerda = true, direita = true });
            linha8.Add(new Parede { esquerda = true, direita = true });

            //linha9
            linha9.Add(new Parede { esquerda = true, baixo = true });
            linha9.Add(new Parede { topo = true, baixo = true });
            linha9.Add(new Parede { topo = true, direita = true, baixo = true });
            linha9.Add(new Parede { esquerda = true, baixo = true });
            linha9.Add(new Parede { topo = true, baixo = true });
            linha9.Add(new Parede { topo = true });
            linha9.Add(new Parede { topo = true, baixo = true, direita = true });
            linha9.Add(new Parede { esquerda = true, baixo = true });
            linha9.Add(new Parede { baixo = true, direita = true });

        }


        public override bool TemItem(int x, int y, Feiticeira bia)
        {
            bool pegouItem = false;
            PocaoFortalecedora pocao_fortalecedora = new PocaoFortalecedora();
            Pirlimpimpim po_pirlimpimpim = new Pirlimpimpim();
            PocaoWhey whey = new PocaoWhey();

            if(x == 1 && y == 7 ) //verifica se o item é a poção fortalecedora
            {
                pegouItem = true;
                bia.mochila.AddItem(pocao_fortalecedora, bia.mochila.bagFortalecedora);
            }

            else if (x == 3 && y == 7) //verifica se o item é a poção fortalecedora
            {
                pegouItem = true;
                bia.mochila.AddItem(whey, bia.mochila.bagWhey);
            }

            else if (x == 7 && y == 8) //verifica se o item é a poção fortalecedora
            {
                pegouItem = true;
                bia.mochila.AddItem(po_pirlimpimpim, bia.mochila.bagPirlimpimpim);
            }

            return pegouItem;
        }
    }
}
