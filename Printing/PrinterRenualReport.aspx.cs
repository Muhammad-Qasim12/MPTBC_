using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Printing_PrinterRenualReport : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction ();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_PrinterRenualRepot() ");
          GridView1.DataBind();

        }
    }
}