using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
public partial class Printing_PaperDetails : System.Web.UI.Page
{
     
    CommonFuction comm = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DataSet ds = new System.Data.DataSet();
            //  ds = obPRI_PrinterRegistration.PrinterRegistrationLoad();
            //ddlprinterName.DataSource = ds.Tables[0];
            //ddlprinterName.DataValueField = "Printer_RedID_I";
            //ddlprinterName.DataTextField = "NameofPressHindi_V";
            //ddlprinterName.DataBind();
            //ddlprinterName.Items.Insert(0, new ListItem("All", "0"));

            // select NameofPressHindi_V nameprinter,Printer_RedID_I Printerid from  pri_printerregistration_t order by NameofPressHindi_V asc;
            DataSet dd = comm.FillDatasetByProc("select NameofPressHindi_V nameprinter,Printer_RedID_I Printerid from  pri_printerregistration_t order by NameofPressHindi_V asc");
           // DataSet dd = comm.FillDatasetByProc("select nameprinter,Printerid from paperdetails");
            ddlprinterName.DataTextField = "nameprinter";
            ddlprinterName.DataValueField = "Printerid";
            ddlprinterName.DataSource = dd.Tables[0];
            ddlprinterName.DataBind();
           TextBox4.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
     //  Response.Redirect ("" + Convert.ToDateTime(TextBox4.Text, cult).ToString("yyyy-MM-dd")   ); 
       DataSet dd= comm.FillDatasetByProc("call USP_PaperDetails(1," + ddlprinterName.SelectedValue + ",0,0,0,0,0,0,0,0,'" + Convert.ToDateTime(TextBox4.Text, cult).ToString("yyyy-MM-dd") + "')");
       GridView1.DataSource = dd.Tables[0];
       GridView1.DataBind();
       
        

        
        if (GridView1.Rows.Count > 0)
       {

       }
       else
       {
           dd = comm.FillDatasetByProc("select * from tmp_paperdetails");
           GridView1.DataSource = dd.Tables[0];
           GridView1.DataBind();
       }
        //`USP_PaperDetails` (id int,Printerida int, GSM70aa decimal, GSM80aa decimal, GSM230aa decimal, GSM250aa decimal, GSM70ba decimal, GSM80ba decimal, GSM230ba decimal, GSM250ba decimal,dateA datetime)
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            comm.FillDatasetByProc("call USP_PaperDetails(0," + ddlprinterName.SelectedValue + ",'" + ((TextBox)GridView1.Rows[i].FindControl("txt1")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("txt2")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("txt3")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("txt4")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("txt5")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("txt6")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("txt7")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("txt8")).Text + "','" + Convert.ToDateTime(TextBox4.Text, cult).ToString("yyyy-MM-dd") + "')");
        }
        GridView1.DataSource = null;
        GridView1.DataBind();
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
     }
}