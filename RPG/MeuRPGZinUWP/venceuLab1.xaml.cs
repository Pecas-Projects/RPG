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
    /// Página que aparece quando o usuário vence o Labirinto da fase 1.
    /// Apartir dessa página, usuário pode:
    /// Ir direto para a próxima batalha,
    /// Ir para a página da Mochila,
    /// Ir para a página de Instruções,
    /// Ir para a página com a história da Pedra Da Água.
    /// </summary>
    public sealed partial class VenceuLab1 : Page
    {
        ControllerBatalha controller = new ControllerBatalha();

        public VenceuLab1()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            controller = e.Parameter as ControllerBatalha;
        }

        private void IrBag_Click(object sender, RoutedEventArgs e)
        {
            controller.Fase = 1;
            this.Frame.Navigate(typeof(TelaIntegracao), controller);
        }

        private void Ajuda_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Instrucoes));
        }

        private void IrBatalha_Click(object sender, RoutedEventArgs e)
        {
            controller.Fase = 1;
            this.Frame.Navigate(typeof(TesteBatalha2), controller);
        }

        private void PedraAgua_Click(object sender, RoutedEventArgs e)
        {
            //tela da história do reino
        }
    }
}
