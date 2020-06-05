using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    /// <summary>
    /// Classe filha de "Item".
    /// Implementa a interface "ItemDesativado".
    /// Aumenta a força da Feiticeira em 15%.
    /// </summary>
    public class PocaoFortalecedora : Item, ItemDesativado
    {
        public PocaoFortalecedora()
        {
            //this.Nome = "Poção Fortalecedora";
            this.Utilizado = false;
            this.Preco = 5;
            this.ImagemItem = new Uri("ms-appx:///Assets/pocao_fortalecedora.png");
        }

        public void DesativarItem(Feiticeira jogador)
        {
            double aux = jogador.Forca * 0.15;
            jogador.Forca -= aux;
            //jogador.mochila.RemoverItem(jogador.mochila.bagFortalecedora);
        }

        public override void Utilizar(Feiticeira jogadora)
        {
            double aux = jogadora.Forca * 0.15;
            jogadora.Forca += aux;
            this.Utilizado = true;
        }

    }
}
