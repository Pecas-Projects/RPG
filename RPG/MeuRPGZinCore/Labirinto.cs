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

        public abstract bool TemParedeTopo(int x, int y);
        public abstract bool TemParedeDireita(int x, int y);
        public abstract bool TemParedeEsquerda(int x, int y);
        public abstract bool TemParedeBaixo(int x, int y);
        public abstract void TemPeca(int x, int y, Feiticeira bia);
        public abstract void TemItem(int x, int y, Feiticeira bia, Item item);

    }
}
