using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
public partial class Depo_UpdateChallanDetails : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                DataSet dd = comm.FillDatasetByProc("call USP_DPTUpdateScheamChallanDate(" + Session["UserID"] + ")");
                GridView1.DataSource = dd.Tables[0];
                GridView1.DataBind();
            }
        }

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    //if (((HiddenField)e.Row.FindControl("HiddenField1")).Value != "1")
        //    //{ e.Row.FindControl("rb1")
        //    string A2 = ((HiddenField)e.Row.FindControl("HiddenField1")).Value;
        //    HtmlAnchor  aa2 = ((HtmlAnchor)e.Row.FindControl("aa")) ;
        //    if (A2 == "0")
        //    {

        //        //e.Row.Style.Add("background-color", "#FFFF00!important");
        //    }
        //    else {
        //        aa2.HRef = "javascript:void(0);";
        //    }
        //}
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ScheamBookDistribution.aspx");
    }
}