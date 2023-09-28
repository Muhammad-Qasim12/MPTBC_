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

public partial class Printing_GroupWiseRateDetails : System.Web.UI.Page
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
            DdlACYear.Items.Insert(0, "Select..");
            //DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
        }
    }
    protected void ddlTenderID_I_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("call GettenderbyGropu('" + ddlTenderID_I.SelectedValue  + "')"); ;
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
        DataSet dd = obCommonFuction.FillDatasetByProc("call Prin_loadTenderdd('" + DdlACYear.SelectedItem.Text + "')"); ;
        ddlTenderID_I.DataSource = dd.Tables[0];
        ddlTenderID_I.DataValueField = "TenderId_I";
        ddlTenderID_I.DataTextField = "TenderNo_V";
        ddlTenderID_I.DataBind();
        ddlTenderID_I.Items.Insert(0, "Select..");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       // USP_Prn_GroupWisePrinterRate
        for (int i = 0;i< GridView1.Rows.Count; i++)
        {
            obCommonFuction.FillDatasetByProc("call USP_Prn_GroupWisePrinterRate(0," + ddlTenderID_I.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "','" + ddlGroup.SelectedItem.Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("TextBox1")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("TextBox2")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("TextBox3")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("TextBox4")).Text + "'," + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value + ")");
        }
        GridView1.DataSource = null;
        GridView1.DataBind(); fillgrd();
        ddlGroup.SelectedIndex = 0;
        DdlACYear.SelectedIndex = 0;
        ddlTenderID_I.SelectedIndex = 0;
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('आपका डाटा सुरक्षित हो चुका  |');</script>");

    }
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_groupWiseBook('"+ddlGroup.SelectedItem.Text+"','"+DdlACYear.SelectedItem.Text+"','"+ddlTenderID_I.SelectedValue+"')");
        GridView1.DataBind();
    
    }
    public void fillgrd()
    {
      DataSet dd= obCommonFuction.FillDatasetByProc("call USP_Prn_GroupWisePrinterRate(1," + ddlTenderID_I.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "',0,0,0,0,0,0)");
      GridView2.DataSource = dd.Tables[0];
      GridView2.DataBind();
    
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        fillgrd();
    }
}