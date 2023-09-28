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


public partial class Printing_ReWorkorderToPrinterList : System.Web.UI.Page
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
            FillData();
            ViewState["WorkorderID_I"] = "";
        }
    }

    public void FillData()
    {
        try
        {
            obWorkOrderDetails = new WorkOrderDetails();
            obWorkOrderDetails.WorkorderID_I = 0;
            GrdWorkOrderDetails.DataSource = obWorkOrderDetails.SelectReorder();
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

    public void SearchData()
    {
        try
        {
            obWorkOrderDetails = new WorkOrderDetails();
            obWorkOrderDetails.WorkorderID_I = 0;
            //name of printer
            obWorkOrderDetails.JobCode_V = Convert.ToString(txtSearch.Text);
            GrdWorkOrderDetails.DataSource = obWorkOrderDetails.SelectSearch();
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

    protected void lnBtnViewGroup_Click(object sender, EventArgs e)
    {
        MessagesGroup.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");

        try
        {
            LinkButton lnkSender = (LinkButton)sender;
            GridViewRow gv = (GridViewRow)lnkSender.NamingContainer;
            Label lblViewgroup = (Label)gv.FindControl("lblViewgroup");
            System.Data.DataTable dtt = new System.Data.DataTable();

            obWorkOrderDetails = new WorkOrderDetails();
            if (lblViewgroup.Text != "")
            {
                //obWorkOrderDetails.WorkorderID_I = Convert.ToInt32(lblViewgroup.Text);
               // GrdGroupDetails.DataSource = obWorkOrderDetails.ViewGroup();
                //GrdGroupDetails.DataBind();

                obCommonFuction = new CommonFuction();
                dtt = obCommonFuction.FillTableByProc("CALL USP_PRI011_WorkOrderGroupDetail_New(" + Convert.ToInt32(lblViewgroup.Text) + ")");
                GrdGroupDetails.DataSource = dtt;
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
        obWorkOrderDetails.ArgLastDate_D = DateTime.Parse(txtLastDate.Text);
        obWorkOrderDetails.AskingPrinterSecurityAmount_N = Decimal.Parse(txtPrinterSecurityAmount.Text);
        obWorkOrderDetails.AskingPaperSecurityAmount_N = Decimal.Parse(txtPaperSecurityAmount.Text);


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

        try
        {
            DataSet ds = new DataSet();
            int wid = int.Parse(ViewState["WorkorderID_I"].ToString());
            obWorkOrderDetails.WorkorderID_I = wid;
            ds = obWorkOrderDetails.SelectReorder();
            txtPaperSecurityAmount.Text = ds.Tables[0].Rows[0]["DmndPaperSecAmt"].ToString();
            txtPrinterSecurityAmount.Text = ds.Tables[0].Rows[0]["DmndPrintingSecAmt"].ToString();
            txtLastDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DepositEndDt"]).ToString("dd/MM/yyyy");
        }
        catch { }
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
        SearchData();
    }
    protected void GrdWorkOrderDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdWorkOrderDetails.PageIndex = e.NewPageIndex;
        SearchData();
    }
    protected void btnSaveNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReWorkOrderToPrinter.aspx");
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
        SearchData();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SearchData(); 
    }
    protected void GrdWorkOrderDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}