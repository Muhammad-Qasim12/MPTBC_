using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.AcademicB;
using System.Data;
using System.Globalization;

public partial class AcademicB_TenderDetailsB : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    TenderDetails obTenderDetails = null;
    CommonFuction obCommonFuction = null;

    DataSet dt = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFuction obCommonFuction = new CommonFuction();
            ddlAcdmicYr_V.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlAcdmicYr_V.DataValueField = "AcYear";
            ddlAcdmicYr_V.DataTextField = "AcYear";
            ddlAcdmicYr_V.DataBind();
            // ddlAcdmicYr_V.SelectedValue = obCommonFuction.GetFinYear();

            // LblFyYear.Text = DdlACYear.SelectedItem.Text;


            obTenderDetails = new TenderDetails();
            obTenderDetails.AcdmicYr_V = Convert.ToString(ddlAcdmicYr_V.SelectedValue);
            try
            {
                obTenderDetails.TenderId_I = 0;
                //int.Parse(new APIProcedure().Decrypt(Request.QueryString["ID"]));
                obTenderDetails.ID = 1;
            }
            catch
            {
                obTenderDetails.ID = 0;
            }
            try
            {
                GrdGroupDetails.DataSource = obTenderDetails.FillGridGroupDetail();
                GrdGroupDetails.DataBind();
            }
            catch { }

            try
            {
                if (Request.QueryString["ID"] != null)
                {
                    showdata(new APIProcedure().Decrypt(Request.QueryString["ID"]));
                }

            }
            catch (Exception ex)
            { }
            finally { obTenderDetails = null; }
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Session["TenderId_I"] = 0;
        try
        {

            int valchk = 0;
            DateTime dt1, dt2;

            dt1 = dateConversion(txtLUNDate_D.Text);
            dt2 = dateConversion(txtTenderDate_D.Text);
            if (dt1 < dt2)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('LUN भेजने की दिनाक टेंडर दिनाक से बाद की नहीं है');</script>");
                valchk++;
            }

            dt1 = dateConversion(txtNITDate_D.Text);

            if (dt1 < dt2)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('NIT की दिनाक टेंडर दिनाक से बाद की नहीं है');</script>");
                valchk++;
            }

            dt2 = dateConversion(txtTenderSubmissionDate_D.Text);

            if (dt2 < dt1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('टेंडर जमा करने की दिनाक NIT की दिनाक  से बाद की नहीं है');</script>");
                valchk++;
            }

            dt1 = dateConversion(txtTechBidopeningDate_D.Text);

            if (dt1 < dt2)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Technical Bid  खोलने की दिनाक टेंडर जमा करने की दिनाक से बाद की नहीं है');</script>");
                valchk++;
            }

            dt1 = dateConversion(txtCommecialBidOpeningdate_D.Text);
            if (dt1 < dt2)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Financial Bid  खोलने की दिनाक टेंडर जमा करने की दिनाक से बाद की नहीं है');</script>");
                valchk++;
            }


            if (valchk == 0)
            {




                if (GridCheck() > 0)
                {


                    obTenderDetails = new TenderDetails();
                    obTenderDetails.AcdmicYr_V = Convert.ToString(ddlAcdmicYr_V.SelectedValue);
                    obTenderDetails.TenderType_V = Convert.ToString(ddlTenderType_V.SelectedValue);
                    obTenderDetails.TenderNo_V = Convert.ToString(txtTenderNo_V.Text.Trim());
                    obTenderDetails.TenderDate_D = Convert.ToDateTime(txtTenderDate_D.Text, cult);
                    obTenderDetails.LUNSendNo_V = Convert.ToString(txtLUNSendNo_V.Text.Trim());
                    obTenderDetails.LUNDate_D = Convert.ToDateTime(txtLUNDate_D.Text, cult);
                    obTenderDetails.NITDate_D = Convert.ToDateTime(txtNITDate_D.Text, cult);
                    obTenderDetails.TenderDocFee_N = Convert.ToDecimal(txtTenderDocFee_N.Text);
                    obTenderDetails.TenderSubmissionDate_D = Convert.ToDateTime(txtTenderSubmissionDate_D.Text, cult);
                    obTenderDetails.TechBidopeningDate_D = Convert.ToDateTime(txtTechBidopeningDate_D.Text, cult);
                    obTenderDetails.CommecialBidOpeningdate_D = Convert.ToDateTime(txtCommecialBidOpeningdate_D.Text, cult);
                    obTenderDetails.Transdate_D = Convert.ToDateTime(System.DateTime.Now, cult);
                    obTenderDetails.UserID_I = Convert.ToInt32(Session["UserID_I"]);

                    obTenderDetails.TenderId_I = 0;
                    if (HiddenField1.Value != "")
                    {
                        obTenderDetails.TenderId_I = 1;
                        obTenderDetails.TenderId_I = Convert.ToInt32(HiddenField1.Value);
                    }
                    int LID = obTenderDetails.InsertUpdate();

                    if (HiddenField3.Value == "")
                    {
                        int i = 0;
                        foreach (GridViewRow gv in GrdGroupDetails.Rows)
                        {
                            CheckBox chk = (CheckBox)gv.FindControl("chkGroup");
                            Label lblGroupNO_V = (Label)gv.FindControl("lblGroupNO_V");
                            int hd2 = Convert.ToInt32(((HiddenField)gv.FindControl("HiddenField2")).Value);
                            if (chk.Checked == true)
                            {

                                obTenderDetails.TenDetid_I = i;
                                i++;
                                obTenderDetails.TenderId_I = LID;
                                obTenderDetails.GrpID_I = hd2;
                                obTenderDetails.InsertGroup();
                            }
                        }
                    }
                    else if (HiddenField3.Value != "")
                    {
                        int i = 0;
                        foreach (GridViewRow gv in GrdGroupDetails.Rows)
                        {
                            CheckBox chk = (CheckBox)gv.FindControl("chkGroup");
                            Label lblGroupNO_V = (Label)gv.FindControl("lblGroupNO_V");
                            int hd2 = Convert.ToInt32(((HiddenField)gv.FindControl("HiddenField2")).Value);
                            if (chk.Checked == true)
                            {

                                obTenderDetails.TenDetid_I = i;
                                i++;
                                obTenderDetails.TenderId_I = LID;
                                obTenderDetails.GrpID_I = hd2;
                                obTenderDetails.InsertGroup();
                            }
                        }

                    }
                    obCommonFuction = new CommonFuction();
                    obCommonFuction.EmptyTextBoxes(this);
                    HiddenField1.Value = "";
                    Response.Redirect("View_ACB_004.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Group Select');</script>");

                }
            }
        }
        catch (Exception ex) { }
        finally
        {
            obTenderDetails = null;

        }


    }

    public int GridCheck()
    {
        int i = 0;
        foreach (GridViewRow gv in GrdGroupDetails.Rows)
        {
            CheckBox chk = (CheckBox)gv.FindControl("chkGroup");
            if (chk.Checked == true)
            {
                i++;
            }
        }
        return i;
    }
    public DateTime dateConversion(string txtValue)
    {
        DateTime dt;
        if (txtValue == "")
        {
            return Convert.ToDateTime("01/01/1900");
        }
        else
        {
            return DateTime.ParseExact(txtValue, "dd/MM/yyyy", null);
        }

    }
    public void showdata(string ID)
    {
        try
        {
            obTenderDetails = new TenderDetails();
            obTenderDetails.TenderId_I = int.Parse(new APIProcedure().Decrypt(Request.QueryString["ID"]));
            //Convert.ToInt32(Request.QueryString["ID"]);
            DataSet obDataSet = obTenderDetails.Select();

            ddlAcdmicYr_V.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["AcdmicYr_V"]);
            ddlTenderType_V.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["TenderType_V"]);
            txtTenderNo_V.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TenderNo_V"]);
            txtTenderDate_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["TenderDate_D"]).ToString("dd/MM/yyyy");
            txtLUNSendNo_V.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["LUNSendNo_V"]);
            txtLUNDate_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["LUNDate_D"]).ToString("dd/MM/yyyy");
            txtNITDate_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["NITDate_D"]).ToString("dd/MM/yyyy");
            txtTenderDocFee_N.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TenderDocFee_N"]);
            txtTenderSubmissionDate_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["TenderSubmissionDate_D"]).ToString("dd/MM/yyyy");
            txtTechBidopeningDate_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["TechBidopeningDate_D"]).ToString("dd/MM/yyyy");
            txtCommecialBidOpeningdate_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["CommecialBidOpeningdate_D"]).ToString("dd/MM/yyyy");
            obTenderDetails.TenderId_I = 1;
            HiddenField1.Value = new APIProcedure().Decrypt(Request.QueryString["ID"]);
            HiddenField3.Value = Convert.ToString(obDataSet.Tables[0].Rows[0]["TenDetid_I"]);

        }
        catch (Exception ex)
        {
        }
    }
    protected void GrdGroupDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        obTenderDetails = new TenderDetails();
        if (Request.QueryString["ID"] != null)
        {
            obTenderDetails.TenderId_I = int.Parse(new APIProcedure().Decrypt(Request.QueryString["ID"]));
        }
        DataSet obDataSet = obTenderDetails.Select();

        //if (int.Parse(new APIProcedure().Decrypt(Request.QueryString["ID"]))  != 0)
        //{
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkGroup = (CheckBox)e.Row.FindControl("chkGroup");
            Label lblGroupNO_V = (Label)e.Row.FindControl("lblGroupNO_V");
            int hd = Convert.ToInt32(((HiddenField)e.Row.FindControl("HiddenField2")).Value);
            for (int i = 0; i < obDataSet.Tables[0].Rows.Count; i++)
            {

                if (hd == Convert.ToInt32(obDataSet.Tables[0].Rows[i]["GrpID_I"]))
                {
                    chkGroup.Checked = true;
                }
            }
        }
        //}

    }
}