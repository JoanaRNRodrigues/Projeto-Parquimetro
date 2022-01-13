using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parquimetro
{
    public class Car
    {
        public int id;                          //variavel para o identificador de cada objeto car
        public Time time;                       //variável do tipo Time que descreve o tempo limite para o estacionamento do carro
        public bool parked;                     //variável que descreve se o carro está estacionado ou não
        
        public Car(Time time, int id)
        {
            //Construtor por parametros de objetos da classe Car
            parked = true;
            this.time = time;
        }
    }
}
