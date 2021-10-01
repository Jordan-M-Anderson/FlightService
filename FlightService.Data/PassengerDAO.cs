using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightService.Data
{
    public class PassengerDAO : IPassengerDAO
    {
        private string connString = "Data Source=DESKTOP-KPRJHLO;Initial Catalog=FlightService;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IEnumerable<Passenger> GetPassengers() {

            List<Passenger> passengerList = new List<Passenger>();

            using (SqlConnection conn = new SqlConnection(connString)) {

                SqlCommand cmd = new SqlCommand("SELECT * FROM PASSENGERS", conn);
                try
                {
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Passenger hold = new Passenger(dataReader["name"].ToString(), dataReader["job"].ToString(), dataReader["email"].ToString(), Convert.ToInt32(dataReader["age"]), Convert.ToInt32(dataReader["flight_number"]));
                        hold.confirmationNum = Convert.ToInt32(dataReader["confirmation_number"]);
                        passengerList.Add(hold);
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally {
                    conn.Close();
                }

                return passengerList;
            }
        }


        public Passenger GetPassenger(int confirmationNum)
        {
            Passenger result = new Passenger();
            String query = "[dbo].[GetPassenger]";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@confirmationNum", confirmationNum);

                try
                {
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        result.confirmationNum = Convert.ToInt32(dataReader["confirmation_num"].ToString());
                        result.job = dataReader["job"].ToString();
                        result.email = dataReader["email"].ToString();
                        result.age = Convert.ToInt32(dataReader["age"].ToString());
                        result.flightNum = Convert.ToInt32(dataReader["flight_number"]);
                    }

                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally { 
                    conn.Close(); 
                }

                return result;
            }
        }

        public void AddPassenger(Passenger passenger) {
            int confirmationNum = 0;

            using (SqlConnection conn = new SqlConnection(connString)) {
                string query = "[dbo].[AddPassenger]";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", passenger.name);
                cmd.Parameters.AddWithValue("@job", passenger.job);
                cmd.Parameters.AddWithValue("@age", passenger.age);
                cmd.Parameters.AddWithValue("@email", passenger.email);
                cmd.Parameters.AddWithValue("flightNum", passenger.flightNum);

                try {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    confirmationNum = (int)cmd.Parameters["@confirmation_num"].Value;
                    passenger.confirmationNum = confirmationNum;
                } catch (SqlException e) {
                    Console.WriteLine(e.Message); 
                } finally { 
                    conn.Close(); 
                }
            }
        }

    }
}
