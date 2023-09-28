using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Depo_RptInterDepoChallan : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlChallano.DataSource = obCommonFuction.FillDatasetByProc("call Getinterdepochallan(0," + Session["UserID"] + ",0)");
            ddlChallano.DataTextField = "ChallanN";
            ddlChallano.DataValueField = "ChallanNo_V";
            ddlChallano.DataBind();
            ddlChallano.Items.Insert(0, "Select..");
            if (Request.QueryString["ChallanNo"] != null)
            {
                ddlChallano.SelectedValue = Request.QueryString["ChallanNo"].ToString();
                GridView1.DataSource = obCommonFuction.FillDatasetByProc("call Getinterdepochallan(1," + Session["UserID"] + "," +Request.QueryString["ChallanNo"].ToString() + ")");
                GridView1.DataBind();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call Getinterdepochallan(1," + Session["UserID"] + ","+ddlChallano.SelectedValue+")");
        GridView1.DataBind();
    }
}