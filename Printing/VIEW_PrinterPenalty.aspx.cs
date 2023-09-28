using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using MPTBCBussinessLayer;

public partial class Printing_VIEW_PrinterPenalty : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    PRI_PrinterPenalty obPRI_PrinterPenalty = null;
    CommonFuction obCommonFuction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
        }
    }
    public void FillData()
    {
        try
        {
            obPRI_PrinterPenalty = new PRI_PrinterPenalty();
            obPRI_PrinterPenalty.PenaltyID_I = 0;
            obPRI_PrinterPenalty.PenaltyID_I = Convert.ToInt32(Session["PenaltyID_I"]);
            GrdPrinterPenaltyDetails.DataSource = obPRI_PrinterPenalty.Select();
            GrdPrinterPenaltyDetails.DataBind();

        }
        catch
        {
        }
        finally
        {
            obPRI_PrinterPenalty = null;
        }
    }
    protected void GrdPrinterPenaltyDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obPRI_PrinterPenalty = new PRI_PrinterPenalty();
        string str = GrdPrinterPenaltyDetails.DataKeys[e.RowIndex].Value.ToString();
        obPRI_PrinterPenalty.Delete(Convert.ToInt32(str));
        FillData();
    }
    protected void GrdPrinterPenaltyDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdPrinterPenaltyDetails.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("PrinterPenalty.aspx");
    }
}