using System;
using System.Collections.Generic;
using System.Text;

namespace MeuRPGZinCore
{
    public abstract class Labirinto
    {   /// <summary>
    /// as listas equivalem às linhas do mapeamento do labirinto
    /// cada elemento delas equivalem a uma coluna
    /// a combinação de seus elementos é uma coordenada
    /// </summary>
        public List<Parede> linha1 = new List<Parede>();
        public List<Parede> linha2 = new List<Parede>();
        public List<Parede> linha3 = new List<Parede>();
        public List<Parede> linha4 = new List<Parede>();
        public List<Parede> linha5 = new List<Parede>();
        public List<Parede> linha6 = new List<Parede>();
        public List<Parede> linha7 = new List<Parede>();
        public List<Parede> linha8 = new List<Parede>();
        public List<Parede> linha9 = new List<Parede>();

        public List<Moeda> moedas = new List<Moeda>(); //moedas que aparecerão nessa fase

        public bool TemParedeTopo(int x, int y)
        {
            bool resultado = false;

            if (x == 1)
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
                if (linha4[y].topo == true) resultado = true;
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
                if (linha4[y].direita == true) resultado = true;
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
                if (linha4[y].esquerda == true) resultado = true;
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
                if (linha4[y].baixo == true) resultado = true;
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

        public bool TemPeca(int x, int y, Feiticeira bia)
        {
            for (int i = 0; i < moedas.Count; ++i)
            {
                if (moedas[i].X == x && moedas[i].Y == y)
                {
                    bia.Moedas++;
                    moedas.Remove(moedas[i]);
                    return true;
                }
            }

            return false;

        }

        public abstract bool TemItem(int x, int y, Feiticeira bia);

    }
}
