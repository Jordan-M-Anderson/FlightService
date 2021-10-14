using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Web.Models
{
    public class PassengerViewModel
    {
        [Required]
        [Display(Name = "Confirmation Number")]
        public int confirmationNum { get; set; }

        [Required]
        [Display(Name = "Name")]
        public String name { get; set; }

        [Required]
        [Display(Name = "Job")]
        public String job { get; set; }

        [Required]
        [Display(Name = "Email")]
        public String email { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int age { get; set; }
        [Required]
        [Display(Name = "Flight Number")]
        public int flightNum { get; set; }

    }
}
