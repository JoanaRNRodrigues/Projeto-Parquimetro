using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parquimetro
{
    public class Zone
    {
        private int id;
        private int timeLimit;
        private double costPerHour;
        private double maxChange;
        private Car[] spaces;
        private int vacantSpaces;

        public Car[] Spaces
        {
            get { return spaces; }
            set { spaces = value; }
        }
        public int VacantSpaces
        {
            get { return vacantSpaces; }
            set { vacantSpaces = value; }
        }
        public double CostPerHour
        {
            get { return costPerHour; }
            set { costPerHour = value; }
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public int TimeLimit
        {
            get { return timeLimit; }
            set { timeLimit = value; }
        }
        public double MaxChange
        {
            get { return maxChange; }
            set { maxChange = value; }
        }

        public Zone(int id, double CostPerHour, int TimeLimit, int Spaces)
        {
            this.id = id;
            this.costPerHour = CostPerHour; //custo em euros por hora
            this.timeLimit = TimeLimit; // tempo máximo em minutos
            this.maxChange = CostPerHour * ((double)TimeLimit / 60); //Custo máximo que o utilizador pode pagar por sessão
            this.spaces = new Car[Spaces]; // lugares disponíveis para estacionar
            this.vacantSpaces = Spaces;
        }

        public void updateMaxChange() //atualiza o maxChange quando o administrador altera o valor de tempo máximo ou custo por hora das zonas
        {
            this.maxChange = CostPerHour * ((double)TimeLimit / 60);
        }


        public override string ToString()
        {
            string Limite;
            if (this.TimeLimit == 0) { Limite = "Sem Limite de tempo"; }
            else { Limite = this.TimeLimit.ToString() + " minutos"; }
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



        public void park(int minutes)           //Função para estacionar
        {
            int freeSpot = findFreeSpot();      //Encontra-se um lugar livre
            Time exitTime = zoneTime1.calculateExitTime(minutes, this);     //Determinamos a hora de saida
            int ticketId = id * 100 + freeSpot; //Calculo do ID to ticket
            Car parkingCar = new Car(exitTime, ticketId);                    //Instanciamento do Carro
            vacantSpaces--;                     //O numero de lugares disponiveis diminui
            printTicket(exitTime, freeSpot, ticketId);                      //Impressão do ticket
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
                $"Hora de Saída: {exitTime.Day}/{exitTime.Month}\n{exitTime.Hour}h{exitTime.Minute}" +
                $"ID: {ticketId}");
        }





    }
}
