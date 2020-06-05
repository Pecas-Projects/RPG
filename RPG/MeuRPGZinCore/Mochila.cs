using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    /// <summary>
    /// A Mochila guarda os itens da feiticeira.
    /// Dentro da mochila existe um ArrayList para cada tipo de item, chamados de "bag + nome do item".
    /// Um item é guandado dentro da mochila dentro da sua respectiva bag.
    /// </summary>
    public class Mochila
    {
       public ArrayList bagPirlimpimpim = new ArrayList();
       public ArrayList bagFortalecedora = new ArrayList();
       public ArrayList bagVitae = new ArrayList();
       public ArrayList bagRadix = new ArrayList();
       public ArrayList bagWhey= new ArrayList();

        // temos que decidir se a pessoa pode comprar mais de um do mesmo item , pq ai vamos precisar contar quanto de cada ela tem
        
        /// <summary>
        /// Método que adiciona um item a sua respectiva bag.
        /// </summary>
        /// <param name="generico"></param>
        /// <param name="bag"></param>
        public void AddItem(Item generico, ArrayList bag)
        {
            bag.Add(generico);
        }

        /// <summary>
        /// Método que remove um item de uma bag.
        /// </summary>
        /// <param name="bag"></param>
        public void RemoverItem(ArrayList bag)
        {
            bag.Remove(bag[bag.Count-1]);
        }

    }
}
