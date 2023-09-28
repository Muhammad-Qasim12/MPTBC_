using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Collections;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Configuration;
public partial class Depo_BlockChalanReport : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    int count12;
    ArrayList aa = new ArrayList(); string bundleNo;
    int TotalBandal, count1; int total = 0, total112, total113;
    int grdCount1, grdCount2; string bundleNo1; string bundleNoNew = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {

                DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("call USP_DD_SelectDistrict(" + Session["UserID"] + " ,0,0 )");
                DdlDistrict.DataValueField = "DistrictTrno_I";
                DdlDistrict.DataTextField = "District_Name_Hindi_V";
                DdlDistrict.DataBind();
                DdlDistrict.Items.Insert(0, "--Select--");
                // ddlSessionYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
               // Finacual year change 
                ddlSessionYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoadnew(0)");
                ddlSessionYear.DataValueField = "AcYear";
                ddlSessionYear.DataTextField = "AcYear";
                ddlSessionYear.DataBind();
                // ddlSessionYear.SelectedValue = "2018-2019";
                ddlChallano.DataSource = obCommonFuction.FillDatasetByProc(@"select distinct StockDistributionSEntryID_I, ChallanNo_V from dpt_stockdistributionschemeentry_m
inner join dpt_distributchallanreceipt on dpt_distributchallanreceipt.ChallanID=ChallanNo_V
inner join adm_blockmaster on adm_blockmaster.BlockTrno_I=blockID_I  where dpt_stockdistributionschemeentry_m.UserID  ='" + Convert.ToString(Session["UserID"]) + "' and SendStatus not in(1,2) and `YearID`=(SELECT `AcYear` FROM`adm_acadmicyears` WHERE `Isactive`=1);");
                ddlChallano.DataValueField = "StockDistributionSEntryID_I";
                ddlChallano.DataTextField = "ChallanNo_V";
                ddlChallano.DataBind();
                ddlChallano.Items.Insert(0, "select..");

                ddlChallano_SelectedIndexChanged(sender, e);
                if (Request.QueryString["challanID"] != null)
                {
                    ddlChallano.ClearSelection();
                    ddlChallano.Items.FindByText(Request.QueryString["challanID"].ToString()).Selected = true;
                    // ddlChallano.SelectedItem.Text = Request.QueryString["challanID"].ToString();
                    Button3_Click1(sender, e);
                    DataSet ds = obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('','" + ddlChallano.SelectedValue + "',002," + Convert.ToString(Session["UserID"]) + "," + Request.QueryString["TitleID"] + ")");
                    grdPrinterBundleDetails.DataSource = ds;
                    grdPrinterBundleDetails.DataBind();
                    Label2.Text = Request.QueryString["loojBook"];
                    fadeDiv.Style.Add("display", "block");
                    Messages.Style.Add("display", "block");
                }

            }
            catch (Exception ex) { }
        }

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcell();
        }
        catch { }
    }
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "BandelDetails.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - word";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }
    List<Baecode> obBaecodeList = new List<Baecode>();
    public class GenarteLoosebundle
    {
        public string BookNo { get; set; }

    }
    protected void chkIsLooseChange(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkbox = (CheckBox)sender;

            GridViewRow grd = (GridViewRow)(chkbox.NamingContainer);


            List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
            TextBox txtb = (TextBox)grd.FindControl("txtb");
            txtb.Visible = true;
            Label BandalNo = (Label)grd.FindControl("BundleNo_I");
            Label txtf = (Label)grd.FindControl("FromNo_I");
            Label txtPer = (Label)grd.FindControl("lblPer");
            Label txtTo = (Label)grd.FindControl("ToNo_I");
            CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
            CommonFuction comm = new CommonFuction();
            DataSet ds = comm.FillDatasetByProc("call DPT_BlockwiseBandCheck(" + BandalNo.Text + ",0)");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string[] strRemaingLoose = Convert.ToString(ds.Tables[0].Rows[0]["RemaingLoose_V"]).Split(',');


                foreach (string stritem in strRemaingLoose)
                {
                    if (stritem.ToString() != "")
                    {
                        GenarteLoosebundle obGenarteLoosebundle = new GenarteLoosebundle();
                        obGenarteLoosebundle.BookNo = Convert.ToString(stritem);
                        List.Add(obGenarteLoosebundle);
                    }
                }


            }
            else
            {

                if (txtf.Text != "")
                {
                    for (int i = 0; i < Convert.ToInt32(txtPer.Text); i++)
                    {
                        GenarteLoosebundle obGenarteLoosebundle = new GenarteLoosebundle();
                        obGenarteLoosebundle.BookNo = Convert.ToString(Convert.ToInt32(txtf.Text) + i);
                        List.Add(obGenarteLoosebundle);
                        txtTo.Text = Convert.ToString(Convert.ToInt32(txtf.Text) + i);
                    }
                }

            }
            if (chkbox.Checked)
            {
                obChkLooseBundleList.DataSource = List;
                obChkLooseBundleList.DataTextField = "BookNo";
                obChkLooseBundleList.DataBind();


            }
            else
            {
                txtb.Visible = false;

                obChkLooseBundleList.Items.Clear();
            }
        }
        catch { }
    }
    protected void txtonChange_TextChanged(object sender, EventArgs e)
    {

        TextBox TextBox = (TextBox)sender;

        GridViewRow grd = (GridViewRow)(TextBox.NamingContainer);
        //List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
        Label txtf = (Label)grd.FindControl("FromNo_I");
        Label txtPer = (Label)grd.FindControl("lblPer");
        Label txtTo = (Label)grd.FindControl("ToNo_I");

        // CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");

        int id = Convert.ToInt32(TextBox.Text);
        TotalBandal = TotalBandal + id;
        foreach (ListItem items in obChkLooseBundleList.Items)
        {
            count12 = count12 + 1;
            if (id >= count12)
            {
                items.Selected = true;
            }
            else
            { items.Selected = false; }

        }

    }
    //protected void Checkbarcode(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('" + txtBundlenNo.Text + "','" + ddlChallano.SelectedValue + "',0," + Convert.ToString(Session["UserID"]) + "," + ddlBookName.SelectedValue + ")");
    //        Label2.Text = txtBundlenNo.Text;

    //    }
    //    catch { }

    //    txtBundlenNo.Text = "";
    //    txtBundlenNo.Focus();
    //}


    public class Baecode
    {
        public string ChalanNo { get; set; }
        public string Title_I { get; set; }
        public string NameofPress_V { get; set; }
        public string TitleHindi_V { get; set; }
        public string booktype { get; set; }

        public string BundleNo_I { get; set; }
        public string FromNo_I { get; set; }
        public string ToNo_I { get; set; }
        public int StockDetailsID_I { get; set; }

    }

    // Button51_Click
    protected void Button51_Click(object sender, EventArgs e)
    {
        Response.Redirect("addloojbandal.aspx?ChallanID=" + ddlChallano.SelectedItem.Text + "&Hid=" + HiddenField6.Value + "");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            obCommonFuction.FillDatasetByProc("update dpt_distributchallanreceipt set SendStatus=1 where ChallanID=" + ddlChallano.SelectedItem.Text + "");

            Label1.Text = "यह चालान ब्लाक को भेजा जा चुका है ";
            grdPrinterBundleDetails.DataSource = null;
            grdPrinterBundleDetails.DataBind();
            GridView1.DataSource = null;
            GridView1.DataBind();
            Label1.Text = "";
            ddlChallano.DataSource = obCommonFuction.FillDatasetByProc(@"select distinct StockDistributionSEntryID_I, ChallanNo_V from dpt_stockdistributionschemeentry_m
inner join dpt_distributchallanreceipt on dpt_distributchallanreceipt.ChallanID=ChallanNo_V
inner join adm_blockmaster on adm_blockmaster.BlockTrno_I=blockID_I  where dpt_stockdistributionschemeentry_m.UserID  ='" + Convert.ToString(Session["UserID"]) + "' and SendStatus not in(1,2);");
            ddlChallano.DataValueField = "StockDistributionSEntryID_I";
            ddlChallano.DataTextField = "ChallanNo_V";
            ddlChallano.DataBind();
            ddlChallano.Items.Insert(0, "select..");


        }

        catch { }
    }
    protected void grdPrinterBundleDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //try
        //{
        //    obCommonFuction.FillDatasetByProc(@"update dpt_stockdetailschild_t set IsDistribute ='0 ',DistributID ='0' where   StockDetailsChildID_I=" + grdPrinterBundleDetails.DataKeys[e.RowIndex].Value + "");
        //    DataSet ds = obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('','" + ddlChallano.SelectedValue + "',001," + Convert.ToString(Session["UserID"]) + "," + ddlBookName.SelectedValue + ")");
        //    grdPrinterBundleDetails.DataSource = ds;
        //    grdPrinterBundleDetails.DataBind();
        //}
        //catch { }
    }


    protected void ddlChallano_SelectedIndexChanged(object sender, EventArgs e)
    {
        //        DataSet dd = obCommonFuction.FillDatasetByProc(@"select TitleHindi_V,TitalID ,PaikBandal, LoojBandal from dpt_distributchallanreceipt
        //inner join acd_titledetail on acd_titledetail.TitleID_I=TitalID where ChallanID=" + ddlChallano.SelectedItem.Text + "");
        //        //ddlBookName.DataSource = dd;
        //        //ddlBookName.DataTextField = "TitleHindi_V";
        //        //ddlBookName.DataValueField = "TitalID";
        //        //ddlBookName.DataBind();
        //        hdPaikBandal.Value = dd.Tables[0].Rows[0]["PaikBandal"].ToString();
        //        hdLosse.Value = dd.Tables[0].Rows[0]["LoojBandal"].ToString();
        //        ddlBookName.Items.Insert(0, "select..");

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        // DataSet ds = obCommonFuction.FillDatasetByProc(@"select dpt_stockdetailschild_t.* ,TitleHindi_V , case IsOpenMarket when 2 then 'सामान्य' else 'योज़ना' end as booktype from  dpt_stockdetails_t INNER JOIN dpt_stockdetailschild_t on dpt_stockdetailschild_t.StockDetailsID_I=dpt_stockdetails_t.StockDetailsID_I inner join acd_titledetail on dpt_stockdetails_t.SubJectID_I=acd_titledetail.TitleID_I  inner join dpt_warehouuse_m on dpt_stockdetailschild_t.WareHouseID=dpt_warehouuse_m.WareHouseID_I where dpt_warehouuse_m.UserID_I=" + Convert.ToString(Session["UserID"]) + " and  IsDistribute=3 and  DistributID =" + ddlChallano.SelectedValue + "  ");

        //DataSet ds = obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('','" + ddlChallano.SelectedValue + "',001," + Convert.ToString(Session["UserID"]) + ","+ddlBookName.SelectedValue+")");
        //DataSet ds2 = obCommonFuction.FillDatasetByProc("call DPT_BlockwiseBandCheck('',2)");
        //if (Convert.ToString(ds2.Tables[0].Rows[0]["RemaingLoose_V"]) != "")
        //{
        //    Messages.Style.Add("display", "block");
        //    fadeDiv.Style.Add("display", "block");

        //}

        //grdPrinterBundleDetails.DataSource = ds;
        //grdPrinterBundleDetails.DataBind();

    }
    protected void Button3_Click1(object sender, EventArgs e)
    {
        try
        {
            DataSet dt = obCommonFuction.FillDatasetByProc("call USP_looj1(" + ddlChallano.SelectedItem.Text + "," + Session["UserID"].ToString() + ")");

            DataSet ds = obCommonFuction.FillDatasetByProc("Call USP_DPTGetBookDistribute(" + ddlChallano.SelectedItem.Text + "," + Session["UserID"] + "," + ddlChallano.SelectedValue + ",'" + ddlSessionYear.SelectedValue + "')");
            GridView1.DataSource = ds;
            GridView1.DataBind();
            total113 = GridView1.Rows.Count;
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                string aa = GridView1.Rows[i].Cells[5].Text;
                if (aa.ToString() == "&nbsp;")
                {
                    aa = "0";
                }
                if (GridView1.Rows[i].Cells[3].Text != aa && GridView1.Rows[i].Cells[3].Text != "0")
                {
                    ((Button)GridView1.Rows[i].FindControl("Button4")).Visible = true;

                }
                else
                {
                    ((Button)GridView1.Rows[i].FindControl("Button4")).Visible = false;
                    total112 = total112 + 1;
                }

                if (GridView1.Rows[i].Cells[1].Text == aa)
                {
                    ((Button)GridView1.Rows[i].FindControl("Button4")).Visible = false;

                }
                int ra;
                if (GridView1.Rows[i].Cells[5].Text.ToString() == "&nbsp;")
                {
                    ra = 0;
                }
                else
                {
                    ra = Convert.ToInt32(GridView1.Rows[i].Cells[5].Text);
                }
                if (Convert.ToInt32(ra) == Convert.ToInt32(GridView1.Rows[i].Cells[1].Text))
                {
                    ((TextBox)GridView1.Rows[i].FindControl("TextBox1")).Visible = false;
                    ((Button)GridView1.Rows[i].FindControl("btn12")).Visible = false;

                }
                else
                {
                    ((TextBox)GridView1.Rows[i].FindControl("TextBox1")).Visible = true;
                    ((Button)GridView1.Rows[i].FindControl("btn12")).Visible = true;
                }
                if (Convert.ToInt32(ra) == Convert.ToInt32(GridView1.Rows[i].Cells[1].Text))
                {
                    ((FileUpload)GridView1.Rows[i].FindControl("FileUpload1")).Visible = false;
                    ((Button)GridView1.Rows[i].FindControl("Button10")).Visible = false;
                }
                else
                {
                    ((FileUpload)GridView1.Rows[i].FindControl("FileUpload1")).Visible = true;
                    ((Button)GridView1.Rows[i].FindControl("Button10")).Visible = true;
                }

                grdCount1 = grdCount1 + Convert.ToInt32(GridView1.Rows[i].Cells[1].Text);
                grdCount2 = grdCount2 + ra;
            }
            DataSet dd1 = obCommonFuction.FillDatasetByProc("call USP_DPTChallanDetails(" + ddlChallano.SelectedItem.Text + ",0)");
            if (dd1.Tables[0].Rows.Count > 0)
            {
                a.Style.Add("display", "block");
                lblDist.Text = Convert.ToString(dd1.Tables[0].Rows[0]["District_Name_Hindi_V"]);
                lblBlock.Text = Convert.ToString(dd1.Tables[0].Rows[0]["BlockNameHindi_V"]);
                lblChallNo.Text = Convert.ToString(dd1.Tables[0].Rows[0]["ChallanNo_V"]);
                lblChallandate.Text = Convert.ToString(dd1.Tables[0].Rows[0]["ChallanDate_D"]);
                Label10.Text = Convert.ToString(dd1.Tables[0].Rows[0]["DriverMobileNo_V"]);
                Label11.Text = Convert.ToString(dd1.Tables[0].Rows[0]["TruckNo_V"]);
                Label12.Text = Convert.ToString(dd1.Tables[0].Rows[0]["GRNO_V"]);
                Label13.Text = Convert.ToString(dd1.Tables[0].Rows[0]["GRNODate_D"]);
            }
            if (grdCount1 == grdCount2)
            {
                Button1.Visible = true;
                Button6.Visible = true;
            }
            else
            {
                Button1.Visible = false;
                Button6.Visible = false;
            }


        }
        catch { }

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Button bt = (Button)sender;
        GridViewRow grdrow = (GridViewRow)bt.NamingContainer;
        //DataSet ds = obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('','" + ddlChallano.SelectedValue + "',002," + Convert.ToString(Session["UserID"]) + "," + bt.CommandArgument + ")");
        //grdPrinterBundleDetails.DataSource = ds;
        //grdPrinterBundleDetails.DataBind();
        //Label2.Text = grdrow.Cells[3].Text;
        DataSet dt = obCommonFuction.FillDatasetByProc("call Fn_CursorLosseSupply(" + ddlChallano.SelectedItem.Text + "," + bt.CommandArgument + "," + Session["UserID"].ToString() + ")");

        // obCommonFuction.FillDatasetByProc("call Fn_CursorStocklooseforBillNew(" + ddlChallano.SelectedValue + "," + bt.CommandArgument + "," + grdrow.Cells[3].Text + "," + Convert.ToString(Session["UserID"]) + ")");
        // fadeDiv.Style.Add("display", "block");
        // Messages.Style.Add("display", "block");
        //obCommonFuction.FillDatasetByProc("call USP_CreateProcUpdateLooj(" + ddlChallano.SelectedValue + "," + bt.CommandArgument + "," + Convert.ToString(Session["UserID"]) + ")");


        //  HiddenField6.Value = bt.CommandArgument;
        //int count12345 = 0;
        Button3_Click1(sender, e);
        //int count12345 = 0;

        //for (int j = 0; j < grdPrinterBundleDetails.Rows.Count; j++)
        //{
        //    //if (((TextBox)grdPrinterBundleDetails.Rows[j].FindControl("txtb")).Text.ToString() != "")
        //    //{
        //    //    //total = total + Convert.ToInt32(((TextBox)grdPrinterBundleDetails.Rows[j].FindControl("txtb")).Text);
        //    if (count12345 == 0)
        //    { 
        //    TextBox txtb1 = (TextBox)grdPrinterBundleDetails.Rows[j].FindControl("txtb"); //(TextBox)grd.FindControl("txtb");
        //    txtb1.Visible = true;
        //    txtb1.Text = (Label2.Text);
        //    CheckBox chk = (CheckBox)grdPrinterBundleDetails.Rows[j].FindControl("chkIsLoose");
        //    chk.Checked = true;
        //    Label BandalNo = (Label)grdPrinterBundleDetails.Rows[j].FindControl("BundleNo_I");
        //    Label txtf = (Label)grdPrinterBundleDetails.Rows[j].FindControl("FromNo_I"); //(Label)grd.FindControl("FromNo_I");
        //    Label txtPer = (Label)grdPrinterBundleDetails.Rows[j].FindControl("lblPer");// (Label)grd.FindControl("lblPer");
        //    Label txtTo = (Label)grdPrinterBundleDetails.Rows[j].FindControl("ToNo_I"); //(Label)grd.FindControl("ToNo_I");
        //    CheckBoxList obChkLooseBundleList = (CheckBoxList)grdPrinterBundleDetails.Rows[j].FindControl("ChkLooseBundleList"); //(CheckBoxList)grd.FindControl("ChkLooseBundleList");
        //    List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        //    CommonFuction comm = new CommonFuction();
        //    DataSet ds1 = comm.FillDatasetByProc("call DPT_BlockwiseBandCheck(" + BandalNo.Text + ",0)");
        //    if (ds1.Tables[0].Rows.Count > 0)
        //    {
        //        string[] strRemaingLoose = Convert.ToString(ds1.Tables[0].Rows[0]["RemaingLoose_V"]).Split(',');


        //        foreach (string stritem in strRemaingLoose)
        //        {
        //            if (stritem.ToString() != "")
        //            {
        //                GenarteLoosebundle obGenarteLoosebundle = new GenarteLoosebundle();
        //                obGenarteLoosebundle.BookNo = Convert.ToString(stritem);
        //                List.Add(obGenarteLoosebundle);
        //            }
        //        }


        //    }
        //    else
        //    {

        //        if (txtf.Text != "")
        //        {
        //            for (int i = 0; i < Convert.ToInt32(txtPer.Text); i++)
        //            {
        //                GenarteLoosebundle obGenarteLoosebundle = new GenarteLoosebundle();
        //                obGenarteLoosebundle.BookNo = Convert.ToString(Convert.ToInt32(txtf.Text) + i);
        //                List.Add(obGenarteLoosebundle);
        //                txtTo.Text = Convert.ToString(Convert.ToInt32(txtf.Text) + i);
        //            }
        //        }

        //    }

        //    obChkLooseBundleList.DataSource = List;
        //    obChkLooseBundleList.DataTextField = "BookNo";
        //    obChkLooseBundleList.DataBind();

        //    int id = Convert.ToInt32(Label2.Text);
        //    TotalBandal = TotalBandal + id;
        //    foreach (ListItem items in obChkLooseBundleList.Items)
        //    {
        //        count12 = count12 + 1;
        //        if (id >= count12)
        //        {
        //            items.Selected = true;
        //        }
        //        else
        //        { items.Selected = false; }

        //    }

        //    }
        //    count12345 = count12345 + 1;
        //}
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        fadeDiv.Style.Add("display", "none");
        Messages.Style.Add("display", "none");
    }

    protected void But1_Click(object sender, EventArgs e)
    {
        try
        {


            for (int j = 0; j < grdPrinterBundleDetails.Rows.Count; j++)
            {
                if (((TextBox)grdPrinterBundleDetails.Rows[j].FindControl("txtb")).Text.ToString() != "")
                {
                    total = total + Convert.ToInt32(((TextBox)grdPrinterBundleDetails.Rows[j].FindControl("txtb")).Text);
                }
            }


            if (Convert.ToInt32(Label2.Text) == total)
            {
                fadeDiv.Style.Add("display", "none");
                Messages.Style.Add("display", "none");
                string str1 = "";
                string str2 = "";
                for (int i = 0; i < grdPrinterBundleDetails.Rows.Count; i++)
                {
                    str1 = "";
                    str2 = "";
                    str1 = "'";
                    str2 = "'";
                    CheckBoxList obChkLooseBundleList = (CheckBoxList)grdPrinterBundleDetails.Rows[i].FindControl("ChkLooseBundleList");
                    foreach (ListItem a in obChkLooseBundleList.Items)
                    {

                        if (a.Selected)
                        {
                            if (str1 == "")
                            {

                                str1 = a.Text;
                            }
                            else
                            {
                                count12 = count12 + 1;
                                str1 = str1 + "," + a.Text;
                            }

                        }
                        else
                        {
                            if (str2 == "")
                            {
                                str2 = str2 + a.Text;
                            }
                            else
                            {
                                str2 = str2 + "," + a.Text;
                            }
                        }

                    }
                    str1 = str1 + "'";
                    str2 = str2 + "'";
                    if (str1.ToString() != "''")
                    {
                        if (str2.ToString() == "''")
                        {
                            str2 = ".";
                            obCommonFuction.FillDatasetByProc(@"update dpt_stockdetailschild_t set  IsDistribute ='6',DistributID ='" + ddlChallano.SelectedValue + "', RemaingLoose_V='" + str2 + "',RemainingStock=" + str1 + " ,DistributID =" + ddlChallano.SelectedValue + " where BundleNo_I='" + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I")).Text + "' and  StockDetailsChildID_I=" + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + "");
                            obCommonFuction.FillDatasetByProc("call USP_DPT_dtp_loosebandaldetailsSave ('Block',0,0," + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + "," + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I")).Text + "," + str1 + "," + ddlChallano.SelectedValue + ")");

                        }
                        else
                        {
                            obCommonFuction.FillDatasetByProc(@"update dpt_stockdetailschild_t set  IsDistribute ='0',DistributID ='0', RemaingLoose_V=" + str2 + ",RemainingStock=" + str1 + " ,DistributID =" + ddlChallano.SelectedValue + " where BundleNo_I='" + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I")).Text + "' and  StockDetailsChildID_I=" + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + "");
                            obCommonFuction.FillDatasetByProc("call USP_DPT_dtp_loosebandaldetailsSave ('Block',0,0," + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + "," + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I")).Text + "," + str1 + "," + ddlChallano.SelectedValue + ")");

                        }



                    }

                    str1 = "";
                    str2 = "";

                }
                //Button3_Click1( sender,  e);

            }
            else
            {
                Label8.Text = " आपके द्वारा डाले गए लूज पुस्तक की संख्या दिए जाने वाले पुस्तक की संख्या सामान नहीं  है .";
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert ');</script>");
                fadeDiv.Style.Add("display", "block");
                Messages.Style.Add("display", "block");
            }
            Button3_Click1(sender, e);

        }
        catch { }
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReceiptDetails.aspx?ChallanID=" + ddlChallano.SelectedItem.Text + "");
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Redirect("DistributeYojnaBookWithBarcode.aspx");
    }
    protected void Button112_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        GridViewRow grd = (GridViewRow)(btn.NamingContainer);
        HiddenField hd = (HiddenField)grd.FindControl("HiddenField3");
        DataSet st = obCommonFuction.FillDatasetByProc("call USP_DeleteChallanTitle(" + ddlChallano.SelectedItem.Text + "," + hd.Value + ")");
        Button3_Click1(sender, e);

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBox = (TextBox)sender;

        GridViewRow grd = (GridViewRow)(TextBox.NamingContainer);
        //List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        //    CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
        TextBox txtf = (TextBox)grd.FindControl("TextBox1");
        HiddenField hd = (HiddenField)grd.FindControl("HiddenField3");


        Button btn10 = (Button)grd.FindControl("Button10");
        FileUpload fl = (FileUpload)grd.FindControl("FileUpload1");
        btn10.Visible = false;
        fl.Visible = false;
        string Bandal = grd.Cells[2].Text;

        try
        {
            HiddenField5.Value = grd.Cells[4].Text;
        }
        catch { }
        if (HiddenField5.Value == "&nbsp;")
        {
            HiddenField5.Value = "0";
        }
        HiddenField2.Value = Convert.ToString(Convert.ToInt32(Bandal));
        HiddenField4.Value = hd.Value;
        //HiddenField3
        DataSet dd = obCommonFuction.FillDatasetByProc("call GetBundaleNo(" + Session["UserID"] + "," + hd.Value + "," + txtf.Text + "," + HiddenField2.Value + ")");
        GridView2.DataSource = dd.Tables[0];
        GridView2.DataBind();
        Div1.Style.Add("display", "block");
        Div2.Style.Add("display", "block");
        txtf.Visible = false;
    }
    //
    //protected void Button8_Click(object sender, EventArgs e)
    //{
    //    //if (Convert.ToInt32(HiddenField2.Value) == Convert.ToInt32(GridView2.Rows.Count))
    //    //{
    //        for (int i = 0; i < GridView2.Rows.Count; i++)
    //        {//CheckBox1
    //            if (((CheckBox)GridView2.Rows[i].FindControl("CheckBox1")).Checked == true)
    //            {
    //                obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('" + GridView2.Rows[i].Cells[2].Text + "','" + ddlChallano.SelectedValue + "',0," + Convert.ToString(Session["UserID"]) + "," + HiddenField4.Value + ")");
    //            }
    //        }
    //         Button3_Click1( sender,  e);
    //        Div1.Style.Add("display", "none");
    //        Div2.Style.Add("display", "none");
    //        HiddenField2.Value = "";
    //        HiddenField4.Value = "";
    //    //}
    //    //else
    //    //{
    //    //    Label1.Text = "आपके द्वारा भेजे जाने वाले बंडल की संख्या भेजे जाने वाले बंदला की संख्या से  कम है ";

    //    //}
    //    //Response.Redirect("DistributeYojnaBookWithBarcode.aspx");
    //}
    protected void Button8_Click(object sender, EventArgs e)
    {
        //if (Convert.ToInt32(HiddenField2.Value) == Convert.ToInt32(GridView2.Rows.Count))
        //{
        int count = 0;

        for (int i = 0; i < GridView2.Rows.Count; i++)
        {//CheckBox1
            if (((CheckBox)GridView2.Rows[i].FindControl("CheckBox1")).Checked == true)
            {

                if (count == 0)
                {
                    bundleNo = GridView2.Rows[i].Cells[2].Text;
                }
                else
                {
                    bundleNo = bundleNo + "," + GridView2.Rows[i].Cells[2].Text;
                }
                count = 1;

            }
        }
        obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('" + bundleNo + "','" + ddlChallano.SelectedValue + "',0," + Convert.ToString(Session["UserID"]) + "," + HiddenField4.Value + ")");
        //Button3_Click1(sender, e);
        Div1.Style.Add("display", "none");
        Div2.Style.Add("display", "none");
        HiddenField2.Value = "";
        HiddenField4.Value = "";
        //}
        //else
        //{
        //    Label1.Text = "???? ?????? ???? ???? ???? ???? ?? ?????? ???? ???? ???? ????? ?? ?????? ??  ?? ?? ";

        //}
        //Response.Redirect("DistributeYojnaBookWithBarcode.aspx");
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        Div1.Style.Add("display", "none");
        Div2.Style.Add("display", "none");
        //Response.Redirect("DistributeYojnaBookWithBarcode.aspx");
    }


    protected void Button10_Click(object sender, EventArgs e)
    {
        HiddenField5.Value = "0";
        HiddenField2.Value = "0";
        HiddenField4.Value = "0";
        //hd.Value = "0";
        Button btn = (Button)sender;

        GridViewRow grd = (GridViewRow)(btn.NamingContainer);
        //List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        //    CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
        TextBox txtf = (TextBox)grd.FindControl("TextBox1");
        HiddenField hd = (HiddenField)grd.FindControl("HiddenField3");
        FileUpload FileUploadExcel = (FileUpload)grd.FindControl("FileUpload1");
        //Button btn10 = (Button)grd.FindControl("Button10");
        //FileUpload fl = (FileUpload)grd.FindControl("FileUpload1");
        //btn10.Visible = false;
        //fl.Visible = false;
        txtf.Visible = false;
        string Bandal = grd.Cells[2].Text;
        Label4.Text = ddlChallano.SelectedItem.Text;
        Label3.Text = grd.Cells[0].Text;
        try
        {
            HiddenField5.Value = grd.Cells[4].Text;
        }
        catch { }
        if (HiddenField5.Value == "&nbsp;")
        {
            HiddenField5.Value = "0";
        }
        HiddenField2.Value = Convert.ToString(Convert.ToInt32(grd.Cells[2].Text) - Convert.ToInt32(HiddenField5.Value));
        HiddenField4.Value = hd.Value;
        //HiddenField3
        try
        {
            // excel code
            if (FileUploadExcel.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadExcel.PostedFile.FileName);
                    string Extension = Path.GetExtension(FileUploadExcel.PostedFile.FileName);
                    string filePath = Server.MapPath("~/DepoFileUpload/" + filename);
                    FileUploadExcel.SaveAs(filePath);
                    GridView3.DataSource = ImportTogrid(filePath, Extension, "Yes");
                    GridView3.DataBind();
                    Div3.Style.Add("display", "block");
                    Div4.Style.Add("display", "block");
                }
                catch { }
            }
        }
        catch (Exception ex) { }
        finally { }
        //DataSet dd = obCommonFuction.FillDatasetByProc("call GetBundaleNo(" + Session["UserID"] + "," + hd.Value + "," + txtf.Text + "," + HiddenField2.Value + ")");
        //GridView3.DataSource = dd.Tables[0];
        //GridView3.DataBind();
        //Div3.Style.Add("display", "block");
        //Div4.Style.Add("display", "block");
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        Div3.Style.Add("display", "none");
        Div4.Style.Add("display", "none");
        //Response.Redirect("DistributeYojnaBookWithBarcode.aspx");
    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        //Button btn = (Button)sender;

        //GridViewRow grd = (GridViewRow)(btn.NamingContainer);
        string Bandal = HiddenField2.Value;
        try
        {

            for (int i = 0; i < (GridView3.Rows.Count); i++)
            {

                //if (((CheckBox)GridView3.Rows[i].FindControl("CheckBox1")).Checked == true)
                //{//`CheckBandleNo` (BundleNo_IA int ,SubJectID_IA int ,UserID_IA int)
                //    DataSet ss = obCommonFuction.FillDatasetByProc("call CheckBandleNo ('" + GridView3.Rows[i].Cells[2].Text + "'," + HiddenField4.Value + "," + Convert.ToString(Session["UserID"]) + ")");
                //    if (ss.Tables[0].Rows.Count > 0)
                //    {
                //        GridView3.Rows[i].Cells[2].BackColor = System.Drawing.Color.Green;
                //    }
                //    else
                //    {
                //        GridView3.Rows[i].Cells[2].BackColor = System.Drawing.Color.Red;
                //    }
                //    try { 
                //    DataSet dd = obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('" + GridView3.Rows[i].Cells[2].Text + "','" + ddlChallano.SelectedValue + "',0," + Convert.ToString(Session["UserID"]) + "," + HiddenField4.Value + ")");
                //    }
                //    catch { }

                //    }

                int count12 = 0;

                if (Convert.ToInt32(Bandal) == count12)
                {

                }
                else
                {
                    if (count12 == 0)
                    {
                        bundleNo1 = GridView3.Rows[i].Cells[2].Text;
                    }
                    else
                    {
                        bundleNo1 = bundleNo1 + "," + GridView3.Rows[i].Cells[2].Text;
                    }
                }
                count12 = count12 + 1;
            }



            obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('" + bundleNo1 + "','" + ddlChallano.SelectedValue + "',0," + Convert.ToString(Session["UserID"]) + "," + HiddenField4.Value + ")");
            Button3_Click1(sender, e);
        }
        catch { }
        //Div3.Style.Add("display", "none");
        //Div4.Style.Add("display", "none");
        HiddenField2.Value = "";
        HiddenField4.Value = "";


    }
    private DataTable ImportTogrid(string FilePath, string Extension, string IsHDR)
    {
        string conStr = "";
        switch (Extension)
        {
            case ".xls": // Excel 97-03
                conStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Extended Properties='Excel 8.0;HDR={1}'";

                break;

            case ".xlsx": // Excel 07
                conStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties='Excel 12.0;HDR={1}'";
                break;
        }

        conStr = string.Format(conStr, FilePath, IsHDR);
        OleDbConnection connExcel = new OleDbConnection(conStr);
        OleDbCommand cmdExcel = new OleDbCommand();
        OleDbDataAdapter oda = new OleDbDataAdapter();

        DataTable dt = new DataTable();
        cmdExcel.Connection = connExcel;
        // get first Sheet

        connExcel.Open();

        DataTable dtExcelSchema;
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
        connExcel.Close();

        // read data from first sheet
        connExcel.Open();
        cmdExcel.CommandText = "SELECT * FROM [" + sheetName + "]";

        oda.SelectCommand = cmdExcel;
        oda.Fill(dt);
        connExcel.Close();
        return dt;
    }
    //Button15_Click
    public string TitleID;
    protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
    {
        obCommonFuction.FillDatasetByProc("Update dpt_stockdetailschild_t SET `IsDistribute`=0,`distributID`=0 where BundleNo_I=" + GridView4.SelectedDataKey.Value.ToString() + " ");

        DataSet ss1 = obCommonFuction.FillDatasetByProc("call USP_SendbandalDetails(" + ddlChallano.SelectedValue + "," + hdTitleA.Value + ")");
        Div5.Style.Add("display", "block");
        Div6.Style.Add("display", "block");
        GridView4.DataSource = ss1.Tables[0];
        GridView4.DataBind();
    }
    protected void Button15_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Label6.Text = "";
        GridViewRow grd = (GridViewRow)(btn.NamingContainer);
        //List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        //    CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
        TextBox txtf = (TextBox)grd.FindControl("TextBox1");
        HiddenField hd1 = (HiddenField)grd.FindControl("HiddenField3");
        hdTitleA.Value = hd1.Value;
        DataSet ss1 = obCommonFuction.FillDatasetByProc("call USP_SendbandalDetails(" + ddlChallano.SelectedValue + "," + hd1.Value + ")");
        Div5.Style.Add("display", "block");
        Div6.Style.Add("display", "block");
        GridView4.DataSource = ss1.Tables[0];
        GridView4.DataBind();
        try
        {
            string[] st = ss1.Tables[1].Rows[0]["BundleNob"].ToString().Split(',');

            for (int i = 0; i < st.Length; i++)
            {
                DataSet ss = obCommonFuction.FillDatasetByProc("call CheckBandleNo ('" + st[i] + "'," + hd1.Value + "," + Convert.ToString(Session["UserID"]) + ")");
                if (ss.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    //st[i];
                    bundleNoNew = bundleNoNew + "," + st[i];
                }


            }

            Label6.Text = bundleNoNew.ToString();
            obCommonFuction.FillDatasetByProc("call USP_Dpt_ChallanDetailsBundel(1," + hd1.Value + ",'" + ddlChallano.SelectedValue + "','" + Label6.Text + "'," + Session["UserID"] + ")");
        }
        catch { }
        // Label6.Text = "";
        // USP_SendbandalDetails
    }
    protected void Button13_Click(object sender, EventArgs e)
    {
        Div5.Style.Add("display", "none");
        Div6.Style.Add("display", "none");
        //Response.Redirect("DistributeYojnaBookWithBarcode.aspx");
    }
    //B13_Click
    protected void B13_Click(object sender, EventArgs e)
    {
        Div8.Style.Add("display", "none");
        Div7.Style.Add("display", "none");
    }
    protected void Button15_Click1(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow grd = (GridViewRow)(btn.NamingContainer);
        Div8.Style.Add("display", "block");
        Div7.Style.Add("display", "block");
        HiddenField hd12 = (HiddenField)grd.FindControl("HiddenField3");
        DataSet dt = obCommonFuction.FillDatasetByProc(@"call dptStockDetailsReport(" + Session["USerID"] + "," + hd12.Value + ",0,0,'" + ddlSessionYear.SelectedValue + "')");
        grd15.DataSource = dt.Tables[0];
        grd15.DataBind();
    }
    protected void btn12_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow grd = (GridViewRow)(btn.NamingContainer);
        HiddenField4.Value = ((HiddenField)grd.FindControl("HiddenField3")).Value;

        try
        {
            HiddenField5.Value = grd.Cells[4].Text;
        }
        catch { }
        if (HiddenField5.Value == "&nbsp;")
        {
            HiddenField5.Value = "0";
        }
        HiddenField2.Value = Convert.ToString(Convert.ToInt32(grd.Cells[2].Text) - Convert.ToInt32(HiddenField5.Value));
        Div9.Style.Add("display", "block");
        Div10.Style.Add("display", "block");
    }
    protected void btn12_1_Click(object sender, EventArgs e)
    {


        obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('" + TextBox1.Text.Trim() + "','" + ddlChallano.SelectedValue + "',0," + Convert.ToString(Session["UserID"]) + "," + HiddenField4.Value + ")");
        try
        {
            obCommonFuction.FillDatasetByProc("call USP_Dpt_ChallanDetailsBundel(0," + HiddenField4.Value + ",'" + ddlChallano.SelectedValue + "','" + TextBox1.Text + "'," + Session["UserID"] + ")");
        }
        catch { }
        Button3_Click1(sender, e);
        Div9.Style.Add("display", "none");
        Div10.Style.Add("display", "none");
        HiddenField4.Value = "";
        HiddenField2.Value = "";
        Label5.Text = "";
        TextBox1.Text = "";
        HiddenField2.Value = "";



    }
    protected void btn12_2_Click(object sender, EventArgs e)
    {
        Div9.Style.Add("display", "none");
        Div10.Style.Add("display", "none");
    }
    //btn12_Click
    protected void DdlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strcallbyd = "CALL USP_GEN_GetBlockByDistrict(" + DdlDistrict.SelectedValue + ")";
        CommonFuction obCommonFuction = new CommonFuction();
        DataSet ds = obCommonFuction.FillDatasetByProc(strcallbyd);
        ddlBlock.DataSource = ds;
        ddlBlock.DataTextField = "BlockNameHindi_V";
        ddlBlock.DataValueField = "BlockTrno_I";
        ddlBlock.DataBind();
        ddlBlock.Items.Insert(0, "select..");
    }
    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlChallano.DataSource = obCommonFuction.FillDatasetByProc(@"select distinct StockDistributionSEntryID_I, ChallanNo_V from dpt_stockdistributionschemeentry_m
inner join dpt_distributchallanreceipt on dpt_distributchallanreceipt.ChallanID=ChallanNo_V
inner join adm_blockmaster on adm_blockmaster.BlockTrno_I=blockID_I  where dpt_stockdistributionschemeentry_m.UserID  ='" + Convert.ToString(Session["UserID"]) + "' and blockID_I=" + ddlBlock.SelectedValue + " and SendStatus not in(1,2) and `YearID`=(SELECT `AcYear` FROM`adm_acadmicyears` WHERE `DepoYear`=1);");
        ddlChallano.DataValueField = "StockDistributionSEntryID_I";
        ddlChallano.DataTextField = "ChallanNo_V";
        ddlChallano.DataBind();
        ddlChallano.Items.Insert(0, "select..");

        ddlChallano_SelectedIndexChanged(sender, e);
    }
    protected void Button16_Click(object sender, EventArgs e)
    {
        obCommonFuction.FillDatasetByProc("call USP_DPTYojnaPaikBundleSuply(" + ddlChallano.SelectedItem.Text + "," + ddlChallano.SelectedValue + "," + Session["UserID"] + ")");
        Button3_Click1(sender, e);
    }


    //protected void Button151_Click1(object sender, EventArgs e)
    //{
    //    Button btn = (Button)sender;

    //    GridViewRow grd = (GridViewRow)(btn.NamingContainer);
    //    HiddenField hd1 = (HiddenField)grd.FindControl("HiddenField3");
    //   // HiddenField hd2 = (HiddenField)grd.FindControl("hdType");
    //    Div13.Style.Add("display", "block");
    //    Div14.Style.Add("display", "block");
    //    GridView6.DataSource = obCommonFuction.FillDatasetByProc("call USP_GetChallanBundel(" + ddlChallano.SelectedValue + "," + hd1.Value + ")");
    //    GridView6.DataBind();
    //    //TitleID HiddenField3
    //    //hdType 
    //}
    //protected void Button18C(object sender, EventArgs e)
    //{
    //    Div13.Style.Add("display", "none");
    //    Div14.Style.Add("display", "none");
    //}
    protected void Button17_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            obCommonFuction.FillDatasetByProc("call Fn_CursorStocklooseforBillNew(" + ddlChallano.SelectedValue + "," + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField3")).Value + "," + GridView1.Rows[i].Cells[3].Text + "," + Convert.ToString(Session["UserID"]) + ")");
            // fadeDiv.Style.Add("display", "block");
            // Messages.Style.Add("display", "block");
            //  HiddenField6.Value = bt.CommandArgument;
            //int count12345 = 0;
        }
        Button3_Click1(sender, e);
    }
    protected void Button18_Click(object sender, EventArgs e)
    {
        Response.Clear();

        Response.Buffer = true;



        Response.AddHeader("content-disposition",

         "attachment;filename=GridViewExport.xls");

        Response.Charset = "";

        Response.ContentType = "application/vnd.ms-excel";

        StringWriter sw = new StringWriter();

        HtmlTextWriter hw = new HtmlTextWriter(sw);



        GridView1.AllowPaging = false;

        GridView1.DataBind();



        GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");

        GridView1.HeaderRow.Cells[0].Style.Add("background-color", "green");

        GridView1.HeaderRow.Cells[1].Style.Add("background-color", "green");

        GridView1.HeaderRow.Cells[2].Style.Add("background-color", "green");



        ArrayList arr = (ArrayList)ViewState["States"];

        GridView1.HeaderRow.Cells[0].Visible = Convert.ToBoolean(arr[0]);

        GridView1.HeaderRow.Cells[1].Visible = Convert.ToBoolean(arr[1]);

        GridView1.HeaderRow.Cells[2].Visible = Convert.ToBoolean(arr[2]);



        GridView1.HeaderRow.Cells[0].FindControl("chkCol0").Visible = false;

        GridView1.HeaderRow.Cells[1].FindControl("chkCol1").Visible = false;

        GridView1.HeaderRow.Cells[2].FindControl("chkCol2").Visible = false;



        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            GridViewRow row = GridView1.Rows[i];

            row.Cells[0].Visible = Convert.ToBoolean(arr[0]);

            row.Cells[1].Visible = Convert.ToBoolean(arr[1]);

            row.Cells[2].Visible = Convert.ToBoolean(arr[2]);

            row.BackColor = System.Drawing.Color.White;

            row.Attributes.Add("class", "textmode");

            if (i % 2 != 0)
            {

                row.Cells[0].Style.Add("background-color", "#C2D69B");

                row.Cells[1].Style.Add("background-color", "#C2D69B");

                row.Cells[2].Style.Add("background-color", "#C2D69B");

            }

        }

        GridView1.RenderControl(hw);

        string style = @"<style> .textmode { mso-number-format:\@; } </style>";

        Response.Write(style);

        Response.Output.Write(sw.ToString());

        Response.End();
    }
    protected void Button18_Click1(object sender, EventArgs e)
    {

    }
    protected void Button18_Click2(object sender, EventArgs e)
    {
        if (FileUpload2.HasFile)
        {

            string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);

            string Extension = Path.GetExtension(FileUpload2.PostedFile.FileName);

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];



            string FilePath = Server.MapPath(FolderPath + FileName);

            FileUpload2.SaveAs(FilePath);

            Import_To_Grid(FilePath, Extension, "Yes");
            Button3_Click1(sender, e);

        }
    }
    private void Import_To_Grid(string FilePath, string Extension, string isHDR)
    {

        string conStr = "";
        switch (Extension)
        {
            case ".xls": // Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;

                break;

            case ".xlsx": // Excel 07
                conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                break;

        }

        conStr = string.Format(conStr, FilePath, isHDR);
        OleDbConnection connExcel = new OleDbConnection(conStr);
        OleDbCommand cmdExcel = new OleDbCommand();
        OleDbDataAdapter oda = new OleDbDataAdapter();

        DataSet dt = new DataSet();
        cmdExcel.Connection = connExcel;
        // get first Sheet

        connExcel.Open();

        DataTable dtExcelSchema;
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
        connExcel.Close();

        // read data from first sheet
        connExcel.Open();
        cmdExcel.CommandText = "SELECT * FROM [" + sheetName + "]";

        oda.SelectCommand = cmdExcel;
        oda.Fill(dt);
        connExcel.Close();
        string SubQuery = "";
        for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
        {


            if (dt.Tables[0].Rows[i]["Title1"].ToString() != "")
            {
                SubQuery = SubQuery + dt.Tables[0].Rows[i]["Title1"];
            }
            if (dt.Tables[0].Rows[i]["Title2"].ToString() != "")
            {
                SubQuery = SubQuery + "," + dt.Tables[0].Rows[i]["Title2"].ToString();
            }
            if (dt.Tables[0].Rows[i]["Title3"].ToString() != "")
            {
                SubQuery = SubQuery + "," + dt.Tables[0].Rows[i]["Title3"].ToString();
            }
            if (dt.Tables[0].Rows[i]["Title4"].ToString() != "")
            {
                SubQuery = SubQuery + "," + dt.Tables[0].Rows[i]["Title4"].ToString();
            }
            if (dt.Tables[0].Rows[i]["Title5"].ToString() != "")
            {
                SubQuery = SubQuery + "," + dt.Tables[0].Rows[i]["Title5"].ToString();
            }
            if (dt.Tables[0].Rows[i]["Title6"].ToString() != "")
            {
                SubQuery = SubQuery + "," + dt.Tables[0].Rows[i]["Title6"].ToString();
            }
            if (dt.Tables[0].Rows[i]["Title7"].ToString() != "")
            {
                SubQuery = SubQuery + "," + dt.Tables[0].Rows[i]["Title7"].ToString();
            }
            if (dt.Tables[0].Rows[i]["Title8"].ToString() != "")
            {
                SubQuery = SubQuery + "," + dt.Tables[0].Rows[i]["Title8"].ToString();
            }
            if (dt.Tables[0].Rows[i]["Title9"].ToString() != "")
            {
                SubQuery = SubQuery + "," + dt.Tables[0].Rows[i]["Title9"].ToString();
            }
            if (dt.Tables[0].Rows[i]["Title10"].ToString() != "")
            {
                SubQuery = SubQuery + "," + dt.Tables[0].Rows[i]["Title10"].ToString();
            }
            if (dt.Tables[0].Rows[i]["Title11"].ToString() != "")
            {
                SubQuery = SubQuery + "," + dt.Tables[0].Rows[i]["Title11"].ToString();
            }
            if (dt.Tables[0].Rows[i]["Title12"].ToString() != "")
            {
                SubQuery = SubQuery + "," + dt.Tables[0].Rows[i]["Title12"].ToString();
            }
            if (dt.Tables[0].Rows[i]["Title13"].ToString() != "")
            {
                SubQuery = SubQuery + "," + dt.Tables[0].Rows[i]["Title13"].ToString();
            }
            if (dt.Tables[0].Rows[i]["Title14"].ToString() != "")
            {
                SubQuery = SubQuery + "," + dt.Tables[0].Rows[i]["Title14"].ToString();
            }


        }

        obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('" + SubQuery + "','" + ddlChallano.SelectedValue + "',0," + Convert.ToString(Session["UserID"]) + ",0)");


    }
    protected void Button19_Click(object sender, EventArgs e)
    {
        obCommonFuction.FillDatasetByProc("CALL `UpdateBundalfromBarcodeDevice_Challan`()");
    }
}