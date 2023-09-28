using System;
using System.Data;

public partial class Admin_ChangePassword : System.Web.UI.Page
{
    DataSet ds;
    MPTBCBussinessLayer.Admin.ChangePassword obChangePassword = new MPTBCBussinessLayer.Admin.ChangePassword();
    protected void Page_Load(object sender, EventArgs e)
    {
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = "";

        if (!IsPostBack)
        {
            
            if (Session["UserID"] != null)
            {
                obChangePassword.QueryType = 0;
                DataSet dsUser = new DataSet();
                obChangePassword.QueryType = 0;
                obChangePassword.UserId = int.Parse(Session["UserID"].ToString());
                dsUser = obChangePassword.Select();
                if (dsUser.Tables[0].Rows.Count > 0)
                {
                    lblLoginUserName.Text = dsUser.Tables[0].Rows[0]["UserName_V"].ToString();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }



    protected void btnSave_OnClick(object sender, EventArgs e)
    {
       
        if (Session["UserID"] != null)
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                
                DataSet dsUser = new DataSet();
                obChangePassword.QueryType = 0;
                obChangePassword.UserId = int.Parse(Session["UserID"].ToString());
                obChangePassword.UserName_V = Session["UserName"].ToString();
                
                dsUser = obChangePassword.Select();
                if (dsUser.Tables[0].Rows.Count > 0)
                {
                    if (dsUser.Tables[0].Rows[0]["Password_V"].ToString() == txtOldPassword.Text)
                    {
                       
                        obChangePassword.Password = txtConfirmPassword.Text;
                        ds= obChangePassword.InsertUpdate();
                        if (ds.Tables[0].Rows[0][0].ToString() == "0")
                        {
                            mainDiv.Style.Add("display", "block");
                            lblmsg.ForeColor = System.Drawing.Color.Green;
                            lblmsg.Text = "Password changed successfully";
                        }
                        else
                        {
                            mainDiv.Style.Add("display", "block");
                            lblmsg.Text = "New password Already Exist.";
                        }
                    }
                    else
                    {
                        mainDiv.Style.Add("display", "block");
                        lblmsg.Text = "Old password not match";
                    }
                }
            }
            else
            {
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Password and Confirm password not match";
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}