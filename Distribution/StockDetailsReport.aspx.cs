using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

using System.IO;
public partial class Distribution_StockDetailsReport : System.Web.UI.Page
{
    public CommonFuction comm = new CommonFuction();
    DPT_DepotMaster obDPT_DepotMaster = null;

    string Classes = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFuction comm = new CommonFuction();

            ddlMedium.DataSource = comm.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("Select..", "0"));
            ddlSessionYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlSessionYear.DataValueField = "AcYear";
            ddlSessionYear.DataTextField = "AcYear";
            ddlSessionYear.DataBind();
            DdlDepot.DataSource = comm.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, "All");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Classes = "";
        string DepoID;
        if (DDLClass.SelectedValue.ToString() == "1-8") Classes = "1,2,3,4,5,6,7,8";
        else if (DDLClass.SelectedValue.ToString() == "9-12") Classes = "9,10,11,12";
        if (DdlDepot.SelectedIndex == 0)
        {
            DepoID = "0";
           //DepoID = DdlDepot.SelectedValue = "0";

        }
        else
        {
            DepoID = DdlDepot.SelectedValue;
        }
        GridView1.DataSource = comm.FillDatasetByProc("call usp_gETfORMAT3 ('" + ddlSessionYear.SelectedValue + "'," + ddlMedium.SelectedValue + ", " + DepoID + ",'" + DDLClass.SelectedValue + "') ");
       
        GridView1.DataBind();
    }
}