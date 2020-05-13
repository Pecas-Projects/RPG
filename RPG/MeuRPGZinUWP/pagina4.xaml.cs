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
        Labirinto1 l;

        public pagina4()
        {
            this.InitializeComponent();
            butao.Focus(FocusState.Programmatic);
            l = new Labirinto1();
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


    