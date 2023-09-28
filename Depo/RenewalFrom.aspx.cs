using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class Depo_RenewalFrom : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Text = Request.QueryString["Name"];
            BindDDLBank();
            txt1.Text =System.DateTime.Now.ToString ("dd/MM/yyyy");
            txtFromdate.Text = "01-04-2018";
            txttilldate.Text = "31-03-2023";

        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string  bankID,bankname;
        if (DDLBank.SelectedIndex == 0)
        {
            bankID = "0";
            bankname = "Na";
        }
        else
        {

            bankID =DDLBank.SelectedValue;
            bankname = DDLBank.SelectedItem.Text;
        }
        comm.FillDatasetByProc("UPDATE dpt_booksellerregistration_m SET Renewsaldate='" + Convert.ToDateTime(txt1.Text, cult).ToString("yyyy-MM-dd") + "',  Fromdate='" + Convert.ToDateTime(txtFromdate.Text, cult).ToString("yyyy-MM-dd") + "',  Todate='" + Convert.ToDateTime(txttilldate.Text, cult).ToString("yyyy-MM-dd") + "',  ReAmount=" + txtAmount.Text + " , bankID=" + bankID + "  ,bankName='" + bankname + "',  ReDDNo='" + txtDDNo.Text + "',  ReddDate='" + Convert.ToDateTime(txtDDdate.Text, cult).ToString("yyyy-MM-dd") + "' , GSTNo='" + txtGST.Text + "'  , AdharNo='" + txtadhar.Text + "',BilamShukl="+txtBilam.Text+" WHERE `Booksellerregistration_I`=" + Request.QueryString["ID"] + "");
        Response.Redirect("BookSellerMasterList.aspx");
    }
    public void BindDDLBank()
    {
        DataSet dd = comm.FillDatasetByProc("CALL USP_bankmasterList()");
        DDLBank.DataSource = dd;
        DDLBank.DataValueField = "BankId";
        DDLBank.DataTextField = "BankName";
        DDLBank.DataBind();
        DDLBank.Items.Insert(0, "Select..");
    }
    protected void txtFromdate_TextChanged(object sender, EventArgs e)
    {
      //  DataSet dta = comm.FillDatasetByProc("SELECT  DATE_FORMAT(  DATE_ADD('" + Convert.ToDateTime(txtFromdate.Text, cult).ToString("yyyy-MM-dd") + "', INTERVAL 5 YEAR),'%d/%m/%Y')aa");
       txttilldate.Text = "31-03-2023";
    
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            DDLBank.Visible = true;
        }
        else
        { DDLBank.Visible = false; }
    }
}