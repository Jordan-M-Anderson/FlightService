using System;
using FlightService.Data;

namespace FlightService
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightDAO dao = new FlightDAO();
            PassengerDAO pDAO = new PassengerDAO();
            DateTime arrival = new DateTime(2021, 4, 1, 5, 20, 53);
            DateTime departure = new DateTime(2021, 4, 1, 5, 20, 53);

            dao.DeleteFlight(6);
            //Flight flight = dao.GetFlight(6);
            //Console.WriteLine(flight.capacity);

            //Flight flight = new Flight(arrival, departure, "place1", "place2", 1);
            //dao.AddFlight(flight);
            //Console.WriteLine(flight.flightNum);

            //Passenger passenger = new Passenger("Jordan", "Software Dev", "j@skillstorm.com", 22, 6);
            //pDAO.AddPassenger(passenger);
            //Console.WriteLine(passenger.confirmationNum);

            //Passenger passenger = pDAO.GetPassenger(1);
            //passenger.name = "Jordan Anderson";
            //pDAO.UpdatePassenger(passenger);

            //Flight flight = dao.GetFlight(6);
            //flight.capacity = 100;
            //dao.UpdateFlight(flight);
        }
    }
}
