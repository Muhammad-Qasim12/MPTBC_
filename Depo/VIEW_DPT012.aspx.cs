using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.IO;
using System.Net;
public partial class Depo_VIEW_DPT012 : System.Web.UI.Page
{
   // SMSAdapter adapter1 = new SMSAdapter();
    CountingDetails obCountingDetails = null;
    public APIProcedure api = new APIProcedure();
    CommonFuction obj = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            fillgrd();
        }
    }
    public void fillgrd()
    {
        
        obCountingDetails = new CountingDetails();
        obCountingDetails.PinterID_I = 0;
        obCountingDetails.userID = Convert.ToInt32(Session["UserID"]);
        obCountingDetails.LetterNo_V = Convert.ToString(Session["UserID"]);
       DataSet ds= obCountingDetails.Select();
       Grdmain.DataSource = ds.Tables[0];
       Grdmain.DataBind();
    }
    protected void Grdmain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grdmain.PageIndex = e.NewPageIndex;
        fillgrd();
    }
    protected void Grdmain_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obCountingDetails = new CountingDetails();
        obCountingDetails.Delete(Convert.ToInt32(Grdmain.DataKeys[e.RowIndex].Value));
        fillgrd();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("DPT012_25PercentageReport.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Messages.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
        //DataSet ds = obCommonFuction.FillDatasetByProc("CALL Usp_Get_SMS_MobileNo()");
        string Msg = "", DepotMoblNo = "";
        Button chkbox = (Button)sender;

        GridViewRow grd = (GridViewRow)(chkbox.NamingContainer);


        //List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        HiddenField txtb = (HiddenField)grd.FindControl("HiddenField1");
     
         Random rand = new Random();
            int randnum = rand.Next(100000, 10000000);
            Label1.Text = txtb.Value;
            obj.FillDatasetByProc("insert into tbl_OTP(ChallanNo, OPT)values('" + txtb.Value + "'," + randnum + ")");
            DepotMoblNo = obj.FillDatasetByProc("CALL GetMobleNumberDeport(" + Session["UserID"] + ",0,0)").ToString();
           // sendMessage(DepotMoblNo.ToString (), randnum.ToString ());
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(" http://216.245.209.132/rest/services/sendSMS/sendGroupSms?AUTH_KEY=cd78eab843b07ec4b6918e5ce372cea5&message=" + randnum + "&senderId=PWDPIU&routeId=1&mobileNos=" + DepotMoblNo + "&smsContentType=english");
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
          
        //            objSendSms.sendMessage(DepotMoblNo, Msg);
        
    }
    //Button3_Click

    protected void Button3_Click(object sender, EventArgs e)
    {
        DataSet dt = obj.FillDatasetByProc("select * from tbl_OTP where ChallanNo='" + Label1.Text + "' ");
        if (dt.Tables[0].Rows.Count > 0)
        {
            obj.FillDatasetByProc("delete from tbl_OTP where ChallanNo='"+Label1.Text+"'");
            obj.FillDatasetByProc("update dpt_stockreceivedtwentyfiveper_m set DepoSendstatus=1 where ChallanNo_V='" + Label1.Text + "'");

            Messages.Style.Add("display", "none");
            fadeDiv.Style.Add("display", "none");
            Label1.Text = "";
        }
        else
        {
            fadeDiv.Style.Add("disiplay", "block");
            Messages.Style.Add("disiplay", "block");

        }
        fillgrd();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }
    protected void sendMessage(string mobile, string message)
    {
        try
        {
            if (mobile != "")
            {
                //adapter1.Username = "cnetinfohttp";
                //adapter1.Password = "hotmail02";
                //SMSMessage objMessage = new SMSMessage();
                //objMessage.recipient = mobile;
                //objMessage.message = message;
                //adapter1.Send(objMessage);
            }
        }
        catch
        {
        }
    }
}