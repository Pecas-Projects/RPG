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
    /// Tela que aparece quendo o usuário vence o jogo.
    /// </summary>
    public sealed partial class VenceuJogo : Page
    {
        public VenceuJogo()
        {
            this.InitializeComponent();
        }

        private void Jogar_Novamente(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TelaInicio));
        }
    }
}
