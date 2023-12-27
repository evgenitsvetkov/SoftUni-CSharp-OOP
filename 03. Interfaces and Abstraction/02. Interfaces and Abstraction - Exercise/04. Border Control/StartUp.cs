using BorderControl.Models;
using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;


List<IIds> society = new();

while (true)
{
	string input = Console.ReadLine();

	if (input == "End")
	{
		break;
	}

	string[] tokens = input
		.Split(" ", StringSplitOptions.RemoveEmptyEntries);

	if (tokens.Length == 3)
	{
		IIds person = new Person(tokens[2], tokens[0], int.Parse(tokens[1]));
		society.Add(person);
	}
	else
	{
		IIds robot = new Robot(tokens[1], tokens[0]);
		society.Add(robot);
    }
}

string invalidNumber = Console.ReadLine();

foreach (var element in society)
{
	if (element.Id.EndsWith(invalidNumber))
	{
		Console.WriteLine(element.Id);
	}
}