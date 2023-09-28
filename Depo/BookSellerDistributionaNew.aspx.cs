using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
public partial class Depo_BookSellerDistributionaNew : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    BookSellerDemand obBookSellerDemand = null; int TotalBandal;
    string SubQuery; int total112, total113, grdCount1, grdCount2;
    int count12,total; int count123; CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Random rand = new Random();
            //int randnum = rand.Next(100000, 10000000);
            //txtChalanNo.Text = randnum.ToString();
            //txtChalanNo.Enabled = false;

            // WareHouseMaster obWareHouseMaster = new WareHouseMaster();
            // obWareHouseMaster.WareHouseID = 0;
            //  obWareHouseMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
            // DataSet dsWareHouse = obWareHouseMaster.Select();

            obBookSellerDemand = new BookSellerDemand();
            obBookSellerDemand.User_ID_I = Convert.ToInt32(Session["UserID"]);
            obBookSellerDemand.DBookSelleDemandTrNo_I = -3;
            DataSet Demand = obBookSellerDemand.Select();
            ddlBookSllerName.DataSource = Demand;
            ddlBookSllerName.DataValueField = "User_ID_I";
            ddlBookSllerName.DataTextField = "BooksellerOwnerName_V";
            ddlBookSllerName.DataBind();
            ddlBookSllerName.SelectedValue = Request.QueryString["ID"];

            ddlBookSllerName_SelectedIndexChanged(sender, e);
            DropDownList1_SelectedIndexChanged(sender, e);
           // txtChalanNo.Text = Request.QueryString["Bchall"];
            hdnMasterId1.Value = Request.QueryString["Achall"];
           // ddlBookSllerName.SelectedValue = Request.QueryString["ID"];

            //ddlBookSllerName_SelectedIndexChanged(sender, e);
            //DropDownList1_SelectedIndexChanged(sender, e);
            //txtChalanNo.Text = Request.QueryString["Bchall"];
            //hdnMasterId1.Value = Request.QueryString["Achall"];

            //fillgrid();
            obCommonFuction.FillDatasetByProc("call USP_looj1_Samany(" + DropDownList1.SelectedValue + ","+Session["UserID"]+")");
        }
    }
    protected void btn12_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow grd = (GridViewRow)(btn.NamingContainer);
        HiddenField4.Value = ((HiddenField)grd.FindControl("HiddenField3")).Value;
        Button Button11 = ((Button)grd.FindControl("Button11"));
        try
        {
            HiddenField5.Value = grd.Cells[4].Text;
        }
        catch { }
        if (HiddenField5.Value == "&nbsp;")
        {
            HiddenField5.Value = "0";
        }
        try
        {
            HiddenField2.Value = Convert.ToString(Convert.ToInt32(grd.Cells[2].Text));
        }
        catch { }
        Div11.Style.Add("display", "block");
        Div12.Style.Add("display", "block");
    }
    protected void btn12_1_Click(object sender, EventArgs e)
    {

        //int count = TextBox1.Text.Split(',').Length;
        //if (Convert.ToInt32(HiddenField2.Value) >= count)
        //{

        //        obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new1('" + SubQuery + "','" + ddlChallano.SelectedItem.Text + "',0," + Session["userID"] + ","+HiddenField4.Value+")");
      //  obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('" + TextBox1.Text.Trim() + "','" + ddlChallano.SelectedValue + "',0," + Convert.ToString(Session["UserID"]) + "," + HiddenField4.Value + ")");
        try
        {
            obCommonFuction.FillDatasetByProc("UPDATE dpt_stockdetailschild_t SET IsDistribute =4,DistributID =" + Request.QueryString["Achall"] + ",BookSellerChallan=" + Request.QueryString["ChalanNo"] + " WHERE FIND_IN_SET (BundleNo_I,'" + TextBox1.Text + "') AND IsDistribute=0 AND IFNULL(iflooj,0)=0 and BundleType_I=2; ");
        }
        catch { }
        ddlBookSllerName_SelectedIndexChanged(sender, e);
        DropDownList1_SelectedIndexChanged(sender, e);
       // Button3_Click1(sender, e);
        Div11.Style.Add("display", "none");
        Div12.Style.Add("display", "none");
        HiddenField4.Value = "";
        HiddenField2.Value = "";
        Label5.Text = "";
        TextBox1.Text = "";
        HiddenField2.Value = "";
        //}
        //else
        //{
        //    Label5.Text = " आपके द्वारा डाले गए बंडल की संख्या दिए जाने वाले बंडल की संख्या सामान नहीं  है .";
        //}


    }
    protected void btn12_2_Click(object sender, EventArgs e)
    {
        Div11.Style.Add("display", "none");
        Div12.Style.Add("display", "none");
    }
    protected void ddlBookSllerName_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        DataSet ds = comm.FillDatasetByProc("select distinct OrderNo from dpt_bookselledemandmaster where Issumbited_I=1 and User_ID_I=" + ddlBookSllerName.SelectedValue + "");
        DropDownList1.DataTextField = "OrderNo";
        DropDownList1.DataValueField = "OrderNo";
        DropDownList1.DataSource = ds.Tables[0];
        DropDownList1.DataBind();
        DropDownList1.SelectedValue = Request.QueryString["ChalanNo"];
        a.Visible = false;
        a2.Visible = false;
        a1.Visible = false;
        a11.Visible = false;

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       // fillgrd();
        //a.Style.Add ("display","block");
        //a2.Style.Add("display", "block");
        a.Visible = true;
        a2.Visible = true;
        a1.Visible = true;
        a11.Visible = true;
        CommonFuction comm = new CommonFuction();
        DataSet book = comm.FillDatasetByProc("call USP_DptBookSellerDemand('" + ddlBookSllerName.SelectedValue + "',15,'" + DropDownList1.SelectedValue + "')");
        Label1.Text = book.Tables[0].Rows[0]["DDNouber"].ToString();
        Label2.Text = book.Tables[0].Rows[0]["BankName"].ToString();
        Label3.Text = Convert.ToString(Math.Round(Convert.ToDouble(book.Tables[0].Rows[0]["TotalRate"]), 2));
        Label4.Text = Convert.ToString(Math.Round(Convert.ToDouble(book.Tables[0].Rows[0]["Discount"]), 2));//Convert.ToString( Math.Round( book.Tables[0].Rows[0]["Discount"]),2)));
        Label5.Text = book.Tables[0].Rows[0]["DDDate"].ToString();
        Label6.Text = book.Tables[0].Rows[0]["RegistrationNo_V"].ToString();
        Label8.Text = book.Tables[0].Rows[0]["Categorya"].ToString();
        Label7.Text = book.Tables[0].Rows[0]["TotalAmount"].ToString();
        GridView1.DataSource = comm.FillDatasetByProc("call USP_DPTBookSupply(" + DropDownList1.SelectedValue + "," + ddlBookSllerName.SelectedValue + "," + Session["UserID"] + "," + Request.QueryString["Achall"] + ")");
        GridView1.DataBind();
        total113 = GridView1.Rows.Count;
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            string aa = GridView1.Rows[i].Cells[4].Text;
            if (aa.ToString() == "&nbsp;")
            {
                aa = "0";
            }
            if (GridView1.Rows[i].Cells[3].Text != aa && GridView1.Rows[i].Cells[3].Text != "0")
            {
                ((Button)GridView1.Rows[i].FindControl("Button4")).Visible = true;
              //  ((TextBox)GridView1.Rows[i].FindControl("TextBox2")).Visible = true;
            }
            else
            {
                ((Button)GridView1.Rows[i].FindControl("Button4")).Visible = false;
                //((TextBox)GridView1.Rows[i].FindControl("TextBox2")).Visible = false;
                total112 = total112 + 1;
            }

            if (GridView1.Rows[i].Cells[1].Text == aa)
            {
                ((Button)GridView1.Rows[i].FindControl("Button4")).Visible = false;
              //  ((TextBox)GridView1.Rows[i].FindControl("TextBox2")).Visible = false;

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

            }
            else
            {
                ((TextBox)GridView1.Rows[i].FindControl("TextBox1")).Visible = true;
            }
            //if (Convert.ToInt32(ra) == Convert.ToInt32(GridView1.Rows[i].Cells[1].Text))
            //{
            //    ((FileUpload)GridView1.Rows[i].FindControl("FileUpload1")).Visible = false;
            //    ((Button)GridView1.Rows[i].FindControl("Button10")).Visible = false;
            //}
            //else
            //{
            //    ((FileUpload)GridView1.Rows[i].FindControl("FileUpload1")).Visible = true;
            //    ((Button)GridView1.Rows[i].FindControl("Button10")).Visible = true;
            //}

            if ( GridView1.Rows[i].Cells[3].Text != "0")
            {
                ((Button)GridView1.Rows[i].FindControl("Button4")).Visible = true;
                //  ((TextBox)GridView1.Rows[i].FindControl("TextBox2")).Visible = true;
            }
            grdCount1 = grdCount1 + Convert.ToInt32(GridView1.Rows[i].Cells[1].Text);
            grdCount2 = grdCount2 + ra;
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBox = (TextBox)sender;

        GridViewRow grd = (GridViewRow)(TextBox.NamingContainer);
        //List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        //    CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
        TextBox txtf = (TextBox)grd.FindControl("TextBox1");
        HiddenField hd = (HiddenField)grd.FindControl("HiddenField3");
        HiddenField hdtype = (HiddenField)grd.FindControl("hdType");
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
        HiddenField2.Value = Convert.ToString(Convert.ToInt32(grd.Cells[2].Text) - Convert.ToInt32(HiddenField5.Value));
        HiddenField4.Value = hd.Value;
        //HiddenField3
        DataSet dd = obCommonFuction.FillDatasetByProc("call GetBundaleNo1(" + Session["UserID"] + "," + hd.Value + "," + txtf.Text + "," + HiddenField2.Value + "," + hdtype.Value + ")");
        GridView2.DataSource = dd.Tables[0];
        GridView2.DataBind();
        Div1.Style.Add("display", "block");
        Div2.Style.Add("display", "block");
    }
    protected void Button15_Click1(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow grd = (GridViewRow)(btn.NamingContainer);
        Div8.Style.Add("display", "block");
        Div7.Style.Add("display", "block");
        HiddenField hd12 = (HiddenField)grd.FindControl("HiddenField3");
        DataSet dt = obCommonFuction.FillDatasetByProc(@"call dptStockDetailsReport(" + Session["USerID"] + "," + hd12.Value + ",0,0,'2019-2020')");
        grd15.DataSource = dt.Tables[0];
        grd15.DataBind();
    }


    protected void Button8_Click(object sender, EventArgs e)
    {
        SubQuery = "";
        //SubQuery1 = "";

        for (int i = 0; i < GridView2.Rows.Count; i++)
        {//CheckBox1
            if (((CheckBox)GridView2.Rows[i].FindControl("CheckBox1")).Checked == true)
            {

                // obCommonFuction.FillDatasetByProc("insert into dpt_interdepotransdetails (OrderNo,ChallanNo,SubjectID,DepoID,BandalNo)values ('" + ddlChallano.SelectedValue + "','" + ddlChallano.SelectedItem.Text + "',0," + Session["userID"] + ",'" + GridView2.Rows[i].Cells[2].Text + "')");
                if (SubQuery == "")
                {
                    SubQuery = SubQuery + "" + GridView2.Rows[i].Cells[2].Text + "";
                }
                else
                {
                    SubQuery = SubQuery + "," + GridView2.Rows[i].Cells[2].Text + "";
                }
                //titleIDa=hi

               
            }
        }

        obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new2('" + SubQuery + "','" + hdnMasterId1.Value + "','" + DropDownList1.SelectedValue+ "'," + Session["userID"] + "," + HiddenField4.Value + ")");
        DropDownList1_SelectedIndexChanged(sender, e);
        Div1.Style.Add("display", "none");
        Div2.Style.Add("display", "none");
    }



    protected void Button9_Click(object sender, EventArgs e)
    {
        Div1.Style.Add("display", "none");
        Div2.Style.Add("display", "none");
        //Response.Redirect("DistributeYojnaBookWithBarcode.aspx");
    }
    protected void B13_Click(object sender, EventArgs e)
    {
        Div8.Style.Add("display", "none");
        Div7.Style.Add("display", "none");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Button bt = (Button)sender;
        GridViewRow grdrow = (GridViewRow)bt.NamingContainer;
        ////ds
        HiddenField6.Value = grdrow.Cells[3].Text;
        TextBox txtb = ((TextBox)grdrow.FindControl("TextBox2"));
        HiddenField hdtype = (HiddenField)grdrow.FindControl("hdType");
       // obCommonFuction.FillDatasetByProc("call Fn_CursorStocklooseforSamany(" + hdnMasterId1.Value + "," + bt.CommandArgument + "," + HiddenField6.Value + "," + Convert.ToString(Session["UserID"]) + "," + Request.QueryString["ChalanNo"] + ")");
        DataSet dt = obCommonFuction.FillDatasetByProc("call Fn_CursorLosseSupply_Samany(" + DropDownList1.SelectedItem.Text + "," + bt.CommandArgument + "," + Session["UserID"].ToString() + ")");

        DropDownList1_SelectedIndexChanged(sender, e);
        //DataSet ds = obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new1('" + hdtype.Value + "','" + txtb.Text + "',002," + Convert.ToString(Session["UserID"]) + "," + bt.CommandArgument + ")");
        //grdPrinterBundleDetails.DataSource = ds;
        //grdPrinterBundleDetails.DataBind();
        //Label10.Text = grdrow.Cells[3].Text;
        //fadeDiv.Style.Add("display", "block");
        //Messages.Style.Add("display", "block");

        ////grdPrinterBundleDetails\\\

        //for (int j = 0; j < grdPrinterBundleDetails.Rows.Count; j++)
        //{
        //    //if (((TextBox)grdPrinterBundleDetails.Rows[j].FindControl("txtb")).Text.ToString() != "")
        //    //{
        //    //    //total = total + Convert.ToInt32(((TextBox)grdPrinterBundleDetails.Rows[j].FindControl("txtb")).Text);
        //    TextBox txtb1 = (TextBox)grdPrinterBundleDetails.Rows[j].FindControl("txtb"); //(TextBox)grd.FindControl("txtb");
        //    txtb1.Visible = true;
        //    txtb1.Text = (Label10.Text);
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

        //    int id = Convert.ToInt32(Label10.Text);
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

        //}

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        fadeDiv.Style.Add("display", "none");
        Messages.Style.Add("display", "none");
    }
 
    //looj Save

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


             
            fadeDiv.Style.Add("display", "none");
            Messages.Style.Add("display", "none");
            string str1 = "";
            string str2 = "";
            for (int i = 0; i < grdPrinterBundleDetails.Rows.Count; i++)
            {
                hdnDetailsid.Value = ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value;

                Label txtBundle = ((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I"));
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
                if (str1 == "''")
                {
                    obCommonFuction.FillDatasetByProc(@"update dpt_stockdetailschild_t set BookSellerChallan='" + DropDownList1.SelectedValue + "',IsDistribute =4 ,DistributID =" + Convert.ToString(hdnMasterId1.Value) + " where StockDetailsChildID_I='" + hdnDetailsid.Value + "'");

                }
                else
                {
                    if (str2 == "''")
                    {
                        str2 = ".";
                        obCommonFuction.FillDatasetByProc(@"update dpt_stockdetailschild_t set IsDistribute=4, RemaingLoose_V='" + str2 + "',RemainingStock=" + str1 + ", BookSellerChallan='" + DropDownList1.SelectedValue + "' ,DistributID =" + Convert.ToString(hdnMasterId1.Value) + " where StockDetailsChildID_I='" + hdnDetailsid.Value + "'");
                    }
                    else
                    {
                        obCommonFuction.FillDatasetByProc(@"update dpt_stockdetailschild_t set  RemaingLoose_V=" + str2 + ",RemainingStock=" + str1 + ", BookSellerChallan='" + DropDownList1.SelectedValue + "' ,DistributID =" + Convert.ToString(hdnMasterId1.Value) + " where StockDetailsChildID_I='" + hdnDetailsid.Value + "'");
                    }

                    obCommonFuction.FillDatasetByProc("call USP_DPT_dtp_loosebandaldetailsSave ('BookSeller'," + ddlBookSllerName.SelectedValue + "," + hdnMasterId1.Value + "," + hdnDetailsid.Value + "," + txtBundle.Text + "," + str1 + "," + DropDownList1.SelectedValue + ")");
                }

                str1 = "";
                str2 = "";
                hdnDetailsid.Value = "";
            }
          //  Button3_Click1(sender, e);

             //}
             // else
             // {
             //     Label8.Text = " आपके द्वारा डाले गए लूज पुस्तक की संख्या दिए जाने वाले पुस्तक की संख्या सामान नहीं  है .";
             //     ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert ');</script>");
             //     fadeDiv.Style.Add("display", "block");
             //     Messages.Style.Add("display", "block");
             // }

        }
        catch { }
        DropDownList1_SelectedIndexChanged(sender, e);
        //Button3_Click1(sender, e);
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
    protected void Button15_Click(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();
        obCommonFuction.FillDatasetByProc("update dpt_bookselledemandmaster set Issumbited_I=2 where OrderNo= '" + DropDownList1.SelectedItem.Text + "' ");
        Response.Redirect("BookSellerChallanDetails.aspx?ChallanID=" + DropDownList1.SelectedValue + "&BookSellerID=" + ddlBookSllerName.SelectedValue + "");
    }
    protected void Button16_Click(object sender, EventArgs e)
    {
        try { 
        obCommonFuction.FillDatasetByProc("call USP_DPTBookSellerBookDistribute(" + Request.QueryString["Achall"] + ",'" + DropDownList1.SelectedValue + "'," + Session["UserID"] + ")");
        }
        catch { }
        // ddlBookSllerName_SelectedIndexChanged(sender, e);
       
        DropDownList1_SelectedIndexChanged(sender, e);
        Button16.Visible = false;

    }
    protected void Button116_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            obCommonFuction.FillDatasetByProc("call Fn_CursorStocklooseforSamany(" + hdnMasterId1.Value + "," + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField3")).Value + "," + GridView1.Rows[i].Cells[3].Text.ToString() + "," + Convert.ToString(Session["UserID"]) + "," + Request.QueryString["ChalanNo"] + ")");
        }

        DropDownList1_SelectedIndexChanged(sender, e);
    }

    protected void btn13_Click(object sender, EventArgs e)
    {
        Button bt = (Button)sender;
        GridViewRow grdrow = (GridViewRow)bt.NamingContainer;
        HiddenField hd = (HiddenField)grdrow.FindControl("HiddenField3");
        Div5.Style.Add("display", "block");
        Div6.Style.Add("display", "block");

        GridView4.DataSource = obCommonFuction.FillDatasetByProc(@" SELECT BundleNo_I FROM  dpt_stockdetailschild_t
     INNER JOIN dpt_stockdetails_t ON dpt_stockdetails_t.StockDetailsID_I=dpt_stockdetailschild_t.StockDetailsID_I where SubJectID_I=" + hd.Value + " and BookSellerChallan=" + Request.QueryString["Bchall"] + "");
        GridView4.DataBind();

    }
    protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
    {

        obCommonFuction.FillDatasetByProc("Update dpt_stockdetailschild_t SET `IsDistribute`=0,`distributID`=0 where BundleNo_I=" + GridView4.SelectedDataKey.Value.ToString() + " ");

        DropDownList1_SelectedIndexChanged(sender, e);
        Div5.Style.Add("display", "block");
        Div6.Style.Add("display", "block");
    }

    protected void Button13_Click(object sender, EventArgs e)
    {
        Div5.Style.Add("display", "none");
        Div6.Style.Add("display", "none");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            obCommonFuction.FillDatasetByProc("UPDATE dpt_stockdetailschild_t SET IsDistribute =4,DistributID =" + Request.QueryString["Achall"] + ",BookSellerChallan=" + Request.QueryString["ChalanNo"] + " WHERE FIND_IN_SET (BundleNo_I,'" + TextBox2.Text + "') AND IsDistribute=0 AND IFNULL(iflooj,0)=0 and BundleType_I=2; ");
        }
        catch { }
        ddlBookSllerName_SelectedIndexChanged(sender, e);
        DropDownList1_SelectedIndexChanged(sender, e);
        Div3.Style.Add("display", "none");
        Div4.Style.Add("display", "none");
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Div3.Style.Add("display", "none");
        Div4.Style.Add("display", "none");
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Div3.Style.Add("display", "block");
        Div4.Style.Add("display", "block");
    }
    
}