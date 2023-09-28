using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.DistributionB;
using System.Data;
using System.Globalization;
using System.IO;

public partial class DistributionB_DIB_Reports_Rpt_DIB005_BillProcess : System.Web.UI.Page
{
    ProcessBill obProcessBill = null;
    CommonFuction obCommonFuction = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillCombo();
            }
            catch
            { }
            finally { obProcessBill = null; }
        }
    }
    private void FillCombo()
    {
        obProcessBill = new ProcessBill();
        obProcessBill.TransID = -1;
        ddlAcademicYear.DataSource = obProcessBill.Select();
        ddlAcademicYear.DataTextField = "AcYear";
        ddlAcademicYear.DataValueField = "Id";
        ddlAcademicYear.DataBind();
        ddlAcademicYear.Items.Insert(0, new ListItem("Select..", "0"));

        obProcessBill.TransID = -6;
        ddlDepartmentName.DataSource = obProcessBill.Select();
        ddlDepartmentName.DataTextField = "DepartmentName_V";
        ddlDepartmentName.DataValueField = "DepartmentID_I";
        ddlDepartmentName.DataBind();
        ddlDepartmentName.Items.Insert(0, new ListItem("Select..", "0"));

        obProcessBill.TransID = -3;
        ddlTitle.DataSource = obProcessBill.Select();
        ddlTitle.DataTextField = "TitleHindi_V";
        ddlTitle.DataValueField = "TitleID_I";
        ddlTitle.DataBind();
        ddlTitle.Items.Insert(0, new ListItem("Select..", "0"));

    }
    public void FillData()
    {
        if (txtFromDate.Text == "" || txtToDate.Text == "")
        {
            tdPrintContent.Visible = false;
            tdNoRecord.Visible = true;
            tdNoRecord.InnerText = "Please enter correct date";
        }
        else
        {
            try
            {
                obProcessBill = new ProcessBill();
                obProcessBill.TransID = 0;
                obProcessBill.FromDate = Convert.ToDateTime(txtFromDate.Text, cult).ToString("yyyy-MM-dd");
                obProcessBill.ToDate = Convert.ToDateTime(txtToDate.Text, cult).ToString("yyyy-MM-dd");
                obProcessBill.AcademicYr = Convert.ToInt32(ddlAcademicYear.SelectedValue);
                obProcessBill.DepartmentID = Convert.ToInt32(ddlDepartmentName.SelectedValue);
                obProcessBill.TitleID = Convert.ToInt32(ddlTitle.SelectedValue);
                DataTable dt = obProcessBill.SelectRPT().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    tdPrintContent.Visible = true;
                    tdNoRecord.Visible = false;
                    lblFromDate.Text = txtFromDate.Text;
                    lblToDate.Text = txtToDate.Text;
                    lblAcademicYear.Text = new CommonFuction().GetFinYear();
                    lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    GrdLetterInfo.DataSource = dt;
                    GrdLetterInfo.DataBind();
                }
                else
                {
                    tdPrintContent.Visible = false;
                    tdNoRecord.Visible = true;
                    tdNoRecord.InnerText = "No record found";
                }
            }
            catch
            {
                tdPrintContent.Visible = false;
                tdNoRecord.Visible = true;
                tdNoRecord.InnerText = "No record found";
            }
            finally
            {
                obProcessBill = null;
            }
        }
    }
    private void CalculateTotal()
    {
        //double TotalAmount = 0;
        //for (int rowno = 0; rowno < grdSelectedTitle.Rows.Count; rowno++)
        //{
        //    TotalAmount += double.Parse(grdSelectedTitle.Rows[rowno].Cells[7].Text);
        //}

        //lblTotalAmount.Text = TotalAmount.ToString("N");
    }

    protected void lnBtnViewPrinterProof_Click(object sender, EventArgs e)
    {
        //Messages.Style.Add("display", "block");
        //fadeDiv.Style.Add("display", "block");

        //try
        //{
        //    LinkButton lnkSender = (LinkButton)sender;
        //    GridViewRow gv = (GridViewRow)lnkSender.NamingContainer;
        //    Label lblProcessBillTrno_I = (Label)gv.FindControl("lblProcessBillTrno_I");

        //    obProcessBill = new ProcessBill();
        //    obProcessBill.TransID = -9;
        //    obProcessBill.QueryParameterValue = Convert.ToInt32(lblProcessBillTrno_I.Text);
        //    var data = obProcessBill.Select();
        //    grdSelectedTitle.DataSource = data;
        //    grdSelectedTitle.DataBind();
        //    CalculateTotal();
        //}
        //catch
        //{
        //}
        //finally
        //{
        //    obProcessBill = null;
        //}
    }

    protected void lnBtnBack_Click(object sender, EventArgs e)
    {
        //Messages.Style.Add("display", "none");
        //fadeDiv.Style.Add("display", "none");
    }

    protected void GrdViewPrinterProof_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLetterInfo.PageIndex = e.NewPageIndex;
        FillData();
    }
    //protected void btnExport_Click(object sender, EventArgs e)
    //{
    //    //FillGrid();
    //    if (GrdLetterInfo.Rows.Count > 0)
    //    {
    //        Class1 cls = new Class1();
    //        cls.Export("BillInformation.xls", GrdLetterInfo, "बिल की जानकारी");
    //    }
    //    else
    //    {
    //        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('इस जिले की कोई जानकारी उपलब्ध नहीं है..');</script>");
    //    }
    //}
    protected void GrdLetterInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowIndex >= 0)
            {
                Label lblProcessBillTrno_I = (Label)e.Row.FindControl("lblProcessBillTrno_I");

                obProcessBill = new ProcessBill();
                obProcessBill.TransID = -9;
                obProcessBill.QueryParameterValue = Convert.ToInt32(lblProcessBillTrno_I.Text);
                GridView grdSelectedTitle = (GridView)e.Row.FindControl("grdSelectedTitle");
                var data = obProcessBill.Select();
                grdSelectedTitle.DataSource = data;
                grdSelectedTitle.DataBind();
                //CalculateTotal();
            }
        }
        catch
        {
        }
        finally
        {
            obProcessBill = null;
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ////FillGrid();
        //Class1 cls = new Class1();
        //cls.Export("RSK_FreeBooksSupplyInformation.xls", GrdLetterInfo, "रा०शि०के से नि:शुल्क पुस्तकों की मांग की स्थिति");
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
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "BillInformation.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillData();
    }
   
}