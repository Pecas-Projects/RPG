using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    class PocaoRadix : Item, ItemDesativado, ItemUtilizavel
    {
        double aux;
        PocaoRadix()
        {
            this.nome = "Poção Radix";
            this.utilizado = false;
        }

        public void DesativarItem(Feiticeira jogador)
        {
            jogador.Forca -= aux;
            jogador.mochila.RemoverItem(jogador.mochila.bagRadix);
        }

        /// <summary>
        /// Aumenta 20% da força
        /// </summary>
        /// <param name="jogador"></param>
        public void Utilizar(Feiticeira jogador)
        {
            aux = jogador.Forca * 0.2;
            jogador.Forca += aux;
            this.utilizado = true;
        }
    }
}
