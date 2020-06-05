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
    /// Primeira tela que é exibida no jogo.
    /// Apartir dessa tela, o usuário pode ir para a tela com a história completa, ou
    /// iniciar o jogo.
    /// </summary>
    public sealed partial class TelaInicio : Page
    {
        
        public TelaInicio()
        {
            this.InitializeComponent();
        }

        private void Historia_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Iniciarjogo_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (TelaInicio2));
        }
    }
}
