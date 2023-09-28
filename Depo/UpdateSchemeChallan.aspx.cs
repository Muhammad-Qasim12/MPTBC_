using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;

public partial class Depo_UpdateSchemeChallan : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    string ClassID;
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
            txtChalanDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtGRNDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            try
            {


                DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("call USP_DD_SelectDistrict(" + Session["UserID"] + " ,0,0 )");
                DdlDistrict.DataValueField = "DistrictTrno_I";
                DdlDistrict.DataTextField = "District_Name_Hindi_V";
                DdlDistrict.DataBind();
                DdlDistrict.Items.Insert(0, "--Select--");
            }
            catch { }
            //ddlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_SchemeLoadClassWise('" + 0 + "')");
            //ddlScheme.DataValueField = "SchemeId";
            //ddlScheme.DataTextField = "SchemeName_Hindi";
            //ddlScheme.DataBind();
            //ddlScheme.Items.Insert(0, "--Select--");
            //    GrdIssueBook.DataSource = obCommonFuction.FillDatasetByProc("call USP_DPT018_BookIssue(" + Convert.ToString(Session["UserID"]) + ")");
            //  GrdIssueBook.DataBind();
            ddlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)");
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, "--Select--");

            try { 
            DataSet dddddd = obCommonFuction.FillDatasetByProc("call USP_DPTSchemeChallanLoad('"+Request.QueryString["ChallanID"]+"')");
            DdlDistrict.SelectedValue = dddddd.Tables[0].Rows[0]["DistrictID_I"].ToString();
                DdlDistrict_SelectedIndexChanged( sender,  e);
            ddlBlock.SelectedValue = dddddd.Tables[0].Rows[0]["BlockID_I"].ToString();
            txtChalanDate.Text = dddddd.Tables[0].Rows[0]["ChallanDate_D"].ToString();
            txtChalanNo.Text = dddddd.Tables[0].Rows[0]["ChallanNo_V"].ToString();
            txtGRNDate.Text = dddddd.Tables[0].Rows[0]["GRNODate_D"].ToString();
            txtGRNO.Text = dddddd.Tables[0].Rows[0]["GRNO_V"].ToString();
            txtRemark.Text = dddddd.Tables[0].Rows[0]["Remarks_V"].ToString();
            txtTrucko.Text = dddddd.Tables[0].Rows[0]["TruckNo_V"].ToString();
            txtDriverMobileNo.Text = dddddd.Tables[0].Rows[0]["DriverMobileNo_V"].ToString();
            ddlMedium.SelectedValue = dddddd.Tables[0].Rows[0]["schemeid"].ToString();
            DropDownList1.SelectedValue = dddddd.Tables[0].Rows[0]["ReceiverName_V"].ToString();

            if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2")
            {
                ClassID = "1,2,3,4,5,6,7,8";
            }
            else if (DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "4")
            {
                ClassID = "9,10,11,12";
            }
            DataSet ds = obCommonFuction.FillDatasetByProc("call USP_DPTDistributionChallanGetdata(" + Session["UserID"] + ",'" + ddlBlock.SelectedValue + "','" + ddlSessionYear.SelectedValue + "','" + ClassID + "'," + ddlMedium.SelectedValue + ",'" + Request.QueryString["ChallanID"] + "')");
              DataTable dt = ds.Tables[0];
             DataTable dt1 = ds.Tables[0];
dt.DefaultView.RowFilter = "perbundlebook >0";
grBook.DataSource = dt;
            grBook.DataBind();
            }
            catch { }

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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void calculate(object sender, EventArgs e)
    {
        try
        {

            TextBox txtPerbundlebook = (TextBox)sender;
            //txtPerbundlebook
            GridViewRow grdrow = (GridViewRow)txtPerbundlebook.NamingContainer;
            TextBox lblnoofbooks = (TextBox)grdrow.FindControl("lblnoofbooks");
            TextBox txtPackbundle = (TextBox)grdrow.FindControl("txtPackbundle");
            TextBox txtloose = (TextBox)grdrow.FindControl("txtloose");
            TextBox txtPerbundlebook1 = (TextBox)grdrow.FindControl("txtPerbundlebook");
            var pack = Convert.ToInt32(lblnoofbooks.Text) / Convert.ToInt32(txtPerbundlebook1.Text);
            var loose = Convert.ToInt32(lblnoofbooks.Text) % Convert.ToInt32(txtPerbundlebook1.Text);
            txtPackbundle.Text = pack.ToString();
            txtloose.Text = loose.ToString();
        }
        catch { }



    }
    protected void btnSaveMasterData_Click(object sender, EventArgs e)
    {
       
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();
        DataSet ddd1 = obCommonFuction.FillDatasetByProc("select distinct OrderNO from dis_textbookdemand_t where blockId=" + ddlBlock.SelectedValue + " and AcYearId='" + ddlSessionYear.SelectedItem.Text + "'and  IsFinal=1");
        if (ddd1.Tables[0].Rows.Count > 0)
        {
            hdnOrderID.Value = ddd1.Tables[0].Rows[0]["OrderNO"].ToString();
        }
        string ProcString = "call USP_DPT019_DistributeStockuPDATE(0 ,'" + hdnOrderID.Value + "'";
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

        //foreach (DataRow dr in ds.Tables[0].Rows)
        //{

        CommonFuction comm = new CommonFuction();
        DataSet dfg = comm.FillDatasetByProc("call USP_DPTdeleteChallanbyID(1,'" + txtChalanNo.Text + "',0)");
        DataSet dfg22 = comm.FillDatasetByProc("call USP_DPTdeleteChallanbyID(10,'" + txtChalanNo.Text + "',0)");
        DBAccess db = new DBAccess();
        comm.FillDatasetByProc("call Dpt_TempTableDatasave(1,'" + ddlBlock.SelectedItem.Text + "',0,0,0,0,0,0,0, 0,0,'" + ddlBlock.SelectedValue + "',0,'" + ddlSessionYear.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "')");
        for (int i = 0; i < grBook.Rows.Count; i++)
        {
            if (((CheckBox)grBook.Rows[i].FindControl("CheckBox1")).Checked == true)
            {
                if (((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text == grBook.Rows[i].Cells[5].Text || Convert.ToInt32(((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text) < Convert.ToInt32(((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text))
                {

                }
                else
                {
                    comm.FillDatasetByProc("call USP_DptBlockChallanSave(" + Convert.ToString(dfg.Tables[0].Rows[0]["masterID"].ToString()) + ",'" + txtChalanNo.Text + "'," + ((HiddenField)grBook.Rows[i].FindControl("HiddenField1")).Value + "," + ((TextBox)grBook.Rows[i].FindControl("txtPerbundlebook")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtPackbundle")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtloose")).Text + "," + ddlMedium.SelectedValue + ")");

                    comm.FillDatasetByProc("call Dpt_TempTableDatasave(0,'" + ddlBlock.SelectedItem.Text + "','" + DdlDistrict.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "','" + ddlMedium.SelectedValue + "','" + txtChalanNo.Text + "',''," + ((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text + " , " + ((TextBox)grBook.Rows[i].FindControl("txtPackbundle")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtloose")).Text + ",'" + ddlBlock.SelectedValue + "'," + ((HiddenField)grBook.Rows[i].FindControl("HiddenField1")).Value + ",'" + ddlSessionYear.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "')");
                }
            }
            //}

            // MailHelper mail = new MailHelper();
            // mail.sendMessage("9893140658,9993146080,9179018774", "Date of dispatch " + System.DateTime.Now.ToString("dd/MM/yyyy") + " BRC/BEO Name " + hdnblockname.Value + " Vehicle No  " + txtTrucko.Text + " Driver contact no " + txtDriverMobileNo.Text + "");


        }
        DataSet dd4 = obCommonFuction.FillDatasetByProc("call procedure1q( 0," + ddlBlock.SelectedValue + ",'" + ddlSessionYear.SelectedValue + "',0," + Session["UserID"] + ")");
        //DataSet dd4 = obCommonFuction.FillDatasetByProc("call procedure1q( 0," + ddlBlock.SelectedValue + ",'" + ddlSessionYear.SelectedValue + "','" + txtChalanNo.Text + "'," + Session["UserID"] + ")");
        DataSet dd3 = obCommonFuction.FillDatasetByProc("call procedure1q( 1," + ddlBlock.SelectedValue + ",'" + ddlSessionYear.SelectedValue + "','" + txtChalanNo.Text + "'," + Session["UserID"] + ")");
        Response.Redirect("View_DPT014.aspx?ChallanNo=" + txtChalanNo.Text + "");
    }
    protected void btnSchemeWise_Click(object sender, EventArgs e)
    {

    }
    protected void RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grBook_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "MouseEvents(this, event)");
            e.Row.Attributes.Add("onmouseout", "MouseEvents(this, event)");
        }
    }
}