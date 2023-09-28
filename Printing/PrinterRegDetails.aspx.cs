using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Printing_PrinterRegDetails : System.Web.UI.Page
{
    PRI_PrinterRegistration obPRI_PrinterRegistration = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            load();
        }
    }


    public void load()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();

        try
        {
            grdPrinterRegistration.DataSource = obPRI_PrinterRegistration.PrinterRegistrationDetailLoad();
            grdPrinterRegistration.DataBind();
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }

    }

    public void loadSearch()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();

        try
        {
            obPRI_PrinterRegistration.NameofPress_V =Convert.ToString( txtSearch.Text); 
            grdPrinterRegistration.DataSource = obPRI_PrinterRegistration.PrinterRegistrationSearchDetailLoad();
            grdPrinterRegistration.DataBind();
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }

    }


    protected void grdPrinterRegistration_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdPrinterRegistration.PageIndex = e.NewPageIndex;

        load();
    }




    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("Printer_Registration.aspx");

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        loadSearch();
    }
}