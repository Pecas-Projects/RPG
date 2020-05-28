using MeuRPGZinCore;
using NUnit.Framework;
using System;

namespace MeuRPGZinTest
{
    public class Tests
    {
        Personagem Atacante;
        Personagem Inimigo;
        Personagem User;
        PocaoWhey Whey;

        [SetUp]
        public void Setup()
        {
            //Para testes de Ataque e uso de Escudo
            Atacante = new Feiticeira { Forca = 20, PerdaEstamina = 0.2, GanhoEstamnina = 0.1, Escudo = 50};
            Inimigo = new Feiticeira { Forca = 20, PerdaEstamina = 0.2, GanhoEstamnina = 0.1, Escudo = 50 };

            //Para teste de Itens
            User = new Feiticeira { Forca=10, PerdaEstamina = 0.1, GanhoEstamnina=0.1, Escudo = 10 };
            Whey = new PocaoWhey();
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
           // Inimigo.Vida = 100;
            Inimigo.Escudo = 15;
            Assert.AreEqual(95, Inimigo.Vida);
            Assert.AreEqual(10, Inimigo.Escudo);
            Assert.AreEqual(0.8, Atacante.Estamina);
        }


    }
}