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
    /// Tela que aparece antes do primeiro laberinto, contextualizando a história da fase 1.
    /// A partir dessa tela, o usuário pode ir para a página do labirinto 1 ou ir para a página de instruções.
    /// </summary>
    public sealed partial class TelaInicio2 : Page
    {
        public TelaInicio2()
        {
            this.InitializeComponent();
        }


        private void Iniciar_handleClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Fase1));
        }

        private void Instrucoes_handleClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Instrucoes));
        }

        private void pedraTerra_handleClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HistoriaSavi));
        }
    }
}
