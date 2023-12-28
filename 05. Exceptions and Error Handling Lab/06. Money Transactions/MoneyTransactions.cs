
string[] bankAccountsInfo = Console.ReadLine().Split(",");

Dictionary<int, double> accounts = new Dictionary<int, double>();

foreach (string line in bankAccountsInfo)
{

    string[] currentLine = line.Split('-');

    int accountNum = int.Parse(currentLine[0]);
    double accountBalance = double.Parse(currentLine[1]);

    accounts.Add(accountNum, accountBalance);

}


string command = Console.ReadLine();

while (command != "End")
{
    try
    {
        string[] commandInfo = command.Split();

        string commandType = commandInfo[0];
        int accountNumber = int.Parse(commandInfo[1]);
        double balance = double.Parse(commandInfo[2]);

        if (commandType == "Deposit")
        {
            accounts[accountNumber] += balance;
        }
        else if (commandType == "Withdraw")
        {
            if (balance > accounts[accountNumber])
            {
                throw new InvalidOperationException("Insufficient balance!");
            }

            accounts[accountNumber] -= balance;
        }
        else
        {
            throw new ArgumentException("Invalid command!");
        }

        Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
    }
    catch (KeyNotFoundException)
    {
        Console.WriteLine("Invalid account!");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
    }


    Console.WriteLine("Enter another command");
    command = Console.ReadLine();
}