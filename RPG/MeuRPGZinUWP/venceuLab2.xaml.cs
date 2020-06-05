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
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class venceuLab2 : Page
    {
        ControllerBatalha controller = new ControllerBatalha();

        public venceuLab2()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            controller = e.Parameter as ControllerBatalha;
        }

        private void ajuda_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Instrucoes));
        }

        private void irBatalha_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TesteBatalha2), controller);
        }

        private void irBag_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TelaIntegracao), controller);
        }

        private void pedraAr_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
