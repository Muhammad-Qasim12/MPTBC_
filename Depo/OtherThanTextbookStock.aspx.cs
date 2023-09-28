using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_OtherThanTextbookStock : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            GridView1.DataSource = comm.FillDatasetByProc("call USP_StockOtherThan("+Session["UserID"]+")");
            GridView1.DataBind();
        }

    }
}