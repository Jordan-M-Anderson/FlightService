using Microsoft.AspNetCore.Mvc;
using FlightService.Data;
using FlightService.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Web.Controllers
{
    public class PassengerController : Controller
    {
        private readonly IPassengerDAO passengerDAO;

        public PassengerController(IPassengerDAO passengerDAO) {
            this.passengerDAO = passengerDAO;
        }

        public IActionResult Index()
        {
            IEnumerable<Passenger> passengers = passengerDAO.GetPassengers();
            List<PassengerViewModel> model = new List<PassengerViewModel>();

            foreach (var passenger in passengers)
            {
                PassengerViewModel temp = new PassengerViewModel
                {
                    confirmationNum = passenger.confirmationNum,
                    flightNum = passenger.flightNum,
                    name = passenger.name,
                    email = passenger.email,
                    job = passenger.job,
                    age = passenger.age
                };

                model.Add(temp);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] PassengerViewModel passenger)
        {
            if (ModelState.IsValid)
            {
                Passenger newPassenger = new Passenger();
                newPassenger.name = passenger.name;
                newPassenger.job = passenger.job;
                newPassenger.email = passenger.email;
                newPassenger.age = passenger.age;
                newPassenger.flightNum = passenger.flightNum;
                passengerDAO.AddPassenger(newPassenger);
                return RedirectToAction("Index");
            }

            return View(passenger);
        }

        public IActionResult Delete(int confirmationNum)
        {
            passengerDAO.DeletePassenger(confirmationNum);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        public ActionResult Update(int confirmationNum)
        {
            Passenger model = passengerDAO.GetPassenger(confirmationNum);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind] PassengerViewModel passenger)
        {
            if (ModelState.IsValid)
            {
                Passenger newPassenger = new Passenger();
                newPassenger.confirmationNum = passenger.confirmationNum;
                newPassenger.flightNum = passenger.flightNum;
                newPassenger.name = passenger.name;
                newPassenger.age = passenger.age;
                newPassenger.email = passenger.email;
                newPassenger.job = passenger.job;
                passengerDAO.UpdatePassenger(newPassenger);
                return RedirectToAction("Index");
            }
            return View(passenger);
        }
    }
}

