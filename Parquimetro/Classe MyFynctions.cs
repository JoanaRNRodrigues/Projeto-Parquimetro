using System;

namespace Parquimetro
{
    public static class MyFunctions
    {


        public static void giveChange(double change, double[] coins)
        {
            //Esta função pede o valor de troco e imprime as moedas que iriam cair na máquina assim como o total de troco

            Console.WriteLine($"Troco: {change} euros");

            
            
            //A função não corre mais do que uma vez
            if (change > 0 )                                       //se o valor a dar pela máquina for maior do que 0, vai se verificar que moeda devolver.
            { 
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

        }

      

        public static int[] Time()
        {

            DateTime tempoPC = DateTime.Now;

            // dia, ano e mes actual (buscado do computador)

            int day = tempoPC.Day;
            int month = tempoPC.Month;
            int year = tempoPC.Year;


            // horas e minutos

            int horas = tempoPC.Hour;
            int minutos = tempoPC.Minute;
            DateTime dateValue = new DateTime(year, month, day);
            int weekDay = ((int)dateValue.DayOfWeek);

            int[] time = { tempoPC.Hour, tempoPC.Minute, tempoPC.Day, tempoPC.Month, tempoPC.Year, weekDay };

            return time;
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
            int[] currentTime = MyFunctions.Time();
            double minutesParking;
            if (change >= zone.MaxChange & zone.MaxChange > 0)
            {
                minutesParking = zone.TimeLimit;
                MyFunctions.giveChange(change - zone.MaxChange, coins);
                return minutesParking;
            }
            else
            {
                minutesParking = (60 * change) / zone.CostPerHour;  //tornar função universal com array que recebe preço e maxchange
                return minutesParking;
            }
        }





        public static void zoneTime(double change, Zone zone, double[] coins)
        {
            double parkingMinutes = minutesCount(change, zone, coins);
            int[] currentTime = MyFunctions.Time();

            int currentHour = currentTime[0];
            int currentMinute = currentTime[1];

            int exitMinute = (int)Math.Round(parkingMinutes) + currentMinute;
            int exitHour = currentHour;

            int exitDay = currentTime[2];
            int weekDay = currentTime[5];
            int exitMonth = currentTime[3];

            if (exitMinute >= 60)
            {
                int hours = exitMinute / 60;
                exitHour = currentHour + hours;
                exitMinute -= 60 * hours;
            }


            if (exitHour >= 20 & currentTime[5] <= 5 || exitHour >= 14 & currentTime[5] == 6)
            {
                if (zone.id < 2)
                {
                    Console.WriteLine("20h00 " + exitDay + "/" + exitMonth + "/" + currentTime[4]); // adaptar ao menu ou alterar o retorno para array
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
                Console.WriteLine("" + exitHour + "h" + exitMinute + " " + exitDay + "/" + exitMonth + "/" + currentTime[4]);
            }
            if (zone.id == 2)
            {
                int[] daysMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                while (exitDay > daysMonth[exitMonth])
                {
                    exitDay -= daysMonth[exitMonth];
                    exitMonth += 1;

                }
                Console.WriteLine("" + exitHour + "h" + exitMinute + " " + exitDay + "/" + exitMonth + "/" + currentTime[4]); // adaptar ao menu ou alterar o retorno para array
            }


        }

    }
}
