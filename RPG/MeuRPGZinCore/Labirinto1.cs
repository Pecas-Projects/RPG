﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MeuRPGZinCore
{
    public class Labirinto1

    {

        public List<Parede> linha1 = new List<Parede>();
        public List<Parede> linha2 = new List<Parede>();
        public List<Parede> linha3 = new List<Parede>();
        public List<Parede> linha4 = new List<Parede>();
        public List<Parede> linha5 = new List<Parede>();
        public List<Parede> linha6 = new List<Parede>();
        public List<Parede> linha7 = new List<Parede>();
        public List<Parede> linha8 = new List<Parede>();
        public List<Parede> linha9 = new List<Parede>();


        public Labirinto1()
        {
            linha1.Add(new Parede { topo = true, esquerda = true });
            linha1.Add(new Parede { topo = true, baixo = true });
            linha1.Add(new Parede { topo = true, direita = true, baixo = true });
            linha1.Add(new Parede { topo = true, esquerda = true });
            linha1.Add(new Parede { topo = true, baixo = true });
            linha1.Add(new Parede { topo = true, baixo = true });
            linha1.Add(new Parede { topo = true, direita = true, baixo = true });
            linha1.Add(new Parede { topo = true, esquerda = true });
            linha1.Add(new Parede { topo = true }); //linha coordenada da saida

            linha2.Add(new Parede { esquerda = true });
            linha2.Add(new Parede { direita = true, topo = true });
            linha2.Add(new Parede { topo = true, esquerda = true });
            linha2.Add(new Parede()); //linha2[3] tem todas as opcoes livre
            linha2.Add(new Parede { topo = true, direita = true });
            linha2.Add(new Parede { topo = true, esquerda = true });
            linha2.Add(new Parede { topo = true, direita = true});
            linha2.Add(new Parede { esquerda = true, direita = true });
            linha2.Add(new Parede { direita = true, esquerda = true });
            linha2.Add(new Parede { baixo = true, direita = true });

            //linha3
            linha3.Add(new Parede { baixo = true, direita = true });
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
            linha4.Add(new Parede { esquerda = true, topo = true, direita = true });
            linha4.Add(new Parede { esquerda = true, direita = true });
            linha4.Add(new Parede { esquerda = true, baixo = true });
            linha4.Add(new Parede { direita = true, topo = true });

            //linha 5
            linha5.Add(new Parede { direita = true, esquerda = true });
            linha5.Add(new Parede { topo = true, esquerda = true });
            linha5.Add(new Parede { direita = true, topo = true });
            linha5.Add(new Parede { baixo = true, esquerda = true });
            linha5.Add(new Parede { baixo = true });
            linha5.Add(new Parede { esquerda = true });
            linha5.Add(new Parede { baixo = true });
            linha5.Add(new Parede { direita = true, topo = true, baixo = true });
            linha5.Add(new Parede { direita = true, baixo = true });

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
            linha7.Add(new Parede { esquerda = true,  baixo = true });
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
            linha8.Add(new Parede { direita = true});

            //linha 9
            linha9.Add(new Parede { baixo = true, esquerda = true });
            linha9.Add(new Parede { baixo = true, topo = true });
            linha9.Add(new Parede { baixo = true, topo = true });
            linha9.Add(new Parede { baixo = true });
            linha9.Add(new Parede { baixo = true });
            linha9.Add(new Parede { baixo = true });
            linha9.Add(new Parede { baixo = true, topo = true });
            linha9.Add(new Parede { baixo = true, direita = true, topo = true });
            linha9.Add(new Parede { baixo = true, esquerda = true, direita = true});

        }
        
        public bool TemParedeTopo (int x, int y)
        {
            bool resultado = false;

            if(x == 1)
            {
                if (linha1[y].topo == true) resultado = true;
            }


            else if (x == 2)
            {
                if (linha2[y].topo == true) resultado = true;
            }


            else if (x == 3)
            {
                if (linha3[y].topo == true) resultado = true;
            }


            else if (x == 4)
            {
                if (linha1[y].topo == true) resultado = true;
            }

            else if (x == 5)
            {
                if (linha5[y].topo == true) resultado = true;
            }


            else if (x == 6)
            {
                if (linha6[y].topo == true) resultado = true;
            }


            else if (x == 7)
            {
                if (linha7[y].topo == true) resultado = true;
            }

            else if (x == 8)
            {
                if (linha8[y].topo == true) resultado = true;
            }

            else if (x == 9)
            {
                if (linha9[y].topo == true) resultado = true;
            }

            return resultado;

        }

        public bool TemParedeDireita(int x, int y)
        {
            bool resultado = false;

            if (x == 1)
            {
                if (linha1[y].direita == true) resultado = true;
            }


            else if (x == 2)
            {
                if (linha2[y].direita == true) resultado = true;
            }


            else if (x == 3)
            {
                if (linha3[y].direita == true) resultado = true;
            }


            else if (x == 4)
            {
                if (linha1[y].direita == true) resultado = true;
            }

            else if (x == 5)
            {
                if (linha5[y].direita == true) resultado = true;
            }


            else if (x == 6)
            {
                if (linha6[y].direita == true) resultado = true;
            }


            else if (x == 7)
            {
                if (linha7[y].direita == true) resultado = true;
            }

            else if (x == 8)
            {
                if (linha8[y].direita == true) resultado = true;
            }

            else if (x == 9)
            {
                if (linha9[y].direita == true) resultado = true;
            }

            return resultado;

        }

        public bool TemParedeEsquerda(int x, int y)
        {
            bool resultado = false;

            if (x == 1)
            {
                if (linha1[y].esquerda == true) resultado = true;
            }


            else if (x == 2)
            {
                if (linha2[y].esquerda == true) resultado = true;
            }


            else if (x == 3)
            {
                if (linha3[y].esquerda == true) resultado = true;
            }


            else if (x == 4)
            {
                if (linha1[y].esquerda == true) resultado = true;
            }

            else if (x == 5)
            {
                if (linha5[y].esquerda == true) resultado = true;
            }


            else if (x == 6)
            {
                if (linha6[y].esquerda == true) resultado = true;
            }


            else if (x == 7)
            {
                if (linha7[y].esquerda == true) resultado = true;
            }

            else if (x == 8)
            {
                if (linha8[y].esquerda == true) resultado = true;
            }

            else if (x == 9)
            {
                if (linha9[y].esquerda == true) resultado = true;
            }

            return resultado;

        }

        public bool TemParedeBaixo(int x, int y)
        {
            bool resultado = false;

            if (x == 1)
            {
                if (linha1[y].baixo == true) resultado = true;
            }


            else if (x == 2)
            {
                if (linha2[y].baixo == true) resultado = true;
            }


            else if (x == 3)
            {
                if (linha3[y].baixo == true) resultado = true;
            }


            else if (x == 4)
            {
                if (linha1[y].baixo == true) resultado = true;
            }

            else if (x == 5)
            {
                if (linha5[y].baixo == true) resultado = true;
            }


            else if (x == 6)
            {
                if (linha6[y].baixo == true) resultado = true;
            }


            else if (x == 7)
            {
                if (linha7[y].baixo == true) resultado = true;
            }

            else if (x == 8)
            {
                if (linha8[y].baixo == true) resultado = true;
            }

            else if (x == 9)
            {
                if (linha9[y].baixo == true) resultado = true;
            }

            return resultado;

        }

    }
}





