using System;

namespace Parquimetro
{
    public class Time
    {
        public int Hour;
        public int Minute;
        public int Day;
        public int Month;
        public int DayOfWeek;
        public int Year;
        public Time()                                                                       // construtor por omissão usado para o tempo de entrada
        {
            DateTime tempoPC = DateTime.Now;
            DateTime dateValue = new DateTime(tempoPC.Year, tempoPC.Month, tempoPC.Day);
            int weekDay = ((int)dateValue.DayOfWeek);
            this.Hour = tempoPC.Hour;
            this.Minute = tempoPC.Minute;
            this.Day = tempoPC.Day;
            this.Month = tempoPC.Month;
            this.DayOfWeek = weekDay;
            this.Year = tempoPC.Year;

        }
        public Time(int[] exitTime)                     // construtor com parametros que vai receber o exitTime e criar um objeto time para ser associado com o carro
        {
            DateTime tempoPC = new DateTime(exitTime[0], exitTime[1], exitTime[2], exitTime[3], exitTime[4], exitTime[5]);
            this.Hour = tempoPC.Hour;
            this.Minute = tempoPC.Minute;
            this.Day = tempoPC.Day;
            this.Month = tempoPC.Month;
            this.DayOfWeek = ((int)tempoPC.DayOfWeek);
            this.Year = tempoPC.Year;
        }
        public void exceedTime(Zone zone) //se for administrador
        {
            foreach(Car car in zone.Spaces)
            {
                Time now = new Time();
                if (car.parked == true && (car.time.Hour > now.Hour || (car.time.Hour == now.Hour && car.time.Minute > now.Minute)))
                {
                    Console.WriteLine("O carro " + car.id + " está a exceder o estacionamento");
                }
            }

        }
    }
}
