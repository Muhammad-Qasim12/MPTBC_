using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Printing_PrinterList : System.Web.UI.Page
{
    CommonFuction obj = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            GridView1.DataSource = obj.FillDatasetByProc("call GetPrinterregexpiryList(90)");
            GridView1.DataBind();
        
        }
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int md ;
        md = Convert.ToInt32(TextBox1.Text);
        GridView1.DataSource = obj.FillDatasetByProc("call GetPrinterregexpiryList("+ md +")");
        GridView1.DataBind();
    }
}