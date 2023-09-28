using System;
using System.Collections.Generic;
using MPTBCBussinessLayer;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AllChallan : System.Web.UI.Page
{
    PPR_TenderEvaluation objTenderEvaluation = null;
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot1()");
            //DdlDepot.DataValueField = "DepoTrno_I";
            //DdlDepot.DataTextField = "DepoName_V";
            //DdlDepot.DataBind();
            //DdlDepot.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
          //  DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_DPT018_PrinterDelivery_loadGM(0,1)");


           // grdDetails.DataSource = ds1.Tables[0];
            //grdDetails.DataBind();
            RadioButtonList1_SelectedIndexChanged( sender,  e);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "2")
        {
            DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_DPT018_PrinterDelivery_loadGM(" + DdlDepot.SelectedValue + ",1)");


            grdDetails.DataSource = ds1.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_GetMillData(" + DdlDepot.SelectedValue + ")");


            GridView1.DataSource = ds1.Tables[0];
            GridView1.DataBind();
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdDetails.DataSource = null;
        grdDetails.DataBind();
        GridView1.DataSource = null;
        GridView1.DataBind();
        if (RadioButtonList1.SelectedValue == "1")
        {
            DataSet dd = obCommonFuction.FillDatasetByProc("call ppr_GetPaperVendorbyAcYear(0)");
            DdlDepot.DataSource = dd.Tables[0];
            DdlDepot.DataTextField = "PaperVendorName_V";
            DdlDepot.DataValueField = "PaperVendorTrId_I";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
        }
        else
        {
            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot1()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
        
        }
    }
}