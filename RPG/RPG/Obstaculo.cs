using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace RPG
{
    public class ObstaculoEventArgs : EventArgs
    {
        //public String adress { get; set; }
        public Image img;
    }
    public abstract class Obstaculo
    {
        public delegate void ObstaculoCriadoEventHandler(object sender, ObstaculoEventArgs e);

        public event ObstaculoCriadoEventHandler ObstaculoAparece;

        public double dano
        {
            get
            {
                return dano;
            }
            set
            {
                dano = value;
            }
        }


        public double velocidade { get; set; }

        /// <summary>
        /// Esse método vai calcular o dano que o objeto causa no personagem
        /// quando for um objeto nocivo, o dano será de 100%, logo o personagem morrerá
        /// </summary>
        public abstract void danoCausado(Personagem persona);
    }
}
