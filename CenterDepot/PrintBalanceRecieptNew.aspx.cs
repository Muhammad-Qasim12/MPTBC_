using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.IO;
using MPTBCBussinessLayer.Paper;
using MPTBCBussinessLayer;


public partial class CenterDepot_PrintBalanceRecieptNew : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objdb = new APIProcedure();
    DataTable ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Ono"] != null)
            {
                btnExportPDF.Visible = false;
                string Brno = objdb.Decrypt(Request.QueryString["Ono"].ToString());
                string PrinterId = objdb.Decrypt(Request.QueryString["PrinterId"].ToString());
                string acyear = objdb.Decrypt(Request.QueryString["acyr"].ToString());

                ddlAcYear.ClearSelection();
                try
                {
                    ddlAcYear.Items.FindByValue(acyear).Selected = true;
                }
                catch { }

                //ddlAcYear_SelectedIndexChanged(null,null);

                fillPrinterDDlPrint();
                ddlPrinter.ClearSelection();
                try
                {
                    ddlPrinter.Items.FindByValue(PrinterId).Selected = true;
                }
                catch { }
                ddlPrinter_OnSelectionChanged(null, null);

                ddlBRRecieptNo.ClearSelection();
                try
                {
                    ddlBRRecieptNo.Items.FindByText(Brno).Selected = true;
                }
                catch { }

                if (ddlBRRecieptNo.Items.Count > 0 && ddlBRRecieptNo.SelectedValue != "Select" && ddlBRRecieptNo.SelectedValue != "")
                {
                    RadioButtonList1.ClearSelection();
                    RadioButtonList1.Items.FindByValue("1").Selected = true;
                    btnSearch_Click(null, null);
                }
                
            }
            else
            {
                btnExportPDF.Visible = false;
                BindPrinterDDL();
            }
            
        }
    }

    private void fillPrinterDDlPrint()
    {
        PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.Printer_RedID_I = 0;
        DataSet ds = obPRI_PaperAllotment.SelectddlPrinterName();
        ddlPrinter.DataSource = ds.Tables[0];
        ddlPrinter.DataTextField = "NameofPressHindi_V";
        ddlPrinter.DataValueField = "Printer_RedID_I";
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, "Select");
    }

    public void BindPrinterDDL()
    {
        PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.Printer_RedID_I = 0;
        DataSet ds = obPRI_PaperAllotment.SelectddlPrinterName();
        ddlPrinter.DataSource = ds.Tables[0];
        ddlPrinter.DataTextField = "NameofPressHindi_V";
        ddlPrinter.DataValueField = "Printer_RedID_I";
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, "Select");

        ddlBRRecieptNo.DataBind();
        ddlBRRecieptNo.Items.Insert(0, "Select");
        ddlBRRecieptNo.Enabled = false;
    }

    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            ddlAcYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
            // ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
    }

    public void BRFill()
    {
        try
        {
            DataTable dtt = obCommonFuction.FillTableByProc("call USP_PRI_Fill_PrintBalanceParchiDDL('" + ddlPrinter.SelectedValue + "','"+ddlAcYear.SelectedItem.Text+"')");
            ddlBRRecieptNo.DataSource = dtt;
            //ddlBRRecieptNo.DataTextField = "BalanceRecieptNo_V";
            ddlBRRecieptNo.DataTextField = "BalanceRecieptNo";
            ddlBRRecieptNo.DataValueField = "BRId";
            ddlBRRecieptNo.DataBind();
            ddlBRRecieptNo.Items.Insert(0, "Select");
            ddlBRRecieptNo.Enabled = true;
        }
        catch { }
    }

    protected void ddlPrinter_OnSelectionChanged(object sender, EventArgs e)
    {
        try
        {
            ddlBRRecieptNo.SelectedIndex = -1;
            ddlBRRecieptNo.Enabled = false;
            rptPrint.DataSource = null;
            btnExportPDF.Visible = false;

            rptPrint.DataBind();
            if (ddlPrinter.SelectedItem.Text != "Select" && ddlPrinter.SelectedItem.Text != "")
            {
                BRFill();
            }
        }
        catch { }
    }

    protected void ddlBR_OnSelectionChanged(object sender, EventArgs e)
    {

        fillRpt();
        if (rptPrint.Items.Count > 0)
        {
            btnExportPDF.Visible = true;
        }
        else
            btnExportPDF.Visible = false;
    }

    private void fillRpt()
    {
        string OrderNo = ddlBRRecieptNo.SelectedValue;
        //string BRRecptNo = "B17057001";
        DataTable dtt = obCommonFuction.FillTableByProc("call USP_PRI_Print_BalanceParchi('" + ddlAcYear.SelectedItem.Text + "','" + OrderNo + "','" + RadioButtonList1.SelectedValue + "','" + ddlPrinter.SelectedValue + "')");
       
            rptPrint.DataSource = dtt;
            rptPrint.DataBind();
      
      
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            fillRpt();
            if (rptPrint.Items.Count > 0)
            {
                btnExportPDF.Visible = true;
            }
            else
                btnExportPDF.Visible = false;
        }
        catch { }
        
    }

    protected void rpt_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblTruck = (Label)e.Item.FindControl("lblTruck");
                int cnt = ds.Rows.Count; string str = "";
            
                for (int i = 0; i <= ds.Rows.Count - 1; i++)
                {               
                   str += ds.Rows[i]["TruckNo"].ToString() + ", ";                   
                }

                string pen = ""; string ult = "";
                if (RadioButtonList1.SelectedValue == "2")
                {
                    
                    if (str != "")
                    {
                        String[] arr = str.Split(',');                        
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (arr[i].Trim() != ult.Trim())
                            {
                                pen += ult + ", ";
                                ult = arr[i];
                            }
                        }
                    }
                    //lblTruck.Text = pen.Remove(pen.LastIndexOf(","));
                    lblTruck.Text = (pen.Trim(',').Trim()).ToString().TrimEnd(',');
                }
              
                Label lblBalanceParchiIssuePerson = (Label)e.Item.FindControl("lblBalanceParchiIssuePerson");
                lblBalanceParchiIssuePerson.Text = ds.Rows[0]["IssuePerson"].ToString();
                if (RadioButtonList1.SelectedValue == "2")
                { 
                Label lblPradaykarta = (Label)e.Item.FindControl("lblPradaykarta");
                lblPradaykarta.Text = ds.Rows[0]["SupplierName"].ToString();
               
                Label lblPraaptkarta = (Label)e.Item.FindControl("lblPraaptkarta");
                lblPraaptkarta.Text = ds.Rows[0]["RecieverName"].ToString();

                if (ds.Rows[0]["RecieverName22"].ToString() != "")
                {
                    lblPraaptkarta.Text = ds.Rows[0]["RecieverName22"].ToString();
                }
                else if (ds.Rows[1]["RecieverName22"].ToString() != "")
                {
                    lblPraaptkarta.Text = ds.Rows[1]["RecieverName22"].ToString();
                }

                }

            }

            if (e.Item.ItemType == ListItemType.Header)
            {
                ds = (DataTable)(rptPrint.DataSource);

                Label lblBRNo = (Label)e.Item.FindControl("lblBRNo");
                lblBRNo.Text = ds.Rows[0]["BalanceRecieptNo"].ToString();
                HtmlTableCell thBefore = (HtmlTableCell)e.Item.FindControl("thBefore");
               
                Label lblAcYear = (Label)e.Item.FindControl("lblAcYear");
                lblAcYear.Text = ddlAcYear.SelectedItem.Text;
                if (RadioButtonList1.SelectedValue == "2")
                { 
                Label lblWarehousename = (Label)e.Item.FindControl("lblWarehousename");
                lblWarehousename.Text = ds.Rows[0]["WareHouseName_V"].ToString();
                thBefore.Visible = false;
                }
                else
                    thBefore.Visible = true;

                Label lblBRDate = (Label)e.Item.FindControl("lblBRDate");
                lblBRDate.Text = ds.Rows[0]["BalanceRecieptDate"].ToString();

                Label lblPRinterNameAddress = (Label)e.Item.FindControl("lblPRinterNameAddress");
                lblPRinterNameAddress.Text = ds.Rows[0]["NameofPress_V"].ToString() + "/" + ds.Rows[0]["FullAddress_V"].ToString();

                Label lblTitle_V = (Label)e.Item.FindControl("lblTitle_V");
                lblTitle_V.Text = ds.Rows[0]["TitleHindi_V"].ToString();

            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlTableCell tdBefore = (HtmlTableCell)e.Item.FindControl("tdBefore");
                if (RadioButtonList1.SelectedValue == "2")
                {
                    tdBefore.Visible = false;
                }
                else
                    tdBefore.Visible = true;
            }
        }
        catch { }
    }
 
    protected void btnExportPDF_Click(object sender, EventArgs e)
    {

    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlBR_OnSelectionChanged( sender,  e);
    }
    protected void ddlAcYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlPrinter.ClearSelection();
            rptPrint.DataSource = null;
            rptPrint.DataBind();
            btnExportPDF.Visible = false;
            ddlBRRecieptNo.ClearSelection();
        }
        catch { }
    }
}