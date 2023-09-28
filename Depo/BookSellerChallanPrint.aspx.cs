using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_BookSellerChallanPrint : System.Web.UI.Page
{
    CommonFuction objcomm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.DataSource = objcomm.FillDatasetByProc("CALL USP_PrinBookSeller(" + Request.QueryString["BookSelleLogin"] + "," + Request.QueryString["OrderNo"] + ")");
            GridView1.DataBind();
        }
    }
    int TotalBook, totalBundle;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                try
                {

                    //TextBox txtSamany = (TextBox)e.Row.FindControl("txtSamany");
                    TotalBook +=Convert.ToInt32 (e.Row.Cells[3].Text);
                }
                catch { }
                try
                {
                    totalBundle += Convert.ToInt32(e.Row.Cells[4].Text);
                }
                catch { }


            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label FToNo_I0 = (Label)e.Row.FindControl("FToNo_I0");
            Label lblFLoojBook = (Label)e.Row.FindControl("lblFLoojBook");
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[3].Text = TotalBook.ToString();
            e.Row.Cells[4].Text = totalBundle.ToString();

        }
    }
}