using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

public partial class Printing_PrinterBookDistribution : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    PRI_PrinterPenalty ObjPRI_PrinterPenalty = null;
    int Printer_Id ;
    protected void Page_Load(object sender, EventArgs e)
    {
        Printer_Id = Convert.ToInt32(Session["UserID"]);
        if (!Page.IsPostBack)
        {
          
        }
    }
    public void GridFillLoad()
    {
        try
        {
            ObjPRI_PrinterPenalty = new PRI_PrinterPenalty();
            GrdEval.DataSource = ObjPRI_PrinterPenalty.BookDistributionDtl(Printer_Id, DdlACYear.SelectedItem.Text);
            GrdEval.DataBind();
        }
        catch { }
    }


    protected void DdlACYear_Init(object sender, EventArgs e)
    {
        DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
        DdlACYear.DataValueField = "AcYear";
        DdlACYear.DataTextField = "AcYear";
        DdlACYear.DataBind();
        DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        GridFillLoad();
    }
}