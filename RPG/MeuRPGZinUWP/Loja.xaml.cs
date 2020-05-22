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
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace MeuRPGZinUWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class Loja : Page
    {
        public Feiticeira feiticeira = new Feiticeira();

        public Loja()
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            feiticeira = e.Parameter as Feiticeira;
            AtualizarContItens();
        }

        private void ComprarPoPirlimpimpim(object sender, RoutedEventArgs e)
        {
            Pirlimpimpim produto = new Pirlimpimpim();
            feiticeira.ComprarItem(produto, feiticeira.mochila.bagPirlimpimpim, produto.preco);
            AtualizarContItens();

        }

        private void ComprarPocaoWhey(object sender, RoutedEventArgs e)
        {
            PocaoWhey produto = new PocaoWhey();
            feiticeira.ComprarItem(produto, feiticeira.mochila.bagWhey, produto.preco);
            AtualizarContItens();
        }

        private void ComprarPocaoRadix(object sender, RoutedEventArgs e)
        {
            PocaoRadix produto = new PocaoRadix();
            feiticeira.ComprarItem(produto, feiticeira.mochila.bagRadix, produto.preco);
            AtualizarContItens();

        }

        private void ComprarPocaoVitae(object sender, RoutedEventArgs e)
        {
            PocaoVitae produto = new PocaoVitae();
            feiticeira.ComprarItem(produto, feiticeira.mochila.bagVitae, produto.preco);
            AtualizarContItens();

        }

        private void ComprarPocaoFortalecedora(object sender, RoutedEventArgs e)
        {
            PocaoFortalecedora produto = new PocaoFortalecedora();
            feiticeira.ComprarItem(produto, feiticeira.mochila.bagFortalecedora, produto.preco);
            AtualizarContItens();
        }

        private void IrparaMochila(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TelaIntegracao), feiticeira);
            AtualizarContItens();
        }
    }
}
