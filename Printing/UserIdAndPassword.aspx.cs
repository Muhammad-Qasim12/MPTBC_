using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using MPTBCBussinessLayer.Admin;

public partial class Printing_PRI001_UserIdAndPassword : System.Web.UI.Page
{
    PRI_PrinterRegistration obPriReg = null;
    UserMaster obUser = null;
    APIProcedure objapi = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            if (Request.QueryString["PriId"] != null)
            {
                
                registrationNOLoad();
                LoadUserDetails();
            }
            else 
            {
                Response.Redirect("PrinterRegDetails.aspx");
            }
        
        }
    }


    public void LoadUserDetails()
    {
        obPriReg = new PRI_PrinterRegistration();
        DataSet ds = new DataSet();

        try
        {

            obPriReg.Printer_RedID_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["PriId"]).ToString() );
            ds = obPriReg.LoadUserID();

            if (ds.Tables[0].Rows.Count > 0)
            {
                HDNUserID_I.Value = Convert.ToString(ds.Tables[0].Rows[0]["UserID_I"]);

                txtUserName_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["UserName_V"]);

                txtPassword_V.Attributes.Add("Value", Convert.ToString(ds.Tables[0].Rows[0]["Password_V"]));
               

            }

            if (txtUserName_V.Text == "") { txtUserName_V.Text = lblRegistration.Text; }
        }

        catch (Exception ex) { }
        finally { obPriReg = null; }



    }


    public int SaveUSerId()
    {
        int i = 0;
        obPriReg = new PRI_PrinterRegistration();

        try
        {
            obPriReg.UserID_I = Convert.ToInt32(HDNUserID_I.Value);

            obPriReg.Regno_I = Convert.ToString(txtUserName_V.Text);

            obPriReg.Password_V = Convert.ToString(txtPassword_V.Text);
            obPriReg.RoleTrno_I = 5;
            obPriReg.UserType_V = "External User";

            i = obPriReg.SaveUserID();
        }

        catch (Exception ex) { }
        finally { obPriReg = null; }

        return i;
    }

    public void registrationNOLoad() 
    {
        DataSet ds= new DataSet();
        obPriReg = new PRI_PrinterRegistration();

        try{
             obPriReg.Printer_RedID_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["PriId"]).ToString() );
             ds = obPriReg.PrinterRegistrationLoad();

             if (ds.Tables[0].Rows.Count > 0) 
             {
                 lblRegistration.Text = ds.Tables[0].Rows[0]["Regno_I"].ToString();
             }
        }

        catch(Exception ex){}
        finally{obPriReg=null;}
    }


    public int Validation()
    {
        int i = 0;
        txtUserName_V.BackColor = System.Drawing.Color.White;
        txtPassword_V.BackColor = System.Drawing.Color.White;
        txtConfirmPassword.BackColor = System.Drawing.Color.White;

        if (txtUserName_V.Text == "") { i++; txtUserName_V.BackColor = System.Drawing.Color.Red; }
        else if (txtPassword_V.Text == "") { i++; txtPassword_V.BackColor = System.Drawing.Color.Red; }
        else if (txtConfirmPassword.Text == "") { i++; txtConfirmPassword.BackColor = System.Drawing.Color.Red; }

        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Validation() == 0)
        {

            HDNUserID_I.Value = SaveUSerId().ToString();

            if (Convert.ToInt32(HDNUserID_I.Value) > 0)
            {
                obPriReg = new PRI_PrinterRegistration();
                try
                {
                    obPriReg.Printer_RedID_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["PriId"]).ToString() );
                    obPriReg.UserID_I = Convert.ToInt32(HDNUserID_I.Value);

                    if (obPriReg.UpdateUserID() > 0)
                    {
                        Response.Redirect("PrinterRegDetails.aspx",false );
                    }
                    else { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Check You Data');</script>"); }
                }
                catch (Exception ex) { }
                finally { obPriReg = null; }

            }
            else { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Check You Data.');</script>"); }
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PrinterRegDetails.aspx");
    }

}