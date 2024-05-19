using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
   using System;
    using System.Threading;

    class Program
    {
        static void Main()
        {
            // Инициализация на анализатора
            ElevatorAnalyzer analyzer = new ElevatorAnalyzer();
            Random random = new Random();

            while (true)
            {
                // Генериране на случайна роля (1 - Администратор, 2 - Служител, 3 - Посетител)
                int randomRole = random.Next(1, 4);
                Console.WriteLine($"Your roll is: {randomRole}");

                IAccess userAccess = null;

                // Създаване на обект с правата за достъп според случайната роля
                switch (randomRole)
                {
                    case 1:
                        userAccess = new AdministratorAccess();
                        Console.WriteLine("Your roll is Administratior(Top-sicret)");
                        break;
                    case 2:
                        userAccess = new EmployeeAccess();
                        Console.WriteLine("Your roll is Employ(Sicret)");
                        break;
                    case 3:
                        userAccess = new VisitorAccess();
                        Console.WriteLine("Your roll is Visitor(Confidential)");
                        break;
                }

                // Възможност за потребителя да въведе желания етаж
                int desiredFloor = RequestFloorAccess();

                // Проверка за достъп до избрания етаж
                if (desiredFloor >= 1 && desiredFloor <= 4)
                {
                    Console.WriteLine($"You chuce the {desiredFloor} floor");
                    // Използвайте методите за достъп в зависимост от ролята на потребителя
                    switch (desiredFloor)
                    {
                        case 1:
                            Thread.Sleep(1000);
                            userAccess.AccessFloor1();
                            break;
                        case 2:
                            Thread.Sleep(1000);
                            userAccess.AccessFloor2();
                            break;
                        case 3:
                            Thread.Sleep(1000);
                            userAccess.AccessFloor3();
                            break;
                        case 4:
                            Thread.Sleep(1000);
                            userAccess.AccessFloor4();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Not valid floor");
                    Console.WriteLine("Try again");
                }
            }
        }

        // Функция за въвеждане на желан етаж
        static int RequestFloorAccess()
        {
            int desiredFloor;
            do
            {
                Console.Write("Enter the floor (1-4): ");
                
            } while (!int.TryParse(Console.ReadLine(), out desiredFloor));
             return desiredFloor;
        }
    }

}



// Интерфейс за права на достъп
interface IAccess
{
    void AccessFloor1();
    void AccessFloor2();
    void AccessFloor3();
    void AccessFloor4();
}

// Клас, представящ ролята на администратор
class AdministratorAccess : IAccess
{
    public void AccessFloor1()
    {
        Console.WriteLine("Administrator: Access to 1 floor.");
        Console.WriteLine(" ");
    }

    public void AccessFloor2()
    {
        Console.WriteLine("Administrator: Access to 2 floor.");
        Console.WriteLine(" ");
    }

    public void AccessFloor3()
    {
        Console.WriteLine("Administrator: Access to 3 floor.");
        Console.WriteLine(" ");
    }

    public void AccessFloor4()
    {
        Console.WriteLine("Administrator: Access to 4 floor.");
        Console.WriteLine(" ");
    }
}

// Клас, представящ ролята на служител
class EmployeeAccess : IAccess
{
    public void AccessFloor1()
    {
        Console.WriteLine("Employ: Access to 1 floor.");
        Console.WriteLine(" ");
    }

    public void AccessFloor2()
    {
        Console.WriteLine("Employ: Access to 2 floor.");
        Console.WriteLine(" ");
    }

    public void AccessFloor3()
    {
        Console.WriteLine("Employ: Not have access to 3 floor.");
        Console.WriteLine("You don't have access to that floor");
        Console.WriteLine(" ");
    }

    public void AccessFloor4()
    {
        Console.WriteLine("Employ: Not have access to 4 floor.");
        Console.WriteLine("You don't have access to that floor");
        Console.WriteLine(" ");
    }
}

// Клас, представящ ролята на посетител
class VisitorAccess : IAccess
{
    public void AccessFloor1()
    {
        Console.WriteLine("Visitor: Access to 1 floor.");
        Console.WriteLine(" ");
    }

    public void AccessFloor2()
    {
        Console.WriteLine("Visitor: Not have access to 2 floor.");
        Console.WriteLine("You don't have access to that floor");
        Console.WriteLine(" ");
    }

    public void AccessFloor3()
    {
        Console.WriteLine("Visitor: Not have access to 3 floor.");
        Console.WriteLine("You don't have access to that floor");
        Console.WriteLine(" ");
    }

    public void AccessFloor4()
    {
        Console.WriteLine("Visitor: Not have access to 4 floor.");
        Console.WriteLine("You don't have access to that floor");
        Console.WriteLine(" ");
    }
}

// Клас, представящ анализатора на етажите
class ElevatorAnalyzer
{
    public void AnalyzeAccess(IAccess access)
    {
        // Използвайте методите за достъп в зависимост от ролята на потребителя
        access.AccessFloor1();
        access.AccessFloor2();
        access.AccessFloor3();
        access.AccessFloor4();
    }
}


