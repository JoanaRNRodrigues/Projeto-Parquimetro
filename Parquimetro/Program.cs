using Parquimetro;
using System;

namespace Parquimetro
{
    class Program
    { 
        
        static void Main(string[] args)
        {
            Random rnd = new Random();
            //os lugares de cada zona têm de ser atribuidos aleatoriamente atraves de um metodo.
            Zone Zone1 = new Zone(1 ,1.15, 45, rnd.Next(10, 30));
            Zone Zone2 = new Zone(2, 1.0, 120, rnd.Next(10, 40));
            Zone Zone3 = new Zone(3, 0.62, 0, rnd.Next(10, 50));

            Zone[] Zones = { Zone1, Zone2, Zone3 };
            
            double[] coins = { 2.0, 1.0, 0.5, 0.2, 0.1, 0.05, 0.02, 0.01 };     //Tipos de moedas 

            string[] MainMenuOptions = { "Administrador", "Cliente", "Sair" };
            string[] ClientMenuOptions = { "Estacionar", "Ver Zonas", "Sair do Estacionamento","Voltar" };
            string[] AdminMenuOptions = { "Ver Zonas", "Ver Incumprimentos", "Ver Faturação", "Voltar" };

            string ClientMenu = MyFunctions.Menu("Cliente", ClientMenuOptions);
            string AdminMenu = MyFunctions.Menu("Administrador", AdminMenuOptions);
            string MainMenu = MyFunctions.Menu("Bem Vindo", MainMenuOptions);

            int userChoice = 1;

            if (zoneTime1.isOpen())
            {
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
                            if (userChoice == 1)
                            {
                                Console.WriteLine(Zone1);
                                Console.WriteLine(Zone2);
                                Console.WriteLine(Zone3);
                            }
                            if (userChoice == 2)
                            {
                                MyFunctions.exceedTime(Zones);
                                Console.WriteLine("Terminada a inspeção por carros em incumprimento");
                            }
                            if (userChoice == 3)
                            {
                                Console.WriteLine($"Foram recebidos {MyFunctions.totalGains} euros");
                            }
                        }
                        userChoice = 0;         //Damos esta opção para evitar que a opção de saida do Menu seja igual à opção de saida do Programa. 
                    }
                    else if (userChoice == 2)
                    {
                        while (userChoice != ClientMenuOptions.Length)
                        {
                            Console.WriteLine(ClientMenu);
                            userChoice = int.Parse(Console.ReadLine());

                            if (userChoice == 1)
                            {
                                Console.WriteLine("Insira numero da Zona a Estacionar");
                                int parkChoice = int.Parse(Console.ReadLine());
                                Zone zoneChoice = Zones[parkChoice - 1];
                                if (zoneChoice.vacantSpaces == 0)
                                {
                                    Console.WriteLine("A zona está cheia. Tente outra zona ou vote mais tarde.");
                                }
                                else
                                {
                                    Console.WriteLine(zoneChoice);
                                    Console.WriteLine("Insira o montante em euros:");
                                    double moneyInserted = double.Parse(Console.ReadLine());
                                    int minutesPurchased = (int)MyFunctions.minutesCount(moneyInserted, zoneChoice, coins);
                                    if (minutesPurchased > zoneChoice.TimeLimit && zoneChoice.TimeLimit > 0)
                                    {
                                        double change = minutesPurchased - zoneChoice.MaxChange;
                                        Console.WriteLine($"A máquina devolve {change} euros");
                                        minutesPurchased = zoneChoice.TimeLimit;
                                        moneyInserted -= change;
                                    }
                                    Console.WriteLine($"Estacionamento válido durante {minutesPurchased} minutos");
                                    Console.WriteLine("Pressione 0 para confirmar a operação ou outro número para cancelar");
                                    int confirmation = int.Parse(Console.ReadLine());
                                    if (confirmation == 0)
                                    {
                                        MyFunctions.dayGains(false, moneyInserted, zoneChoice);
                                        zoneChoice.park(minutesPurchased);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"A máquina devolve {moneyInserted}");
                                    }
                                }
                            }
                            else if (userChoice == 2)
                            {
                                Console.WriteLine(Zone1);
                                Console.WriteLine(Zone2);
                                Console.WriteLine(Zone3);
                            }
                            else if (userChoice == 3)
                            {
                                Console.WriteLine("Insira o número do seu Ticket:");
                                int ticketId = int.Parse(Console.ReadLine());
                                int zone = ticketId / 100;
                                Zones[zone - 1].unpark(ticketId);
                                Console.WriteLine("Faça boa viagem!");
                            }
                        }
                        userChoice = 0;
                    }
                }
            }
            else
            {
                Console.WriteLine("Lamentamos mas estamos fechados.");
            }
            
        }
    }
    //Continuar o resto dos submenus

}

    

 
             
