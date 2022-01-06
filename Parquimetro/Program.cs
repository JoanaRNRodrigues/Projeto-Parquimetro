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

          
            double[] coins = { 2.0, 1.0, 0.5, 0.2, 0.1, 0.05, 0.02, 0.01 };     //Tipos de moedas

            string[] MainMenuOptions = { "Administrador", "Cliente", "Sair" };
            string[] ClientMenuOptions = { "Estacionar", "Ver Zonas", "Histórico", "Sair do Estacionamento","Voltar" };
            string[] AdminMenuOptions = { "Ver Zonas", "Histórico", "Ver Máquinas", "Voltar" };

            string ClientMenu = Menu("Cliente", ClientMenuOptions);
            string AdminMenu = Menu("Administrador", AdminMenuOptions);
            string MainMenu = Menu("Bem Vindo", MainMenuOptions);

            int userChoice = 1;    //Dei este valor para o  userChoice não ficar vazio


            //ESTRUTURA DE FUNCIONAMENTO DO PARQUIMTRO/MENUS:

            while (userChoice != MainMenuOptions.Length)
            {
                Console.WriteLine(MainMenu);
                userChoice = int.Parse(Console.ReadLine());

                if (userChoice == 1)
                {
                    while (userChoice != AdminMenuOptions.Length)
                    {
                        Console.WriteLine(AdminMenu);
                        userChoice = int.Parse(Console.ReadLine());
                    }
                    userChoice = 0;         //Damos esta opção para evitar que a opção de saida do Menu seja igual à opção de saida do Programa. 
                }
                else if (userChoice ==2)
                {
                    while (userChoice != ClientMenuOptions.Length)
                    {
                        Console.WriteLine(ClientMenu);
                        userChoice = int.Parse(Console.ReadLine());
                    }
                    userChoice = 0;
                }
               //Continuar o resto dos submenus
            }


          

            
        }

        static string Menu (string title, string[] options )                 //Função que devolve os menus
        {
            string MenuType = "";
            MenuType += " ___________________________________\n" +           // \n é para escrever na linha abaixo/nova linha
                        "|                                   |\n" +
                        $"|------    {title}";                              // O sinal $ serve para adicionar rapidamente um variavel a string

            for (int k = 0; k <= 18-title.Length; k++)                      // Adiciona espaços para alinhar a barra da direita       //Inicio o K em 0 porque escolhi como parametro assumir que o numero de caracteres do titulo começasse em 0.
            {
                MenuType += " ";

            }
            MenuType += "------|\n";
        

            for (int i = 0; i < options.Length; i++)                    // i é o indice das opções
            {
                MenuType += $"|          {i+1}.{options[i]}";           // Imprime o número da opção e o "valor" da opçõo   
                
                for (int j = 0; j <= 22-options[i].Length; j++)         // Adiciona espaços para alinhar a barra da direita       //Inicio o J em 0 porque escolhi como parametro assumir que o numero de caracteres das opções começasse em 0.
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
