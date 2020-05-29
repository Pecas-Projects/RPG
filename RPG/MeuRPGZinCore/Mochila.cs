using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    public class Mochila
    {
       public ArrayList bagPirlimpimpim = new ArrayList();
       public ArrayList bagFortalecedora = new ArrayList();
       public ArrayList bagVitae = new ArrayList();
       public ArrayList bagRadix = new ArrayList();
       public ArrayList bagWhey= new ArrayList();

        // temos que decidir se a pessoa pode comprar mais de um do mesmo item , pq ai vamos precisar contar quanto de cada ela tem

        public void AddItem(Item generico, ArrayList bag)
        {
            bag.Add(generico);

        }

        public void RemoverItem(ArrayList bag)
        {
            bag.Remove(bag[bag.Count-1]);
        }
        

        //sugestão de contador de itens por tipo
        //fazer um cont para cada tipo de item
        //essa função seria chamada antes de cada batalha
        //ela iria contar quantos itens de cada tipo estão na mochila
        //e alteraria o contador correspondente
        //essa informação seria interessante apenas para saber quantos itens de cada o jogador tem
        //e informar se ele pode escolher usar esse item na batalha ou não

    }
}
