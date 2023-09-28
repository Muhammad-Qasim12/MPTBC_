using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;
//using Yojnaservice;
using MPTBCBussinessLayer.Admin;

public partial class Depo_TranspoterBill : System.Web.UI.Page
{ string ImgStatus, mapFile;
    decimal total_BundleNo_IMin, total_BundleNo_IMin1;
    TransportMaster obTransportMaster = null;
    DPT_DepotMaster obDPT_DepotMaster = new DPT_DepotMaster();
    DBAccess db = new DBAccess();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    Class1 obj = new Class1();
    DataSet ds;


    string uploadCopy;
    //PRI_TenderEvaluation obPriEval = new PRI_TenderEvaluation();
    APIProcedure objapi = new APIProcedure();
    UserMaster objUMaster = new UserMaster();
   //  YF_WebService objWebService = new YF_WebService();

    CommonFuction comm=new CommonFuction ();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obDPT_DepotMaster.DepoTrno_I = 0;
            //DataSet depo = obDPT_DepotMaster.Select();

            //obTransportMaster = new TransportMaster();
            //obTransportMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
            //DataSet obDataSet1 = obTransportMaster.Select();
            //DropDownList1.DataTextField = "TransportName_V";
            //DropDownList1.DataValueField = "TransportID_I";
            //DropDownList1.DataSource = obDataSet1.Tables[0];
            //DropDownList1.DataBind();
            //DropDownList1.Items.Insert(0, "सेलेक्ट..");
           ddlBiltiNo.DataSource= comm.FillDatasetByProc ("call GetChallandataByBiltiNo(0,"+Session["UserID"]+")");
              ddlBiltiNo.DataTextField = "GRNO_Vandate";
            ddlBiltiNo.DataValueField = "GRNO_V";
           // DropDownList1.DataSource = obDataSet1.Tables[0];
            ddlBiltiNo.DataBind();
            ddlBiltiNo.Items.Insert(0, "सेलेक्ट..");
            fillgrd();
            ddlFyYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlFyYear.DataValueField = "AcYear";
            ddlFyYear.DataTextField = "AcYear";
            ddlFyYear.DataBind();
            ddlFyYear.SelectedValue = comm.GetFinYear();
            ddlFyYear_SelectedIndexChanged( sender,  e);
            if (Request.QueryString["ID"] != null)
            {
                ddlBiltiNo.ClearSelection();
                ddlBiltiNo.Items.FindByValue(Request.QueryString["ID"].ToString()).Selected = true;
               // ddlBiltiNo.SelectedValue = Request.QueryString["ID"].ToString();
                ddlBiltiNo_SelectedIndexChanged( sender,  e);
            }
           // fillgrd1();
        }
    }
    public void fillgrd()
    {
//        db.execute(@"select BlockNameHindi_V,TranAmount,BilltrNo, BillNo, DATE_FORMAT(Billdate,'%d/%m/%Y')Bdate, BiltiNo,DATE_FORMAT(BiltiDate,'%d/%m/%Y')BiltiD , Amount, NoofBandal, DepoId, TransPoterID,TransportName_V from dpt_transpotbilldetails
//inner join dpt_transport_m on dpt_transport_m.TransportID_I=dpt_transpotbilldetails.TransPoterID
//inner join adm_blockmaster on adm_blockmaster.BlockTrno_I=dpt_transpotbilldetails.BlockID where DepoId=" + Convert.ToInt32(Session["UserID"]) + " and Status", DBAccess.SQLType.IS_QUERY);

        DataSet grds = comm.FillDatasetByProc("call GetFillgrd(0,"+Convert.ToInt32(Session["UserID"])+",0)");
        GridView1.DataSource = grds.Tables[0];
        GridView1.DataBind();
    }
    public void fillgrd1()
    {
        DataSet grds = comm.FillDatasetByProc("call GetFillgrd(1," + Convert.ToInt32(Session["UserID"]) + ",0)");
        GridView2.DataSource = grds.Tables[0];
        GridView2.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
       
        APIProcedure api = new APIProcedure();
       
        CommonFuction comm = new CommonFuction();
        if (HiddenField1.Value != "")
        {
            if (FileUpload1.FileName == "")
            {
                ImgStatus = "Ok";
            }
            else
            {
                ImgStatus = api.SingleuploadFile(FileUpload1, "billDetails", 1024);
                mapFile = api.FullFileName;
            }
            ds = comm.FillDatasetByProc("call USP_TransProterBillAdd('" + txtbillNo.Text + "','" + Convert.ToDateTime(txtdate.Text, cult).ToString("yyyy-MM-dd") + "','" + ddlBiltiNo.SelectedValue + "','01/01/1900'," + lblAmount.Text + ",'" + lblbandal.Text + "'," + Convert.ToInt32(Session["UserID"]) + "," + DropDownList1.SelectedValue + "," + HiddenField1.Value + "," + lbltan.Text + ",'" + txtRemark.Text + "','" + mapFile + "'," + txtbillAmount.Text + ",'" + ddlFyYear.SelectedItem.Text + "','"+HiddenField2.Value+"')");
           //    string LastID = ds.Tables[0].Rows[0][0].ToString();Tan, Remark, uploadCopy, TranAmount
        //    if (LastID != "")
        //    {
        //        string PrathamUId = "", BranchId = "", CreatedByEmpId = "", newGuid = "";
        //        CommonFuction obCommonFuction = new CommonFuction();
        //        if (DropDownList1.SelectedItem.Value.ToString() != "0")
        //        {
        //            ds = objUMaster.PrathamIdSelect(Session["UserID"].ToString(), 3, DropDownList1.SelectedItem.Value);
        //            if (ds.Tables[1].Rows.Count > 0)
        //            {
        //                newGuid = ds.Tables[1].Rows[0][0].ToString();
        //            }
        //        }
        //        else
        //        {
        //            ds = objUMaster.PrathamIdSelect(Session["UserID"].ToString(), 1, "");
        //        }
        //        PrathamUId = ds.Tables[0].Rows[0]["PrathamUserId"].ToString();
        //        BranchId = ds.Tables[0].Rows[0]["BranchId"].ToString();
        //        CreatedByEmpId = ds.Tables[0].Rows[0]["EmployeeID_I"].ToString();
        //        byte PaymentType = 0;

        //        DateTime DateRec = new DateTime();
        //        DateTime CheqDate = new DateTime();
        //        DateRec = DateTime.Parse(txtDate.Text, cult);
        //        string Instrumentxml = "", Billxml = "", deduction_detailsxml = "",
        //            InstGuid = Guid.NewGuid().ToString(); ;

        //        Billxml = @"<DocumentElement>  <TGBPDDETAIL>  <TGBPD_COLUMNID>00034</TGBPD_COLUMNID>  <TGBPD_COLUMNVALUE>" + txtBillNo.Text + "</TGBPD_COLUMNVALUE> </TGBPDDETAIL>" +
        // "<TGBPDDETAIL> <TGBPD_COLUMNID>00036</TGBPD_COLUMNID> <TGBPD_COLUMNVALUE>" + txtDate.Text + "</TGBPD_COLUMNVALUE> </TGBPDDETAIL>" +
        // "<TGBPDDETAIL><TGBPD_COLUMNID>00041</TGBPD_COLUMNID> <TGBPD_COLUMNVALUE>" + newGuid.ToString() + "</TGBPD_COLUMNVALUE></TGBPDDETAIL>" +
        //"<TGBPDDETAIL> <TGBPD_COLUMNID>00004</TGBPD_COLUMNID><TGBPD_COLUMNVALUE>" + txtAmount.Text + "</TGBPD_COLUMNVALUE> </TGBPDDETAIL> " +
        //"<TGBPDDETAIL> <TGBPD_COLUMNID>00035</TGBPD_COLUMNID><TGBPD_COLUMNVALUE>Transport Bill From Depot Bilti No :" + txtBiltiNo.Text + "</TGBPD_COLUMNVALUE></TGBPDDETAIL>" +
        // "</DocumentElement>";
        //        if (newGuid != "")
        //        {
        //            ds = objWebService.Save_Inter_Depo_Distribution(DateRec.ToString("yyyy/MM/dd"), CreatedByEmpId, newGuid.ToString(), "Transport Bill From Depo", "", 0, 0, txtAmount.Text, 0, 0, 0, 0, CreatedByEmpId, 0,
        //                txtAmount.Text, Billxml, objapi.DepoHeadIDSendToID(BranchId), "Transport Bill From Depo Bill No :" + txtBillNo.Text + "-" + DropDownList1.SelectedItem.Text, System.DateTime.Now.ToString("yyyy/MM/dd"), BranchId, PrathamUId, null);

        //            obPriEval.UpdateDepoTranBillHr(ds.Tables[0].Rows[0][1].ToString(), LastID.ToString(), int.Parse(LastID));
        //        }
        //        txtAmount.Text = "";
        //        txtBandalNo.Text = "";
        //        txtBiltiNo.Text = "";
        //        txtBiltiDate.Text = "";
                fillgrd();
                HiddenField2.Value = "";
                HiddenField1.Value = "";
            
            //}

         
        }
        comm.EmptyTextBoxes(this);
    }
    
    protected void ddlBiltiNo_SelectedIndexChanged(object sender, EventArgs e)
{
    try {
    DataSet ds = comm.FillDatasetByProc("call GetChallandataByBiltiNo(1," + ddlBiltiNo.SelectedValue + ")");
    lblbandal.Text = ds.Tables[0].Rows[0]["TotalBandle"].ToString();
    lblBlockName.Text = ds.Tables[0].Rows[0]["BlockName_V"].ToString();
    lblChallanNo.Text = ds.Tables[0].Rows[0]["ChallanNo_V"].ToString();
    lblDriverName.Text = ds.Tables[0].Rows[0]["TruckNo_V"].ToString();
    lblDriverNo.Text = ds.Tables[0].Rows[0]["DriverMobileNo_V"].ToString();
    lblLoojbandal.Text = ds.Tables[0].Rows[0]["LoojBandal"].ToString();
    lblLoojbooks.Text = ds.Tables[0].Rows[0]["loojbooks"].ToString();
    lblPaikBandal.Text = ds.Tables[0].Rows[0]["PaikBandal"].ToString();
    lblPaikBook.Text = ds.Tables[0].Rows[0]["paikBooks"].ToString();
    lblTotalBook.Text = ds.Tables[0].Rows[0]["DestributeBook"].ToString();
    lbltan.Text = ds.Tables[0].Rows[0]["TotalTan"].ToString();
    HiddenField1.Value = ds.Tables[0].Rows[0]["BlockID_I"].ToString();
    HiddenField2.Value = ds.Tables[0].Rows[0]["typeA"].ToString();
    DataSet ds1 = comm.FillDatasetByProc("call GetAmountbybadle('" + ddlFyYear.SelectedItem.Text + "'," + HiddenField1.Value + "," + DropDownList1.SelectedValue + "," + ds.Tables[0].Rows[0]["TotalTan"].ToString() + "," + ds.Tables[0].Rows[0]["TotalBandle"].ToString() + ",'" + ds.Tables[0].Rows[0]["typeA"].ToString() + "')");
    lblAmount.Text = ds1.Tables[0].Rows[0]["Amount"].ToString();
    lblFulltruck.Text = ds1.Tables[0].Rows[0]["Fulltruck"].ToString();
    lblhulftuck.Text = ds1.Tables[0].Rows[0]["Halftruck"].ToString();
    lblPratibadle.Text = ds1.Tables[0].Rows[0]["PerBundle"].ToString();
    aa.Style.Add("display", "block");
    }
    catch { }
}


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        comm.FillDatasetByProc("call USPDeleteBill(" + GridView1.DataKeys[e.RowIndex] + ")");
        fillgrd();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                
                try
                {
                    total_BundleNo_IMin += e.Row.Cells[8].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[8].Text);
                }
                catch { }
                try
                {
                    total_BundleNo_IMin1 += e.Row.Cells[9].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[9].Text);
                }
                catch { }
                

            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label FToNo_I0 = (Label)e.Row.FindControl("FToNo_I0");
            Label lblFLoojBook = (Label)e.Row.FindControl("lblFLoojBook");
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[8].Text = total_BundleNo_IMin.ToString();
            e.Row.Cells[9].Text = total_BundleNo_IMin1.ToString();
          
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        DataSet grds = comm.FillDatasetByProc("call GetFillgrd(2," + Convert.ToInt32(Session["UserID"]) + ",0)");
        fillgrd1();
        fillgrd();
        aa.Style.Add("display", "none");
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;

        fillgrd1();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlFyYear_SelectedIndexChanged(object sender, EventArgs e)
    {
     // ddl 
   
    DropDownList1.DataTextField = "TransportName_V";
    DropDownList1.DataValueField = "TransportID_I";
    DropDownList1.DataSource = comm.FillDatasetByProc("call GetTranspoternameByyear('" + ddlFyYear.SelectedValue + "'," + Session["UserID"] + ")");
    DropDownList1.DataBind();
    }
}