using System;
using System.Collections.Generic;
using System.Data;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Collections;

public partial class Depo_InterDepoBarcodeDisti : System.Web.UI.Page
{
    CommonFuction obcomm = new CommonFuction();
    int count12;
    ArrayList aa = new ArrayList();
    int total=0;
    int totalBandal;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlChallano.DataSource = obcomm.FillDatasetByProc("call USP_DPTInterDepoChallan("+Session["UserID"]+",0,0)");
            ddlChallano.DataTextField = "ChallanNo_V";
            ddlChallano.DataValueField = "ChallanNo_V";
            ddlChallano.DataBind();
            ddlChallano.Items.Insert(0, "Select..");

        }
    }
    protected void ddlChallano_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds1 = obcomm.FillDatasetByProc("call USP_DPTInterDepoChallan(" + Session["UserID"] + ","+ddlChallano.SelectedValue+",1)");
        ddlBookName.DataSource = ds1.Tables[0];
        ddlBookName.DataTextField = "TitleHindi_V";
        ddlBookName.DataValueField = "TitleID_I";
        ddlBookName.DataBind();
        ddlBookName.Items.Insert(0, "Select..");

    }
    protected void ddlBookName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet dd = obcomm.FillDatasetByProc("call USP_DPTPerBandalBookCount(" + ddlBookName.SelectedValue + ")");
            HiddenField3.Value = dd.Tables[0].Rows[0]["PerBandal"].ToString();
            if (HiddenField3.Value == "")
            {
                HiddenField3.Value = "0";
            }

            DataSet ds1 = obcomm.FillDatasetByProc("call USP_DPTInterDepoChallan(" + Session["UserID"] + "," + ddlBookName.SelectedValue + ",2)");
            Label3.Text = ds1.Tables[0].Rows[0]["NoOfBookTransferd"].ToString();
            Label4.Text = ds1.Tables[0].Rows[0]["BookType"].ToString();

            try
            {
                var pack = Convert.ToInt32(Label3.Text) / Convert.ToInt32(HiddenField3.Value);
                var loose = Convert.ToInt32(Label3.Text) % Convert.ToInt32(HiddenField3.Value);

                Label7.Text = pack.ToString();
                Label8.Text = loose.ToString();
            }
            catch { }

            if (ds1.Tables[0].Rows[0]["BookType"].ToString() == "योजना")
            {
                HiddenField1.Value = "1";
            }
            else
            {
                HiddenField1.Value = "2";
            }
            try
            {
                DataSet ds2 = obcomm.FillDatasetByProc("Call USP_DPTInterDepoBandalDistibute('" + txtBundlenNo.Text + "','" + ddlChallano.SelectedValue + "',002," + Convert.ToString(Session["UserID"]) + "," + ddlBookName.SelectedValue + "," + HiddenField1.Value + ")");
                Label5.Text = ds2.Tables[0].Rows[0]["NOOfBooks"].ToString();
            }
            catch { }
            DataSet ds3 = obcomm.FillDatasetByProc("Call USP_DPTInterDepoBandalDistibute('" + txtBundlenNo.Text + "','" + ddlChallano.SelectedValue + "',001," + Convert.ToString(Session["UserID"]) + "," + ddlBookName.SelectedValue + "," + HiddenField1.Value + ")");

            grdPrinterBundleDetails.DataSource = ds3;
            grdPrinterBundleDetails.DataBind();
        }
        catch { }
      
    }

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
            DataSet ds = comm.FillDatasetByProc("call DPT_BlockwiseBandCheck('" + txtBundlenNo.Text + "',0)");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string[] strRemaingLoose = Convert.ToString(ds.Tables[0].Rows[0]["RemaingLoose_V"]).Split(',');


                foreach (string stritem in strRemaingLoose)
                {
                    GenarteLoosebundle obGenarteLoosebundle = new GenarteLoosebundle();
                    obGenarteLoosebundle.BookNo = Convert.ToString(stritem);
                    List.Add(obGenarteLoosebundle);
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
    protected void txtonChange(object sender, EventArgs e)
    {
        try {
        TextBox TextBox = (TextBox)sender;

        GridViewRow grd = (GridViewRow)(TextBox.NamingContainer);
        List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        Label txtf = (Label)grd.FindControl("FromNo_I");
        Label txtPer = (Label)grd.FindControl("lblPer");
        Label txtTo = (Label)grd.FindControl("ToNo_I");
        CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");

        int id = Convert.ToInt32(TextBox.Text);

        foreach (ListItem items in obChkLooseBundleList.Items)
        {
            count12 = count12 + 1;
            if (id >= count12)
            {
                items.Selected = true;
            }
            else { items.Selected = false ; }

        }
        }
        catch { }
    }
    protected void Checkbarcode(object sender, EventArgs e)
    {

        CommonFuction obCommonFuction = new CommonFuction();
        try
        {
            DataSet ds2 = obCommonFuction.FillDatasetByProc("Call USP_DPTInterDepoBandalDistibute('" + txtBundlenNo.Text + "','" + ddlChallano.SelectedValue + "',002," + Convert.ToString(Session["UserID"]) + "," + ddlBookName.SelectedValue + "," + HiddenField1.Value + ")");
            Label5.Text = ds2.Tables[0].Rows[0]["NOOfBooks"].ToString();
            Label9.Text = ds2.Tables[0].Rows[0]["NoOfBundal"].ToString();

        }
        catch { }
        if (Convert.ToInt32(Label8.Text) == 0 || Label8.Text == "")
        {
            totalBandal = Convert.ToInt32(Label7.Text);
        }
        else
        {
            totalBandal = Convert.ToInt32(Label7.Text)+1;
        }
        if (Label9.Text == "")
        {
            Label9.Text = "0";
        }
        if ((totalBandal) == Convert.ToInt32(Label9.Text))
        {
            Label6.Text = "प्रदाय की जाने वाली बण्डल की संख्या पूरी हो चुकी है ";
        }
        else
        { 
        obCommonFuction.FillDatasetByProc("Call USP_DPTInterDepoBandalDistibute('" + txtBundlenNo.Text + "','" + ddlChallano.SelectedValue + "',0," + Convert.ToString(Session["UserID"]) + "," + ddlBookName.SelectedValue + ", " + HiddenField1.Value + ")");
        Label2.Text = txtBundlenNo.Text;


        DataSet ds1 = obCommonFuction.FillDatasetByProc("Call USP_DPTInterDepoBandalDistibute('" + txtBundlenNo.Text + "','" + ddlChallano.SelectedValue + "',001," + Convert.ToString(Session["UserID"]) + "," + ddlBookName.SelectedValue + "," + HiddenField1.Value + ")");
        
        grdPrinterBundleDetails.DataSource = ds1;
        grdPrinterBundleDetails.DataBind();
        }
        txtBundlenNo.Text="";
        txtBundlenNo.Focus();
        
    }
    protected void grdPrinterBundleDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            CommonFuction obCommonFuction = new CommonFuction();
            obCommonFuction.FillDatasetByProc(@"update dpt_stockdetailschild_t set IsDistribute ='0 ',DistributID ='0' where UserID_I=" + Convert.ToString(Session["UserID"]) + "  and  StockDetailsChildID_I=" + grdPrinterBundleDetails.DataKeys[e.RowIndex].Value + "");
            DataSet ds = obCommonFuction.FillDatasetByProc("Call USP_DPTInterDepoBandalDistibute('" + txtBundlenNo.Text + "','" + ddlChallano.SelectedValue + "',001," + Convert.ToString(Session["UserID"]) + "," + ddlBookName.SelectedValue + "," + HiddenField1.Value + ")");
            grdPrinterBundleDetails.DataSource = ds;
            grdPrinterBundleDetails.DataBind();
        }
        catch { }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try { 
        for (int j = 0; j < grdPrinterBundleDetails.Rows.Count; j++)
        {
            if (((TextBox)grdPrinterBundleDetails.Rows[j].FindControl("txtb")).Text.ToString() != "")
            {
                total = total + Convert.ToInt32(((TextBox)grdPrinterBundleDetails.Rows[j].FindControl("txtb")).Text);
            }
        }
        string str1 = "";
        string str2 = "";
        CommonFuction go = new CommonFuction();
        if (Convert.ToInt32(Label8.Text) == total)
        {

        for (int i = 0; i < grdPrinterBundleDetails.Rows.Count; i++)
        {
            str1 = "'";
            str2 = "'"; 
            CheckBoxList obChkLooseBundleList = (CheckBoxList)grdPrinterBundleDetails.Rows[i].FindControl("ChkLooseBundleList");
            foreach (ListItem a in obChkLooseBundleList.Items)
            {

                if (a.Selected)
                {
                    if (str1 == "")
                    {
                        str1 = str1 + a.Text;
                    }
                    else
                    {
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
                    go.FillDatasetByProc("update dpt_stockdetailschild_t set DistributID=" + ddlChallano.SelectedItem.Text + ", RemainingStock=" + str1 + ",RemaingLoose_V=" + str2 + ",IsDistribute=2 where StockDetailsChildID_I=" + Convert.ToInt32(((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField2")).Value + ""));
                    go.FillDatasetByProc("call USP_DPT_dtp_loosebandaldetailsSave ('InterDepo',0,0," + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField2")).Value + ",0," + str1 + "," + ddlChallano.SelectedItem.Text + ")");
                }
                else
                {

                    go.FillDatasetByProc("update dpt_stockdetailschild_t set IsDistribute=2, DistributID=" + ddlChallano.SelectedItem.Text + ", RemainingStock=" + str1 + ",RemaingLoose_V=" + str2 + " where StockDetailsChildID_I=" + Convert.ToInt32(((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField2")).Value + ""));
                   go.FillDatasetByProc("call USPInsertInterDepo(" + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField2")).Value + ")");
                    go.FillDatasetByProc("call USP_DPT_dtp_loosebandaldetailsSave ('InterDepo',0,0," + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField2")).Value + ",0," + str1 + "," + ddlChallano.SelectedItem.Text + ")");
                }
                go.FillDatasetByProc("insert into dpt_interdepotransdetails (OrderNo,ChallanNo,SubjectID,DepoID,BandalNo,looJbook)values ('" + ddlChallano.SelectedValue + "','" + ddlChallano.SelectedItem.Text + "'," + ddlBookName.SelectedValue + "," + Session["userID"] + ",'" + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I")).Text + "'," + str1 + ")");
            }
            else
            {
                go.FillDatasetByProc("update dpt_stockdetailschild_t set DistributID=" + ddlChallano.SelectedItem.Text + ",IsDistribute=2 where StockDetailsChildID_I=" + Convert.ToInt32(((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField2")).Value + ""));
                go.FillDatasetByProc("insert into dpt_interdepotransdetails (OrderNo,ChallanNo,SubjectID,DepoID,BandalNo,looJbook)values ('" + ddlChallano.SelectedValue + "','" + ddlChallano.SelectedItem.Text + "'," + ddlBookName.SelectedValue + "," + Session["userID"] + ",'" + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I")).Text + "'," + str1 + ")");
            }
            
                        }
        go.FillDatasetByProc("Call USP_DPTInterDepoBandalDistibute('" + txtBundlenNo.Text + "','" + ddlChallano.SelectedValue + "',003," + Convert.ToString(Session["UserID"]) + "," + ddlBookName.SelectedValue + "," + HiddenField1.Value + ")");
        grdPrinterBundleDetails.DataSource = "";
        grdPrinterBundleDetails.DataBind();
        ddlBookName.SelectedIndex = -1;
        ddlChallano.SelectedIndex = 0;
        try { 
        DataSet dd = go.FillDatasetByProc("call USP_DPT_InterDepoDataSave(" + ddlChallano.SelectedValue + ")");
        }
        catch { }
        Label6.Text = "आपका डाटा सम्बंधित डिपो को भेजा जा चूका  है ";

        }
        else
        {
            Label6.Text = "प्रदाय की जाने वाली पुस्तकों  की संख्या प्रदाय की गई पुस्तक की संख्या के बराबर नहीं  है ";
        }
            }
        catch { }
    }
    
}