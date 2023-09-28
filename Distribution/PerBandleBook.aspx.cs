using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class Distribution_PerBandleBook : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFuction comm = new CommonFuction();

            ddlMedium.DataSource = comm.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("Select..", "0"));

            DdlACYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = comm.GetFinYear();

            //DataSet asdf = comm.FillDatasetByProc("call USP_DPTOPeningStock(0,1,0,0,0,0)");
            //ddlTital.DataSource = asdf.Tables[0];
            //ddlTital.DataTextField = "TitleHindi_V";
            //ddlTital.DataValueField = "TitleID_I";
            //ddlTital.DataBind();
            //ddlTital.Items.Insert(0, new ListItem("Select..", "0"));
            fillgrd();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //
        comm.FillDatasetByProc("call gettbl_bookPerBundle (0,"+ddlTital.SelectedValue+","+txtHeadname.Text+",'"+DdlACYear.SelectedValue+"')");
        comm.EmptyTextBoxes(this);
        fillgrd();

    }
    protected void ddlTital_SelectedIndexChanged(object sender, EventArgs e)
    {
        try {
            DataSet dd = comm.FillDatasetByProc(" call gettbl_bookPerBundle ("+ddlTital.SelectedValue+",0,0,'"+DdlACYear.SelectedValue+"')");
      txtHeadname.Text = dd.Tables[0].Rows[0]["BookNumber"].ToString();
        }
        catch { }
    }
    public void fillgrd()
    {
      DataSet ddd=  comm.FillDatasetByProc("call getperbandelDetails(0,'"+DdlACYear.SelectedValue+"')");
      GridView1.DataSource = ddd.Tables[0];
      GridView1.DataBind();
    }

    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Classes="1,2,3,4,5,6,7,8,9,10,11,12";

        DataSet asdf = comm.FillDatasetByProc("call GetMediumbyTitileNew(" + ddlMedium.SelectedValue + ",'" + Classes + "')");
        ddlTital.DataSource = asdf.Tables[0];
        ddlTital.DataTextField = "TitleHindi_V";
        ddlTital.DataValueField = "TitleID_I";
        ddlTital.DataBind();
        ddlTital.Items.Insert(0, new ListItem("Select...", "0"));
        DataSet ddd = comm.FillDatasetByProc("call getperbandelDetails("+ddlMedium.SelectedValue+",'"+DdlACYear.SelectedValue+"')");
        GridView1.DataSource = ddd.Tables[0];
        GridView1.DataBind();
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ddd = comm.FillDatasetByProc("call getperbandelDetails(" + ddlMedium.SelectedValue + ",'" + DdlACYear.SelectedValue + "')");
        GridView1.DataSource = ddd.Tables[0];
        GridView1.DataBind();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet asdf = comm.FillDatasetByProc("call GetMediumbyTitileNew(" + ddlMedium.SelectedValue + ",'" + DropDownList1.SelectedValue + "')");
        ddlTital.DataSource = asdf.Tables[0];
        ddlTital.DataTextField = "TitleHindi_V";
        ddlTital.DataValueField = "TitleID_I";
        ddlTital.DataBind();
        ddlTital.Items.Insert(0, new ListItem("Select...", "0"));
        DataSet ddd = comm.FillDatasetByProc("call getperbandelDetailsM(" + ddlMedium.SelectedValue + ",'" + DdlACYear.SelectedValue + "','"+DropDownList1.SelectedValue+"')");
        GridView1.DataSource = ddd.Tables[0];
        GridView1.DataBind();
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
}