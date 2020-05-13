using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    class Feiticeira : Personagem
    {
        public int moedas { get; set; }
        private Mochila mochila { get; set; }

        public void comprarItem(Item itemGenerico, int preco)
        {
            if (this.moedas >= preco)
            {
                mochila.AddItem(itemGenerico);
                this.moedas -= preco;

            }
        }
    }
}
