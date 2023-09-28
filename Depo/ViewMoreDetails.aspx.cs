using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_ViewMoreDetails : System.Web.UI.Page
{
    public DataSet dt, dtt;
    public CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.QueryString["id"] != null)
        //{
        //    ViewState["OrderNo"] = api.Decrypt(Request.QueryString["id"]);
        //    fillgrd();

        //}

    }
    int TotalAmount;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {


                try
                {

                    TotalAmount = TotalAmount + Convert.ToInt32(e.Row.Cells[2].Text);
                }
                catch { }

            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[2].Text = TotalAmount.ToString();

        }
    }
}