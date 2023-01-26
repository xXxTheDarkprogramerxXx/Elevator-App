using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApplication
{
    class Floor
    {
        public int Number { get; set; }
        public int PeopleWaiting { get; set; }

        public Floor(int number)
        {
            Number = number;
            PeopleWaiting = 0;
        }
    }


}
