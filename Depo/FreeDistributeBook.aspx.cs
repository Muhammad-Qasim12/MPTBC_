using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;


public partial class Depo_FreeDistributeBook : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ddlSessionYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlSessionYear.DataValueField = "id";
            ddlSessionYear.DataTextField = "AcYear";
            ddlSessionYear.DataBind();
            ddlSessionYear.Items.Insert(0, "--Select--");
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataSet dt = obCommonFuction.FillDatasetByProc("call dpt_NishulakPraday("+Session["UserID"]+"," + DropDownList2.SelectedValue + ")");
        GridView1.DataSource = dt.Tables[0];
       GridView1.DataBind();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dtr = obCommonFuction.FillDatasetByProc("CALL USP_dib_freebooksdistribution(0," + ddlSessionYear.SelectedValue + "," + Session["UserID"].ToString() + ")");
        DropDownList2.DataSource = dtr.Tables[2];
        DropDownList2.DataValueField = "FreeBooksDistributionID_I";
        DropDownList2.DataTextField = "LetterNo_V";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, "--Select--");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        obCommonFuction.FillDatasetByProc("call USP_DPT_NishulkBookPradaySave(0,'" + DropDownList2.SelectedItem.Text + "'," + DropDownList2.SelectedValue + "," + Session["UserID"] + ")");
        GridView1.DataSource = null;
        GridView1.DataBind();
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
    int TotalBandal, count12;
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
    
    
    protected void Button4_Click(object sender, EventArgs e)
    {
     Button bt = (Button)sender;
     GridViewRow grdrow = (GridViewRow)bt.NamingContainer;
  
       // HiddenField6.Value = grdrow.Cells[3].Text;
      ///  TextBox txtb = ((TextBox)grdrow.FindControl("TextBox2"));
    HiddenField titleID = (HiddenField)grdrow.FindControl("HiddenField1");
    Label2.Text = grdrow.Cells[0].Text;
    Label3.Text = grdrow.Cells[1].Text;
    DataSet ds = obCommonFuction.FillDatasetByProc("Call USP_DPT_NishulkPraday(" + Convert.ToString(Session["UserID"]) + "," + titleID.Value + ")");
        grdPrinterBundleDetails.DataSource = ds;
        grdPrinterBundleDetails.DataBind();
       // Label2.Text = grdrow.Cells[3].Text;
        fadeDiv.Style.Add("display", "block");
        Messages.Style.Add("display", "block");

        //grdPrinterBundleDetails\\\



    }
    protected void But1_Click(object sender, EventArgs e)
    {
        try
        {
            
           fadeDiv.Style.Add("display", "none");
            Messages.Style.Add("display", "none");
            string str1 = "";
            string str2 = "";
            for (int i = 0; i < grdPrinterBundleDetails.Rows.Count; i++)
            {

                if (((CheckBox)grdPrinterBundleDetails.Rows[i].FindControl("chkpaik")).Checked == true)
                {


                    if (((CheckBox)grdPrinterBundleDetails.Rows[i].FindControl("chkIsLoose")).Checked == true)
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
                                obCommonFuction.FillDatasetByProc("update dpt_stockdetailschild_t set DistributID=" + DropDownList2.SelectedValue + ", IsDistribute=7 where StockDetailsChildID_I=" + Convert.ToInt32(((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + ""));

                                obCommonFuction.FillDatasetByProc("call USP_DPT_dtp_loosebandaldetailsSave ('Nishulak',0,0," + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField2")).Value + ",0," + str1 + "," + DropDownList2.SelectedValue + ")");
                            }
                            else
                            {
                                try
                                {
                                    obCommonFuction.FillDatasetByProc("update dpt_stockdetailschild_t set  DistributID=" + DropDownList2.SelectedValue + ",RemaingLoose_V =" + str1 + ",RemainingStock=" + str2 + " where StockDetailsChildID_I=" + Convert.ToInt32(((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + ""));
                                    obCommonFuction.FillDatasetByProc("call USP_DPT_dtp_loosebandaldetailsSave ('Nishulak',0,0," + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + ",0," + str1 + "," + DropDownList2.SelectedValue + ")");

                                }
                                catch { }

                            }
                            

                        }

                        str1 = "";
                        str2 = "";

                    }
                    else
                    {
                        obCommonFuction.FillDatasetByProc("update dpt_stockdetailschild_t set DistributID=" + DropDownList2.SelectedItem.Text + ", IsDistribute=7 where StockDetailsChildID_I=" + Convert.ToInt32(((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + ""));
                    }
                }
                
           
            }

        }
        catch { }
       // Button3_Click1(sender, e);
        DropDownList2_SelectedIndexChanged(sender, e);
    }
     protected void Button5_Click(object sender, EventArgs e)
    {
        fadeDiv.Style.Add("display", "none");
        Messages.Style.Add("display", "none");
     
     }
    
}