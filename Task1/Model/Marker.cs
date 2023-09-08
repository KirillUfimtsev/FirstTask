using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Model
{
    public class Marker : GMapMarker
    {
        public int? ID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Marker(PointLatLng pos) : base(pos) { }


        
    }
}
