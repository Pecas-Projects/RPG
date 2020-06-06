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
    /// Página da Loja.
    /// O usuário pode comprar itens.
    /// O usuário pode voltar para a tela da Mochila.
    /// </summary>
    public sealed partial class Loja : Page
    {
        public ControllerBatalha controller = new ControllerBatalha();
        public Feiticeira feiticeira = new Feiticeira();
        public PocaoWhey Whey = new PocaoWhey();
        public PocaoFortalecedora Fortalecedora = new PocaoFortalecedora();
        public PocaoRadix Radix = new PocaoRadix();
        public PocaoVitae Vitae = new PocaoVitae();
        public Pirlimpimpim Pirlimpimpim = new Pirlimpimpim();

        public Loja()
        {
            this.InitializeComponent();
        }

        public void AtualizarContItens()
        {
            contFortalecedora.Text = "" + feiticeira.mochila.bagFortalecedora.Count;
            contPirlimpimpim.Text = "" + feiticeira.mochila.bagPirlimpimpim.Count;
            contRadix.Text = "" + feiticeira.mochila.bagRadix.Count;
            contVitae.Text = "" + feiticeira.mochila.bagVitae.Count;
            contWhey.Text = "" + feiticeira.mochila.bagWhey.Count;
            contPecas.Text = "Você tem: " + feiticeira.Moedas + " moedas";

            precoFortalecedora.Text = "" + Fortalecedora.Preco;
            precoPirlimpimpim.Text = "" + Pirlimpimpim.Preco;
            precoRadix.Text = "" + Radix.Preco;
            precoVitae.Text = "" + Vitae.Preco;
            precoWhey.Text = "" + Whey.Preco;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            controller = e.Parameter as ControllerBatalha;
            feiticeira = controller.Feiticeira;
            AtualizarContItens();
        }

        private void ComprarPoPirlimpimpim(object sender, RoutedEventArgs e)
        {
            Pirlimpimpim produto = new Pirlimpimpim();
            feiticeira.ComprarItem(produto, feiticeira.mochila.bagPirlimpimpim, produto.Preco);
            AtualizarContItens();

        }

        private void ComprarPocaoWhey(object sender, RoutedEventArgs e)
        {
            feiticeira.ComprarItem(Whey, feiticeira.mochila.bagWhey, Whey.Preco);
            AtualizarContItens();
        }

        private void ComprarPocaoRadix(object sender, RoutedEventArgs e)
        {
            feiticeira.ComprarItem(Radix, feiticeira.mochila.bagRadix, Radix.Preco);
            AtualizarContItens();

        }

        private void ComprarPocaoVitae(object sender, RoutedEventArgs e)
        {
            feiticeira.ComprarItem(Vitae, feiticeira.mochila.bagVitae, Vitae.Preco);
            AtualizarContItens();

        }

        private void ComprarPocaoFortalecedora(object sender, RoutedEventArgs e)
        {
            feiticeira.ComprarItem(Fortalecedora, feiticeira.mochila.bagFortalecedora, Fortalecedora.Preco);
            AtualizarContItens();
        }

        private void IrparaMochila(object sender, RoutedEventArgs e)
        {
            controller.Feiticeira = feiticeira;
            this.Frame.Navigate(typeof(Mochila), controller);
            AtualizarContItens();
        }
    }
}
