using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Printing_PrinterRenewableLists : System.Web.UI.Page
{
    PRI_PrinterRenewal obPRI_PrinterRenewal = null;
    CommonFuction obCommonFuction = null;

    protected void Page_Load(object sender, EventArgs e)
    
    {
        if(!IsPostBack)
        {
          FillData();
        }
    }

    public void FillData()
    {
        try
        {
            obPRI_PrinterRenewal = new PRI_PrinterRenewal();
            obPRI_PrinterRenewal.Printer_RedID_I = 0;
            //obPRI_PrinterRenewal.PriRenewalID_I = Convert.ToInt32(Session["PriRenewalID_I"]);
            GrdPrinterRenew.DataSource = obPRI_PrinterRenewal.Select();
            GrdPrinterRenew.DataBind();

        }
        catch
        {
        }
        finally
        {
            obPRI_PrinterRenewal = null;
        }
    }

    public void SearchData()
    {
        try
        {
            obPRI_PrinterRenewal = new PRI_PrinterRenewal();
            obPRI_PrinterRenewal.Printer_RedID_I = 0;
            obPRI_PrinterRenewal.NameofPress = Convert.ToString(txtSearch.Text); 
            //obPRI_PrinterRenewal.PriRenewalID_I = Convert.ToInt32(Session["PriRenewalID_I"]);
            GrdPrinterRenew.DataSource = obPRI_PrinterRenewal.SelectSearch();
            GrdPrinterRenew.DataBind();

        }
        catch
        {
        }
        finally
        {
            obPRI_PrinterRenewal = null;
        }
    }

    protected void lnBtnViewRenewal_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");

        try
        {
            LinkButton lnkSender = (LinkButton)sender;
            GridViewRow gv = (GridViewRow)lnkSender.NamingContainer;
            Label lblPrinter_RedID_I = (Label)gv.FindControl("lblPrinter_RedID_I");
            Session["PrinterID"]= lblPrinter_RedID_I.Text ;
            obPRI_PrinterRenewal = new PRI_PrinterRenewal();
            if (lblPrinter_RedID_I.Text != "")
            {
                obPRI_PrinterRenewal.Printer_RedID_I = Convert.ToInt32(lblPrinter_RedID_I.Text);
                obPRI_PrinterRenewal.PriRenewalID_I = 0;
                GrdViewRenewable.DataSource = obPRI_PrinterRenewal.Select();
                GrdViewRenewable.DataBind();
            }
            else
            {
                GrdViewRenewable.DataSource = string.Empty;
                GrdViewRenewable.DataBind();
            }
        
            }
        catch
        {
        }
        finally
        {
            obPRI_PrinterRenewal = null;
        }
    }
    protected void lnBtnBack_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }

    protected void GrdViewRenewable_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obPRI_PrinterRenewal = new PRI_PrinterRenewal();
        string str = GrdViewRenewable.DataKeys[e.RowIndex].Value.ToString();
        obPRI_PrinterRenewal.Delete(Convert.ToInt32(str));
        fillrenewalgrid( Session["PrinterID"].ToString());
    }
    protected void GrdPrinterRenew_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdPrinterRenew.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void GrdPrinterRenew_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void fillrenewalgrid(string str1)
    {
        //LinkButton lnkSender = (LinkButton)sender;
        //GridViewRow gv = (GridViewRow)lnkSender.NamingContainer;
        //Label lblPrinter_RedID_I = (Label)gv.FindControl("lblPrinter_RedID_I");
         
                    obPRI_PrinterRenewal = new PRI_PrinterRenewal();
         //if (lblPrinter_RedID_I.Text != "")
         //        {
                    obPRI_PrinterRenewal.Printer_RedID_I = Convert.ToInt32(str1);
                    obPRI_PrinterRenewal.PriRenewalID_I = 0;
                    GrdViewRenewable.DataSource = obPRI_PrinterRenewal.Select();
                    GrdViewRenewable.DataBind();
                 
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SearchData();
    }
}