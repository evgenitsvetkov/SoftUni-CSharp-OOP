﻿
namespace ClassBoxData
{
    public class Box
    {
        //Fields
        private double length;
        private double width;
        private double height;

        //Constructor
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
       

        //Properties
        public double Length 
        {
            get => length; 
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                length = value;
            }
        }

        public double Width 
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                width = value;
            }
        }

        public double Height 
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                height = value;
            }
        }

        //Methods
        public double LateralSurface()
        {
            double lateralArea = (2 * Length * Height) + (2 * Width * Height);
            return lateralArea;
        }

        public double Surface()
        {
            double surfaceArea = LateralSurface() + (2 * Length * Width);
            return surfaceArea;
        }

        public double Volume()
        {
            double volume = Length * Width * Height;
            return volume;
        }
    }
}
