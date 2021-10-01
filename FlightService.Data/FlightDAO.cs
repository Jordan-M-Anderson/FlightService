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
            String query = "SELECT * FROM FLIGHTS WHERE flight_number = @flightNum";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flightNum", flightNum);
                try { 
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read()) {
                        result.flightNum = Convert.ToInt32(dataReader["flight_number"]);
                        result.arrivalDate = Convert.ToDateTime(dataReader["arrival_date"]);
                        result.depatureDate = Convert.ToDateTime(dataReader["departure_date"]);
                        result.startAirport = dataReader["start_airport"].ToString();
                        result.endAirport = dataReader["end_airport"].ToString();
                        result.capacity = Convert.ToInt32(dataReader["capacity"]);
                    }
                } catch (SqlException e) {
                    Console.WriteLine(e.Message); 
                } finally { 
                    conn.Close(); 
                }
            }
            return result;
        }

        public void AddFlight(Flight flight) {
            int flightNum = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                String query = "[dbo].[AddFlight]";

                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@arrivalDate", flight.arrivalDate);
                cmd.Parameters.AddWithValue("@departureDate", flight.depatureDate);
                cmd.Parameters.AddWithValue("@startAirport", flight.startAirport);
                cmd.Parameters.AddWithValue("@endAirport", flight.endAirport);
                cmd.Parameters.AddWithValue("@capacity", flight.capacity);
                cmd.Parameters.Add("@flightNum", SqlDbType.Int).Direction = ParameterDirection.Output;
                try { 
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    flightNum = (int)cmd.Parameters["@flightNum"].Value;
                    flight.flightNum = flightNum;
                } catch (SqlException e) { 
                    Console.WriteLine(e.Message); 
                } finally {
                    conn.Close(); 
                }
            }
        }
    }
}
