using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

public partial class Printing_View_001PrintOrderPrinter : System.Web.UI.Page
{
    WorkOrderDetails objWorkOrderDetails = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GridFillLoad();
        }
    }
    public void GridFillLoad()
    {
        try
        {
            objWorkOrderDetails = new WorkOrderDetails();
            objWorkOrderDetails.Printer_regid_i = int.Parse(Session["UserID"].ToString());
            GrdPaperMaster.DataSource = objWorkOrderDetails.PrintOrderFill(txtSearch.Text);
            GrdPaperMaster.DataBind();
        }
        catch { }

    }
  
    protected void GrdPaperMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdPaperMaster.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            objWorkOrderDetails = new WorkOrderDetails();
            GrdPaperMaster.DataSource = objWorkOrderDetails.PrintOrderFill(txtSearch.Text);
            GrdPaperMaster.DataBind();
        }
        catch { }
    }
  
}