﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
   public class PocaoWhey : Item, ItemUtilizavel
    {
        public PocaoWhey()
        {
            this.nome = "Poção de Whey";
            this.utilizado = false;
        }

        /// <summary>
        /// Aumenta 30% da estamina Total da feiticeira
        /// </summary>
        /// <param name="jogador"></param>
        public void Utilizar(Feiticeira jogadora)
        {
            if(jogadora.Estamina < 1)
            {
                jogadora.Estamina += 0.30;
                this.utilizado = true;
                jogadora.mochila.RemoverItem(jogadora.mochila.bagWhey);
                if (jogadora.Estamina > 1)
                {
                    jogadora.Estamina = 1;
                }
            }

        }
    }
}
