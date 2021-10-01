using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightService.Data
{
    interface IPassengerDAO
    {
        public IEnumerable<Passenger> GetPassengers();
        public Passenger GetPassenger(int confirmationNum);
        public void AddPassenger(Passenger passenger);
    }
}
