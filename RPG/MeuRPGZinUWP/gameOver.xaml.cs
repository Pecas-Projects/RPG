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
    /// Página de Game Over de um Labirinto. Aparece caso o labirinto não seja finalizado
    /// antes de acabar o tempo.
    /// O usuário pode retornar para o labirinto que perdeu.
    /// </summary>
    public sealed partial class gameOver : Page
    {
        public gameOver()
        {
            this.InitializeComponent();
        }

        private void HandleClick(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

       
    }
}
