using System;
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

        public List<Item> ItemdeBatalha = new List<Item>();
        
        public Feiticeira()
        {
            this.mochila = new Mochila();
            this.ImagemPersonagem = new Uri("ms-appx:///Assets/feiticeira_front.png");
            //implementar valores default para a feiticeira
            this.Forca = 20;
            this.PerdaEstamina = 0.30;
            this.GanhoEstamnina = 0.12;
            this.Escudo = 50;
            this.magia = 1.2;
            this.ItemdeBatalha.Capacity = 2;
            this.ImagemPersonagem = new Uri("ms-appx:///Assets/feiticeira_front.png");

        }

        /// <summary>
        /// Apos o oponente se defender 3 vezes libera o ataque especial
        /// A força da feiticeira almenta em 20% 
        /// O ataque especial ignora o escudo do inimigo
        /// </summary>
        /// <param name="inimigo"></param>
        public override void ataqueEspecial(Personagem inimigo)
        {
            inimigo.Vida -= this.Forca * this.Estamina * magia;
            
        }


        public void ComprarItem(Item itemGenerico, ArrayList bag,int preco)
        {
            if (this.moedas >= preco)
            {
                this.mochila.AddItem(itemGenerico, bag);
                this.moedas -= preco;

            }
        }

        public void EscolherItemdeBatalha(ArrayList bag)
        {
            if ( this.ItemdeBatalha.Count < 2)
            {
                if (bag.Count > 0){
                    this.ItemdeBatalha.Add((Item)bag[(bag.Count)-1]);
                    this.mochila.RemoverItem(bag);
                }
            }
        }

        public void RetirarItemdeBatalha(ArrayList bag, Item item)
        {
            foreach(Item i in this.ItemdeBatalha)
            {
                if(i.GetType() == item.GetType())
                {
                    this.ItemdeBatalha.Remove(i);
                    bag.Add(i);
                    break;
                }
            }
        }
    }
}
