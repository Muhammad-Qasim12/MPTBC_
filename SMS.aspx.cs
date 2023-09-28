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
using System.Text.RegularExpressions;

public partial class SMS : System.Web.UI.Page
{
    util1 ubti = new util1();
    SMSAdapter sms = new SMSAdapter();

    MailHelper mh = new MailHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
       // mh.sendMessage("9893140658", "hi");
        sms.sendSingleSMS1("DITMP-TBCBPL", "Mptbc@123", "TBCBPL", "9893140658", "Test by ajay dgffdgfdg");
    }
}