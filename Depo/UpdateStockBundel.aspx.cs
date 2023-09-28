using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

using System.IO;

public partial class Depo_UpdateStockBundel : System.Web.UI.Page
{
    public CommonFuction comm = new CommonFuction();
    DPT_DepotMaster obDPT_DepotMaster = null;

    string Classes = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFuction comm = new CommonFuction();

            ddlMedium.DataSource = comm.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("All", "0"));
            ddlSessionYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlSessionYear.DataValueField = "AcYear";
            ddlSessionYear.DataTextField = "AcYear";
            ddlSessionYear.DataBind();
            ddlSessionYear.SelectedValue = "2019-2020";
            //ddlSessionYear.Enabled = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = comm.FillDatasetByProc("CALL USP_GetStockD("+ddlTital.SelectedValue+","+Session["UserID"].ToString ()+")");
        GridView1.DataBind();
    }
    protected void DDLClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        Classes = "";
        if (DDLClass.SelectedValue.ToString() == "1-8") Classes = "1,2,3,4,5,6,7,8";
        else if (DDLClass.SelectedValue.ToString() == "9-12") Classes = "9,10,11,12";
        DataSet asdf = comm.FillDatasetByProc("call GetMediumbyTitile(" + ddlMedium.SelectedValue + ",'" + Classes + "')");
        ddlTital.DataSource = asdf.Tables[0];
        ddlTital.DataTextField = "TitleHindi_V";
        ddlTital.DataValueField = "TitleID_I";
        ddlTital.DataBind();
        ddlTital.Items.Insert(0, new ListItem("Select...", "0"));
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        comm.FillDatasetByProc("CALL USP_DeletBund("+GridView1.DataKeys[e.RowIndex].Value.ToString ()+")");
        Button1_Click(sender, e);
      
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        { 
            
            try { 
            comm.FillDatasetByProc("CALL UPdateStockData(" + ((TextBox)GridView1.Rows[i].FindControl("TextBox1")).Text + "," + ((TextBox)GridView1.Rows[i].FindControl("TextBox2")).Text + "," + ((TextBox)GridView1.Rows[i].FindControl("TextBox3")).Text + "," + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value + ")");
        }
        catch { }
        }
        Button1_Click(sender, e);
    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void ddlTital_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}