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
    public sealed partial class Batalha : Page
    {
        public Feiticeira feiticeira = new Feiticeira();
        public ControllerBatalha controller = new ControllerBatalha();
        public Personagem Inimigo { get; set; }
        public ControllerBatalha Controller = new ControllerBatalha();

        public Batalha()
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
            
            if (controller.Fase == 1)
            {
                Inimigo = new SereianosNPC();
                fundo_batalha.Source = new BitmapImage(new Uri("ms-appx:///Assets/underwater_blur.png"));
            }
            else if(controller.Fase == 2)
            {
                Inimigo = new FadaNPC();
                fundo_batalha.Source = new BitmapImage(new Uri("ms-appx:///Assets/ceu_desfocado.png"));
            }
            else if (controller.Fase == 3)
            {
                Inimigo = new BarbaroNPC();
                fundo_batalha.Source = new BitmapImage(new Uri("ms-appx:///Assets/vulcao_gaussiano.png"));
            }
            else if(controller.Fase == 4)
            {
                Inimigo = new HumanoNPC();
                fundo_batalha.Source = new BitmapImage(new Uri("ms-appx:///Assets/floresta_gaussian.png"));
            }
            inimigoImg.Source = new BitmapImage(Inimigo.ImagemPersonagem);

            controller.ComecaBatalha();
            feiticeira = controller.Feiticeira;
            feiticeiraImg.Source = new BitmapImage(feiticeira.FeiticeiraCostas);
            AtualizarStatus();

            if (feiticeira.ItemdeBatalha.Count >= 1)
            {
                Item1_Img.Source = new BitmapImage(feiticeira.ItemdeBatalha[0].ImagemItem);
                Item1_Batalha.Height= 78;
                Item1_Batalha.Width = 133;
                
            }

            if (feiticeira.ItemdeBatalha.Count == 2)
            {
                Item1_Img.Source = new BitmapImage(feiticeira.ItemdeBatalha[0].ImagemItem);
                Item1_Batalha.Height = 78;
                Item1_Batalha.Width = 133;
                Item2_Img.Source = new BitmapImage(feiticeira.ItemdeBatalha[1].ImagemItem);
                Item2_Batalha.Height = 78;
                Item2_Batalha.Width = 133;
            }

        }
        

        /// <summary>
        /// Método que atualiza na tela os Status da Feiticeira e seu inimigo.
        /// </summary>
        public void AtualizarStatus()
        {
            feiticeiraVida.Text = "vida: " + feiticeira.Vida;
            feiticeiraEscudo.Text = "escudo: " + feiticeira.Escudo;
            feiticeiraEstamina.Text = "estamina: " + feiticeira.Estamina;

            inimigoVida.Text = "vida: " + Inimigo.Vida;
            inimigoEscudo.Text = "escudo: " + Inimigo.Escudo;
            inimigoEstamina.Text = "estamina: " + Inimigo.Estamina;

            if (controller.ContDefesaInimigo >= 4)
            {
                AtaqueEspecial_Btn.Source = new BitmapImage(new Uri("ms-appx:///Assets/bomba_before.png"));
            }
            else
            {
                AtaqueEspecial_Btn.Source = new BitmapImage(new Uri("ms-appx:///Assets/bomba_after.png"));
            }
        }


        /// <summary>
        /// Método que exibe a tela de Game Over da batalha ou permite que o usuário vá para a próxima fase.
        /// </summary>
        public void FinalDeJogo()
        {
            if (feiticeira.Vida <= 0)
            {
                controller.ConfereItemBatalha(feiticeira);
                controller.Feiticeira = feiticeira;
                this.Frame.Navigate(typeof(gameOverBatalha), controller);
            }
            else if(Inimigo.Vida <= 0)
            {
                controller.ConfereItemBatalha(feiticeira);

                controller.Feiticeira = feiticeira;
                if (controller.Fase == 1)
                {
                    this.Frame.Navigate(typeof(venceuBatalha1), controller);
                }
                else if (controller.Fase == 2)
                {
                    this.Frame.Navigate(typeof(venceuBatalha2), controller);
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
                acaoInimigo.Text = "Descançou";
            }
            else if (inimigo == 0)
            {
                acaoInimigo.Text = "Usou escudo";
            }
            else if (inimigo == 1)
            {
                acaoInimigo.Text = "Atacou";
            }
            else
            {
                acaoInimigo.Text = "Ataque Especial";
            }

            if (jogadora == -1)
            {
                acaoFeiticeira.Text = "Descançou";
            }
            else if (jogadora == 0)
            {
                acaoFeiticeira.Text = "Usou escudo";
            }
            else if (jogadora == 1)
            {
                acaoFeiticeira.Text = "Atacou";
            }
            else
            {
                acaoFeiticeira.Text = "Ataque Especial";
            }
        }

        /// <summary>
        /// Método associado ao botão de iniciar a batalha.
        /// Exibe os itens que a feitceira levou para a batalha, e o status da feiticeira e do seu inimigo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


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
        /// Método do botão associado ao uso do primeiro Item da List "ItemBatalha" da feiticeira.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsarItem1NaBatalha(object sender, RoutedEventArgs e)
        {
            if(feiticeira.ItemdeBatalha.Count >= 1)
            {
                if (feiticeira.ItemdeBatalha[0].Utilizado == false)
                {
                    Item item = feiticeira.ItemdeBatalha[0] as Item;
                    Controller.UsarItemUtilizavel(feiticeira, feiticeira.ItemdeBatalha[0]);
                    AtualizarStatus();
                    feiticeira.ItemdeBatalha[0].Utilizado = true;
                    Item1_Img.Height = 0;
                    Item1_Img.Width = 0;
                    Item1_Batalha.Height = 0;
                    Item1_Batalha.Width = 0;
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
                    Item2_Img.Height = 0;
                    Item2_Img.Width = 0;
                    Item2_Batalha.Height = 0;
                    Item2_Batalha.Width = 0;
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
            if (controller.ContDefesaInimigo >= 4)
            {
                int acaoInimigo;
                controller.ControleAtaqueEspecialFeiticeira(feiticeira, Inimigo);
                acaoInimigo = ((PersonagemNPC)Inimigo).Acao(feiticeira, controller);
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
