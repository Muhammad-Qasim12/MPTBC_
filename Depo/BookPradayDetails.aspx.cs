using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_BookPradayDetails : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, "--Select--");
            DdlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)");
            DdlMedium.DataValueField = "MediumTrno_I";
            DdlMedium.DataTextField = "MediunNameHindi_V";
            DdlMedium.DataBind();
            DdlMedium.Items.Insert(0, "--Select--");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_Praday("+DdlMedium.SelectedValue+",'"+ddlClass.SelectedValue+"','"+DdlACYear.SelectedValue+"','"+DdlDepot.SelectedValue+"','"+ddlbooktype.SelectedValue+"','"+ddlClass.SelectedItem.Text+"')");
        GridView1.DataBind();
        Button2.Visible = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        obCommonFuction.FillDatasetByProc("delete from dpt_bookpraday where DepoID=" + DdlDepot.SelectedValue + " and ClassID='" + ddlClass.SelectedItem.Text + "' and MediumID="+DdlMedium.SelectedValue+" and YearID='"+DdlACYear.SelectedValue+"' and  bookType="+ddlbooktype.SelectedValue+" ");
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            obCommonFuction.FillDatasetByProc(@"INSERT INTO dpt_bookpraday (TitleID ,DepoID , ClassID,  MainDemand,  Selelight,  InterDepo,  [2PerRKS] ,  Bafar ,
  Other,  MediumID , YearID,  bookType ) values (" + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value + "," + DdlDepot.SelectedValue + ",'" + ddlClass.SelectedItem.Text + "'," + ((TextBox)GridView1.Rows[i].FindControl("txt1")).Text + "," + ((TextBox)GridView1.Rows[i].FindControl("txt2")).Text + "," + ((TextBox)GridView1.Rows[i].FindControl("txt3")).Text + "," + ((TextBox)GridView1.Rows[i].FindControl("txt4")).Text + "," + ((TextBox)GridView1.Rows[i].FindControl("txt5")).Text + "," + ((TextBox)GridView1.Rows[i].FindControl("txt6")).Text + ","+DdlMedium.SelectedValue+",'"+DdlACYear.SelectedItem.Text +"',"+ddlbooktype.SelectedValue+")");
        }
        GridView1.DataSource = null;
        GridView1.DataBind();
        Button2.Visible = false;
    }
}