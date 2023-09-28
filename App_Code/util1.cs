using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Text;

/// <summary>
/// Summary description for util
/// </summary>
public class util1
{
    public util1()
    {
        //
        // TODO: Add constructor logic here
        //
    }

}

public class SMSAdapter
{
    //
    public SMSAdapter()
    {
    }

    //adapter1.sendSingleSMS1 ("DITMP-TBCBPL","Mptbc@123","TBCBPL","9303109927","Testing" ); 
    static String username = "username";
    static String password = "password";
    //static String senderid = "senderid";
    //static String message = "message";
    //static String mobileNo = "9856XXXXX";
    //static String mobileNos = "9856XXXXX, 9856XXXXX ";
    //static String scheduledTime = "20110819 13:26:00";
    static HttpWebRequest request;
    static Stream dataStream;

    // Method for sending single SMS.

    public void sendMessage(
        String mobileNo, String message)
    {

        String username = "DITMP-TBCBPL"; String password = "Mptbc@123"; String senderid = "TBCBPL";
        request = (HttpWebRequest)WebRequest.Create("http://msdgweb.mgov.gov.in/esms/sendsmsrequest");
        request.ProtocolVersion = HttpVersion.Version10;
        //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
        ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
        request.Method = "POST";

        sendSingleSMS(username, password, senderid, mobileNo, message);


    }
    public void sendSingleSMS1(String username, String password, String senderid,
        String mobileNo, String message)
    {


        request = (HttpWebRequest)WebRequest.Create("http://msdgweb.mgov.gov.in/esms/sendsmsrequest");
        request.ProtocolVersion = HttpVersion.Version10;
        //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
        ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
        request.Method = "POST";

        sendSingleSMS(username, password, senderid, mobileNo, message);


    }

    public static void sendSingleSMS(String username, String password, String senderid,
        String mobileNo, String message)
    {
        String smsservicetype = "singlemsg"; //For single message.
        String query = "username=" + HttpUtility.UrlEncode(username) +
            "&password=" + HttpUtility.UrlEncode(password) +
            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
            "&content=" + HttpUtility.UrlEncode(message) +
            "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
            "&senderid=" + HttpUtility.UrlEncode(senderid);

        byte[] byteArray = Encoding.ASCII.GetBytes(query);
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteArray.Length;

        dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
        WebResponse response = request.GetResponse();
        String Status = ((HttpWebResponse)response).StatusDescription;
        dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
        response.Close();
    }


    //private const string referalUrl = "http://203.212.64.30/CapacityBuilder/PushSMS.aspx";
    // private const string referalUrl = "http://203.212.64.15/genericpushnew/pushsms.aspx";
    //private const string referalUrl = "http://vtermination.com/sendhttp.php";
   private const string referalUrl = "http://services.mpgov.gov.in";
    //private string username;
    public string Username
    {
        get { return username; }
        set { username = value; }
    }

   // private string password;
    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    public SMSResponse Send(SMSMessage message)
    {

        WebClient wc = new WebClient();
        wc.QueryString.Add("username", Username);
        wc.QueryString.Add("password", Password);
        wc.QueryString.Add("to", message.recipient);
        wc.QueryString.Add("from", "mptbc");
        wc.QueryString.Add("text", message.message);
        ////wc.QueryString.Add("userid", Username);
        ////wc.QueryString.Add("password", Password);
        ////wc.QueryString.Add("mobileno", message.recipient);
        ////wc.QueryString.Add("masking", "scratch");
        ////wc.QueryString.Add("message", message.message);
        //if (!message.from == string.Empty) wc.QueryString.Add("from", message.from);

        Stream responseStream = wc.OpenRead(referalUrl);
        StreamReader sr = new StreamReader(responseStream);
        string responseString = sr.ReadToEnd();

        SMSResponse response1 = new SMSResponse();

        if (responseString == "Null") response1.invalidCredentials = true;

        if (!response1.invalidCredentials)
        {
            if (responseString.ToString() == "false: Invalid Mobile Number")
                response1.success = false;
            else
                try
                {
                    response1.success = Convert.ToBoolean(responseString);
                }
                catch
                {
                    response1.success = true;
                }
        }

        response1.response = responseString;

        sr.Close();
        responseStream.Close();
        return response1;
    }

}

public struct SMSMessage
{
    public string recipient;
    public string message;
    //public string fromno = string.Empty;
}

public struct SMSResponse
{
    public bool success;
    public bool invalidCredentials;
    public string response;
}

public class MailHelper
{
    //static String username = "username";
    //static String password = "password";
    //static String senderid = "senderid";
    //static String message = "message";
    //static String mobileNo = "9856XXXXX";
    //static String mobileNos = "9856XXXXX, 9856XXXXX ";
    //static String scheduledTime = "20110819 13:26:00";
    static HttpWebRequest request;
    static Stream dataStream;
    SMSAdapter adapter1 = new SMSAdapter();
    public void sendMessage(
       String mobileNo, String message)
    {

        String username = "DITMP-TBCBPL"; String password = "Mptbc@123"; String senderid = "TBCBPL";
        request = (HttpWebRequest)WebRequest.Create("http://msdgweb.mgov.gov.in/esms/sendsmsrequest");
        request.ProtocolVersion = HttpVersion.Version10;
        //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
        ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
        request.Method = "POST";

        sendSingleSMS(username, password, senderid, mobileNo, message);


    }
    public static void sendSingleSMS(String username, String password, String senderid,
        String mobileNo, String message)
    {
        String smsservicetype = "singlemsg"; //For single message.
        String query = "username=" + HttpUtility.UrlEncode(username) +
            "&password=" + HttpUtility.UrlEncode(password) +
            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
            "&content=" + HttpUtility.UrlEncode(message) +
            "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
            "&senderid=" + HttpUtility.UrlEncode(senderid);

        byte[] byteArray = Encoding.ASCII.GetBytes(query);
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteArray.Length;

        dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
        WebResponse response = request.GetResponse();
        String Status = ((HttpWebResponse)response).StatusDescription;
        dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
        response.Close();
    }

