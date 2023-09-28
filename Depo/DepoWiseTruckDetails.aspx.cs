using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.Store;
using System.Data;
using System.Globalization;
using System.IO;

public partial class Depo_DepoWiseTruckDetails : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    string leaderName = string.Empty;
    string leaderName2 = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            GridView1.DataSource = comm.FillDatasetByProc("call USP_GetDepoWiseTruckno()");
            GridView1.DataBind();
        }
    }
    protected void ltrLeader_DataBinding(object sender, EventArgs e)
    {
        Literal lt = (Literal)sender;
        lt.Text = (Eval("DepoName_V")).ToString();

        if (!string.Equals(lt.Text, leaderName))
        {
            leaderName = lt.Text;
        }
        else
        {
            lt.Text = string.Empty;
        }
    }
    protected void ltrLeader1_DataBinding(object sender, EventArgs e)
    {
        Literal lt = (Literal)sender;
        lt.Text = (Eval("District_Name_Hindi_V")).ToString();

        if (!string.Equals(lt.Text, leaderName2))
        {
            leaderName2 = lt.Text;
        }
        else
        {
            lt.Text = string.Empty;
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcell();
            //Class1 cls = new Class1();
            //cls.Export("Export.xls", GrdStockAvailability, "Export");
        }
        catch { }
        finally { }
    }
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "TruckDetails.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - word";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        GridView1.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}