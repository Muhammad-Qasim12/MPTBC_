using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
public partial class Depo_Tender_DPT002_TenderMaster : System.Web.UI.Page
{
    Vehicle003_Tender obTender = null;
    CommonFuction obCommonFuction = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadCheckListCondition();
            if (Request.QueryString["Cid"] != null)
            {
                LoadTender();
            }

        }
    }
    public void LoadCheckListCondition()
    {
        DataSet ds = new DataSet();
        obTender = new Vehicle003_Tender();
        obTender.TenderCheckListTrno = Convert.ToInt32(0);
        if (Request.QueryString["Cid"] != null)
        {
            obCommonFuction = new CommonFuction();
            ds = obCommonFuction.FillDatasetByProc("call DPT_checklistcondition(0,0," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["Cid"])) + ",0,3)");
        }
        else
        {
            obCommonFuction = new CommonFuction();
            ds = obCommonFuction.FillDatasetByProc("call depo_TenderChecklistConditionLoad(0)");
        }
        GrdCondition.DataSource = ds;
        GrdCondition.DataBind();
    }

    public void LoadTender()
    {
        DataSet ds = new DataSet();

        obTender = new Vehicle003_Tender();

        try
        {
            if (Request.QueryString["Cid"] != null)
            {
              HiddenField1.Value =(new APIProcedure().Decrypt(Request.QueryString["Cid"]));
            }else 
            {
            HiddenField1.Value ="0";
            }
            ds = obCommonFuction.FillDatasetByProc("call Depo_TenderDetailsLoad(" + HiddenField1.Value + ","+Session["UserID"].ToString ()+")");

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTenderNo_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["TenderNo_V"]);
                txtTenderDate_D.Text = Convert.ToString(ds.Tables[0].Rows[0]["TenderDate_D"]);
                txtNITDate_D.Text = Convert.ToString(ds.Tables[0].Rows[0]["NITDate_D"]);
                txtTenderDocFee_N.Text = Convert.ToString(ds.Tables[0].Rows[0]["TenderDocFee_N"]);
                txtTenderSubmissionDate_D.Text = Convert.ToString(ds.Tables[0].Rows[0]["TenderSubmissionDate_D"]);
                txtTechBidopeningDate_D.Text = Convert.ToString(ds.Tables[0].Rows[0]["TechBidopeningDate_D"]);
                txtCommecialBidOpeningdate_D.Text = Convert.ToString(ds.Tables[0].Rows[0]["CommecialBidOpeningdate_D"]);
            }
        }
        catch (Exception ex) { }
        finally { obTender = null; }
    }


    public int TenderDetailsSave()
    {
        int i = 0;

        obTender = new Vehicle003_Tender();
        obCommonFuction = new CommonFuction();
        try
        {
            if (Request.QueryString["Cid"] != null)
            {
               HiddenField2.Value = (new APIProcedure().Decrypt(Request.QueryString["Cid"]));
            }
            else { HiddenField2.Value = "0"; }


            //obTender.TenderNo_V = Convert.ToString(txtTenderNo_V.Text);
            //obTender.TenderDate_D = ;
            //obTender.NITDate_D = ;
            //obTender.TenderDocFee_N = ;
            //obTender.TenderSubmissionDate_D = ;
            //obTender.TechBidopeningDate_D =;
            //obTender.CommecialBidOpeningdate_D = ;

            //obTender.UserTrno_I = ;
            DataSet dt = obCommonFuction.FillDatasetByProc("call depo_TenderDetailsSaveUpdate(" + HiddenField2.Value + ",'" + Convert.ToString(txtTenderNo_V.Text) + "','" + Convert.ToDateTime(txtTenderDate_D.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(txtNITDate_D.Text, cult).ToString("yyyy-MM-dd") + "'," + Convert.ToDouble(txtTenderDocFee_N.Text) + ",'" + Convert.ToDateTime(txtTenderSubmissionDate_D.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(txtTechBidopeningDate_D.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(txtCommecialBidOpeningdate_D.Text, cult).ToString("yyyy-MM-dd") + "'," + Convert.ToInt32(Session["UserID"]) + ")");
            string ChkCondtion = "";
            foreach (GridViewRow gv in GrdCondition.Rows)
            {
                CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                if (chkSelect.Checked == true)
                {
                    ChkCondtion = "Ok";
                }

            }
            if (ChkCondtion == "Ok")
            {
                i = Convert.ToInt32(dt.Tables[0].Rows[0][0].ToString());
                if (i > 0)
                {
                    if (Request.QueryString["Cid"] != null)
                    {
                        i = Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["Cid"]));
                    }

                    foreach (GridViewRow gv in GrdCondition.Rows)
                    {
                        CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                        Label lblId = (Label)gv.FindControl("lblId");
                        Label lblIdSrNo = (Label)gv.FindControl("lblIdSrNo");
                        if (Request.QueryString["Cid"] != null)
                        {
                            obCommonFuction.FillDatasetByProc("call DPT_checklistcondition(" + int.Parse(lblIdSrNo.Text) + "," + int.Parse(lblId.Text) + "," + i + "," + Convert.ToByte(chkSelect.Checked) + ",2)");
                        }
                        else
                        {
                            obCommonFuction.FillDatasetByProc("call DPT_checklistcondition(0," + int.Parse(lblId.Text) + "," + i + "," + Convert.ToByte(chkSelect.Checked) + ",0)");
                        }
                    }
                }
            }
            else
            {
                i = 0;
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Check at least one Check box.');</script>");
            }

        }

        catch (Exception ex) { }

        finally { obTender = null; }
        HiddenField2.Value = "";

        return i;
    }

    protected void GrdCondition_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblCheckStatus = (Label)e.Row.FindControl("lblDisplayStatus");
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            if (Request.QueryString["Cid"] != null)
            {
                if (lblCheckStatus.Text.ToLower() == "0")
                {
                    chkSelect.Checked = false;
                }
                else
                {
                    chkSelect.Checked = true;
                }

            }
            else
            {
                //if (lblCheckStatus.Text.ToLower() == "0")
                //{
                //    chkSelect.Checked = false;
                //}
                //else
                //{
                //    chkSelect.Checked = true;
                //}

            }
        }
    }


    protected void BtnTenderSave_Click(object sender, EventArgs e)
    {
        if (TenderDetailsSave() > 0)
        {
            message("Details Saved.", "SUCCESS");

            Response.Redirect("VIEW003_TenderDetails.aspx");
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Details Saved.');</script>");
        }
        else
        {
            message("Error", "ERROR");
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Error');</script>");
        }

    }


    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("VIEW003_TenderDetails.aspx");
    }


    public void message(string mess, string messType)
    {
        messDiv.Style.Add("display", "block");
        lblMess.Text = mess;

        if (messType == "ERROR")
        {

            messDiv.CssClass = "response-msg error ui-corner-all";
        }

        else if (messType == "SUCCESS")
        {
            messDiv.CssClass = "response-msg success ui-corner-all";

        }

        else if (messType == "INFO")
        {
            messDiv.CssClass = "response-msg inf ui-corner-all";

        }

    }
}