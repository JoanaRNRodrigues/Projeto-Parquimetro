using System;

namespace Parquimetro
{
    public static class MyFunctions
    {


        public static void giveChange(double change, double[] coins)
        {
            //Esta função pede o valor de troco e imprime as moedas que iriam cair na máquina assim como o total de troco

            Console.WriteLine("Your total change is" + change);

            //retirei stock pk elimina o risco de ficar sem troco a dada altura quando tivermos a correr o codigo.
            //pk na versão anterior com o while (change > 0) e if (change >= coins[0] & stockCoins[0] > 0), se o stock ficasse a 0 tornav-se num loop infinito.

            while (change > 0)                                       //enquanto o valor a dar pela máquina for maior do que 0, vai se verificar que moeda devolver.
            { 
                for (int i = 0; i < coins.Length; i++)
                {
                    while (change >= coins[i])
                    {
                        Console.WriteLine(coins[i] + "€");
                        change -= coins[i];
                    }
                }

            }

        }
    }
}
