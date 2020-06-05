﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    public class Pirlimpimpim : Item, ItemDesativado
    {
        double aux;

        public Pirlimpimpim()
        {
            this.nome = "Pó de Pirlimpimpim";
            this.utilizado = false;
            this.preco = 4;
            this.ImagemItem = new Uri("ms-appx:///Assets/po_pirlimpimpim.png");
        }
        /// <summary>
        /// decidir se o item é utilizado durante toda batalha
        /// ou se ele é usado por turno, por exemplo: 
        /// cada um é usado 3 vezes durante a batalha e depois acaba, ou algo assim
        /// </summary>
        /// <param name="jogador"></param>
        public void DesativarItem(Feiticeira jogador)
        {
            aux = jogador.Magia / 0.2;
            jogador.Magia = aux;

            jogador.mochila.RemoverItem(jogador.mochila.bagPirlimpimpim); 
            //sujestão de como ir usando e removendo, 
            //ou podemos criar uma função para remover caso o item seja usado por turno, 
            //depois de um número x de turnos com ele ativo ele seria removido
            //essa dinâmica também será controlada na classe controladora da batalha
            //essa função poderia ser colocada na classe mãe Item pois serve para todos
        }
        
        /// <summary>
        /// Aumenta a magia em 20%
        /// </summary>
        /// <param name="jogador"></param>
        public override void Utilizar(Feiticeira jogador)
        {
            jogador.Magia += jogador.Magia * 0.2;
            this.utilizado = true;
        }

    }
}
