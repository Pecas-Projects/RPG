using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    /// <summary>
    /// Classe filha de "Item".
    /// Aumenta em 0.3 a estamina total da feiticeira.
    /// </summary>
    public class PocaoWhey : Item
    {
        public PocaoWhey()
        {
            this.Utilizado = false;
            this.Preco = 2;
            this.ImagemItem = new Uri("ms-appx:///Assets/pocao_whey.png");
        }

        public override void Utilizar(Feiticeira jogadora)
        {
            if(jogadora.Estamina < 1)
            {
                jogadora.Estamina += 0.30;
                this.Utilizado = true;

                if (jogadora.Estamina > 1)
                {
                    jogadora.Estamina = 1;
                }
            }

        }
    }
}
