using System;

public class cardHolder
{
    String cardNum;
    String firstName;
    String lastName;
    int pin;
    double balance;

    // Constructor
    public cardHolder(String cardNum, String firstName, String lastName, int pin, double balance)
    {
        this.cardNum = cardNum;
        this.firstName = firstName;
        this.lastName = lastName;
        this.pin = pin;
        this.balance = balance;
    }

    // Getters
    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    // Setters
    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please select one of the following options: ");
            Console.WriteLine("1: Deposit Funds");
            Console.WriteLine("2: Withdraw Funds");
            Console.WriteLine("3: Check Balance");
            Console.WriteLine("4: Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Your deposit was successful. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw? ");
            double withdrawal = Double.Parse(Console.ReadLine());
            // Check if the user has enough funds to withdraw
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient Funds");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Transaction completed. Thank you for choosing Mo's Banking.");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Your current balance is: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("3975126974563258", "Jhonny", "Sins", 6969, 150000.69));
        cardHolders.Add(new cardHolder("1234567890123456", "Jane", "Doe", 1234, 23254.54));
        cardHolders.Add(new cardHolder("2345678901234567", "John", "Smith", 2345, 31789.78));
        cardHolders.Add(new cardHolder("3456789012345678", "Alice", "Johnson", 3456, 48671.21));
        cardHolders.Add(new cardHolder("4567890123456789", "Bob", "Williams", 4567, 55321.32));
        cardHolders.Add(new cardHolder("5678901234567890", "Charlie", "Brown", 5678, 69667.89));

        // Prompt user
        Console.WriteLine("Welcome to Mo's Banking");
        Console.WriteLine("Please insert your debit card number: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                // Check if the card number exists in the database
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card number not found. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("An error has occurred. Please try again.");
            }
        }

        Console.WriteLine("Enter your PIN: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                // Check if the PIN is correct
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect PIN entered. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("An error has occurred. Please try again.");
            }
        }

        Console.WriteLine("Welcome, " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {

            }
            if (option == 1)
            {
                deposit(currentUser);
            }
            else if (option == 2)
            {
                withdraw(currentUser);
            }
            else if (option == 3)
            {
                balance(currentUser);
            }
            else if (option == 4)
            {
                break;
            }
            else
            {
                option = 0;
            }
        }
        while (option != 4);
        Console.WriteLine("Thank you for banking with us! Have a great day.");
    }
}
