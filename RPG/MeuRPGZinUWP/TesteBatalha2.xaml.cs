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
    public sealed partial class TesteBatalha2 : Page
    {
        public Feiticeira p = new Feiticeira();
        //public Personagem inimigoTroll;
        public SereianosNPC s = new SereianosNPC();
        public ControllerBatalha Controller = new ControllerBatalha();

        public TesteBatalha2()
        {
            this.InitializeComponent();
        }

       /* protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            inimigoTroll = e.Parameter as Personagem;
           ((PersonagemNPC)inimigoTroll).Inteligencia(p);
        }*/

        public void AtualizarStatus()
        {
            feiticeiraVida.Text = "Vida: " + p.Vida;
            feiticeiraEscudo.Text = "Escudo: " + p.Escudo;
            feiticeiraEstamina.Text = "Estamina: " + p.Estamina;

            sereianoVida.Text = "Vida: " + s.Vida;
            sereianoEscudo.Text = "Escudo: " + s.Escudo;
            sereianoEstamina.Text = "Estamina: " + s.Estamina;
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
            if(p != null && s != null)
            {
                AtualizarStatus();
            }
        }

        private void Ataque(object sender, RoutedEventArgs e)
        {
            int acaoInimigo;
            acaoInimigo = s.Inteligencia(p);
            p.atacar(s);
            Controller.FimDeTurno(p, s, 1, acaoInimigo);
            RegistraAcoes(1, acaoInimigo);
            AtualizarStatus();
        }

        private void usarEscudoBrabo(object sender, RoutedEventArgs e)
        {
            int acaoInimigo;
            p.usarEscudo();
            acaoInimigo = s.Inteligencia(p);
            Controller.FimDeTurno(p, s, 0, acaoInimigo);
            RegistraAcoes(0, acaoInimigo);
            AtualizarStatus();
        }

        private void DescancarTroll(object sender, RoutedEventArgs e)
        {
            int acaoInimigo;
            acaoInimigo = s.Inteligencia(p);
            p.descansar();
            Controller.FimDeTurno(p, s, -1, acaoInimigo);
            RegistraAcoes(-1, acaoInimigo);
            AtualizarStatus();

        }
    }
}
