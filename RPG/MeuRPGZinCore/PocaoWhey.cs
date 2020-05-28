using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
   public class PocaoWhey : Item, ItemUtilizavel
    {
        public PocaoWhey()
        {
            this.nome = "Poção de Whey";
            this.utilizado = false;
        }

        /// <summary>
        /// Aumenta 30% da estamina da feiticeira
        /// </summary>
        /// <param name="jogador"></param>
        public void Utilizar(Feiticeira jogador)
        {
            jogador.Estamina += jogador.Estamina * 0.3;
            this.utilizado = true;
        }
    }
}
