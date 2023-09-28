using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using MPTBCBussinessLayer;
//using Microsoft.Reporting.WebForms;
using System.Collections;
public partial class Printing_PrinterGroupAllotment : System.Web.UI.Page
{
    DataTable Dt; WorkOrderDetails obWorkOrderDetails = null;
    DataSet DS;
    CommonFuction obCommonFuction = new CommonFuction();
    PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obCommonFuction = new CommonFuction();
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            DdlACYear_SelectedIndexChanged(sender, e);
            obPRI_PaperAllotment = new PRI_PaperAllotment();
            obPRI_PaperAllotment.Printer_RedID_I = 0;
            DataSet ds = obPRI_PaperAllotment.SelectddlPrinterName();
            ddlPrinterName.DataSource = ds.Tables[0];
            ddlPrinterName.DataTextField = "NameofPressHindi_V";
            ddlPrinterName.DataValueField = "Printer_RedID_I";
            //ddlPrinterName.DataValueField = "NameofPress_V";
            ddlPrinterName.DataBind();
            ddlPrinterName.Items.Insert(0, "सलेक्ट करे");
        }
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("call Prin_loadTender('" + DdlACYear.SelectedItem.Text + "')");
        ddlTenderID_I.DataSource = dd.Tables[0];
        ddlTenderID_I.DataValueField = "TenderId_I";
        ddlTenderID_I.DataTextField = "TenderNo_V";
        ddlTenderID_I.DataBind();
        ddlTenderID_I.Items.Insert(0, "Select..");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string[] al = TextBox1.Text.Split(',');


        for (int i = 0; i < Convert.ToInt32(al.Length); i++)
        {
            //string ID = al[i].ToString();
            obCommonFuction.FillDatasetByProc("call PrinSaveLunList(0,'" + ddlPrinterName.SelectedItem.Text + "','" + ddlTenderID_I.SelectedValue + "','" + al[i] + "')");
        }

        DataSet dd = obCommonFuction.FillDatasetByProc("call PrinSaveLunList(1,'','" + ddlTenderID_I.SelectedValue + "','')");
        GridView1.DataSource = dd.Tables[0];
        GridView1.DataBind();
        TextBox1.Text = "";
        ddlPrinterName.SelectedIndex = 0;
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('आपका का डाटा सुरक्षित हो चुका  है  |');</script>");
    }
    protected void ddlTenderID_I_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("call PrinSaveLunList(1,'','" + ddlTenderID_I.SelectedValue + "','')");
        GridView1.DataSource = dd.Tables[0];
        GridView1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("VIEW_TenderDetails.aspx");
    }
}