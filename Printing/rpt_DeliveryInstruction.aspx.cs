using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Printing_rpt_DeliveryInstruction : System.Web.UI.Page
{
    DIS_DemandEstimation ObjDemandEstimation = new DIS_DemandEstimation();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblAcademicYear.Text = "शिक्षा सत्र : " + DdlACYear.SelectedValue;
        if (!IsPostBack)
        {
            PRI_PrinterRegistration PriReg = new PRI_PrinterRegistration();
            PriReg.UserID_I = Convert.ToInt32(Session["USerID"]);
            DataSet ds = new DataSet();
            ds = PriReg.GetPrinterDetails();
            if (ds.Tables[0].Rows.Count > 0)
            {

                Session["PrierID_I"] = Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
                DDLPrinter.DataSource = ds;
                DDLPrinter.DataValueField = "Printer_RedID_I";
                DDLPrinter.DataTextField = "NameofPress_V";
                DDLPrinter.DataBind();
                DDLPrinter.Enabled = false;
                DDLPrinter.SelectedValue = Session["PrierID_I"].ToString();
            }

            lblDate.Text = System.DateTime.Now.ToString("MMM dd, yyyy");
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            //DdlACYear.SelectedValue = obCommonFuction.GetFinYearNew();
            DdlACYear.Enabled = true;

            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, new ListItem("All", "0"));

           // DDLPrinter.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DistributionorderonWorkorder('" + DdlACYear.SelectedValue.ToString() + "')");
           // DDLPrinter.DataValueField = "Printer_regid_i";
           // DDLPrinter.DataTextField = "NameofPress_V";
           // DDLPrinter.DataBind();
           //// DDLPrinter.Items.Insert(0, new ListItem("All", "0"));
           // DDLPrinter.Enabled = false;
           // DDLPrinter.SelectedValue = Session["PrierID_I"].ToString ();

            DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            DdlClass.DataValueField = "ClassTrno_I";
            DdlClass.DataTextField = "ClassDesc_V";
            DdlClass.DataBind();
            DdlClass.Items.Insert(0, new ListItem("All", "0"));

            DdlTitle.Items.Insert(0, new ListItem("All", "0"));
            ddlType.Items.Insert(0, new ListItem("All", "0"));

            DdlGroup.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS002_GroupCreationLoad(0)");
            DdlGroup.DataValueField = "GroupId";
            DdlGroup.DataTextField = "GroupName";
            DdlGroup.DataBind();
            DdlGroup.Items.Insert(0, new ListItem("All", "0"));
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {

            CommonFuction obCommonFuction = new CommonFuction();

            DataSet obDataset = obCommonFuction.FillDatasetByProc(@"Call DIS_RptVitranNirdesh_new('" + DdlACYear.SelectedValue.ToString() +
                                                                    "'," + Convert.ToInt16(DdlDepot.SelectedValue) +
                                                                    "," + Convert.ToInt16(DDLPrinter.SelectedValue) +
                                                                    "," + Convert.ToInt16(DdlClass.SelectedValue) +
                                                                    "," + Convert.ToInt16(DdlTitle.SelectedValue) +
                                                                    "," + Convert.ToInt16(ddlType.SelectedValue) + "," + DdlGroup.SelectedItem.Value.ToString().Replace("All", "0") + ",0)");
            if (obDataset.Tables[0].Rows.Count > 0)
            {
                GrdVitranNirdesh.DataSource = obDataset;
                GrdVitranNirdesh.DataBind();
                tdPrintContent.Visible = true;
            }
            else
            {
                GrdVitranNirdesh.DataSource = string.Empty;
                GrdVitranNirdesh.DataBind();

                tdPrintContent.Visible = false;
            }

        }
        catch { }
    }

    ////////  EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "DistributionOrder.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

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
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            PRI_PrinterRegistration PriReg = new PRI_PrinterRegistration();
            PriReg.UserID_I = Convert.ToInt32(Session["USerID"]);
            DataSet ds = new DataSet();
            ds = PriReg.GetPrinterDetails();
            if (ds.Tables[0].Rows.Count > 0)
            {

                Session["PrierID_I"] = Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
            }

            DDLPrinter.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DistributionorderonWorkorder('" + DdlACYear.SelectedValue.ToString() + "')");
            DDLPrinter.DataValueField = "Printer_regid_i";
            DDLPrinter.DataTextField = "NameofPress_V";
            DDLPrinter.DataBind();
            DDLPrinter.SelectedValue = Session["PrierID_I"].ToString();
            DDLPrinter.Enabled = false;
            // DDLPrinter.Items.Insert(0, new ListItem("All", "0"));
        
        
    }
    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {

        CommonFuction obCommonFuction = new CommonFuction();


        DdlTitle.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_TitleLoadClassWise(" + Convert.ToInt32(DdlClass.SelectedValue) + ")");
        DdlTitle.DataValueField = "TitleID_I";
        DdlTitle.DataTextField = "TitleHindi_V";
        DdlTitle.DataBind();
        //DdlTitle.Items.Insert(0, "--Select--");
        DdlTitle.Items.Insert(0, new ListItem("All", "0"));


    }
    protected void Print_Click(object sender, EventArgs e)
    {

        this.GrdVitranNirdesh.Columns[0].Visible = false;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "PrintPanel()", true);
        this.GrdVitranNirdesh.Columns[0].Visible = true;
    }

}