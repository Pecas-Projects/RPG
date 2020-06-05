﻿using MeuRPGZinCore;
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
        public ControllerBatalha controller = new ControllerBatalha();
        public Feiticeira feiticeira = new Feiticeira();
        public Pirlimpimpim pirlimpimpim = new Pirlimpimpim();

        public TelaIntegracao()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Primeiro metodo executado ao renderizar a pagina
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            controller = e.Parameter as ControllerBatalha;
            feiticeira = controller.Feiticeira;
            AtualizarContItens();
        }

        public void AtualizarContItens()
        {
            contFortalecedora.Text = "Poção Fortalecedora: " + feiticeira.mochila.bagFortalecedora.Count;
            contPirlimpimpim.Text = "Pó de Pirlimpimpim: " + feiticeira.mochila.bagPirlimpimpim.Count;
            contRadix.Text = "Poção Radix: " + feiticeira.mochila.bagRadix.Count;
            contVitae.Text = "Poção Vitae: " + feiticeira.mochila.bagVitae.Count;
            contWhey.Text = "Poção Whey: " + feiticeira.mochila.bagWhey.Count;
            contPecas.Text = "Você tem " + feiticeira.Moedas + " moedas";
        }

        /// <summary>
        /// Integração para a batalha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaginaDaBatalha(object sender, RoutedEventArgs e)
        {
            controller.Feiticeira = feiticeira;
            this.Frame.Navigate(typeof(TesteBatalha2), controller);
        }

        /// <summary>
        /// Integração pagina da loja
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaginaDaLoja(object sender, RoutedEventArgs e)
        {
            controller.Feiticeira = feiticeira;
            this.Frame.Navigate(typeof(Loja), controller);
        }


        /// <summary>
        /// Selecio o Whey como item de batalha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LevarWhey(object sender, RoutedEventArgs e)
        {
            feiticeira.EscolherItemdeBatalha(feiticeira.mochila.bagWhey);
            if(((BitmapImage)Item_mochila.Source).UriSource.AbsolutePath == ("/Assets/interrogacao.png"))
            {
                Item_mochila.Source = new BitmapImage(new Uri("ms-appx:///Assets/pocao_whey.png"));
                AtualizarContItens();
            }
            else if (((BitmapImage)Item_mochila2.Source).UriSource.AbsolutePath == ("/Assets/interrogacao.png"))
            {
                Item_mochila2.Source = new BitmapImage(new Uri("ms-appx:///Assets/pocao_whey.png"));
                AtualizarContItens();
            }

        }

        /// <summary>
        /// Retira o Whey como item de batalha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RetirarWhey(object sender, RoutedEventArgs e)
        {
            PocaoWhey whey = new PocaoWhey();
            feiticeira.RetirarItemdeBatalha(feiticeira.mochila.bagWhey, whey);
            if (((BitmapImage)Item_mochila2.Source).UriSource.AbsolutePath == ("/Assets/pocao_whey.png"))
            {
                Item_mochila2.Source = new BitmapImage(new Uri("ms-appx:///Assets/interrogacao.png"));
                AtualizarContItens();
            }
            else if (((BitmapImage)Item_mochila.Source).UriSource.AbsolutePath == ("/Assets/pocao_whey.png"))
            {
                Item_mochila.Source = new BitmapImage(new Uri("ms-appx:///Assets/interrogacao.png"));
                AtualizarContItens();
            }
        }

        private void LevarPirlimpimpim(object sender, RoutedEventArgs e)
        {
            feiticeira.EscolherItemdeBatalha(feiticeira.mochila.bagPirlimpimpim);
            if (((BitmapImage)Item_mochila.Source).UriSource.AbsolutePath == ("/Assets/interrogacao.png"))
            {
                Item_mochila.Source = new BitmapImage(new Uri("ms-appx:///Assets/po_pirlimpimpim.png"));
                AtualizarContItens();
            }
            else if (((BitmapImage)Item_mochila2.Source).UriSource.AbsolutePath == ("/Assets/interrogacao.png"))
            {
                Item_mochila2.Source = new BitmapImage(new Uri("ms-appx:///Assets/po_pirlimpimpim.png"));
                AtualizarContItens();
            }
        }

        private void RetirarPirlimpimpim(object sender, RoutedEventArgs e)
        {
            Pirlimpimpim pirlimpimpim = new Pirlimpimpim();
            feiticeira.RetirarItemdeBatalha(feiticeira.mochila.bagPirlimpimpim, pirlimpimpim);
            if (((BitmapImage)Item_mochila2.Source).UriSource.AbsolutePath == ("/Assets/po_pirlimpimpim.png"))
            {
                Item_mochila2.Source = new BitmapImage(new Uri("ms-appx:///Assets/interrogacao.png"));
                AtualizarContItens();
            }
            else if (((BitmapImage)Item_mochila.Source).UriSource.AbsolutePath == ("/Assets/po_pirlimpimpim.png"))
            {
                Item_mochila.Source = new BitmapImage(new Uri("ms-appx:///Assets/interrogacao.png"));
                AtualizarContItens();
            }
        }

        private void LevarFortalecedora(object sender, RoutedEventArgs e)
        {
            feiticeira.EscolherItemdeBatalha(feiticeira.mochila.bagFortalecedora);
            if (((BitmapImage)Item_mochila.Source).UriSource.AbsolutePath == ("/Assets/interrogacao.png"))
            {
                Item_mochila.Source = new BitmapImage(new Uri("ms-appx:///Assets/pocao_fortalecedora.png"));
                AtualizarContItens();
            }
            else if (((BitmapImage)Item_mochila2.Source).UriSource.AbsolutePath == ("/Assets/interrogacao.png"))
            {
                Item_mochila2.Source = new BitmapImage(new Uri("ms-appx:///Assets/pocao_fortalecedora.png"));
                AtualizarContItens();
            }
        }

        private void RetirarFortalecedora(object sender, RoutedEventArgs e)
        {
            PocaoFortalecedora fortalecedora = new PocaoFortalecedora();
            feiticeira.RetirarItemdeBatalha(feiticeira.mochila.bagFortalecedora, fortalecedora);
            if (((BitmapImage)Item_mochila2.Source).UriSource.AbsolutePath == ("/Assets/pocao_fortalecedora.png"))
            {
                Item_mochila2.Source = new BitmapImage(new Uri("ms-appx:///Assets/interrogacao.png"));
                AtualizarContItens();
            }
            else if (((BitmapImage)Item_mochila.Source).UriSource.AbsolutePath == ("/Assets/pocao_fortalecedora.png"))
            {
                Item_mochila.Source = new BitmapImage(new Uri("ms-appx:///Assets/interrogacao.png"));
                AtualizarContItens();
            }
        }

        private void LevarRadix(object sender, RoutedEventArgs e)
        {
            feiticeira.EscolherItemdeBatalha(feiticeira.mochila.bagRadix);
            if (((BitmapImage)Item_mochila.Source).UriSource.AbsolutePath == ("/Assets/interrogacao.png"))
            {
                Item_mochila.Source = new BitmapImage(new Uri("ms-appx:///Assets/pocao_radix.png"));
                AtualizarContItens();
            }
            else if (((BitmapImage)Item_mochila2.Source).UriSource.AbsolutePath == ("/Assets/interrogacao.png"))
            {
                Item_mochila2.Source = new BitmapImage(new Uri("ms-appx:///Assets/pocao_radix.png"));
                AtualizarContItens();
            }
        }

        private void RetirarRadix(object sender, RoutedEventArgs e)
        {
            PocaoRadix radix = new PocaoRadix();
            feiticeira.RetirarItemdeBatalha(feiticeira.mochila.bagRadix, radix);
            if (((BitmapImage)Item_mochila2.Source).UriSource.AbsolutePath == ("/Assets/pocao_radix.png"))
            {
                Item_mochila2.Source = new BitmapImage(new Uri("ms-appx:///Assets/interrogacao.png"));
                AtualizarContItens();
            }
            else if (((BitmapImage)Item_mochila.Source).UriSource.AbsolutePath == ("/Assets/pocao_radix.png"))
            {
                Item_mochila.Source = new BitmapImage(new Uri("ms-appx:///Assets/po_pirlimpimpim.png"));
                AtualizarContItens();
            }
        }

        private void LevarVitae(object sender, RoutedEventArgs e)
        {
            feiticeira.EscolherItemdeBatalha(feiticeira.mochila.bagVitae);
            if (((BitmapImage)Item_mochila.Source).UriSource.AbsolutePath == ("/Assets/interrogacao.png"))
            {
                Item_mochila.Source = new BitmapImage(new Uri("ms-appx:///Assets/pocao_vitae.png"));
                AtualizarContItens();
            }
            else if (((BitmapImage)Item_mochila2.Source).UriSource.AbsolutePath == ("/Assets/interrogacao.png"))
            {
                Item_mochila2.Source = new BitmapImage(new Uri("ms-appx:///Assets/pocao_vitae.png"));
                AtualizarContItens();
            }
        }

        private void RetirarVitae(object sender, RoutedEventArgs e)
        {
            PocaoVitae vitae = new PocaoVitae();
            feiticeira.RetirarItemdeBatalha(feiticeira.mochila.bagVitae, vitae);
            if (((BitmapImage)Item_mochila2.Source).UriSource.AbsolutePath == ("/Assets/pocao_vitae.png"))
            {
                Item_mochila2.Source = new BitmapImage(new Uri("ms-appx:///Assets/interrogacao.png"));
                AtualizarContItens();
            }
            else if (((BitmapImage)Item_mochila.Source).UriSource.AbsolutePath == ("/Assets/pocao_vitae.png"))
            {
                Item_mochila.Source = new BitmapImage(new Uri("ms-appx:///Assets/po_pirlimpimpim.png"));
                AtualizarContItens();
            }
        }
    }
}
