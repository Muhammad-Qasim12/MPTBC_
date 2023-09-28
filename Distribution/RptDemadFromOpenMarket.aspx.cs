using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.IO;
using System.Data;

public partial class Distrubution_RptDemadFromOpenMarket : System.Web.UI.Page
{
    double LastYearSaleBook = 0, CurntYearOpenBook = 0, OpenTentetiveStock = 0, NetDemand = 0;
    Dis_TentativeDemandHistory objTentativeDemandHistory = null;
    Dis_OpenMarketDemand objOpenMarketDemand = null;
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        int CurrentYear = DateTime.Today.Year;
        string PreviousYear = (CurrentYear - 1).ToString();
        string NextYear = (CurrentYear + 1).ToString();
        string finYear = "";
        if (DateTime.Today.Month > 3)
            finYear = CurrentYear.ToString() + "-" + NextYear;
        else
            finYear = PreviousYear + "-" + CurrentYear.ToString();

        if (!IsPostBack)
        {
            ddlSessionYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlSessionYear.DataValueField = "AcYear";
            ddlSessionYear.DataTextField = "AcYear";
            ddlSessionYear.DataBind();
            ddlSessionYear.Items.FindByText(obCommonFuction.GetFinYear()).Selected = true;
        }


    }

    protected void ddlMedum_Init(object sender, EventArgs e)
    {
        objTentativeDemandHistory = new Dis_TentativeDemandHistory();
        ddlMedum.DataSource = objTentativeDemandHistory.MedumFill();
        ddlMedum.DataValueField = "MediumTrno_I";
        ddlMedum.DataTextField = "MediunNameHindi_V";
        ddlMedum.DataBind();
        ddlMedum.Items.Insert(0, "Select");
    }
    protected void ddlClass_Init(object sender, EventArgs e)
    {

        objTentativeDemandHistory = new Dis_TentativeDemandHistory();
        ddlClass.DataSource = objTentativeDemandHistory.ClassFill();
        ddlClass.DataValueField = "ClassTrno_I";
        ddlClass.DataTextField = "ClassDesc_V";
        ddlClass.DataBind();
        //ddlClass.Items.Insert(0, "Select");
    }

    protected void ddlDepoMaster_Init(object sender, EventArgs e)
    {
        ddlDepoMaster.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
        ddlDepoMaster.DataValueField = "DepoTrno_I";
        ddlDepoMaster.DataTextField = "DepoName_V";
        ddlDepoMaster.DataBind();
        ddlDepoMaster.Items.Insert(0, "All");
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlClass.SelectedItem.Text != "Select" && ddlMedum.SelectedItem.Text != "Select")
            {
                string strclasses = "";
                foreach (ListItem item in ddlClass.Items)
                {
                    if (item.Selected)
                    {
                        strclasses = strclasses + "," + item.Value;
                    }

                }
                 
                DataSet Ds = new DataSet();
                Ds = obCommonFuction.FillDatasetByProc("Call USP_DIS001_OpenDemandDataShowWithCls('" + ddlDepoMaster.SelectedValue.ToString().Replace("All", "0") + "','" + ddlMedum.SelectedItem.Value.ToString().Replace("Select", "0") + "','" + strclasses + "','" + ddlSessionYear.SelectedValue + "',2)"); // objOpenMarketDemand.BooksfillWithClass(strclasses);
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    lblYear.Text = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
                    lblTitle.Text = "डिपो का नाम  : " + ddlDepoMaster.SelectedItem.Text.Replace("All", "सभी") + ", " + " माध्यम का नाम : " + ddlMedum.SelectedItem.Text.Replace("All", "सभी") + ", " + " कक्षा : " + strclasses;
                    lblDate.Text = "दिनांक :" + System.DateTime.Now.ToString("dd MMM yyyy");
                    tdPrintContent.Visible = true;
                    GrdBooksMaster.DataSource = Ds.Tables[0];
                    GrdBooksMaster.DataBind();
                }
                else
                {
                    tdPrintContent.Visible = false;
                    GrdBooksMaster.DataSource = Ds.Tables[0];
                    GrdBooksMaster.DataBind();

                }


            }
        }
        catch { }
    }

    protected void GrdBooksMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblLastYearSaleBook = (Label)e.Row.FindControl("lblLastYearSaleBook");
            Label lblCurntYearOpenBook = (Label)e.Row.FindControl("lblCurntYearOpenBook");
            Label lblOpenTentetiveStock = (Label)e.Row.FindControl("lblOpenTentetiveStock");
            Label lblNetDemand = (Label)e.Row.FindControl("lblNetDemand");
            try
            {
                LastYearSaleBook = LastYearSaleBook + double.Parse(lblLastYearSaleBook.Text);
            }
            catch { LastYearSaleBook = 0; }
            try
            {
                CurntYearOpenBook = CurntYearOpenBook + double.Parse(lblCurntYearOpenBook.Text);
            }
            catch { CurntYearOpenBook = 0; }
            try
            {
                OpenTentetiveStock = OpenTentetiveStock + double.Parse(lblOpenTentetiveStock.Text);
            }
            catch { OpenTentetiveStock = 0; }
            try
            {
                NetDemand = NetDemand + double.Parse(lblNetDemand.Text);
            }
            catch { NetDemand = 0; }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblFLastYearSaleBook = (Label)e.Row.FindControl("lblFLastYearSaleBook");
            Label lblFCurntYearOpenBook = (Label)e.Row.FindControl("lblFCurntYearOpenBook");
            Label lblFOpenTentetiveStock = (Label)e.Row.FindControl("lblFOpenTentetiveStock");
            Label lblFNetDemand = (Label)e.Row.FindControl("lblFNetDemand");
            lblFLastYearSaleBook.Text = LastYearSaleBook.ToString();
            lblFCurntYearOpenBook.Text = CurntYearOpenBook.ToString();
            lblFOpenTentetiveStock.Text = OpenTentetiveStock.ToString();
            lblFNetDemand.Text = NetDemand.ToString();
        }
    }
    ////////  EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Reports.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }


    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }
}
