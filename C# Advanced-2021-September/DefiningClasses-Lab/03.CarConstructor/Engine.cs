using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        private int hoursePower;
        private double cubicCapacity;
        public int HoursePower;
        //{
        //    get
        //    {
        //        return hoursePower;
        //    }
        //    set
        //    {
        //        hoursePower = value;
        //    }
        //}
        public double CubicCapacity;
        //{
        //    get
        //    {
        //        return cubicCapacity;
        //    }
        //    set
        //    {
        //        cubicCapacity = value;
        //    }
        //}
        public Engine(int hoursePower, double cubicCapacity)
        {
            HoursePower = hoursePower;
            CubicCapacity = cubicCapacity;
        }
    }
}
