using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace RPG
{
    public class LocalEventArgs : EventArgs
    {
        /*public String adress { get; set; }
        public Image img;*/
    }
    public class Local
    {
        public delegate void LocalCriadoEventHandler(object sender, LocalEventArgs e);

        public event LocalCriadoEventHandler LocalCriado;
        public int atrito { get; set; }
        public String nome { get; set; }

        public Image img;
        public Local(string name, int atrito, string address)
        {
            this.nome = name;
            this.atrito = atrito;
            this.img.Source = new BitmapImage(new Uri(address));
        }
    }
}
