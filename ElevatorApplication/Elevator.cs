using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApplication
{
    class Elevator
    {
        public int Id { get; set; }
        public int CurrentFloor { get; set; }
        public int Direction { get; set; }
        public int PeopleOnBoard { get; set; }
        public int WeightLimit { get; set; }
        public int Destination { get; set; }
        public bool IsOccupied { get { return PeopleOnBoard > 0; } }

        public Elevator(int weightLimit)
        {
            Id = new Random().Next(1, 1000);
            CurrentFloor = 1;
            Direction = 1;
            PeopleOnBoard = 0;
            WeightLimit = weightLimit;
            //IsOccupied = false;
        }

        public void Move(ElevatorSystem system)
        {
            if (Direction != 0 && Destination <= system.Floors.Count && Destination > 0)
            {
                CurrentFloor += Direction;
                if (CurrentFloor == Destination)
                {
                    disembark(system, CurrentFloor, PeopleOnBoard);
                    PeopleOnBoard = 0;
                    Direction = 0;
                }
            }
        }


        public bool CanBoardPeople(int numberOfPeople)
        {
            return (PeopleOnBoard + numberOfPeople) <= WeightLimit;
        }
        public void board(ElevatorSystem system, int floor, int numberOfPeople)
        {
            if (CanBoardPeople(numberOfPeople))
            {
                PeopleOnBoard += numberOfPeople;
                system.SetPeopleWaiting(floor, system.Floors[floor - 1].PeopleWaiting - numberOfPeople);
            }
            else
            {
                Console.WriteLine("Cannot board {0} people, weight limit exceeded", numberOfPeople);
            }
        }

        public void disembark(ElevatorSystem system, int floor, int numberOfPeople)
        {
            PeopleOnBoard -= numberOfPeople;
            system.SetPeopleWaiting(floor, system.Floors[floor - 1].PeopleWaiting + numberOfPeople);
        }

    }
}
