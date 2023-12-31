
using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;

public partial class DistributionB_BillProcessPaymentInfo : System.Web.UI.Page
{
    
    MPTBCBussinessLayer.DistributionB.ProcessBill obProcessBill = new MPTBCBussinessLayer.DistributionB.ProcessBill();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obProcessBill.TransID = -1;
            ddlAcYr.DataSource = obProcessBill.Select();
            ddlAcYr.DataTextField = "AcYear";
            ddlAcYr.DataValueField = "Id";
            ddlAcYr.DataBind();
            ddlAcYr.Items.Insert(0, new ListItem("All", "0"));
            FillCombo();
            FillLetterInfoGrid();
        }
    }
    private void FillCombo()
    {   
        obProcessBill.TransID = -6;
        ddlDepartmentName.DataSource = obProcessBill.Select();
        ddlDepartmentName.DataTextField = "DepartmentName_V";
        ddlDepartmentName.DataValueField = "DepartmentID_I";
        ddlDepartmentName.DataBind();
        ddlDepartmentName.Items.Insert(0, new ListItem("All", "0"));

        obProcessBill.TransID = -3;
        ddlTitle.DataSource = obProcessBill.Select();
        ddlTitle.DataTextField = "TitleHindi_V";
        ddlTitle.DataValueField = "TitleID_I";
        ddlTitle.DataBind();
        ddlTitle.Items.Insert(0, new ListItem("All", "0"));

    }
    private void FillLetterInfoGrid()
    {
        //obProcessBill.TransID = -7;
        //obProcessBill.QueryParameterValue = int.Parse(ddlAcYr.SelectedValue);

        //GrdLetterInfo.DataSource = obProcessBill.Select();
        //GrdLetterInfo.DataBind();
        GrdLetterInfo.DataSource = obCommonFuction.FillDatasetByProc("Call USP_DIB005_ProcessBillDetails('" + ddlAcYr.SelectedValue + "','" + ddlDepartmentName.SelectedItem.Text + "','" + ddlTitle.SelectedItem.Text + "','" + txtFromDate.Text + "','" + txtToDate.Text + "')");
        GrdLetterInfo.DataBind();

    }
    protected void btnNewFreeDistribution_Click(object sender, EventArgs e)
    {
        Response.Redirect("DIB_005_ProcessBill.aspx");
    }
    protected void GrdLetterInfo_OnRowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
      
    }
    protected void GrdLetterInfo_OnRowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        //obClassMaster = new ClassMaster();
        //obClassMaster.Delete(Convert.ToInt32(GrdClassMaster.DataKeys[e.RowIndex].Value.ToString()));
        //FillData();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    { 
        DateTime DteCheck;
        string RptDate = "", GrDate = "";
        if (txtFromDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtFromDate.Text, cult);
            }
            catch { RptDate = "NoDate"; }
        }
        if (txtToDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtToDate.Text, cult);
            }
            catch { GrDate = "NoDate"; }
        }


        if (RptDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct From Date.');</script>");
        }
        else if (GrDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct End Date.');</script>");
        }
        else
        {
            FillLetterInfoGrid();
        }
    }
}
