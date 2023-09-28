using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class ForgetPassword : System.Web.UI.Page
{
    DataSet ds;
    CommonFuction objFget = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtUserName.Text = "";
            txtImg.Text = "";
            CreateRandomString(6);            
        }
    }
    public void CreateRandomString(int length)
    {

        string guidResult = System.Guid.NewGuid().ToString();
        guidResult = guidResult.Replace("-", string.Empty);
        guidResult = guidResult.Substring(0, length);

        imgCaptcha.ImageUrl = "~/CaptchaHandler.ashx?txt=" + guidResult;
        Session["FrgtImgText"] = guidResult;

    }

    //--- Method to check whether entered captcha is correct or not.
    protected bool ValidateForm()
    {

        bool IsValid = true;
        if (Session["FrgtImgText"] != null)
        {
            if (txtImg.Text != Session["FrgtImgText"].ToString())
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

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        bool status = true; //ValidateForm();
        if (status == true)
        {
            if (txtUserName.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter your User ID.');</script>");
            }
            else
            {
                ds = objFget.FillDatasetByProc("Call ProcForgotPwd('" + txtUserName.Text + "',0)");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string EmailId = "", MobileNo = "", Pwd = "";
                    EmailId = ds.Tables[0].Rows[0]["EmailId"].ToString();
                    MobileNo = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    Pwd = ds.Tables[0].Rows[0]["Password_V"].ToString();

                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Your password has been sent to your email Or Mobile. Please check your mail Or Mobile.');</script>");
                    //string result = MailHelper.SendMail(objvb.DecryptText(ds.Tables[0].Rows[0]["Email"].ToString()), "Reset Your Password", getMailBody(dtUser));
                    //if (result == "Success")
                    //{
                    //    lblmsg.Text = "Your password reset link has been sent to your email. Please check your mail and follow instructions.";
                    //    lblmsg.Style.Add("color", "Green");
                    //}
                    //else
                    //{
                    //    lblmsg.Text = result;
                    //    lblmsg.Style.Add("color", "Red");
                    //}

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('User ID does not exist.');</script>");
                }
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Entered Text is Incorrect.');</script>");
        }
        //--- Recreate captcha.
        txtUserName.Text = "";
        txtImg.Text = "";
        CreateRandomString(6);   
    }

    protected string getMailBody(DataTable dtUser)
    {
        //StringBuilder mailBody = new StringBuilder();
        //string userid = HttpUtility.UrlEncode(objvb.EncryptText(txtUserID.Text.Trim() + "|2"));

        //mailBody.Append(@"");

        //mailBody.Replace("$RecipientName$", objvb.DecryptText(dtUser.Rows[0]["Fname"].ToString()));
        //mailBody.Replace("$ResetURL$", "http://182.18.133.191:2090/ResetPassword.aspx?code=" + userid);

        //return mailBody.ToString();
        return "";
    }
}