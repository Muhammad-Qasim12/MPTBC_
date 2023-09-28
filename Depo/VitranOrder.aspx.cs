using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Depo_VitranOrder : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet dt = comm.FillDatasetByProc("call USP_GetvitranNirdesh('" + comm.GetFinYear() + "'," + Session["UserID"] + ")");
            GridView1.DataSource = dt.Tables[1];
            GridView1.DataBind();
        }
    }
}