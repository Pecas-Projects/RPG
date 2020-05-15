using MeuRPGZinCore;
using NUnit.Framework;
using System;

namespace MeuRPGZinTest
{
    public class Tests
    {
        SereianosNPC p;
        Feiticeira ini;

        [SetUp]
        public void Setup()
        {
            p = new SereianosNPC { Forca = 20, PerdaEstamina = 0.25,
                GanhoEstamnina = 0.15, Escudo = 50};
            ini = new Feiticeira {
                Forca = 20,
                PerdaEstamina = 0.25,
                GanhoEstamnina = 0.15,
                Escudo = 50
            } ;
           // p = new Personagem { Vida = 10, Nivel = 1 };            
        }

        [Test]
        public void NumAleatorio()
        {
            p.inteligencia(ini);
            Assert.AreNotEqual(20, p.Forca);
            Console.WriteLine(p.Forca);
            //  p.Vida = 99;
            // p.GanharVida();
            //Assert.AreEqual(3, p.Nivel);
        }
    }
}