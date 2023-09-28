using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;
public partial class Depo_DPT003_TransportDetails : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    TransportDetails obTransportDetails = null;
    TransportMaster obTransportMaster = null;
    CommonFuction obCommonFuction = null;
    DPT_DepotMaster obDPT_DepotMaster = new DPT_DepotMaster();
    APIProcedure api = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                obDPT_DepotMaster.DepoTrno_I = 0;
                DataSet depo = obDPT_DepotMaster.Select();
            
                obTransportMaster = new TransportMaster();
                obTransportMaster.UserID_I =Convert.ToInt32(Session["UserID"]);
                DataSet obDataSet1 = obTransportMaster.Select();
                ddlTrnasportName.DataTextField = "TransportName_V";
                ddlTrnasportName.DataValueField = "TransportID_I";
                ddlTrnasportName.DataSource = obDataSet1.Tables[0];
                ddlTrnasportName.DataBind();
                ddlTrnasportName.Items.Insert(0, "सेलेक्ट..");

             
                obTransportDetails = new TransportDetails();
                obTransportDetails.UserID_I = Convert.ToInt32(Session["UserID"]);
                obTransportDetails.TransportID_I = 0;
                 DataSet dsdist = obTransportDetails.DistAndBolck();
                ddlDistrict.DataTextField = "District_Name_Hindi_V";
                ddlDistrict.DataValueField = "DistrictTrno_I";
                ddlDistrict.DataSource = dsdist.Tables[0];
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, "Select..");
                obCommonFuction = new CommonFuction();
                ddlFyYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
                ddlFyYear.DataValueField = "AcYear";
                ddlFyYear.DataTextField = "AcYear";
                ddlFyYear.DataBind();
                ddlFyYear.SelectedValue = obCommonFuction.GetFinYear();


                if (Request.QueryString["ID"] != null)
                {
                    showdata(Request.QueryString[ID]);
                }

            }
            catch { }
            finally { obTransportDetails = null; }
        }

    }
    public string GetFinYear()
    {
        int CurrentYear = DateTime.Today.Year;
        string PreviousYear = (CurrentYear - 1).ToString();
        string NextYear = (CurrentYear + 1).ToString();
        string finYear = "";
        if (DateTime.Today.Month > 3)
            finYear = CurrentYear.ToString() + "-" + NextYear;
        else
            finYear = PreviousYear + "-" + CurrentYear.ToString();

        return finYear;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {


        foreach (GridViewRow grdrow in GrdTranportRate.Rows)
        {
            if (((CheckBox)grdrow.FindControl("chk")).Checked)
            {
                try
                {
                    obTransportDetails = new TransportDetails();
                    HiddenField hdnDepoTrn = (HiddenField)grdrow.FindControl("hdnDepoTrn");
                    HiddenField hdnHeadId = (HiddenField)grdrow.FindControl("hdnHeadId");
                    HiddenField hdnHeadId2 = (HiddenField)grdrow.FindControl("hdMain");
                    obTransportDetails.TransportID_I = Convert.ToInt32(ddlTrnasportName.SelectedValue);
                    if (Request.QueryString["ID"] != null)
                    {
                        obTransportDetails.TransportDetailsID_I = Convert.ToInt32(Request.QueryString["ID"]);
                    }
                    obTransportDetails.BlockID_I = 0;

                    obTransportDetails.FullTruckRate_N = Convert.ToDouble(((TextBox)grdrow.FindControl("txtEstimateAmount")).Text);
                    obTransportDetails.HalfTruckRate_N = Convert.ToDouble(((TextBox)grdrow.FindControl("txtAvailableAmount")).Text);
                    obTransportDetails.RatePerBundle_N = Convert.ToDouble(((TextBox)grdrow.FindControl("txtrequestAmount")).Text);
                    //DistrictID,DepoID,DistType
                    if (ddlDistrict.SelectedItem.Text.Trim() != "Select.." && ddlDistrict.SelectedItem.Text.Trim() != "सेलेक्ट..")
                    {
                        obTransportDetails.DistrictID = Convert.ToString(ddlDistrict.SelectedValue);
                    }

                    if (hdnDepoTrn.Value != "")
                    {
                        obTransportDetails.DepoID = Convert.ToString(hdnDepoTrn.Value);
                    }
                    else
                    {
                        obTransportDetails.DepoID = "0";
                    }
                    obTransportDetails.DistType = Convert.ToString(RadioButtonList1.SelectedValue);
                    obTransportDetails.TransID_I = 0;
                    if (hdnHeadId.Value != "")
                    {
                        obTransportDetails.TransID_I = 1;
                        obTransportDetails.TransportDetailsID_I = Convert.ToInt32(hdnHeadId.Value);
                    }
                    obTransportDetails.FyID = Convert.ToString(ddlFyYear.SelectedValue);
                    if (hdnHeadId2.Value == "")
                    {
                        hdnHeadId2.Value = "0";
                    }
                    obTransportDetails.depotypea = Convert.ToInt16(hdnHeadId2.Value);
                    obTransportDetails.InsertUpdate();
                   // obCommonFuction = new CommonFuction();
                   // obCommonFuction.EmptyTextBoxes(this);
                }
                catch { }
                finally
                {
                    obTransportDetails = null;
                }
            }


            
        }
        foreach (GridViewRow grdrow in grdblock.Rows)
        {
            if (((CheckBox)grdrow.FindControl("chk")).Checked)
            {
                try
                {
                    obTransportDetails = new TransportDetails();
                    HiddenField hdnDepoTrn = (HiddenField)grdrow.FindControl("hdnblockTrn");
                    HiddenField hdnHeadId = (HiddenField)grdrow.FindControl("hdnHeadId");
                    obTransportDetails.TransportID_I = Convert.ToInt32(ddlTrnasportName.SelectedValue);
                    try
                    {
                        obTransportDetails.BlockID_I = Convert.ToInt32(hdnDepoTrn.Value);
                    }
                    catch { }

                    obTransportDetails.FullTruckRate_N = Convert.ToDouble(((TextBox)grdrow.FindControl("txtEstimateAmount")).Text);
                    obTransportDetails.HalfTruckRate_N = Convert.ToDouble(((TextBox)grdrow.FindControl("txtAvailableAmount")).Text);
                    obTransportDetails.RatePerBundle_N = Convert.ToDouble(((TextBox)grdrow.FindControl("txtrequestAmount")).Text);
                    //DistrictID,DepoID,DistType
                    if (ddlDistrict.SelectedItem.Text.Trim() != "Select.." && ddlDistrict.SelectedItem.Text.Trim() != "सेलेक्ट..")
                    {
                        obTransportDetails.DistrictID = Convert.ToString(ddlDistrict.SelectedValue);
                    }

                    obTransportDetails.DepoID = "0";
                    
                    obTransportDetails.DistType = Convert.ToString(RadioButtonList1.SelectedValue);
                    obTransportDetails.TransID_I = 0;
                    if (hdnHeadId.Value != "")
                    {
                        obTransportDetails.TransID_I = 1;
                        obTransportDetails.TransportDetailsID_I = Convert.ToInt32(hdnHeadId.Value);
                    }
                    obTransportDetails.FyID = Convert.ToString(ddlFyYear.SelectedValue);
                    obTransportDetails.InsertUpdate();
                  //  obCommonFuction = new CommonFuction();
                   // obCommonFuction.EmptyTextBoxes(this);
                }
                catch { }
                finally
                {
                    obTransportDetails = null;
                }
            }


            
        }
        Response.Redirect("VIEW_DPT003.aspx");
    }
    public void showdata(string ID)
    {
        obTransportDetails = new TransportDetails();
        obTransportDetails.TransportDetailsID_I = Convert.ToInt32(api.Decrypt(Request.QueryString["ID"].ToString ()));
        DataSet obDataSet = obTransportDetails.Select();
        grdblock.DataSource = obDataSet;
        grdblock.DataBind();
        foreach (GridViewRow grdrow in grdblock.Rows)
        {
            try
            {
              ((CheckBox)grdrow.FindControl("chk")).Checked=true;
              ((CheckBox)grdrow.FindControl("chk")).Enabled = false;
                
            }
            catch { }
        }

        HiddenField1.Value = ( api.Decrypt(Request.QueryString["ID"].ToString ()));
        ddlFyYear.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["FyID"]);
        ddlTrnasportName.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["TransportID_I"]);
      //  ddlBlock.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["BlockID_I"]);
      //  ddlTrnasportName.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["RegistrationNo_V"]);
       // txtFullTrck.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["FullTruckRate_N"]);
      //  txthulfTruck.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["HalfTruckRate_N"]);
     //   txtPratibandal.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["RatePerBundle_N"]);
        RadioButtonList1.SelectedValue =Convert.ToString( obDataSet.Tables[0].Rows[0]["DistType"]);
        ddlFyYear.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["DistType"]);
        if ((obDataSet.Tables[0].Rows[0]["DistType"]).ToString () == "2")
        {
            ddlDistrict.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["DistrictID"]);
            obTransportDetails = new TransportDetails();
            obTransportDetails.UserID_I = Convert.ToInt32(ddlDistrict.SelectedValue);
            obTransportDetails.TransportID_I = 001;
            DataSet bds = obTransportDetails.DistAndBolck();
            //ddlBlock.DataTextField = "BlockNameHindi_V";
            //ddlBlock.DataValueField = "BlockTrno_I";
            //ddlBlock.DataSource = bds.Tables[0];
            //ddlBlock.DataBind();
            //ddlBlock.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["BlockID_I"]);
           // B.Visible = true;
            D.Visible = true;
        }
        else
        {
           // ddldepo.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["DepoID"]);

          //  Depo.Visible = true;
        }

         
    }
    protected void ddlBlock0_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //obTransportDetails = new TransportDetails();
            //obTransportDetails.UserID_I = Convert.ToInt32(ddlDistrict.SelectedValue);
            //obTransportDetails.TransportDetailsID_I = -2;
            //obTransportDetails.FyID = ddlFyYear.SelectedValue;
            //obTransportDetails.TransportID_I = Convert.ToInt32(ddlTrnasportName.SelectedValue);
            //DataSet dt = obTransportDetails.Select();
            CommonFuction obj = new CommonFuction();
            DataSet dt = obj.FillDatasetByProc("call USP_DPT003_TransportDetails_Load(-2," + ddlDistrict.SelectedValue + "," + ddlTrnasportName.SelectedValue + ",'" + ddlFyYear.SelectedValue + "')");
            grdblock.DataSource = dt;
            grdblock.DataBind();
        }
        catch
        { }

        //obTransportDetails = new TransportDetails();
        //obTransportDetails.UserID_I =Convert.ToInt32(ddlDistrict.SelectedValue);
        //obTransportDetails.TransportID_I = 001;
        //DataSet bds = obTransportDetails.DistAndBolck();
        //ddlBlock.DataTextField = "BlockNameHindi_V";
        //ddlBlock.DataValueField = "BlockTrno_I";
        //ddlBlock.DataSource = bds.Tables[0];
        //ddlBlock.DataBind();
        //ddlBlock.Items.Insert(0, "सेलेक्ट..");
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (RadioButtonList1.SelectedValue == "1")
            {
                obTransportDetails = new TransportDetails();
                obTransportDetails.UserID_I = Convert.ToInt32(Session["UserID"]);
                obTransportDetails.FyID = ddlFyYear.SelectedValue;
                obTransportDetails.TransportID_I = Convert.ToInt32(ddlTrnasportName.SelectedValue);
                obTransportDetails.TransportDetailsID_I = -1;
                DataSet dt = obTransportDetails.Select();



                GrdTranportRate.DataSource = dt;
                GrdTranportRate.DataBind();
                grdblock.DataSource = null;
                grdblock.DataBind();

                // Depo.Visible = true;
                // B.Visible = false;
                D.Visible = false;
                ddlDistrict.SelectedIndex = 0;
                //   ddlBlock.SelectedIndex = 0;
            }
            else
            {


                GrdTranportRate.DataSource = null;
                GrdTranportRate.DataBind();
                //  Depo.Visible = false;
                //B.Visible = true ;
                D.Visible = true;
            }
        }catch{}
    }
    protected void GrdAdvance_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (Request.QueryString["ID"] != null)
            {
                TextBox txtEstimateAmount = (TextBox)e.Row.FindControl("txtEstimateAmount");
                TextBox txtAvailableAmount = (TextBox)e.Row.FindControl("txtAvailableAmount");
                TextBox txtrequestAmount = (TextBox)e.Row.FindControl("txtrequestAmount");
                DataTable dt = (DataTable)ViewState["dt"];
                txtEstimateAmount.Text = Convert.ToString(dt.Rows[0]["EstimateCost"]);
                txtAvailableAmount.Text = Convert.ToString(dt.Rows[0]["AvailableCost"]);
                txtrequestAmount.Text = Convert.ToString(dt.Rows[0]["Amount"]);
                ((CheckBox)e.Row.FindControl("chk")).Checked = true;
                ((CheckBox)e.Row.FindControl("chk")).Enabled = false;

            }
        }
        catch { }

    }
}