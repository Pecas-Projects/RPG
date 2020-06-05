using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    /// <summary>
    /// Classe filha de "Item".
    /// Implementa a interface "ItemDesativado".
    /// Aumenta a magia da Feiticeira em 20%
    /// </summary>
    public class Pirlimpimpim : Item, ItemDesativado
    {
        public Pirlimpimpim()
        {
            //this.Nome = "Pó de Pirlimpimpim";
            this.Utilizado = false;
            this.Preco = 4;
            this.ImagemItem = new Uri("ms-appx:///Assets/po_pirlimpimpim.png");
        }
        
        public void DesativarItem(Feiticeira jogadora)
        {
            double  aux = jogadora.Magia / 0.2;
            jogadora.Magia = aux;
            //jogadora.mochila.RemoverItem(jogador.mochila.bagPirlimpimpim); 
        }
        
        
        public override void Utilizar(Feiticeira jogadora)
        {
            double aux = jogadora.Magia * 0.2;
            jogadora.Magia += aux;
            this.Utilizado = true;
        }

    }
}
