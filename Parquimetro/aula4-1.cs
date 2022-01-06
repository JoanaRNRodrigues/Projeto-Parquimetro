

double[] zone1 = { 1.15, 45.0, 35.0 };
double[] zone2 = { 1.0, 120.0, 40.0 };     //informação para menus zona
double[] zone3 = { 0.62, -1, 45.0 };

// quando selecionar a zona atribuir valor 0, 1 ou 2 à variavel
// caso a pessoa escolha a zona 1, a variavel zone será alterada para 0, caso escolha a zona 2 será zone = 1 e caso escolha zona 3, zone = 2
int zone;

double change = 12.0;

double minutesCount(double change, int zone)
{
    double[] maxChange = { 0.86, 2, -1 };
    double[] costHour = { 1.15, 1, 0.62 };
    double[] maxMinutes = { 45, 120, -1 };

    int[] currentTime = Time();
    double minutesParking;
    if (change >= maxChange[zone] & maxChange[zone] > 0)
    {
        minutesParking = maxMinutes[zone];
        giveChange(change - maxChange[zone]);
        return minutesParking;
    }
    else
    {
        minutesParking = (60 * change) / costHour[zone];  //tornar função universal com array que recebe preço e maxchange
        return minutesParking;
    }
}

void zoneTime(double change, int zone)
{
    double parkingMinutes = minutesCount(change, zone);
    int[] currentTime = Time();

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
        if (zone < 2)
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
    if (zone == 2)
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

zoneTime(1, 1);
