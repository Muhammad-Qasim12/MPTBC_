using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Distribution_VitranNoGenrate : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DropDownList2.DataSource = obCommonFuction.FillDatasetByProc("select distinct OrderNo from dis_demandtoprintingnew where AcYear='" + DdlACYear.SelectedItem.Text + "'");
        //DropDownList2.DataValueField = "OrderNo";
        //DropDownList2.DataTextField = "OrderNo";
        //DropDownList2.DataBind();
        //DropDownList2.Items.Insert(0, new ListItem("-Select-", "0"));
    }
}