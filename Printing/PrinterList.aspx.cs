using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Printing_PrinterList : System.Web.UI.Page
{
    CommonFuction obj = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            GridView1.DataSource = obj.FillDatasetByProc("call USP_PrinterList(0,0,0,0)");
            GridView1.DataBind();
        
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (((RadioButtonList)GridView1.Rows[i].FindControl("RadioButtonList1")).SelectedIndex != -1)
            {

                obj.FillDatasetByProc("call USP_PrinterList(" + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value + "," + ((RadioButtonList)GridView1.Rows[i].FindControl("RadioButtonList1")).SelectedValue + "," + ((DropDownList)GridView1.Rows[i].FindControl("ddlstate")).SelectedValue + ",0)");
            }
        }

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList drp = ((DropDownList)e.Row.FindControl("ddlstate"));
            drp.DataTextField = "Statename_eng_V";
            drp.DataValueField = "stateid";
            drp.DataSource = obj.FillDatasetByProc("SELECT * FROM `statemaster_m`");
            drp.DataBind();
        }
    }
}