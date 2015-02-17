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


namespace SafeBusLocationService
{
    public class Tracking : ITracking    
    {
        private DataAccess DAObject;

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
        public User Login(string sUserName , string sPassword)
        {
            User userDetails;
            string genKey;

            string authkey = DAObject.GetAuthKey(sUserName);
            if (authkey == "")
            {
                UserDetail user = DAObject.AuthenticateUser(sUserName, sPassword);
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
                        userDetails = new User { status = "success", message = "Successfully logged in", parent_name = user.ParentName, authKey = genKey };
                    }
                    else
                    {   
                        userDetails = new User { status = "failed", message = "Server error", authKey = "" };
                    }
                }
                else
                {
                    userDetails = new User { status = "failed", message = "Invalid userName or password", authKey = "" };
                }
            }
            else
            {
                UserDetail user = DAObject.AuthenticateUser(sUserName, sPassword);
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
                        userDetails = new User { status = "success", message = "Successfully logged in", parent_name = user.ParentName , authKey = genKey };
                    }
                    else
                    {
                        userDetails = new User { status = "failed", message = "Server error", authKey = "" };
                    }
                }
                else
                {
                    userDetails = new User { status = "failed", message = "Invalid userName or password", authKey = "" };
                }
            }
            return userDetails;
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
