using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_PrnterReceiveDashboard : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            GridView2.DataSource = comm.FillDatasetByProc("call USP_PrinterUpdate()");
            GridView2.DataBind();
            //CALL `UpdatePrinterData`()
        }
    }
}