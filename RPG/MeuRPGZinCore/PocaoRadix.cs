﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    public class PocaoRadix : Item, ItemDesativado
    {
        double aux;
        public PocaoRadix()
        {
            this.nome = "Poção Radix";
            this.utilizado = false;
            this.preco = 6;
            this.ImagemItem = new Uri("ms-appx:///Assets/pocao_radix.png");
        }

        public void DesativarItem(Feiticeira jogador)
        {
            jogador.Forca -= aux;
            jogador.mochila.RemoverItem(jogador.mochila.bagRadix);
        }

        /// <summary>
        /// Aumenta 20% da força
        /// </summary>
        /// <param name="jogador"></param>
        public override void Utilizar(Feiticeira jogador)
        {
            aux = jogador.Forca * 0.2;
            jogador.Forca += aux;
            this.utilizado = true;
        }
    }
}
