using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Globalization;
using MPTBCBussinessLayer.DistributionB;

public partial class Depo_OtherthanInterdepo : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    RDLC_Data objReports = new RDLC_Data();
    CommonFuction obCommonFuction = new CommonFuction();
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlFyYr.DataSource = objReports.FillFyYear().Tables[0];
            ddlFyYr.DataTextField = "AcYear";
            ddlFyYr.DataValueField = "AcYear";
            ddlFyYr.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
            ddlFyYr.DataBind();
            ddlLetterNo.DataSource = obCommonFuction.FillDatasetByProc("call USP_ACB002_SubTitleMasterSelect(0,-1)");
            ddlLetterNo.DataValueField = "TitleID_I";
            ddlLetterNo.DataTextField = "TitleHindi_V";
            ddlLetterNo.DataBind();
            ddlLetterNo.Items.Insert(0, new ListItem("-Select-", "0"));
        }

    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        string TitleID, SubTitle;
        if (ddlLetterNo.SelectedIndex == 0)
        {
            TitleID = "0";
        }
        else
        {
            TitleID = ddlLetterNo.SelectedValue;
        }
        if (ddlSub.SelectedIndex == 0)
        {
            SubTitle = "0";
        }
        else
        {
            SubTitle = ddlSub.SelectedValue;
        }
        GridView1.DataSource = obCommonFuction.FillDatasetByProc(@"Call USP_interDepoRep1('" + TitleID + "','" + SubTitle + "','" + ddlFyYr.SelectedItem.Text + "',"+Session["UserID"]+") ");
        GridView1.DataBind();

    }
    protected void ddlLetterNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSub.DataSource = obCommonFuction.FillDatasetByProc("call USP_ACB002_SubTitleMasterSelect(" + ddlLetterNo.SelectedValue + ",-2)");
        ddlSub.DataValueField = "SubTitleID_I";
        ddlSub.DataTextField = "SubTitleHindi_V";
        ddlSub.DataBind();
        ddlSub.Items.Insert(0, new ListItem("-Select-", "0"));
    }
}