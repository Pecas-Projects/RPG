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
using System.Security.Cryptography.X509Certificates;
using Windows.UI.Xaml.Media.Imaging;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace MeuRPGZinUWP
{
    /// <summary>
    /// Tela da batalha.
    /// Todas as batalhas ocorrem nessa tela, mas os inimigos e o plano de fundo, 
    /// são trocados de acordo com a fase em que o usuário está.
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

        /// <summary>
        /// Método que escolhe o inimigo e o plano de fundo da fase correspondente.
        /// Prepara a feiticeira e o controller para começar uma nova batalha.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            controller = e.Parameter as ControllerBatalha;
            feiticeira = controller.Feiticeira;
            if (controller.Fase == 1)
            {
                Inimigo = new SereianosNPC();
                //Colocar back
            }
            else if(controller.Fase == 2)
            {
                Inimigo = new FadaNPC();
            }
            else if (controller.Fase == 3)
            {
                Inimigo = new BarbaroNPC();
            }
            else if(controller.Fase == 4)
            {
                Inimigo = new HumanoNPC();
            }
            inimigoImg.Source = new BitmapImage(Inimigo.ImagemPersonagem);

            controller.ContAtaqueFeiticeira = 0;
            controller.ContAtaqueInimigo = 0;
            controller.ContDefesaFeiticeira = 0;
            controller.ContDefesaInimigo = 0;
            controller.ContDescancarFeiticeira = 0;
            controller.ContDescancarInimigo = 0;
            controller.ContTurnos = 0;
            feiticeira.Vida = 100;
            feiticeira.Estamina = 1;
            feiticeira.Escudo = 50;
            controller.Feiticeira = feiticeira;
        }

        /// <summary>
        /// Método que atualiza na tela os Status da Feiticeira e seu inimigo.
        /// </summary>
        public void AtualizarStatus()
        {
            feiticeiraVida.Text = "Vida: " + feiticeira.Vida;
            feiticeiraEscudo.Text = "Escudo: " + feiticeira.Escudo;
            feiticeiraEstamina.Text = "Estamina: " + feiticeira.Estamina;

            inimigoVida.Text = "Vida: " + Inimigo.Vida;
            inimigoEscudo.Text = "Escudo: " + Inimigo.Escudo;
            inimigoEstamina.Text = "Estamina: " + Inimigo.Estamina;
        }

        /// <summary>
        /// Método que exibe a tela de Game Over da batalha ou permite que o usuário vá para a próxima fase.
        /// </summary>
        public void FinalDeJogo()
        {
            if (feiticeira.Vida <= 0)
            {
                controller.Feiticeira = feiticeira;
                this.Frame.Navigate(typeof(gameOverBatalha));
            }
            else if(Inimigo.Vida <= 0)
            {
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
        }

        /// <summary>
        /// Método que exibe na página quais foram as ações realizadas 
        /// pela feiticeira e seu inimigo em um turno.
        /// </summary>
        /// <param name="jogadora"></param>
        /// <param name="inimigo"></param>
        public void RegistraAcoes (int jogadora, int inimigo)
        {
            if (inimigo == -1)
            {
                acaoInimigo.Text = "Ação: Descançou";
            }
            else if (inimigo == 0)
            {
                acaoInimigo.Text = "Ação: Usou escudo";
            }
            else if (inimigo == 1)
            {
                acaoInimigo.Text = "Ação: Atacou";
            }
            else
            {
                acaoInimigo.Text = "Ação: Ataque Especial";
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
            else
            {
                acaoFeiticeira.Text = "Ação: Ataque Especial";
            }
        }

        /// <summary>
        /// Método associado ao botão de iniciar a batalha.
        /// Exibe os itens que a feitceira levou para a batalha, e o status da feiticeira e do seu inimigo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BatalhaInicio(object sender, RoutedEventArgs e)
        {
            if(feiticeira != null && Inimigo != null)
            {
                AtualizarStatus();
                if(feiticeira.ItemdeBatalha.Count == 1)
                {
                    Item1_Img.Source = new BitmapImage(feiticeira.ItemdeBatalha[0].ImagemItem);
                }

                if (feiticeira.ItemdeBatalha.Count == 2)
                {
                    Item2_Img.Source = new BitmapImage(feiticeira.ItemdeBatalha[1].ImagemItem);
                }
            }
        }

        /// <summary>
        /// Botão de Ataque da feiticeira, chama o método "Atacar" da classe Personagem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ataque(object sender, RoutedEventArgs e)
        {
            if(feiticeira.Estamina >= feiticeira.PerdaEstamina)
            {
                int acaoInimigo;
                acaoInimigo = ((PersonagemNPC)Inimigo).Acao(feiticeira, controller);
                feiticeira.Atacar(Inimigo);
                controller.RelatorioTurno(1, acaoInimigo);

                if (Controller.FimDeTurno(feiticeira, Inimigo, 1, acaoInimigo) != null)
                {
                    AtualizarStatus();
                    FinalDeJogo();
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

        /// <summary>
        /// Botão de usar escudo. Chama o método "UsarEscudo" da classe Personagem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsarEscudoBrabo(object sender, RoutedEventArgs e)
        {
            
            if(feiticeira.Escudo > 0)
            {
                int acaoInimigo;
                feiticeira.UsarEscudo();
                acaoInimigo = ((PersonagemNPC)Inimigo).Acao(feiticeira, controller);
                controller.RelatorioTurno(0, acaoInimigo);

                if (Controller.FimDeTurno(feiticeira, Inimigo, 0, acaoInimigo) != null)
                {
                    AtualizarStatus();
                    FinalDeJogo();
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

        /// <summary>
        /// Botão de Descansar. Chama o método "Descansar" da classe Personagem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DescancarTroll(object sender, RoutedEventArgs e)
        {
            int acaoInimigo;
            acaoInimigo = ((PersonagemNPC)Inimigo).Acao(feiticeira, controller);
            feiticeira.Descansar();
            controller.RelatorioTurno(-1, acaoInimigo);

            if (Controller.FimDeTurno(feiticeira, Inimigo, -1, acaoInimigo) != null)
            {
                AtualizarStatus();
                FinalDeJogo();

            }
            else
            {
                RegistraAcoes(-1, acaoInimigo);
                AtualizarStatus();
                
            } 
        }

        /// <summary>
        /// Método do botão que encaminha o usuário para a tela de vitória correspondente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProximaFase(object sender, RoutedEventArgs e)
        {
            controller.Feiticeira = feiticeira;
            if(controller.Fase == 1)
            {
                this.Frame.Navigate(typeof(venceuBatalha1), controller);
            }
            else if (controller.Fase == 2)
            {
                this.Frame.Navigate(typeof(venceuBtalha2), controller);
            }
            else if (controller.Fase == 3)
            {
                this.Frame.Navigate(typeof(venceuBatalha3), controller);
            }
            else if (controller.Fase == 4)
            {
                this.Frame.Navigate(typeof(VenceuJogo), controller);
            }

        }

        /// <summary>
        /// Método do botão associado ao uso do primeiro Item da List "ItemBatalha" da feiticeira.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsarItem1NaBatalha(object sender, RoutedEventArgs e)
        {
            if (feiticeira.ItemdeBatalha.Count == 1)
            {
                if (feiticeira.ItemdeBatalha[0].Utilizado == false)
                {
                    Item item = feiticeira.ItemdeBatalha[0] as Item;
                    Controller.UsarItemUtilizavel(feiticeira, feiticeira.ItemdeBatalha[0]);
                    AtualizarStatus();
                    feiticeira.ItemdeBatalha[0].Utilizado = true;
                    Item1_Img.Source = new BitmapImage(new Uri("ms-appx:///Assets/interrogacao.png"));
                }
            }              
        }

        /// <summary>
        /// Método do botão associado ao uso do segundo Item da List "ItemBatalha" da feiticeira.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsarItem2NaBatalha(object sender, RoutedEventArgs e)
        {
            if(feiticeira.ItemdeBatalha.Count == 2)
            {
                if (feiticeira.ItemdeBatalha[1].Utilizado == false)
                {
                    Item item = feiticeira.ItemdeBatalha[1] as Item;
                    Controller.UsarItemUtilizavel(feiticeira, feiticeira.ItemdeBatalha[1]);
                    AtualizarStatus();
                    feiticeira.ItemdeBatalha[1].Utilizado = true;
                    Item2_Img.Source = new BitmapImage(new Uri("ms-appx:///Assets/interrogacao.png"));
                }
            }      
        }

        /// <summary>
        /// Botão de Ataque Especial. Chama o método "ControleAtaqueEspecialFeiticeira" da classe ControllerBatalha.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AtaqueEspecial(object sender, RoutedEventArgs e)
        {
            if (controller.ContDefesaInimigo == 4)
            {
                int acaoInimigo;
                acaoInimigo = ((PersonagemNPC)Inimigo).Acao(feiticeira, controller);
                controller.ControleAtaqueEspecialFeiticeira(feiticeira, Inimigo);
                controller.RelatorioTurno(2, acaoInimigo);

                if (Controller.FimDeTurno(feiticeira, Inimigo, 2, acaoInimigo) != null)
                {
                    AtualizarStatus();
                    FinalDeJogo();

                }
                else
                {
                    RegistraAcoes(2, acaoInimigo);
                    AtualizarStatus();
                }
            }
            else
            {
                //Algo no front
            }
            
       }
    }
}
