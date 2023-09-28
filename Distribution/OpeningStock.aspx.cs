using System;
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using MPTBCBussinessLayer.Paper;
using System.IO;

public partial class Depo_OpeningStock : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    int TotalSamany, TotalScheme; string Classes;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DDlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DDlDepot.DataValueField = "DepoTrno_I";
            DDlDepot.DataTextField = "DepoName_V";
            DDlDepot.DataBind();
            DDlDepot.Items.Insert(0, new ListItem("--Select--", "0"));
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            ddlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("Select...", "0"));
        }

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "1")
        {
            Classes = "1,2,3,4,5,6,7,8";
        }
        else if (DropDownList1.SelectedValue == "2")
        {
            Classes = "9,10,11,12";
        }
        GridView2.DataSource = obCommonFuction.FillDatasetByProc("call USP_DPTSaveOpeningStock(1,'" + DdlACYear.SelectedItem.Text + "',0," + DDlDepot.SelectedValue + ",0,0,'" + Classes + "'," + ddlMedium.SelectedValue + ")");

        GridView2.DataBind();
        GridView1.Visible = false;
        GridView2.Visible = true;
        ExportToExcell();
        GridView1.Visible = true;
        GridView2.Visible = false;
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "1")
        {
            Classes = "1,2,3,4,5,6,7,8";
        }
        else if (DropDownList1.SelectedValue == "2")
        {
            Classes = "9,10,11,12";
        }
        obCommonFuction.FillDatasetByProc("call USP_DPTSaveOpeningStock(-1,'" + DdlACYear.SelectedItem.Text + "',0," + DDlDepot.SelectedValue + ",0,0,'" + Classes + "'," + ddlMedium.SelectedValue + ")");
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            obCommonFuction.FillDatasetByProc("call USP_DPTSaveOpeningStock(0,'" + DdlACYear.SelectedItem.Text + "'," + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value + "," + DDlDepot.SelectedValue + "," + ((TextBox)GridView1.Rows[i].FindControl("txtYojna")).Text + "," + ((TextBox)GridView1.Rows[i].FindControl("txtSamany")).Text + ",0," + ddlMedium.SelectedValue + ")");
        }
        //GridView1.DataSource = null;
        //GridView1.DataBind();
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (DropDownList1.SelectedValue == "1")
        {
            Classes = "1,2,3,4,5,6,7,8";
        }
        else if (DropDownList1.SelectedValue == "2")
        {
            Classes = "9,10,11,12";
        }
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_DPTSaveOpeningStock(1,'" + DdlACYear.SelectedItem.Text + "',0," + DDlDepot.SelectedValue + ",0,0,'" + Classes + "'," + ddlMedium.SelectedValue + ")");

        GridView1.DataBind();
        aa.Visible = true;
        //  IDa int, fyYeara varchar(20), TitleIDa int, DepoIDa int, YojanaBooka int, samanyBooka int, statusa int,MediumIDa int 
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        obCommonFuction.FillDatasetByProc("call USP_DPTSaveOpeningStock(-2,'" + DdlACYear.SelectedItem.Text + "',0," + DDlDepot.SelectedValue + ",0,0,0," + ddlMedium.SelectedValue + ")");
        GridView1.DataSource = null;
        GridView1.DataBind();
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                try
                {

                    TextBox txtSamany = (TextBox)e.Row.FindControl("txtSamany");
                    TotalSamany += txtSamany.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(txtSamany.Text);
                }
                catch { }
                try
                {
                    TextBox lblPerBundle = (TextBox)e.Row.FindControl("txtYojna");
                    TotalScheme += lblPerBundle.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lblPerBundle.Text);
                }
                catch { }


            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label FToNo_I0 = (Label)e.Row.FindControl("FToNo_I0");
            Label lblFLoojBook = (Label)e.Row.FindControl("lblFLoojBook");
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[2].Text = TotalScheme.ToString();
            e.Row.Cells[3].Text = TotalSamany.ToString();

        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        ddlMedium.SelectedIndex = 0;
    }
}