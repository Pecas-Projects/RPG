using MeuRPGZinCore;
using NUnit.Framework;
using System;

namespace MeuRPGZinTest
{
    public class Tests
    {
        Personagem Atacante;
        Personagem Inimigo;

        [SetUp]
        public void Setup()
        {
            Atacante = new Feiticeira { Forca = 20, PerdaEstamina = 0.2, GanhoEstamnina = 0.1, Escudo = 50};
            Inimigo = new Feiticeira { Forca = 20, PerdaEstamina = 0.2, GanhoEstamnina = 0.1, Escudo = 50 };        
        }

        [Test]
        public void Ataque_SemEscudoAtivo()
        {
            Atacante.atacar(Inimigo);
            Assert.AreEqual(Inimigo.Vida == 80, Atacante.Estamina == 0.8);
            
        }

        [Test]
        public void Ataque_EscudoAtivoEDanoNegativo() 
        { 
            Inimigo.usarEscudo();
            Atacante.atacar(Inimigo);
            Assert.AreEqual(Inimigo.Escudo == 43, Atacante.Estamina == 0.8);
        }

        [Test]
        public void Ataque_EscudoAtivoEDanoPositivo()
        {
            Inimigo.usarEscudo();
            Inimigo.Escudo = 15;
            Assert.AreEqual(Inimigo.Vida == 95, Inimigo.Escudo == 45);
        }
    }
}