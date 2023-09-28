using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Printing_PercentagewisebookDetails : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet dd = comm.FillDatasetByProc("call USP_Rp009_Masterreport(0,0,8,0,0,0)");
            GridView1.DataSource = dd.Tables[0];
            GridView1.DataBind();
            DataSet asdf = comm.FillDatasetByProc("call USP_DPTOPeningStock(0,1,0,0,0,0)");
            ddlTital.DataSource = asdf.Tables[0];
            ddlTital.DataTextField = "TitleHindi_V";
            ddlTital.DataValueField = "TitleID_I";
            ddlTital.DataBind();
            ddlTital.Items.Insert(0, new ListItem("All", "0"));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        DataSet dd2 = comm.FillDatasetByProc("call USP_Rp009_Masterreport(0,"+ddlTital.SelectedValue+",9,"+TextBox1.Text+",0,0)");
        btnExportPDF.Visible = true;
        GridView1.DataSource = dd2.Tables[0];
        GridView1.DataBind();
        Label1.Text = "प्रतिशतवर पुस्तक की जानकारी ";
    }
}