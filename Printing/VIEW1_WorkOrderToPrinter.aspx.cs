using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;


public partial class Printing_VIEW_WorkOrderToPrinter : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    WorkOrderDetails obWorkOrderDetails = null;
    CommonFuction obCommonFuction = null;
    string ext;
    string FilePath;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obCommonFuction = new CommonFuction();
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();

            FillData();
            ViewState["WorkorderID_I"] = "";
        }
    }

    public void FillData()
    {
        try
        {
            PRI_PrinterRegistration PriReg = new PRI_PrinterRegistration();
            PriReg.UserID_I = Convert.ToInt32(Session["USerID"]);
            DataSet ds = new DataSet();
            ds = PriReg.GetPrinterDetails();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["PrierID_I"] = Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
                lblPrinter.Text = ds.Tables[0].Rows[0]["NameOfPress_V"].ToString();
            }
            //obWorkOrderDetails = new WorkOrderDetails();
            //obWorkOrderDetails.WorkorderID_I = 0;
            CommonFuction comm = new CommonFuction();
           DataSet dd= comm.FillDatasetByProc("call GetWorkOrdertoPrinter(" + Session["PrierID_I"].ToString() + ",'"+DdlACYear.SelectedItem.Text+"')");
           GrdWorkOrderDetails.DataSource = dd.Tables[0];
            GrdWorkOrderDetails.DataBind();

           
        }
        catch
        {
        }
        finally
        {
            obWorkOrderDetails = null;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            FillData();
        }
        catch { }
    }

    protected void lnBtnViewGroup_Click(object sender, EventArgs e)
    {
        MessagesGroup.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");

        try
        {
            LinkButton lnkSender = (LinkButton)sender;
            GridViewRow gv = (GridViewRow)lnkSender.NamingContainer;
            Label lblViewgroup = (Label)gv.FindControl("lblViewgroup");

            obWorkOrderDetails = new WorkOrderDetails();
            if (lblViewgroup.Text != "")
            {
                obWorkOrderDetails.WorkorderID_I = Convert.ToInt32(lblViewgroup.Text);
                GrdGroupDetails.DataSource = obWorkOrderDetails.ViewGroup();
                GrdGroupDetails.DataBind();
            }
            else
            {
                GrdGroupDetails.DataSource = string.Empty;
                GrdGroupDetails.DataBind();
            }
        }
        catch
        {
        }
        finally
        {
            obWorkOrderDetails = null;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        obWorkOrderDetails = new WorkOrderDetails();
        obWorkOrderDetails.WorkorderID_I = int.Parse(ViewState["WorkorderID_I"].ToString());
        obWorkOrderDetails.ArgDate_D = DateTime.Parse(txtAgreeMentDate.Text, cult);
        obWorkOrderDetails.ArgNo_V = txtAgreeMentNo.Text;
        obWorkOrderDetails.PrintSecurityAmount_N = Decimal.Parse(txtPrinterSecuAmt.Text);
        obWorkOrderDetails.PrintSecurityDetail_V = txtPrinterRemark.Text;
        obWorkOrderDetails.PaperSecurityAmount_N = Decimal.Parse(txtPaperSecAmt.Text);
        obWorkOrderDetails.PaperSecurityDetail_V = txtPaperRemark.Text;
        obWorkOrderDetails.JobCode_V = txtJobCardNo.Text;
        int i = obWorkOrderDetails.UpdateAgreement();
        if (i > 0)
        {
            ViewState["WorkorderID_I"] = "";
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
        }
        MessagesGroup.Style.Add("display", "none");
        MessagesAcceptance.Style.Add("display", "none");
        MessagesWorkOrder.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
        ViewState["WorkorderID_I"] = "";
        txtAgreeMentDate.Text = "";
        txtAgreeMentNo.Text = "";
        txtPrinterSecuAmt.Text = "";
        txtPrinterRemark.Text = "";
        txtPaperSecAmt.Text = "";
        txtPaperRemark.Text = "";
        FillData();
    }
    protected void lnBtnViewAcceptance_Click(object sender, EventArgs e)
    {
        MessagesAcceptance.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
        obWorkOrderDetails = new WorkOrderDetails();
        try
        {
            txtJobCardNo.Text = obWorkOrderDetails.JobCardNo().Tables[0].Rows[0][0].ToString();
        }
        catch { txtJobCardNo.Text = ""; }
        LinkButton lnkSender = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnkSender.NamingContainer;
        Label lblWorkorderID_I = (Label)gv.FindControl("lblViewAcceptance");
        ViewState["WorkorderID_I"] = lblWorkorderID_I.Text;
    }

    protected void lnBtnBack_Click(object sender, EventArgs e)
    {
        MessagesGroup.Style.Add("display", "none");
        MessagesAcceptance.Style.Add("display", "none");
        MessagesWorkOrder.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
        ViewState["WorkorderID_I"] = "";
    }
    protected void GrdWorkOrderDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obWorkOrderDetails = new WorkOrderDetails();
        string str = GrdWorkOrderDetails.DataKeys[e.RowIndex].Value.ToString();

        obWorkOrderDetails.Delete(Convert.ToInt32(str));
        FillData();
    }
    protected void GrdWorkOrderDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdWorkOrderDetails.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSaveNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("WorkOrderToPrinter.aspx");
    }
    protected void GrdWorkOrderDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        LinkButton lnkSender = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnkSender.NamingContainer;
        Label lblWorkorderID_I = (Label)gv.FindControl("lblViewAcceptance");
        obWorkOrderDetails = new WorkOrderDetails();
        obWorkOrderDetails.Delete(Convert.ToInt32(lblWorkorderID_I.Text));
        FillData();
    }

}