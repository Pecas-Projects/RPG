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
using System.Security.Cryptography.X509Certificates;
using Windows.UI.Xaml.Media.Imaging;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace MeuRPGZinUWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class TesteBatalha2 : Page
    {
        public Feiticeira feiticeira = new Feiticeira();
        public ControllerBatalha controller = new ControllerBatalha();
        public Personagem Inimigo { get; set; }
        public ControllerBatalha Controller = new ControllerBatalha();

        public TesteBatalha2()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            controller = e.Parameter as ControllerBatalha;
            feiticeira = controller.Feiticeira;
            if (controller.Fase == 1)
            {
                Inimigo = new SereianosNPC();
                
            }
            else if(controller.Fase == 2)
            {
                Inimigo = new FadaNPC();
            }
            inimigoImg.Source = new BitmapImage(Inimigo.ImagemPersonagem);
        }

        public void AtualizarStatus()
        {
            feiticeiraVida.Text = "Vida: " + feiticeira.Vida;
            feiticeiraEscudo.Text = "Escudo: " + feiticeira.Escudo;
            feiticeiraEstamina.Text = "Estamina: " + feiticeira.Estamina;

            sereianoVida.Text = "Vida: " + Inimigo.Vida;
            sereianoEscudo.Text = "Escudo: " + Inimigo.Escudo;
            sereianoEstamina.Text = "Estamina: " + Inimigo.Estamina;
        }

        public void RegistraAcoes (int jogadora, int inimigo)
        {
            if (inimigo == -1)
            {
                acaoSereiano.Text = "Ação: Descançou";
            }
            else if (inimigo == 0)
            {
                acaoSereiano.Text = "Ação: Usou escudo";
            }
            else if (inimigo == 1)
            {
                acaoSereiano.Text = "Ação: Atacou";
            }

            if (jogadora == -1)
            {
                acaoFeiticeira.Text = "Ação: Descançou";
            }
            else if (jogadora == 0)
            {
                acaoFeiticeira.Text = "Ação: Usou escudo";
            }
            else if (jogadora == 1)
            {
                acaoFeiticeira.Text = "Ação: Atacou";
            }
        }

        private void batalhaInicio(object sender, RoutedEventArgs e)
        {
            if(feiticeira != null && Inimigo != null)
            {
                AtualizarStatus();
                Item1_Img.Source = new BitmapImage(feiticeira.ItemdeBatalha[0].ImagemItem);
                Item2_Img.Source = new BitmapImage(feiticeira.ItemdeBatalha[1].ImagemItem);

            }
        }

        private void Ataque(object sender, RoutedEventArgs e)
        {
            if(feiticeira.Estamina >= feiticeira.PerdaEstamina)
            {
                int acaoInimigo;
                acaoInimigo = ((PersonagemNPC)Inimigo).Inteligencia(feiticeira);
                feiticeira.atacar(Inimigo);

                if (Controller.FimDeTurno(feiticeira, Inimigo, 1, acaoInimigo) != null)
                {
                    AtualizarStatus();
                    //acabar o jogo aqui e mostrar o vencedor
                    //tudo some, fica só uma imagem de ganhador
                    //botões de 1px, feiticeira feliz ou triste
                    //um botão que era de 1px fica grande falando pra pular para a próxima fase
                    Fim_BTN.Height = 71;
                    Fim_BTN.Width = 419;
                    Inicio_BTN.Height = 0;
                    Inicio_BTN.Width = 0;
                    usarEscudo.Width = 0;
                    usarEscudo.Height = 0;
                    ataque.Width = 0;
                    ataque.Height = 0;
                    descancar.Width = 0;
                    descancar.Height = 0;
                }
                else
                {
                    RegistraAcoes(1, acaoInimigo);
                    AtualizarStatus();
                }


            }
            else
            {
                //algo no fronte falando que não pode atacar 
            }
            

            
            
        }

        private void usarEscudoBrabo(object sender, RoutedEventArgs e)
        {
            
            if(feiticeira.Escudo > 0)
            {
                int acaoInimigo;
                feiticeira.usarEscudo();
                acaoInimigo = ((PersonagemNPC)Inimigo).Inteligencia(feiticeira);

                if(Controller.FimDeTurno(feiticeira, Inimigo, 0, acaoInimigo) != null)
                {
                    AtualizarStatus();
                    //acabar o jogo aqui e mostrar o vencedor
                    //tudo some, fica só uma imagem de ganhador
                    //botões de 1px, feiticeira feliz ou triste
                    //um botão que era de 1px fica grande falando pra pular para a próxima fase
                    Fim_BTN.Height = 71;
                    Fim_BTN.Width = 419;
                    Inicio_BTN.Height = 0;
                    Inicio_BTN.Width = 0;
                    usarEscudo.Width = 0;
                    usarEscudo.Height = 0;
                    ataque.Width = 0;
                    ataque.Height = 0;
                    descancar.Width = 0;
                    descancar.Height = 0;
                }
                else
                {
                    RegistraAcoes(0, acaoInimigo);
                    AtualizarStatus();
                   
                }
                
            }
            else
            {
                //algo no fronte avisando q não tem escudo e pedindo pra escolher outra coisa
            }
            
        }

        private void DescancarTroll(object sender, RoutedEventArgs e)
        {
            int acaoInimigo;
            acaoInimigo = ((PersonagemNPC)Inimigo).Inteligencia(feiticeira);
            feiticeira.descansar();
            

            if (Controller.FimDeTurno(feiticeira, Inimigo, -1, acaoInimigo) != null)
            {
                AtualizarStatus();
                //acabar o jogo aqui e mostrar o vencedor
                //tudo some, fica só uma imagem de ganhador
                //botões de 1px, feiticeira feliz ou triste
                //um botão que era de 1px fica grande falando pra pular para a próxima fase
                Fim_BTN.Height = 71;
                Fim_BTN.Width = 419;
                Inicio_BTN.Height = 0;
                Inicio_BTN.Width = 0;
                usarEscudo.Width = 0;
                usarEscudo.Height = 0;
                ataque.Width = 0;
                ataque.Height = 0;
                descancar.Width = 0;
                descancar.Height = 0;

            }
            else
            {
                RegistraAcoes(-1, acaoInimigo);
                AtualizarStatus();
                
            }

          
        }

        private void ProximaFase(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Fase2), feiticeira);
        }

        private void UsarItem1NaBatalha(object sender, RoutedEventArgs e)
        {
            
            if(feiticeira.ItemdeBatalha[0].utilizado == false)
            {
                Item item = feiticeira.ItemdeBatalha[0] as Item;
                Controller.UsarItemUtilizavel(feiticeira, feiticeira.ItemdeBatalha[0]);
                AtualizarStatus();
                feiticeira.ItemdeBatalha[0].utilizado = true;
                Item1_Img.Source = new BitmapImage(new Uri("ms-appx:///Assets/interrogacao.png"));
            }   
        }

        private void UsarItem2NaBatalha(object sender, RoutedEventArgs e)
        {

            if (feiticeira.ItemdeBatalha[1].utilizado == false)
            {
                Item item = feiticeira.ItemdeBatalha[1] as Item;
                Controller.UsarItemUtilizavel(feiticeira, feiticeira.ItemdeBatalha[1]);
                AtualizarStatus();
                feiticeira.ItemdeBatalha[1].utilizado = true;
                Item2_Img.Source = new BitmapImage(new Uri("ms-appx:///Assets/interrogacao.png"));

            }
        }
    }
}
