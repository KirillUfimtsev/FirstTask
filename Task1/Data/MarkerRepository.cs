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
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var m = new Marker(new GMap.NET.PointLatLng())
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

        public void addMarker(string latitude, string longitude)
        {
            conn = new DBUtils().GetDBConnection();

            latitude = latitude.Replace(',', '.');
            longitude = longitude.Replace(',', '.');

            using (conn) 
            using (SqlCommand cmd = new SqlCommand("INSERT INTO MARKER (Latitude,Longitude) VALUES " + $"({latitude}, {longitude})", conn))
            {
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                { }
            }
        }

        public void updateMarker(int? ID, double latitude, double longitude)
        {
            conn = new DBUtils().GetDBConnection();

            var lat = latitude.ToString().Replace(',', '.');
            var lng = longitude.ToString().Replace(',', '.');
            
            using (conn)
            using (SqlCommand cmd = new SqlCommand($"UPDATE MARKER set latitude = {lat},Longitude = {lng} WHERE ID = {ID}", conn))
            {
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                { }

            }
        }


        
    }
}
