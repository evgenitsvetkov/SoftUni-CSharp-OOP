﻿
using Vehicles.Core;
using Vehicles.Core.Interfaces;
using Vehicles.Factories;
using Vehicles.IO;

IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter(), new VehicleFactory());
engine.Run();