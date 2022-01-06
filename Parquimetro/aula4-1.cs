        {


           
            string[] MainMenuOptions = {"Administrador", "Cliente", "Opções", "voltar"};
            string[] ClientMenuOptions = { "Estacionar", "Ver Zonas", "Histórico","Voltar" };
            string[] AdminMenuOptions = { "Ver Zonas", "Histórico", "Ver Máquinas", "Voltar" };

            string ClientMenu = Menu("Cliente", ClientMenuOptions);
            string AdminMenu = Menu("Cliente", AdminMenuOptions);
            string MainMenu = Menu("Bem Vindo", MainMenuOptions);

            Console.WriteLine(MainMenu);
            Console.ReadLine();
          
        }

        static string Menu (string title, string[] options )        //função que devolve os menus
        {
            string MenuType = "";
            MenuType += " ___________________________________\n" +           // \n é para escrever na linha abaixo/nova linha
                        "|                                   |\n" +
                        $"|------    {title}";                          // O sinal $ serve para adicionar rapidamente um variavel a string

            for (int k = 0; k <= 18-title.Length; k++)                  // adiona espaços para alinhar a barra da direita       // dei valor 0 porque escolhi como parametro assumir que o numero de caracteres do "valor" da opção fosse 0.
            {
                MenuType += " ";

            }
            MenuType += "------|\n";
        

            for (int i = 0; i < options.Length; i++)                    // i é o indice das opções
            {
                MenuType += $"|          {i+1}.{options[i]}";    // imprime o número da opção e o "valor" da opçõo   
                
                for (int j = 0; j <= 22-options[i].Length; j++)         // adiona espaços para alinhar a barra da direita       // dei valor 0 porque escolhi como parametro assumir que o numero de caracteres do "valor" da opção fosse 0.
                {
                MenuType += " ";
                }
                MenuType += "|\n"; 
            }


             MenuType += "|                                   |\n" +
                         "|___________________________________|\n";

            return MenuType;
        } 










static int[] Time()
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


//int[] stockCoins = new int[8];                                      //stock de cada moeda , depois deverá vir de trás o valor que cada parquímetro tem
int[] stockCoins = {10,10,10,10,10,10,10,10};
double[] coins = { 2.0, 1.0, 0.5, 0.2, 0.1, 0.05, 0.02, 0.01 };     //tipos de moedas

void giveChange(double change)
{
    //Esta função pede o valor de troco e imprime as moedas que iriam cair na máquina assim como o total de troco

    Console.WriteLine("Your total change is" + change);


    while (change > 0)                                       //enquanto o valor a dar pela máquina for maior do que 0, vai se verificar que moeda devolver, consoante o stock da máquina)
    {
        if (change >= coins[0] & stockCoins[0] > 0)
        {
            Console.WriteLine("2€");
            change = change - coins[0];
            stockCoins[0]--;
        }
        else if (change >= coins[1] & stockCoins[1] > 0)
        {
            Console.WriteLine("1€");
            change = change - coins[1];
            stockCoins[1]--;
        }
        else if (change >= coins[2] & stockCoins[2] > 0)
        {
            Console.WriteLine("50 cents");
            change = change - coins[2];
            stockCoins[2]--;
        }
        else if (change >= coins[3] & stockCoins[3] > 0)
        {
            Console.WriteLine("20 cents");
            change = change - coins[3];
            stockCoins[3]--;
        }
        else if (change >= coins[4] & stockCoins[4] > 0)
        {
            Console.WriteLine("10 cents");
            change = change - coins[4];
            stockCoins[4]--;
        }
        else if (change >= coins[5] & stockCoins[5] > 0)
        {
            Console.WriteLine("5 cents");
            change = change - coins[5];
            stockCoins[5]--;
        }
        else if (change >= coins[6] & stockCoins[6] > 0)
        {
            Console.WriteLine("2 cents");
            change = change - coins[6];
            stockCoins[6]--;
        }
        else if (change >= coins[7] & stockCoins[7] > 0)
        {
            Console.WriteLine("1 cents");
            change = change - coins[7];
            stockCoins[7]--;
        }
    }

}


double[] zone1= { 1.15, 45.0, 35.0};
double[] zone2 = { 1.0, 120.0, 40.0 };     //informação para menus zona
double[] zone3 = { 0.62, -1, 45.0 };

// quando selecionar a zona atribuir valor 0, 1 ou 2 à variavel
// caso a pessoa escolha a zona 1, a variavel zone será alterada para 0, caso escolha a zona 2 será zone = 1 e caso escolha zona 3, zone = 2
int zone;

double change = 12.0;

void zoneTime(double change,int zone)
{
    double parkingMinutes = minutesCount(change,zone);
    int[] currentTime = Time();

    int currentHour = currentTime[0];
    int currentMinute = currentTime[1];

    int exitMinute = (int)Math.Round(parkingMinutes) + currentMinute;
    int exitHour = currentHour;
    if (exitMinute >= 60)
    {
        exitHour++;
        exitMinute -= 60;
    }

    Console.WriteLine(""+ exitHour + "h" + exitMinute);  //horas de saida do estacionamento
}


double minutesCount(double change, int zone)
{
    double[] maxChange = { 0.86, 2, -1 };               
    double[] costHour = { 1.15, 1, 0.62 };
   
    int[] currentTime = Time();
    double minutesParking;
    if (change >= maxChange[zone])
    {
        minutesParking = 45;
        giveChange(change - maxChange[zone]);
    }
    else
    {
        minutesParking = (60 * change) / costHour[zone];  //tornar função universal com array que recebe preço e maxchange
    }
    if (currentTime[5] <= 5 & currentTime[0] >= 9 & currentTime[0] < 20)
    {
        if (currentTime[0] == 19 & currentTime[1] > 15)
        {
            // menu fora do horário
            return 0;
        }
        else
        {
            return minutesParking;
        }
    }
    else if (currentTime[5] == 6 & currentTime[0] >= 9 & currentTime[0] < 14)
    {
        if (currentTime[0] == 13 & currentTime[1] > 15)
        {
            // menu fora do horário
            return 0;
        }
        else
        {
            return minutesParking;
        }
    }
    else
    {
        // menu fora do horário
        return 0;
    }
}
