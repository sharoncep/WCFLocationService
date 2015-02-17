﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SafeBusLocationService
{
    [ServiceContract]
    public interface ITracking
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Login?UserName={UserName}&Password={Password}&Est_id={EstablishmentId}")]
        User Login(string UserName , string Password,string EstablishmentId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetLocationDetails?authKey={authKey}")]
        Location GetLocationDetails(string authKey);
    }
}
