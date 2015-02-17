using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Xml;
using System.Data.SqlClient;
using System.Data;

using System.Web.Configuration;
using System.Web.Hosting;
namespace SafeBusLocationService
{
    public class Tracking : ITracking    
    {
        private DataAccess DAObject;

        //Sarat
        //http://www.c-sharpcorner.com/UploadFile/dhananjaycoder/four-steps-to-create-first-wcf-service-for-beginners/
        // for PDB file Missing
        //http://stackoverflow.com/questions/19053738/visual-studio-2012-website-publish-not-copying-pdb-files

        //how to test wcf service in visual studio 2012

        //http://www.csharptutorial.in/35/how-to-test-wcf-service-using-wcf-test-client-in-vs-2010



        public Tracking()
        {
            DAObject = new DataAccess();
        }

        /// <summary>
        /// For Login Check
        /// </summary>
        /// <param name="sUserName"></param>
        /// <param name="sPassword"></param>
        /// <returns></returns>
        public User Login(string sUserName, string sPassword, string sEstablishmentId)
        {
            User userDetails;
            string genKey;

            string authkey = DAObject.GetAuthKey(sUserName);
            if (authkey == "")
            {
                UserDetail user = DAObject.AuthenticateUser(sUserName, sPassword, sEstablishmentId);
                if (user.UserID > 0)
                {
                    //Generate new authKey
                    MD5 mdHash = new MD5CryptoServiceProvider();
                    mdHash.ComputeHash(ASCIIEncoding.ASCII.GetBytes("Safebus" + DateTime.Now.ToString()));
                    byte[] hashByte = mdHash.Hash;
                    StringBuilder strBuilder = new StringBuilder();
                    for (int i = 0; i < hashByte.Length; i++)
                    {
                        strBuilder.Append(hashByte[i].ToString("x2"));
                    }
                    genKey = strBuilder.ToString();

                    //ADD AUTHKEY
                    if (DAObject.AddLoginDetails(user.UserID, sUserName, genKey))
                    {
                       //Sarat Changes
                        logUserDetails("SuccessMessage", user.UserID.ToString(), sUserName,sEstablishmentId);
                        userDetails = new User { status = "success", message = "Successfully logged in", parent_name = user.ParentName, authKey = genKey };
                    }
                    else
                    {
                        logUserDetails("FailedServerError", user.UserID.ToString(), sUserName,sEstablishmentId);
                        userDetails = new User { status = "failed", message = "Server error", authKey = "" };
                    }
                }
                else
                {
                   logUserDetails("FailedInvalidUser", user.UserID.ToString(),sUserName,sEstablishmentId);
                    userDetails = new User { status = "failed", message = "Invalid Mobile number or Password", authKey = "" };
                }
            }
            else
            {
                UserDetail user = DAObject.AuthenticateUser(sUserName, sPassword,sEstablishmentId);
                if (user.UserID > 0)
                {
                    //Generate new authKey
                    MD5 mdHash = new MD5CryptoServiceProvider();
                    mdHash.ComputeHash(ASCIIEncoding.ASCII.GetBytes("SafeSafebus" + DateTime.Now.ToString()));
                    byte[] hashByte = mdHash.Hash;
                    StringBuilder strBuilder = new StringBuilder();
                    for (int i = 0; i < hashByte.Length; i++)
                    {
                        strBuilder.Append(hashByte[i].ToString("x2"));
                    }
                    genKey = strBuilder.ToString();

                    //UPDATE AUTHKEY
                    if (DAObject.UpdateLogin(user.UserID, genKey))
                    {
                        logUserDetails("SuccessMessage", user.UserID.ToString(), sUserName,sEstablishmentId);
                        userDetails = new User { status = "success", message = "Successfully logged in", parent_name = user.ParentName , authKey = genKey };
                    }
                    else
                    {
                        logUserDetails("FailedServerError", user.UserID.ToString(), sUserName,sEstablishmentId);
                        userDetails = new User { status = "failed", message = "Server error", authKey = "" };
                    }
                }
                else
                {
                    logUserDetails("FailedInvalidUser", user.UserID.ToString(), sUserName,sEstablishmentId);
                    userDetails = new User { status = "failed", message = "Invalid Mobile number or Password", authKey = "" };
                }
            }
            return userDetails;
        }

