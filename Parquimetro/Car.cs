using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parquimetro
{
    public class Car
    {
        private int id;                          //variavel para o identificador de cada objeto car
        private Time time;                       //variável do tipo Time que descreve o tempo limite para o estacionamento do carro
        private bool parked;                     //variável que descreve se o carro está estacionado ou não

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public Time Time
        {
            get { return time; }
            set { time = value; }
        }
        public bool Parked
        {
            get { return parked; }
            set { parked = value; }
        }
        public Car(Time time, int id)
        {
            //Construtor por parametros de objetos da classe Car
            parked = true;
            this.time = time;
        }
    }
}
