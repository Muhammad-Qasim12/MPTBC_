using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;

public partial class AcademicB_DemandCreation : System.Web.UI.Page
{
    
    //MPTBCBussinessLayer.AcademicB.DemandCreation obDemandCreation = new MPTBCBussinessLayer.AcademicB.DemandCreation();
    DemandCreation_New obDemandCreation = new DemandCreation_New();
    DataTable dtItemDesc;
    protected void Page_Load(object sender, EventArgs e)
    {
        mainDiv.CssClass = "form-message error";
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = "";

        if (!IsPostBack)
        {
            dtItemDesc = new DataTable();
            DataColumn[] DatakeySet = new DataColumn[13];
            DatakeySet[0] = dtItemDesc.Columns.Add("TitleSize", typeof(string));
            DatakeySet[1] = dtItemDesc.Columns.Add("Binding", typeof(string));
            DatakeySet[2] = dtItemDesc.Columns.Add("PrintingPaperType", typeof(string));
            DatakeySet[3] = dtItemDesc.Columns.Add("PrintingPaperID", typeof(string));
            DatakeySet[4] = dtItemDesc.Columns.Add("PrintingPaperGSM", typeof(string));
            DatakeySet[5] = dtItemDesc.Columns.Add("CoverPaperType", typeof(string));
            DatakeySet[6] = dtItemDesc.Columns.Add("CoverPaperID", typeof(string));
            DatakeySet[7] = dtItemDesc.Columns.Add("CoverPaperGSM", typeof(string));
            DatakeySet[8] = dtItemDesc.Columns.Add("TextColourScheme", typeof(string));
            DatakeySet[9] = dtItemDesc.Columns.Add("CoverColourScheme1n4", typeof(string));
            DatakeySet[10] = dtItemDesc.Columns.Add("CoverColourScheme2n3", typeof(string));
            DatakeySet[11] = dtItemDesc.Columns.Add("TotalTitleInOneSet", typeof(string));
            DatakeySet[12] = dtItemDesc.Columns.Add("ReemFactor", typeof(string));
            dtItemDesc.PrimaryKey = DatakeySet;
            ViewState.Add("dtSelectedTitle", dtItemDesc);
            fillTitle();
            fillPaperType();
            //fillDepoDetails();
            //LoadCategoryDropdown();
            //ddlCategory_OnSelectedIndexChanged(sender, e);
        }
    }
   
    //private void fillDepoDetails()
    //{
    //    obDemandCreation.QueryType = -1;
    //    //obGroupCreation.PrameterValue = int.Parse(ddlSubTitle.SelectedValue);
    //    ddlDepo.DataSource = obDemandCreation.Select();
    //    ddlDepo.DataTextField = "DepoName_V";
    //    ddlDepo.DataValueField = "DepoTrno_I";
    //    ddlDepo.DataBind();
    //    ddlDepo.Items.Insert(0, new ListItem("--Select--", "0"));
    //    fillTitle();
    //}

    private void fillTitle() 
    {
        obDemandCreation.QueryType = -1;
        //obDemandCreation.ParameterValue = int.Parse(ddlDepo.SelectedValue);
        ddlTitle.DataSource = obDemandCreation.Select();
        ddlTitle.DataTextField = "TitleHindi_V";
        ddlTitle.DataValueField = "TitleID_I";
        ddlTitle.DataBind();
        ddlTitle.Items.Insert(0, new ListItem("--Select--", "0"));
        fillSubTitle();
    }
    private void fillSubTitle()
    {
        obDemandCreation.QueryType = -2;
        obDemandCreation.ParameterValue = int.Parse(ddlTitle.SelectedValue);
        ddlSubTitle.DataSource = obDemandCreation.Select();
        ddlSubTitle.DataTextField = "SubTitleHindi_V";
        ddlSubTitle.DataValueField = "SubTitleID_I";
        ddlSubTitle.DataBind();
        ddlSubTitle.Items.Insert(0, new ListItem("--Select--", "0"));
        fillTotalQuantity();
    }

    private void fillTotalQuantity()
    {
        obDemandCreation.QueryType = -3;
        obDemandCreation.ParameterValue = int.Parse(ddlSubTitle.SelectedValue);
        DataSet dsTotalQuantity= obDemandCreation.Select();
        if (dsTotalQuantity.Tables[0].Rows.Count > 0)
        {
            lblTotalQuantity.Text = dsTotalQuantity.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            lblTotalQuantity.Text = "0";
        }
    }

