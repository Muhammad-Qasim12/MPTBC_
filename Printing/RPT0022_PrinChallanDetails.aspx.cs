using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using MPTBCBussinessLayer.Academic;
using System.IO;
public partial class RPT0022_PrinChallanDetails : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    TitleMaster obTitleMaster = null;
    PRIN_ChallanDetails obPrinChallan = null;
    Pri_BillDetails objBillDetails = null;
    int pid;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField =  "AcYear";
            DdlACYear.DataBind();
            //DdlACYear.SelectedValue = obCommonFuction.GetFinYearNew();
            //DdlACYear.Enabled = false;
            LoadGrid();

            pid = Convert.ToInt32(Session["PrierID_I"].ToString() );

            
            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_RPT0022_DepomasterLoad(" + pid + ",1,'" + DdlACYear.SelectedValue + "',0)");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, "--Select--");


           
        }
    }


    public void LoadGrid()
    {
       
            obPrinChallan = new PRIN_ChallanDetails();
            PRI_PrinterRegistration PriReg = new PRI_PrinterRegistration();
            PriReg.UserID_I = Convert.ToInt32(Session["USerID"]);
            DataSet ds = new DataSet();
            ds = PriReg.GetPrinterDetails();
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["PrierID_I"] = Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
                     
                    obPrinChallan.PriTransID = Convert.ToInt32(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
                     
                }
                else
                {
                     
                    obPrinChallan.PriTransID = 0;
                }

                if (ddlClass.SelectedIndex > 0)
                {
                    obPrinChallan.ClassID = Convert.ToInt32(ddlClass.SelectedValue);
                }
                else
                { obPrinChallan.ClassID = 0; }

                if (ddlTitle.SelectedIndex > 0)
                {
                    obPrinChallan.TitalID  = Convert.ToInt32(ddlTitle.SelectedValue );
                }
                else
                { obPrinChallan.TitalID = 0; }


                if (DdlDepot.SelectedIndex > 0)
                {
                    obPrinChallan.Depo_I = Convert.ToInt32(DdlDepot.SelectedValue);
                }
                else
                {
                    obPrinChallan.Depo_I = 0;
                }



                obPrinChallan.Finyear = Convert.ToString(DdlACYear.SelectedValue);

                ds=obPrinChallan.PrinLoadChallanDetailsprint();

                if (ds.Tables[0].Rows.Count > 0)
                {

                    GrdChallan.DataSource = ds.Tables[0];
                    GrdChallan.DataBind();
                }

                else

                {


                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('No Data Found');</script>");

                    GrdChallan.DataSource = "";
                    GrdChallan.DataBind();
                
                }
            }

            catch (Exception ex) { }
            finally { obPrinChallan = null; }
        

       
    }

    protected void btnAdd_Click(object sender, EventArgs e) 
    {
       // Response.Redirect("PRIN0011_ChallanDetails.aspx");
    }

    protected void GrdChallan_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcell();
        }
        catch { }
    }
    public void ExportToExcell()
    {

        LoadGrid();
        Class1 cls = new Class1();
        cls.Export("Challan.xls", GrdChallan, "चालान की जानकारी");
        //Response.ClearContent();
        //Response.Buffer = true;
        //Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Challan.xls"));
        //Response.Charset = "";
        //Response.ContentType = "application / vnd.ms - word";

        //StringWriter sw = new StringWriter();
        //HtmlTextWriter HW = new HtmlTextWriter(sw);

        //ExportDiv.RenderControl(HW);
        //Response.Write(sw.ToString());
        //Response.End();
        //Response.Clear();
    }
    protected void GrdChallan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdChallan.PageIndex = e.NewPageIndex;
        LoadGrid();
    }
    public void FillTitle()
    {
        try
        {

            pid = Convert.ToInt32(Session["PrierID_I"].ToString());

            ddlTitle.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_RPT0022_DepomasterLoad(" + pid + ",2,'" + DdlACYear.SelectedValue + "'," + DdlDepot.SelectedValue + " )");
            ddlTitle.DataValueField = "titleid_i";
            ddlTitle.DataTextField = "titlehindi_v";
            ddlTitle.DataBind();
            ddlTitle.Items.Insert(0, "--Select--");
        }
        catch { }
        finally { obTitleMaster = null; }
    }
    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillTitle();
        }
        catch { }
        finally { obTitleMaster = null; }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadGrid();
    }
    public void FillClassMediumDDL()
    {
        try
        {
            pid = Convert.ToInt32(Session["PrierID_I"].ToString());
            //obTitleMaster = new TitleMaster();
            //obTitleMaster.ID = 0;
            //var data = obTitleMaster.FillReport();
            //ddlClass.DataSource = data;
            //ddlClass.DataValueField = "ClassTrno_I";
            //ddlClass.DataTextField = "Classdet_V";
            //ddlClass.DataBind();
            //ddlClass.Items.Insert(0, "Select..");
            ddlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_RPT0022_DepomasterLoad(" + pid + ",3,'" + DdlACYear.SelectedValue + "'," + DdlDepot.SelectedValue + " )");
            ddlClass.DataValueField = "classTrno_I";
            ddlClass.DataTextField = "classTrno_I";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, "--Select--");
            
        }
        catch { }
        finally { obTitleMaster = null; }
    }

    protected void DdlDepot_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillClassMediumDDL();
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        pid = Convert.ToInt32(Session["PrierID_I"].ToString());
        DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_RPT0022_DepomasterLoad(" + pid + ",1,'" + DdlACYear.SelectedValue + "',0)");
        DdlDepot.DataValueField = "DepoTrno_I";
        DdlDepot.DataTextField = "DepoName_V";
        DdlDepot.DataBind();
        DdlDepot.Items.Insert(0, "--Select--");
    }
}