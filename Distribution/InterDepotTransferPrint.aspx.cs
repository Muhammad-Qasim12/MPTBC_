using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.IO;
using System.Globalization;

public partial class Distrubution_InterDepotTransferPrint : System.Web.UI.Page
{
    CommonFuction obj = new CommonFuction();
    DataSet ds;
    InterDepoTransfer ObjInterDepoTransfer = null;
    Random rdm = new Random();
    string ChallanNo;
    double TotQty = 0; CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DdlACYear.DataSource = obj.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obj.GetFinYear();
          //  DataSet asdf = comm.FillDatasetByProc("call USP_DPTOPeningStock(0,1,0,0,0,0)");
            DropDownList1.DataSource = obj.FillDatasetByProc("call USP_DPTOPeningStock(0,1,0,0,0,0)"); ;
            DropDownList1.DataTextField = "TitleHindi_V";
            DropDownList1.DataValueField = "TitleID_I";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
           // GridFillLoad();
        }
    }
    //USP_GetInterDepoReport
    public void GridFillLoad()
    {
        try
        {
            if (ddlReqDepo.SelectedItem.Text != "Select")
            {
                //DBAccess obDBAccess = new DBAccess();
                //obDBAccess.execute("USP_DPO002_InterDepoTransferShowData", DBAccess.SQLType.IS_PROC);
                //obDBAccess.addParam("mDepoTrno_I", 0);
                //obDBAccess.addParam("mDemandingDepotID", 0);
                //obDBAccess.addParam("mReqNo", 0);
                //obDBAccess.addParam("mSupplierDepoID", SupplierDepoID);
                //obDBAccess.addParam("mtype", 4);
             DataSet dd= obj.FillDatasetByProc("call USP_DPO002_InterDepoTransferShowData(0,"+ddlReqDepo0.SelectedValue+",0,"+ddlReqDepo.SelectedValue+",4)");
             GrdDepoQtyMaster.DataSource = dd.Tables[0];
                
                //return obDBAccess.records();
                //ObjInterDepoTransfer = new InterDepoTransfer();
                //ObjInterDepoTransfer.SupplierDepoID = int.Parse(ddlReqDepo.SelectedValue.ToString());
                //GrdDepoQtyMaster.DataSource = ObjInterDepoTransfer.ChallanFillForPrintBYSuppl();
                GrdDepoQtyMaster.DataBind();
            }
            else
            {
                GrdDepoQtyMaster.DataSource = string.Empty;
                GrdDepoQtyMaster.DataBind();
            }
        }
        catch { }

    }
    public void GridFillLoad1()
    {
        try
        {
            if (ddlReqDepo.SelectedItem.Text != "Select")
            {
                //DBAccess obDBAccess = new DBAccess();
                //obDBAccess.execute("USP_DPO002_InterDepoTransferShowData", DBAccess.SQLType.IS_PROC);
                //obDBAccess.addParam("mDepoTrno_I", 0);
                //obDBAccess.addParam("mDemandingDepotID", 0);
                //obDBAccess.addParam("mReqNo", 0);
                //obDBAccess.addParam("mSupplierDepoID", SupplierDepoID);
                //obDBAccess.addParam("mtype", 4);
                DataSet dd = obj.FillDatasetByProc("call USP_DPO002_InterDepoTransferShowData(0," + ddlReqDepo0.SelectedValue + ",0," + ddlReqDepo.SelectedValue + ",7)");
                GrdDepoQtyMaster.DataSource = dd.Tables[0];

                //return obDBAccess.records();
                //ObjInterDepoTransfer = new InterDepoTransfer();
                //ObjInterDepoTransfer.SupplierDepoID = int.Parse(ddlReqDepo.SelectedValue.ToString());
                //GrdDepoQtyMaster.DataSource = ObjInterDepoTransfer.ChallanFillForPrintBYSuppl();
                GrdDepoQtyMaster.DataBind();
            }
            else
            {
                GrdDepoQtyMaster.DataSource = string.Empty;
                GrdDepoQtyMaster.DataBind();
            }
        }
        catch { }

    }


    protected void GrdDepoQtyMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

          //  19221805573350
            // 7231704433755
            Label lblChallanNo = (Label)e.Row.FindControl("lblChallanNo");
            Label lblChalanDate = (Label)e.Row.FindControl("lblChalanDate");
            Label lblDemandingDepotID = (Label)e.Row.FindControl("lblDemandingDepotID");
            Label lblSupplierDepoID = (Label)e.Row.FindControl("lblSupplierDepoID");
            DateTime dte = new DateTime();
            dte = DateTime.Parse(lblChalanDate.Text);
            lblChalanDate.Text = dte.ToString("dd/MM/yyyy");
            GridView GvReelDetails = (GridView)e.Row.FindControl("GvReelDetails");
            TotQty = 0;
            GvReelDetails.DataSource = obj.FillDatasetByProc("Call USP_DPO002_InterDepoTransferShowData(0,'" + lblDemandingDepotID.Text + "','" + lblChallanNo.Text + "','" + lblSupplierDepoID.Text + "',6)");
            GvReelDetails.DataBind();

        }
    }
    protected void GvReelDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblNoOFBook = (Label)e.Row.FindControl("lblNoOFBook");

            try
            {
                TotQty = TotQty + double.Parse(lblNoOFBook.Text);
            }
            catch { }


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblFNoOFBook = (Label)e.Row.FindControl("lblFNoOFBook");
            lblFNoOFBook.Text = TotQty.ToString();
        }
    }

    protected void ddlReqDepo_Init(object sender, EventArgs e)
    {

        ObjInterDepoTransfer = new InterDepoTransfer();
        ds = ObjInterDepoTransfer.ChallanFillForPrint();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlReqDepo.DataSource = ds.Tables[0];
            ddlReqDepo.DataTextField = "TransSupply";
            ddlReqDepo.DataValueField = "SupplierDepoID";
            ddlReqDepo.DataBind();
            ddlReqDepo.Items.Insert(0, new ListItem("Select...", "0"));
            ddlReqDepo0.DataSource = ds.Tables[0];
            ddlReqDepo0.DataTextField = "TransSupply";
            ddlReqDepo0.DataValueField = "SupplierDepoID";
            ddlReqDepo0.DataBind();
            ddlReqDepo0.Items.Insert(0, new ListItem("Select...", "0"));
        }
        else
        {
            ddlReqDepo.DataSource = string.Empty;
            ddlReqDepo.DataBind();
            ddlReqDepo.Items.Insert(0, "Select");

        }
    }
    protected void ddlReqDepo_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridFillLoad();
        ddlReqDepo0.SelectedIndex = 0;
    }
    protected void ddlReqDepo0_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlReqDepo.SelectedIndex = 0;
        GridFillLoad1();
    }

    protected void txtfromDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Add date filter by Challan date - 19/4/2017
        a.Visible = false;
        a1.Visible = false;
        string challanDt = FnDtFormat(txtFromDate.Text);
        GridView1.DataSource = obj.FillDatasetByProc("call USP_GetInterDepoReport('" + DdlACYear.SelectedValue + "','" + challanDt + "')");
        GridView1.DataBind();
        GrdDepoQtyMaster.DataSource = null;
        GrdDepoQtyMaster.DataBind();
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            //Add date filter by Challan date - 19/4/2017
            a.Visible = false;
            a1.Visible = false;
            a123.Visible = true;

           // GridView1.DataSource = obj.FillDatasetByProc("call USP_GetInterDepoReport('" + DdlACYear.SelectedValue + "','')");
           // GridView1.DataBind();
            GrdDepoQtyMaster.DataSource = null;
            GrdDepoQtyMaster.DataBind();
        }
        else
        {
            a.Visible = true;
            a1.Visible = true;
            a123.Visible = false;
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcell();
            //Class1 cls = new Class1();
            //cls.Export("Export.xls", GrdStockAvailability, "Export");
        }
        catch { }
        finally { }
    }
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "TENDERPARTICIPENT.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - word";

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

    public string FnDtFormat(string date)
    {
        if (date.Trim().Length > 0)
        {
            if (date.IndexOf('-') > 0)
            {
                date = date.Split('-')[2] + "-" + date.Split('-')[1] + "-" + date.Split('-')[0];
            }
            else
                date = date.Split('/')[2] + "-" + date.Split('/')[1] + "-" + date.Split('/')[0];
        }
        return date;
    }
    protected void showReport_Click(object sender, EventArgs e)
    {
        try {
            a.Visible = false;
            a1.Visible = false;
            a123.Visible = true;

            // GridView1.DataSource = obj.FillDatasetByProc("call USP_GetInterDepoReport('" + DdlACYear.SelectedValue + "','')");
            // GridView1.DataBind();
            GrdDepoQtyMaster.DataSource = null;
            GrdDepoQtyMaster.DataBind();
        GridView1.DataSource = obj.FillDatasetByProc("call USP_GetInterDepoReportNew('" + DdlACYear.SelectedValue + "','" + Convert.ToDateTime(TextBox1.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(txtTodate.Text, cult).ToString("yyyy-MM-dd") + "',"+DropDownList1.SelectedValue+")");
        GridView1.DataBind();
        }
        catch { }
    }
}
