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
        private Car[] Spaces;
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
            return $"-------------------\n" +
                $"ZONA {id}: \n" +
                $"Custo Por Hora: {CostPerHour} euros \n" +
                $"Limite de Tempo: {TimeLimit} minutos \n" +
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



        public void park(int minutes)
        {
            int freeSpot = findFreeSpot();
            Time exitTime = zoneTime1.calculateExitTime(minutes, this);
            int ticketId = id * 100 + freeSpot;
            Car parkingCar = new Car(exitTime, ticketId);
            vacantSpaces--;
            printTicket(exitTime, freeSpot, ticketId);
            Spaces[freeSpot] = parkingCar;
        }



        public void unpark(int ticketId)
        {
            int freeSpot = ticketId % 100;
            Spaces[freeSpot] = null;
            vacantSpaces++;
        }


        private void printTicket(Time exitTime, int vacantSpot, int ticketId)
        {
            Console.WriteLine($"----------------\n" +
                $"Zona: {id}\n" +
                $"Hora de Entrada: {DateTime.Now}\n" +
                $"Hora de Saída: {exitTime}\n" +
                $"ID: {ticketId}");
        }





    }
}
