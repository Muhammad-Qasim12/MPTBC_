using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Printing_PrinterRenewable : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    PRI_PrinterRenewal obPRI_PrinterRenewal = null;
    CommonFuction obCommonFuction = null;
    APIProcedure objapi = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            try
            {
                if (Request.QueryString["ID"] != null)
                {
                    showdata(objapi.Decrypt(Request.QueryString["ID"]).ToString());
                }
            }
            catch { }
            finally { obPRI_PrinterRenewal = null; }
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Session["PriRenewalID_I"] = 0;
        try
        {
            int valchk = 0;
            DateTime dt1, dt2;
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            dt1 = dateConversion(txtRenewaldate.Text);
            dt2 = dateConversion(txtRenFrom.Text);
            if (dt2 < dt1)
            {
                txtRenTo_D.Text = "";

                messageDiv.InnerHtml = "'Renewal from दिनाक ,  Renewal दिनाक से बाद की नहीं है..'";
             //   ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Renewal from दिनाक से  Renewal दिनाक से बाद की नहीं है');</script>");
                valchk++;
            }

            else
            {
                dt1 = dateConversion(txtRenTo_D.Text);

                if (dt1 < dt2)
                {
                    messageDiv.InnerHtml = "'Renewal To दिनाक ,  Renewal From दिनाक से बाद की नहीं है..'";
                 //   ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Renewal To दिनाक से  Renewal From दिनाक बाद की नहीं है');</script>");
                    valchk++;
                }
            }

            if (valchk == 0)
            {
                messageDiv.InnerHtml = "";
                obPRI_PrinterRenewal = new PRI_PrinterRenewal();
                if (HiddenField2.Value == "")
                { }
                else { obPRI_PrinterRenewal.Printer_RedID_I = Convert.ToInt32(HiddenField2.Value); }
                obPRI_PrinterRenewal.Renewaldate_D = Convert.ToDateTime(System.DateTime.Now, cult);
                obPRI_PrinterRenewal.Amount_I = Convert.ToInt32(txtRenewAmount.Text.Trim());
                obPRI_PrinterRenewal.AmtDetail_V = Convert.ToString(txtAmtDetail.Text.Trim());
                obPRI_PrinterRenewal.RenFrom_D = Convert.ToDateTime(txtRenFrom.Text, cult);
                obPRI_PrinterRenewal.RenTo_D = Convert.ToDateTime(txtRenTo_D.Text, cult);

                obPRI_PrinterRenewal.PriRenewalID_I = 0;
                if (HiddenField1.Value != "")
                {
                    // obPRI_PrinterRenewal.PriRenewalID_I = 1;
                    obPRI_PrinterRenewal.PriRenewalID_I = Convert.ToInt32(HiddenField1.Value);
                }
                obPRI_PrinterRenewal.InsertUpdate();
                obCommonFuction = new CommonFuction();
                obCommonFuction.EmptyTextBoxes(this);
                HiddenField1.Value = "";
                HiddenField2.Value = "";

                messageDiv.InnerHtml = "  डाटा save हो गया है ";
                Response.Redirect("VIEW_PrinterRenewable.aspx");
            }
            
        }
          catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert("+ex.Message +");</script>");
        
        }  
        finally
        {
            obPRI_PrinterRenewal = null;
           
        }
       
    }


   
    public void showdata(string ID)
    {
        obPRI_PrinterRenewal = new PRI_PrinterRenewal();
        obPRI_PrinterRenewal.Printer_RedID_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["PrinterID"]).ToString() );
        if (objapi.Decrypt(Request.QueryString["ID"]).ToString()  != "0" )
        {
            obPRI_PrinterRenewal.PriRenewalID_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["ID"]).ToString() );
            HiddenField1.Value = (objapi.Decrypt(Request.QueryString["ID"]).ToString() );

            DataSet obDataSet = obPRI_PrinterRenewal.Select();
            txtRenewaldate.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["Renewaldate_D"]).ToString("dd/MM/yyyy");
            txtRenewAmount.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Amount_I"]);
            txtAmtDetail.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["AmtDetail_V"]);
            txtRenFrom.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["RenFrom_D"]).ToString("dd/MM/yyyy");
            txtRenTo_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["RenTo_D"]).ToString("dd/MM/yyyy");
        }
        else
        {
            obPRI_PrinterRenewal.PriRenewalID_I = 0;
            HiddenField1.Value = "0";
        }
        HiddenField2.Value = (objapi.Decrypt(Request.QueryString["PrinterID"]).ToString() );
    }

    protected void txtRenTo_D_TextChanged(object sender, EventArgs e)
    {

        //if (Convert.ToDateTime(txtRenTo_D.Text, cult) < Convert.ToDateTime(txtRenFrom.Text, cult))
        //{
            
        //}
    }
    public DateTime dateConversion(string txtValue)
    {
        DateTime dt;
        if (txtValue == "")
        {
            return Convert.ToDateTime("01/01/1900");
        }
        else
        {
            return DateTime.ParseExact(txtValue, "dd/MM/yyyy", null);
        }

    }
protected void   btnBack_Click(object sender, EventArgs e)
{
    Response.Redirect ("VIEW_PrinterRenewable.aspx");
}
 
}