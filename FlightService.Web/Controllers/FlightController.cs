using FlightService.Data;
using FlightService.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Web.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightDAO flightDAO;
        public FlightController(IFlightDAO flightDAO)
        {
            this.flightDAO = flightDAO;
        }
            
        public IActionResult Index()
        {
            IEnumerable<Flight> flights = flightDAO.GetFlights();
            //IEnumerable<Passenger> passengers = passengerDAO.GetPassengers();
            List<FlightViewModel> fModel = new List<FlightViewModel>();
            //List<PassengerViewModel> pModel = new List<PassengerViewModel>();

            foreach (var flight in flights)
            {
                FlightViewModel hold = new FlightViewModel
                {
                    flightNum = flight.flightNum,
                    departureDate = flight.depatureDate,
                    arrivalDate = flight.arrivalDate,
                    fromAirport = flight.startAirport,
                    toAirport = flight.endAirport,
                    capacity = flight.capacity
                };
                fModel.Add(hold);
            }
            return View(fModel);
        }
        public IActionResult Delete(int flightNum) {
            flightDAO.DeleteFlight(flightNum);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        public ActionResult Update(int flightNum)
        {
            Flight model = flightDAO.GetFlight(flightNum);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind] FlightViewModel flight)
        {
            if (ModelState.IsValid)
            {
                Flight newFlight = new Flight();
                newFlight.flightNum = flight.flightNum;
                newFlight.arrivalDate = flight.arrivalDate;
                newFlight.depatureDate = flight.departureDate;
                newFlight.startAirport = flight.fromAirport;
                newFlight.endAirport = flight.toAirport;
                newFlight.capacity = flight.capacity;
                flightDAO.UpdateFlight(newFlight);
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] FlightViewModel flight)
        {
            if (ModelState.IsValid)
            {
                Flight newFlight = new Flight();
                newFlight.arrivalDate = flight.arrivalDate;
                newFlight.depatureDate = flight.departureDate;
                newFlight.startAirport = flight.fromAirport;
                newFlight.endAirport = flight.toAirport;
                newFlight.capacity = flight.capacity;
                flightDAO.AddFlight(newFlight);

                return RedirectToAction("Index");
            }

            return View(flight);
        }
    }
}
