using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Printing_ChallanType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            Response.Redirect("View0022_PrinChallanDetails.aspx");
        }
        else if (RadioButtonList1.SelectedValue == "2")
        {
            Response.Redirect("VIEW0022_PrinChallanDetailsU_E.aspx");
        }

    }
}