﻿using System;
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
    /// Tela da história de Ardens Missus.
    /// </summary>
    public sealed partial class historia : Page
    {
        public historia()
        {
            this.InitializeComponent();
        }

        private void Voltar_handleClick(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void pedraAgua_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HistoriaAequor));
        }

        private void pedraTerra_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HistoriaSavi));
        }

        private void pedraFogo_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HistoriaIgnis));
        }

        private void pedraAr_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HistoriaCaeli));
        }
    }
}
