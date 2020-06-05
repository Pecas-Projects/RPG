using System;
using System.Collections.Generic;
using System.Text;

namespace MeuRPGZinCore
{
    /// <summary>
    /// Classe abstrata que define um Labirinto.
    /// As listas equivalem às linhas do mapeamento do labirinto.
    /// Cada elemento delas equivale a uma coluna.
    /// A combinação de seus elementos é uma coordenada.
    /// Possui a função abstrata "TemItem".
    /// </summary>
    public abstract class Labirinto
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

        /// <summary>
        /// Lista de Moedas que aparecerão na fase.
        /// </summary>
        public List<Moeda> moedas = new List<Moeda>();

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

        /// <summary>
        /// Verifica se tem Moeda na coordenada desejada retorna true caso possua
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="bia"></param>
        public bool TemPeca(int x, int y, Feiticeira feiticeira)
        {
            for (int i = 0; i < moedas.Count; ++i)
            {
                if (moedas[i].X == x && moedas[i].Y == y)
                {
                    feiticeira.Moedas++;
                    moedas.Remove(moedas[i]);
                    return true;
                }
            }

            return false;

        }

        /// <summary>
        /// Função abstrata que determina se existe um item em uma coordenada de um labirinto.
        /// Cada labirinto possui itens diferente.
        /// Define se o item foi pego pea feiticeira.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="feiticeira"></param>
        /// <returns></returns>
        public abstract bool TemItem(int x, int y, Feiticeira feiticeira);

    }
}
