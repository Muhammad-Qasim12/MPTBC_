using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distribution_DemandReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (RadioButtonList2.SelectedValue == "1")
        {
            Response.Redirect(RD1.SelectedValue);
        }
        if (RadioButtonList2.SelectedValue == "2")
        {
            Response.Redirect(RD2.SelectedValue);
        }
        if (RadioButtonList2.SelectedValue == "3")
        {
            Response.Redirect(RD3.SelectedValue);
        }
    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList2.SelectedValue == "1")
        {
            RD1.Visible = true;
            RD2.Visible = false;
            RD3.Visible = false;
        }
        if (RadioButtonList2.SelectedValue == "2")
        {
            RD1.Visible = false;
            RD2.Visible = true;
            RD3.Visible = false;
        }
        if (RadioButtonList2.SelectedValue == "3")
        {
            RD1.Visible = false;
            RD2.Visible = false;
            RD3.Visible = true;
        }
    }
}