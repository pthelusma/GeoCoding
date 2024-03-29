﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GeoCodeSvc
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IGeoCode
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        GeoResponse GetGeoResponse(string address);
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class GeoLocation
    {
        [DataMember]
        public decimal Lat { get; set; }

        [DataMember]
        public decimal Lng { get; set; }
    }

    [DataContract]
    public class GeoGeometry
    {
        [DataMember]
        public GeoLocation Location { get; set; }
    }

    [DataContract]
    public class GeoResult
    {
        [DataMember]
        public string Formatted_Address { get; set; }

        [DataMember]
        public GeoGeometry Geometry { get; set; }
    }

    [DataContract]
    public class GeoResponse
    {
        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public GeoResult[] Results { get; set; }
    }

    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
