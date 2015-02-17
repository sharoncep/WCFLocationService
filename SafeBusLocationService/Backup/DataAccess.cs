using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Collections;
using System.Data;

namespace SafeBusLocationService
{
    public class DataAccess
    {
        private DABase DBConn;

        public DataAccess()
        {
            DBConn = new DABase();
        }

        #region Authentication
        /// <summary>
        /// To Get Authentication Key
        /// </summary>
        /// <returns></returns>
        public string GetAuthKey(string sUserName)
        {
            try
            {
                Hashtable param = new Hashtable();
                param.Add("@UserName", sUserName);
                DataSet ds = DBConn.ExecuteSelect("GetAuthKeyParent", param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToString(ds.Tables[0].Rows[0]["AuthKey"]);
                }
                else
                    return "";
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// To Authenticate User
        /// </summary>
        /// <param name="sUserName"></param>
        /// <param name="sPassword"></param>
        /// <returns></returns>
        public UserDetail AuthenticateUser(string sUserName, string sPassword)
        {
            var userDetail = new UserDetail();

            try
            {
                Hashtable param = new Hashtable();
                param.Add("@UserName", sUserName);
                param.Add("@Password", sPassword);
                DataSet ds = DBConn.ExecuteSelect("AuthenticateParent", param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    userDetail = new UserDetail()
                    {
                        UserID = Convert.ToInt64(ds.Tables[0].Rows[0]["UserId"]),
                        ParentName = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"])
                    };
                    return userDetail;
                }
                else
                    return userDetail;
            }
            catch
            {
                return userDetail;
            }
        }

        /// <summary>
        /// To Update Login Details
        /// </summary>
        public bool UpdateLogin(long lUserId, string sauthKey)
        {
            try
            {
                Hashtable param = new Hashtable();
                param.Add("@UserId", lUserId);
                param.Add("@AuthKey", sauthKey);
                if (DBConn.ExecuteUpdate("UpdateMobLoginDetail", param) != 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// To Add Login Details
        /// </summary>
        /// <returns></returns>
        public bool AddLoginDetails(long lUserId, string sUserName, string sauthKey)
        {
            try
            {
                Hashtable param = new Hashtable();
                param.Add("@UserId", lUserId);
                param.Add("@UserName", sUserName);
                param.Add("@AuthKey", sauthKey);
                DataSet ds = DBConn.ExecuteSelect("AddLoginDetails", param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        } 
        #endregion


        /// <summary>
        /// To Get Devices Of Parent
        /// </summary>
        /// <param name="lUserId"></param>
        /// <returns></returns>
        public List<long> GetDevicesOfParent(long lUserId)
        {
            List<long> devices = new List<long>();
            Hashtable param = new Hashtable();
            param.Add("@UserId",lUserId);
            DataSet ds = DBConn.ExecuteSelect("GetDevicesOfParent",param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    devices.Add(Convert.ToInt64(row["DeviceId"]));
                }
                return devices;
            }
            else
                return devices;
        }

        /// <summary>
        /// To get Track Data For Device
        /// </summary>
        /// <param name="lDeviceId"></param>
        /// <returns></returns>
        public BusTrack GetTrackDataForDevice(long lDeviceId)
        {
            var busTrack = new BusTrack();

            Hashtable param = new Hashtable();
            param.Add("@DeviceID",lDeviceId);
            DataSet ds = DBConn.ExecuteSelect("GetTrackDataForDevice",param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                busTrack = new BusTrack()
                {
                    BusName = Convert.ToString(ds.Tables[0].Rows[0]["BusName"]),
                    Lattitude = Convert.ToString(ds.Tables[0].Rows[0]["Lattitude"]),
                    Longitude = Convert.ToString(ds.Tables[0].Rows[0]["Longitude"])
                };
                return busTrack;
            }
            else
                return busTrack;
        }

        /// <summary>
        /// Get Active Trip Id
        /// </summary>
        /// <param name="lDeviceId"></param>
        /// <returns></returns>
        public long GetActiveTripId(long lDeviceId)
        {
            Hashtable param = new Hashtable();
            param.Add("@DeviceID",lDeviceId);
            DataSet ds = DBConn.ExecuteSelect("GetActiveTripId",param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt64(ds.Tables[0].Rows[0]["TripId"]);
            }
            else
                return 0;
        }

        /// <summary>
        /// To Get Visited Locations
        /// </summary>
        /// <returns></returns>
        public List<Stop> GetVisitedLocations(long lTripId)
        {
            List<Stop> visitedLocations = new List<Stop>();

            Hashtable param = new Hashtable();
            param.Add("@TripId",lTripId);
            DataSet ds = DBConn.ExecuteSelect("GetVisitedLocations", param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    visitedLocations.Add(new Stop { pLatitude = Convert.ToString(row["Latitude"]), pLongitude = Convert.ToString(row["Longitude"]), location_name = Convert.ToString(row["StopName"]) });
                }
                return visitedLocations;
            }
            else
                return visitedLocations;
        }

        /// <summary>
        /// To Get Upcoming Locations
        /// </summary>
        /// <returns></returns>
        public List<Stop> GetUpcomingLocations(long lTripId)
        {
            List<Stop> upcomingLocations = new List<Stop>();

            Hashtable param = new Hashtable();
            param.Add("@TripId",lTripId);
            DataSet ds = DBConn.ExecuteSelect("GetUpcomingLocations", param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    upcomingLocations.Add(new Stop { pLatitude = Convert.ToString(row["Latitude"]), pLongitude = Convert.ToString(row["Longitude"]), location_name = Convert.ToString(row["StopName"]) });
                }
                return upcomingLocations;
            }
            else
                return upcomingLocations;
        }

        /// <summary>
        /// To Get UserID By AuthKey
        /// </summary>
        /// <param name="authKey"></param>
        /// <returns></returns>
        public long GetUserId(string authKey)
        {
            Hashtable param = new Hashtable();
            param.Add("@AuthKey",authKey);
            DataSet ds = DBConn.ExecuteSelect("GetUserIdByAuthKey",param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt64(ds.Tables[0].Rows[0]["UserId"]);
            }
            else
                return 0;
        }

        /// <summary>
        /// To Get Start Point
        /// </summary>
        /// <returns></returns>
        public Stop GetStartPoint(long lTripId)
        {
            Stop stops;

            Hashtable param = new Hashtable();
            param.Add("@TripId",lTripId);
            DataSet ds = DBConn.ExecuteSelect("GetStartPoint",param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                stops = new Stop
                {
                     location_name = Convert.ToString(ds.Tables[0].Rows[0]["StopName"]),
                     pLatitude  = Convert.ToString(ds.Tables[0].Rows[0]["Latitude"]),
                     pLongitude = Convert.ToString(ds.Tables[0].Rows[0]["Longitude"])
                };
                return stops;
            }
            else
                return new Stop();
        }

        /// <summary>
        /// To Get End Point
        /// </summary>
        /// <returns></returns>
        public Stop GetEndPoint(long lTripId)
        {
            Stop stops;

            Hashtable param = new Hashtable();
            param.Add("@TripId", lTripId);
            DataSet ds = DBConn.ExecuteSelect("GetEndPoint", param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                stops = new Stop
                {
                    location_name = Convert.ToString(ds.Tables[0].Rows[0]["StopName"]),
                    pLatitude = Convert.ToString(ds.Tables[0].Rows[0]["Latitude"]),
                    pLongitude = Convert.ToString(ds.Tables[0].Rows[0]["Longitude"])
                };
                return stops;
            }
            else
                return new Stop();
        }
    }
}