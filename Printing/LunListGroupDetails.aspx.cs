using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Printing_LunListGroupDetails : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    string Company,PrinterCapecity;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
            ddlAcdmicYr_V.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlAcdmicYr_V.DataValueField = "AcYear";
            ddlAcdmicYr_V.DataTextField = "AcYear";
            ddlAcdmicYr_V.DataBind();
            ddlAcdmicYr_V.SelectedValue = obCommonFuction.GetFinYear();
        }
    }
    protected void ddlAcdmicYr_V_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddlTenderName.DataSource = obCommonFuction.FillDatasetByProc("CALL GetTenderDetailsbyFyYear('"+ddlAcdmicYr_V.SelectedItem.Text+"',0)");
        ddlTenderName.DataValueField = "TenderId_I";
        ddlTenderName.DataTextField = "TenderNo_V";
        ddlTenderName.DataBind();
        ddlTenderName.Items.Insert(0, "Select..");
        //ddlTenderName.SelectedValue = obCommonFuction.GetFinYear();
       // 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("CALL GetTenderDetailsbyFyYear('" + ddlTenderName.SelectedValue  + "',1)");
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call GetLUNListGroupbyDetails('" + ddlAcdmicYr_V.SelectedItem.Text + "','" + dd.Tables[0].Rows[0]["TenderType_V"].ToString() + "'," + ddlTenderName.SelectedValue + ")");
        GridView1.DataBind();
     
    }
    protected void lblPrinter_DataBinding(object sender, EventArgs e)
    {
        Literal lt = (Literal)sender;
        lt.Text = (Eval("Company")).ToString();

        if (!string.Equals(lt.Text, Company))
        {
            Company = lt.Text;
        }
        else
        {
            lt.Text = string.Empty;
        }
    }
    protected void lblPrinterCapacity_DataBinding(object sender, EventArgs e)
    {
        Literal lt1 = (Literal)sender;
        lt1.Text = (Eval("capacity1")).ToString();
       // Company = (Eval("Company")).ToString();
        if (!string.Equals(lt1.Text, PrinterCapecity))
        {
            PrinterCapecity = lt1.Text;
        }
        else
        {

            lt1.Text = string.Empty;
        }
    }
}