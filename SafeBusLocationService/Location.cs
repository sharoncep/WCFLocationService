using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SafeBusLocationService
{
    [DataContract]
    public class Location
    {
        [DataMember]
        public string status { get; set; }

        [DataMember]
        public string message { get; set; }

        [DataMember]
        public List<TrackData> data { get; set; }
    }

    public class TrackData
    {
        public string bus_name { get; set; }
        public string bus_status { get; set; }
        public LatLng bus_location { get; set; }
        public Stop start_location { get; set; }
        public Stop end_location { get; set; }
        public List<Stop> visited_locations { get; set; }
        public List<Stop> upcoming_locations { get; set; }
    }

    public class LatLng
    {
        public string pLatitude { get; set; }
        public string pLongitude { get; set; }
    }

    public class Stop
    {
        public string pLatitude { get; set; }
        public string pLongitude { get; set; }
        public string location_name { get; set; }
    }
}