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
using MPTBCBussinessLayer;

public partial class Printing_ProjectManagment : System.Web.UI.Page
{
    int DataCheck = 0;
    ClassMaster obClass = null;
    PRI_ProjectManagement objProjectManagement = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obClass = new ClassMaster();
            DataSet dtclass = obClass.Select();
            obClass.ClassTrno_I = 0;

            ddlClass.DataTextField = "Classdet_V";
            ddlClass.DataValueField = "ClassTrno_I";
            ddlClass.DataSource = dtclass;
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, "सलेक्ट करे"); 
           
        }

    }
    protected void ddlJobNo_Init(object sender, EventArgs e)
    {
        try
        {
           
        }
        catch { }
    }
    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlJobNo.SelectedItem.Text != "Select")
            {
                objProjectManagement = new PRI_ProjectManagement();
                objProjectManagement.JobCode_V = ddlJobNo.SelectedItem.Value.ToString();
                GrdProjectMaster.DataSource = objProjectManagement.ProjectManagementFill();
                GrdProjectMaster.DataBind();
            }
            else
            {
                GrdProjectMaster.DataSource = string.Empty;
                GrdProjectMaster.DataBind();
            }
        }
        catch { }
    }
    protected void GrdProjectMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblSchuDate_D = (Label)e.Row.FindControl("lblSchuDate_D");
                Label lblCurtDate = (Label)e.Row.FindControl("lblCurtDate");
                Label lblUniqueDate = (Label)e.Row.FindControl("lblUniqueDate");
                DateTime CrDt = new DateTime();
                DateTime ShudDt = new DateTime();
                if (lblCurtDate.Text == "")
                {

                }
                else
                {
                    try
                    {
                        CrDt = DateTime.Parse(lblUniqueDate.Text);
                    }
                    catch { }
                }
                // CrDt = DateTime.Parse(lblCurtDate.Text);
                if (lblSchuDate_D.Text == "")
                {

                }
                else
                {
                    ShudDt = DateTime.Parse(lblSchuDate_D.Text);
                }
                // ShudDt = DateTime.Parse(lblSchuDate_D.Text);
                if (CrDt > ShudDt && DataCheck != 0)
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
                DataCheck = DataCheck + 1;

                lblSchuDate_D.Text = ShudDt.ToString("dd/MM/yyyy");
                //if (lblUniqueDate.Text == "")
                //{
                //    ShudDt =   ;
                //}
                //else
                //{
                //    ShudDt = DateTime.Parse(lblUniqueDate.Text);
                //}


                //if (ShudDt.ToString() == "")
                //{

                //}
                //else
                //{
                //    lblUniqueDate.Text = ShudDt.ToString("dd/MM/yyyy");
                //}
                //if (lblUniqueDate.Text == "01-01-0001")
                //{
                //    lblUniqueDate.Text = "";
                //}


                //ShudDt = DateTime.Parse(lblUniqueDate.Text);
                // lblUniqueDate.Text = ShudDt.ToString("dd/MM/yyyy");
            }
        }
        catch { }

    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CommonFuction comm = new CommonFuction();
            DataSet asdf = comm.FillDatasetByProc("call GetTitleDetailsbyClass('" + ddlClass.SelectedValue + "')");
            ddlTitle.DataSource = asdf.Tables[0];
            ddlTitle.DataTextField = "TitleHindi_V";
            ddlTitle.DataValueField = "TitleID_I";
            ddlTitle.DataBind();
            ddlTitle.Items.Insert(0, new ListItem("Select..", "0"));
        }
        catch { }
    }
    protected void ddlPrinterName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CommonFuction comm = new CommonFuction();

            ddlJobNo.DataSource = comm.FillDatasetByProc("call USP_PRI002_ProjectManagementDetails(" + ddlPrinterName.SelectedValue + ",0)");
            ddlJobNo.DataTextField = "JobCode_V";
            ddlJobNo.DataValueField = "WorkorderID_I";
            ddlJobNo.DataBind();
            ddlJobNo.Items.Insert(0, "Select");
        }
        catch { }
    }
    protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        try { 
        CommonFuction comm = new CommonFuction();
        DataSet ds = comm.FillDatasetByProc("call GetRegPrinterwithWorkOrder(" + ddlTitle.SelectedValue + ")");
        ddlPrinterName.DataSource = ds.Tables[0];
        ddlPrinterName.DataTextField = "NameofPress_V";
        ddlPrinterName.DataValueField = "Printer_RedID_I";
        //ddlPrinterName.DataValueField = "NameofPress_V";
        ddlPrinterName.DataBind();
        ddlPrinterName.Items.Insert(0, "सलेक्ट करे"); 
            }
        catch { }
    }
}
