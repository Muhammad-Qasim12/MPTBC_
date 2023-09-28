using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using MPTBCBussinessLayer;

public partial class ReportDefReelCD : System.Web.UI.Page
{
    PPR_WorkPlan objWorkPlan = null;
    CommonFuction obCommonFuction = new CommonFuction();
    protected string acdyr = ""; protected string dte = ""; protected string vendorDetail = ""; protected string dte11 = "";
    protected string totDefReel = "0"; protected string totTonDefReel = "0.0"; protected string sSetAcYr = "";
    double dTotReel = 0, dTotGrossWt = 0, dTotDefReel=0, dTotDefWt=0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            acdyr = DdlACYear.SelectedItem.Text;
            dte = System.DateTime.Now.ToString("dd/MM/yyyy");
            dte11=System.DateTime.Now.ToString("dd.MM.yyyy");
            lblTotTonMetric.Text = "0.00";
            lblTotDefReel11.Text = "0";
            lblSetAcYr.Text = acdyr.Substring(0, 4);
            sSetAcYr = lblSetAcYr.Text;
            lblVenderName.Text = ddlVendor.SelectedItem.Text != "Select" ? ddlVendor.SelectedItem.Text : "";
        }
    }

    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet dsr = new DataSet();
            DataTable ds = obCommonFuction.FillTableByProc("call USP_PPR0022_RptDefReelCPD('0','" + ddlVendor.SelectedValue + "','" + DdlACYear.SelectedItem.Text + "',24,'',0)");
            ddlGSM.DataSource = ds;
            ddlGSM.DataTextField = "CoverInformation";
            ddlGSM.DataValueField = "PaperTrId_I";
            ddlGSM.DataBind();
        }
        catch { }
    }

    private void ClearCtrls()
    {
        GridView1.DataSource = null;
    }
   

    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select dbo.GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
            // ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
    }


    public void venderFill()
    {

        objWorkPlan = new PPR_WorkPlan();
        ddlVendor.DataSource = objWorkPlan.VenderFill();
        ddlVendor.DataTextField = "PaperVendorName_V";
        ddlVendor.DataValueField = "PaperVendorTrId_I";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, "Select");


    }

    protected void ddlVendor_Init(object sender, EventArgs e)
    {
        venderFill();
    }

   

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlVendor.SelectedItem.Text == "Select")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Select Paper Mill');</script>");
            }
            else if (txtFromDate.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter date');</script>");
            }
            else if (ddlGSM.SelectedValue == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select Paper Type');</script>");
            }
            else
            {
                dte = Convert.ToDateTime(txtFromDate.Text).ToString("dd/MM/yyyy");
                dte11 = Convert.ToDateTime(txtFromDate.Text).ToString("dd.MM.yyyy");

                string Edt = Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd");
                string strPaperTrId_I = ddlGSM.SelectedValue != "" ? ddlGSM.SelectedValue : "0";
                //string strPaperTrId_I = "0";
                DataSet dsr = new DataSet();
                dsr = obCommonFuction.FillDatasetByProc("call USP_PPR0022_RptDefReelCPD('0','" + ddlVendor.SelectedValue + "','" + DdlACYear.SelectedItem.Text + "',23,'" + Edt + "','"+strPaperTrId_I+"')");
                DataTable Dt = dsr.Tables[0];
                if (Dt.Rows.Count > 0)
                {
                    
                    tdPrintContent.Visible = true;
                    GridView1.DataSource = Dt;
                    GridView1.DataBind();
                    lblVenderName.Text = ddlVendor.SelectedItem.Text;
                    lblVenderAddress.Text = Dt.Rows[0]["PaperVendorAddress_V"].ToString();
                    tdNoRecord.Visible = false;
                }
                else
                {
                    tdPrintContent.Visible = false;
                    tdNoRecord.Visible = true;
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
        }
        catch { }
    }

    string previousCov = ""; int firstRow = -1;
    protected void GvReelDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblNoOfReels = (Label)e.Row.FindControl("lblNoOfReels");
            Label lblRecQty = (Label)e.Row.FindControl("lblRecQty");
            Label lblDefReel = (Label)e.Row.FindControl("lblDefReel");
            Label lblDefWt = (Label)e.Row.FindControl("lblDefWt");
            try
            {
                dTotReel = dTotReel + double.Parse(lblNoOfReels.Text);               
            }
            catch { dTotReel = 0; dTotGrossWt = 0; }

            try
            { dTotGrossWt = dTotGrossWt + double.Parse(lblRecQty.Text); }
            catch { dTotGrossWt = 0; }

            try
            { dTotDefReel = dTotDefReel + double.Parse(lblDefReel.Text); }
            catch { dTotDefReel = 0; }

            try
            { dTotDefWt = dTotDefWt + double.Parse(lblDefWt.Text); }
            catch { dTotDefWt = 0; }

            try
            {
                DataRowView drv = ((DataRowView)e.Row.DataItem);
                if (previousCov == drv["CoverInformation"].ToString())
                {
                    if (GridView1.Rows[firstRow].Cells[1].RowSpan == 0)
                    {
                        GridView1.Rows[firstRow].Cells[1].RowSpan = 2;
                        //GridView1.Rows[firstRow].Cells[1].Style.Add("vertical-align", "middle");
                    }
                    else
                    {
                        GridView1.Rows[firstRow].Cells[1].RowSpan += 1;
                        //GridView1.Rows[firstRow].Cells[1].Style.Add("vertical-align","middle");
                    }
                    e.Row.Cells.RemoveAt(1);
                   
                }
                else
                {
                    //e.Row.VerticalAlign = VerticalAlign.Middle;
                    previousCov = drv["CoverInformation"].ToString();
                    firstRow = e.Row.RowIndex;
                }
            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotReels = (Label)e.Row.FindControl("lblTotReels");
            Label lblTotRecQty = (Label)e.Row.FindControl("lblTotRecQty");
            Label lblTotDefReel = (Label)e.Row.FindControl("lblTotDefReel");

            lblTotReels.Text = Math.Round(dTotReel).ToString();
            lblTotRecQty.Text = dTotGrossWt.ToString("0.000");
            lblTotDefReel.Text = Math.Round(dTotDefReel).ToString();

            lblTotTonMetric.Text = dTotDefWt.ToString();
            lblTotDefReel11.Text = lblTotDefReel.Text;
        }


    }

     // string previousCat = "";int firstRow = -1;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    { 
        if (e.Row.RowType == DataControlRowType.DataRow) 
        {  
            //We're only interested in Rows that contain data    //get a reference to the data used to databound the row  
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            if (previousCov == drv["CategoryName"].ToString())   
            {      //If it's the same category as the previous one      //Increment the rowspan    
                if (GridView1.Rows[firstRow].Cells[0].RowSpan == 0)      
                    GridView1.Rows[firstRow].Cells[0].RowSpan = 2;     
                else   
                    GridView1.Rows[firstRow].Cells[0].RowSpan += 1;      //Remove the cell 
                e.Row.Cells.RemoveAt(0);  
            }    else 
                //It's a new category 
            {      //Set the vertical alignment to top     
                e.Row.VerticalAlign = VerticalAlign.Top;      //Maintain the category in memory     
                previousCov = drv["CategoryName"].ToString();     
                firstRow = e.Row.RowIndex;   
            } 
        }
    }

    private void fnClearCtrls()
    {
      
        tdPrintContent.Visible = false;
        tdNoRecord.Visible = false;
        GridView1.DataSource = null;
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
        Button1_Click(null, null);
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "GroupInformation.xls"));
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