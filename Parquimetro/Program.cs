using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace Parquimetro
{
    class Program
    { 
        
        static void Main(string[] args)
        {
            Zone Zone1 = new Zone(1 ,1.15, 45, 35);
            Zone Zone2 = new Zone(2, 1.15, 45, 35);
            Zone Zone3 = new Zone(3, 1.15, 45, 35);

            int[] stockCoins = { 5, 2, 500, 500, 500, 500, 500, 500 };
            double[] coins = { 2.0, 1.0, 0.5, 0.2, 0.1, 0.05, 0.02, 0.01 };     //Tipos de moedas 

            string[] MainMenuOptions = { "Administrador", "Cliente", "Sair" };
            string[] ClientMenuOptions = { "Estacionar", "Ver Zonas", "Histórico", "Sair do Estacionamento","Voltar" };
            string[] AdminMenuOptions = { "Ver Zonas", "Histórico", "Ver Máquinas", "Voltar" };

            string ClientMenu = MyFunctions.Menu("Cliente", ClientMenuOptions);
            string AdminMenu = MyFunctions.Menu("Administrador", AdminMenuOptions);
            string MainMenu = MyFunctions.Menu("Bem Vindo", MainMenuOptions);

            int userChoice = 1;    //Dei este valor para o  userChoice não ficar vazio



            MyFunctions.giveChange(3.88, coins, stockCoins);




            //ESTRUTURA DE FUNCIONAMENTO DO PARQUIMTRO/MENUS:

            //bool abeto ou fechado

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

          



        



    }
}
        */