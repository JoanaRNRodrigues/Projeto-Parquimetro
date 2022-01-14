using System;
namespace Parquimetro
{

    public static class zoneTime1
    {

        public static Time calculateExitTime(int parkingMinutes, Zone zone)
        // calculateExitTime tem como parametros os minutos de estacionamento comprados pelo utiizador assim como a zona onde vai acontecer o estacionamento 
        // retorna um objeto do tipo tempo correspondente à hora de saída limite para o estacionamento
        {
            Time currentTime = new Time();

            int currentHour = currentTime.Hour;                     // variáveis de tempo atual e tempo de saída
            int currentMinute = currentTime.Minute;
            int exitMinute = parkingMinutes + currentMinute;
            int exitHour = currentHour;
            int exitDay = currentTime.Day;
            int weekDay = currentTime.DayOfWeek;
            int exitMonth = currentTime.Month;
            Console.WriteLine(weekDay);
            if (exitMinute >= 60)                                   // acerta os minutos e horas de forma a evitar tempos em que existem mais de 60 minutos, por exemplo corrigir 14h90 para 15h30 
            {
                int hours = exitMinute / 60;                        //estabelece a hora de saída do estacionamento
                exitHour = currentHour + hours;
                exitMinute -= 60 * hours;
            }


            if (exitHour >= 20 && currentTime.DayOfWeek <= 5 || exitHour >= 14 && currentTime.DayOfWeek == 6)
            {

                if (zone.ID < 2)                                    // caso a hora de saída seja superior às 20h nos dias de semana e 14h no sábado e o estacionamento seja na zona 1 ou 2:
                {                                                   // o tempo em excesso é calculadas, e o dinheiro desse tempo é devolvido ao utilizador, para que a hora de saída seja
                    int excessHours;                                // 20h00 nos dias da semana ou 14h00 nos sábados
                    if (currentTime.DayOfWeek <= 5)
                    {
                        excessHours = exitHour - 20;
                    }
                    else
                    {
                        excessHours = exitHour - 14;
                    }
                    int excessMinutes;
                    double[] coins = { 2.0, 1.0, 0.5, 0.2, 0.1, 0.05, 0.02, 0.01 };

                    if (excessHours == 0)
                    {
                        excessMinutes = exitMinute;
                    }
                    else
                    {
                        excessMinutes = excessHours * 60 + exitMinute;
                    }
                    exitHour = 20;
                    exitMinute = 0;
                    double change = excessMinutes * (zone.CostPerHour / 60);
                    MyFunctions.giveChange(change, coins);
                }
                else
                {                                                   // caso a hora de saída seja superior às 20h nos dias de semana e 14h no sábado e o estacionamento seja na zona 3:
                    int excessHours;                                // as horas em excesso são calculadas e levadas para o dia seguinte
                    if (currentTime.DayOfWeek <= 5)
                    {
                        excessHours = exitHour - 20;
                        exitDay++;
                        weekDay++;
                    }
                    else
                    {
                        excessHours = exitHour - 14;
                        exitDay += 2;
                        weekDay = 1;
                    }
                    if (excessHours == 0)
                    {
                        exitHour = 9;
                    }

                    while (excessHours > 0)                         //enquanto existirem horas extra, estas são distribuidas pelos dias seguintes
                    {
                        while (weekDay <= 5)                        // nos dias de semana, se restarem mais de 11 horas (horas do dia de funcionamento), são retiradas 11 horas e passa para o dia seguinte
                        {
                            if (excessHours >= 11)
                            {
                                excessHours -= 11;
                                weekDay++;
                                exitDay++;

                            }
                            else
                            {
                                exitHour = 9 + excessHours;         // se restarem menos de 11 horas a hora de saida será 9h00 mais as horas extra
                                excessHours = 0;
                                break;
                            }
                        }
                        if (weekDay == 6 & excessHours > 0)         // nos sábados, se restarem mais de 5 horas (horas de funcionamento de sabado), são retiradas 5 horas e passa 2 dias à frente
                        {
                            if (excessHours >= 5)
                            {
                                excessHours -= 5;
                                exitDay += 2;                       // o domingo é ignorado pois são incrementados 2 dias em vez de 1 e o weekDay volta a segunda
                                weekDay = 1;
                            }

                            else
                            {
                                exitHour = 9 + excessHours;         // se restarem menos de 5 horas a hora de saida será 9h00 mais as horas extra          
                                excessHours = 0;
                            }
                        }
                    }
                }
            }

            if (zone.ID == 2)                                       // no caso da zona 2, existe um array com os dias de cada mês, para que caso os dias avancem acima deste número o mès avance
            {
                int[] daysMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                while (exitDay > daysMonth[exitMonth])
                {
                    exitDay -= daysMonth[exitMonth];
                    exitMonth += 1;

                }
            }

            int[] exitTime = { currentTime.Year, exitMonth, exitDay, exitHour, exitMinute, 0 };
            return new Time(exitTime);
        }


        public static bool isOpen()
        {
            Time currentTime = new Time();
            if (currentTime.DayOfWeek == 7)
            {
                return false;
            }
            else if (currentTime.DayOfWeek == 6)
            {
                if (currentTime.Hour >= 9 && currentTime.Hour < 14)
                {
                    return true;
                }
            }
            else
            {
                if (currentTime.Hour >= 9 && currentTime.Hour < 20)
                {
                    return true;
                }
            }
            return false;
        }


    }
}




