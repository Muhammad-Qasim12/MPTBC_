using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using MPTBCBussinessLayer.Paper;
using System.IO ;
using System.Net ;
public partial class Depo_ScheamBookDistribution : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    string ClassID;
    string SubQuery;
    string SubQuery1; CommonFuction obCommonFuction = new CommonFuction();
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
            //txtNofBooks/lblAbook
            //txtNofBooks
            TextBox txtPerbundlebook = (TextBox)sender;
            //txtPerbundlebook
            GridViewRow grdrow = (GridViewRow)txtPerbundlebook.NamingContainer;
           TextBox  txtNofBooks =(TextBox)grdrow.FindControl("txtNofBooks");
            TextBox lblnoofbooks = (TextBox)grdrow.FindControl("lblnoofbooks");
            Label lblAbook = (Label)grdrow.FindControl("lblAbook");
            TextBox txtPackbundle = (TextBox)grdrow.FindControl("txtPackbundle");
            TextBox txtloose = (TextBox)grdrow.FindControl("txtloose");
            TextBox txtPerbundlebook1 = (TextBox)grdrow.FindControl("txtPerbundlebook");
            if ((Convert.ToInt32(txtNofBooks.Text) - Convert.ToInt32(lblAbook.Text)) < (Convert.ToInt32(lblnoofbooks.Text)))
            {
                lblnoofbooks.Text = "0";
                txtPackbundle.Text ="0";
                txtloose.Text = "0";
                return;
            }
            else
            {
               
                var pack = Convert.ToInt32(lblnoofbooks.Text) / Convert.ToInt32(txtPerbundlebook1.Text);
                var loose = Convert.ToInt32(lblnoofbooks.Text) % Convert.ToInt32(txtPerbundlebook1.Text);
                txtPackbundle.Text = pack.ToString();
                txtloose.Text = loose.ToString();
            }
           
        }
        catch { }



    }
    protected void btnSaveMasterData_Click(object sender, EventArgs e)
    {
        btnPrint.Visible = true;
        btnSchemeWise.Visible = true;
        if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "4")
        {
            ClassID = "1,2,3,4,5,6,7,8";
        }
        else if (DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3")
        {
            ClassID = "9,10,11,12";
        }
        if (DdlDistrict.SelectedIndex == 0)
        { }
        else {
        //ClassTrno_I
        CommonFuction obCommonFuction = new CommonFuction();
//        DataSet ds = obCommonFuction.FillDatasetByProc(@"SELECT ifnull((select  sum(DestributeBook)DestributeBook from dpt_distributchallanreceipt inner join dpt_stockdistributionschemeentry_m on dpt_stockdistributionschemeentry_m.StockDistributionSEntryID_I=masterid
//where userID=" + Session["UserID"] + " and BlockID_I='" + ddlBlock.SelectedValue + "'  and schemeid=" + ddlMedium.SelectedValue + " and TitalID=dis_textbookdemand_t.titleid),0) as PradayBook, ifnull((select  max(cast(ToNo_I   as decimal)-cast(FromNo_I  as decimal)) from dpt_stockdetailschild_t  INNER JOIN dpt_stockdetails_t  on dpt_stockdetailschild_t.StockDetailsID_I=dpt_stockdetails_t.StockDetailsID_I inner join dpt_warehouuse_m on dpt_stockdetailschild_t.WareHouseID=dpt_warehouuse_m.WareHouseID_I where dpt_warehouuse_m.UserID_I=" + Session["UserID"] + " and SubJectID_I= dis_textbookdemand_t.titleid and dpt_stockdetails_t.BookType_I=1 )+1,0) perbundlebook,  OrderNO, TitleId, sum(NoOfBooks) NoOfBooks, UserId, DepoId, DistrictId, blockId , IsFinal, OrderNO, TitleID_I, Classdet_V,  acd_titledetail.TitleID_I, adm_classmaster.ClassTrno_I, trim(acd_titledetail.TitleEnglish_V) as Title_V,  trim(adm_classmaster.Classdet_V) as Classdet_V FROM         acd_titledetail INNER JOIN adm_classmaster ON acd_titledetail.ClassTrno_I = adm_classmaster.ClassTrno_I   inner  join dis_textbookdemand_t on acd_titledetail.TitleID_I= dis_textbookdemand_t.titleid  where dis_textbookdemand_t.blockId='" + ddlBlock.SelectedValue + "' and dis_textbookdemand_t.Isfinal =1  and depoid ='" + Convert.ToInt32(Session["UserID"]) + "' and NoofBooks <>0 and ACYEARID='" + ddlSessionYear.SelectedItem.Text + "' and medium_I=" + ddlMedium.SelectedValue + " and acd_titledetail.ClassTrno_I in ('" + ClassID + "') group by TitleId,  DepoId,  blockId ,  OrderNO ,ACYEARID order by acd_titledetail.TitleID_I ");
        //  string ID = "perbundlebook > 0";
        //   DataRow[] filter = ds.Tables[0].Select(ID);
            //UserIDA int,BlockID_IA int,schemeidA int,ACYEARIDA Varchar(100),ClassIDA varchar(100),medium_IA int
        DataSet ds = obCommonFuction.FillDatasetByProc("call USP_DPT_ShcemeBookDeistributionNew(" + Session["UserID"] + ",'" + ddlBlock.SelectedValue + "','" + ddlSessionYear.SelectedValue + "','" + ClassID + "'," + ddlMedium.SelectedValue + "," + DDlDemandType.SelectedValue + ")");
        DataTable dt = ds.Tables[0];
        DataTable dt1 = ds.Tables[0];
       dt.DefaultView.RowFilter = "perbundlebook >0";
        grBook.DataSource = dt;
        grBook.DataBind();
        //foreach (GridViewRow grdrow in grBook.Rows)
        //{
        //    try
        //    {
        //        CheckBox chk=(CheckBox)grdrow.FindControl("CheckBox1");
        //        TextBox txtPerbundlebook = (TextBox)grdrow.FindControl("txtPerbundlebook");
        //        TextBox lblnoofbooks = (TextBox)grdrow.FindControl("lblnoofbooks");
        //        TextBox txtnoofbooks = (TextBox)grdrow.FindControl("txtNofBooks");
        //        Label lblAbook = (Label)grdrow.FindControl("lblAbook");
        //        TextBox txtPackbundle = (TextBox)grdrow.FindControl("txtPackbundle");
        //        TextBox txtloose = (TextBox)grdrow.FindControl("txtloose");
        //        var pack = Convert.ToInt32(lblnoofbooks.Text) / Convert.ToInt32(txtPerbundlebook.Text);
        //        var loose = Convert.ToInt32(lblnoofbooks.Text) % Convert.ToInt32(txtPerbundlebook.Text);
        //        txtPackbundle.Text = pack.ToString();
        //        txtloose.Text = loose.ToString();
        //        if (lblAbook.Text == txtnoofbooks.Text)
        //        {
        //            chk.Enabled = false;
        //            lblnoofbooks.Enabled = false;
        //        }
        //    }
        //    catch { }
        //}
        }
    }
    protected void btnSchemeWise_Click(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        fadeDiv.Style.Add("display", "block");
        Messages.Style.Add("display", "block");
        SubQuery = "";
        comm.FillDatasetByProc("call Dpt_TempTableDatasave(2,'" + ddlBlock.SelectedItem.Text + "','" + DdlDistrict.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "','" + ddlMedium.SelectedValue + "','" + txtChalanNo.Text + "','',0,0 , 0,0,'" + ddlBlock.SelectedValue + "',0,'" + ddlSessionYear.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "')");
        for (int i = 0; i < grBook.Rows.Count; i++)
        {
            if (((CheckBox)grBook.Rows[i].FindControl("CheckBox1")).Checked == true)
            {
                if (((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text == grBook.Rows[i].Cells[5].Text || Convert.ToInt32(((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text) < Convert.ToInt32(((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text))
                {

                }
                else
                {
                   // comm.FillDatasetByProc("call Dpt_TempTableDatasave(0,'" + ddlBlock.SelectedItem.Text + "','" + DdlDistrict.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "','" + ddlMedium.SelectedValue + "','" + txtChalanNo.Text + "',''," + ((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text + " , " + ((TextBox)grBook.Rows[i].FindControl("txtPackbundle")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtloose")).Text + ",'" + ddlBlock.SelectedValue + "'," + ((HiddenField)grBook.Rows[i].FindControl("HiddenField1")).Value + ",'"+ddlSessionYear.SelectedItem.Text+"','"+DropDownList1.SelectedItem.Text+"')");

                    if (SubQuery == "")
                    {
                        SubQuery = SubQuery + "('" + ddlBlock.SelectedItem.Text + "','" + DdlDistrict.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "','" + ddlMedium.SelectedValue + "','" + txtChalanNo.Text + "',''," + ((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text + " , " + ((TextBox)grBook.Rows[i].FindControl("txtPackbundle")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtloose")).Text + ",'" + ddlBlock.SelectedValue + "'," + ((HiddenField)grBook.Rows[i].FindControl("HiddenField1")).Value + ",'" + ddlSessionYear.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "')";
                    }
                    else {
                        SubQuery = SubQuery + ",('" + ddlBlock.SelectedItem.Text + "','" + DdlDistrict.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "','" + ddlMedium.SelectedValue + "','" + txtChalanNo.Text + "',''," + ((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text + " , " + ((TextBox)grBook.Rows[i].FindControl("txtPackbundle")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtloose")).Text + ",'" + ddlBlock.SelectedValue + "'," + ((HiddenField)grBook.Rows[i].FindControl("HiddenField1")).Value + ",'" + ddlSessionYear.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "')";
               }
                }
                  
            }
        }
        comm.FillDatasetByProc(@"  INSERT INTO dpt_teamchallandetails (BlockName,DistName, ReceiverName, Medium, ChallanNo,BookName,Avantan,Praday,TotalBandl, LoojBandal,                                                                                                               BlockID,
TitleID, Fyyesr,Praptkarta)values " + SubQuery + "");

        if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2")
        {
            ClassID = "1-8";
        }
        else
        {
            ClassID = "9-12";
        }

        try
        {
            DataSet dd4 = comm.FillDatasetByProc("truncate table BookData");
        }
        catch { }
        DataSet dd3 = comm.FillDatasetByProc("call procedure1q( 0," + ddlBlock.SelectedValue + ",'" + ddlSessionYear.SelectedValue+ "',0," + Session["UserID"] + ")");
        // DataSet dd = comm.FillDatasetByProc("SELECT SchemeId," + Request.QueryString["ChallanID"] + " as ChallanNO , SchemeName_Hindi FROM adm_schememaster where classes='" + classID + "' ");
        DataSet dd = comm.FillDatasetByProc("select distinct adm_schememaster.SchemeId,SchemeName_Hindi," + txtChalanNo.Text+ " as ChallanNO  from adm_schememaster inner join BookData on BookData.SchemeID=adm_schememaster.SchemeId where BlockIDA=" + ddlBlock.SelectedValue+ " order by SchemeId asc");
        grdview.DataSource = dd.Tables[0];
        grdview.DataBind();
       // Response.Redirect("schemeWiseChallan.aspx?blockID=" + ddlBlock.SelectedValue + "&Fyyear=" + ddlSessionYear.SelectedValue + "&ChallanID=" + txtChalanNo.Text + "&ClassID=" + DropDownList1.SelectedValue + "");
    }

    protected void btnSchemeWise1_Click(object sender, EventArgs e)
    {
        fadeDiv.Style.Add("display", "none");
        Messages.Style.Add("display", "none");
        }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
          CommonFuction obCommonFuction = new CommonFuction();
        DataSet ddd1 = obCommonFuction.FillDatasetByProc("select distinct OrderNO from dis_textbookdemand_t where blockId=" + ddlBlock.SelectedValue + " and AcYearId='" + ddlSessionYear.SelectedItem.Text + "'and  IsFinal=1");
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
        try
        {
            obCommonFuction.FillDatasetByProc("call UPdateDetails(" + DDlDemandType.SelectedValue + "," + ds.Tables[0].Rows[0]["retvalue"].ToString() + ",'"+ddlSessionYear.SelectedValue+"')");
        }
        catch { }
        SubQuery = ""; SubQuery1 = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
        
        CommonFuction comm = new CommonFuction();
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
                    if (SubQuery == "")
                    {
                        SubQuery = SubQuery + "(" + Convert.ToString(dr[0]) + ",'" + txtChalanNo.Text + "'," + ((HiddenField)grBook.Rows[i].FindControl("HiddenField1")).Value + "," + ((TextBox)grBook.Rows[i].FindControl("txtPerbundlebook")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtPackbundle")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtloose")).Text + "," + ddlMedium.SelectedValue + ",0)";
                    }
                    else
                    {
                        SubQuery = SubQuery + ",(" + Convert.ToString(dr[0]) + ",'" + txtChalanNo.Text + "'," + ((HiddenField)grBook.Rows[i].FindControl("HiddenField1")).Value + "," + ((TextBox)grBook.Rows[i].FindControl("txtPerbundlebook")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtPackbundle")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtloose")).Text + "," + ddlMedium.SelectedValue + ",0)";
                    }
                    if (SubQuery1 == "")
                    {
                        SubQuery1 = SubQuery1 + "('" + ddlBlock.SelectedItem.Text + "','" + DdlDistrict.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "','" + ddlMedium.SelectedValue + "','" + txtChalanNo.Text + "',''," + ((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text + " , " + ((TextBox)grBook.Rows[i].FindControl("txtPackbundle")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtloose")).Text + ",'" + ddlBlock.SelectedValue + "'," + ((HiddenField)grBook.Rows[i].FindControl("HiddenField1")).Value + ",'" + ddlSessionYear.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "')";
                    }
                    else
                    {
                        SubQuery1 = SubQuery1 + ",('" + ddlBlock.SelectedItem.Text + "','" + DdlDistrict.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "','" + ddlMedium.SelectedValue + "','" + txtChalanNo.Text + "',''," + ((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text + " , " + ((TextBox)grBook.Rows[i].FindControl("txtPackbundle")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtloose")).Text + ",'" + ddlBlock.SelectedValue + "'," + ((HiddenField)grBook.Rows[i].FindControl("HiddenField1")).Value + ",'" + ddlSessionYear.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "')";
                    }
                  //  comm.FillDatasetByProc("call USP_DptBlockChallanSave(" +Convert.ToString(dr[0]) + ",'" + txtChalanNo.Text + "'," + ((HiddenField)grBook.Rows[i].FindControl("HiddenField1")).Value + "," + ((TextBox)grBook.Rows[i].FindControl("txtPerbundlebook")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtPackbundle")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtloose")).Text + "," + ddlMedium.SelectedValue+ ")");
                    
                   // comm.FillDatasetByProc("call Dpt_TempTableDatasave(0,'" + ddlBlock.SelectedItem.Text + "','" + DdlDistrict.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "','" + ddlMedium.SelectedValue + "','" + txtChalanNo.Text + "',''," + ((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text + " , " + ((TextBox)grBook.Rows[i].FindControl("txtPackbundle")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtloose")).Text + ",'" + ddlBlock.SelectedValue + "'," + ((HiddenField)grBook.Rows[i].FindControl("HiddenField1")).Value + ",'" + ddlSessionYear.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "')");
                }
            }
        }
        comm.FillDatasetByProc(@"insert into dpt_distributchallanreceipt(MasterID, ChallanID, TitalID, PerBandlbook, ReceivedBook, DestributeBook, PaikBandal, LoojBandal,schemeid,SendStatus)
  values " + SubQuery + "");
        comm.FillDatasetByProc(@"INSERT INTO dpt_teamchallandetails(BlockName,DistName,ReceiverName,Medium,ChallanNo,BookName,Avantan,Praday,TotalBandl,LoojBandal,BlockID,TitleID,Fyyesr,Praptkarta)VALUES " + SubQuery1 + "");
          
            
            
            
            
            try
        {
            //DataSet ds2;
            //MailHelper objSendSms = new MailHelper();
            //PPR_RDLCData objGetMobile = new PPR_RDLCData();
            //string Msg = "", DepotMoblNo = "";
            ////Usp_Get_SMS_MobileNo
            //ds2 = new DataSet();
            //ds2 = obCommonFuction.FillDatasetByProc("CALL Usp_Get_SMS_MobileNo()");
            //Msg = "Date of dispatch " + System.DateTime.Now.ToString("dd/MM/yyyy") + " BRC/BEO Name " + ddlBlock.SelectedItem.Text + " Vehicle No  " + txtTrucko.Text + " Driver contact no " + txtDriverMobileNo.Text + ",Depot Name: " + Session["UserName"];
            //Msg = "Received as per Challan No : " + lblchalan.Text.Trim() + "  and date " + lblchalandate.Text + " On " + txtPdate.Text + " Date";
            //foreach (DataRow Dr in ds2.Tables[0].Rows)
            //{
            //    if (Dr["Flag"].ToString() == "DGM" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Distribution")
            //    {
            //        try
            //        {
            //            objSendSms.sendMessage(Dr["MobileNo"].ToString(), Msg);
            //        }
            //        catch { }
            //    }
            //    if (Dr["Flag"].ToString() == "DGM" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Printing")
            //    {
            //        try
            //        {
            //            objSendSms.sendMessage(Dr["MobileNo"].ToString(), Msg);
            //        }
            //        catch { }
            //    }
            //}
            //try
            //{
            //    // Paper Vendor
            //    ds2 = new DataSet();
            //    ds2 = obCommonFuction.FillDatasetByProc("CALL GetMobleNumberDeport(" + Session["UserID"] + ",0,0)");
            //    objSendSms.sendMessage(ds2.Tables[0].Rows[0]["mobno_v"].ToString(), Msg);
            //}
            //catch { }

            RKSKNew obj = new RKSKNew();
            obj.BookDispatchDetailsByChallan(txtChalanNo.Text);
        }
        catch { } 
            

        }
      // DataSet dd4 = obCommonFuction.FillDatasetByProc("call procedure1q( 0," + ddlBlock.SelectedValue + ",'" + ddlSessionYear.SelectedValue + "',0," + Session["UserID"] + ")");
       //DataSet dd4 = obCommonFuction.FillDatasetByProc("call procedure1q( 0," + ddlBlock.SelectedValue + ",'" + ddlSessionYear.SelectedValue + "','" + txtChalanNo.Text + "'," + Session["UserID"] + ")");
      // DataSet dd3 = obCommonFuction.FillDatasetByProc("call procedure1q( 1," + ddlBlock.SelectedValue + ",'" +ddlSessionYear.SelectedValue + "','"+txtChalanNo.Text+"'," + Session["UserID"] + ")");
       Response.Redirect("View_DPT014.aspx?ChallanNo=" + txtChalanNo.Text + "");

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

    protected void grdDailyTask_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        CommonFuction comm = new CommonFuction();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int CountryId;
            GridView gv = (GridView)e.Row.FindControl("grdview1");
            // ((HtmlImage)e.Row.FindControl("imgAddReason")).Visible = false;
            try
            {
                CountryId = Convert.ToInt32(((HiddenField)e.Row.FindControl("HID")).Value);
                DataSet dd1 = comm.FillDatasetByProc(" select * from BookData where Praday<>0 and SchemeID=" + CountryId + " ");
                gv.DataSource = dd1.Tables[0];
                gv.DataBind();
                //sd.Fill_Grid(gv, "select Sno ,OrganizationName ,convert(varchar,DateOfVisti,106) DateOfVisti,convert(varchar,NextVistDate,106)NextVistDate ,RemarkAsOn,NoOfVisitsmade ,CallStatus from EmpDailyReport('" + Convert.ToDateTime(TextBox1.Text, cul).ToString("MM/dd/yyyy") + "','" + Convert.ToDateTime(TextBox2.Text, cul).ToString("MM/dd/yyyy") + "'," + CountryId + ")");
            }
            catch { }

        }
    }
    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltype.SelectedValue == "1")
        {
            DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS001_DemandTypeMasterLoadNew('" + ddlSessionYear.SelectedItem.Text + "',1)");
            DDlDemandType.DataValueField = "DemandTypeId";
            DDlDemandType.DataTextField = "DemandTypeHindi";
            DDlDemandType.DataBind();
        }
        else
        {
            DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS001_DemandTypeMasterLoadNew('" + ddlSessionYear.SelectedItem.Text + "',0)");
            DDlDemandType.DataValueField = "DemandTypeId";
            DDlDemandType.DataTextField = "DemandTypeHindi";
            DDlDemandType.DataBind();
        }
    }
}