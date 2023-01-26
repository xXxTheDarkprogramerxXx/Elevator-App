using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApplication
{
    class ElevatorSystem
    {
        public List<Elevator> Elevators { get; set; }
        public List<Floor> Floors { get; set; }

        public ElevatorSystem(int numberOfElevators, int numberOfFloors, int weightLimit)
        {
            Elevators = new List<Elevator>();
            for (int i = 0; i < numberOfElevators; i++)
            {
                Elevators.Add(new Elevator(weightLimit));
            }

            Floors = new List<Floor>();
            for (int i = 0; i < numberOfFloors; i++)
            {
                Floors.Add(new Floor(i + 1));
            }
        }

        public void CallElevator(int floor)
        {
            var elevator = Elevators.Find(e => e.Direction == 0);
            if (elevator == null)
            {
                elevator = Elevators.OrderBy(e => Math.Abs(e.CurrentFloor - floor)).First();
            }
            elevator.Destination = floor;
            if (elevator.CurrentFloor > floor)
            {
                elevator.Direction = -1;
            }
            else
            {
                elevator.Direction = 1;
            }
        }

        public void SetPeopleWaiting(int floor, int people)
        {
            Floors[floor - 1].PeopleWaiting = people;
        }

        public void PrintStatus()
        {
            Console.WriteLine("Elevator Status:");
            foreach (var elevator in Elevators)
            {
                Console.WriteLine("Elevator {0}: Floor {1}, {2} people on board, {3}", elevator.Id, elevator.CurrentFloor, elevator.PeopleOnBoard, elevator.IsOccupied ? "Occupied" : "Not Occupied");
            }
            Console.WriteLine("Floor Status:");
            for (int i = 0; i < Floors.Count; i++)
            {
                Console.WriteLine("Floor {0}: {1} people waiting", i + 1, Floors[i].PeopleWaiting);
            }
        }

        public void Run()
        {
            while (true)
            {
                foreach (var elevator in Elevators)
                {
                    elevator.Move(this);
                }
                Console.WriteLine("Enter your command (set/call/board/disembark/status/exit): ");
                var command = Console.ReadLine();
                if (command == "exit")
                {
                    break;
                }
                else if (command.StartsWith("set"))
                {
                    var cmd = command.Split(' ');
                    if (cmd.Length != 3)
                    {
                        Console.WriteLine("Invalid command");
                        continue;
                    }
                    SetPeopleWaiting(int.Parse(cmd[1]), int.Parse(cmd[2]));
                }
                else if (command.StartsWith("call"))
                {
                    var cmd = command.Split(' ');
                    if (cmd.Length != 2)
                    {
                        Console.WriteLine("Invalid command");
                        continue;
                    }
                    CallElevator(int.Parse(cmd[1]));
                }
                else if (command.StartsWith("board"))
                {
                    var cmd = command.Split(' ');
                    if (cmd.Length != 4)
                    {
                        Console.WriteLine("Invalid command");
                        continue;
                    }
                    var elevator = Elevators.Find(e => e.Id == int.Parse(cmd[1]));
                    if (!elevator.IsOccupied)
                    {
                        elevator.board(this, int.Parse(cmd[2]), int.Parse(cmd[3]));
                    }
                    else
                    {
                        Console.WriteLine("Elevator {0} is occupied", elevator.Id);
                    }
                }
                else if (command.StartsWith("disembark"))
                {
                    var cmd = command.Split(' ');
                    if (cmd.Length != 4)
                    {
                        Console.WriteLine("Invalid command");
                        continue;
                    }
                    var elevator = Elevators.Find(e => e.Id == int.Parse(cmd[1]));
                    if (elevator.IsOccupied)
                    {
                        elevator.disembark(this, int.Parse(cmd[2]), int.Parse(cmd[3]));
                    }
                    else
                    {
                        Console.WriteLine("Elevator {0} is empty", elevator.Id);
                    }
                }
                else if (command == "status")
                {
                    PrintStatus();
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }
            }
        }



    }
}
