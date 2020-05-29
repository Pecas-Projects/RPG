using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{

        public class PocaoVitae : Item
        {
            public PocaoVitae() //era um construtor que se tentava fazer?
            {
                this.nome = "Poção Vitae";
                this.utilizado = false;

            }

        /// <summary>
        /// Aumenta 30 pontos 
        /// </summary>
        /// <param name="jogadora"></param>
            public override void Utilizar(Feiticeira jogadora) //aumenta a vida do jogador em 50%
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
