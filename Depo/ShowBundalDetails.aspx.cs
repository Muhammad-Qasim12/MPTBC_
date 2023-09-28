using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.IO;
public partial class Depo_ShowtransportDetails : System.Web.UI.Page
{

    CommonFuction obCommon = new CommonFuction();
    APIProcedure api = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlTrnasportName.DataTextField = "NameofPress_V";
            ddlTrnasportName.DataValueField = "Printer_RedID_I";
            obCommon = new CommonFuction();
            DataSet dd = obCommon.FillDatasetByProc("call USP_PRI004_PrinterRegistrationload_wo_wise(0,'2018-2019')");
            ddlTrnasportName.DataSource = dd;
            ddlTrnasportName.DataBind();
            ddlTrnasportName.Items.Insert(0, new ListItem("All", "0"));


            DataSet ds1 = obCommon.FillDatasetByProc("call  USP_Bacodemis()");
            //Label lbl = new Label();
            lblAddress.Text = Convert.ToString(ds1.Tables[0].Rows[0][0]);

            GridView1.DataSource = ds1.Tables[0];
            GridView1.DataBind();
            btnExport.Visible = true;
            btnExportPDF.Visible = true;
                
             
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
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    public void ExportToExcell()
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
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("TransportReport.aspx");
    //}
    
}