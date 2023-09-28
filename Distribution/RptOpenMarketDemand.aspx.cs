using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.Store;
using System.Data;
using System.Globalization;
using System.IO;
using MPTBCBussinessLayer;

public partial class Distribution_RptOpenMarketDemand : System.Web.UI.Page
{
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
            ddlSessionYear.SelectedValue = obCommonFuction.GetFinYear();
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

        //objOpenMarketDemand = new Dis_OpenMarketDemand();
        //ddlDepoMaster.DataSource = objOpenMarketDemand.Depofill();
        //ddlDepoMaster.DataValueField = "DepoTrno_I";
        //ddlDepoMaster.DataTextField = "DepoName_V";
        //ddlDepoMaster.DataBind();
        //ddlDepoMaster.Items.Insert(0, "Select");

        ddlDepoMaster.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
        ddlDepoMaster.DataValueField = "DepoTrno_I";
        ddlDepoMaster.DataTextField = "DepoName_V";
        ddlDepoMaster.DataBind();
        //ddlDepoMaster.Items.Insert(0, "Select");
        ddlDepoMaster.Items.Insert(0, new ListItem("All","0"));
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
       // GetOpenMarketDemand
        string strclasses = "";
        foreach (ListItem item in ddlClass.Items)
        {
            if (item.Selected)
            {
                strclasses = strclasses + "," + item.Value;
            }

        }
        //`(mDepoTrno_I INT,mSession VARCHAR(50),mMediumTrno_I INT,mClassTrno_I VARCHAR(100))
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call GetOpenMarketDemand(" + ddlDepoMaster.SelectedValue + ",'"+ddlSessionYear.SelectedValue+"'," + ddlMedum.SelectedValue + ",'" + strclasses + "')");
        GridView1.DataBind();
    }

    protected void GrdGroupDetails_DataBound(object sender, EventArgs e)
    {
        this.AddTotalRow("Total", dMainDemand.ToString(), dExtraDemand.ToString(), dExtraDemand1.ToString(), dtotalDemand.ToString());
    }

    decimal dMainDemand = 0; decimal dExtraDemand = 0; decimal dExtraDemand1 = 0; decimal dtotalDemand = 0; 
    protected void OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (e.Row.DataItem as DataRowView).DataView.Table;
                dMainDemand += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["MainDemand"]);
                dExtraDemand += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["ExtraDemand"]);
                dExtraDemand1 += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["ExtraDemand1"]);
                dtotalDemand += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["totalDemand"]);
                
            }

          //  this.AddTotalRow("Total", "", dMainDemand.ToString("N2"), dExtraDemand.ToString("N2"), dExtraDemand1.ToString("N2"), dtotalDemand.ToString("N2"));
           
        }
        catch { }
    }

    private void AddTotalRow(string labelText,string maindemval, string extravalue, string extra1value, string totalvalue)
    {
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
        row.BackColor = System.Drawing.Color.Gray;
        row.Cells.AddRange(new TableCell[5] { new TableCell { Text = labelText, HorizontalAlign = HorizontalAlign.Right},                                        
                                        new TableCell { Text = maindemval, HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = extravalue, HorizontalAlign = HorizontalAlign.Right },
                                         new TableCell { Text = extra1value, HorizontalAlign = HorizontalAlign.Right },
        new TableCell { Text = totalvalue, HorizontalAlign = HorizontalAlign.Right },
       
        });

        GridView1.Controls[0].Controls.Add(row);
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
}