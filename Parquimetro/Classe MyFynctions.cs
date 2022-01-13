using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parquimetro
{
    public static class MyFunctions
    {
        public static int id;                                                       // id que identifica os objetos carro
        public static bool needChange;                                              // variável que descreve se um transação envolveu troco para fins de faturação
        public static double totalGains;                                            // Variável que vai sendo incrementada consuante os valores que são ganhos num dado dia
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

        public static string Menu(string title, string[] options)                   //Função que devolve os menus
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
                        "|___________________________________|";

            return MenuType;
        }

        public static double minutesCount(double change, Zone zone, double[] coins)
        {
            // esta função recebe o dinheiro que o utilizador coloca na máquina, a zona em que será feito o estacionamento e um array com as diferentes moedas
            // esta função retorna o número de minutos de estacionamento equivalentes ao valor que o utilizador inseriu, considerando o tempo máximo permitido por zona
            Time currentTime = new Time();
            double minutesParking;
            if (change >= zone.MaxChange & zone.MaxChange > 0)                      // caso a zona escolhida tenha limite de tempo e seja inserido demasiado dinheiro para esse tempo:
            {
                minutesParking = zone.TimeLimit;                                    // o valor máximo da zona será assumido e o restante dinheiro devolvido como troco
                MyFunctions.giveChange(change - zone.MaxChange, coins);
                needChange = true;
                return minutesParking;
            }
            else
            {
                minutesParking = (60 * change) / zone.CostPerHour;                  // caso contrário o dinheiro é convertido para o número de minutos equivalente
                return minutesParking;
            }
        }

        public static void dayGains(bool needChange, double change, Zone zone)
        {
            // esta funcção recebe um booleano que indica se numa transação foi necessário troco, o dinheiro inserido nessa transação e a zona de estacionamento
            // ela incrementa na variável totalGains o dinheiro ganho na transação, para que seja possível consultar a faturação diária
            if (needChange == false)
            {
                totalGains += change;                                               // caso a transação não envolva troco, o dinheiro inserido é adicionado à faturação no seu total
            }
            else
            {
                totalGains += zone.MaxChange;                                       // caso contrário, o que só acontece nas zonas com tempo limite, 
            }                                                                       // é adicionado o valor máximo associado à zona pois foi comprado o tempo máximo
        }

        public static void exceedTime(Zone[] zones) 
        {
            // esta função recebe o parametro zones que é um array das 3 zonas disponiveis
            // determina se existe algum carro a exceder o tempo de estacionamento e notifica o administrador quando seleciona essa opção no menu
            Time now = new Time();
            foreach (Zone zone in zones)                                            // para cada zona percorre os espaços de estacionamento e verifica se
            {                                                                       // algum carro tem um limite de estacionamento que já tenha passado em relação a hora atual
                for (int i = 0; i < zone.Spaces.Length; i++)
                {
                    Car car = zone.Spaces[i];
                    if (car != null)
                    {
                        if (car.parked == true && (car.time.Hour < now.Hour && car.time.Day==now.Day|| (car.time.Hour == now.Hour && car.time.Minute < now.Minute && car.time.Day == now.Day)))
                        {
                            Console.WriteLine($"O carro no lugar {i} da zona {zone.id} está a exceder o estacionamento");
                        }
                    }
                }
            }

        }
    }
}
