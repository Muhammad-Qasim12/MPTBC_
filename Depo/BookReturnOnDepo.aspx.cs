using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Depo_BookReturnOnDepo : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    string aa;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          DataSet ds= comm.FillDatasetByProc("call USP_DPT_BOOKRetrunDetailsDepo("+Session["UserID"]+",12,'')");
          grdBook.DataSource = ds.Tables[0];
          grdBook.DataBind();

        }

    }
  

    protected void grdBook_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DataSet ds1 = comm.FillDatasetByProc("call USP_DPT_BOOKRetrunDetailsDepo(" + Session["UserID"] + ",0,"+grdBook.SelectedDataKey.Value.ToString ()+")");
        GridView1.DataSource = ds1;
        GridView1.DataBind();
        Button1.Visible = true;
    }
    List<Baecode> obBaecodeList = new List<Baecode>();
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        TextBox txtbox = (TextBox)sender;
        CommonFuction comm = new CommonFuction();
    DataSet ds= comm.FillDatasetByProc("select StockDetailsChildID_I, StockDetailsID_I, BundleNo_I, FromNo_I, ToNo_I, BundleType_I, RemaingLoose_V, IsOpenMarket, IsDistribute, RemainingStock, WareHouseID, DistributID, PriTransID, BookSellerChallan from dpt_stockdetailschild_t where BundleNo_I=" + txtbox.Text+ " and IsDistribute=0");
    
      
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("CheckBoxList1");
        List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        if (ds.Tables[0].Rows.Count > 0)
        {
            HiddenField5.Value = Convert.ToString(ds.Tables[0].Rows[0]["StockDetailsChildID_I"]);
            string[] strRemaingLoose = Convert.ToString(ds.Tables[0].Rows[0]["RemaingLoose_V"]).Split(',');

            foreach (string stritem in strRemaingLoose)
            {
                if (stritem!="")
                { 
                GenarteLoosebundle obGenarteLoosebundle = new GenarteLoosebundle();
                obGenarteLoosebundle.BookNo = Convert.ToString(stritem);
                List.Add(obGenarteLoosebundle);
                }
            }
            if (List.Count == 0)
            {
                for (int i = Convert.ToInt32(ds.Tables[0].Rows[0]["FromNo_I"]); i < Convert.ToInt32(ds.Tables[0].Rows[0]["ToNo_I"]); i++)
                {
                    GenarteLoosebundle obGenarteLoosebundle = new GenarteLoosebundle();
                    obGenarteLoosebundle.BookNo = Convert.ToString(i);
                    List.Add(obGenarteLoosebundle);
                }
            }
            obChkLooseBundleList.DataSource = List;
            obChkLooseBundleList.DataTextField = "BookNo";
            obChkLooseBundleList.DataBind();

        }
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
    public class GenarteLoosebundle
    {
        public string BookNo { get; set; }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string str1 = "";
        string str2 = "";
        string str3="";
        int count;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            
            CheckBoxList obChkLooseBundleList = (CheckBoxList)GridView1.Rows[i].FindControl("CheckBoxList1");
            foreach (ListItem a in obChkLooseBundleList.Items)
            {

                if (a.Selected)
                {
                    if (str1 == "")
                    {
                        str1 = a.Text;
                        str3 = a.Text;
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
                        str2 = a.Text;
                    }
                    else
                    {
                        str2 = str2 + "," + a.Text;
                    }

                }

                
            } 
           
            aa = ((HiddenField)GridView1.Rows[i].FindControl("HiddenField2")).Value;
            comm.FillDatasetByProc("update dpt_bookreturndetails_t set Status=1,NewBookNo='" + str3 + "' where bookRetrNo_I=" + aa + "");
            comm.FillDatasetByProc("update dpt_stockdetailschild_t set RemaingLoose_V='" + str2 + "',RemainingStock='" + str1 + "' where StockDetailsChildID_I="+HiddenField5.Value+"");
        
        }
        GridView1.DataSource = null;
        GridView1.DataBind();
       
    }
}