using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Depo_OtherDistribution : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    Dis_TentativeDemandHistory objTentativeDemandHistory;
    string classA; DataTable Dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            objTentativeDemandHistory = new Dis_TentativeDemandHistory();
            DdlScheme.DataSource = objTentativeDemandHistory.MedumFill();
            DdlScheme.DataValueField = "MediumTrno_I";
            DdlScheme.DataTextField = "MediunNameHindi_V";
            DdlScheme.DataBind();
            if (Convert.ToString(Request.QueryString["Class"]) != null)
            {
                DdlACYear.SelectedValue = Request.QueryString["Year"];
                DdlScheme.SelectedValue = Request.QueryString["Medium"];
               DDLClass.SelectedValue = Request.QueryString["Class"];
               DataSet dd = obCommonFuction.FillDatasetByProc("call USP_Ph_otherDistribution ('" + Request.QueryString["Year"] + "','" + Request.QueryString["Class"] + "'," + Request.QueryString["Medium"] + "," + Convert.ToString(Session["UserID"]) + ") ");
               GridView1.DataSource = dd.Tables[0];
              GridView1.DataBind();

           }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("call USP_Ph_otherDistribution ('" + DdlACYear.SelectedValue + "','" + DDLClass.SelectedValue + "', " + DdlScheme.SelectedValue+ ") ");
         GridView1.DataSource = dd.Tables[0];
         GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        obCommonFuction.FillDatasetByProc("delete from Dpt_Physical_otherDemand where DepoID=" + Session["UserID"].ToString() + " and ClassID='" + DDLClass.SelectedItem.Text + "' and MediumID=" + DdlScheme.SelectedValue + " and YEAR='" + DdlACYear.SelectedItem.Text + "'");
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            obCommonFuction.FillDatasetByProc("insert into Dpt_Physical_otherDemand(DepoID, ClassID , MediumID , Yojna  ,Samany,  YEAR,TitleID)values (" + Session["UserID"].ToString() + ",'" + DDLClass.SelectedItem.Text + "'," + DdlScheme.SelectedValue + "," + ((TextBox)GridView1.Rows[i].FindControl("TextBox1")).Text + "," + ((TextBox)GridView1.Rows[i].FindControl("TextBox2")).Text + ",'" + DdlACYear.SelectedItem.Text + "'," + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value + ")");
        }
        GridView1.DataSource = null;
        GridView1.DataBind();
        Response.Redirect("View_otherthanDemand.aspx");
        
    }
    
}