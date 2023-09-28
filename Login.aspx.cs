using System;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Net;
using System.Web;
using System.Globalization;



public partial class Login : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    public string d1d, keyEd, ivED;
    MPTBCBussinessLayer.Admin.Login obLogin = new MPTBCBussinessLayer.Admin.Login();
    APIProcedure objdb = new APIProcedure();
    CommonFuction obCommonFuction = new CommonFuction();
    DataTable dt;
    DataSet ds;
    Random rnd = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        string DateTmLng = "", RndNo = "";


        if (Session["KeyVal"] == null)
        {
            // DateTmLng = System.DateTime.Now.ToString("yyyyMMddhhmmss");
            DateTmLng = Guid.NewGuid().ToString().Replace("-", "");
            //if (DateTmLng.Length < 14)

            //    RndNo = rnd.Next(1, 99999).ToString().Substring(0, 14 - DateTmLng.Length);
            //}
            //else
            //{
            //    RndNo = rnd.Next(1, 99999).ToString().Substring(0, 2);
            //}
            // Session["KeyVal"] = RndNo + DateTmLng;
            Session["KeyVal"] = DateTmLng;
        }
        if (!Page.IsPostBack)
        {
            DateTmLng = Guid.NewGuid().ToString().Replace("-", "");
            //DateTmLng = System.DateTime.Now.ToString("yyyyMMddhhmmss");
            //if (DateTmLng.Length < 14)
            //{
            //    RndNo = rnd.Next(1, 99999).ToString().Substring(0, 14 - DateTmLng.Length);
            //}
            //else
            //{
            //    RndNo = rnd.Next(1, 99999).ToString().Substring(0, 2);
            //}
            // Session["KeyVal"] = RndNo + DateTmLng;

            Session["KeyVal"] = DateTmLng;

            //   Session["KeyVal"]   = "3620151005042518";// Session["KeyVal"].ToString();
            Session["KeyID"] = "8080808080808080";
            int Year = 0;
            Year = System.DateTime.Now.Year;
            txtFDate.Text = "01/04/" + Year.ToString();
            txtToDate.Text = "31/03/" + (Year + 1).ToString();
            txtPswd.Attributes.Add("Type", "Password");
            Page.Form.DefaultButton = "btnLogin";
            Page.Form.DefaultFocus = "txtUserName";
            //  lblmsg.Text = "";
            CreateRandomString(6);


        }
    }

    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {

        obLogin.UserName = txtUserName.Text;
        obLogin.QueryType = 0;
        DataSet dsLogin = obLogin.GetBranchId();
        if (dsLogin.Tables[0].Rows.Count > 0)
        {
            //if (dsLogin.Tables[0].Rows[0]["RoleAccess"].ToString() == "Code Module")
            //{
            //    if (dsLogin.Tables[0].Rows[0]["UserFromDPHO"].ToString() == "00002")
            //    {
            //        rbBusiness.Visible = false;
            //        rbcore.Visible = true;
            //        rbcore.Checked = true;
            //        ClientScript.RegisterStartupScript(this.GetType(), "Post", "<script type='text/javascript'>CoreShow();OnFocusCr();</script>");
            //    }
            //    else
            //    {

            //        rbBusiness.Visible = true;
            //        rbcore.Visible = true;
            //        rbcore.Checked = false;
            //        rbBusiness.Checked = true;
            //        ClientScript.RegisterStartupScript(this.GetType(), "Post", "<script type='text/javascript'>BuisnessShow();OnFocusBs();</script>");
            //    }
            //}
            //else
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "Post", "<script type='text/javascript'>BuisnessShow();OnFocusBs();</script>");
            //    rbBusiness.Visible = true;
            //    rbcore.Visible = false;
            //    rbBusiness.Checked = true;
            //    rbcore.Checked = false;
            //}

            if (dsLogin.Tables[0].Rows[0]["RoleAccess"].ToString() == "Code Module")
            {

                rbBusiness.Visible = false;
                rbcore.Visible = true;
                rbcore.Checked = true;
                ClientScript.RegisterStartupScript(this.GetType(), "Post", "<script type='text/javascript'>CoreShow();OnFocusCr();</script>");

            }
            else if (dsLogin.Tables[0].Rows[0]["RoleAccess"].ToString() == "Business Module")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Post", "<script type='text/javascript'>BuisnessShow();OnFocusBs();</script>");
                rbBusiness.Visible = true;
                rbcore.Visible = false;
                rbBusiness.Checked = true;
                rbcore.Checked = false;

            }
            else if (dsLogin.Tables[0].Rows[0]["RoleAccess"].ToString() == "Both")
            {
                rbBusiness.Visible = true;
                rbcore.Visible = true;
                rbcore.Checked = false;
                rbBusiness.Checked = true;
                ClientScript.RegisterStartupScript(this.GetType(), "Post", "<script type='text/javascript'>BuisnessShow();OnFocusBs();</script>");
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Post", "<script type='text/javascript'>OnFocusBs();</script>");
            rbBusiness.Visible = true;
            rbcore.Visible = false;
            rbcore.Checked = false;
            rbBusiness.Checked = true;
        }

    }
    protected void rbcore_CheckedChanged(object sender, EventArgs e)
    {
        if (txtUserName.Text == "")
        {
            rbBusiness.Checked = true;
            rbcore.Checked = false;
            ClientScript.RegisterStartupScript(this.GetType(), "Post", "<script type='text/javascript'>alert('Please Enter UserName.')</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Post", "<script type='text/javascript'>CoreShow();OnFocusCr();</script>");
        }
    }
    protected void rbBusiness_CheckedChanged(object sender, EventArgs e)
    {
        if (txtUserName.Text == "")
        {
            rbBusiness.Checked = true;
            rbcore.Checked = false;
            ClientScript.RegisterStartupScript(this.GetType(), "Post", "<script type='text/javascript'>alert('Please Enter UserName.')</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Post", "<script type='text/javascript'>BuisnessShow();OnFocusBs();</script>");
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string EmpId = "", BranchId = "";
        bool status = true;
        if (status == true)
        {

            try
            {
                string HostName = Dns.GetHostName();
                IPHostEntry ipEn = Dns.GetHostByName(HostName);
                IPAddress[] adds = ipEn.AddressList;
                string IpAddress = adds[adds.Length - 1].ToString();
                //string dd = objdb.Encrypt("paper123");

                // lblmsg.Text = "";
                obLogin.UserName = txtUserName.Text;
                obLogin.UserType = "0";
                // AESEncrytDecry.DecryptStringAES(HDPassword.Value);
                //obLogin.Password = AESEncrytDecry.DecryptStringAES(txtPswd.Text);
                obLogin.Password = txtPswd.Text;
                obLogin.IpAdress = IpAddress;
                obLogin.QueryType = 0;
                obLogin.UserID = 0;

                DataSet dsLogin = obLogin.MyLogin();

                if (dsLogin.Tables[0].Rows[0][0].ToString() == "Ok")
                {
                    txtPswd.Text = string.Empty;
                    // Session.Abandon();
                    Session.Clear();

                    Session["FullName"] = dsLogin.Tables[0].Rows[0]["OfficerName_V"].ToString();
                    txtPswd.Attributes.Add("AutoComplete", "Off");
                    txtUserName.Attributes.Add("AutoComplete", "Off");
                    Session["UserID"] = dsLogin.Tables[0].Rows[0]["UserID_I"].ToString();
                    EmpId = dsLogin.Tables[0].Rows[0]["EmpId"].ToString();
                    BranchId = dsLogin.Tables[0].Rows[0]["BranchId"].ToString();
                    Session["CoreModule"] = dsLogin.Tables[0].Rows[0]["CoreModule"].ToString();
                    Session["AcUserId"] = dsLogin.Tables[0].Rows[0]["AcUserId"].ToString();
                    Session["RoleId"] = dsLogin.Tables[0].Rows[0]["RoleId"].ToString();
                    Session["BranchId"] = dsLogin.Tables[0].Rows[0]["BranchId"].ToString();
                    Session["DepartName"] = (dsLogin.Tables[0].Rows[0]["DepartName"].ToString() == "" ? "M.P. Text Book Corporation" : dsLogin.Tables[0].Rows[0]["DepartName"].ToString());
                    Session["UserName"] = txtUserName.Text;
                    if (Convert.ToString(Session["RoleId"]) == "36")
                    {
                        DataSet dtr = obCommonFuction.FillDatasetByProc("call GetUserNamebyOfficername(" + Session["UserID"] + ")");
                        Session["FullName"] = dtr.Tables[0].Rows[0]["OfficerName_V"].ToString();
                    }
                    Response.Cookies.Clear();
                    Random rndNo = new Random();
                    Session["TokenValue"] = rndNo.Next().ToString();
                    HttpCookie cookie = new HttpCookie("KeyCookie");
                    cookie.Expires = DateTime.Now.AddMinutes(30);
                    cookie.Value = Session["TokenValue"].ToString();
                    Response.Cookies.Add(cookie);

                    Session["IsMySQL"] = "1";
                    Session["YojnaHeaderRequired"] = "0";
                    Session["Choice"] = "0";
                    Session["CssType"] = "YojnaPanchayat";
                    Session["CategoryRequired"] = "0";
                    Session["SchemeRequired"] = "0";

                    Session["HomePage"] = "../Default.aspx";
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    // lblmsg.Text = dsLogin.Tables[0].Rows[0][0].ToString();
                    DisplayMsg(dsLogin.Tables[0].Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                //lblmsg.Text = ex.Message;
                DisplayMsg(ex.Message.ToString());
            }
        }
        else
        {
            DisplayMsg("Entered Text is Incorrect");
            lblmsg.Text = "Entered Captcha Code is Incorrect";
        }

        //--- Recreate captcha.
        CreateRandomString(6);
        txtImg.Text = "";

    }
    public void DisplayMsg(string Msg)
    {
        if (Session["CoreModule"] != null)
        {
            if (Session["CoreModule"].ToString() == "Yes")
            {
                rbcore.Visible = true;
                rbBusiness.Checked = true;
                rbcore.Checked = false;
                ClientScript.RegisterStartupScript(this.GetType(), "Post", "<script type='text/javascript'>alert('" + Msg + "');CoreShow();OnFocusBs();</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Post", "<script type='text/javascript'>alert('" + Msg + "');OnFocusBs();</script>");
                rbcore.Visible = false;
                rbBusiness.Checked = true;
                rbcore.Checked = false;
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Post", "<script type='text/javascript'>alert('" + Msg + "');</script>");
            txtUserName.Text = "";
        }

        //if (rbBusiness.Checked == true)
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "Post", "<script type='text/javascript'>alert('" + Msg + "');BuisnessShow();</script>");        
        //}
        //else
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "Post", "<script type='text/javascript'>alert('" + Msg + "');CoreShow();</script>");  
        //}

    }


    //---- Method to create random string to be used as captcha.
    public void CreateRandomString(int length)
    {

        string guidResult = System.Guid.NewGuid().ToString();
        guidResult = guidResult.Replace("-", string.Empty);
        guidResult = guidResult.Substring(0, length);

        imgCaptcha.ImageUrl = "~/CaptchaHandler1.aspx?txt=" + guidResult;
        Session["RandomImgText"] = guidResult;
        txtImg.Text = guidResult;
    }

    //--- Method to check whether entered captcha is correct or not.
    protected bool ValidateForm()
    {

        bool IsValid = true;
        if (Session["RandomImgText"] != null)
        {
            if (txtImg.Text != Session["RandomImgText"].ToString())
            {
                IsValid = false;
            }
        }
        else
        {
            CreateRandomString(6);
            IsValid = false;
        }
        return IsValid;

    }




    [System.Web.Services.WebMethod]
    public static string GetDate(string sData)
    {
        APIProcedure objd = new APIProcedure();
        return objd.Encrypt(sData);
    }
}
