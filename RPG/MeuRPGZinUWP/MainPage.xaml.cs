using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MeuRPGZinCore;
using Windows.System;
using Windows.Security.Cryptography.Certificates;
using Windows.UI.Xaml.Shapes;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace MeuRPGZinUWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //Personagem p = null;

        //public VirtualKey Key { get; set; }

        private void CreateParede()
        {
            // Initialize a new rectangle instance
            Rectangle parede = new Rectangle();

            // Set the rectangle height and width
            parede.Height = 40;
            parede.Width = 40;

            

            // Fill the rectangle with a solid color
            parede.Fill = new SolidColorBrush(Colors.Blue);

            // Set the rectangle border color
            parede.Stroke = new SolidColorBrush(Colors.LightSeaGreen);

            // Set rectangle border thickness/width
            parede.StrokeThickness = 5;
        }

        public MainPage()
        {
            //CreateParede();
            this.InitializeComponent();
            BtnCriarDoar.Click += BtnCriarDoar_Click;            
        }

        private void BtnCriarDoar_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pagina3));
            /*if (p == null)
            {
                p = new Personagem { Nivel = 1, Vida = 10 };
                var btn = sender as Button;
                btn.Content = "Doar Vida";
                p.PersonagemUP += TratarPersonagemUPLevel;
                TblLevel.Text = "Nível:" + p.Nivel;
                TblLife.Text = "Vida:" + p.Vida;
            }
            else
            {
                p.GanharVida();
                TblLife.Text = "Vida:" + p.Vida;
            }*/
        }

        /*private void TratarPersonagemUPLevel(object sender, PersonagemEventArgs e)
        {
            
            var persona = sender as MeuRPGZinCore.Personagem;
            TblLevel.Text = "Nível Anterior: " + e.NivelAnterior + " Novo Nível: " + persona.Nivel; 
        }

        private void BtnRetirar_Click(object sender, RoutedEventArgs e)
        {
            p?.TirarVida();
            TblLife.Text = "Vida:" + p?.Vida;
        }

        private void BtnVai_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pagina2), p);
        }

        /*private void Rectangle_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            //myTranslateTransform.X = myTranslateTransform.X - 15;
           // myTranslateTransform.Y = myTranslateTransform.Y + 15;
        }*/

        private void movimento_cima(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.W)
                ImgBFTranslateTransform.Y = ImgBFTranslateTransform.Y + 20;
    
        }

        //private void MeuBotao_Click(object sender, RoutedEventArgs e)
        //{
        //    var btn = sender as Button;
        //    if (btn != null)
        //    {
        //        double topBotao = Canvas.GetTop(btn);

        //        if (btn.Content.ToString() == "TÓXICO")
        //        {
        //            Debug.WriteLine("EU SOU TÓXICO!");
        //        }
        //    }
        //}

        //private void MeuBotao_PointerEntered(object sender, PointerRoutedEventArgs e)
        //{
        //    MeuBotao.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);

        //}

        //private void MeuBotao_PointerExited(object sender, PointerRoutedEventArgs e)
        //{
        //    // MeuBotao.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
        //}
    }
}
