using System;
using System.IO;
using GeneradorContraseña.Entiti;
namespace TestContraseña
{
    class Program
    {
        static void Main(string[] args)
        {
            for(; ; )
            {
                Console.WriteLine(Contraseña.GetRandom(3,25));
                Console.ReadLine();
            }
        }
    }
}
