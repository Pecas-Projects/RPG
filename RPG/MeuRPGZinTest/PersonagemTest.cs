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
            p = new SereianosNPC { forca = 20, perdaEstamina = 0.25,
                ganhoEstamnina = 0.15, escudo = 50};
            ini = new Feiticeira {
                forca = 20,
                perdaEstamina = 0.25,
                ganhoEstamnina = 0.15,
                escudo = 50
            } ;
           // p = new Personagem { Vida = 10, Nivel = 1 };            
        }

        [Test]
        public void NumAleatorio()
        {
            p.inteligencia(ini);
            Assert.AreNotEqual(20, p.forca);
            Console.WriteLine(p.forca);
            //  p.Vida = 99;
            // p.GanharVida();
            //Assert.AreEqual(3, p.Nivel);
        }
    }
}