using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightService.Data
{
    public class FlightDAO : IFlightDAO
    {
        private string connString = "Data Source=DESKTOP-KPRJHLO;Initial Catalog=FlightService;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public IEnumerable<Flight> GetFlights() {
            List<Flight> flightList = new List<Flight>();
            using (SqlConnection conn = new SqlConnection(connString)) {
                SqlCommand cmd = new SqlCommand("SELECT * FROM FLIGHTS", conn);
                try {
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read()) {
                        Flight hold = new Flight();
                        hold.flightNum = Convert.ToInt32(dataReader["flight_number"]);
                        hold.arrivalDate = Convert.ToDateTime(dataReader["arrival_date"]);
                        hold.depatureDate = Convert.ToDateTime(dataReader["departure_date"]);
                        hold.startAirport = dataReader["start_airport"].ToString();
                        hold.endAirport = dataReader["end_airport"].ToString();
                        hold.capacity = Convert.ToInt32(dataReader["capacity"]);

                        flightList.Add(hold);
                    }
                } catch (SqlException e) {
                    Console.WriteLine(e.Message);
                } finally { 
                    conn.Close(); 
                }

            }
                return flightList;
        }

        public Flight GetFlight(int flightNum) {
            Flight result = new Flight();
            String query = "[dbo].[GetFlight]";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flightNum", flightNum);
                try { 
                    conn.Open(); 
                } catch (SqlException e) {
                    Console.WriteLine(e.Message); 
                } finally { 
                    conn.Close(); 
                }
            }
            return result;
        }
    }
}
