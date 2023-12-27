using System;
using Telephony.Models;
using Telephony.Models.Interfaces;

string[] phoneNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] urls = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);


ICallable phone;

foreach (var phoneNumber in phoneNumbers)
{
    if (phoneNumber.Length == 10)
    {
        phone = new Smartphone();
    }
    else
    {
        phone = new StationaryPhone();
    }

    try
    {
        Console.WriteLine(phone.Call(phoneNumber));
    }
    catch (Exception ex)
    {

        Console.WriteLine(ex.Message);
    }
}

IBrowsable browse = new Smartphone();

foreach (var url in urls)
{
    try
    {
        Console.WriteLine(browse.Browse(url));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    
}