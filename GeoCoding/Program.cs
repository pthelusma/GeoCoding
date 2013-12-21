using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using GeoCoding.GeoCodeRef;

namespace GeoCoderJson
{
    class Program
    {
        public class GeoLocation
        {
            public decimal Lat { get; set; }
            public decimal Lng { get; set; }
        }

        public class GeoGeometry
        {
            public GeoLocation Location { get; set; }
        }

        public class GeoResult
        {
            public string Formatted_Address { get; set; }
            public GeoGeometry Geometry { get; set; }
        }

        public class GeoResponse
        {
            public string Status { get; set; }
            public GeoResult[] Results { get; set; }
        }

        static void Main(string[] args)
        {

            GeoCodeClient client = new GeoCodeClient();

            var gr = client.GetGeoResponse("02126");

            string sjdkldj = client.GetData(5);

            if(gr.Status == "OK")
            {
                int count = gr.Results.Length;

                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("Lat: {0}", gr.Results[i].Geometry.Location.Lat);
                    Console.WriteLine("Lng: {0}", gr.Results[i].Geometry.Location.Lng);
                    Console.WriteLine("Formatted Address: {0}", gr.Results[i].Formatted_Address);
                }
            }
            else
            {
                Console.WriteLine("JSON response failed, status is '{0}'", gr.Status);
            }

            Console.WriteLine(sjdkldj);
            
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}