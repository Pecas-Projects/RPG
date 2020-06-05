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
    public sealed partial class venceuBatalha1 : Page
    {
        ControllerBatalha controller = new ControllerBatalha();

        public venceuBatalha1()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            controller = e.Parameter as ControllerBatalha;
        }

        private void irLab_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Fase2), controller);
        }

        private void ajuda_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Instrucoes));
        }

        private void pedraAgua_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
