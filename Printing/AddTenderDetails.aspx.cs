using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Printing_AddTenderDetails : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    TenderDetails obTenderDetails = null;
    CommonFuction obCommonFuction = null;
    APIProcedure objapi = new APIProcedure();
    DataSet dt = new DataSet();
    int Tid; Decimal cell1, cell2, cell3, cell4, cell5, cell6;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

            tblbookDtl.Visible = true;
            CommonFuction obCommonFuction = new CommonFuction();
            ddlAcdmicYr_V.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlAcdmicYr_V.DataValueField = "AcYear";
            ddlAcdmicYr_V.DataTextField = "AcYear";
            ddlAcdmicYr_V.DataBind();
            ddlAcdmicYr_V.SelectedValue = obCommonFuction.GetFinYear();

            // LblFyYear.Text = DdlACYear.SelectedItem.Text;
         

            //obTenderDetails = new TenderDetails();
            //obTenderDetails.AcdmicYr_V = Convert.ToString(ddlAcdmicYr_V.SelectedValue);
            //GrdGroupDetails.DataSource = obTenderDetails.FillGridGroupDetailAllSearch(0, 0, obTenderDetails.AcdmicYr_V);
            //DdlClass.SelectedValue = "1";  
            //GrdGroupDetails.DataBind();
          
                
                
                //if (GrdGroupDetails.Rows.Count > 0)
            //{
            //    tblbookDtl.Visible = true;
            //}
            //else
            //{
            //    tblbookDtl.Visible = false;
            //}
                if (Request.QueryString["ID"] != null)
                {
                    APIProcedure objapi = new APIProcedure();

                    if (Request.QueryString["ID"] == null)
                    {
                        Tid = 0;
                    }
                    else
                    { 
                     Tid = int.Parse (  objapi.Decrypt(Request.QueryString["ID"]).ToString());
                    }

                    
                   // showdata();
                    showdata(Tid.ToString() );
                   
                   // 
                }
                obTenderDetails.AcdmicYr_V = Convert.ToString(ddlAcdmicYr_V.SelectedValue);
                GrdGroupDetails.DataSource = obTenderDetails.FillGridGroupDetailAllSearch(0, 0, obTenderDetails.AcdmicYr_V);
                DdlClass.SelectedValue = "1";
                GrdGroupDetails.DataBind();
            }
            catch { }
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

            if (txtDays.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Enter Completion Days');</script>");
                valchk++;
            }

            if (valchk == 0)
            {

                if (GridCheck() >= 1)
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
                    obTenderDetails.UserID_I = Convert.ToInt32(txtDays.Text);

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
                        Response.Redirect("VIEW_TenderDetails.aspx");
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
                    Response.Redirect("VIEW_TenderDetails.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Group Select');</script>");

                }
            }
        }
        catch { }
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
            obTenderDetails.TenderId_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["ID"].ToString()));
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
            HiddenField1.Value = (objapi.Decrypt(Request.QueryString["ID"].ToString()));
            HiddenField3.Value = Convert.ToString(obDataSet.Tables[0].Rows[0]["TenDetid_I"]);
        }
        catch { }
        finally { }
    }


    protected void GrdGroupDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
     try{
         if (e.Row.RowType == DataControlRowType.DataRow)
        {

            try
            {
                cell1 += e.Row.Cells[5].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[5].Text.Replace("&nbsp;", "0").Trim());
            }
            catch { }
            try
            {
                cell2 += e.Row.Cells[6].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[6].Text.Replace("&nbsp;", "0").Trim());
            }
            catch { }
            try
            {
                cell3 += e.Row.Cells[7].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[7].Text.Replace("&nbsp;", "0").Trim());
            }
            catch { }
            try
            {
                cell4 += e.Row.Cells[8].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[8].Text.Replace("&nbsp;", "0").Trim());
            }
            catch { }
            try
            {
                cell5 += e.Row.Cells[9].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[9].Text.Replace("&nbsp;", "0").Trim());
            }
            catch { }
            obTenderDetails = new TenderDetails();
            if (Request.QueryString["ID"] != null)
            {
                obTenderDetails.TenderId_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["ID"].ToString()));
                if (Convert.ToInt32(objapi.Decrypt(Request.QueryString["ID"].ToString())) != 0)
                {
                    DataSet obDataSet = obTenderDetails.Select();
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

            }
            else
            {
                obTenderDetails.TenderId_I = 0;
            }

        }
         if (e.Row.RowType == DataControlRowType.Footer)
         {
             Label FToNo_I0 = (Label)e.Row.FindControl("FToNo_I0");
             Label lblFLoojBook = (Label)e.Row.FindControl("lblFLoojBook");
             e.Row.Style.Add("background", "#f1f1f1");
             e.Row.Cells[0].Text = "Total";
             e.Row.Cells[5].Text = cell1.ToString();
             e.Row.Cells[6].Text = cell2.ToString();
             e.Row.Cells[7].Text = cell3.ToString();
             e.Row.Cells[8].Text = cell4.ToString();
             e.Row.Cells[9].Text = cell5.ToString();
             //e.Row.Cells[4].Text = total_kulbook.ToString();
             //e.Row.Cells[5].Text = total_Total.ToString();
             //e.Row.Cells[6].Text = total_TotalBookpaik.ToString();
             ////e.Row.Cells[7].Text = total_BundleNo_IMin.ToString();
             ////e.Row.Cells[8].Text = total_BundleNo_Imax.ToString();
             ////e.Row.Cells[9].Text = total_FromNo_I.ToString();
             ////e.Row.Cells[10].Text = total_ToNo_I.ToString();
             //lblFLoojBook.Text = total_LoojBook.ToString();
             //FToNo_I0.Text = total_PerBundleas.ToString();
         }
    }
        catch { }
        finally { }
    }
    protected void ddlAcdmicYr_V_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            obTenderDetails = new TenderDetails();
            obTenderDetails.AcdmicYr_V = Convert.ToString(ddlAcdmicYr_V.SelectedValue);
            //GrdGroupDetails.DataSource = obTenderDetails.FillGridGroupDetail();
            int clid = Convert.ToInt32(DdlClass.SelectedValue.ToString());
            GrdGroupDetails.DataSource = obTenderDetails.FillGridGroupDetailAllSearch(0, clid, obTenderDetails.AcdmicYr_V);
            //     FillGridGroupDetailAllSearch(0, 1, obTenderDetails.AcdmicYr_V);
            //DdlClass.SelectedValue = "1";
            GrdGroupDetails.DataBind();
            //if (GrdGroupDetails.Rows.Count > 0)
            //{
            //    tblbookDtl.Visible = true;
            //}
            //else
            //{
            //    tblbookDtl.Visible = false;
            //}
        }
        catch { }
        finally { }
    }
    protected void DdlMedium_Init(object sender, EventArgs e)
    {
        try
        {
            //ddlMedium.DataSource = comm.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            //ddlMedium.DataValueField = "MediumTrno_I";
            //ddlMedium.DataTextField = "MediunNameHindi_V";
            //ddlMedium.DataBind();
            //ddlMedium.Items.Insert(0, new ListItem("Select..", "0"));
            obCommonFuction = new CommonFuction();
            DdlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)");
            DdlMedium.DataValueField = "MediumTrno_I";
            DdlMedium.DataTextField = "MediunNameHindi_V";
            DdlMedium.DataBind();
            DdlMedium.Items.Insert(0, "Select");
        }
        catch { }
    }
    protected void DdlClass_Init(object sender, EventArgs e)
    {
        try
        {
            obCommonFuction = new CommonFuction();
            DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            DdlClass.DataValueField = "ClassTrno_I";
            DdlClass.DataTextField = "Classdet_V";
            DdlClass.DataBind();
            DdlClass.Items.Insert(0, "Select");
        }
        catch { }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadDataAgainstGrd();
    }
    public void LoadDataAgainstGrd()
    {
         
        if (DdlMedium.SelectedItem.Text == "Select" && DdlClass.SelectedItem.Text == "Select")
        {
            obTenderDetails = new TenderDetails();
            obTenderDetails.AcdmicYr_V = Convert.ToString(ddlAcdmicYr_V.SelectedValue);
           if  (ddlTenderType_V.SelectedValue=="Web Offset") 
            obTenderDetails.TenderId_I = 1;
            else
            obTenderDetails.TenderId_I = 2;
            

            GrdGroupDetails.DataSource = obTenderDetails.FillGridGroupDetail();
            GrdGroupDetails.DataBind();        
        }
      
        else
        {
            TenderDetails obGroup = new TenderDetails();
            int Mdu = 0, Class = 0;
            if (DdlMedium.SelectedItem.Text == "Select")
            {
                Mdu = 0;
            }
            else
            {
                Mdu = int.Parse(DdlMedium.SelectedItem.Value);
            }

            if (DdlClass.SelectedItem.Text == "Select")
            {
                Class = 0;
            }
            else
            {
                Class = int.Parse(DdlClass.SelectedItem.Value);
            }
            try
            {
                int  TenderType=0;

                if (ddlTenderType_V.SelectedValue == "Web Offset")
                { TenderType = 1;
                }

                else { 
                TenderType=2;
                }
                //obDBAccess.addParam("acyear", acyear);
               // obDBAccess.addParam("mtenderid_i", TenderId_I);
               // obDBAccess.addParam("mmedium_i", mmedium_i);
               // obDBAccess.addParam("mclasstrno_i", classtrno_i);
                //    obTenderDetails.TenderId_I = 2;
                //}
                CommonFuction COMM = new CommonFuction();

                GrdGroupDetails.DataSource = COMM.FillDatasetByProc("call USP_PRI010_TenderGroupGridfillSearch(0,'" + ddlAcdmicYr_V.SelectedItem.Text + "'," + TenderType + "," + Mdu + "," + Class + ")");//obGroup.FillGridGroupDetailAllSearch(Mdu, Class, );
                GrdGroupDetails.DataBind();
            }
            catch (Exception ex) { }
            finally { obGroup = null; }
        }
    }
    protected void CheckBox12_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < GrdGroupDetails.Rows.Count; i++)
        {

            if (((CheckBox)GrdGroupDetails.HeaderRow.FindControl("CheckBox12")).Checked == true)
            {
                ((CheckBox)GrdGroupDetails.Rows[i].FindControl("chkGroup")).Checked = true;
                //chkGroup
            }
            else
            {
                ((CheckBox)GrdGroupDetails.Rows[i].FindControl("chkGroup")).Checked = false;
            }
        }
    }
    protected void GrdGroupDetails_DataBound(object sender, EventArgs e)
    {
      
    }
}