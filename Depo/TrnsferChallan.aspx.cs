using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;

using System.IO;
public partial class Depo_TrnsferChallan : System.Web.UI.Page
{
    PRIN_ChallanDetails obPrinChallan = null;
    public double totalBook, TotalNo;
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

           
            DdlACYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            //  DdlACYear_SelectedIndexChanged(sender, e);
            //sLoadGrid();

            //DataSet Title = comm.FillDatasetByProc("call GetChallanbyStock(" + Session["PrierID_I"] + ")");

            DropDownList1.DataSource = comm.FillDatasetByProc("call USP_DD_SelectMainBookDepot1()");
            DropDownList1.DataTextField = "DepoName_V";
            DropDownList1.DataValueField = "DepoTrno_I";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select..", "0"));


            DataSet ds = comm.FillDatasetByProc("call GetRegPrinterwithWorkOrderN(0,'" + DdlACYear.SelectedValue + "')");
            ddlPrinter.DataSource = ds.Tables[0];
            ddlPrinter.DataTextField = "NameofPress_V";
            ddlPrinter.DataValueField = "Printer_RedID_I";
            //ddlPrinterName.DataValueField = "NameofPress_V";
            ddlPrinter.DataBind();
            ddlPrinter.Items.Insert(0, "सलेक्ट करे");
            //
        }
    }

    public void LoadGrid()
    {
        try {
        
                Session["PrierID_I"] = ddlPrinter.SelectedValue;
              
            //GrdChallan.DataSource = obPrinChallan.PrinLoadChallanDetails();
            CommonFuction comm = new CommonFuction();
            DataTable Dt = comm.FillTableByProc("Call USP_PRIN0011_ChallanDetailsLoad_Rpt022(" + obPrinChallan.PriTransID + ",'" + obPrinChallan.Depo_I + "','" + DdlACYear.SelectedItem.Text + "')");
            GrdChallan.DataSource = Dt;
            GrdChallan.DataBind();
        }

        catch (Exception ex) { }
        finally {  }


    }

    protected void GrdChallan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
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
    protected void GrdChallan_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button11(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        //USP_UpdateChallanDepoName
        comm.FillDatasetByProc("call USP_UpdateChallanDepoName (" + DropDownList1.SelectedValue + ","+HiddenField2.Value+") ");
        HiddenField2.Value = "";
        btnAdd0_Click(sender, e);
        fadeDiv.Style.Add("display", "none");
        Messages.Style.Add("display", "none");
    }
    protected void Button22(object sender, EventArgs e)
    {
        fadeDiv.Style.Add("display", "none");
        Messages.Style.Add("display", "none");
    }
    protected void btnClick(object sender, EventArgs e)
    {
        LinkButton btns = (LinkButton)sender;

        GridViewRow grd = (GridViewRow)(btns.NamingContainer);

       HiddenField2.Value = ((HiddenField)grd.FindControl("HiddenField1")).Value;
       fadeDiv.Style.Add("display", "block");
       Messages.Style.Add("display", "block");
        //href='=<%#new APIProcedure().Encrypt( Eval("PriTransID").ToString()) %>'
    }
    protected void btnAdd0_Click(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        GrdChallan.DataSource = comm.FillDatasetByProc("call GetChallFilterbyDepot(" + ddlPrinter.SelectedValue  + "," + ddlDepot.SelectedValue + "," + ddlTital.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "')");
        GrdChallan.DataBind();
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = comm.FillDatasetByProc("call GetRegPrinterwithWorkOrderN(0,'" + DdlACYear.SelectedValue + "')");
        ddlPrinter.DataSource = ds.Tables[0];
        ddlPrinter.DataTextField = "NameofPress_V";
        ddlPrinter.DataValueField = "Printer_RedID_I";
        //ddlPrinterName.DataValueField = "NameofPress_V";
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, "सलेक्ट करे");
        //CommonFuction comm = new CommonFuction();
        //DataSet Title = comm.FillDatasetByProc("call GetChallanbyStocknew(" + Session["PrierID_I"] + ",'" + DdlACYear.SelectedItem.Text + "')");
        //ddlTital.DataSource = Title.Tables[1];
        //ddlTital.DataTextField = "TitleHindi_V";
        //ddlTital.DataValueField = "TitleID_I";
        //ddlTital.DataBind();
        //ddlTital.Items.Insert(0, new ListItem("Select..", "0"));
    }
    protected void ddlPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        DataSet Title = comm.FillDatasetByProc("call GetChallanbyStocknew(" + ddlPrinter.SelectedValue+ ",'" + DdlACYear.SelectedItem.Text + "')");
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
    }

    protected void GrdChallan_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        GrdChallan.PageIndex = e.NewPageIndex;
        Session["PrierID_I"] = ddlPrinter.SelectedValue;

        //GrdChallan.DataSource = obPrinChallan.PrinLoadChallanDetails();
        CommonFuction comm = new CommonFuction();
        GrdChallan.DataSource = comm.FillDatasetByProc("call GetChallFilterbyDepot(" + ddlPrinter.SelectedValue + "," + ddlDepot.SelectedValue + "," + ddlTital.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "')");
        GrdChallan.DataBind();
    }
}