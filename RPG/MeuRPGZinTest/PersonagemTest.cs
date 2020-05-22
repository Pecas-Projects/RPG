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
            Atacante = new Feiticeira { Forca = 10, PerdaEstamina = 0.2, GanhoEstamnina = 0.1, Escudo = 50};
            Inimigo = new Feiticeira { Forca = 10, PerdaEstamina = 0.2, GanhoEstamnina = 0.1, Escudo = 50 };
            /* p = new SereianosNPC { Forca = 20, PerdaEstamina = 0.25,
                 GanhoEstamnina = 0.15, Escudo = 50};
             ini = new Feiticeira {
                 Forca = 20,
                 PerdaEstamina = 0.25,
                 GanhoEstamnina = 0.15,
                 Escudo = 50
             } ;*/
            // p = new Personagem { Vida = 10, Nivel = 1 };            
        }

        [Test]
        public void Ataque_SemEscudoAtivo()
        {
            Atacante.atacar(Inimigo);
            Assert.AreEqual(Inimigo.Vida == 90, Atacante.Estamina == 0.8);
            
        }
    }
}