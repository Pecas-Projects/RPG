using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TesteThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(() => Tarefa1(), () => Tarefa2());
            Console.WriteLine("Precione uma tecla para continuar....");
            Console.ReadKey();
        }

        public static void Tarefa1()
        {
            Console.WriteLine("T1 INI");
            Thread.Sleep(3000);
            Console.WriteLine("T1 FIM");
        }

        public static void Tarefa2()
        {
            Console.WriteLine("T2 INI");
            Thread.Sleep(1000);
            Console.WriteLine("T2 FIM");
        }
    }
}
