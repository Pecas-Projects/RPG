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
using System.Timers;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace MeuRPGZinUWP
{
    /// <summary>
    /// Página do Labirinto da Fase3.
    /// </summary>
    public sealed partial class Fase3 : Page
    {
        DispatcherTimer dispatcherTimer;
        DateTimeOffset startTime;
        DateTimeOffset lastTime;
        DateTimeOffset stopTime;
        int timesTicked = 1;
        int timesToTick = 50;
        int tempoTotal = 50;

        int feiticeiraX = 9, feiticeiraY = 5;

        public Labirinto3 l;

        public Feiticeira feiticeira = new Feiticeira();

        Image[,] matrizImg = new Image[10, 10]; //matriz interna das imagens do labirinto
        public int contMoedas = 0;
        public bool Fort = false, _Pirlim= false, Whey=false;

        public Fase3()
        {
            this.InitializeComponent();
            butao.Focus(FocusState.Programmatic);
            l = new Labirinto3();
            DispatcherTimerSetup();

            //setando coordenadas das imagens dos itens no labirinto
            matrizImg[9, 6] = moeda0;
            matrizImg[9, 7] = moeda1;
            matrizImg[8, 1] = moeda2;
            matrizImg[7, 1] = moeda3;
            matrizImg[7, 6] = moeda4;
            matrizImg[6, 3] = moeda5;
            matrizImg[5, 4] = moeda6;
            matrizImg[5, 6] = moeda7;
            matrizImg[5, 7] = moeda8;
            matrizImg[1, 2] = moeda9;
            matrizImg[1, 1] = moeda10;
            matrizImg[1, 7] = fortalecedora;
            matrizImg[3, 7] = whey;
            matrizImg[7, 8] = pirlimpimpim;
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

            if (l.TemItem(feiticeiraX, feiticeiraY, feiticeira))
            {

                Image Item = matrizImg[feiticeiraX, feiticeiraY];
                canvasMap.Children.Remove(Item); //remove visualmente o item

                if (feiticeiraX == 1 && feiticeiraY == 7) Fort = true;
                else if (feiticeiraX == 3 && feiticeiraY == 7) Whey = true;
                else if (feiticeiraX == 7 && feiticeiraY == 8) _Pirlim = true;

            }
            if (l.TemPeca(feiticeiraX, feiticeiraY, feiticeira)) //remove visualmente a moeda
            {
                ++contMoedas;
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
            if (feiticeiraX == 1 && feiticeiraY == 0)
            {
                dispatcherTimer.Stop();
                this.Frame.Navigate(typeof(TelaIntegracao), feiticeira);
            }
            if (l.TemParedeEsquerda(feiticeiraX, feiticeiraY) == false)
            {
                feiticeiraMovimento.X -= 80;
                feiticeiraY -= 1;

            }
        }

        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            //IsEnabled defaults to false
           
            startTime = DateTimeOffset.Now;
            lastTime = startTime;
            
            dispatcherTimer.Start();
            //IsEnabled should now be true after calling start
           
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            DateTimeOffset time = DateTimeOffset.Now;
            TimeSpan span = time - lastTime;
            lastTime = time;
            //Time since last tick should be very very close to Interval
            tempoTotal = timesToTick - timesTicked;
            tempo.Text = "TEMPO RESTANTE: " + tempoTotal.ToString() + "s";
            timesTicked++;
            if (timesTicked > timesToTick) //quando ot empo terminar
            {
                stopTime = time;
                dispatcherTimer.Stop();
                span = stopTime - startTime;

                //deleta tudo que o jogador coletou no labirinto se ele perder
                if (Fort) feiticeira.mochila.RemoverItem(feiticeira.mochila.bagFortalecedora);
                if (Whey) feiticeira.mochila.RemoverItem(feiticeira.mochila.bagWhey);
                if (_Pirlim) feiticeira.mochila.RemoverItem(feiticeira.mochila.bagPirlimpimpim);
                feiticeira.Moedas -= contMoedas;

                tempo.Text = "GAME OVER";
                this.Frame.Navigate(typeof(gameOver));
            }
        }
    }
}
