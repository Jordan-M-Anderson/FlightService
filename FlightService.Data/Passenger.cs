using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightService.Data
{
    public class Passenger
    {
        public int confirmationNum { get; set; }
        [Display(Name = "Name")]
        public String name { get; set; }
        [Display(Name = "Job")]
        public String job { get; set; }
        [Display(Name = "Email")]
        public String email { get; set; }
        [Display(Name = "Age")]
        public int age { get; set; }
        [Display(Name = "Flight Number")]
        public int flightNum { get; set; }

        public Passenger() { }

        public Passenger(String name, String job, String email, int age, int flightNum) {
            this.name = name;
            this.job = job;
            this.email = email;
            this.age = age;
            this.flightNum = flightNum;
        }
    }
}
