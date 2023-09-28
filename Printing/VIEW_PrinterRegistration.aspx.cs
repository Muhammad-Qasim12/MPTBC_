using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;


public partial class Printing_VIEW_PrinterRegistration : System.Web.UI.Page
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

        obPRI_PrinterRegistration.Printer_RedID_I = 0;
        grdPrinterRegistration.DataSource = obPRI_PrinterRegistration.PrinterRegistrationLoad();
        grdPrinterRegistration.DataBind();

    
    }

    protected void btnAdd_Click(object sender, EventArgs e) 
    {
        Response.Redirect("PrinterRegistration.aspx");
    
    }

    protected void grdPrinterRegistration_PageIndexChanging(object sender, GridViewPageEventArgs e) 
    {

        grdPrinterRegistration.PageIndex = e.NewPageIndex;

        load();
    }

}