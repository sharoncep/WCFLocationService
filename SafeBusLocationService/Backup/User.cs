using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SafeBusLocationService
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string status { get; set; }

        [DataMember]
        public string message { get; set; }

        [DataMember]
        public string authKey { get; set; }

        [DataMember]
        public string parent_name { get; set; }
    }
}