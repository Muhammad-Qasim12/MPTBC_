using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;

public partial class Printing_PrintertCapecity : System.Web.UI.Page
{
    PRI_PaperAllotment obPRI_PaperAllotment = null;
    public DataSet ds = new DataSet();
 public   CommonFuction obCommonFuction = new CommonFuction();
 public int p1, p2, p3, p4,p5,p6;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadACyear();
            obPRI_PaperAllotment = new PRI_PaperAllotment();
            obPRI_PaperAllotment.Printer_RedID_I = 0;
            DataSet ds = obPRI_PaperAllotment.SelectddlPrinterName();
            ddlPrinterName.DataSource = ds.Tables[0];
            ddlPrinterName.DataTextField = "NameofPress_V";
            ddlPrinterName.DataValueField = "Printer_RedID_I";
            //ddlPrinterName.DataValueField = "NameofPress_V";
            ddlPrinterName.DataBind();
            ddlPrinterName.Items.Insert(0, "सलेक्ट करे");
        }
    }

    public void LoadACyear()
    {
        try
        {

            ddlACYear_I.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlACYear_I.DataValueField = "AcYear";
            ddlACYear_I.DataTextField = "AcYear";
            ddlACYear_I.DataBind();
            ddlACYear_I.SelectedValue = obCommonFuction.GetFinYear();

            ddlACYear_I.Items.Insert(0, new ListItem("All", "0"));
        }
        catch (Exception ex) { }
        finally { }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            ds = obCommonFuction.FillDatasetByProc("call GetPrinterCapecity(" + ddlPrinterName.SelectedValue + ",'" + ddlACYear_I.SelectedItem.Text + "')");
            if (ds.Tables[0].Rows.Count > 0)
            {

                Printer.Visible = true;
            }
            else { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Details not found');</script>"); }
        }
        catch { }
        finally { }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

    }
}