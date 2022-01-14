using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parquimetro
{
    public static class MyFunctions
    {
        private static int id;                                                       // id que identifica os objetos carro
        
        private static double totalGains;                                            // Variável que vai sendo incrementada consuante os valores que são ganhos num dado dia
        public static double ID
        {
            get { return ID; }
            set { ID = value; }
        }
        public static double TotalGains
        { 
            get { return totalGains; } 
            set { totalGains = value; } 
        }
        public static void giveChange(double change, double[] coins)
        {
            //Esta função pede o valor de troco e imprime as moedas que iriam cair na máquina assim como o total de troco

            Console.WriteLine($"Troco: {change} euros");
            totalGains -= change;
           
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

        public static string Menu(string title, string[] options)                   //Função que constroi o aspeto os Menus
        {
            string MenuType = "";
            MenuType += " ___________________________________\n" +           
                        "|                                   |\n" +
                        $"|------    {title}";
            //Função que controla o espaçamento no aspeto dos Menus para o sector do Titulo
            //Iniciou-se o K em 0 pois assumiu-se que o numero de caracteres do titulo começasse em 0.
            for (int k = 0; k <= 18 - title.Length; k++)                     
            {
                MenuType += " ";

            }
            MenuType += "------|\n";

            //Função que controla o espaçamento no aspeto dos Menus para o sector das Opções
            for (int i = 0; i < options.Length; i++)                    // i é o indice das opções
            {
                MenuType += $"|          {i + 1}.{options[i]}";           // Imprime o número da opção e o respetivo "valor"   

                for (int j = 0; j <= 22 - options[i].Length; j++)         //Inicio o J em 0 pois assumiu-se que o numero de caracteres das opções começasse em 0.
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
            if (change >= zone.MaxChange && zone.MaxChange > 0)                      // caso a zona escolhida tenha limite de tempo e seja inserido demasiado dinheiro para esse tempo:
            {
                minutesParking = zone.TimeLimit;                                    // o valor máximo da zona será assumido e o restante dinheiro devolvido como troco
                MyFunctions.giveChange(Math.Round(change - zone.MaxChange,2), coins);
                
                return minutesParking;
            }
            else
            {
                minutesParking = (60 * change) / zone.CostPerHour;                  // caso contrário o dinheiro é convertido para o número de minutos equivalente
                return minutesParking;
            }
        }

        public static void dayGains(double change, Zone zone)
        {
            // esta funcção recebe um booleano que indica se numa transação foi necessário troco, o dinheiro inserido nessa transação e a zona de estacionamento
            // ela incrementa na variável totalGains o dinheiro ganho na transação, para que seja possível consultar a faturação diária
            totalGains += change;                                               
                                                                                
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
                        if (car.Parked == true && (car.Time.Hour < now.Hour && car.Time.Day == now.Day || (car.Time.Hour == now.Hour && car.Time.Minute < now.Minute && car.Time.Day == now.Day)))
                        {
                            Console.WriteLine($"O carro no lugar {i} da zona {zone.ID} está a exceder o estacionamento");
                        }
                    }
                }
            }

        }
        public static void changePrice(float newPrice, Zone zone)
        {   // esta função altera o preço de uma dada zona
            zone.CostPerHour=newPrice;
        }
        public static void changeTimeLimit(int newLimit, Zone zone)
        {   //esta função altera o tempo limite de uma zona, exceto a terceira
            zone.TimeLimit = newLimit;
        }
        public static double receivePayment(double[] coins)   //Função para selecionar as moedas
        {
            double insertedMoney = 0;
            string[] coinsOptions = { "2 euros", "1 euro", "50 centimos", "20 centimos", "10 centimos", "5 centimos", "2 centimos", "1 centimo", "confirmar" };
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
