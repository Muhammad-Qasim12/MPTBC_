using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using MPTBCBussinessLayer;
public partial class Depo_VIEW_DPT002 : System.Web.UI.Page
{
    TransportMaster obTransportMaster = null;
    CommonFuction obCommonFuction = null;
    public APIProcedure api = new APIProcedure();
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
            obTransportMaster = new TransportMaster();
            obTransportMaster.TransportID_I = 0;
            obTransportMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
            GrdTransport.DataSource = obTransportMaster.Select();
            GrdTransport.DataBind();

        }
        catch
        {
        }
        finally { }
    }
    
    protected void GrdTransport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdTransport.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("DPT002_TransportMaster.aspx");
    }
    protected void GrdTransport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "eDelete")
        {
            obTransportMaster = new TransportMaster();
            obTransportMaster.Delete(Convert.ToInt32(e.CommandArgument));
            FillData();
            Response.Write("<script>alert('Record has deleted');</script>");
        }
    }
}