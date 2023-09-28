using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
using MPTBCBussinessLayer.DistributionB;
public partial class DistributionB_InterDepoOtherthantextbook : System.Web.UI.Page
{
    RDLC_Data objReports = new RDLC_Data();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = objReports.FillFyYear().Tables[0];
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataValueField = "Id";
            DdlACYear.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));

            ddlDepoFrom.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot1()");
            ddlDepoFrom.DataValueField = "DepoTrno_I";
            ddlDepoFrom.DataTextField = "DepoName_V";
            ddlDepoFrom.DataBind();
            ddlDepoFrom.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlDepoTo.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot1()");
            ddlDepoTo.DataValueField = "DepoTrno_I";
            ddlDepoTo.DataTextField = "DepoName_V";
            ddlDepoTo.DataBind();
            ddlDepoTo.Items.Insert(0, new ListItem("--Select--", "0"));

            ddlBookName.DataSource = obCommonFuction.FillDatasetByProc("call USP_DIB_Rpt001_DepowiseDemand(" + DdlACYear.SelectedValue + ",'-2')");
            ddlBookName.DataTextField = "LetterNo_Va";
            ddlBookName.DataValueField = "LetterNo_V";
            ddlBookName.DataBind();
            ddlBookName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
}