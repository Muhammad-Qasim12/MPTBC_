using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Printing_ViewOtherThenTextbook : System.Web.UI.Page
{
    CommonFuction obj = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrd();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("OtherThenTextbookChallan.aspx");
    }
    public void fillgrd()
    {
        GrdHead.DataSource =obj.FillDatasetByProc("call USP_abcGetChallan("+Session["UserID"]+")");
        GrdHead.DataBind();
  //  USP_abcGetChallan
    }
    protected void GrdHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdHead.PageIndex = e.NewPageIndex;
        fillgrd();
    }

     string previousCov = ""; int firstRow = -1;
     protected void GvReelDetails_RowDataBound(object sender, GridViewRowEventArgs e)
     {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             try
             {
                 DataRowView drv = ((DataRowView)e.Row.DataItem);
                 if (previousCov == drv["ChallanNO"].ToString())
                 {
                     if (GrdHead.Rows[firstRow].Cells[1].RowSpan == 0)
                     {
                         GrdHead.Rows[firstRow].Cells[1].RowSpan = 2;
                         //GridView1.Rows[firstRow].Cells[1].Style.Add("vertical-align", "middle");
                     }
                     else
                     {
                         GrdHead.Rows[firstRow].Cells[1].RowSpan += 1;
                         //GridView1.Rows[firstRow].Cells[1].Style.Add("vertical-align","middle");
                     }
                     e.Row.Cells.RemoveAt(1);

                 }
                 else
                 {
                     //e.Row.VerticalAlign = VerticalAlign.Middle;
                     previousCov = drv["ChallanNO"].ToString();
                     firstRow = e.Row.RowIndex;
                 }
             }
             catch { }
         }
     }
}