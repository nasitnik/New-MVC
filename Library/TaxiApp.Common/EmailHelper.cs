﻿namespace TaxiApp.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Web.Hosting;
    using System.Web.Script.Serialization;
    using Twilio;
    using Twilio.Rest.Api.V2010.Account;

    public class EmailHelper
    {
        /// <summary>
        /// Sending An Email with master mail template
        /// </summary>
        /// <param name="mailFrom">Mail From</param>
        /// <param name="mailTo">Mail To</param>
        /// <param name="mailCC">Mail CC</param>
        /// <param name="mailBCC">Mail BCC</param>
        /// <param name="subject">Subject of mail</param>
        /// <param name="body">Body of mail</param>
        /// <param name="attachment">Attachment for the mail</param>
        /// <param name="emailType">Email Type</param>
        /// <returns>return send status</returns>


        public static void SendPushNotification(string Id, string bodyt, string titlet)
        {
            string response;
            try
            {
                if (string.IsNullOrEmpty(Id) == true)
                {
                    throw new Exception("");
                }
                string serverKey = Configurations.ServerKey;
                string senderId = Configurations.SenderId;
                string deviceId = Id;

                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");

                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = bodyt,//"Your job Status has been changed",
                        title = titlet,//"Fitting job has been completed.",
                        sound = "Enabled"
                    }
                };

                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                response = sResponseFromServer;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            //if (moblie != null && moblie != string.Empty)
            //{
            //    SendMsgViaTwilio(titlet + " - " + bodyt, moblie);
            //}

            //AdminSend("bereket@auroratechafrica.com", "", "", titlet, bodyt);
        }

        public static bool SendPasswordEmail(string email, string password, string fullname)
        {
            //demo
            string body = "";
            using (StreamReader reader = new StreamReader(HostingEnvironment.MapPath("~/EmailTemplate/PasswordTemplate.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("@welcometext", "Welcome to Bondinn");
            body = body.Replace("@message", "Your temporary auto generated password is");
            body = body.Replace("@password", password);
            body = body.Replace("@fullname", fullname);
            body = body.Replace("@content", "Please reset your password for security purposes.");
            bool reason = EmailHelper.Send(email, "", "", email, body);
            return reason;
        }


        public static bool SendEmail(string toEmail, string fullname, string message)
        {
            string body = "";
            using (StreamReader reader = new StreamReader(HostingEnvironment.MapPath("~/EmailTemplate/EmailTemplate.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("@welcometext", "Welcome to Beauty Book");
            //body = body.Replace("@verifiedurl", Configurations.urlEndpoint + verifiedurl);
            body = body.Replace("@fullname", fullname);
            body = body.Replace("@message", message);
            bool reason = EmailHelper.Send(toEmail, "", "", fullname, body);
            return reason;
        }

        public static bool Send(string mailTo, string mailCC, string mailBCC, string subject, string body, List<byte[]> attachmentFile = null, List<string> attachmentName = null)
        {
            Boolean issent = true;
            string mailFrom;
            mailFrom = Configurations.FromEmailAddress;
            mailBCC = Configurations.BccEmailAddress;
            try
            {
                if (!string.IsNullOrWhiteSpace(mailFrom) && !string.IsNullOrWhiteSpace(mailTo))
                {
                    MailMessage mailMesg = new MailMessage();
                    SmtpClient objSMTP = new SmtpClient();

                    objSMTP.Host = Configurations.EmailHost;

                    objSMTP.EnableSsl = Convert.ToBoolean(Configurations.EnableSsl);

                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();

                    NetworkCred.UserName = Configurations.EmailUserName; //reading from web.config  

                    NetworkCred.Password = Configurations.EmailPassword; //reading from web.config  

                    objSMTP.UseDefaultCredentials = true;

                    objSMTP.Credentials = new System.Net.NetworkCredential(NetworkCred.UserName, NetworkCred.Password);

                    objSMTP.Port = int.Parse(Configurations.Port);

                    mailMesg.From = new System.Net.Mail.MailAddress(mailFrom);
                    mailMesg.To.Add(mailTo);

                    if (!string.IsNullOrEmpty(mailCC))
                    {
                        string[] mailCCArray = mailCC.Split(';');
                        foreach (string email in mailCCArray)
                        {
                            mailMesg.CC.Add(email);
                        }
                    }

                    if (!string.IsNullOrEmpty(mailBCC))
                    {
                        mailBCC = mailBCC.Replace(";", ",");
                        mailMesg.Bcc.Add(mailBCC);
                    }

                    if (attachmentFile != null && attachmentName != null)
                    {
                        byte[][] Files = attachmentFile.ToArray();
                        string[] Names = attachmentName.ToArray();
                        if (Files != null)
                        {
                            for (int i = 0; i < Files.Length; i++)
                            {
                                mailMesg.Attachments.Add(new Attachment(new MemoryStream(Files[i]), Names[i]));
                            }
                        }
                    }

                    mailMesg.Subject = subject;
                    mailMesg.Body = body;
                    mailMesg.IsBodyHtml = true;

                    try
                    {
                        objSMTP.Send(mailMesg);
                        issent = true;
                        return issent;
                    }
                    catch (Exception ex)
                    {
                        mailMesg.Dispose();
                        mailMesg = null;
                        //CommonService.Log(e);
                        issent = false;
                        return issent;
                    }
                    finally
                    {
                        mailMesg.Dispose();
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        //public static bool SendEmail(string toEmail, string subject, string fullname, string message, string loginurl, string note, bool isWelcomeEmail)
        //{
        //    string body = "";
        //    using (StreamReader reader = new StreamReader(HostingEnvironment.MapPath("~/EmailTemplate/EmailTemplate.html")))
        //    {
        //        body = reader.ReadToEnd();
        //    }
        //    if (isWelcomeEmail == false)
        //    {
        //        body = body.Replace("@welcometext", "Greetings from Bondinn.");
        //    }
        //    else
        //    {
        //        body = body.Replace("@welcometext", "Welcome to Bondinn");
        //    }
        //    body = body.Replace("@fullname", fullname);
        //    body = body.Replace("@message", message);
        //    body = body.Replace("@loginurl", Configurations.BaseUrl + loginurl);
        //    body = body.Replace("@note", note);


        //    bool reason = EmailHelper.Send(toEmail, "", "", subject, body);
        //    return reason;
        //}

        /// <summary>
        /// Method is used to Validate Email
        /// </summary>
        /// <param name="fromEmail">From email List</param>
        /// <param name="toEmail">To Email list</param>
        /// <returns>Returns validation result</returns>
        private static bool ValidateEmail(string fromEmail, string toEmail)
        {
            bool isValid = true;
            if (!IsEmail(fromEmail))
            {
                isValid = false;
            }

            if (!string.IsNullOrEmpty(toEmail))
            {
                toEmail = toEmail.Replace(" ", string.Empty);
                string[] emailList = null;
                try
                {
                    emailList = toEmail.Split(',');
                }
                catch
                {
                    isValid = false;
                }

                if (emailList != null && emailList.Count() > 0)
                {
                    foreach (string email in emailList)
                    {
                        if (!IsEmail(email))
                        {
                            isValid = false;
                        }
                    }
                }
                else
                {
                    isValid = false;
                }
            }
            else
            {
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check email string is Email or not
        /// </summary>
        /// <param name="email">Email to verify</param>
        /// <returns>return email validation result</returns>
        private static bool IsEmail(string email)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string SendMsgViaTwilio(string msgBody, string mobileno)
        {
            string status = "FAIL";
            try
            {
                string accountSid = Configurations.TwilioAccountSid;
                string authToken = Configurations.TwilioAuthToken;
                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                  body: msgBody,     // replace with Body
                  to: new Twilio.Types.PhoneNumber(mobileno),   // replace with customer number 
                  from: new Twilio.Types.PhoneNumber(Configurations.FromMobileNumber) // +13254201234 //
              );
                status = "SUCCESS";
            }
            catch (Exception ex)
            {
                status = "FAIL" + ex.Message;
            }

            return status;
        }
    }
}
