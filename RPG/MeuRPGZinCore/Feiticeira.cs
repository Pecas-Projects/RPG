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
    /// -Classe filha de Personagem
    /// -Personagem principal do jogo, é o avatar do usuário
    /// </summary>
    public class Feiticeira : Personagem
    {
        public int Moedas { get; set; }
        public Uri FeiticeiraCostas { get; set; }
        public Uri FeiticeiraFrente { get; set; }
        public Uri FeiticeiraDireita { get; set; }
        public Uri FeiticeiraEsquerda { get; set; }

        /// <summary>
        /// a feiticeira possui uma mochila, que é onde 
        /// os seus itens são guardados.
        /// </summary>
        public Mochila mochila;

        /// <summary>
        /// A magia será utilizada na batalha de turno, 
        /// uma barra adicional que só a feiticeira tem,
        /// e controla o seu ataqueEspecial.
        /// </summary>
        public double Magia { get; set; }

        /// <summary>
        /// Lista de Itens que serão levados para a batalha.
        /// </summary>
        public List<Item> ItemdeBatalha = new List<Item>();

        public List<Uri> Pedras = new List<Uri>();

        /// <summary>
        /// Função que cria feiticeira.
        /// Ela inicia o jogo com:
        /// Forca = 20; 
        /// PerdaEstamina = 0.30; 
        /// GanhoEstamnina = 0.12; 
        /// Escudo = 50; 
        /// Magia = 1.2; 
        /// </summary>
        public Feiticeira()
        {
            this.mochila = new Mochila();
            this.ImagemPersonagem = new Uri("ms-appx:///Assets/feiticeira_front.png");
            this.FeiticeiraCostas = new Uri("ms-appx:///Assets/feiticeira_back.png");
            this.FeiticeiraDireita = new Uri("ms-appx:///Assets/feiticeira_right_2.png");
            this.FeiticeiraEsquerda = new Uri("ms-appx:///Assets/feiticeira_left_2.png");

            this.Pedras.Add(new Uri("ms-appx:///Assets/pedras_da_terra.png"));

            //implementar valores default para a feiticeira
            this.Forca = 20;
            this.PerdaEstamina = 0.30;
            this.GanhoEstamnina = 0.12;
            this.Escudo = 50;
            this.Magia = 1.2;
            this.ItemdeBatalha.Capacity = 2;

        }

        /// <summary>
        /// Apos o oponente se defender 4 vezes o ataque especial é liberado .
        /// A força da feiticeira almenta em 20% .
        /// O ataque especial ignora o escudo do inimigo.
        /// </summary>
        /// <param name="inimigo"></param>
        public override void AtaqueEspecial(Personagem inimigo)
        {
            inimigo.Vida -= this.Forca * this.Estamina * Magia; 
        }

        /// <summary>
        /// A feiticeira pode comprar itens da classe "Item",
        /// caso possua moedas suficientes.
        /// O item é adicionado a sua mochila.
        /// </summary>
        /// <param name="itemGenerico"></param>
        /// <param name="bag"></param>
        /// <param name="preco"></param>
        public void ComprarItem(Item itemGenerico, ArrayList bag,int preco)
        {
            if (this.Moedas >= preco)
            {
                this.mochila.AddItem(itemGenerico, bag);
                this.Moedas -= preco;

            }
        }

        /// <summary>
        /// A feiticeira pode escolher dois itens da sua mochila para utilizar
        /// durante a batalha, ao colocá-los no "ItemdeBatalha".
        /// No máximo dois itens podem ser levados
        /// </summary>
        /// <param name="bag"></param>
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

        /// <summary>
        /// A feiticeira pode retirar um item do "ItemdeBatalha"
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="item"></param>
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
