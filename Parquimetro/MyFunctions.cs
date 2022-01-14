using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parquimetro
{
    public static class MyFunctions
    {
        public static int id;
        public static bool needChange;
        public static double totalGains;
        public static void giveChange(double change, double[] coins)
        {
            //Esta função pede o valor do troco e imprime as moedas que iriam cair na máquina assim como o total de troco

            Console.WriteLine($"Troco: {change} euros");
                        
            for (int i = 0; i < coins.Length; i++)                //O i é o indice do array das coins
            { 
                while (change >= coins[i])
                {
                    Console.WriteLine($"O Parquímetro devolve {coins[i]} euros");         //Imprime o valor de troco a dar ao utilizador
                    change -= coins[i];                                                   //O valor a dar de troco é deduzido.
                    change = Math.Round(change, 2);                                       //Arredonda o troco a duas casas decimais para evitar erro por arrendondamento
                        
                }
            }

        }
        
        public static string Menu(string title, string[] options)                 //Função que constroi o aspeto dos Menus
        {
            string MenuType = "";
            MenuType += " ___________________________________\n" +           
                        "|                                   |\n" +
                        $"|------    {title}";                             
            //Função que controla o espaçamento no aspeto dos Menus para o sector do Titulo
            for (int k = 0; k <= 18 - title.Length; k++)                      //Iniciou-se o K em 0 pois assumiu-se que o numero de caracteres do titulo começasse em 0.
            {
                MenuType += " ";

            }
            MenuType += "------|\n";

            //Função que controla o espaçamento no aspeto dos Menus para o sector das Opções
            for (int i = 0; i < options.Length; i++)                    //O i é o indice das opções
            {
                MenuType += $"|          {i + 1}.{options[i]}";           // Imprime o número da opção e respetivo "valor"   

                for (int j = 0; j <= 22 - options[i].Length; j++)          //Iniciou-se o J em 0 pois assumiu-se que o numero de caracteres das opções começasse em 0.
                {
                    MenuType += " ";
                }
                MenuType += "|\n";
            }


            MenuType += "|                                   |\n" +
                        "|___________________________________|";

            return MenuType;
        }

        public static double minutesCount(double change, Zone zone, double[] coins)
        {
            Time currentTime = new Time();
            double minutesParking;
            if (change >= zone.MaxChange & zone.MaxChange > 0)
            {
                minutesParking = zone.TimeLimit;
                MyFunctions.giveChange(change - zone.MaxChange, coins);
                needChange = true;
                return minutesParking;
            }
            else
            {
                minutesParking = (60 * change) / zone.CostPerHour;  
                return minutesParking;
            }
        }

        public static int[] zoneTime(double change, Zone zone, double[] coins)
        {
            double parkingMinutes = minutesCount(change, zone, coins);
            Time currentTime = new Time();
            int exitMinute = (int)Math.Round(parkingMinutes) + currentTime.Minute;
            int exitHour = currentTime.Hour;
            int weekDay = currentTime.DayOfWeek;
            int exitDay = currentTime.Day;
            int exitMonth = currentTime.Month;
            if (exitMinute >= 60)
            {
                int hours = exitMinute / 60;
                exitHour = currentTime.Hour + hours;
                exitMinute -= 60 * hours;
            }


            if (exitHour >= 20 & currentTime.DayOfWeek <= 5 || exitHour >= 14 & currentTime.DayOfWeek == 6)
            {
                if (zone.id < 2)
                {
                    Console.WriteLine("20h00 " + exitDay + "/" + exitMonth + "/" + currentTime.Year); 
                }
                else
                {
                    int excessHours = exitHour - 20;
                    if (excessHours == 0)
                    {
                        exitHour = 9;
                    }
                    exitDay++;
                    weekDay++;

                    while (excessHours > 0)
                    {
                        while (weekDay <= 5)
                        {
                            if (excessHours >= 11)
                            {
                                excessHours -= 11;
                                weekDay++;
                                exitDay++;
                            }
                            else
                            {
                                exitHour = 9 + excessHours;
                                excessHours = 0;
                                break;
                            }

                        }
                        if (weekDay == 6 & excessHours > 0)
                        {
                            if (excessHours >= 5)
                            {
                                excessHours -= 5;
                                exitDay += 2;
                                weekDay = 1;
                            }
                            else
                            {
                                exitHour = 9 + excessHours;
                                excessHours = 0;
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("" + exitHour + "h" + exitMinute + " " + exitDay + "/" + exitMonth + "/" + currentTime.Year);
            }
            if (zone.id == 2)
            {
                int[] daysMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                while (exitDay > daysMonth[exitMonth])
                {
                    exitDay -= daysMonth[exitMonth];
                    exitMonth += 1;

                }
                Console.WriteLine("" + exitHour + "h" + exitMinute + " " + exitDay + "/" + exitMonth + "/" + currentTime.Year); 
            }
            int[] exitTime = { currentTime.Year, exitMonth, exitDay, exitHour, exitMinute, 0 };

            return exitTime;
        }

        public static void dayGains(bool needChange,double change, Zone zone)
        {
            if (needChange == false)
            {
                totalGains += change;
            }
            else
            {
                totalGains += (change - zone.MaxChange);
            }
        }

        public static void exceedTime(Zone[] zones) //se for administrador
        {
            Time now = new Time();
            foreach (Zone zone in zones)
            {
                for (int i = 0; i < zone.Spaces.Length; i++)
                {
                    Car car = zone.Spaces[i];
                    if (car != null)
                    {
                        if (car.parked == true && (car.time.Hour < now.Hour || (car.time.Hour == now.Hour && car.time.Minute < now.Minute)))
                        {
                            Console.WriteLine($"O carro no lugar {i} da zona {zone.id} está a exceder o estacionamento");
                        }
                    }
                }
            }

        }


        public static double receivePayment (double[] coins)   //Função para selecionar as moedas
        {
            double insertedMoney = 0;
            string[] coinsOptions = { "2 euros", "1 euro", "50 centimos", "20 centimos", "10 centimos", "5 centimos", "2 centimos", "1 centimo", "confirmar"};
            string Payment = Menu("Pagamento", coinsOptions);
            Console.WriteLine(Payment);
            int moneySelected = int.Parse(Console.ReadLine());
            while (moneySelected != coinsOptions.Length)
            {
                insertedMoney = insertedMoney + coins[moneySelected - 1];
                Console.WriteLine($"Montante atual: {insertedMoney}");
                moneySelected = int.Parse(Console.ReadLine());
                
            }

            return insertedMoney;
        }





    }

}
