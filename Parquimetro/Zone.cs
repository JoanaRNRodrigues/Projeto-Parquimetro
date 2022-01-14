using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parquimetro
{
    public class Zone
    {
        public int id;
        public int TimeLimit;
        public double CostPerHour;
        public double MaxChange;
        public Car[] Spaces;
        public int vacantSpaces;


        public Zone(int id, double CostPerHour, int TimeLimit, int spaces)
        {
            this.id = id;
            this.CostPerHour = CostPerHour; //custo em euros por hora
            this.TimeLimit = TimeLimit; // tempo máximo em minutos
            this.MaxChange = CostPerHour * (TimeLimit / 60); //Custo máximo que o utilizador pode pagar por sessão
            this.Spaces = new Car[spaces]; // lugares disponíveis para estacionar
            this.vacantSpaces = spaces;
        }




        public override string ToString()
        {
            string Limite;
            if (this.TimeLimit == 0) { Limite = "Sem Limite de tempo"; }
            else { Limite = this.TimeLimit.ToString() + "minutos"; }
            return $"-------------------\n" +
                $"ZONA {id}: \n" +
                $"Custo Por Hora: {CostPerHour} euros \n" +
                $"Limite de Tempo: {Limite} \n" +
                $"Lotação: {Spaces.Length} \n" +
                $"Lugares Vagos: {vacantSpaces}";
        }



        public Car[] GetSpaces()
        {
            return this.Spaces;
        }



        private int findFreeSpot()
        {
            for (int i = 0; i < Spaces.Length; i++)
            {
                if (Spaces[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }



        public void park(int minutes)       //Função para estacionar
        {
            int freeSpot = findFreeSpot();      //Encontra-se um lugar livre
            Time exitTime = zoneTime1.calculateExitTime(minutes, this);     //Determinamos a hora de saida
            int ticketId = id * 100 + freeSpot;     //Calculo do ID to ticket
            Car parkingCar = new Car(exitTime, ticketId);   //Instanciamento do Carro
            vacantSpaces--;     //O numero de lugares disponiveis diminui
            printTicket(exitTime, freeSpot, ticketId);      //Impressão do ticket
            Spaces[freeSpot] = parkingCar;      //Carro é estacionado
        }

        public void unpark(int ticketId)    //Função que tira o carro do estacionamento
        {
            int freeSpot = ticketId % 100;      //Lugar é determinado pelos ultimos dois digitos do ID do ticket
            Spaces[freeSpot] = null;    //O espaço deixa de ter um carro
            vacantSpaces++;     //O numero de lugar livres aumenta
        }


        private void printTicket(Time exitTime, int vacantSpot, int ticketId)       //Função que imprime o ticket
        {
            Console.WriteLine($"----------------\n" +
                $"Zona: {id}\n" +
                $"Hora de Entrada: {DateTime.Now}\n" +
                $"Hora de Saída: {exitTime}\n" +
                $"ID: {ticketId}");
        }





    }
}
