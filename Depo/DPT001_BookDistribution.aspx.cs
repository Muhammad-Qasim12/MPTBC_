using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
public partial class Depo_DPT001_BookDistribution : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
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
            Random rand = new Random();
            int randnum = rand.Next(100000, 10000000);
            txtChalanNo.Text = randnum.ToString();
            txtChalanNo.Enabled = false;
            CommonFuction obCommonFuction = new CommonFuction();
            ddlSessionYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlSessionYear.DataValueField = "AcYear";
            ddlSessionYear.DataTextField = "AcYear";
            ddlSessionYear.DataBind();
            ddlSessionYear.SelectedValue = obCommonFuction.GetFinYear();
            try
            {
            

                DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("call USP_DD_SelectDistrict(" + Session["UserID"] + " ,0,0 )");
                DdlDistrict.DataValueField = "DistrictTrno_I";
                DdlDistrict.DataTextField = "District_Name_Hindi_V";
                DdlDistrict.DataBind();
                DdlDistrict.Items.Insert(0, "--Select--");
            }
            catch { }
            ddlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_SchemeLoadClassWise('" + 0 + "')");
            ddlScheme.DataValueField = "SchemeId";
            ddlScheme.DataTextField = "SchemeName_Hindi";
            ddlScheme.DataBind();
            ddlScheme.Items.Insert(0, "--Select--");
        //    GrdIssueBook.DataSource = obCommonFuction.FillDatasetByProc("call USP_DPT018_BookIssue(" + Convert.ToString(Session["UserID"]) + ")");
          //  GrdIssueBook.DataBind();

        }
    }
    protected void DdlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strcallbyd = "CALL USP_GEN_GetBlockByDistrict(" + DdlDistrict.SelectedValue + ")";
        CommonFuction obCommonFuction = new CommonFuction();
        DataSet ds = obCommonFuction.FillDatasetByProc(strcallbyd);
        ddlBlock.DataSource = ds;
        ddlBlock.DataTextField = "BlockNameHindi_V";
        ddlBlock.DataValueField = "BlockTrno_I";
        ddlBlock.DataBind();

    }
    protected void lnk_DistrbutBookClick(object sender, EventArgs e)
    {

        LinkButton lnkButton = (LinkButton)sender;
        btnSaveMasterData.CommandArgument = lnkButton.CommandArgument;
       // pnldiv.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");

        GridViewRow grdrow = (GridViewRow)(lnkButton).NamingContainer;

        hdnDistrictID.Value = ((HiddenField)grdrow.FindControl("hdnDistrictID")).Value;
        hdnOrderID.Value = ((Label)grdrow.FindControl("lblOerderId")).Text;
        hdnblockname.Value = ((HiddenField)grdrow.FindControl("hdnblockname")).Value;
        // Response.Redirect("View_DPT014.aspx?ID=" + lnkButton.CommandArgument);
    }


    protected void btnSave(object sender, EventArgs e)
    {

        CommonFuction obCommonFuction = new CommonFuction();
        DataSet ddd1 = obCommonFuction.FillDatasetByProc("select distinct OrderNO from dis_textbookdemand_t where blockId=" + ddlBlock.SelectedValue + " and AcYearId='" + ddlSessionYear.SelectedItem.Text + "' and SchemeID=" + ddlScheme.SelectedValue + " and  IsFinal=1");
       if (ddd1.Tables[0].Rows.Count > 0)
       {
           hdnOrderID.Value = ddd1.Tables[0].Rows[0]["OrderNO"].ToString();
       }
        string ProcString = "call USP_DPT019_DistributeStockSave(0 ,'" + hdnOrderID.Value + "'";
        ProcString = ProcString + ",'" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "'";
        ProcString = ProcString + ",'" + txtChalanNo.Text + "'";

        ProcString = ProcString + ",'" + Convert.ToDateTime(txtChalanDate.Text, cult).ToString("yyyy-MM-dd") + "'";

        ProcString = ProcString + ",'" + DdlDistrict.SelectedValue + "'";
        ProcString = ProcString + ",'" + ddlBlock.SelectedValue + "'";
        ProcString = ProcString + "," + "0";
        ProcString = ProcString + ",'" + DropDownList1.SelectedValue + "'";
        ProcString = ProcString + ",'" + txtGRNO.Text + "'";
        ProcString = ProcString + ",'" + Convert.ToDateTime(txtGRNDate.Text, cult).ToString("yyyy-MM-dd") + "'";
        ProcString = ProcString + ",'" + txtTrucko.Text + "'";
        ProcString = ProcString + ",'" + txtDriverMobileNo.Text + "'";
        ProcString = ProcString + ",'" + txtRemark.Text + "'";
        ProcString = ProcString + ",'" + Convert.ToString(Session["UserID"]) + "'";
        ProcString = ProcString + ",'" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "'";
        ProcString = ProcString + ")";
        DataSet ds = obCommonFuction.FillDatasetByProc(ProcString);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            MailHelper mail = new MailHelper();
            mail.sendMessage("9893140658,9993146080,9179018774", "Date of dispatch " + System.DateTime.Now.ToString("dd/MM/yyyy") + " BRC/BEO Name " + hdnblockname.Value + " Vehicle No  " + txtTrucko.Text + " Driver contact no " + txtDriverMobileNo.Text + "");
            Response.Redirect("View_DPT014.aspx?ID=" + ddlBlock.SelectedValue + "&ChallanNo=" + txtChalanNo.Text + "&MasterID=" + Convert.ToString(dr[0]) + "&Session=" + ddlSessionYear.SelectedValue + "&schemeid=" + ddlScheme.SelectedValue);

        }

    }

}