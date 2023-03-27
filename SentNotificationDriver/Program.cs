using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace SentNotificationDriver
{
    class Program
    {

        public static string ConnStr = "Data Source=rushkar-db-z.cwfpajxcr0v7.ap-south-1.rds.amazonaws.com;Initial Catalog=TaxiApp;Persist Security Info=True;User ID=sa;Password=*aA123123;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True";

        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            while (true)
            {
                try
                {
                    string q = "select * from [dbo].[Driver] where MsgRec = 1";
                    SqlDataAdapter ad = new SqlDataAdapter(q, ConnStr);
                    DataTable dt = new DataTable();
                    

                    ad.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        List<string> DeviceT = new List<string>();
                        List<string> MsgJsonRec = new List<string>();
                        Console.WriteLine("Getting Connection ...");

                        foreach (DataRow row in dt.Rows)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                DeviceT = dt.AsEnumerable()
                                              .Select(r => r.Field<string>("DeviceToken"))
                                              .ToList();

                                MsgJsonRec = dt.AsEnumerable()
                                              .Select(r => r.Field<string>("MsgJsonRes"))
                                              .ToList();

                                if (DeviceT.Count > 0)
                                {
                                    SendNotification(DeviceT, MsgJsonRec, row["id"].ToString());
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            Console.Read();
        }

        public static string SendNotification(List<string> DeviceT, List<string> Description, string Id)
        {
            string response = string.Empty;
            string serverKey = "AAAAN_NMX4c:APA91bEIAZqiwFjgXLVhqP-nHixTHPdPzBq3wKgwlvCNn7IlbujHJTdaRs4YTQ3v0xvqasflr3IXUsI9K__ryf6cCpHOT1b1_McY29wUWN9iUENAfUA-2ZBT95-GnBN3MKrNCYjNVwzd"; // Something very long

            HttpWebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send") as HttpWebRequest;

            tRequest.Method = "post";
            tRequest.ContentType = "application/json";

            var data = new
            {
                registration_ids = DeviceT,
                //to = deviceId,
                data = new
                {
                    body = Description,
                    title = "",
                    sound = "default",
                    mutable_contenct = true,
                    badge = 4,
                    data = new { }
                },
                mutable_contenct = true
            };
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(data);
            Byte[] byteArray = Encoding.UTF8.GetBytes(json);
            tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
            
            tRequest.ContentLength = byteArray.Length;
            string q = "";
            string S = "";
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (HttpWebResponse tResponse = tRequest.GetResponse() as HttpWebResponse)
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String sResponseFromServer = tReader.ReadToEnd();

                            SqlConnection Conn = new SqlConnection(ConnStr);
                            Conn.Open();

                                string updateIsSent = "UPDATE Driver SET MsgRec = 2 where Id = " + Convert.ToInt64(Id);
                                SqlCommand UpdateDENotificationcmd = new SqlCommand(updateIsSent, Conn);
                                UpdateDENotificationcmd.ExecuteNonQuery();

                            Conn.Close();
                            Console.WriteLine("Send successful!");
                        }
                    }
                }
            }
            return "";
        }
    }
}

// msg scenario in int value
// MsgRec = 0 :- its mean driver did't recevie any notification
// MsgRec = 1 :- its mean driver notification is on the way 
// MsgRec = 2 :- its mean driver notification recevied
// MsgRec = 3 :- its mean driver notification Accepted
// MsgRec = 4 :- its mean driver notification Rejected
