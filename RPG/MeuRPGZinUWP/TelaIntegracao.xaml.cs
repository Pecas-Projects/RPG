using MeuRPGZinCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace MeuRPGZinUWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class TelaIntegracao : Page
    {
        public Feiticeira feiticeira = new Feiticeira();
        public Pirlimpimpim pirlimpimpim = new Pirlimpimpim();

        public TelaIntegracao()
        {
            this.InitializeComponent();
        }

        public void AtualizarContItens()
        {
            contFortalecedora.Text = "Poção Fortalecedora: " + feiticeira.mochila.bagFortalecedora.Count;
            contPirlimpimpim.Text = "Pó de Pirlimpimpim: " + feiticeira.mochila.bagPirlimpimpim.Count;
            contRadix.Text = "Poção Radix: " + feiticeira.mochila.bagRadix.Count;
            contVitae.Text = "Poção Vitae: " + feiticeira.mochila.bagVitae.Count;
            contWhey.Text = "Poção Whey: " + feiticeira.mochila.bagWhey.Count;
            contPecas.Text = "Você tem " + feiticeira.moedas + " moedas";
        }

        private void paginaDaBatalha(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TesteBatalha2),feiticeira);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            feiticeira = e.Parameter as Feiticeira;
            AtualizarContItens();
        }

        private void paginaDaLoja(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Loja), feiticeira);
        }

        private void Levar_Pirlimpimpim(object sender, RoutedEventArgs e)
        {
           
           feiticeira.EscolherItemdeBatalha(feiticeira.mochila.bagPirlimpimpim); 
           selectPirlimpimpim.Content = "Retirar da mochila";
          /*  if (feiticeira.ItemdeBatalha.Count == 1)
            {
                Pirlimpimpim_Mochila.Width = 162;
                Pirlimpimpim_Mochila.Height = 76;
            }
            else if (feiticeira.ItemdeBatalha.Count == 2)
            {
                Pirlimpimpim_Mochila2.Width = 162;
                Pirlimpimpim_Mochila2.Height = 76;
            }*/
        }

        private void Levar_Whey(object sender, RoutedEventArgs e)
        {
            if(selectWhey.Content.Equals("Levar para a batalha"))
            {
                contWhey.Text = "Poção Whey: " + (feiticeira.mochila.bagWhey.Count- 1) ;
                selectWhey.Content = "Retirar da mochila";
                feiticeira.EscolherItemdeBatalha(feiticeira.mochila.bagWhey);
               /* if (feiticeira.ItemdeBatalha.Count == 1)
                {
                    Whey_Mochila.Width = 162;
                    Whey_Mochila.Height = 76;
                }
                else if (feiticeira.ItemdeBatalha.Count == 2)
                {
                    Whey_Mochila2.Width = 162;
                    Whey_Mochila2.Height = 76;
                }
            }
            else
            {
                contWhey.Text = "Poção Whey: " + feiticeira.mochila.bagWhey.Count;
                selectWhey.Content = "Levar para a batalha";
                feiticeira.EscolherItemdeBatalha(feiticeira.mochila.bagWhey);
                if (feiticeira.ItemdeBatalha[0] == feiticeira.mochila.bagWhey)
                {
                    Whey_Mochila.Width = 1;
                    Whey_Mochila.Height = 1;
                }
                else if (feiticeira.ItemdeBatalha[1] == feiticeira.mochila.bagWhey)
                {
                    Whey_Mochila2.Width = 1;
                    Whey_Mochila2.Height = 1;
                }*/
            }
           
        }

        private void Levar_Fortalecedora(object sender, RoutedEventArgs e)
        {
            selectFortalecedora.Content = "Retirar da mochila";
            feiticeira.EscolherItemdeBatalha(feiticeira.mochila.bagFortalecedora);
        }

        private void Levar_Radix(object sender, RoutedEventArgs e)
        {
            selectRadix.Content = "Retirar da mochila";
            feiticeira.EscolherItemdeBatalha(feiticeira.mochila.bagRadix);
        }

        private void Levar_Vitae(object sender, RoutedEventArgs e)
        {
            selectVitae.Content = "Retirar da mochila";
            feiticeira.EscolherItemdeBatalha(feiticeira.mochila.bagVitae);
        }
    }
}
