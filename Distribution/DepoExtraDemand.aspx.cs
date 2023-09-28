using System;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.IO;
using System.Web.UI;

public partial class Distribution_DepoExtraDemand : System.Web.UI.Page
{
    DIS_DemandEstimation ObjDemandEstimation = new DIS_DemandEstimation();

    CommonFuction objExec = new CommonFuction();
    int TotalNo; string strclasses = ""; string Bookstatus;
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();
        if (!IsPostBack)
        {

            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS001_DemandTypeMasterLoad(0)");
            DDlDemandType.DataValueField = "DemandTypeId";
            DDlDemandType.DataTextField = "DemandTypeHindi";
            DDlDemandType.DataBind();
            DDlDemandType.Items.Insert(0, "--Select--");

            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, "--Select--");

            //DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            //DdlClass.DataValueField = "ClassTrno_I";
            //DdlClass.DataTextField = "ClassDesc_V";
            //DdlClass.DataBind();
            //DdlClass.Items.Insert(0, new ListItem("-Select-", "-1"));
            //DdlClass.Items.Insert(1, new ListItem("-All-", "0"));

            DdlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)");
            DdlMedium.DataValueField = "MediumTrno_I";
            DdlMedium.DataTextField = "MediunNameHindi_V";
            DdlMedium.DataBind();
            DdlMedium.Items.Insert(0, "--Select--");

         


        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "BundelReelDetails.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }
    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm=new CommonFuction ();
        GridView1.DataSource = comm.FillDatasetByProc("call USP_ExtraDemand('"+DdlACYear.SelectedValue+"',"+DdlDepot.SelectedValue+","+DdlMedium.SelectedValue+","+DDlDemandType.SelectedValue+")");
        GridView1.DataBind();
    }
}