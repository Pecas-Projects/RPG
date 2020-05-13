using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    class Mochila
    {
        ArrayList bag = new ArrayList();

        public void AddItem(Item generico)
        {
            bag.Add(generico);

        }

        public void RemoverItem(Item generico)
        {
            bag.Remove(generico);
        }
    }
}
