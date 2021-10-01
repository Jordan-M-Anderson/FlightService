using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightService.Data
{
    public interface IFlightDAO
    {
        public IEnumerable<Flight> GetFlights();
        public Flight GetFlight(int flightNum);
        public void AddFlight(Flight flight);
    }
}
