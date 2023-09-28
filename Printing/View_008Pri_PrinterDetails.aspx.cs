using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Printing_View_008Pri_PrinterDetails : System.Web.UI.Page
{
    DataSet ds, DS;
    CommonFuction obCommonFuction = new CommonFuction();
    PRIN_PrinterBooksPrintingDetails obj = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //USP_PRI012_PrinterOrderDtlChild
        }
    }

    public void LoadDetails()
    {
        DateTime DteCheck;
        string RptDate = "", GrDate = "";
        if (txtFromDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtFromDate.Text, cult);
            }
            catch { RptDate = "NoDate"; }
        }
        if (txtToDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtToDate.Text, cult);
            }
            catch { GrDate = "NoDate"; }
        }


        if (RptDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct From Date.');</script>");
        }
        else if (GrDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct End Date.');</script>");
        }

        else
        { 
            try
            {
                ds = obCommonFuction.FillDatasetByProc("CALL USP_PRI012_PrinterOrderDtlChild('" + ddlPrinterName.SelectedItem.Value.ToString().Replace("All", "0") + "','" + txtFromDate.Text + "','" + txtToDate.Text + "',4,'" + DdlACYear.SelectedItem.Text + "')");
                grdPrintingDetail.DataSource = ds.Tables[0];
                grdPrintingDetail.DataBind();
            }

            catch (Exception ex) { }

            finally { obj = null; }
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadDetails();
    }
    protected void grdPrintingDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblPrinter_RedID_I = (Label)e.Row.FindControl("lblPrinter_RedID_I");
            Panel pnlName = (Panel)e.Row.FindControl("pnlName");


            GridView GridView1 = (GridView)e.Row.FindControl("GridView1");
            DS = obCommonFuction.FillDatasetByProc("CALL USP_PRI008_prinDailyMISdetail('" + DdlACYear.SelectedItem.Text + "','" + lblPrinter_RedID_I.Text.ToString()  + "')");
            if (DS.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = DS.Tables[0];
                GridView1.DataBind();
                
            }
            else
            {
               
            }


            GridView grdPrintingDetailChild = (GridView)e.Row.FindControl("grdPrintingDetailChild");
            DS = obCommonFuction.FillDatasetByProc("CALL USP_PRI012_PrinterOrderDtlChild('" + lblPrinter_RedID_I.Text.ToString() + "','" + txtFromDate.Text + "','" + txtToDate.Text + "',1,'" + DdlACYear.SelectedItem.Text + "')");
            if (DS.Tables[0].Rows.Count > 0)
            {
                grdPrintingDetailChild.DataSource = DS.Tables[0];
                grdPrintingDetailChild.DataBind();































































                pnlName.Attributes.Add("Style", "background-color:green;width:100%;padding:10px;color:white;");
            }
            else
            {
                pnlName.Attributes.Add("Style", "background-color:Red;width:100%;padding:10px;color:white;");
            }
        }
    }
    protected void DdlACYear_Init(object sender, EventArgs e)
    {

        DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
        DdlACYear.DataValueField = "AcYear";
        DdlACYear.DataTextField = "AcYear";
        DdlACYear.DataBind();
        DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
    }

    protected void ddlPrinterName_Init(object sender, EventArgs e)
    {

        ddlPrinterName.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_PRI012_PrinterOrderDtlChild('','','',2,'" + DdlACYear.SelectedItem.Text + "')");
        ddlPrinterName.DataTextField = "NameofPress_V";
        ddlPrinterName.DataValueField = "Printer_RedID_I";
        ddlPrinterName.DataBind();
        ddlPrinterName.Items.Insert(0, "All");
    }

    public void message(string mess, string messType)
    {
        messDiv.Style.Add("display", "block");
        lblMess.Text = mess;

        if (messType == "ERROR")
        {

            messDiv.CssClass = "response-msg error ui-corner-all";
        }

        else if (messType == "SUCCESS")
        {
            messDiv.CssClass = "response-msg success ui-corner-all";

        }

        else if (messType == "INFO")
        {
            messDiv.CssClass = "response-msg inf ui-corner-all";

        }

    }

}