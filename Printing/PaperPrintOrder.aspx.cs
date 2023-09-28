using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data ;

public partial class Printing_PaperPrintOrder : System.Web.UI.Page
{
    public CommonFuction comm = new CommonFuction();
    public DataSet dd = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dd = comm.FillDatasetByProc("call GetpaperDetailsbyOrdertest('" + Request.QueryString["OrderNo"] + "')");
            GridView1.DataSource = dd.Tables[0]; //comm.FillDatasetByProc("call GetpaperDetailsbyOrder('9174')");
            GridView1.DataBind();
        }
    }
}