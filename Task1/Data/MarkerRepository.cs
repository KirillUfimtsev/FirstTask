using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Model;

namespace Task1.Data
{

    public class MarkerRepository
    {
        SqlConnection conn = new DBUtils().GetDBConnection();
        public Marker[] getAllMarkers()
        {
            List<Marker> markers = new List<Marker>();
            
            using (conn)
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Marker", conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            var m = new Marker()
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                Latitude = reader.GetDouble(reader.GetOrdinal("Latitude")),
                                Longitude = reader.GetDouble(reader.GetOrdinal("Longitude"))
                            };
                            markers.Add(m);
                        }
                    }
                }
            }
            return markers.ToArray();
        }

        public void addMarker(double latitude,double longitude)
        {
            conn = new DBUtils().GetDBConnection();
            using (conn) 
            using (SqlCommand cmd = new SqlCommand("INSERT INTO MARKER VALUES " + $"({latitude}, {longitude})", conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                try
                {
                    if (cmd.ExecuteNonQuery() > 0)
                        Console.WriteLine("INSERT statement successful");
                    else
                        Console.WriteLine("Insert statement FAILED!");
                }
                catch
                {
                    Console.WriteLine("Error occurred while attempting INSERT.");
                }
                
            }

        }


        private static Marker[] markers = new Marker[]
        {
            new Marker()
            {
                // Moscow
                ID = 1,
                Latitude= 55.75393,
                Longitude= 37.620795
            },

            new Marker()
            {
                // Ermitaj
                ID = 2,
                Latitude= 59.9409876,
                Longitude= 30.3129961
            },
            new Marker()
            {
                // Zimniy
                ID = 3,
                Latitude= 59.94028,
                Longitude= 30.31389,
            },

            new Marker()
            {
                // Lenina
                ID = 4,
                Latitude= 55.030278,
                Longitude= 82.921389,
            }



        };
    }
}
