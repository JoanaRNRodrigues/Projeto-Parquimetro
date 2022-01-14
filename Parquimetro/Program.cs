using Parquimetro;
using System;

namespace Parquimetro
{
    class Program
    {

        static void Main(string[] args)
        {
            Random rnd = new Random();
            
            //Instanciamento das Zonas
            //os lugares de cada zona têm de ser atribuidos aleatoriamente atraves de um metodo.
            Zone Zone1 = new Zone(1, 1.15, 45, rnd.Next(10, 30));
            Zone Zone2 = new Zone(2, 1.0, 120, rnd.Next(10, 40));
            Zone Zone3 = new Zone(3, 0.62, 0, rnd.Next(10, 50));

            Zone[] Zones = { Zone1, Zone2, Zone3 };

            double[] coins = { 2.0, 1.0, 0.5, 0.2, 0.1, 0.05, 0.02, 0.01 };     //Tipos de moedas 
            
            //Opções de cada Menu
            string[] MainMenuOptions = { "Administrador", "Cliente", "Sair" };
            string[] ClientMenuOptions = { "Estacionar", "Ver Zonas", "Sair do Estacionamento", "Voltar" };
            string[] AdminMenuOptions = { "Ver Zonas", "Ver Incumprimentos", "Ver Faturação", "Alterar Zonas","Voltar" };

            //Criação dos Menus
            string ClientMenu = MyFunctions.Menu("Cliente", ClientMenuOptions);
            string AdminMenu = MyFunctions.Menu("Administrador", AdminMenuOptions);
            string MainMenu = MyFunctions.Menu("Bem Vindo", MainMenuOptions);

            int userChoice = 1;

            if (zoneTime1.isOpen())                     // Só acedemos aos Menus durante o horário de funcionamento
            {
                while (userChoice != MainMenuOptions.Length)
                {
                    Console.WriteLine(MainMenu);
                    userChoice = int.Parse(Console.ReadLine());

                    if (userChoice == 1)            //Aceder ao Menu Administrador
                    {
                        while (userChoice != AdminMenuOptions.Length)       //Enquanto o utilizador não escolher voltar, permite a escolhe das opções
                        {
                            Console.WriteLine(AdminMenu);       //Apresenta o Menu Administrador
                            userChoice = int.Parse(Console.ReadLine());     //Permite a escolha entre as diferentes opções do Menu Administrador
                            if (userChoice == 1)                //Selecionar Ver as Zonas
                            {   //Mostra os dados das zonas     
                                Console.WriteLine(Zone1);
                                Console.WriteLine(Zone2);
                                Console.WriteLine(Zone3);
                            }
                            if (userChoice == 2)            //Selecionar Ver Incumprimentos
                            {
                                MyFunctions.exceedTime(Zones);      //Mostra os dados dos incumprimentos
                                Console.WriteLine("Terminada a inspeção por carros em incumprimento");
                            }
                            if (userChoice == 3)        //Seleccionar Ver Faturação
                            {
                                Console.WriteLine($"Foram recebidos {MyFunctions.TotalGains} euros");       //Mostra os dados da faturação
                            }
                            if (userChoice == 4)
                            {
                                Console.WriteLine("Insira o numero da zona a alterar: ");
                                int zone = int.Parse(Console.ReadLine());
                                Zone zoneChoice = Zones[zone - 1];
                                Console.WriteLine("Prima 0 para alterar o custo por hora e qualquer outro número para alterar o tempo máximo: ");
                                userChoice = int.Parse(Console.ReadLine());
                                if (userChoice == 0)
                                {
                                    Console.WriteLine($"O custo por hora atual da zona {zone} é: {zoneChoice.CostPerHour} euros. Insira o novo valor: ");
                                    zoneChoice.CostPerHour = double.Parse(Console.ReadLine());
                                    Console.WriteLine($"O custo por hora da zona {zone} é agora {zoneChoice.CostPerHour}");
                                }
                                else
                                {
                                    Console.WriteLine($"O tempo limite atual da zona {zone} é: {zoneChoice.TimeLimit} minutos. Insira o novo valor: ");
                                    zoneChoice.TimeLimit = int.Parse(Console.ReadLine());
                                    Console.WriteLine($"O tempo limite da zona {zone} é agora {zoneChoice.TimeLimit} minutos.");
                                }

                            }
                        }
                        userChoice = 0;         //Foi dada esta atribuição para evitar que a opção de saida do Menu fosse igual à opção de saida do Programa. 
                    }
                    else if (userChoice == 2)   //Aceder ao Menu Cliente
                    {
                        while (userChoice != ClientMenuOptions.Length)      //Enquanto o utilizador não escolher voltar, permite a escolhe dos opções
                        {
                            Console.WriteLine(ClientMenu);          //Apresenta o Menu Cliente
                            userChoice = int.Parse(Console.ReadLine());         //Permite a escolha entre as diferentes opções do Menu Cliente

                            if (userChoice == 1)        //Seleccionar Estacionar
                            {
                                Console.WriteLine("Insira numero da Zona a Estacionar");
                                int parkChoice = int.Parse(Console.ReadLine());     //Permite a seleção das zonas
                                Zone zoneChoice = Zones[parkChoice - 1];
                                if (zoneChoice.VacantSpaces == 0)           //Se não houver lugares disponiveis imprime a mensagem
                                {
                                    Console.WriteLine("A zona está cheia. Tente outra zona ou vote mais tarde.");
                                }
                                else        //Se houver lugares disponiveis calcula o custo
                                {
                                    Console.WriteLine(zoneChoice);
                                    Console.WriteLine("Insira o montante em euros:");
                                    double moneyInserted = MyFunctions.receivePayment(coins);       //Permite pagamento do custo
                                    int minutesPurchased = (int)MyFunctions.minutesCount(moneyInserted, zoneChoice, coins);

                                    Console.WriteLine($"Estacionamento válido durante {minutesPurchased} minutos");
                                    Console.WriteLine("Pressione 0 para confirmar a operação ou outro número para cancelar");
                                    int confirmation = int.Parse(Console.ReadLine());
                                    if (confirmation == 0)
                                    {//Se o utilizador confirmar a operação, adiciona o valor inserido e estaciona o carro.
                                        if (minutesPurchased > zoneChoice.TimeLimit && zoneChoice.TimeLimit > 0)
                                        {//Calcula o custo de acordo com o valor inserido e o tempo maximo de estacionamento permitido em cada zona
                                            double change = moneyInserted - zoneChoice.MaxChange;
                                            MyFunctions.giveChange(change, coins);      //Calcula o troco a receber
                                            minutesPurchased = zoneChoice.TimeLimit;
                                            moneyInserted -= change;
                                        }
                                        MyFunctions.dayGains(moneyInserted, zoneChoice);
                                        zoneChoice.park(minutesPurchased);
                                    }
                                    else
                                    {//Se o utilizador recusar a operção devolve o valor inserido
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
                            else if (userChoice == 3)       //selecionar Sair do Estacionamento
                            {
                                Console.WriteLine("Insira o número do seu Ticket:");
                                int ticketId = int.Parse(Console.ReadLine());           //Utilizador insere o numero de ID
                                int zone = ticketId / 100;                          //A zona é o numero das centenas do ID
                                Zones[zone - 1].unpark(ticketId);               //Carro é retirado do estacionamento
                                Console.WriteLine("Faça boa viagem!");
                            }
                        }
                        userChoice = 0;
                    }
                }
            }
            else     //Se estiver for do horário de funcionamento ou durante o domingo, imprime a mensagem
            {
                Console.WriteLine("Lamentamos mas estamos fechados.");
                Console.ReadLine();
            }

        }
    }
    

}
    

 
             
