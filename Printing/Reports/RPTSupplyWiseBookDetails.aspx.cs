using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Printing_RPTSupplyWiseBookDetails : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DataSet dd = comm.FillDatasetByProc("call USP_Rp009_Masterreport(0,0,8,0)");
            //GridView1.DataSource = dd.Tables[0];
            //GridView1.DataBind();
            DataSet asdf = comm.FillDatasetByProc("call USP_DPTOPeningStock(0,1,0,0,0,0)");
            ddlTital.DataSource = asdf.Tables[0];
            ddlTital.DataTextField = "TitleHindi_V";
            ddlTital.DataValueField = "TitleID_I";
            ddlTital.DataBind();
            ddlTital.Items.Insert(0, new ListItem("All", "0"));
            ddlClassName.DataSource = comm.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            ddlClassName.DataValueField = "ClassTrno_I";
            ddlClassName.DataTextField = "ClassDesc_V";
            ddlClassName.DataBind();
            ddlClassName.Items.Insert(0, new ListItem("All", "0"));
            ddlMedium.DataSource = comm.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("All", "0"));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        DataSet dd2 = comm.FillDatasetByProc("call USP_Rp009_Masterreport("+ddlMedium.SelectedValue+"," + ddlTital.SelectedValue + ",10,"+ddlClassName.SelectedValue+")");
        GridView1.DataSource = dd2.Tables[0];
        GridView1.DataBind();
        btnExportPDF.Visible = true;
        Label1.Text = "आवंटन से ज्यादा पुस्तकों की जानकारी ";
    }
}