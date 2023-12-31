﻿
using System.Runtime.InteropServices;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        private string model;
        private string color;
        private int battery;

        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

   
        public string Model 
        {
            get => model;
            set
            {
                model = value;
            }
        }

        public string Color 
        {
            get => color;
            set
            {
                color = value;
            }
        }

        public int Battery
        {
            get => battery;
            set
            {
                battery = value;
            }
        }

        public string Start()
        {
           return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{this.Color} {nameof(Tesla)} {this.Model} with {this.Battery} Batteries";
        }
    }
}
