using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parquimetro
{
    public class Car
    {
        public int id;
        public Time time;
        public bool parked;
        public Car(int[] exitTime)
        {
            this.id = id + 1;
            this.time = new Time(exitTime);                             //um carro será um objeto com um id e um objeto tempo associado que será a hora e data do fim do estacionamento
            MyFunctions.id++;
            parked = true;
        }   
        // penso que assim será mais fácil para a parte do administrador
        public void exitParking()
        {
            this.parked = false;
        }
     
    }
}
