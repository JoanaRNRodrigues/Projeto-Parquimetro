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


        public Zone(int id, double CostPerHour, int TimeLimit, int spaces)
        {
            this.id = id;
            this.CostPerHour = CostPerHour; //custo em euros por hora
            this.TimeLimit = TimeLimit; // tempo máximo em minutos
            this.MaxChange = CostPerHour * (TimeLimit / 60); //Custo máximo que o utilizador pode pagar por sessão
            this.Spaces = new Car[spaces]; // lugares disponíveis para estacionar
        }
    }
}
