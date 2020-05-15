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
using MeuRPGZinCore;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace MeuRPGZinUWP
{

    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class pagina4 : Page
    {
        int feiticeiraX = 9, feiticeiraY = 0;
        public Labirinto1 l;
        public PocaoWhey pocao_whey = new PocaoWhey();
        public Feiticeira bia = new Feiticeira();
        Image[,] matrizImg = new Image[10, 10]; //matriz interna das imagens do labirinto


        public pagina4()
        {
            this.InitializeComponent();
            butao.Focus(FocusState.Programmatic);
            l = new Labirinto1();
            //setando imagens das moedas à matriz controladora
            matrizImg[1, 4] = moeda0;
            matrizImg[1, 5] = moeda1;
            matrizImg[1, 7] = moeda2;
            matrizImg[2, 7] = moeda3;
            matrizImg[3, 7] = moeda4;
            matrizImg[9, 7] = moeda5;
            matrizImg[9, 6] = moeda6;
            matrizImg[9, 5] = moeda7;
            matrizImg[1, 2] = whey;
        }

        /*protected override async void OnKeyDown(KeyRoutedEventArgs e)
               {
                   base.OnKeyDown(e);
                   if (e.Key == Windows.System.VirtualKey.Down)
                   {

                   }
                   else if (e.Key == Windows.System.VirtualKey.Up)
                   {
                       BitmapImage img1 = new BitmapImage();
                       Uri url2 = new Uri(this.BaseUri, "Assets/feiticeira_right_2.png");
                       img1.UriSource = url2;
                       ImgBestFriend.Source = img1;
                   }
               } */

        protected override void OnKeyUp(KeyRoutedEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.Key == Windows.System.VirtualKey.Down)
            {
                Down();
            }
            else if (e.Key == Windows.System.VirtualKey.Up)
            {
                /*BitmapImage img1 = new BitmapImage();
                Uri url2 = new Uri(this.BaseUri, "Assets/feiticeira_right_2.png");
                img1.UriSource = url2;
                ImgBestFriend.Source = img1;*/

                Up();

            }
            else if (e.Key == Windows.System.VirtualKey.Right)
            {
                Right();
            }
            else if (e.Key == Windows.System.VirtualKey.Left)
            {
                Left();
            }

            if (l.TemItem(feiticeiraX, feiticeiraY, bia, pocao_whey))
            {
                Image Whey = matrizImg[feiticeiraX, feiticeiraY];
                canvasMap.Children.Remove(Whey); //remove visualmente o item
                //Console.WriteLine(bia.mochila.bagWhey.Count);
            }
            if (l.TemPeca(feiticeiraX, feiticeiraY, bia)) //remove visualmente a moeda
            {
                Image moeda = matrizImg[feiticeiraX, feiticeiraY];
                canvasMap.Children.Remove(moeda); //remove visualmente a moeda
                //Console.WriteLine(bia.moedas);
            }

        }

            public void Down()
            {
                if (l.TemParedeBaixo(feiticeiraX, feiticeiraY) == false)
                {
                    feiticeiraMovimento.Y += 80;
                    feiticeiraX += 1;

                }

            }

            public void Up()
            {   
                if (feiticeiraX == 4)
            {
                Console.WriteLine("tá na linha 4");
            }
                if (l.TemParedeTopo(feiticeiraX, feiticeiraY) == false)
                {
                    feiticeiraMovimento.Y -= 80;
                    feiticeiraX -= 1;               

                }
            }

            public void Right()
            {
                if (l.TemParedeDireita(feiticeiraX, feiticeiraY) == false)
                {
                    feiticeiraMovimento.X += 80;
                    feiticeiraY += 1;

                }                
            }

            public void Left()
            {
                if (l.TemParedeEsquerda(feiticeiraX, feiticeiraY) == false)
                {
                    feiticeiraMovimento.X -= 80;
                    feiticeiraY -= 1;

                }
            }   

        }
    }


    