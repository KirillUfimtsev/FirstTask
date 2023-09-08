using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Model
{
    public class Marker
    {
        public int? ID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Marker(int id, double latitude, double longitude)
        {
            ID = id;
            Latitude = latitude;
            Longitude = longitude;
        }

        public Marker()
        {
        }
    }
}
