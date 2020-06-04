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
            this.preco = 8;
            this.ImagemItem = new Uri("ms-appx:///Assets/pocao_vitae.png");
        }

        /// <summary>
        /// Da 50 pontos de vida a jogadora
        /// </summary>
        /// <param name="jogador"></param>
            public override void Utilizar(Feiticeira jogadora)
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
