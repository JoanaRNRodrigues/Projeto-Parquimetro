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
            //Esta função pede o valor de troco e imprime as moedas que iriam cair na máquina assim como o total de troco

            Console.WriteLine($"Troco: {change} euros");

            //Alterado para ter em consideração o stock
            //Dei um stock bastante elevado para diminuir o risco de ficar a zero
            //A função não corre mais do que uma vez
            for (int i = 0; i < coins.Length; i++)                // i é o indice do array das coins
            { 
                while (change >= coins[i])
                {
                    Console.WriteLine($"O Parquímetro devolve {coins[i]} euros");         //Imprime o valor de troco a dar ao utilizador
                    change -= coins[i];                                                   //O valor a dar de troco é deduzido.
                    change = Math.Round(change, 2);                                       //Arredonda o troco a duas casas decimais para evitar erro por arrendondamento
                        
                }
            }

        }
        public static string Menu(string title, string[] options)                 //Função que devolve os menus
        {
            string MenuType = "";
            MenuType += " ___________________________________\n" +           // \n é para escrever na linha abaixo/nova linha
                        "|                                   |\n" +
                        $"|------    {title}";                              // O sinal $ serve para adicionar rapidamente um variavel a string

            for (int k = 0; k <= 18 - title.Length; k++)                      // Adiciona espaços para alinhar a barra da direita       //Inicio o K em 0 porque escolhi como parametro assumir que o numero de caracteres do titulo começasse em 0.
            {
                MenuType += " ";

            }
            MenuType += "------|\n";


            for (int i = 0; i < options.Length; i++)                    // i é o indice das opções
            {
                MenuType += $"|          {i + 1}.{options[i]}";           // Imprime o número da opção e o "valor" da opçõo   

                for (int j = 0; j <= 22 - options[i].Length; j++)         // Adiciona espaços para alinhar a barra da direita       //Inicio o J em 0 porque escolhi como parametro assumir que o numero de caracteres das opções começasse em 0.
                {
                    MenuType += " ";
                }
                MenuType += "|\n";
            }


            MenuType += "|                                   |\n" +
                        "|___________________________________|\n";

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
                minutesParking = (60 * change) / zone.CostPerHour;  //tornar função universal com array que recebe preço e maxchange
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
                    Console.WriteLine("20h00 " + exitDay + "/" + exitMonth + "/" + currentTime.Year); // adaptar ao menu ou alterar o retorno para array
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
                Console.WriteLine("" + exitHour + "h" + exitMinute + " " + exitDay + "/" + exitMonth + "/" + currentTime.Year); // adaptar ao menu ou alterar o retorno para array
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
        

    }
}
