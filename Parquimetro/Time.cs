using System;

namespace Parquimetro
{
    public class Time
    {
        private int hour;                                                                    //variáveis que vão representar valores de horas e datas de objetos da classe Time
        private int minute;
        private int day;
        private int month;
        private int dayOfWeek;
        private int year;

        public int Hour
        { get { return hour; } set { hour = value; } }
        
        public int Minute
        { get { return minute; } set { minute = value; } }
        
        public int Day
        { get { return day; } set { day = value; } }
        
        public int Month
        { get { return month; } set { month = value; } }    
        
        public int DayOfWeek
        { get { return dayOfWeek; } set { dayOfWeek = value; } }
        
        public int Year
        { get { return year; } set { year = value; } }
        
        
        public Time()
        {   //Construtor por omissão que é utilizado para o tempo de entrada no estacionamento e outras funcionalidade que requerem o tempo atual.
            DateTime tempoPC = DateTime.Now;
            DateTime dateValue = new DateTime(tempoPC.Year, tempoPC.Month, tempoPC.Day);
            int weekDay = ((int)dateValue.DayOfWeek);
            this.hour = tempoPC.Hour;
            this.minute = tempoPC.Minute;
            this.day = tempoPC.Day;
            this.month = tempoPC.Month;
            this.dayOfWeek = weekDay;
            this.year = tempoPC.Year;

        }
        public Time(int[] exitTime)
        {   // construtor com parametros que vai receber um array exitTime e criar um objeto do tipo Time que será associado ao tempo calculado de saída do estacionamento
            DateTime tempoPC = new DateTime(exitTime[0], exitTime[1], exitTime[2], exitTime[3], exitTime[4], exitTime[5]);
            this.hour = tempoPC.Hour;
            this.minute = tempoPC.Minute;
            this.day = tempoPC.Day;
            this.month = tempoPC.Month;
            this.dayOfWeek = ((int)tempoPC.DayOfWeek);
            this.year = tempoPC.Year;
        }
        
        public override string ToString()
        {
            return $"{Day}/{Month}/{Year} {Hour}:{Minute}:00";
        }

    }
}
