using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Collections;
public partial class Depo_DistributeYojnaBookWithBarcode : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    int count12;
    ArrayList aa = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            try {
            ddlChallano.DataSource = obCommonFuction.FillDatasetByProc("select StockDistributionSEntryID_I,BlockID_I, UserID,ChallanNo_V from dpt_stockdistributionschemeentry_m where UserID ='"+Convert.ToString(Session["UserID"])+"';");
            ddlChallano.DataValueField = "StockDistributionSEntryID_I";
            ddlChallano.DataTextField = "ChallanNo_V";
            ddlChallano.DataBind();
            ddlChallano.Items.Insert(0, "select..");
            if (Request.QueryString["ID"] != null)
            {
                ddlChallano.SelectedItem.Text = Request.QueryString["ID"];
                ddlChallano_SelectedIndexChanged(sender, e);
            }
               
                 }
            catch { }
        }
    }
    List<Baecode> obBaecodeList = new List<Baecode>();
    public class GenarteLoosebundle
    {
        public string BookNo { get; set; }

    }
    protected void chkIsLooseChange(object sender, EventArgs e)
    {
        try {
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
         DataSet ds = comm.FillDatasetByProc("call DPT_BlockwiseBandCheck('"+txtBundlenNo.Text+"',0)");
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
        else { 
       
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
            txtb.Visible = false ;

            obChkLooseBundleList.Items.Clear();
        }
        }
        catch { }
    }
    protected void txtonChange(object sender, EventArgs e)
    {
       
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

        }
      
    }
    protected void Checkbarcode(object sender, EventArgs e)
    {
        try
        {

            DataSet ds1 = obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('" + txtBundlenNo.Text + "','" + ddlChallano.SelectedValue + "',001," + Convert.ToString(Session["UserID"]) + "," + ddlBookName.SelectedValue + ")");
            Label4.Text = ds1.Tables[0].Rows.Count.ToString();
            if (Label3.Text == Label4.Text)
            { 
                txtBundlenNo.Style.Add("BackColor", "Red");
              txtBundlenNo.BackColor =System.Drawing.Color.Red;
              if (Label5.Text != "")
              {
                  ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('लूज बण्डल डालने के लिये अपने डिपो प्रवन्धक से संपर्क करें.');</script>");
              }
              else
              {
                  ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert आगे का काम के लिये डिपो प्रवन्धक से संपर्क करें.');</script>");
              }
            }
            else
            { 
            obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('" + txtBundlenNo.Text + "','" + ddlChallano.SelectedValue + "',0," + Convert.ToString(Session["UserID"]) + ","+ddlBookName.SelectedValue+")");
            Label2.Text = txtBundlenNo.Text;
            //DataSet ds = obCommonFuction.FillDatasetByProc(@"select dpt_stockdetailschild_t.* ,TitleHindi_V , case IsOpenMarket when 2 then 'सामान्य' else 'योज़ना' end as booktype from  dpt_stockdetails_t INNER JOIN dpt_stockdetailschild_t on dpt_stockdetailschild_t.StockDetailsID_I=dpt_stockdetails_t.StockDetailsID_I inner join acd_titledetail on dpt_stockdetails_t.SubJectID_I=acd_titledetail.TitleID_I  inner join dpt_warehouuse_m on dpt_stockdetailschild_t.WareHouseID=dpt_warehouuse_m.WareHouseID_I where dpt_warehouuse_m.UserID_I=" + Convert.ToString(Session["UserID"]) + " and  IsDistribute=3 and  DistributID =" + ddlChallano.SelectedValue + "  ");

          DataSet ds = obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('" + txtBundlenNo.Text + "','" + ddlChallano.SelectedValue + "',001," + Convert.ToString(Session["UserID"]) + ","+ddlBookName.SelectedValue+")");
          Label4.Text = ds.Tables[0].Rows.Count.ToString ();
            }
        

        }
        catch { }

            txtBundlenNo.Text = "";
        txtBundlenNo.Focus();
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
   }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try { 
        string str1 = "";
        string str2 = "";
        for (int i = 0; i < grdPrinterBundleDetails.Rows.Count;i++ )
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
            if (str1.ToString() != "")
            {
                obCommonFuction.FillDatasetByProc(@"update dpt_stockdetailschild_t set RemaingLoose_V=" + str2 + ",RemainingStock="+str1+" ,DistributID =" + ddlChallano.SelectedValue + " where BundleNo_I='" + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I")).Text + "'");
                obCommonFuction.FillDatasetByProc("call USP_DPT_dtp_loosebandaldetailsSave ('Block',0,0," + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + "," + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I")).Text + "," + str1 + "," + ddlChallano.SelectedValue + ")");
            }
            
            str1 = "";
             str2 = "";

        }
        }
        catch { }
        }
    protected void grdPrinterBundleDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try { 
        obCommonFuction.FillDatasetByProc(@"update dpt_stockdetailschild_t set IsDistribute ='0 ',DistributID ='0' where UserID_I=" + Convert.ToString(Session["UserID"]) + "  and  StockDetailsChildID_I=" + grdPrinterBundleDetails.DataKeys[e.RowIndex].Value + "");
        DataSet ds = obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut('" + txtBundlenNo.Text + "','" + ddlChallano.SelectedValue + "',001," + Convert.ToString(Session["UserID"]) + ")");
        grdPrinterBundleDetails.DataSource = ds;
        grdPrinterBundleDetails.DataBind();
        }
        catch { }
    }


    protected void ddlChallano_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ddchallan;
        ddchallan = obCommonFuction.FillDatasetByProc(@"select TitleHindi_V,TitalID,paikbandal,loojbandal from dpt_distributchallanreceipt
inner join acd_titledetail on acd_titledetail.TitleID_I=TitalID where ChallanID=" + ddlChallano.SelectedItem.Text + " ");
        ddlBookName.DataSource = ddchallan;
        ddlBookName.DataTextField = "TitleHindi_V";
        ddlBookName.DataValueField = "TitalID";
        ddlBookName.DataBind();
        Label3.Text = ddchallan.Tables[0].Rows[0]["paikbandal"].ToString() ;
         Label5.Text = ddchallan.Tables[0].Rows[0]["loojbandal"].ToString();
     
    }
    protected void ddlBookName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ddchallan;
        ddchallan = obCommonFuction.FillDatasetByProc(@"select TitleHindi_V,TitalID,paikbandal,loojbandal from dpt_distributchallanreceipt
inner join acd_titledetail on acd_titledetail.TitleID_I=TitalID where ChallanID=" + ddlChallano.SelectedItem.Text + " and  TitalID="+ddlBookName.SelectedValue+"");
      
        Label3.Text = ddchallan.Tables[0].Rows[0]["paikbandal"].ToString();
        Label5.Text = ddchallan.Tables[0].Rows[0]["loojbandal"].ToString();
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("BlockChalanReport.aspx?challanID="+ddlChallano.SelectedItem.Text+"&TitleID="+ddlBookName.SelectedValue+"&loojBook="+Label5.Text+"");
    }
}