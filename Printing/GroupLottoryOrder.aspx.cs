using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using MPTBCBussinessLayer;
//using Microsoft.Reporting.WebForms;
public partial class Printing_GroupLottoryOrder : System.Web.UI.Page
{
    DataTable Dt; WorkOrderDetails obWorkOrderDetails = null;
    DataSet DS;
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obCommonFuction = new CommonFuction();
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYearNew();
            DdlACYear_SelectedIndexChanged(sender, e);

        }
    }
    protected void ddlTenderID_I_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("call GettenderbyGropu('" + ddlTenderID_I.SelectedValue + "')"); 
        ddlGroup.DataSource = dd.Tables[0];
        ddlGroup.DataValueField = "GroupNO_V";
        ddlGroup.DataTextField = "GroupNO_V";
        ddlGroup.DataBind();
        ddlGroup.Items.Insert(0, "Select..");
        fillgrd();
        //
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("call Prin_loadTender('" + DdlACYear.SelectedItem.Text + "')"); 
        ddlTenderID_I.DataSource = dd.Tables[0];
        ddlTenderID_I.DataValueField = "TenderId_I";
        ddlTenderID_I.DataTextField = "TenderNo_V";
        ddlTenderID_I.DataBind();
        ddlTenderID_I.Items.Insert(0, "Select..");

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        obCommonFuction.FillDatasetByProc("call USP_Prin_GroupLottryAllotmentOrderSave(0,'" + ddlGroup.SelectedItem.Text + "'," + ddlTenderID_I.SelectedValue + "," + TextBox1.Text + ")");
        DataSet dd = obCommonFuction.FillDatasetByProc("call USP_Prin_GroupLottryAllotmentOrderSave(1,'" + ddlGroup.SelectedItem.Text + "'," + ddlTenderID_I.SelectedValue + "," + TextBox1.Text + ")"); ;
        GridView1.DataSource = dd.Tables[0];
        GridView1.DataBind();
        TextBox1.Text = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("PrinterGroupAllotment.aspx");
    }
    public void fillgrd()
    {
        DataSet dd1 = obCommonFuction.FillDatasetByProc("call USP_Prin_GroupLottryAllotmentOrderSave(1,0," + ddlTenderID_I.SelectedValue + ",0)"); ;
        GridView1.DataSource = dd1.Tables[0];
        GridView1.DataBind();
    }

    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ddd = obCommonFuction.FillDatasetByProc("call USP_GetLataryNo(" + ddlTenderID_I.SelectedValue + ")");
        TextBox1.Text = ddd.Tables[0].Rows[0]["LottoryNo"].ToString();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("VIEW_TenderDetails.aspx");
    }
}