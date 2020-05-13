using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    class PocaoFortalecedora : Item, ItemDesativado, ItemUtilizavel
    {
        double aux;
        PocaoFortalecedora()
        {
            this.nome = "Poção Fortalecedora";
            this.utilizado = false;
        }

        public void DesativarItem(Feiticeira jogador)
        {
            aux = jogador.forca / 0.15;
            jogador.forca = aux;
            jogador.mochila.RemoverItem(jogador.mochila.bagFortalecedora);
        }

        public void utilizar(Feiticeira jogador) //aumenta 15% da forca
        {
            aux = jogador.forca * 0.15;
            jogador.forca = aux;
            this.utilizado = true;
        }
    }
}
