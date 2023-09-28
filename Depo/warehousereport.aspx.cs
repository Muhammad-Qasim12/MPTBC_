using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.IO;
public partial class Depo_warehousereport : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GrdWarehouse.DataSource = obCommonFuction.FillDatasetByProc("call USP_WarehouseD()");
            GrdWarehouse.DataBind();
        }

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcell();
        }
        catch { }
    }
    public void ExportToExcell()
    {
        try
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "AVASKIJANKARI.xls"));
            Response.Charset = "";
            Response.ContentType = "application / vnd.ms - word";

            StringWriter sw = new StringWriter();
            HtmlTextWriter HW = new HtmlTextWriter(sw);

            ExportDiv.RenderControl(HW);
            Response.Write(sw.ToString());
            Response.End();
            Response.Clear();
        }
        catch { }
    }

    protected void btnExport_Click1(object sender, EventArgs e)
    {
        ExportToExcell();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}