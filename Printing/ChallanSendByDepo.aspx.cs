using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

public partial class Printing_ChallanSendByDepo : System.Web.UI.Page
{
    // CultureInfo cult = new CultureInfo("gu-IN", true);
    PRI_PrinterRegistration obPRI_PrinterRegistration = null;
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
            obPRI_PrinterRegistration = new PRI_PrinterRegistration();

            obPRI_PrinterRegistration.Printer_RedID_I = 0;//Convert.ToInt32(Session["UserID"]);
            GrdChallanDetail.DataSource = obPRI_PrinterRegistration.GetChallanDetailFromDepo();
            GrdChallanDetail.DataBind();
        }
        catch  {    }
    }
    
    protected void GrdWarehouse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdChallanDetail.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow gv = (GridViewRow)lnk.NamingContainer;
            Label lblPinterID_I = (Label)gv.FindControl("lblPinterID_I");
            obPRI_PrinterRegistration = new PRI_PrinterRegistration();
            int i = obPRI_PrinterRegistration.GetChallanDetailFromDepoStatusChange(int.Parse(lblPinterID_I.Text));
            if (i > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('चालान को बिल में जोड़ दिया गया है |');</script>");
            }
            else
            {
              //  ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill();</script>");
            }
          FillData();
            
        }
        catch { }
    }
 
}