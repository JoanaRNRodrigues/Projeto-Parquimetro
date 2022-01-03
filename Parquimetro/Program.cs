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


            //Console.WriteLine(Menu("Bem vindo", "Administrador", "Cliente", "Voltar"));
            //Console.ReadKey();
            string[] MainMenu = {"Administrador", "Cliente", "Op��es", "voltar"};
            string[] MenuTitle = {"Bem Vindo", "Administrador", "Cliente"};
            Console.WriteLine(Menu ("Bem Vindo", MainMenu));
            Console.ReadLine();
          
        }

        static string Menu (string title, string[] options )        //fun��o que devolve os menus
        {
            string MenuType = "";
            MenuType += " ___________________________________\n" +           // \n � para escrever na linha abaixo/nova linha
                        "|                                   |\n" +
                        $"|------    {title}";                          // O sinal $ serve para adicionar rapidamente um variavel � string

            for (int k = 0; k <= 18-title.Length; k++)                  // adiona espa�os para alinhar a barra da direita       // dei valor 0 porque escolhi como parametro assumir que o numero de caracteres do "valor" da op��o fosse 0.
            {
                MenuType += " ";

            }
            MenuType += "------|\n";
        

            for (int i = 0; i < options.Length; i++)                    // i � o indice das op��es
            {
                MenuType += $"|          {i+1}.{options[i]}";    // imprime o n�mero da op��o e o "valor" da op��o   
                
                for (int j = 0; j <= 22-options[i].Length; j++)         // adiona espa�os para alinhar a barra da direita       // dei valor 0 porque escolhi como parametro assumir que o numero de caracteres do "valor" da op��o fosse 0.
                {
                MenuType += " ";
                }
                MenuType += "|\n"; 
            }


             MenuType += "|                                   |\n" +
                         "|___________________________________|\n";

            return MenuType;
        }   



        



    }
}
