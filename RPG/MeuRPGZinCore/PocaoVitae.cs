using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{

        public class PocaoVitae : Item, ItemUtilizavel
        {
            public PocaoVitae() //era um construtor que se tentava fazer?
            {
                this.nome = "Poção Vitae";
                this.utilizado = false;
                this.preco = 15;

            }

            public void Utilizar(Feiticeira jogador) //aumenta a vida do jogador em 50%
            {
                jogador.Vida += jogador.Vida * 0.5;
                this.utilizado = true;

                jogador.mochila.RemoverItem(jogador.mochila.bagVitae);
        }
        }
}
