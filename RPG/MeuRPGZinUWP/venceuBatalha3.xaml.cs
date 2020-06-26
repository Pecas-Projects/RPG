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
    /// Página que aparece quando o usuário vence a batalha da fase 3.
    /// Apartir dessa página, usuário pode:
    /// Ir direto para a próxima batalha,
    /// Ir para a página da Mochila,
    /// Ir para a página de Instruções,
    /// Ir para a página com a história da Pedra Do Fogo.
    /// </summary>
    public sealed partial class venceuBatalha3 : Page
    {
        ControllerBatalha controller = new ControllerBatalha();

        public venceuBatalha3()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            controller = e.Parameter as ControllerBatalha;
        }

        private void IrBatalha_Click(object sender, RoutedEventArgs e)
        {
            controller.Feiticeira.Pedras.Add(new Uri("ms-appx:///Assets/pedras_do_fogo.png"));
            controller.Fase = 4;
            controller.RecompencaBatalha();
            this.Frame.Navigate(typeof(Batalha), controller);
        }

        private void Itens_Click(object sender, RoutedEventArgs e)
        {
            controller.Feiticeira.Pedras.Add(new Uri("ms-appx:///Assets/pedras_do_fogo.png"));
            controller.Fase = 4;
            controller.RecompencaBatalha();
            this.Frame.Navigate(typeof(Mochila), controller);
        }

        private void Ajuda_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Instrucoes));
        }

        private void PedraFogo_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HistoriaIgnis));
        }
    }
}
