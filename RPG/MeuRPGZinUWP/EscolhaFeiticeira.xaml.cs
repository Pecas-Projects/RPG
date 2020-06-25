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
    public sealed partial class EscolhaFeiticeira : Page
    {
        public ControllerBatalha controller = new ControllerBatalha();
        public Feiticeira feiticeira = new Feiticeira();

        public EscolhaFeiticeira()
        {
            this.InitializeComponent();
        }

        private void Ana_Click(object sender, RoutedEventArgs e)
        {
            escolhaFeiticeira.Text = "Você escolheu a feiticeira Ana!";
            feiticeira.ImagemPersonagem = new Uri("ms-appx:///Assets/feiticeira_Ana.png");
            feiticeira.feiticeiraMorta = new Uri("ms-appx:///Assets/feiticeira_Ana_Morta.png");
            feiticeira.FeiticeiraDireita = new Uri("ms-appx:///Assets/Direita_feiticeira_Ana.png");
            feiticeira.FeiticeiraEsquerda = new Uri("ms-appx:///Assets/Esquerda_feiticeira_Ana.png");
            feiticeira.FeiticeiraCostas = new Uri("ms-appx:///Assets/Costas_feiticeira_Ana.png");

        }

        private void Bia_Click(object sender, RoutedEventArgs e)
        {
            escolhaFeiticeira.Text = "Você escolheu a feiticeira Bia!";
            feiticeira.ImagemPersonagem = new Uri("ms-appx:///Assets/feiticeira_front.png");
            feiticeira.feiticeiraMorta = new Uri("ms-appx:///Assets/feiticeira_Ana_Morta.png");
            feiticeira.FeiticeiraDireita = new Uri("ms-appx:///Assets/feiticeira_right_2.png");
            feiticeira.FeiticeiraEsquerda = new Uri("ms-appx:///Assets/feiticeira_left_2.png");
            feiticeira.FeiticeiraCostas = new Uri("ms-appx:///Assets/feiticeira_back.png");
        }

        private void Maria_Click(object sender, RoutedEventArgs e)
        {
            escolhaFeiticeira.Text = "Você escolheu a feiticeira Maria!";
            feiticeira.ImagemPersonagem = new Uri("ms-appx:///Assets/feiticeira_Maria.png");
            feiticeira.feiticeiraMorta = new Uri("ms-appx:///Assets/feiticeira_Maria_Morta.png");
            feiticeira.FeiticeiraDireita = new Uri("ms-appx:///Assets/Direita_feiticeira_Maria.png");
            feiticeira.FeiticeiraEsquerda = new Uri("ms-appx:///Assets/Esquerda_feiticeira_Maria.png");
            feiticeira.FeiticeiraCostas = new Uri("ms-appx:///Assets/Costas_feiticeira_Maria.png");
        }

        private void Fernanda_Click(object sender, RoutedEventArgs e)
        {
            escolhaFeiticeira.Text = "Você escolheu a feiticeira Fernanda!";
            feiticeira.ImagemPersonagem = new Uri("ms-appx:///Assets/feiticeira_Fernanda.png");
            feiticeira.feiticeiraMorta = new Uri("ms-appx:///Assets/feiticeira_Fernanda_Morta.png");
            feiticeira.FeiticeiraDireita = new Uri("ms-appx:///Assets/Direita_feiticeira_Fernanda.png");
            feiticeira.FeiticeiraEsquerda = new Uri("ms-appx:///Assets/Esquerda_feiticeira_Fernanda.png");
            feiticeira.FeiticeiraCostas = new Uri("ms-appx:///Assets/Costas_feiticeira_Fernanda.png");
        }

        private void contunuar_Click(object sender, RoutedEventArgs e)
        {
            if (feiticeira.ImagemPersonagem != null)
            {
                controller.Feiticeira = feiticeira;
                this.Frame.Navigate(typeof(TelaInicio2), controller);
            }
            else
            {
                escolhaFeiticeira.Text = "Você precisa escolher uma feiticeira!";
            }
            
        }
    }
}
