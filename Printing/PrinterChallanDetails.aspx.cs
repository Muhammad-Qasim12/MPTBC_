using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;

using System.IO;
public partial class Printing_PrinterChallanDetails : System.Web.UI.Page
{

    PRIN_ChallanDetails obPrinChallan = null;
    public double totalBook, TotalNo;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CommonFuction comm = new CommonFuction();
            DdlACYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            //  DdlACYear_SelectedIndexChanged(sender, e);
            LoadGrid();

            //DataSet Title = comm.FillDatasetByProc("call GetChallanbyStock(" + Session["PrierID_I"] + ")");
            DataSet Title = comm.FillDatasetByProc("call GetChallanbyStocknew('" + Session["PrierID_I"] + "','" + DdlACYear.SelectedItem.Text + "')");
            ddlTital.DataSource = Title.Tables[1];
            ddlTital.DataTextField = "TitleHindi_V";
            ddlTital.DataValueField = "TitleID_I";
            ddlTital.DataBind();
            ddlTital.Items.Insert(0, new ListItem("Select..", "0"));

            ddlDepot.DataSource = Title.Tables[0];
            ddlDepot.DataTextField = "DepoName_V";
            ddlDepot.DataValueField = "DepoID_I";
            ddlDepot.DataBind();
            ddlDepot.Items.Insert(0, new ListItem("Select..", "0"));
            //
        }
    }


    public void LoadGrid()
    {
        obPrinChallan = new PRIN_ChallanDetails();
        PRI_PrinterRegistration PriReg = new PRI_PrinterRegistration();
        PriReg.UserID_I = Convert.ToInt32(Session["USerID"]);
        DataSet ds = new DataSet();
        ds = PriReg.GetPrinterDetails();
        try
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["PrierID_I"] = Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
                obPrinChallan.PriTransID = 0;
                obPrinChallan.Depo_I = Convert.ToInt32(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
                // printer id using depo variable
            }
            else
            {
                obPrinChallan.Depo_I = Convert.ToInt32(Session["USerID"]); ;
                obPrinChallan.PriTransID = 0;
            }

            //GrdChallan.DataSource = obPrinChallan.PrinLoadChallanDetails();
            CommonFuction comm = new CommonFuction();
            DataTable Dt = comm.FillTableByProc("Call USP_PRIN0011_ChallanDetailsLoad_Rpt022(" + obPrinChallan.PriTransID + ",'" + obPrinChallan.Depo_I + "','" + DdlACYear.SelectedItem.Text + "')");
            GrdChallan.DataSource = Dt;
            GrdChallan.DataBind();
        }

        catch (Exception ex) { }
        finally { obPrinChallan = null; }


    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateChallan.aspx");
    }

    protected void GrdChallan_SelectedIndexChanged(object sender, EventArgs e)
    {

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

        LoadGrid();
        Class1 cls = new Class1();
        cls.Export("Challan.xls", GrdChallan, "चालान की जानकारी");
        //Response.ClearContent();
        //Response.Buffer = true;
        //Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Challan.xls"));
        //Response.Charset = "";
        //Response.ContentType = "application / vnd.ms - word";

        //StringWriter sw = new StringWriter();
        //HtmlTextWriter HW = new HtmlTextWriter(sw);

        //ExportDiv.RenderControl(HW);
        //Response.Write(sw.ToString());
        //Response.End();
        //Response.Clear();
    }
    protected void GrdChallan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdChallan.PageIndex = e.NewPageIndex;
        LoadGrid();
    }
    protected void GrdChallan_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            try
            {
                Label lblPerBundle = (Label)e.Row.FindControl("Label1");
                totalBook += lblPerBundle.Text.Trim().Length == 0 ? 0 : Convert.ToDouble(lblPerBundle.Text);
            }
            catch { }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            TotalNo = GrdChallan.Rows.Count;
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[1].Text = TotalNo.ToString();
            e.Row.Cells[5].Text = totalBook.ToString();
        }

    }
    protected void btnAdd0_Click(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        GrdChallan.DataSource = comm.FillDatasetByProc("call GetChallFilterbyDepot(" + Session["PrierID_I"] + "," + ddlDepot.SelectedValue + "," + ddlTital.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "')");
        GrdChallan.DataBind();
    }
    protected void btnClick(object sender, EventArgs e)
    {
        LinkButton btns = (LinkButton)sender;

        GridViewRow grd = (GridViewRow)(btns.NamingContainer);

        HiddenField hd = (HiddenField)grd.FindControl("HiddenField1");
        Response.Redirect("CreateChallan.aspx?Cid=" + new APIProcedure().Encrypt(hd.Value) + "");
        //href='=<%#new APIProcedure().Encrypt( Eval("PriTransID").ToString()) %>'
    }

    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        DataSet Title = comm.FillDatasetByProc("call GetChallanbyStocknew(" + Session["PrierID_I"] + ",'" + DdlACYear.SelectedItem.Text + "')");
        ddlTital.DataSource = Title.Tables[1];
        ddlTital.DataTextField = "TitleHindi_V";
        ddlTital.DataValueField = "TitleID_I";
        ddlTital.DataBind();
        ddlTital.Items.Insert(0, new ListItem("Select..", "0"));
    }
}