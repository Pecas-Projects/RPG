using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    class PocaoWhey : Item, ItemUtilizavel
    {
        PocaoWhey()
        {
            this.nome = "Poção de Whey";
            this.utilizado = false;
        }
        public void utilizar(Feiticeira jogador) //aumenta 30% da estamina
        {
            jogador.estamina += jogador.estamina * 0.3;
            this.utilizado = true;
        }
    }
}
