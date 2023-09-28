using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class Depo_ViewChallan : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    MediumMaster obMediumMaster = null;
    PRI_PrinterRegistration obPRI_PrinterRegistration = new PRI_PrinterRegistration();
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DataSet dd = comm.FillDatasetByProc("call USP_ReceivedChallanDetails("+ Session["UserID"]+ ")");
            //grdDetails.DataSource = dd.Tables[0];
            //grdDetails.DataBind();
            CommonFuction comm = new CommonFuction();
            DataSet asdf = comm.FillDatasetByProc("call USP_DPTOPeningStock(0,1,0,0,0,0)");
            DropDownList2.DataSource = asdf.Tables[0];
            DropDownList2.DataTextField = "TitleHindi_V";
            DropDownList2.DataValueField = "TitleID_I";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("All", "0"));

            DataSet ds = new System.Data.DataSet();
            ds = obPRI_PrinterRegistration.PrinterRegistrationLoad();
            ddlprinterName.DataSource = ds.Tables[0];
            ddlprinterName.DataValueField = "Printer_RedID_I";
            ddlprinterName.DataTextField = "NameofPressHindi_V";
            ddlprinterName.DataBind();
            ddlprinterName.Items.Insert(0, new ListItem("Select...", "0"));

        }
    
    }
    protected void grdDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //comm.FillDatasetByProc("call USP_DPTDeleteChallan("+grdDetails.DataKeys[e.RowIndex].Value.ToString ()+")");
        //DataSet dd = comm.FillDatasetByProc("call USP_ReceivedChallanDetails(" + Session["UserID"] + ","+ddlprinterName.SelectedValue+","+DropDownList2.SelectedValue+" )");
        //grdDetails.DataSource = dd.Tables[0];
        //grdDetails.DataBind();


    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetails.PageIndex = e.NewPageIndex;
        DataSet dd = comm.FillDatasetByProc("call USP_ReceivedChallanDetails(" + Session["UserID"] + "," + ddlprinterName.SelectedValue + "," + DropDownList2.SelectedValue + " )");
        grdDetails.DataSource = dd.Tables[0];
        grdDetails.DataBind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("InterDepoBookReceived.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DataSet dd = comm.FillDatasetByProc("call USP_ReceivedChallanDetails(" + Session["UserID"] + "," + ddlprinterName.SelectedValue + "," + DropDownList2.SelectedValue + " )");
        grdDetails.DataSource = dd.Tables[0];
        grdDetails.DataBind();
    }
    protected void ddlprinterName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GetPrinterWiseTitle
        CommonFuction comm = new CommonFuction();
        DataSet assdf = comm.FillDatasetByProc("call GetPrinterWiseTitle(" + Session["UserID"] + "," + ddlprinterName.SelectedValue + ")");
        DropDownList2.DataSource = assdf.Tables[0];
        DropDownList2.DataTextField = "TitleHindi_V";
        DropDownList2.DataValueField = "TitleID_I";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("Select..", "0"));
    }
}