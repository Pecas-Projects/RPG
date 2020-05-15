﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    /// <summary>
    /// Determinada, inesperiente, criativa, esperta,
    /// ambiciosa
    /// </summary>
    public class Feiticeira : Personagem
    {
        public int moedas { get; set; }
        public Mochila mochila;

        /// <summary>
        /// a magia será utilizada na batalha de turno, 
        /// uma barra adicional que só a feiticeira tem
        /// e controla seu ataque especial
        /// </summary>

        public double magia { get; set; }

        public ArrayList ItemdeBatalha = new ArrayList();
        
        public Feiticeira()
        {
            this.mochila = new Mochila();

            //implementar valores default para a feiticeira
            this.forca = 20;
            this.perdaEstamina = 0.30;
            this.ganhoEstamnina = 0.12;
            this.escudo = 50;
            this.magia = 1.2;
            this.ItemdeBatalha.Capacity = 2;
           
        }

        /// <summary>
        /// Apos o oponente se defender 3 vezes libera o ataque especial
        /// A força da feiticeira almenta em 20% 
        /// O ataque especial ignora o escudo do inimigo
        /// </summary>
        /// <param name="inimigo"></param>
        
        public override void ataqueEspecial(Personagem inimigo)
        {
            //Colocar if para contar as defesas, na classe controladora da batalha
            inimigo.vida -= this.forca * this.estamina * magia;

        }


        public void ComprarItem(Item itemGenerico, ArrayList bag,int preco)
        {
            if (this.moedas >= preco)
            {
                mochila.AddItem(itemGenerico, bag);
                this.moedas -= preco;

            }
        }

        public void EscolherItemdeBatalha(ArrayList bag)
        {
            if ( ItemdeBatalha.Count < 2)
            {
                if (bag.Count > 0){
                    ItemdeBatalha.Add(bag[(bag.Count)-1]);
                }
            }
        }
    }
}
