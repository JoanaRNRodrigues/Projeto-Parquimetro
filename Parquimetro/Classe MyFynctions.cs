using System;

namespace Parquimetro
{
    public static class MyFunctions
    {


        public static void giveChange(double change, double[] coins, int[] stock)
        {
            //Esta função pede o valor de troco e imprime as moedas que iriam cair na máquina assim como o total de troco

            Console.WriteLine($"Troco: {change} euros");

            //Alterado para ter em consideração o stock
            //Dei um stock bastante elevado para diminuir o risco de ficar a zero

            while (change > 0 )                                       //enquanto o valor a dar pela máquina for maior do que 0, vai se verificar que moeda devolver.
            { 
                for (int i = 0; i < coins.Length; i++)                // i é o indice do array das coins
                {
                    while (change >= coins[i] & stock[i] > 0)
                    {
                        Console.WriteLine($"O Parquímetro devolve {coins[i]} euros");         //Imprime o valor de troco a dar ao utilizador
                        change -= coins[i];                        //O valor a dar de troco é deduzido.
                        change = Math.Round(change, 2);            //Arredonda o troco a duas casas decimais para evitar erro por arrendondamento
                        stock[i]--;                                //O tipo de moeda dada é retirada do stock.
                        //Console.WriteLine($" falta dar {change}");
                    }
                }

            }

        }

        /*
         while (change > 0)                                       //enquanto o valor a dar pela máquina for maior do que 0, vai se verificar que moeda devolver, consoante o stock da máquina)
        {                                                        //tive que alterar para >= senão não funcionava devidamente
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
        */





        public static void ImprimeTempo()
        {

            DateTime tempoPC = DateTime.Now;

            // dia, ano e mes actual (buscado do computador)

            int dia = tempoPC.Day;
            int mes = tempoPC.Month;
            int ano = tempoPC.Year;


            // horas e minutos

            int horas = tempoPC.Hour;
            int minutos = tempoPC.Minute;


            // pode ser alterado para efeitos de simulação

            // dias da semana - retorna 1 quando é segunda feira, 2 para terça, 3 para quarta, etc

            DateTime dateValue = new DateTime(ano, mes, dia);
            Console.WriteLine((int)dateValue.DayOfWeek);


            // podemos usar estas variaveis como qualquer outras

            Console.WriteLine("dia " + dia + " mes " + mes + " ano " + ano + "horas " + horas);


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



    }
}
