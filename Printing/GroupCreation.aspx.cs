using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

using System.Data;

public partial class Printing_GroupCreation : System.Web.UI.Page
{
    ClassMaster obClass = null;
    PRI_CategoryMaster obPRI_CategoryMaster = null;
    PRI_GroupCreationLC obGroupCreation1 = new PRI_GroupCreationLC();
    CommonFuction obCommonFunction = new CommonFuction();
    DataSet ds; int count;
    string id = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!Page.IsPostBack)
        {

            DdlACYear.DataSource = obCommonFunction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            try
            {
                DdlACYear.SelectedValue = obCommonFunction.GetFinYear();
            }
            catch { }
            LoadPrintingPaper();
            obClass = new ClassMaster();
            DataSet dtclass = obClass.Select();
            obClass.ClassTrno_I = 0;

            CheckBoxList1.DataTextField = "Classdet_V";
            CheckBoxList1.DataValueField = "ClassTrno_I";
            CheckBoxList1.DataSource = dtclass;
            CheckBoxList1.DataBind();
            CommonFuction comm = new CommonFuction();
            //DataSet asdf = comm.FillDatasetByProc("call USP_DPTOPeningStock(0,1,0,0,0,0)");
            //ddlTital.DataSource = asdf.Tables[0];
            //ddlTital.DataTextField = "TitleHindi_V";
            //ddlTital.DataValueField = "TitleID_I";
            //ddlTital.DataBind();
            //ddlTital.Items.Insert(0, new ListItem("Select..", "0"));
            //DdlMedium.DataSource = obCommonFunction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)");
            //DdlMedium.DataValueField = "MediumTrno_I";
            //DdlMedium.DataTextField = "MediunNameHindi_V";
            //DdlMedium.DataBind();
            //DdlMedium.Items.Insert(0, "Select");

            Load(); LoadCoverPaper();
        }
    }
    public void LoadPrintingPaper()
    {
        obPRI_CategoryMaster = new PRI_CategoryMaster();
        try
        {
            ddlPrintingPaperInformation_V.DataSource = obPRI_CategoryMaster.Fillddl(1);
            ddlPrintingPaperInformation_V.DataTextField = "PrintingInformation";
            ddlPrintingPaperInformation_V.DataValueField = "PaperTrId_I";
            ddlPrintingPaperInformation_V.DataBind();
            ddlPrintingPaperInformation_V.Items.Insert(0, "Select..");

        }
        catch (Exception ex) { }
        finally { obPRI_CategoryMaster = null; }
    }
    public void LoadCoverPaper()
    {
        obPRI_CategoryMaster = new PRI_CategoryMaster();
        try
        {
            ddlCoverPaperinformation_V.DataSource = obPRI_CategoryMaster.Fillddl(2);
            ddlCoverPaperinformation_V.DataTextField = "CoverInformation";
            ddlCoverPaperinformation_V.DataValueField = "PaperTrId_I";
            ddlCoverPaperinformation_V.DataBind();
            ddlCoverPaperinformation_V.Items.Insert(0, "Select..");

        }
        catch (Exception ex) { }
        finally { obPRI_CategoryMaster = null; }
    }

    public void Load()
    {
        LoadCategoryDropdown();
        LoadGrd();

        if (Request.QueryString["Cid"] != null)
        {
            loadGRoupGrd();
        }

    }
    public void loadGRoupGrd()
    {
        obGroupCreation1 = new PRI_GroupCreationLC();
        DataSet ds = new DataSet();

        try
        {

            obGroupCreation1.GrpID_I = Convert.ToInt32(Request.QueryString["Cid"]);
            obGroupCreation1.BankDetails = Convert.ToString(DdlACYear.SelectedValue); 
            ds = obGroupCreation1.GroupDetailsLoad();

            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlCategory.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PrintingCategory_V"]);
                txtGroupNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["groupno_v"]);

               // ddlGroupId.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["BookMarkId"]);
                txtBankDetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["EMDAmount_N"]);
                txtBankDetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["BankName_V"]);
                txtBankDetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["BankDetails"]);
                try
                {
                    ddlTenderType.Items.FindByText(ds.Tables[0].Rows[0]["TenderType"].ToString()).Selected = true;
                }
                catch { }
         
                obGroupCreation1.IsFinal = 1;
                obGroupCreation1.AcdYear = obCommonFunction.GetFinYear();
                obGroupCreation1.GrpID_I = Convert.ToInt32(Request.QueryString["Cid"]);
               
               
                grdBooksDes.DataSource = ds;
                grdBooksDes.DataBind();

                for (int i = 0; i < grdBooksDes.Rows.Count; i++)
                {
                    ((CheckBox)grdBooksDes.Rows[i].FindControl("chkChoose")).Checked = true;
                }
            }
        }
        catch (Exception ex) { }
        finally { obGroupCreation1 = null; }
    }

    public void LoadCategoryDropdown()
    {
        obGroupCreation1 = new PRI_GroupCreationLC();

        try
        {
            obGroupCreation1.CatID_I = 0;
            ddlCategory.DataTextField = "CategoryNo_V";
            ddlCategory.DataValueField = "CatID_I";
            ddlCategory.DataSource = obGroupCreation1.LoadCategory();
            ddlCategory.DataBind();

            ddlCategory.Items.Insert(0, new ListItem("Select", "0"));
        }

        catch (Exception ex) { }
        finally { obGroupCreation1 = null; }


    }





    public void LoadGrd()
    {
        PRIN_GroupCreation obGroup = new PRIN_GroupCreation();
        try
        {
            obGroup.GroupId = 0;

            //ddlGroupId.DataTextField = "GroupName";
            //ddlGroupId.DataValueField = "GroupId";

            //ddlGroupId.DataSource = obGroup.Select();
            //ddlGroupId.DataBind();
            //ddlGroupId.Items.Insert(0, new ListItem("Select", "0"));
            obGroup.ACYear = Convert.ToString(DdlACYear.SelectedValue);
            DlistGroup.DataSource = obGroup.Select();
            DlistGroup.DataBind();
        }

        catch (Exception ex) { }
        finally { obGroup = null; }

    }



    public void LoadTitlesGrd(string BookMarkId)
    {
        PRIN_GroupCreation obGroup = new PRIN_GroupCreation();
        try
        {
            obGroup.ACYear = Convert.ToString(DdlACYear.SelectedValue);
            ds = obGroup.MultGroupTitleListLoad(BookMarkId);
            grdBooksDes.DataSource = ds.Tables[0];
            grdBooksDes.DataBind();
            if (grdBooksDes.Rows.Count > 0)
            {
                tblbookDtl.Visible = true;
            }
            else
            {
                tblbookDtl.Visible = false;
                grdBooksDes.DataSource = string.Empty;
                grdBooksDes.DataBind();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                lblDepoList.Text = "";
                foreach (DataRow dsL in ds.Tables[1].Rows)
                {
                    lblDepoList.Text = lblDepoList.Text + dsL["DepoNames"].ToString() + ",";
                }
            }
            else
            {
                lblDepoList.Text = "";
            }
        }

        catch (Exception ex) { }
        finally { obGroup = null; }

    }


    protected void chkGroupName_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkGrpName = (CheckBox)sender;
        DataListItem Dl = (DataListItem)chkGrpName.NamingContainer;
        string Val = "";
        foreach (DataListItem dl in DlistGroup.Items)
        {
            CheckBox chkGroupName = (CheckBox)dl.FindControl("chkGroupName");
            Label lblGroupId = (Label)dl.FindControl("lblGroupId");
            if (chkGroupName.Checked == true)
            {
                Val = Val + lblGroupId.Text+",";
            }
        }

        if (Val != "")
        {
           // LoadTitlesGrd(Val);
        }
        else
        {

        }
    }
    //protected void ddlGroupId_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    if (ddlGroupId.SelectedValue != "0")
    //    {
    //        //LoadTitlesGrd(Convert.ToInt32(ddlGroupId.SelectedValue));
    //    }
    //    else
    //    {

    //    }
    //}


    // function to Save Update the Group Master Information

    public int GroupMasterSaveUpdate()
    {
        int i = 0;
        string GroupId = "";
        foreach (DataListItem dl in DlistGroup.Items)
        {
            CheckBox chkGroupName = (CheckBox)dl.FindControl("chkGroupName");
            // String grpvalue = Convert.ToString ((CheckBox)dl.FindControl("chkGroupName");
            Label lblGroupId = (Label)dl.FindControl("lblGroupId");
            if (chkGroupName.Checked == true)
            {
                GroupId = lblGroupId.Text;
            }
       
        if (GroupId == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('कृपया बुक मार्क चुने |');</script>");
        }
        else
        {
            PRI_GroupCreationLC obGroupCreation1 = new PRI_GroupCreationLC();
          //  obGroupCreation1 = new PRI_GroupCreationLC();
            
            try
            {
                
                for (int j = 0; j < grdBooksDes.Rows.Count; j++)
                {
                    if (((CheckBox)grdBooksDes.Rows[j].FindControl("chkChoose")).Checked == true && Convert.ToString (((HiddenField)grdBooksDes.Rows[j].FindControl("Hdngroupname")).Value) == GroupId )
                    { 
                    if (Request.QueryString["Cid"] != null)
                    {
                        obGroupCreation1.GrpID_I = Convert.ToInt32(Request.QueryString["Cid"]);
                    }
                    else {
                        try { 
                        obGroupCreation1.GrpID_I = 0;
                        }
                        catch { }
                    }

                obGroupCreation1.GroupNO_V = Convert.ToString(txtGroupNo.Text);
                obGroupCreation1.PrintingCategory_V = Convert.ToString(ddlCategory.SelectedValue);

                obGroupCreation1.DepoID_I = Convert.ToInt32(HdnDepoID_I.Value);
                obGroupCreation1.BookMarkId = Convert.ToInt32(GroupId.ToString());
                obGroupCreation1.BookmarkName_V = "";
                obGroupCreation1.EMDAmount_N = txtEMDAmount_N.Text == "" ? 0 : Convert.ToDouble(txtEMDAmount_N.Text);
                //bank name used for Subgroup no and detail used for academic year
                obGroupCreation1.BankName_V = Convert.ToString(((TextBox)grdBooksDes.Rows[j].FindControl("txtSubgroup")).Text);
                obGroupCreation1.BankDetails = Convert.ToString(DdlACYear.SelectedValue);
              obGroupCreation1.TenderType = Convert.ToString(ddlTenderType.SelectedItem.Text);
               
                i = obGroupCreation1.GroupMasterSaveUpdate();
                HdnGrpId_I.Value = i.ToString();
                GroupDetailSaveUpdate(GroupId, j);
                    }
                }
            }
            catch (Exception ex) { }
            finally
            {
                obGroupCreation1 = null;
                //Response.Redirect("VIEW002_GroupCreation.aspx");
            }
        }

        }
        return i;
    }

    // function to save Update the Group Details

    public int GroupDetailSaveUpdate(string GroupId,int j)
    {
        obGroupCreation1 = new PRI_GroupCreationLC();
        int i = 0;
        try
             
        {
            // string GroupId = "";
//            foreach (DataListItem dl in DlistGroup.Items)
//            {
//                CheckBox chkGroupName = (CheckBox)dl.FindControl("chkGroupName");
//                Label lblGroupId = (Label)dl.FindControl("lblGroupId");
//                if (chkGroupName.Checked == true)
//                {

///*                    GroupId = GroupId + lblGroupId.Text + ",";  */
                      
//                }
                
//            }

          //  GroupId = lblGroupId.Text + ",";
          // loop lock salah
            //  for (int grdRow = 0; grdRow < grdBooksDes.Rows.Count; grdRow++)
           // {
          int   grdRow = j;
                if (((CheckBox)grdBooksDes.Rows[grdRow].FindControl("chkChoose")).Checked == true  )
                {
                    obGroupCreation1.TitleID_I = Convert.ToInt32(((HiddenField)grdBooksDes.Rows[grdRow].FindControl("HdnTitleId")).Value);
                    obGroupCreation1.DelStatus = grdRow;

                    if (Request.QueryString["Cid"] != null)
                    {
                        obGroupCreation1.GrpID_I = Convert.ToInt32(Request.QueryString["Cid"]);
                    }
                    else {
                        
                    obGroupCreation1.GrpID_I = Convert.ToInt32(HdnGrpId_I.Value);

                        
                       //  obGroupCreation1.GrpID_I = Convert.ToInt32(((TextBox )grdBooksDes.Rows[grdRow].FindControl("txtSubgroup")).Value);
                    
                    }

                    obGroupCreation1.AcdYear = DdlACYear.SelectedItem.Text;
                    obGroupCreation1.DepoID_I = 0;//Convert.ToInt32(((HiddenField)grdBooksDes.Rows[grdRow].FindControl("HdnDepoId")).Value);
                    obGroupCreation1.PriDemandId = 0;// Convert.ToInt32(((HiddenField)grdBooksDes.Rows[grdRow].FindControl("HdnPriDemandId")).Value);

                    i = obGroupCreation1.GroupDetailsSaveUpdate(GroupId);
                }
            //}
        }
        catch (Exception ex) { }
        finally {  }
        return i;
}

    protected void btnSaveGroup_Click(object sender, EventArgs e)
    {
        int i = 0;
        string ChkSts = "";
        foreach (GridViewRow gv in grdBooksDes.Rows)
        {
            CheckBox chkChoose = (CheckBox)gv.FindControl("chkChoose");

            if (chkChoose.Checked == true)
            {
                ChkSts = "Ok";
            }        
        }

        if (ChkSts == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('ग्रुप के लिए पुस्तक की जानकारी चेक करे  |');</script>");
        }
        else if (grdBooksDes.Rows.Count > 0)
        {

            i = GroupMasterSaveUpdate();
            //if (i > 0)
            //{
            grdBooksDes.DataSource = null;
            grdBooksDes.DataBind();
            txtBankDetails.Text = "";
            txtBankName_V.Text = "";
            txtEMDAmount_N.Text = "";
            txtGroupNo.Text = "";
            ddlCategory.SelectedIndex = -1;
            Label1.Text = "";
            try { 
            ddlTital.SelectedIndex = 0;
            }
            catch { }
            Label3.Text = "ग्रुप की जानकारी सुरक्षित हो गई है |";
           ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('ग्रुप की जानकारी सुरक्षित हो गई है |');</script>");
               // Response.Redirect("VIEW002_GroupCreation.aspx"); 
            //}
                
        }
        else
        {

            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('ग्रुप की जानकारी चेक करे  |');</script>");
        }
    }

    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadGrd() ;
        //string Val = "";
        //foreach (DataListItem dl in DlistGroup.Items)
        //{
        //    CheckBox chkGroupName = (CheckBox)dl.FindControl("chkGroupName");
        //    Label lblGroupId = (Label)dl.FindControl("lblGroupId");
        //    if (chkGroupName.Checked == true)
        //    {
        //        Val = Val + lblGroupId.Text + ",";
        //    }
        //}

        //if (Val != "")
        //{
        //    LoadTitlesGrd(Val);
        //}
        //else
        //{

        //}
    }

    // USP_ADM017_SchemeMasterLoad 
    //protected void DdlMedium_Init(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DdlMedium.DataSource = obCommonFunction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load()");
    //        DdlMedium.DataValueField = "MediumTrno_I";
    //        DdlMedium.DataTextField = "MediunNameHindi_V";
    //        DdlMedium.DataBind();
    //        DdlMedium.Items.Insert(0, "Select");
    //    }
    //    catch { }
    //}
    //protected void DdlClass_Init(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DdlClass.DataSource = obCommonFunction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
    //        DdlClass.DataValueField = "ClassTrno_I";
    //        DdlClass.DataTextField = "Classdet_V";
    //        DdlClass.DataBind();
    //        DdlClass.Items.Insert(0, "Select");
    //    }
    //    catch { }
    //}
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Label3.Text = "";
        LoadDataAgainstGrd();
    }
    public void LoadDataAgainstGrd()
    {
        //if (DdlMedium.SelectedItem.Text == "Select" && DdlClass.SelectedItem.Text == "Select")
        //{
        //   // LoadTitlesGrd(Convert.ToInt32(ddlGroupId.SelectedValue));
        //    string Val = "";
        //    foreach (DataListItem dl in DlistGroup.Items)
        //    {
        //        CheckBox chkGroupName = (CheckBox)dl.FindControl("chkGroupName");
        //        Label lblGroupId = (Label)dl.FindControl("lblGroupId");
        //        if (chkGroupName.Checked == true)
        //        {
        //            Val = Val + lblGroupId.Text + ",";
        //        }
        //    }

        //    if (Val != "")
        //    {
        //        LoadTitlesGrd(Val);
        //    }
        //    else
        //    {

        //    }
        //}
        //else
        //{
        foreach (ListItem chk in CheckBoxList1.Items)
        {
            if (chk.Selected == true)
            {
                if (count == 0)
                {
                    count = count + 1;
                    id = chk.Value;
                }
                else
                {
                    id = id + "," + chk.Value;
                }
            }
        }
            PRIN_GroupCreation obGroup = new PRIN_GroupCreation();
            try
            {
                string Val = "";
                foreach (DataListItem dl in DlistGroup.Items)
                {
                    CheckBox chkGroupName = (CheckBox)dl.FindControl("chkGroupName");
                    Label lblGroupId = (Label)dl.FindControl("lblGroupId");
                    if (chkGroupName.Checked == true)
                    {
                        Val = Val + lblGroupId.Text + ",";
                    }
                }

               
                obGroup.ACYear = Convert.ToString(DdlACYear.SelectedValue);
               // obGroup.GroupId = Convert.ToInt32(ddlGroupId.SelectedValue);
                int Mdu = 0, Class = 0;
                //if (DdlMedium.SelectedItem.Text == "Select")
                //{
                //     Mdu = 0;
                //}
                //else
                //{
                //    Mdu = int.Parse(DdlMedium.SelectedItem.Value);
                //}

                //if (DdlClass.SelectedItem.Text == "Select")
                //{
                //    Class = 0;
                //}
                //else
                //{
                //    Class = int.Parse(DdlClass.SelectedItem.Value);
                //}


                //`USP_PRIN002_GroupTitleDetailsLoadSearchNew` (PrintingPaperDetailsa varchar(100), CoverpaperDetailsa varchar(100), BindingDetailsa varchar(100) ,ColourCover1n4_Va varchar(100), ColourCover2n3_Va varchar(100), ColorText_Va varchar(100))
                CommonFuction comm = new CommonFuction();
                DataSet ds = comm.FillDatasetByProc("call USP_PRIN002_GroupTitleDetailsLoadSearchNew('"+id+"','"+DdlACYear.SelectedItem.Text+"','" + Val + "','" + ddlPrintingPaperInformation_V.SelectedItem.Text + "','" + ddlCoverPaperinformation_V.SelectedItem.Text + "','" + Binding.SelectedItem.Text + "','" + ddlColourCover1n4.SelectedItem.Text + "','" + ddlColourCover2n3.SelectedItem.Text + "','" + ddlColourCover.SelectedItem.Text + "','"+ddlTital.SelectedValue+"')");
                grdBooksDes.DataSource = ds.Tables[0];
                grdBooksDes.DataBind();

            }

            catch (Exception ex) { }
            finally { obGroup = null; }
        //}
    }

    protected void DlistGroup_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void chkChoose_CheckedChanged(object sender, EventArgs e)
    {
        double TotalTan=0;
        for (int i = 0; i < grdBooksDes.Rows.Count; i++)
        {
            if (((CheckBox)grdBooksDes.Rows[i].FindControl("chkChoose")).Checked == true)
            {
                TotalTan = TotalTan + Convert.ToDouble(((Label)grdBooksDes.Rows[i].FindControl("Label2")).Text);
                ((TextBox)grdBooksDes.Rows[i].FindControl("txtSubgroup")).Visible = true;
                
                //  txtSubgroup
            }
            else {
                ((TextBox)grdBooksDes.Rows[i].FindControl("txtSubgroup")).Visible = false;
            }
        
        }
        Label1.Text = TotalTan.ToString();
    }
    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem chk in CheckBoxList1.Items)
        {
            if (chk.Selected == true)
            {
                if (count == 0)
                {
                    count = count + 1;
                    id = chk.Value;
                }
                else
                {
                    id = id + "," + chk.Value;
                }
            }
        }
      
       
        CommonFuction comm = new CommonFuction();
        DataSet asdf = comm.FillDatasetByProc("call GetTitleDetailsbyClass('" + id + "')");
        ddlTital.DataSource = asdf.Tables[0];
        ddlTital.DataTextField = "TitleHindi_V";
        ddlTital.DataValueField = "TitleID_I";
        ddlTital.DataBind();
        ddlTital.Items.Insert(0, new ListItem("Select..", "0"));
        //PROCEDURE `db_live_mptbctest`.`GetTitleDetailsbyClass`
    }

    public class PRI_GroupCreationLC
    {
        int _CatID_I,
            _TitleID_I,
            _IsFinal,
            _PriDemandId,
            _GrpID_I,
            _DepoID_I,
            _GrpDetId_I,
            _DelStatus,
            _ClassID_I,
            _BookMarkId;

        string _CategoryNo_V,
               _ColorSchText_V,
               _ColorSchCoverPaper_V,
               _PrintingPaperInformation_V,
               _CoverPaperinformation_V,
               _Bindingdetail_V,
               _AcdYear,
               _GroupNO_V,
               _PrintingCategory_V,
                _BankName_V,
                _BankDetails,
                _BookmarkName_V, _TenderType
               ;


        double _EMDAmount_N;


        public int CatID_I { get { return _CatID_I; } set { _CatID_I = value; } }
        public int TitleID_I { get { return _TitleID_I; } set { _TitleID_I = value; } }
        public int IsFinal { get { return _IsFinal; } set { _IsFinal = value; } }
        public int PriDemandId { get { return _PriDemandId; } set { _PriDemandId = value; } }
        public int GrpID_I { get { return _GrpID_I; } set { _GrpID_I = value; } }
        public int DepoID_I { get { return _DepoID_I; } set { _DepoID_I = value; } }
        public int GrpDetId_I { get { return _GrpDetId_I; } set { _GrpDetId_I = value; } }
        public int DelStatus { get { return _DelStatus; } set { _DelStatus = value; } }
        public int ClassID_I { get { return _ClassID_I; } set { _ClassID_I = value; } }


        public string CategoryNo_V { get { return _CategoryNo_V; } set { _CategoryNo_V = value; } }
        public string ColorSchText_V { get { return _ColorSchText_V; } set { _ColorSchText_V = value; } }
        public string ColorSchCoverPaper_V { get { return _ColorSchCoverPaper_V; } set { _ColorSchCoverPaper_V = value; } }
        public string PrintingPaperInformation_V { get { return _PrintingPaperInformation_V; } set { _PrintingPaperInformation_V = value; } }
        public string CoverPaperinformation_V { get { return _CoverPaperinformation_V; } set { _CoverPaperinformation_V = value; } }
        public string Bindingdetail_V { get { return _Bindingdetail_V; } set { _Bindingdetail_V = value; } }
        public string AcdYear { get { return _AcdYear; } set { _AcdYear = value; } }
        public string GroupNO_V { get { return _GroupNO_V; } set { _GroupNO_V = value; } }
        public string PrintingCategory_V { get { return _PrintingCategory_V; } set { _PrintingCategory_V = value; } }
        public string TenderType { get { return _TenderType; } set { _TenderType = value; } }

        public int BookMarkId { get { return _BookMarkId; } set { _BookMarkId = value; } }

        public string BookmarkName_V { get { return _BookmarkName_V; } set { _BookmarkName_V = value; } }
        public double EMDAmount_N { get { return _EMDAmount_N; } set { _EMDAmount_N = value; } }
        public string BankName_V { get { return _BankName_V; } set { _BankName_V = value; } }
        public string BankDetails { get { return _BankDetails; } set { _BankDetails = value; } }


        //function to load Category
        public DataSet LoadCategory()
        {
            DBAccess obj = new DBAccess();
            DataSet ds = new DataSet();

            obj.execute("USP_PRI009_CategoryMasterLoad", DBAccess.SQLType.IS_PROC);
            obj.addParam("mCatID_I", CatID_I);
            obj.addParam("mACYear", BankDetails);
            ds = obj.records();

            return ds;


        }

        //function to load title
        public DataSet LoadTitle()
        {
            DBAccess obj = new DBAccess();
            DataSet ds = new DataSet();

            obj.execute("USP_ACD001_TitleMasterSelect", DBAccess.SQLType.IS_PROC);
            obj.addParam("mTitleID_I", TitleID_I);
            obj.addParam("mParameter", 0);
            obj.addParam("mParameter2", 0);

            ds = obj.records();

            return ds;


        }

        //function to load title
        public DataSet LoadClass()
        {
            DBAccess obj = new DBAccess();
            DataSet ds = new DataSet();

            obj.execute("USP_ADM014_ClassMaster_Load", DBAccess.SQLType.IS_PROC);
            obj.addParam("id", TitleID_I);
            ds = obj.records();

            return ds;


        }


        // function to Load B

        public DataSet LoadBooksDetails(int status)
        {
            DBAccess obDBAccess = new DBAccess();

            try
            {
                obDBAccess.execute("USP_PRI002_GroupTitleLoad", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("macyear", AcdYear);
                obDBAccess.addParam("mIsFinal", status);
                obDBAccess.addParam("mGrpID_I", GrpID_I);


            }
            catch (Exception feException)
            {
                new Exception(feException.Message);
            }
            return obDBAccess.records();

        }

        //public DataSet LoadBooksDetails(int status) 
        //{
        //    DBAccess obDBAccess = new DBAccess();

        //    try
        //    {
        //        obDBAccess.execute("USP_PRI009_Test", DBAccess.SQLType.IS_PROC);
        //        obDBAccess.addParam("acyear", AcdYear);
        //        obDBAccess.addParam("mIsFinal",status);


        //    }
        //    catch (Exception feException)
        //    {
        //        new Exception(feException.Message);
        //    }
        //    return obDBAccess.records();

        //}


        // function to Change Status of Group ie. form add or remove the titles in Group..
        public int GroupAllotmentStatusChang()
        {
            DBAccess obDBAccess = new DBAccess();
            int i = 0;
            try
            {
                obDBAccess.execute("USP_PRI009_GroupAllotmentStatusUpdate", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mPriDemandId", PriDemandId);
                obDBAccess.addParam("mIsFinal", IsFinal);
                obDBAccess.addParam("mGRPID_I", GrpID_I);

                i = obDBAccess.executeMyQuery();

            }
            catch (Exception feException)
            {
                new Exception(feException.Message);
            }
            return i;
        }

        // function to save Update Group Master information
        public int GroupMasterSaveUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            int i = 0;
            try
            {
                obDBAccess.execute("USP_PRI002_GroupMasterSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mGrpID_I", GrpID_I);
                obDBAccess.addParam("mGroupNO_V", GroupNO_V);
                obDBAccess.addParam("mPrintingCategory_V", PrintingCategory_V);
                obDBAccess.addParam("mDepoID_I", DepoID_I);

                obDBAccess.addParam("mBookMarkId", BookMarkId);
                obDBAccess.addParam("mBookmarkName_V", BookmarkName_V);
                obDBAccess.addParam("mEMDAmount_N", EMDAmount_N);
                obDBAccess.addParam("mBankName_V", BankName_V);
                obDBAccess.addParam("mBankDetails", BankDetails);
                obDBAccess.addParam("mTenderType", TenderType);

                i = Convert.ToInt32(obDBAccess.executeMyScalar());


            }

            catch (Exception ex) { }
            finally { obDBAccess = null; }

            return i;

        }



        // Function to Load Group Details

        public DataSet LoadGroupDetails()
        {
            DBAccess obdbaccess = new DBAccess();

            DataSet ds = new DataSet();
            try
            {
                obdbaccess.execute("USP_PRI002_GroupDetails_Load", DBAccess.SQLType.IS_PROC);
                obdbaccess.addParam("acyear", AcdYear);
                obdbaccess.addParam("mIsFinal", IsFinal);
                obdbaccess.addParam("mGrpID_I", GrpID_I);
                ds = obdbaccess.records();

            }
            catch (Exception ex) { }

            finally { obdbaccess = null; }
            return ds;
        }
        // function to Save Update Group Details

        public int GroupDetailsSaveUpdate(string GroupId)
        {
            DBAccess obDbAccess = new DBAccess();
            int i = 0;
            try
            {
                obDbAccess.execute("USP_PRI002_GroupDetailSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mGrpDetId_I", GrpDetId_I);
                obDbAccess.addParam("mGRPID_I", GrpID_I);
                obDbAccess.addParam("mTextBookID_I", TitleID_I);
                obDbAccess.addParam("mPriDemandID", PriDemandId);
                obDbAccess.addParam("mDelStatus", DelStatus);
                obDbAccess.addParam("mDepoID_I", DepoID_I);
                obDbAccess.addParam("mGroupId", GroupId);
                obDbAccess.addParam("mAcYearid", AcdYear);

                i = obDbAccess.executeMyQuery();

            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return i;

        }



        // function to Load Group
        public DataSet GroupMasterLoad()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();
            try
            {

                obDbAccess.execute("USP_PRI002_GroupMasterLoad", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mGrpID_I", GrpID_I);

                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return ds;

        }

        public DataSet GroupMasterLoadFYYear()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();
            try
            {

                obDbAccess.execute("USP_PRI002_GroupMasterLoadFYYear", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mFYYear", AcdYear);

                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return ds;

        }

        public DataSet GroupMasterLoadFYYearSearch()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();
            try
            {

                obDbAccess.execute("USP_PRI002_GroupMasterLoadFYYearSearch", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mFYYear", AcdYear);
                obDbAccess.addParam("mGroupno", GroupNO_V);

                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return ds;

        }


        public DataSet GroupDetailsLoad()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();
            try
            {

                obDbAccess.execute("USP_PRI002_GroupDetailsLoadonGrPID", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mGrpID_I", GrpID_I);

                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return ds;

        }

        public string GroupDetailsdELETE(int mGrpID_I)
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();
            try
            {

                obDbAccess.execute("USP_PRI002_GroupDetailsdELETE", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mGrpID_I", mGrpID_I);

                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return ds.Tables[0].Rows[0][0].ToString();

        }




        #region ICommon Members

        public int InsertUpdate()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet Select()
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        public DataSet LoadGridView()
        {
            DBAccess obDBaccess = new DBAccess();

            DataSet ds = new DataSet();

            try
            {
                obDBaccess.execute("USP_PRI002_Test1", DBAccess.SQLType.IS_PROC);
                obDBaccess.addParam("macyearid", AcdYear);
                obDBaccess.addParam("mIsFinal", IsFinal);
                obDBaccess.addParam("mGrpID_I", GrpID_I);
                ds = obDBaccess.records();

            }
            catch (Exception ex) { }

            finally { obDBaccess = null; }
            return ds;
        }


        public DataSet LoadGridTitleView()
        {
            DBAccess obDBaccess = new DBAccess();

            DataSet ds = new DataSet();

            try
            {
                obDBaccess.execute("USP_PRI002_GroupGridFill", DBAccess.SQLType.IS_PROC);
                obDBaccess.addParam("macyearid", AcdYear);
                obDBaccess.addParam("mtitleid", TitleID_I);
                obDBaccess.addParam("mclasstrno_i", ClassID_I);
                ds = obDBaccess.records();

            }
            catch (Exception ex) { }

            finally { obDBaccess = null; }
            return ds;
        }

        public int GroupDetailsInsert()
        {
            int i = 0;
            DBAccess obDbAccess = new DBAccess();

            try
            {
                obDbAccess.execute("USP_PRI002_GroupDetailsInsertForLOAD", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mGRPID_I", GrpID_I);
                obDbAccess.addParam("mTextBookID_I", TitleID_I);
                obDbAccess.addParam("mPriDemandID", PriDemandId);
                obDbAccess.addParam("mGrpStatus", IsFinal);
                obDbAccess.addParam("mDepoID_I", DepoID_I);

                i = obDbAccess.executeMyQuery();

            }
            catch (Exception ex)
            { }
            finally { obDbAccess = null; }

            return i;
        }

    }
}