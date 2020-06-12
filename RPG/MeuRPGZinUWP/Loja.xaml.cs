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

        private void ComprarPoPirlimpimpim()
        {
            Pirlimpimpim produto = new Pirlimpimpim();
            feiticeira.ComprarItem(produto, feiticeira.mochila.bagPirlimpimpim, produto.Preco);
            AtualizarContItens();

        }

        private void ShowDialogItemClicked(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            DisplayContentDialog(btn.Name);
        }

        private void ShowItemComprado(string sucess)
        {
            string titulo = null, texto = null;
            if(sucess == "sim")
            {
                titulo = "Compra";
                texto = "Item comprado com sucesso!";
                textoCaixaDialogo2.FontSize = 30;
            }
            else
            {
                titulo = "Pecas Insuficientes!";
                textoCaixaDialogo2.FontSize = 25;
                texto = "Você não possui Pecas suficientes!";
            }
            //AposClick.Title = titulo;
            textoCaixaDialogo2.Text = texto;
            AposClick.ShowAsync();
        }

        private void FecharContent(object sender, RoutedEventArgs e)
        {
            CaixaDeDialogo.Hide();
        }

        private void FecharContent2(object sender, RoutedEventArgs e)
        {
            AposClick.Hide();
        }

        private void ComprarItem(Object sender, RoutedEventArgs e)
        {
            //chama método de comprar
            CaixaDeDialogo.Hide();
                if (NomeDoItem.Text == "Pó de Pirlimpimpim" && feiticeira.Moedas >= Pirlimpimpim.Preco)
                {
                    ComprarPoPirlimpimpim();
                    ShowItemComprado("sim");
            }
                else if (NomeDoItem.Text == "Taurus Rubber" && feiticeira.Moedas >= Whey.Preco)
                {
                    ComprarPocaoWhey();
                    ShowItemComprado("sim");
                }
                else if (NomeDoItem.Text == "Poção Vitae" && feiticeira.Moedas >= Vitae.Preco)
                {
                    ComprarPocaoVitae();
                    ShowItemComprado("sim");
                }
                else if (NomeDoItem.Text == "Poção Radix" && feiticeira.Moedas >= Radix.Preco)
                {
                    ComprarPocaoRadix();
                    ShowItemComprado("sim");

                }
                else if (NomeDoItem.Text == "Poção Fortalecedora" && feiticeira.Moedas >= Fortalecedora.Preco)
                {
                    ComprarPocaoFortalecedora();
                    ShowItemComprado("sim");
                }
                else
                {
                    ShowItemComprado("nao");
                }
            }

        private void DisplayContentDialog(string NomeItem)
        {
            string titulo = null, texto = null;
            ImageSource address = null;
            if (NomeItem == "PirlimpimpimButton")
            {
                titulo = "Pó de Pirlimpimpim";
                texto = "Aumenta em 20% a sua magia!";
                address = PirlimpimpimImg.Source;
            }
            else if (NomeItem == "WheyButton")
            {
                titulo = "Taurus Rubber";
                texto = "Aumenta a sua estamina!";
                address = WheyImg.Source;
            }
            else if (NomeItem == "VitaeButton")
            {
                titulo = "Poção Vitae";
                texto = "Aumenta a sua vida em 50 pontos!";
                address = VitaeImg.Source;
            }
            else if (NomeItem == "RadixButton")
            {
                titulo = "Poção Radix";
                texto = "Recupera 15% de seu escudo atual!";
                address = RadixImg.Source;
            }
            else if (NomeItem == "FortalecedoraButton")
            {
                titulo = "Poção Fortalecedora";
                texto = "Aumenta a sua força em 15%!";
                address = FortalecedoraImg.Source;
            }
            
            //CaixaDeDialogo.Title = titulo;
            textoCaixaDialogo.Text = texto;
            NomeDoItem.Text = titulo;
            NewItemImg.Source = address;
            CaixaDeDialogo.ShowAsync();
        }

        private void ComprarPocaoWhey()
        {
            feiticeira.ComprarItem(Whey, feiticeira.mochila.bagWhey, Whey.Preco);
            AtualizarContItens();
        }

        private void ComprarPocaoRadix()
        {
            feiticeira.ComprarItem(Radix, feiticeira.mochila.bagRadix, Radix.Preco);
            AtualizarContItens();

        }

        private void ComprarPocaoVitae()
        {
            feiticeira.ComprarItem(Vitae, feiticeira.mochila.bagVitae, Vitae.Preco);
            AtualizarContItens();

        }

        private void ComprarPocaoFortalecedora()
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
