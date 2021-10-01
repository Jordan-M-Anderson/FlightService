using System;
using FlightService.Data;

namespace FlightService
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightDAO dao = new FlightDAO();
            DateTime arrival = new DateTime(2021, 4, 1, 5, 20, 53);
            DateTime departure = new DateTime(2021, 4, 1, 5, 20, 53);

            Flight flight = new Flight(arrival, departure, "place1", "place2", 1);
            dao.AddFlight(flight);
            Console.WriteLine(flight.flightNum);
        }
    }
}
