using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data ;
public partial class Printing_RptCoverandPrintingPaperDetails : System.Web.UI.Page
{
    public DataSet dd = new DataSet();
    public DataSet dd2 = new DataSet();
    public CommonFuction obCommonFuction = new CommonFuction();
    public double printingPaper; public int EmdMoney;
    public int coutn = 0;
    public int Froma, To;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlAcadmicYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlAcadmicYear.DataValueField = "AcYear";
            ddlAcadmicYear.DataTextField = "AcYear";
            ddlAcadmicYear.DataBind();
            ddlAcadmicYear.SelectedValue = obCommonFuction.GetFinYear();
            ddlAcadmicYear.Items.Insert(0, "सलेक्ट करे");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void ddlTenderID_I_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("call Prin_loadTenderDetails(0,'" + ddlAcadmicYear.SelectedItem.Text + "')"); ;
        ddlTenderID_I.DataSource = dd.Tables[0];
        ddlTenderID_I.DataValueField = "TenderId_I";
        ddlTenderID_I.DataTextField = "TenderNo_V";
        ddlTenderID_I.DataBind();
        ddlTenderID_I.Items.Insert(0, "Select..");
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Panel1.Visible = true;
    }
}