    private void fillPaperType()
    {
        obDemandCreation.QueryType = -4;
        obDemandCreation.ParameterValue = 1;
        ddlPaperGSM.DataSource = obDemandCreation.Select();
        ddlPaperGSM.DataTextField = "Papersize_V";
        ddlPaperGSM.DataValueField = "PaperTrId_I";
        ddlPaperGSM.DataBind();

        obDemandCreation.QueryType = -4;
        obDemandCreation.ParameterValue = 2;
        ddlCoverGSM.DataSource = obDemandCreation.Select();
        ddlCoverGSM.DataTextField = "Papersize_V";
        ddlCoverGSM.DataValueField = "PaperTrId_I";
        //ddlCoverGSM.DataValueField = "GSM";
        ddlCoverGSM.DataBind();
        
    }

    private void FillGrid()
    {
        //obDemandCreation.QueryType = -4;
        //obDemandCreation.PrameterValue = int.Parse(ddlDepo.SelectedValue);
        ////obGroupCreation.PrameterValue2 = int.Parse( ddlSubTitle.SelectedValue);
        //grdDepo.DataSource = obDemandCreation.Select();
        //grdDepo.DataBind();
    }
    protected void ddlTitle_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        fillSubTitle();
    }

    protected void ddlSubTitle_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        //fillDemandDetails();
        // fillDepoDetails();
        //FillGrid();
        fillTotalQuantity();
    }

    protected void ddlDepo_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }
    //
    protected void ddlDemandDetails_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }

    
   
    private void FillSelectedTitleGrid()
    {

        dtItemDesc = (DataTable)ViewState["dtSelectedTitle"];
        grdSelectedTitle.DataSource = dtItemDesc;
        grdSelectedTitle.DataBind();


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (grdSelectedTitle.Rows.Count < 1)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please add specification of items";
        }
        else if (int.Parse(txtTotalPages.Text) > 0)
        {
            obDemandCreation.SubTitleID_I = int.Parse(ddlSubTitle.SelectedValue);
            obDemandCreation.TotalQty_I = int.Parse(lblTotalQuantity.Text);
            obDemandCreation.TotalPages_I = int.Parse(txtTotalPages.Text);
            obDemandCreation.DemandGenrationDate_D = DateTime.Now.ToString("yyyy-MM-dd");
            obDemandCreation.TransID = 0;
            obDemandCreation.TotalTitleInOneSet = int.Parse(txtTottitleinOneSet.Text);

            obDemandCreation.DemandID_I = obDemandCreation.InsertUpdate();

            for (int i = 0; i < grdSelectedTitle.Rows.Count; i++)
            {

                obDemandCreation.ItemSize_V = grdSelectedTitle.Rows[i].Cells[0].Text;
                obDemandCreation.Binding_V = grdSelectedTitle.Rows[i].Cells[1].Text;

                Label lblGrid = (Label)grdSelectedTitle.Rows[i].FindControl("lblPrintingPaperID");
                obDemandCreation.PrintingPaperTypeID_I =int.Parse(lblGrid.Text);

                lblGrid = (Label)grdSelectedTitle.Rows[i].FindControl("lblPrintingPaperGSM");
                obDemandCreation.PrintingPaperGSM_I = int.Parse(lblGrid.Text);

                lblGrid = (Label)grdSelectedTitle.Rows[i].FindControl("lblCoverPaperID");
                obDemandCreation.CoverPaperTypeID_I = int.Parse(lblGrid.Text);

                lblGrid = (Label)grdSelectedTitle.Rows[i].FindControl("lblCoverPaperGSM");
                obDemandCreation.CoverPaperGSM_I = int.Parse(lblGrid.Text);

                lblGrid = (Label)grdSelectedTitle.Rows[i].FindControl("lblReemFactor");
                obDemandCreation.ReemFactor = int.Parse(lblGrid.Text);

                obDemandCreation.TextColor_V = grdSelectedTitle.Rows[i].Cells[4].Text;
                obDemandCreation.CoverColor1n4_V = grdSelectedTitle.Rows[i].Cells[5].Text;
                obDemandCreation.CoverColor2n3_V = grdSelectedTitle.Rows[i].Cells[6].Text;

                obDemandCreation.TransID = -1;

                obDemandCreation.InsertUpdate();

            }
            mainDiv.CssClass = "form-message success";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Record added successfully";

            ClearCtrl();
            Response.Redirect("ViewDemandOtherthanTextbook.aspx");
        }
        else
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Total pages should be greater then zero.";
        }
        #region old code
        /*
        if (grdSelectedTitle.Rows.Count > 0)
        {

            try
            {
                if (Request.QueryString["Cid"] != null)
                {
                    obGroupCreation.DemandGroupTrno_I = Convert.ToInt32(Request.QueryString["Cid"]);
                }
                else { obGroupCreation.DemandGroupTrno_I = 0; }

                obGroupCreation.GroupName_V = Convert.ToString(txtGroupName.Text);
                obGroupCreation.PrintingCategory_V = Convert.ToString(ddlCategory.SelectedValue);

                obGroupCreation.DepoTrno_I = 0;

                obGroupCreation.DemandGroupTrno_I = obGroupCreation.GroupMasterSaveUpdate();

            }
            catch  { }
           
          


            for (int row = 0; row < grdSelectedTitle.Rows.Count; row++)
            {
               
                Label lblGrid = (Label)grdSelectedTitle.Rows[row].FindControl("lblDemandSubTitleTrno");

                string[] DemandDetails = lblGrid.Text.Split(',');

                for (int i = 0; i < DemandDetails.Length; i++)
                {


                    obGroupCreation.DemandID_I = int.Parse(DemandDetails[i]);

                    lblGrid = (Label)grdSelectedTitle.Rows[row].FindControl("lblSubTitleID");
                    obGroupCreation.SubTitleID_I = int.Parse(lblGrid.Text);

                    lblGrid = (Label)grdSelectedTitle.Rows[row].FindControl("lblDepoID");
                    obGroupCreation.DepoTrno_I = int.Parse(lblGrid.Text);
                    obGroupCreation.TotalSupply_I = int.Parse(grdSelectedTitle.Rows[row].Cells[3].Text);
                    obGroupCreation.GroupName_V = txtGroupName.Text;
                    obGroupCreation.GroupDate_D = DateTime.Now.ToString("yyyy-MM-dd");
                    obGroupCreation.TypeID = 0;
                    try
                    {
                        obGroupCreation.GroupDetailsSaveUpdate();
                    }
                    catch
                    {
                        //mainDiv.CssClass = "form-message error";
                        //mainDiv.Style.Add("display", "block");
                        //lblmsg.Text = "Error in data!!";

                    }
                }
            }

            mainDiv.CssClass = "form-message success";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Record saved successfully";
            ClearCtrl();
        }
        else
        {
            mainDiv.CssClass = "form-message error";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "No record selected!!";
        }
        //obGroupCreation.DemandID_I
         */
        #endregion
    }
    protected void grdSelectedTitle_OnRowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        dtItemDesc = (DataTable)ViewState["dtSelectedTitle"];
        dtItemDesc.Rows[e.RowIndex].Delete();
        dtItemDesc.AcceptChanges();
        ViewState["dtSelectedTitle"] = dtItemDesc;
        FillSelectedTitleGrid();
    }
    private void ClearCtrl()
    {
        txtTotalPages.Text = "";
        txtSize.Text = "";
        txtBinding.Text = "";
        //grdDepo.DataSource = null;
        //grdDepo.DataBind();
       // FillTitle();
        dtItemDesc =(DataTable) ViewState["dtSelectedTitle"];
        dtItemDesc.Rows.Clear();
        ViewState["dtSelectedTitle"] = dtItemDesc;
        FillSelectedTitleGrid();
        grdSelectedTitle.DataSource = null;
        grdSelectedTitle.DataBind();

        fillTitle();
    }
    protected void btnAddTitle_Click(object sender, EventArgs e)  
    {
        if (Page.IsValid)
        {
            dtItemDesc = (DataTable)ViewState["dtSelectedTitle"];
            DataRow drNewTitle = dtItemDesc.NewRow();
            drNewTitle["TitleSize"] = txtSize.Text;
            drNewTitle["Binding"] = txtBinding.Text;
            drNewTitle["PrintingPaperType"] = ddlPaperGSM.SelectedItem;
            drNewTitle["PrintingPaperID"] = ddlPaperGSM.SelectedValue;
            string GSM=  ddlPaperGSM.SelectedItem.Text.Substring(ddlPaperGSM.SelectedItem.Text.LastIndexOf("-") + 2);
            GSM = GSM.Substring(0, GSM.Length - 4);
            drNewTitle["PrintingPaperGSM"] =GSM;
            drNewTitle["CoverPaperType"] = ddlCoverGSM.SelectedItem;
            drNewTitle["CoverPaperID"] = ddlCoverGSM.SelectedValue;

            GSM = ddlCoverGSM.SelectedItem.Text.Substring(ddlCoverGSM.SelectedItem.Text.LastIndexOf("-") + 2);
            GSM = GSM.Substring(0, GSM.Length - 4);
            drNewTitle["CoverPaperGSM"] = GSM;
            drNewTitle["TextColourScheme"] = ddlTextColour.SelectedValue;
            drNewTitle["CoverColourScheme1n4"] = ddlCoverColour1n4.SelectedValue;
            drNewTitle["CoverColourScheme2n3"] = ddlCoverColour2n3.SelectedValue;

            drNewTitle["TotalTitleInOneSet"] = txtTottitleinOneSet.Text;
            drNewTitle["ReemFactor"] = txtReemfactor.Text;


            //lblGridValue = (Label)grdDepo.Rows[rowno].FindControl("lblDemandSubTitleTrno");
            //drNewTitle["DemandSubTitleDetailsTrno"] = lblGridValue.Text;
            try
            {
                dtItemDesc.Rows.Add(drNewTitle);
                mainDiv.CssClass = "form-message success";
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Record added successfully";
            }
            catch
            {
                mainDiv.CssClass = "form-message error";
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Duplicate entry!!";
            }
            ViewState.Add("dtSelectedTitle", dtItemDesc);
            FillSelectedTitleGrid();
        }
    }

    public class DemandCreation_New 
    {
        public int QueryType { get; set; }
        public int ParameterValue { get; set; }
        public int ParameterValue2 { get; set; }


        public int DemandID_I { get; set; }
        public int SubTitleID_I { get; set; }
        public int TotalQty_I { get; set; }
        public int TotalPages_I { get; set; }
        public double Qty_PriPaper { get; set; }
        public double Qty_CoverPaper { get; set; }
        public int DemandDetailsID_I { get; set; }

        public int DisDemandID_I { get; set; }
        public int TotalItems_I { get; set; }
        public int DepoID_I { get; set; }

        public int DemandSpecificationID_I { get; set; }
        public string ItemSize_V { get; set; }
        public string Binding_V { get; set; }
        public int PrintingPaperTypeID_I { get; set; }
        public int PrintingPaperGSM_I { get; set; }
        public int CoverPaperTypeID_I { get; set; }
        public int CoverPaperGSM_I { get; set; }
        public string TextColor_V { get; set; }
        public string CoverColor1n4_V { get; set; }
        public string DemandGenrationDate_D { get; set; }
        public string CoverColor2n3_V { get; set; }
        public int TransID { get; set; }
        public int ReemFactor { get; set; }
        public int TotalTitleInOneSet { get; set; }

        DBAccess obDBAccess = new DBAccess();
        #region ICommon Members

        public int InsertUpdate()
        {
            obDBAccess.execute("USP_ACB006_DemandCreationSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDemandID_I", DemandID_I);
            obDBAccess.addParam("mSubTitleID_I", SubTitleID_I);
            obDBAccess.addParam("mTotalQty_I", TotalQty_I);
            obDBAccess.addParam("mTotalPages_I", TotalPages_I);
            obDBAccess.addParam("mQty_PriPaper", Qty_PriPaper);
            obDBAccess.addParam("mQty_CoverPaper", Qty_CoverPaper);
            obDBAccess.addParam("mDemandGenrationDate_D", DemandGenrationDate_D);
            obDBAccess.addParam("mDemandDetailsID_I", DemandDetailsID_I);
            obDBAccess.addParam("mDisDemandID_I", DisDemandID_I);
            obDBAccess.addParam("mTotalItems_I", TotalItems_I);

            obDBAccess.addParam("mDepoID_I", DepoID_I);
            obDBAccess.addParam("mDemandSpecificationID_I", DemandSpecificationID_I);
            obDBAccess.addParam("mItemSize_V", ItemSize_V);
            obDBAccess.addParam("mBinding_V", Binding_V);
            obDBAccess.addParam("mPrintingPaperTypeID_I", PrintingPaperTypeID_I);

            obDBAccess.addParam("mPrintingPaperGSM_I", PrintingPaperGSM_I);
            obDBAccess.addParam("mCoverPaperTypeID_I", CoverPaperTypeID_I);
            obDBAccess.addParam("mCoverPaperGSM_I", CoverPaperGSM_I);
            obDBAccess.addParam("mTextColor_V", TextColor_V);
            obDBAccess.addParam("mCoverColor1n4_V", CoverColor1n4_V);
            obDBAccess.addParam("mCoverColor2n3_V", CoverColor2n3_V);
            obDBAccess.addParam("mTransID", TransID);
            obDBAccess.addParam("mTotalTitleInOneSet", TotalTitleInOneSet);
            obDBAccess.addParam("mReemFactor", ReemFactor); 

            object result = obDBAccess.executeMyScalar();
            return int.Parse(result.ToString());
        }

        public System.Data.DataSet Select()
        {
            obDBAccess.execute("USP_ACB006_DemandCreationSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", QueryType);
            obDBAccess.addParam("mParameterValue", ParameterValue);
            obDBAccess.addParam("mParameterValue2", ParameterValue2);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    
}