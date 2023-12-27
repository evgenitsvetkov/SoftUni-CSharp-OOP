using VehiclesExtension.Core;
using VehiclesExtension.Core.Interfaces;
using VehiclesExtension.Factories;
using VehiclesExtension.IO;

IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter(), new VehicleFactory());
engine.Run();