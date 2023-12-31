using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI;
using System.Globalization;
using System.Linq;
using System.Collections;

public partial class DistributionB_DemandfromOthers : System.Web.UI.Page
{
    Table tblBlockwise = null;
    string path, mapFile;
    DemandfromOthers obDemandfromOthers = new DemandfromOthers();
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        mainDiv.CssClass = "form-message error";
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = "";

        if (!IsPostBack)
        {
            DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS001_DemandTypeMasterLoad(0)");
            DDlDemandType.DataValueField = "DemandTypeId";
            DDlDemandType.DataTextField = "DemandTypeHindi";
            DDlDemandType.DataBind();
            FillCombo();

            CommonFuction comm = new CommonFuction();
            DataSet ds = comm.FillDatasetByProc("SELECT  id , ORGName  FROM dib_otherorganisation ");
            ddlOtherORG.DataSource = ds.Tables[0];
            ddlOtherORG.DataTextField = "ORGName";
            ddlOtherORG.DataValueField = "id";
            ddlOtherORG.DataBind();
            ddlOtherORG.Items.Insert(0, "सलेक्ट करे");

            if (Request.QueryString["ID"] == null)
            {
                hdnDenmandID.Value = "0";
                btnFinailise.Visible = false;
            }
            else
            {
                int DemandId = 0;
                int.TryParse(new APIProcedure().Decrypt(Request.QueryString["ID"].ToString()), out DemandId).ToString();
                if (DemandId > 0)
                {
                    obDemandfromOthers.QueryType = -15;
                    obDemandfromOthers.ParameterValue = DemandId;
                    if (obDemandfromOthers.Select().Tables[0].Rows.Count > 0)
                    {
                        btnFinailise.Visible = false;
                        btnSave.Visible = false;

                        mainDiv.CssClass = "form-message error";
                        mainDiv.Style.Add("display", "block");
                        lblmsg.Text = "Cant't modify finalized data";
                    }
                    else
                    {
                        btnFinailise.Visible = true;
                    }
                }
                hdnDenmandID.Value = DemandId.ToString();
                fillDataValues(DemandId);
            }
        }
    }
    private void fillDataValues(int DemandId)
    {
        obDemandfromOthers.QueryType = -12;
        obDemandfromOthers.ParameterValue = DemandId;
        DataSet dsOtherDemand = obDemandfromOthers.Select();

        if (dsOtherDemand.Tables[0] != null && dsOtherDemand.Tables[0].Rows.Count > 0)
        {
            txtLetterNo.Text = dsOtherDemand.Tables[0].Rows[0]["LetterNo_V"].ToString();
            txtLetterDate.Text = DateTime.Parse(dsOtherDemand.Tables[0].Rows[0]["LetterDate_D"].ToString()).ToString("dd/MM/yyyy");
            ddlDemandFrom.Text = dsOtherDemand.Tables[0].Rows[0]["DepTrno_I"].ToString();
            ddlAcademicYr.SelectedValue = dsOtherDemand.Tables[0].Rows[0]["AcYrID_I"].ToString();
            FillFinancialYear();
            txtRefLetterNo.Text = dsOtherDemand.Tables[0].Rows[0]["RefLetterNo_V"].ToString();
            try
            {
                txtRefLetterDate.Text = DateTime.Parse(dsOtherDemand.Tables[0].Rows[0]["RefLetterDate_D"].ToString()).ToString("dd/MM/yyyy");
            }
            catch
            {
                txtRefLetterDate.Text = "";
            }
            ddlTitle.SelectedValue = dsOtherDemand.Tables[0].Rows[0]["TitleID_I"].ToString();
            rdlOfficeName.SelectedValue = dsOtherDemand.Tables[0].Rows[0]["DemandFrom_I"].ToString();
            TxtOtherAgency.Text = dsOtherDemand.Tables[0].Rows[0]["OtherAgencyName_V"].ToString();

            if (dsOtherDemand.Tables[0].Rows[0]["OtherAgencyName_V"].ToString() != "")
                ChkOtherAgency.Checked = true;

            OfficeSelectionChange();
        }
    }
    private void FillCombo()
    {
        obDemandfromOthers.QueryType = 0;
        obDemandfromOthers.ParameterValue = 0;
        ddlDemandFrom.DataSource = obDemandfromOthers.Select();
        ddlDemandFrom.DataTextField = "DepartmentName_V";
        ddlDemandFrom.DataValueField = "DepartmentID_I";
        ddlDemandFrom.DataBind();

        obDemandfromOthers.QueryType = -1;
        ddlAcademicYr.DataSource = obDemandfromOthers.Select();
        ddlAcademicYr.DataTextField = "AcYear";
        ddlAcademicYr.DataValueField = "Id";
        ddlAcademicYr.DataBind();
        FillFinancialYear();

        obDemandfromOthers.QueryType = -3;
        ddlTitle.DataSource = obDemandfromOthers.Select();
        ddlTitle.DataTextField = "TitleHindi_V";
        ddlTitle.DataValueField = "TitleID_I";
        ddlTitle.DataBind();

        obDemandfromOthers.QueryType = -8;
        ddlDistrict.DataSource = obDemandfromOthers.Select();
        ddlDistrict.DataTextField = "DepoName_V";
        ddlDistrict.DataValueField = "DepoTrno_I";
        ddlDistrict.DataBind();
        ListItem lstSelect = new ListItem("Select", "0");
        ddlDistrict.Items.Insert(0, lstSelect);

        //obDemandfromOthers.QueryType = -8;
        //ddlSearchDepo.DataSource = obDemandfromOthers.Select();
        //ddlSearchDepo.DataTextField = "DepoName_V";
        //ddlSearchDepo.DataValueField = "DepoTrno_I";
        //ddlSearchDepo.DataBind();

    }
    protected void ddlAcademicYr_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        FillFinancialYear();
    }
    private void FillFinancialYear()
    {
        obDemandfromOthers.QueryType = -2;
        obDemandfromOthers.ParameterValue = int.Parse(ddlAcademicYr.SelectedValue);
        DataSet dsFinancal = obDemandfromOthers.Select();
        if (dsFinancal.Tables[0].Rows.Count > 0)
        {
            lblFinancialYr.Text = dsFinancal.Tables[0].Rows[0]["FyYear"].ToString();
        }
        else
        {
            lblFinancialYr.Text = "";
        }
    }
    private DataTable InsertInDT(DataTable dt, string District, string DistrictID, string Block, string BlockID, string Title, string SubTitleID, string Supply
        , string OtherDeptName, string OtherDeptId)
    {
        DataRow drNew = dt.NewRow();
        drNew["District"] = District;
        drNew["DistrictID"] = DistrictID;
        drNew["Block"] = Block;
        drNew["BlockID"] = BlockID;
        drNew["Title"] = Title;
        drNew["SubTitleID"] = SubTitleID;
        drNew["Supply"] = Supply;
        drNew["OtherDeptName"] = OtherDeptName;
        drNew["OtherDeptId"] = OtherDeptId;
        try
        {
            dt.Rows.Add(drNew);
            dt.AcceptChanges();
        }
        catch
        {

            mainDiv.Style.Add("display", "block");
            lblmsg.Text += "Duplicate entry for " + District + "-" + Block + "-" + Title;
        }


        return dt;
    }
    private void FillSelectedBlockGrid()
    {
        string strcallbyd = "CALL USP_GEN_GetBlockByDistrict('" + ddlDistrictM.SelectedValue + "')";
        CommonFuction obCommonFuction = new CommonFuction();
        DataSet ds = obCommonFuction.FillDatasetByProc(strcallbyd);
        DataSet obDataset = obCommonFuction.FillDatasetByProc("Call USP_GEN_GetOtherThenTextBookTitle('" + ddlTitle.SelectedValue + "')");
        ViewState["obDataset"] = obDataset;

        gridDetails.DataSource = ds;
        gridDetails.RepeatColumns = ds.Tables[0].Rows.Count;
        gridDetails.DataBind();
        hideFiresrTitle();
    }
    protected void gridDetails_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            try
            {
                CommonFuction obCommonFuction = new CommonFuction();
                hdnblockid.Value = ((HiddenField)e.Item.FindControl("hdnkey")).Value;
                GridView grdTitlegrid = (GridView)e.Item.FindControl("grdTitlegrid");

                DataSet obDataset = (DataSet)ViewState["obDataset"];
                CommonFuction obCommonF = new CommonFuction();
                string getStock = "call USP_DIS018_SelectOtherTextBookDemand(";
                getStock = getStock + hdnDenmandID.Value;
                getStock = getStock + ",";
                getStock = getStock + ddlTitle.SelectedValue;
                getStock = getStock + ",";
                getStock = getStock + hdnblockid.Value;
                getStock = getStock + ")";
                DataSet ds = obCommonF.FillDatasetByProc(getStock);
                ViewState["ds"] = ds;

                grdTitlegrid.DataSource = obDataset;
                grdTitlegrid.DataBind();
            }
            catch { }
        }
    }
    public void hideFiresrTitle()
    {
        int c = 0;
        foreach (DataListItem obGridViewRow in gridDetails.Items)
        {
            GridView grdTitlegrid = (GridView)obGridViewRow.FindControl("grdTitlegrid");
            if (c > 0)
            {
                grdTitlegrid.Columns[0].Visible = false;
            }
            c++;
        }
    }
    protected void ddlDistrict_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        ddlDistrictM.Visible = true;
        Label1.Visible = true;
        obDemandfromOthers.QueryType = -17;
        obDemandfromOthers.ParameterValue = int.Parse(ddlDistrict.SelectedValue);
        DataSet dsDepoDistrict = obDemandfromOthers.Select();
        ddlDistrictM.DataSource = dsDepoDistrict.Tables[0];
        ddlDistrictM.DataTextField = "District_Name_Hindi_V";
        ddlDistrictM.DataValueField = "DistrictTrno_I";
        ddlDistrictM.DataBind();
        ListItem lstSelect = new ListItem("Select", "0");
        ddlDistrictM.Items.Insert(0, lstSelect);
    }
    protected void rdlOfficeName_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        OfficeSelectionChange();
    }
    private void OfficeSelectionChange()
    {
        if (rdlOfficeName.SelectedValue == "1")
        {
            lblDist.Visible = true;
            ddlDistrict.Visible = true;
            ddlDistrictM.Visible = true;
            Label1.Visible = true;
            lblDivision.Visible = false;
            ddlDivision.Visible = false;
        }
        else if (rdlOfficeName.SelectedValue == "2")
        {
            lblDist.Visible = false;
            ddlDistrict.Visible = false;
            ddlDistrictM.Visible = false;
            Label1.Visible = false;

            lblDivision.Visible = true;
            ddlDivision.Visible = true;

            CommonFuction obCommonFuction = new CommonFuction();
            ddlDivision.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot1()");
            ddlDivision.DataValueField = "DepoTrno_I";
            ddlDivision.DataTextField = "DepoName_V";
            ddlDivision.DataBind();
            ddlDivision.Items.Insert(0, "--Select--");
        }
    }
    private bool CheckDateFormate(string DateValue)
    {
        try
        {
            DateTime dtTmp = DateTime.Parse(DateValue, cult);
            return true;
        }
        catch
        {
            return false;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = string.Empty;

        if (!CheckDateFormate(txtLetterDate.Text))
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Invalid letter date";
        }
        else if (txtRefLetterDate.Text != "" && !CheckDateFormate(txtRefLetterDate.Text))
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Invalid Reference letter date";
        }
        else if (DateTime.Parse(txtLetterDate.Text, cult) > DateTime.Now.Date ||
             (txtRefLetterDate.Text != "" && DateTime.Parse(txtRefLetterDate.Text, cult) > DateTime.Now.Date))
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Date can not be future date";
        }
        else
        {
            APIProcedure objApi = new APIProcedure();
            bool IsValidFile = true;
            if (fileScanLetter.HasFile)
            {

                string uploadStatus = objApi.uploadFile(fileScanLetter, "DistributionBFile", 3000);
                if (uploadStatus != "Ok")
                {
                    mainDiv.Style.Add("display", "block");
                    lblmsg.Text = uploadStatus;
                    IsValidFile = false;
                }
            }
            if (IsValidFile)
            {
                if (fileScanLetter.HasFile)
                {
                    mapFile = objApi.FullFileName;
                }
                else
                {
                    mapFile = mapID.Value;
                }
                obDemandfromOthers.DemandID_I = int.Parse(hdnDenmandID.Value);
                obDemandfromOthers.DepTrno_I = int.Parse(ddlDemandFrom.SelectedValue);
                obDemandfromOthers.AcYrID_I = int.Parse(ddlAcademicYr.SelectedValue);
                obDemandfromOthers.LetterNo_V = txtLetterNo.Text;
                obDemandfromOthers.LetterDate_D = DateTime.Parse(txtLetterDate.Text, cult).ToString("yyyy-MM-dd");
                obDemandfromOthers.RefLetterNo_V = txtRefLetterNo.Text;
                if (txtRefLetterDate.Text != "")
                {
                    obDemandfromOthers.RefLetterDate_D = DateTime.Parse(txtRefLetterDate.Text, cult).ToString("yyyy-MM-dd");
                }
                else
                    obDemandfromOthers.RefLetterDate_D = null;

                obDemandfromOthers.TitleID_I = int.Parse(ddlTitle.SelectedValue);
                obDemandfromOthers.ScanLetterPath_V = fileScanLetter.FileName;
                obDemandfromOthers.FIleName = Convert.ToString(mapFile);
                obDemandfromOthers.DemandFrom_I = int.Parse(rdlOfficeName.SelectedValue);
                obDemandfromOthers.OtherAgencyName_V = TxtOtherAgency.Text;
                obDemandfromOthers.DistrictID_I = Convert.ToInt16(ddlDistrictM.SelectedValue);
                if (hdnDenmandID.Value == "0")
                {
                    obDemandfromOthers.TransID = 0;
                    hdnDenmandID.Value = obDemandfromOthers.InsertUpdate().ToString();
                    CommonFuction comm = new CommonFuction();
                    comm.FillDatasetByProc("UPDATE `dib_demand` SET DemandType=" + DDlDemandType.SelectedValue + " WHERE DemandID_I=" + hdnDenmandID.Value + "");
                }
                else
                {
                    obDemandfromOthers.TransID = -2;
                    obDemandfromOthers.InsertUpdate().ToString();
                }


                #region SaveOffice Information

                if (rdlOfficeName.SelectedValue == "1")
                {
                    int subtitleID = 0;
                    long DistrictSupply_I, BRCSupply_I;//, BlockSupply_I,;
                    int DPCSupply_I, DiatSupply_I;//, OtherSupply_I;
                    int BlockID_I;//, PrvBlockID_I;

                    foreach (DataListItem obGridViewRow in gridDetails.Items)
                    {
                        HiddenField hdnkey = (HiddenField)obGridViewRow.FindControl("hdnkey");
                        GridView grdTitlegrid = (GridView)obGridViewRow.FindControl("grdTitlegrid");

                        DistrictSupply_I = 0;
                        BRCSupply_I = 0;
                        DPCSupply_I = 0;
                        DiatSupply_I = 0;

                        foreach (GridViewRow grd in grdTitlegrid.Rows)
                        {
                            HiddenField tilleid = (HiddenField)grd.FindControl("tilleid");
                            TextBox txtDemand = (TextBox)grd.FindControl("txtDemand");


                            subtitleID = Convert.ToInt16(tilleid.Value);
                            BRCSupply_I = Convert.ToInt64(txtDemand.Text);
                            BlockID_I = Convert.ToInt16(hdnkey.Value);

                            obDemandfromOthers.DemandID_I = int.Parse(hdnDenmandID.Value);
                            obDemandfromOthers.SubTitleID_I = subtitleID;
                            obDemandfromOthers.TransID = -3;
                            obDemandfromOthers.DistrictID_I = Convert.ToInt16(ddlDistrictM.SelectedValue);
                            obDemandfromOthers.OtherDeptId = Convert.ToInt16(ddlDistrict.SelectedValue);
                            obDemandfromOthers.DistrictSupply_I = DistrictSupply_I;
                            obDemandfromOthers.DPCSupply_I = DPCSupply_I;
                            obDemandfromOthers.DiatSupply_I = DiatSupply_I;
                            int CurrentSubTitleTranID = obDemandfromOthers.InsertUpdate();


                            obDemandfromOthers.DemandSubTitleDetailsTrno_I = CurrentSubTitleTranID;
                            obDemandfromOthers.SubTitleID_I = subtitleID;
                            obDemandfromOthers.BRCSupply_I = BRCSupply_I;
                            obDemandfromOthers.TransID = -1;
                            obDemandfromOthers.BlockTrno_I = BlockID_I;
                            obDemandfromOthers.OtherDeptId = Convert.ToInt16(ddlDistrict.SelectedValue);
                            obDemandfromOthers.InsertUpdate();
                        }
                    }

                }
                #endregion

                else
                {
                    #region Save Other AgencyInformation
                    int subtitleID = 0;
                    TextBox txtBox;
                    int PrvDistrictID, RSKSupply, OtherSupply;
                    int DistrictSupply = 0;
                    int DistrictID = 0;
                    for (int row = 2; row < tblBlockwise.Rows.Count; row++)
                    {
                        DistrictSupply = 0;
                        DistrictID = 0;
                        PrvDistrictID = 0;
                        RSKSupply = 0;
                        OtherSupply = 0;

                        if (tblBlockwise.Rows[row].Cells[0].ID != null && tblBlockwise.Rows[row].Cells[0].ID.StartsWith("lblSubTitleID"))
                        {
                            subtitleID = int.Parse(tblBlockwise.Rows[row].Cells[0].ID.Replace("lblSubTitleID", ""));
                        }

                        obDemandfromOthers.DemandID_I = int.Parse(hdnDenmandID.Value);
                        obDemandfromOthers.SubTitleID_I = subtitleID;


                        foreach (TableCell tblBlockCell in tblBlockwise.Rows[row].Cells)
                        {
                            if (((tblBlockCell.ID != null && tblBlockCell.ID.StartsWith("CellDistrictOther")) ||
                                tblBlockCell.ID == null) && tblBlockCell.Visible == true)
                            {

                                for (int cntrl = 0; cntrl < tblBlockCell.Controls.Count; cntrl++)
                                {
                                    try
                                    {
                                        txtBox = (TextBox)tblBlockCell.Controls[cntrl];
                                        //DistrictID = 0;
                                        int.TryParse(txtBox.ID.Substring(txtBox.ID.IndexOf("__") + 2), out DistrictID);
                                        if (PrvDistrictID == 0)
                                        {
                                            PrvDistrictID = DistrictID;
                                        }
                                        obDemandfromOthers.TransID = -3;
                                        if (DistrictID != PrvDistrictID)
                                        {
                                            if (DistrictSupply > 0 || RSKSupply > 0 || OtherSupply > 0)
                                            {
                                                obDemandfromOthers.DistrictSupply_I = DistrictSupply;
                                                obDemandfromOthers.DPCSupply_I = RSKSupply;
                                                obDemandfromOthers.DiatSupply_I = OtherSupply;
                                                obDemandfromOthers.DistrictID_I = PrvDistrictID;
                                                obDemandfromOthers.InsertUpdate();

                                                RSKSupply = 0;
                                            }

                                            PrvDistrictID = DistrictID;
                                        }

                                        if (txtBox.ID.StartsWith("txtDistrictRSK_CPI"))
                                        {
                                            RSKSupply = 0;
                                            int.TryParse(txtBox.Text, out RSKSupply);
                                        }
                                        else if (txtBox.ID.StartsWith("txtDiat"))
                                        {
                                            OtherSupply = 0;
                                            int.TryParse(txtBox.Text, out OtherSupply);
                                        }
                                        else if (txtBox.ID.StartsWith("txtDistrict"))
                                        {
                                            DistrictSupply = 0;
                                            int.TryParse(txtBox.Text, out DistrictSupply);
                                        }

                                    }
                                    catch
                                    {
                                    }
                                }

                            }

                        }

                        if (DistrictSupply > 0 || RSKSupply > 0 || OtherSupply > 0)
                        {
                            obDemandfromOthers.DistrictSupply_I = DistrictSupply;
                            obDemandfromOthers.DPCSupply_I = RSKSupply;
                            obDemandfromOthers.DiatSupply_I = OtherSupply;
                            obDemandfromOthers.DistrictID_I = DistrictID;
                            obDemandfromOthers.InsertUpdate();
                        }
                    }

                    #endregion
                }
                obDemandfromOthers.TransID = 0;
                mainDiv.CssClass = "form-message success";
                mainDiv.Style.Add("display", "block");
                lblmsg.ForeColor = System.Drawing.Color.Green;
                lblmsg.Text = "Record saved successfully";
                btnFinailise.Visible = true;
            }

        }
    }
    protected void btnFinailise_Click(object sender, EventArgs e)
    {
        obDemandfromOthers.TransID = -4;
        obDemandfromOthers.DemandID_I = int.Parse(hdnDenmandID.Value);
        try
        {
            obDemandfromOthers.InsertUpdate();
            mainDiv.CssClass = "form-message success";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Finalization successfully completed";

            Response.Redirect("DemandOtherThenTextBook.aspx");
        }
        catch (Exception ex)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Error in finalization!!";
        }

    }
    private void ClearCtrl()
    {
        txtLetterNo.Text = "";
        txtLetterDate.Text = "";
        TxtOtherAgency.Text = "";
        txtRefLetterNo.Text = "";
        txtRefLetterDate.Text = "";
        tblBlockwise.Rows.Clear();
        rdlOfficeName.SelectedValue = "1";
        hdnDenmandID.Value = "0";
        for (int i = 0; i < chkOffice.Items.Count; i++)
        {
            chkOffice.Items[i].Selected = false;
        }
        ddlDistrict.SelectedValue = "0";
        OfficeSelectionChange();
    }
    protected void btnCloseDistrictSelection_Click(object sender, EventArgs e)
    {
        OnDistrictSelection();
    }
    private void OnDistrictSelection()
    {
        for (int row = 0; row < tblBlockwise.Rows.Count; row++)
        {
            foreach (TableCell tblBlockCell in tblBlockwise.Rows[row].Cells)
            {
                string cellID = "";
                if (tblBlockCell.ID == null)
                {
                    try
                    {
                        TextBox txtGrid = (TextBox)tblBlockCell.Controls[0];
                        cellID = txtGrid.ID;
                    }
                    catch { }
                }
                else
                {
                    cellID = tblBlockCell.ID;
                }

                foreach (ListItem litmDistrict in chklstDistrict.Items)
                {

                    if (litmDistrict.Selected &&
                        cellID.Substring(cellID.IndexOf("__") + 2) == litmDistrict.Value)
                    {
                        tblBlockCell.Visible = true;

                    }
                }
            }
        }

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("DemandOtherThenTextBook.aspx");
    }
    protected void ddlDistrictM_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOtherORG.SelectedIndex <= 0)
        {
            ddlDistrictM.SelectedIndex = -1;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Please select Other Department Name.');", true);
            return;
        }
    }
    protected void ddlOtherORG_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlDistrictM.SelectedIndex > 0)
            {
                ddlDistrictM_SelectedIndexChanged(null, null);
            }
        }
        catch { }
    }
    protected void gridDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                HiddenField tilleid = (HiddenField)e.Row.FindControl("tilleid");
                TextBox txtDemand = (TextBox)e.Row.FindControl("txtDemand");
                DataSet ds = (DataSet)ViewState["ds"];
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (tilleid.Value == Convert.ToString(dr["SubTitleID_I"]))
                    {
                        txtDemand.Text = dr["BRCSupply_I"].ToString();
                    }
                }
            }
            catch { }
        }
    }
    protected void BtnViewAll_Click(object sender, EventArgs e)
    {
        FillSelectedBlockGrid();
    }
    public class DemandfromOthers
    {
        public int QueryType { get; set; }
        public int ParameterValue { get; set; }
        public int ParameterValue2 { get; set; }
        public string StringParameterValue { get; set; }

        public int DemandID_I { get; set; }
        public int DepTrno_I { get; set; }
        public int AcYrID_I { get; set; }
        public string LetterNo_V { get; set; }
        public string LetterDate_D { get; set; }
        public string RefLetterNo_V { get; set; }
        public string RefLetterDate_D { get; set; }
        public int TitleID_I { get; set; }
        public string ScanLetterPath_V { get; set; }
        public int DemandFrom_I { get; set; }
        public int DistrictID_I { get; set; }
        public int DemandDetailsID_I { get; set; }
        public int SubTitleID_I { get; set; }
        public long DistrictSupply_I { get; set; }
        public string OtherAgencyName_V { get; set; }

        public int BlockSupply_I { get; set; }
        public long BRCSupply_I { get; set; }
        public int DPCSupply_I { get; set; }
        public int DiatSupply_I { get; set; }
        public int OtherSupply_I { get; set; }
        public int TransID { get; set; }
        public int BlockTrno_I { get; set; }
        public int DemandSubTitleDetailsTrno_I { get; set; }
        public int OtherDeptId { get; set; }
        public string FIleName { get; set; }
        DBAccess obDBAccess = new DBAccess();

        #region ICommon Members

        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB002_DemandfromOthersSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDemandID_I", DemandID_I);
            obDBAccess.addParam("mDepTrno_I", DepTrno_I);
            obDBAccess.addParam("mAcYrID_I", AcYrID_I);
            obDBAccess.addParam("mLetterNo_V", LetterNo_V);
            obDBAccess.addParam("mLetterDate_D", LetterDate_D);
            obDBAccess.addParam("mRefLetterNo_V", RefLetterNo_V);
            obDBAccess.addParam("mRefLetterDate_D", RefLetterDate_D);
            obDBAccess.addParam("mTitleID_I", TitleID_I);
            obDBAccess.addParam("mScanLetterPath_V", ScanLetterPath_V);
            obDBAccess.addParam("mDemandFrom_I", DemandFrom_I);
            obDBAccess.addParam("mDistrictID_I", DistrictID_I);
            obDBAccess.addParam("mDemandDetailsID_I", DemandDetailsID_I);
            obDBAccess.addParam("mSubTitleID_I", SubTitleID_I);
            obDBAccess.addParam("mDistrictSupply_I", DistrictSupply_I);
            obDBAccess.addParam("mBlockSupply_I", BlockSupply_I);
            obDBAccess.addParam("mBRCSupply_I", BRCSupply_I);
            obDBAccess.addParam("mDPCSupply_I", DPCSupply_I);
            obDBAccess.addParam("mDiatSupply_I", DiatSupply_I);
            obDBAccess.addParam("mOtherSupply_I", OtherSupply_I);
            obDBAccess.addParam("mBlockTrno_I", BlockTrno_I);
            obDBAccess.addParam("mOtherAgencyName_V", OtherAgencyName_V);
            obDBAccess.addParam("mDemandSubTitleDetailsTrno_I", DemandSubTitleDetailsTrno_I);

            obDBAccess.addParam("FIleName", FIleName);
            obDBAccess.addParam("mTransID", TransID);
            obDBAccess.addParam("mOtherDeptId", OtherDeptId);
            object result = obDBAccess.executeMyScalar();

            return int.Parse(result.ToString());
        }

        public System.Data.DataSet Select()
        {
            obDBAccess.execute("USP_DIB002_DemandfromOthersSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mType", QueryType);
            obDBAccess.addParam("mParameterValue", ParameterValue);
            obDBAccess.addParam("mParameterValue2", ParameterValue2);
            obDBAccess.addParam("mStringParameterValue", StringParameterValue);

            return obDBAccess.records();
        }

        public System.Data.DataSet FillGrid()
        {
            obDBAccess.execute("USP_DIB002_DemandFromOtherLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDistrictID_I", DistrictID_I);

            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
