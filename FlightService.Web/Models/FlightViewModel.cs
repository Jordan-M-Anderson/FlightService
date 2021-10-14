using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Web.Models
{
    public class FlightViewModel
    {
        [Required]
        [Display(Name = "Flight Number")]
        public int flightNum { get; set; }

        [Required]
        [Display(Name = "Arrival Date")]
        public DateTime arrivalDate { get; set; }

        [Required]
        [Display(Name = "Departure Date")]
        public DateTime departureDate { get; set; }

        [Required]
        [Display(Name = "From")]
        public String fromAirport { get; set; }

        [Required]
        [Display(Name = "To")]
        public String toAirport { get; set; }

        [Required]
        [Display(Name = "Capacity")]
        public int capacity { get; set; }


    }
}
