using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{

        class PocaoVitae : Item, ItemUtilizavel
        {
            PocaoVitae() //era um construtor que se tentava fazer?
            {
                this.nome = "Poção Vitae";
                this.utilizado = false;

            }

        /// <summary>
        /// Aumenta 50% a vida do jogador
        /// </summary>
        /// <param name="jogador"></param>
            public void Utilizar(Feiticeira jogador)
            {
                jogador.Vida += jogador.Vida * 0.5;
                this.utilizado = true;

                jogador.mochila.RemoverItem(jogador.mochila.bagVitae);
        }
        }
}
