// See https://aka.ms/new-console-template for more information
using System;

public class cardHolder
{
    int cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;
    int age;
    public cardHolder(int cardNum, int pin, string firstName, string lastName, double balance, int age)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
        this.age = age;
    }

    public int getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFullName()
    {
        return firstName + " " + lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public int getAge()
    {
        return age;
    }

    public void setCardNum(int newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }
    public void setAge(int newAge)
    {
        age = newAge;
    }

    public static void Main(String[] args)
    {
        void printOptions(cardHolder currentUser)
        {
            Console.WriteLine("\n\nHi, " + currentUser.getFullName() + " (Age: " + currentUser.getAge() + ")");
            Console.WriteLine("Your current balance: $" + currentUser.getBalance());
            Console.WriteLine("\nPlease select an ATM option:");
            Console.WriteLine("1.) Deposit");
            Console.WriteLine("2.) Withdraw");
            Console.WriteLine("3.) Exit");
        }
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("Amount to Deposit: ");
            double depositAmt = Double.Parse(Console.ReadLine());
            if (depositAmt > 0)
            {
                depositAmt = currentUser.getBalance() + depositAmt;
                currentUser.setBalance(depositAmt);
                Console.WriteLine("Thanks for your deposit");
            }
            else
            {
                Console.WriteLine("Failed to Deposit, wrong amount");
            }
        }
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("Amount to Withdraw: ");
            double withdrawAmt = Double.Parse(Console.ReadLine());
            if (currentUser.getBalance() > withdrawAmt && withdrawAmt > 0)
            {
                withdrawAmt = currentUser.getBalance() - withdrawAmt;
                currentUser.setBalance(withdrawAmt);
                Console.WriteLine("Successfully Withdrawed");
            }
            else
            {
                Console.WriteLine("Failed to Withdraw, insufficient funds");
            }
        }
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder(878912, 1234, "Bob", "Jones", 100, 20));
        cardHolders.Add(new cardHolder(123111, 4155, "Sarah", "Smith", 465, 39));
        cardHolders.Add(new cardHolder(401922, 9782, "Sam", "Brown", 25, 14));
        Console.WriteLine("Welcome to ATM");
        Console.WriteLine("\nPlease insert your card number: ");
        int enteredCard = 0;
        cardHolder currentUser;
        while (true)
        {
            try
            {
                enteredCard = int.Parse(Console.ReadLine());
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == enteredCard);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("No matching cardholder member");
                }
            }
            catch
            {
                Console.WriteLine("ERROR: Please try again");
            }
        }
        while (true)
        {
            Console.WriteLine("\nPlease enter your pin: ");
            int enteredPin = 0;
            try
            {
                enteredPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == enteredPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect PIN");
                }
            }
            catch
            {
                Console.WriteLine("ERROR: Please try again");
            }
        }
        int userOption = 0;
        while (userOption != 3)
        {
            printOptions(currentUser);
            try
            {
                userOption = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("ERROR");
            }
            if (userOption == 1)
            {
                deposit(currentUser);
            }
            else if (userOption == 2)
            {
                withdraw(currentUser);
            }
            else if (userOption == 3)
            {
            }
            else
            {
                Console.WriteLine("ERROR: Incorrect option");
            }
        }
        Console.WriteLine("\nThank you for using ATM");
    }
}
