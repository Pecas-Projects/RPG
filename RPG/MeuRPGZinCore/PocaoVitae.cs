using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    /// <summary>
    /// Classe filha de "Item".
    /// Da 50 pontos de vida a jogadora
    /// </summary>
    public class PocaoVitae : Item
    {
            public PocaoVitae()
            {
                //this.Nome = "Poção Vitae";
                this.Utilizado = false;
                this.Preco = 8;
                this.ImagemItem = new Uri("ms-appx:///Assets/pocao_vitae.png");
        }

            public override void Utilizar(Feiticeira jogadora)
            {
            if(jogadora.Vida < 100)
            {
                jogadora.Vida += 30;
                this.Utilizado = true;
                //jogadora.mochila.RemoverItem(jogadora.mochila.bagVitae);
                if(jogadora.Vida > 100)
                {
                    jogadora.Vida = 100;
                }
            }
        }
    }
}
