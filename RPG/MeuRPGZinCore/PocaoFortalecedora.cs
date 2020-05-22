using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    public class PocaoFortalecedora : Item, ItemDesativado, ItemUtilizavel
    {
        double aux;
        public PocaoFortalecedora()
        {
            this.nome = "Poção Fortalecedora";
            this.utilizado = false;
        }

        public void DesativarItem(Feiticeira jogador)
        {
            aux = jogador.Forca / 0.15;
            jogador.Forca = aux;
            jogador.mochila.RemoverItem(jogador.mochila.bagFortalecedora);
        }

        public void utilizar(Feiticeira jogador) //aumenta 15% da forca
        {
            aux = jogador.Forca * 0.15;
            jogador.Forca = aux;
            this.utilizado = true;
        }

    }
}
