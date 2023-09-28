using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer ;
using MPTBCBussinessLayer.DistributionB;
using System.IO;
using System.Data;
public partial class Printing_Reports_RPT003_GroupAllotment : System.Web.UI.Page
{
    PRI003_RPTGroupAllotment obGroupAllotment = null;
    PRI_PrinterRegistration obPriReg = null;
    DemandfromOthers obDemandfromOthers = new DemandfromOthers();
    CommonFuction obCommon = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadAcYear(); 
            FillData(); 
            btnExport.Visible = false;
            btnExportPDF.Visible = false;

        }
    }


    public void LoadAcYear() 
    {
        obDemandfromOthers.QueryType = -1;
        ddlAcYearId.DataSource = obDemandfromOthers.Select();
        ddlAcYearId.DataTextField = "AcYear";
        ddlAcYearId.DataValueField = "AcYear";
        ddlAcYearId.DataBind();
        ddlAcYearId.Items.Insert(0, new ListItem("Select", "0"));
       // BindTenderNo();
    
    }


    public void FillData()
    {
        try
        {
            obPriReg = new PRI_PrinterRegistration();

            ddlPrinter.DataTextField = "NameofPress_V";
            ddlPrinter.DataValueField = "Printer_RedID_I";

            obPriReg.Printer_RedID_I = 0;
            ddlPrinter.DataSource = obPriReg.PrinterRegistrationLoad();
            ddlPrinter.DataBind();


            ddlPrinter.Items.Insert(0, new ListItem("All", "0"));

        }
        catch (Exception ex)
        {
        }
        finally
        {
            obPriReg = null;
        }
    }



    public void LoadGroup()
    {
        obGroupAllotment = new PRI003_RPTGroupAllotment();

        try
        {
            lblTitle.Text = "शेक्षणिक सत्र :" + ddlAcYearId.SelectedItem.Text + ", प्रिंटर का नाम :" + ddlPrinter.SelectedItem.Text+", दिनांक :"+System.DateTime.Now.ToString("MMM dd,yyyy");;
            obGroupAllotment.Printer_RedID_I = Convert.ToInt32(ddlPrinter.SelectedValue);
            obGroupAllotment.AcYearId = Convert.ToString(ddlAcYearId.SelectedValue);
            //GrdGroupDetails.DataSource = obGroupAllotment.LoadGroupAllotment();
            GrdGroupDetails.DataSource = GetLoadGroup(obGroupAllotment);
            GrdGroupDetails.DataBind();

            if (GrdGroupDetails.Rows.Count > 0)
            {
                btnExport.Visible = true;
                btnExportPDF.Visible = true;
              
            }
            else
            {
                btnExport.Visible = false;
                btnExportPDF.Visible = false ;
                
            }



        }

        catch (Exception ex)
        {
        }
        finally
        {
            obGroupAllotment = null;
        }
    }

    protected void ddlPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadGroup();
        BindTenderNo();

    }
     public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "PrinterTender.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - word";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }
    protected void btnExportPDF_Click(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadGroup();
    }
    public void BindTenderNo()
    {
        DataSet ds = new DataSet();
        CommonFuction obCommonFuction = new CommonFuction();
        DataSet dd = obCommonFuction.FillDatasetByProc("call Prin_loadTenderDetails(0,'" + ddlAcYearId.SelectedItem.Text + "')"); ;
        ddlTenderID_I.DataSource = dd.Tables[0];
        ddlTenderID_I.DataValueField = "TenderId_I";
        ddlTenderID_I.DataTextField = "TenderNo_V";
        ddlTenderID_I.DataBind();
        ddlTenderID_I.Items.Insert(0, new ListItem("All", "0"));
        //LoadGroup();
    }

    public DataSet GetLoadGroup(PRI003_RPTGroupAllotment ob)
    {
        int tenID = 0;
        if (ddlTenderID_I.SelectedIndex>0)
        tenID=Convert.ToInt32(ddlTenderID_I.SelectedValue);
        DataSet ds1 = new DataSet();
        CommonFuction obCommonFuction = new CommonFuction();
        ds1 = obCommonFuction.FillDatasetByProc("call USP_PRI003_RPTGroupAllotmentNew(" + ob.Printer_RedID_I + ",'" + ob.AcYearId + "'," + tenID + ")"); ;
       return ds1;
    }
}