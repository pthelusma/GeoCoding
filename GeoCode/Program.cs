using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoCoding;
using GeoCoding.Google;
using System.Diagnostics;

namespace GeoCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiKey = "648173182770.apps.googleusercontent.com";

            IGeoCoder geoCoder = new GoogleGeoCoder();
            IEnumerable<Address> addresses = geoCoder.GeoCode("26 Bluff St, Salem, NH 03079");

            foreach (var address in addresses)
            {
                Debug.Print(address.Coordinates.Latitude.ToString());
                Debug.Print(address.Coordinates.Longitude.ToString());
            }
        }
    }
}
