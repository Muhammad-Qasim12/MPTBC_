using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CenterDepot_Rellnumber : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            CommonFuction comm = new CommonFuction();
            DataSet dd = comm.FillDatasetByProc("call GetRellbyDetails('" + txtSearch.Text + "')");
            if (dd.Tables[0] != null && dd.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = dd.Tables[0];
                GridView1.DataBind();
            }
            else if (dd.Tables[1] != null && dd.Tables[1].Rows.Count > 0)
            {
                GridView1.DataSource = dd.Tables[1];
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = string.Empty;
                GridView1.DataBind();
            }
        }
        catch { }
    }
}