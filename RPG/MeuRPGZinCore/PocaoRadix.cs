﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    class PocaoRadix : Item, ItemDesativado, ItemUtilizavel
    {
        double aux;
        PocaoRadix()
        {
            this.nome = "Poção Radix";
            this.utilizado = false;
        }

        public void DesativarItem(Feiticeira jogador)
        {
            jogador.forca -= aux;
            jogador.mochila.RemoverItem(jogador.mochila.bagRadix);
        }

        public void utilizar(Feiticeira jogador) //aumenta em 20% a força 
        {
            aux = jogador.forca * 0.2;
            jogador.forca += aux;
            this.utilizado = true;
        }
    }
}
