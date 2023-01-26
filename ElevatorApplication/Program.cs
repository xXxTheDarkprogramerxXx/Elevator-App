using System;
using System.Collections.Generic;

namespace ElevatorApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Would you like to see a demo or enter items manually? (Y/N) ");
            //var choice = Console.ReadLine();
            //if (choice.ToUpper() == "Y")
            //{
            //    // Show demo
            //    var system = new ElevatorSystem(2, 3, 10);
            //    system.AddElevator(new Elevator { Id = 1, CurrentFloor = 1, WeightLimit = 10 });
            //    system.AddElevator(new Elevator { Id = 2, CurrentFloor = 2, WeightLimit = 10 });
            //    system.AddFloor(new Floor { PeopleWaiting = 0 });
            //    system.AddFloor(new Floor { PeopleWaiting = 0 });
            //    system.AddFloor(new Floor { PeopleWaiting = 0 });
            //    system.Run();
            //}
            //else if (choice.ToUpper() == "N")
            {
                Console.WriteLine("Enter number of elevators: ");
                int numberOfElevators = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter number of floors: ");
                int numberOfFloors = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter weight limit: ");
                int weightLimit = int.Parse(Console.ReadLine());

                ElevatorSystem system = new ElevatorSystem(numberOfElevators, numberOfFloors, weightLimit);
                system.Run();
            }
            //else
            //{
            //    Console.WriteLine("Invalid choice, please enter Y or N");
            //}
        }

    }
}
