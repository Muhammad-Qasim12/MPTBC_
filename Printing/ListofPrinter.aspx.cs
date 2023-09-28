using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using MPTBCBussinessLayer.DistributionB;
using System.IO;
using System.Data;
public partial class Printing_ListofPrinter : System.Web.UI.Page
{
    CommonFuction obj = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ddlstate.DataSource = obj.FillDatasetByProc("SELECT stateid,Statename_eng_V FROM `statemaster_m`");
            ddlstate.DataTextField = "Statename_eng_V";
            ddlstate.DataValueField = "stateid";
            ddlstate.DataBind();
           // ddlstate.SelectedIndex = 0;
           ddlstate.Items.Insert(0, new ListItem("All", "0"));

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string stateID = "0";
        if (ddlstate.SelectedIndex == 0)
        {
            stateID = "0";
        }
        else
        {
            stateID = ddlstate.SelectedValue;
        }
        GridView1.DataSource = obj.FillDatasetByProc("call USP_PrinterListN('"+RadioButtonList1.SelectedValue+"','"+ stateID +"')");
       GridView1.DataBind();
    }
}