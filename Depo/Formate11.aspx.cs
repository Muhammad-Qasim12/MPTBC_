using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Depo_Formate11 : System.Web.UI.Page
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
                DdlScheme.SelectedValue= Request.QueryString["Medium"] ;
                DDLClass.SelectedValue = Request.QueryString["Class"];
                DataSet dd = obCommonFuction.FillDatasetByProc("call USP_UpdateF11 ('" + Request.QueryString["Year"] + "'," + Convert.ToString(Session["UserID"]) + ",'" + Request.QueryString["Class"] + "'," + Request.QueryString["Medium"] + ") ");
        GridView1.DataSource = dd.Tables[0];
        GridView1.DataBind();
            
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("call usp_gETfORMAT3 ('" + DdlACYear.SelectedValue + "'," + DdlScheme.SelectedValue + ", " + Convert.ToString(Session["UserID"]) + ",'" + DDLClass.SelectedValue + "') ");
        GridView1.DataSource = dd.Tables[0];
        GridView1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        obCommonFuction.FillDatasetByProc("delete from Format_11 where DepoID=" + Session["UserID"].ToString() + " and ClassID='" + DDLClass.SelectedItem.Text + "' and MediumID=" + DdlScheme.SelectedValue + " and YEAR='"+DdlACYear.SelectedItem.Text+"'");
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            obCommonFuction.FillDatasetByProc("insert into Format_11(DepoID, ClassID , MediumID , Yojna1,  Yojna2  ,Samany1,  Samany2,  YEAR,TitleID)values (" + Session["UserID"].ToString() + ",'" + DDLClass.SelectedItem.Text + "'," + DdlScheme.SelectedValue + "," + ((Label)GridView1.Rows[i].FindControl("Label1")).Text + "," + ((TextBox)GridView1.Rows[i].FindControl("TextBox1")).Text + "," + ((Label)GridView1.Rows[i].FindControl("Label2")).Text + "," + ((TextBox)GridView1.Rows[i].FindControl("TextBox2")).Text + ",'" + DdlACYear.SelectedItem.Text + "'," + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value + ")");
        }
        GridView1.DataSource = null;
        GridView1.DataBind();


    }
}