    //public void sendMessage(string mobile, string message)
    //{
    //    string authKey = "61806AUeKGpgofJ52c4fe03";
    //    //Multiple mobiles numbers seperated by comma
    //    string mobileNumber = "9893176989";
    //    //Sender ID,While using route4 sender id should be 6 characters long.
    //    string senderId = "TBCBPL";
    //    //Your message to send, Add URL endcoding here.
    //    // string message = HttpUtility.UrlEncode("Test message");

    //    //Prepare you post parameters
    //    StringBuilder sbPostData = new StringBuilder();
    //    sbPostData.AppendFormat("authkey={0}", authKey);
    //    sbPostData.AppendFormat("&mobiles={0}", mobile);
    //    sbPostData.AppendFormat("&message={0}", message);
    //    sbPostData.AppendFormat("&sender={0}", senderId);
    //    sbPostData.AppendFormat("&route={0}", "4");
    //    SMSResponse response1 = new SMSResponse();
    //    try
    //    {

    //        //Call Send SMS API
    //        string sendSMSUri = "http://msdgweb.mgov.gov.in/esms/sendsmsrequest";
    //        //Create HTTPWebrequest
    //        System.Net.HttpWebRequest httpWReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(sendSMSUri);
    //        //Prepare and Add URL Encoded data
    //        UTF8Encoding encoding = new UTF8Encoding();
    //        byte[] data = encoding.GetBytes(sbPostData.ToString());
    //        //Specify post method
    //        httpWReq.Method = "POST";
    //        httpWReq.ContentType = "application/x-www-form-urlencoded";
    //        httpWReq.ContentLength = data.Length;
    //        using (Stream stream = httpWReq.GetRequestStream())
    //        {
    //            stream.Write(data, 0, data.Length);
    //        }
    //        //Get the response
    //        System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)httpWReq.GetResponse();
    //        StreamReader reader = new StreamReader(response.GetResponseStream());
    //        string responseString = reader.ReadToEnd();
    //        if (responseString.Length > 30)
    //        {
    //            response1.success = true;
    //            response1.response = "Sucess";
    //        }
    //        //Close the response
    //        reader.Close();
    //        response.Close();
    //    }
    //    catch (SystemException ex)
    //    {
    //        response1.success = false;
    //        response1.response = ex.Message.ToString();
    //    }

    //    try
    //    {
    //        if (mobile != "")
    //        {
    //            adapter1.Username = "DITMP-TBCBPL";
    //            adapter1.Password = "Mptbc@123";
    //            SMSMessage objMessage = new SMSMessage();
    //            objMessage.recipient = mobile;
    //            objMessage.message = message;
    //            adapter1.Send(objMessage);
    //        }
    //    }
    //    catch
    //    {
    //    }
    //}


    public MailHelper()
    {

    }
    public static string SendMail(string toMail, string mailSubject, string mailBody)
    {
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("182.18.133.191");

            mail.From = new MailAddress("C-NET<no-reply@cnet-india.com>");
            mail.To.Add(toMail);
            mail.Subject = mailSubject;
            mail.IsBodyHtml = true;
            mail.Body = mailBody;

            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("no-reply@cnet-india.com", "no@cnet123");
            SmtpServer.EnableSsl = false;

            SmtpServer.Send(mail);
            return "Success";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }


    public static string SendMailForDPR(string toMail, string cc, string mailSubject, string mailBody)
    {
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("182.18.133.191");

            mail.From = new MailAddress("C-NET<no-reply@cnet-india.com>");
            mail.To.Add(toMail);
            mail.Bcc.Add(new MailAddress(cc));
            mail.Subject = mailSubject;
            mail.IsBodyHtml = true;
            mail.Body = mailBody;
            //mail.Headers.Add("Reply-To", cc.ToString());
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("no-reply@cnet-india.com", "no@cnet123");
            SmtpServer.EnableSsl = false;

            SmtpServer.Send(mail);
            return "Success";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    public static string SendAcknowledgementMail(string toMail, string ccMail, string mailSubject, string mailBody)
    {
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("182.18.133.191");

            mail.From = new MailAddress("C-NET<no-reply@cnet-india.com>");
            mail.To.Add(toMail);
            mail.CC.Add(ccMail);
            mail.Subject = mailSubject;
            mail.IsBodyHtml = true;
            mail.Body = mailBody;

            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("no-reply@cnet-india.com", "no@cnet123");
            SmtpServer.EnableSsl = false;

            SmtpServer.Send(mail);
            return "Success";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}