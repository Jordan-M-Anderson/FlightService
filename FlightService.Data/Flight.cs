using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightService.Data
{
    public class Flight
    {
        public int flightNum { get; set; }
        public DateTime depatureDate { get; set;}
        public DateTime arrivalDate { get; set; }
        public String startAirport { get; set; }
        public String endAirport { get; set; }
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
