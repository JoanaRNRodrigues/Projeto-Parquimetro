using System;
namespace Parquimetro {

    public static class zoneTime1
    {

        public static double minutesCount(double change, Zone zone, double[] coins)
        {
            Time currentTime = new Time();
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
            Time currentTime = new Time();

            int currentHour = currentTime.Hour;
            int currentMinute = currentTime.Minute;

            int exitMinute = (int)Math.Round(parkingMinutes) + currentMinute;
            int exitHour = currentHour;

            int exitDay = currentTime.Day;
            int weekDay = currentTime.DayOfWeek;
            int exitMonth = currentTime.Month;

            if (exitMinute >= 60)
            {
                int hours = exitMinute / 60;
                exitHour = currentHour + hours;
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


        }

        public static Time calculateExitTime(int parkingMinutes, Zone zone)
        {
            Time currentTime = new Time();

            int currentHour = currentTime.Hour;
            int currentMinute = currentTime.Minute;

            int exitMinute = parkingMinutes + currentMinute;
            int exitHour = currentHour;

            int exitDay = currentTime.Day;
            int weekDay = currentTime.DayOfWeek;
            int exitMonth = currentTime.Month;

            if (exitMinute >= 60)
            {
                int hours = exitMinute / 60;
                exitHour = currentHour + hours;
                exitMinute -= 60 * hours;
            }


            if (exitHour >= 20 & currentTime.DayOfWeek <= 5 || exitHour >= 14 & currentTime.DayOfWeek == 6)
            {
                if (zone.id < 2)
                {
                    
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
                
            }
            if (zone.id == 2)
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




