using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Printing_PrinterChallanRpt : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    public DataSet ds1;
    protected void Page_Load(object sender, EventArgs e)
    {
        ds1 = obCommonFuction.FillDatasetByProc("call USP_Prin_ChallanReport(0," + Request.QueryString["ID"].ToString() + ")");
        if (!IsPostBack)
        {
            try
            {
                Label1.Text = ds1.Tables[0].Rows[0]["NameofPress_V"].ToString (); //
              
                DataSet ds = obCommonFuction.FillDatasetByProc("call USP_Prin_ChallanReport(1," + Request.QueryString["ID"].ToString() + ")");
                GrdMismatch.DataSource = ds.Tables[0];
                GrdMismatch.DataBind();
            }
            catch { }
            finally { }
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        //ds1 = obCommonFuction.FillDatasetByProc("call USP_Prin_ChallanReport(0," + Request.QueryString["ID"].ToString() + ")");

    }
    protected void btnExport_Click1(object sender, EventArgs e)
    {
       // ds1 = obCommonFuction.FillDatasetByProc("call USP_Prin_ChallanReport(0," + Request.QueryString["ID"].ToString() + ")");
    }
}