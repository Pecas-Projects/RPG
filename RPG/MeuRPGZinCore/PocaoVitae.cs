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

            }

        /// <summary>
        /// Da 50 pontos de vida a jogadora
        /// </summary>
        /// <param name="jogador"></param>
            public void Utilizar(Feiticeira jogadora)
            {
            if(jogadora.Vida < 100)
            {
                jogadora.Vida += 30;
                this.utilizado = true;
                jogadora.mochila.RemoverItem(jogadora.mochila.bagVitae);

                if(jogadora.Vida > 100)
                {
                    jogadora.Vida = 100;
                }
            }

        }
        }
}
