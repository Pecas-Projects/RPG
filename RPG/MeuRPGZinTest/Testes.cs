using MeuRPGZinCore;
using NUnit.Framework;
using System;

namespace MeuRPGZinTest
{
    public class Tests
    {
        Personagem Atacante;
        Personagem Inimigo;
        Feiticeira User;
        PocaoWhey Whey;
        PocaoVitae Vitae;
        PocaoRadix Radix;
        PocaoFortalecedora Fortalecedora;
        Pirlimpimpim Pirlimpimpim;

        [SetUp]
        public void Setup()
        {
            //Para testes de Ataque e uso de Escudo
            Atacante = new Feiticeira { Forca = 20, PerdaEstamina = 0.2, GanhoEstamnina = 0.1, Escudo = 50};
            Inimigo = new Feiticeira { Forca = 20, PerdaEstamina = 0.2, GanhoEstamnina = 0.1, Escudo = 50 };

            //Para teste de Itens
            User = new Feiticeira { Forca=10, PerdaEstamina = 0.1, GanhoEstamnina=0.1, Escudo = 10 };
            Whey = new PocaoWhey();
            Vitae = new PocaoVitae();
            Radix = new PocaoRadix();
            Fortalecedora = new PocaoFortalecedora();
            Pirlimpimpim = new Pirlimpimpim();
        }

        [Test]
        public void Ataque_SemEscudoAtivo()
        {
            Atacante.atacar(Inimigo);
            Assert.AreEqual(0.8, Atacante.Estamina);
            Assert.AreEqual(80, Inimigo.Vida);
            
        }

        [Test]
        public void Ataque_EscudoAtivoEDanoNegativo() 
        { 
            Inimigo.usarEscudo();
            Atacante.atacar(Inimigo);
            Assert.AreEqual(43, Inimigo.Escudo);
            Assert.AreEqual(0.8, Atacante.Estamina);
        }

        [Test]
        public void Ataque_EscudoAtivoEDanoPositivo()
        {
            Inimigo.usarEscudo();
            Inimigo.Escudo = 15;
            Atacante.atacar(Inimigo);
            
            Assert.AreEqual(95, Inimigo.Vida);
            Assert.AreEqual(10, Inimigo.Escudo);
            Assert.AreEqual(0.8, Atacante.Estamina);
        }

        [Test]
        public void UsarItem_PocaoWhey_EstaminaMenorQue1()
        {
            User.mochila.AddItem((Item)Whey, User.mochila.bagWhey);
            User.Estamina = 0.7;
            Whey.Utilizar(User);
            Assert.AreEqual(1, User.Estamina);
        }
        [Test]
        public void UsarItem_PocaoWhey_EstaminaMaiorQue1()
        {
            User.mochila.AddItem((Item)Whey, User.mochila.bagWhey);
            User.Estamina = 0.9;
            Whey.Utilizar(User);
            Assert.AreEqual(1, User.Estamina);
        }

        [Test]
        public void UsarItem_PocaoVitae_VidaMenorQue1()
        {
            User.mochila.AddItem((Item)Vitae, User.mochila.bagVitae);
            User.Vida = 50;
            Vitae.Utilizar(User);
            Assert.AreEqual(80, User.Vida);
        }

        [Test]
        public void UsarItem_PocaoVitae_VidaMaiorQue1()
        {
            User.mochila.AddItem((Item)Vitae, User.mochila.bagVitae);
            User.Vida = 80;
            Vitae.Utilizar(User);
            Assert.AreEqual(100, User.Vida);
        }

        [Test]
        public void UsarItem_PocaoRadix()
        {
            User.mochila.AddItem((Item)Radix, User.mochila.bagRadix);
            Radix.Utilizar(User);
            Assert.AreEqual(12, User.Forca);
        }

        [Test]
        public void UsarItem_PocaoFortalecedora()
        {
            User.mochila.AddItem((Item)Fortalecedora, User.mochila.bagFortalecedora);
            Fortalecedora.Utilizar(User);
            Assert.AreEqual(11.5, User.Forca);
        }

        [Test]
        public void UsarItem_PoPirlimpimpim()
        {
            User.mochila.AddItem((Item)Pirlimpimpim, User.mochila.bagPirlimpimpim);
            Pirlimpimpim.Utilizar(User);
            Assert.AreEqual(1.44, User.magia);
        }

    }
}