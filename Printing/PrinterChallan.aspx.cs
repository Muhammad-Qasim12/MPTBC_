using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Printing_PrinterChallan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            Response.Redirect("PrinterChallanDetails.aspx");
        }
        else if (RadioButtonList1.SelectedValue == "2")
        {
            Response.Redirect("PrinterChallanDetailsU_E.aspx");
        }

    }
}