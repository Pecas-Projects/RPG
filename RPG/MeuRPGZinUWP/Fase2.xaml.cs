﻿using System;
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
    public sealed partial class Fase2 : Page
    {
        int feiticeiraX = 9, feiticeiraY = 8;
        public Labirinto2 l;
        public Feiticeira bia = new Feiticeira();
        Image[,] matrizImg = new Image[10, 10]; //matriz interna das imagens do labirinto

        public Fase2()
        {
            this.InitializeComponent();
            butao.Focus(FocusState.Programmatic);
            l = new Labirinto2();
            matrizImg[9, 1] = moeda0;
            matrizImg[9, 2] = moeda1;
            matrizImg[9, 3] = moeda2;
            matrizImg[8, 3] = moeda3;
            matrizImg[7, 5] = moeda4;
            matrizImg[8, 5] = moeda5;
            matrizImg[6, 0] = moeda6;
            matrizImg[6, 1] = moeda7;
            matrizImg[1, 5] = moeda8;
            matrizImg[1, 4] = moeda9;
            matrizImg[2, 5] = moeda10;
            matrizImg[1, 6] = vitae;
            matrizImg[7, 0] = radix;
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

            if (l.TemItem(feiticeiraX, feiticeiraY, bia))
            {
               
                Image Item = matrizImg[feiticeiraX, feiticeiraY];
                canvasMap.Children.Remove(Item); //remove visualmente o item
              
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
