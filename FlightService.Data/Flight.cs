using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightService.Data
{
    public class Flight
    {
        [Display(Name = "Flight Number")]
        public int flightNum { get; set; }

        [Display(Name = "Departure Date")]
        public DateTime depatureDate { get; set;}
        [Display(Name = "Arrival Date")]
        public DateTime arrivalDate { get; set; }
        [Display(Name = "From")]
        public String startAirport { get; set; }
        [Display(Name = "To")]
        public String endAirport { get; set; }
        [Display(Name = "Capacity")]
        public int capacity { get; set; }

        public Flight() { }

        public Flight(DateTime depatureDate, DateTime arrivalDate, 
            String startAirport, String endAirport, int capacity) {
            this.depatureDate = depatureDate;
            this.arrivalDate = arrivalDate;
            this.depatureDate = depatureDate;
            this.startAirport = startAirport;
            this.endAirport = endAirport;
        }
    }
}
