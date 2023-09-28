using MPTBCBussinessLayer.Paper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PaperVendor_PVHomePage : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt, dt;
    PPR_RDLCData objReports = new PPR_RDLCData();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {

            if (!Page.IsPostBack)
            {
                LoadHomePage();
            }
        }
        else
        {
            Response.Redirect("../Login.aspx");
        }
    }
    public void LoadHomePage()
    {
        //Stock Details
        //Dt = objReports.StatusDeshBoard("", 0, 0);
        //if (Dt.Rows.Count > 0)
        //{
        //    GrdStockDetails.DataSource = Dt;
        //    GrdStockDetails.DataBind();
        //}
        // Paper Mill Details
        Dt = objReports.StatusDeshBoard("", int.Parse(Session["UserID"].ToString()), 5);
        if (Dt.Rows.Count > 0)
        {
            GvPaperMillDispch.DataSource = Dt;
            GvPaperMillDispch.DataBind();
        }
        else
        {
            GvPaperMillDispch.DataSource = string.Empty;
            GvPaperMillDispch.DataBind();
        }
        // Printer Details
        //Dt = objReports.StatusDeshBoard("", 0, 1);
        //if (Dt.Rows.Count > 0)
        //{
        //    GvPrinterDispDtl.DataSource = Dt;
        //    GvPrinterDispDtl.DataBind();
        //}
        // //Work Plan Details
        Dt = objReports.StatusDeshBoard("",int.Parse( Session["UserID"].ToString()), 4);
        if (Dt.Rows.Count > 0)
        {
            GvWorkPlan.DataSource = Dt;
            GvWorkPlan.DataBind();
        }
        else
        {
            GvWorkPlan.DataSource = string.Empty;
            GvWorkPlan.DataBind();
        }
    }
}