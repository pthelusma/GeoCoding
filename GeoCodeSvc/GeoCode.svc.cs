using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GeoCodeSvc
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class GeoCode : IGeoCode
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public GeoResponse GetGeoResponse(string address)
        {
            GeoResponse geoResponse  = new GeoResponse();

            string url = "http://maps.googleapis.com/maps/api/geocode/" +
                "json?address=" + address + "&sensor=false";

            WebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                response = request.GetResponse();
                if (response != null)
                {
                    string str = null;
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            str = streamReader.ReadToEnd();
                        }
                    }

                    geoResponse = JsonConvert.DeserializeObject<GeoResponse>(str);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Clean up");
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }

            return geoResponse;
        }

    }
}
