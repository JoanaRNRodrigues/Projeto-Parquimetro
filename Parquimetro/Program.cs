using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parquimetro
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine(Menu("Bem vindo", "Administrador", "Cliente", "Voltar"));
            Console.ReadKey();

          
        }

        static string Menu (string title, string opt1, string opt2, string opt3)
        {
            return $"___________________________________________________________________________________\n" +
                   $"|                                                                                  |\n" +
                   $"|--------         {title}                                                  --------|\n" +
                   $"1. {opt1}\n" +
                   $"2. {opt2}\n" +
                   $"3. {opt3}\n";
        }







    }
}
