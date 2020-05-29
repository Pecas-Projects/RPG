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
using Windows.UI.Xaml.Media.Imaging;
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

        private void LevarWhey(object sender, RoutedEventArgs e)
        {
            feiticeira.EscolherItemdeBatalha(feiticeira.mochila.bagWhey);
            if(Item_mochila.Source.Equals("Assets/interrogacao.png"))
            {
                //Mudar a imagem para Whey
            }
            else if (Item_mochila2.Source.Equals("Assets/interrogacao.png"))
            {
                //Mudar imagem para Whey
            }

        }

        private void RetirarWhey(object sender, RoutedEventArgs e)
        {
            PocaoWhey whey = new PocaoWhey();
            feiticeira.RetirarItemdeBatalha(feiticeira.mochila.bagWhey, whey);
            if (Item_mochila2.Source.Equals("Assets/pocao_whey.png"))
            {
                //Mudar imagem para "?"
            }
            else if (Item_mochila.Source.Equals("Assets/pocao_whey.png"))
            {
                //Mudar imagem para "?"
            }
        }

    }
}
