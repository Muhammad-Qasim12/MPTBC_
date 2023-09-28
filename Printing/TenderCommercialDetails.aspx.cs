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
public partial class Printing_TenderCommercialDetails : System.Web.UI.Page
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
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            DdlACYear_SelectedIndexChanged(Server, e);
        }
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("call Prin_loadTender('" + DdlACYear.SelectedItem.Text + "')"); ;
        ddlTenderID_I.DataSource = dd.Tables[0];
        ddlTenderID_I.DataValueField = "TenderId_I";
        ddlTenderID_I.DataTextField = "TenderNo_V";
        ddlTenderID_I.DataBind();
        ddlTenderID_I.Items.Insert(0, "Select..");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_PrinGetTenderLunList('" + ddlGropuName.SelectedItem.Text + "'," + ddlTenderID_I.SelectedValue + ")");
        GridView1.DataBind();
        Button2.Visible = true;
    }
    protected void ddlTenderID_I_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DataSet dd1 = obCommonFuction.FillDatasetByProc("call USP_PrinGroupdetailsbyTender('" + ddlTenderID_I.SelectedValue + "')"); ;
        ddlGropuName.DataSource = dd1.Tables[0];
        ddlGropuName.DataValueField = "GroupNO_V";
        ddlGropuName.DataTextField = "GroupNO_V";
        ddlGropuName.DataBind();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            TextBox txt1 = ((TextBox)GridView1.Rows[i].FindControl("Textbox1"));
            DropDownList ddl1 = ((DropDownList)GridView1.Rows[i].FindControl("DropDownList1"));
            HiddenField hd1 = ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1"));
            obCommonFuction.FillDatasetByProc("call USP_prinUpdateRatelist('" + txt1.Text + "','" + ddl1.SelectedValue + "','" + hd1.Value + "')");
        }
        GridView1.DataSource = null;
        GridView1.DataBind();
        Button2.Visible = false;

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlCities = (DropDownList)e.Row.FindControl("DropDownList1");
            HiddenField hd = (HiddenField)e.Row.FindControl("HiddenField1");
            DataSet dd = obCommonFuction.FillDatasetByProc("select rank from pri_lunlist where did=" + hd.Value + "");
            try
            {
                ddlCities.Items.FindByValue(dd.Tables[0].Rows[0]["rank"].ToString()).Selected = true;
            }
            catch { }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("VIEW_TenderDetails.aspx");
    }
}