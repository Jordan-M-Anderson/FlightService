using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightService.Data
{
    public class Passenger
    {
        public int confirmationNum { get; set; }
        public String name { get; set; }
        public String job { get; set; }
        public String email { get; set; }
        public int age { get; set; }
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
