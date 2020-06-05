using System;
using System.Collections.Generic;
using System.Text;

namespace MeuRPGZinCore
{
    /// <summary>
    /// Desine as paredes de um labireinto.
    /// Casa exista uma parede em:
    /// topo, baixo, esquerda ou direita, a variável correspondente recebe true.
    /// </summary>
    public class Parede
    {
        public bool topo = false;
        public bool baixo = false;
        public bool esquerda = false;
        public bool direita = false;

    }
}
