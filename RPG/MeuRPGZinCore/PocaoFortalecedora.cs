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

        /// <summary>
        /// Aumenta 15% da força
        /// </summary>
        /// <param name="jogador"></param>
        public void Utilizar(Feiticeira jogadora)
        {
            jogadora.Forca += jogadora.Forca * 0.15;
            this.utilizado = true;
        }

    }
}
