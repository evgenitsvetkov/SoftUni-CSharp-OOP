﻿using VehiclesExtension.IO.Interfaces;

namespace VehiclesExtension.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine() => Console.WriteLine();
    }
}