        private void logUserDetails(string messageStatus,string UserId,string Username,string EstablishmentId)

        {
            try
            {
                TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(HostingEnvironment.MapPath("~/Log/UserLog.xml"));
                XmlElement parentelement = xmldoc.CreateElement("UserLog");

                XmlElement messageStat= xmldoc.CreateElement("messageStatus");
                messageStat.InnerText = messageStatus;
                
                XmlElement UserName = xmldoc.CreateElement("UserName");
                UserName.InnerText = Username;
                XmlElement UserID = xmldoc.CreateElement("UserID");
                UserID.InnerText = UserId;
                XmlElement EstablishmentID = xmldoc.CreateElement("EstablishmentID");
                EstablishmentID.InnerText = EstablishmentId;
                XmlElement dateTime = xmldoc.CreateElement("DateTime");
                dateTime.InnerText = indianTime.ToString();
                parentelement.AppendChild(messageStat);
               
                parentelement.AppendChild(UserName);
                parentelement.AppendChild(UserID);
                parentelement.AppendChild(EstablishmentID);
                parentelement.AppendChild(dateTime);
                xmldoc.DocumentElement.AppendChild(parentelement);

                xmldoc.Save(HostingEnvironment.MapPath("~/Log/UserLog.xml"));

            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// For Getting Location Details of Buses
        /// </summary>
        /// <param name="authKey"></param>
        /// <returns></returns>
        public Location GetLocationDetails(string authKey)
        {
            List<Stop> visited;
            List<Stop> upcoming;
            Location locationDetails;
            Stop startPoint;
            Stop endPoint;
            List<TrackData> data = new List<TrackData>();

            try
            {
                //Get userID of user
                long lUserId = DAObject.GetUserId(authKey);

                if (lUserId > 0)
                {
                    // Get Devices For Parent
                    List<long> devices = DAObject.GetDevicesOfParent(lUserId);

                    // Get Active Trip ID
                    long activeTripId;

                    foreach (long device in devices)
                    {
                        activeTripId = DAObject.GetActiveTripId(device);

                        if (activeTripId > 0)
                        {
                            visited = DAObject.GetVisitedLocations(activeTripId);
                            upcoming = DAObject.GetUpcomingLocations(activeTripId);
                            startPoint = DAObject.GetStartPoint(activeTripId);
                            endPoint = DAObject.GetEndPoint(activeTripId);
                            
                            BusTrack track = DAObject.GetTrackDataForDevice(device);
                            data.Add
                                (
                                  new TrackData
                                  {
                                      bus_name = track.BusName,
                                      bus_status = "In a trip",
                                      start_location = startPoint,
                                      end_location = endPoint,
                                      bus_location = new LatLng
                                      {
                                          pLatitude = track.Lattitude,
                                          pLongitude = track.Longitude
                                      },
                                      visited_locations = visited,
                                      upcoming_locations = upcoming
                                  }
                                );

                        }
                        else
                        {
                            BusTrack track = DAObject.GetTrackDataForDevice(device);
                            data.Add
                                (
                                  new TrackData
                                  {
                                      bus_name = track.BusName,
                                      bus_status = "Not in trip",
                                      start_location = new Stop(),
                                      end_location = new Stop(),
                                      bus_location = new LatLng
                                      {
                                          pLatitude = track.Lattitude,
                                          pLongitude = track.Longitude
                                      },
                                      visited_locations = new List<Stop>(),
                                      upcoming_locations = new List<Stop>()
                                  }
                                );
                        }
                    }

                    locationDetails = new Location
                    {
                        status = "Success",
                        message = "Data fetch successfull",
                        data = data
                    };
                    return locationDetails;
                }
                else
                {
                    locationDetails = new Location
                    {
                      status ="failed",
                      message = "Invalid user",
                      data = new List<TrackData>()
                    };
                    return locationDetails;
                }
            }
            catch (Exception ex)
            {
                Location location = new Location
                {
                    status = "failed",
                    message = ex.Message,
                    data = new List<TrackData>()
                };
                return location;
            }
        }
    }
}
