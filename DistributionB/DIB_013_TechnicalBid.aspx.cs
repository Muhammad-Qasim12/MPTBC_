using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using MPTBCBussinessLayer.DistributionB;

public partial class Paper_TechnicalBid : System.Web.UI.Page
{
    InsuranceTenderEvaluation objTenderEvaluation = null;
    InsuranceTechnicalBid obTechnicalBid = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    string CompName = string.Empty;
     CommonFuction obCommonFuction = new CommonFuction();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            TenderDtlFill();
            VenderFill();
            loadTechnicalBid();
            LoadAllCompany();
            FillTenderDetails();
        }
    }


    public void FillTenderDetails()
    {
        objTenderEvaluation = new InsuranceTenderEvaluation();
        DataSet ds = new DataSet();

        try
        {
            if (Request.QueryString["cid"] != null)
            {
                ddlTenderType.SelectedValue = new APIProcedure().Decrypt(Convert.ToString(Request.QueryString["cid"]));

            }

            objTenderEvaluation.TenderTrId_I = ddlTenderType.SelectedValue == "" ? 0 : Convert.ToInt32(ddlTenderType.SelectedValue);

            objTenderEvaluation.StringParameter = "";
            ds = objTenderEvaluation.TenderSelect();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTenderNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["TenderNo_V"]);
                lblTenderDt.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["TenderDate_D"]).ToString("dd/MM/yyyy");
                lblTenderWork.Text = Convert.ToString(ds.Tables[0].Rows[0]["WorkName_V"]);
                lblTenderType.Text = Convert.ToString(ds.Tables[0].Rows[0]["TenderType_V"]);
                lblTenderDtl.Text = Convert.ToString(ds.Tables[0].Rows[0]["TenderDescription_V"]);
                lblEMd.Text = Convert.ToString(ds.Tables[0].Rows[0]["EMDAmount_N"]);
                lblTenderFee.Text = Convert.ToString(ds.Tables[0].Rows[0]["TenderFees_N"]);
                lblSubDt.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["TenderSubmissionDate_D"]).ToString("dd/MM/yyyy");
                lblInsuranceDateFrom_D.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["InsuranceDateFrom_D"]).ToString("dd/MM/yyyy");
                lblInsuranceDateTo_D.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["InsuranceDateTo_D"]).ToString("dd/MM/yyyy");
               // 
                txtCommDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["CommDate"]).ToString("dd/MM/yyyy");
                txtCommTime.Text = ds.Tables[0].Rows[0]["CommTime"].ToString();
                
            }
        }
        catch (Exception ex) { }
        finally { objTenderEvaluation = null; }

    }


    public void loadTechnicalBid()
    {
        obTechnicalBid = new InsuranceTechnicalBid();

        try
        {
            if (Request.QueryString["cid"] != null)
            {
                ddlTenderType.SelectedValue =new APIProcedure().Decrypt( Convert.ToString(Request.QueryString["cid"]));
                ddlTenderType.Enabled = false;
            }

            obTechnicalBid.TenderTrId_I = ddlTenderType.SelectedValue == "" ? 0 : Convert.ToInt32(ddlTenderType.SelectedValue);

            obTechnicalBid.InsCompanyID_I = ddlVenderFill.SelectedValue == "" ? 0 : Convert.ToInt32(ddlVenderFill.SelectedValue);


            grdCompany.DataSource = obTechnicalBid.LoadTechnicalBid();
            grdCompany.DataBind();
        }
        catch (Exception ex) { }
        finally { obTechnicalBid = null; }

    }


    public void LoadAllCompany()
    {

        obTechnicalBid = new InsuranceTechnicalBid();

        try
        {


            if (Request.QueryString["cid"] != null)
            {
                ddlTenderType.SelectedValue = new APIProcedure().Decrypt(Convert.ToString(Request.QueryString["cid"]));
            }

            obTechnicalBid.TenderTrId_I = ddlTenderType.SelectedValue == "" ? 0 : Convert.ToInt32(ddlTenderType.SelectedValue);

            grdCompanyAll.DataSource = obTechnicalBid.LoadTechnicalBidAllCompany();
            grdCompanyAll.DataBind();



        }

        catch (Exception ex) { }
        finally { obTechnicalBid = null; }

    }


    public void VenderFill()
    {
        objTenderEvaluation = new InsuranceTenderEvaluation();
        ddlVenderFill.DataSource = objTenderEvaluation.VenderFill();
        ddlVenderFill.DataTextField = "Company_V";
        ddlVenderFill.DataValueField = "CompanyID_I";
        ddlVenderFill.DataBind();
        ddlVenderFill.Items.Insert(0, new ListItem("Select", "0"));
    }

    public void TenderDtlFill()
    {

        objTenderEvaluation = new InsuranceTenderEvaluation();
        objTenderEvaluation.TenderTrId_I = 0;
        ddlTenderType.DataSource = objTenderEvaluation.TenderSelect();
        ddlTenderType.DataTextField = "TenderNo_V";
        ddlTenderType.DataValueField = "TenderTrId_I";
        ddlTenderType.DataBind();
        ddlTenderType.Items.Insert(0, new ListItem("Select", "0"));

    }
    protected void ddlTenderType_SelectedIndexChanged(object sender, EventArgs e) { }

    protected void ddlVenderFill_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadTechnicalBid();
    }


    protected void grdCompany_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i < grdCompany.Rows.Count; i++)
        {
            if (((HiddenField)grdCompany.Rows[i].FindControl("HDNCheckStatus")).Value == "True")
            {
                ((CheckBox)grdCompany.Rows[i].FindControl("chkCheckStatus")).Checked = true;

            }

        }
    }

    protected void grdCompanyAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i < grdCompanyAll.Rows.Count; i++)
        {
            if (((HiddenField)grdCompanyAll.Rows[i].FindControl("HDNCheckStatus")).Value == "True")
            {
                ((CheckBox)grdCompanyAll.Rows[i].FindControl("chkCheckStatus")).Checked = true;

            }

        }
    }

    protected void litCompany_V_DataBinding(object sender, EventArgs e)
    {
        Literal lt = (Literal)sender;
        lt.Text = Eval("Company_V").ToString();

        if (!string.Equals(lt.Text, CompName))
        {
            CompName = lt.Text;

        }
        else
        {
            lt.Text = string.Empty;
        }
    }


    public int SaveTechCondition()
    {

        obCommonFuction.FillDatasetByProc("Call USP_DIB012_TenderInfoUpdateCommDtTime('" + txtCommDate.Text + "','" + txtCommTime.Text + "'," + ddlTenderType.SelectedItem.Value + ")");

        obTechnicalBid = new InsuranceTechnicalBid();

        int status = 0;

        for (int i = 0; i < grdCompany.Rows.Count; i++)
        {

            int InsCompanyID_I,
                TenderTrId_I,
                Techn_TrId,
                Tender_Cond_Id,
                UserId_I
                ;
            string
                  CheckStatus;


            InsCompanyID_I = Convert.ToInt32(ddlVenderFill.SelectedValue);
            TenderTrId_I = Convert.ToInt32(ddlTenderType.SelectedValue);

            Techn_TrId = Convert.ToInt32(((HiddenField)grdCompany.Rows[i].FindControl("HDNTechn_TrId")).Value);
            Tender_Cond_Id = Convert.ToInt32(((HiddenField)grdCompany.Rows[i].FindControl("HDNTender_Cond_Id")).Value);

            CheckStatus = ((CheckBox)grdCompany.Rows[i].FindControl("chkCheckStatus")).Checked == true ? "True" : "False";

            UserId_I = Convert.ToInt32(Session["UserId"]);


            obTechnicalBid.InsCompanyID_I = InsCompanyID_I;
            obTechnicalBid.TenderTrId_I = TenderTrId_I;
            obTechnicalBid.Techn_TrId = Techn_TrId;
            obTechnicalBid.Tender_Cond_Id = Tender_Cond_Id;
            obTechnicalBid.CheckStatus = CheckStatus;
            obTechnicalBid.UserId_I = UserId_I;

            status = obTechnicalBid.SaveTechCondition();

        }
        return status;
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        DateTime DteCheck;
        string CommDate = "", CommTime = "";
        if (txtCommDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtCommDate.Text, cult);
            }
            catch { CommDate = "NoDate"; }
        }
        if (txtCommTime.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse("01/01/2015 " + txtCommTime.Text, cult);
            }
            catch { CommTime = "NoDate"; }
        }
        if (CommDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct commercial bid opening Date.');</script>");
        }
        else if (CommTime != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct commercial Time.');</script>");
        }
        else
        { 

            if (SaveTechCondition() > 0)
            {
                loadTechnicalBid();
                LoadAllCompany();
            }
        }
    }


    //public class InsuranceTechnicalBid : DBAccess
    //{
    //    int _InsCompanyID_I,
    //        _TenderTrId_I,
    //        _Techn_TrId,
    //        _Tender_Cond_Id,
    //        _UserId_I
    //        ;
    //    string
    //          _CheckStatus;

    //    public int InsCompanyID_I { get { return _InsCompanyID_I; } set { _InsCompanyID_I = value; } }
    //    public int TenderTrId_I { get { return _TenderTrId_I; } set { _TenderTrId_I = value; } }
    //    public int Techn_TrId { get { return _Techn_TrId; } set { _Techn_TrId = value; } }
    //    public int Tender_Cond_Id { get { return _Tender_Cond_Id; } set { _Tender_Cond_Id = value; } }
    //    public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }

    //    public string CheckStatus { get { return _CheckStatus; } set { _CheckStatus = value; } }

    //    public DataSet LoadTechnicalBid()
    //    {
    //        DBAccess obDBAccess = new DBAccess();

    //        DataSet ds = new DataSet();
    //        try
    //        {
    //            obDBAccess.execute("USP_DIB015_TechnicalConditionLoad", SQLType.IS_PROC);

    //            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
    //            obDBAccess.addParam("mInsCompanyID_I", InsCompanyID_I);

    //            ds = obDBAccess.records();

    //        }
    //        catch (Exception ex) { }
    //        finally { obDBAccess = null; }
    //        return ds;

    //    }

    //    public DataSet LoadTechnicalBidAllCompany()
    //    {
    //        DBAccess obDBAccess = new DBAccess();

    //        DataSet ds = new DataSet();
    //        try
    //        {
    //            obDBAccess.execute("USP_DIB015_TechnicalConditionAllComLoad", SQLType.IS_PROC);

    //            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);

    //            ds = obDBAccess.records();

    //        }
    //        catch (Exception ex) { }
    //        finally { obDBAccess = null; }
    //        return ds;

    //    }


    //    public int SaveTechCondition()
    //    {
    //        DBAccess obDBAccess = new DBAccess();

    //        int i = 0;
    //        try
    //        {
    //            obDBAccess.execute("USP_DIB015_TechnicalConditionSaveUpdate", SQLType.IS_PROC);

    //            obDBAccess.addParam("mTechn_TrId", Techn_TrId);
    //            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
    //            obDBAccess.addParam("mTender_Cond_Id", Tender_Cond_Id);
    //            obDBAccess.addParam("mUserId_I", UserId_I);
    //            obDBAccess.addParam("mInsCompanyID_I", InsCompanyID_I);
    //            obDBAccess.addParam("mCheckStatus", CheckStatus);

    //            i = obDBAccess.executeMyQuery();

    //        }
    //        catch (Exception ex) { }
    //        finally { obDBAccess = null; }
    //        return i;
    //    }
    //}


    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("TenderInsuranceInfo.aspx");
    }
}