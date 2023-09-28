using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Collections;
using System.Data.OleDb;
using System.Data;
using System.IO;
public partial class Depo_InterDepoSendChallan : System.Web.UI.Page
{
    int totalBook = 0;
    int TotalLooj = 0;
    int TotalPaik = 0;
    int TotalPaik1 = 0;
    int TotalPaik2 = 0;
    int aj = 0;
    decimal total_TotalBookpaik = 0;
    string SubQuery, SubQuery1;
    int titleIDa;
    CommonFuction obCommonFuction = new CommonFuction();
    int count12;

    ArrayList aa = new ArrayList();
    int TotalBandal, count1; int total = 0, total112, total113;
    int grdCount1, grdCount2;
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
        try {
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
            obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('" + TextBox1.Text.Trim() + "','" + ddlChallano.SelectedValue + "',0," + Convert.ToString(Session["UserID"]) + "," + HiddenField4.Value + ")");
            //try
            //{
            //    obCommonFuction.FillDatasetByProc("call USP_Dpt_ChallanDetailsBundel(0," + HiddenField4.Value + ",'" + ddlChallano.SelectedValue + "','" + TextBox1.Text + "'," + Session["UserID"] + ")");
            //}
            //catch { }
            Button3_Click1(sender, e);
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
    protected void grdPrinterBundleDetails0_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                aj += 1;
                try
                {
                    totalBook += e.Row.Cells[1].Text.Trim().Length == 0 ? 0 : Convert.ToInt32(e.Row.Cells[1].Text.Replace("&nbsp;", "0"));//Convert.ToInt32(e.Row.Cells[1].Text);
                    // total_BundleNo_IMin += e.Row.Cells[7].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[7].Text);

                }
                catch { }
                try
                {
                    TotalLooj += e.Row.Cells[2].Text.Trim().Length == 0 ? 0 : Convert.ToInt32(e.Row.Cells[2].Text.Replace("&nbsp;", "0"));

                }
                catch { }
                try
                {
                    TotalPaik += e.Row.Cells[3].Text.Trim().Length == 0 ? 0 : Convert.ToInt32(e.Row.Cells[3].Text.Replace("&nbsp;", "0"));
                }
                catch { }
                try
                {
                    TotalPaik1 += e.Row.Cells[4].Text.Trim().Length == 0 ? 0 : Convert.ToInt32(e.Row.Cells[4].Text.Replace("&nbsp;", "0"));
                }
                catch { }

                try
                {
                    TotalPaik2 += e.Row.Cells[5].Text.Trim().Length == 0 ? 0 : Convert.ToInt32(e.Row.Cells[5].Text.Replace("&nbsp;", "0"));
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
            e.Row.Cells[0].Text = aj.ToString();
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[1].Text = totalBook.ToString();
            e.Row.Cells[2].Text = TotalLooj.ToString();
            e.Row.Cells[3].Text = TotalPaik.ToString();
            e.Row.Cells[4].Text = TotalPaik1.ToString();
            e.Row.Cells[5].Text = TotalPaik2.ToString();
            //e.Row.Cells[7].Text = total_BundleNo_IMin.ToString();
            //e.Row.Cells[8].Text = total_BundleNo_Imax.ToString();
            //e.Row.Cells[9].Text = total_FromNo_I.ToString();
            //e.Row.Cells[10].Text = total_ToNo_I.ToString();

        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {
                ddlChallano.DataSource = obCommonFuction.FillDatasetByProc("call USP_DPTInterDepoChallan(" + Session["UserID"] + ",0,0)");
                ddlChallano.DataTextField = "ChallanNo_V";
                ddlChallano.DataValueField = "ChallanNo_V";
                ddlChallano.DataBind();
                ddlChallano.Items.Insert(0, "Select..");
                ddlSessionYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
                ddlSessionYear.DataValueField = "AcYear";
                ddlSessionYear.DataTextField = "AcYear";
                ddlSessionYear.DataBind();
             ddlSessionYear.SelectedValue= obCommonFuction.FillDatasetByProc("select GetAcYear1()").Tables[0].Rows[0][0].ToString();
                if (Request.QueryString["ChallanID"] != null)
                {
                    ddlChallano.SelectedItem.Text = Request.QueryString["ChallanID"].ToString();
                    Button3_Click1(sender, e);
                }

            }
            catch { }
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
        try
        {

            DataSet dd = obCommonFuction.FillDatasetByProc("call USP_DPT_InterDepoDataSave(" + ddlChallano.SelectedValue + ")");
        }

        catch (Exception ex)
        { 
        }
            Label1.Text = "आपका डाटा सम्बंधित डिपो को भेजा जा चूका  है ";
            grdPrinterBundleDetails.DataSource = null;
            grdPrinterBundleDetails.DataBind();
            GridView1.DataSource = null;
            GridView1.DataBind();

       
    }
    protected void grdPrinterBundleDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    protected void ddlChallano_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void Button3_Click(object sender, EventArgs e)
    {

    }
    protected void Button3_Click1(object sender, EventArgs e)
    {
        try
        {
            Button6.Visible = true;
            string lblfyYaer;
            lblfyYaer = obCommonFuction.FillDatasetByProc("select GetAcYear1()").Tables[0].Rows[0][0].ToString();


            DataSet ds = obCommonFuction.FillDatasetByProc("Call USPDPTGetInterDepoChallan('" + ddlChallano.SelectedValue + "'," + Session["UserID"] + ",'" + ddlSessionYear.SelectedValue + "','" + ddlChallano.SelectedItem.Text + "')");
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
                    ((TextBox)GridView1.Rows[i].FindControl("TextBox2")).Visible = true;
                }
                else
                {
                    ((Button)GridView1.Rows[i].FindControl("Button4")).Visible = false;
                    ((TextBox)GridView1.Rows[i].FindControl("TextBox2")).Visible = false;
                    total112 = total112 + 1;
                }

                if (GridView1.Rows[i].Cells[1].Text == aa)
                {
                    ((Button)GridView1.Rows[i].FindControl("Button4")).Visible = false;
                    ((TextBox)GridView1.Rows[i].FindControl("TextBox2")).Visible = false;

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
            //DataSet dd1 = obCommonFuction.FillDatasetByProc("call USP_DPTChallanDetails(" + ddlChallano.SelectedItem.Text + ",0)");
            //if (dd1.Tables[0].Rows.Count > 0)
            //{
            //    a.Style.Add("display", "block");
            //    lblDist.Text = Convert.ToString(dd1.Tables[0].Rows[0]["District_Name_Hindi_V"]);
            //    lblBlock.Text = Convert.ToString(dd1.Tables[0].Rows[0]["BlockNameHindi_V"]);
            //    lblChallNo.Text = Convert.ToString(dd1.Tables[0].Rows[0]["ChallanNo_V"]);
            //    lblChallandate.Text = Convert.ToString(dd1.Tables[0].Rows[0]["ChallanDate_D"]);
            //    Label10.Text = Convert.ToString(dd1.Tables[0].Rows[0]["DriverMobileNo_V"]);
            //    Label11.Text = Convert.ToString(dd1.Tables[0].Rows[0]["TruckNo_V"]);
            //    Label12.Text = Convert.ToString(dd1.Tables[0].Rows[0]["GRNO_V"]);
            //    Label13.Text = Convert.ToString(dd1.Tables[0].Rows[0]["GRNODate_D"]);
            //}
            if (grdCount1 == grdCount2)
            {
                Button1.Visible = true;
                // Button6.Visible = true;
            }
            else
            {
                Button1.Visible = false;
                //Button6.Visible = false;
            }


        }
        catch { }

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Button bt = (Button)sender;
        GridViewRow grdrow = (GridViewRow)bt.NamingContainer;
        ////ds
        HiddenField6.Value = grdrow.Cells[3].Text;
        TextBox txtb = ((TextBox)grdrow.FindControl("TextBox2"));
        HiddenField hdtype = (HiddenField)grdrow.FindControl("hdType");
        DataSet ds = obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new1('" + hdtype.Value + "','" + txtb.Text + "',002," + Convert.ToString(Session["UserID"]) + "," + bt.CommandArgument + ")");
        grdPrinterBundleDetails.DataSource = ds;
        grdPrinterBundleDetails.DataBind();
        Label2.Text = grdrow.Cells[3].Text;
        fadeDiv.Style.Add("display", "block");
        Messages.Style.Add("display", "block");
      
        //grdPrinterBundleDetails\\\

       

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


            //for (int j = 0; j < grdPrinterBundleDetails.Rows.Count; j++)
           // {
              //  if (((TextBox)grdPrinterBundleDetails.Rows[j].FindControl("txtb")).Text.ToString() != "")
               // {
               //     total = total + Convert.ToInt32(((TextBox)grdPrinterBundleDetails.Rows[j].FindControl("txtb")).Text);
                //}
          //  }


          //  if (Convert.ToInt32(Label2.Text) == total)
           // {
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
                                count12 =1;
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
                      
                        obCommonFuction.FillDatasetByProc("call USP_InterDepo01(" + Convert.ToInt32(((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value)  + "," + ddlChallano.SelectedItem.Text + ","+count12+")");
                       
                        if (str2.ToString() == "''")
                        {
                            str2 = ".";
                            obCommonFuction.FillDatasetByProc("update dpt_stockdetailschild_t set AcYear='2019-2020', DistributID=" + ddlChallano.SelectedItem.Text + ", IsDistribute=2 where StockDetailsChildID_I=" + Convert.ToInt32(((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + ""));

                            obCommonFuction.FillDatasetByProc("call USP_DPT_dtp_loosebandaldetailsSave ('InterDepo',0,0," + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField2")).Value + ",0," + str1 + "," + ddlChallano.SelectedItem.Text + ")");
                        }
                        else
                        {
                            try
                            {
                                obCommonFuction.FillDatasetByProc("update dpt_stockdetailschild_t set  AcYear='2019-2020',IsDistribute =2, DistributID=" + ddlChallano.SelectedItem.Text + ",RemaingLoose_V =" + str1 + ",RemainingStock=" + str2 + " where StockDetailsChildID_I=" + Convert.ToInt32(((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + ""));
                                 obCommonFuction.FillDatasetByProc("call USPInsertInterDepo(" + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + ")");

                                 //obCommonFuction.FillDatasetByProc("update dpt_stockdetailschild_t set IsDistribute =0, DistributID=0 where StockDetailsChildID_I=" + Convert.ToInt32(((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + ""));
                                obCommonFuction.FillDatasetByProc("call USP_DPT_dtp_loosebandaldetailsSave ('InterDepo',0,0," + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + ",0," + str1 + "," + ddlChallano.SelectedItem.Text + ")");
                           
                            }
                            catch { }

                        }
                        obCommonFuction.FillDatasetByProc("insert into dpt_interdepotransdetails (OrderNo,ChallanNo,SubjectID,DepoID,BandalNo,looJbook)values ('" + ddlChallano.SelectedValue + "','" + ddlChallano.SelectedItem.Text + "',0," + Session["userID"] + ",'" + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I")).Text + "'," + str1 + ")");



                    }

                    str1 = "";
                    str2 = "";

                }
               // Button3_Click1(sender, e);

           // }
            //else
           // {
              //  Label8.Text = " आपके द्वारा डाले गए लूज पुस्तक की संख्या दिए जाने वाले पुस्तक की संख्या सामान नहीं  है .";
                //   ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert ');</script>");
              //  fadeDiv.Style.Add("display", "block");
               // Messages.Style.Add("display", "block");
            //}

        }
        catch { }
        Button3_Click1(sender, e);

    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        //Response.Redirect("ReceiptDetails.aspx?ChallanID=" + ddlChallano.SelectedItem.Text + "");
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Redirect("InterDepoBarcodeDisti.aspx");
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
        Button bt= (Button)grd.FindControl("Button11");
        
        string Bandal = grd.Cells[2].Text;

        try
        {
            HiddenField5.Value = bt.Text;
        }
        catch { }
        if (HiddenField5.Value == "&nbsp;")
        {
            HiddenField5.Value = "0";
        }
        if (bt.Text == "")
        {
            bt.Text = "0";
            HiddenField5.Value="0";
        }
        HiddenField2.Value = Convert.ToString(Convert.ToInt32(grd.Cells[2].Text) - Convert.ToInt32(HiddenField5.Value));
        HiddenField4.Value = hd.Value;
        //HiddenField3
        DataSet dd = obCommonFuction.FillDatasetByProc("call GetBundaleNo1(" + Session["UserID"] + "," + hd.Value + "," + txtf.Text + "," + HiddenField2.Value + "," + hdtype.Value + ")");
        GridView2.DataSource = dd.Tables[0];
        GridView2.DataBind();
        Div1.Style.Add("display", "block");
        Div2.Style.Add("display", "block");
        txtf.Visible = false;
    }
    //
    protected void Button8_Click(object sender, EventArgs e)
    {
        //if (Convert.ToInt32(HiddenField2.Value) == Convert.ToInt32(GridView2.Rows.Count))
        //{
        SubQuery = "";
        SubQuery1 = "";
       
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
               
                if (SubQuery1 == "")
                {
                    SubQuery1 = SubQuery1 + "(" + ddlChallano.SelectedValue + "," + ddlChallano.SelectedItem.Text + ",0," + Session["userID"] + "," + GridView2.Rows[i].Cells[2].Text + ")";
                }
                else
                {
                    SubQuery1 = SubQuery1 + ",(" + ddlChallano.SelectedValue + "," + ddlChallano.SelectedItem.Text + ",0," + Session["userID"] + "," + GridView2.Rows[i].Cells[2].Text + ")";
                }
            }
        }

        obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new1('" + SubQuery + "','" + ddlChallano.SelectedItem.Text + "',0," + Session["userID"] + ","+HiddenField4.Value+")");

  

       // obCommonFuction.FillDatasetByProc("insert into dpt_interdepotransdetails (OrderNo,ChallanNo,SubjectID,DepoID,BandalNo)values "+SubQuery1+"");
        //obCommonFuction.FillDatasetByProc("CALL SaveInterDepo('" + SubQuery1 + "')");
     //   Button3_Click1(sender, e);
        Div1.Style.Add("display", "none");
        Div2.Style.Add("display", "none");
        HiddenField2.Value = "";
        HiddenField4.Value = "";
        //}
        //else
        //{
        //    Label1.Text = "आपके द्वारा भेजे जाने वाले बंडल की संख्या भेजे जाने वाले बंदला की संख्या से  कम है ";

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
        try
        {
            for (int i = 0; i < GridView3.Rows.Count; i++)
            {//CheckBox1
                if (((CheckBox)GridView3.Rows[i].FindControl("CheckBox1")).Checked == true)
                {//`CheckBandleNo` (BundleNo_IA int ,SubJectID_IA int ,UserID_IA int)
                    DataSet ss = obCommonFuction.FillDatasetByProc("call CheckBandleNo ('" + GridView3.Rows[i].Cells[2].Text + "'," + HiddenField4.Value + "," + Convert.ToString(Session["UserID"]) + ")");
                    if (ss.Tables[0].Rows.Count > 0)
                    {
                        GridView3.Rows[i].Cells[2].BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        GridView3.Rows[i].Cells[2].BackColor = System.Drawing.Color.Red;
                    }
                    try
                    {
                        DataSet dd = obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new1('" + GridView3.Rows[i].Cells[2].Text + "','" + ddlChallano.SelectedValue + "',0," + Convert.ToString(Session["UserID"]) + "," + HiddenField4.Value + ")");
                        //obCommonFuction.FillDatasetByProc("insert into dpt_interdepotransdetails (OrderNo,ChallanNo,SubjectID,DepoID,BandalNo,looJbook)values ('" + ddlChallano.SelectedValue + "','" + ddlChallano.SelectedItem.Text + "'," + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("hdType")).Value + "," + Session["userID"] + ",'" + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I")).Text + "'," + str1 + ")");
                    }
                    catch { }

                }
            }
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
   
    protected void Button13_Click(object sender, EventArgs e)
    {
        Div5.Style.Add("display", "none");
        Div6.Style.Add("display", "none");
        //Response.Redirect("DistributeYojnaBookWithBarcode.aspx");
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
    protected void B13_Click(object sender, EventArgs e)
    {
        Div8.Style.Add("display", "none");
        Div7.Style.Add("display", "none");
    }
    protected void Button6_Click1(object sender, EventArgs e)
    {
        Div9.Style.Add("display", "block");
        Div10.Style.Add("display", "block"); string lblfyYaer;
        lblfyYaer = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();

        DataSet ds1 = obCommonFuction.FillDatasetByProc("Call USPDPTGetInterDepoChallan('" + ddlChallano.SelectedValue + "'," + Session["UserID"] + ",'" + lblfyYaer.ToString() + "','" + ddlChallano.SelectedItem.Text + "')");
        GridView5.DataSource = ds1;
        GridView5.DataBind();
        DataSet ds12 = obCommonFuction.FillDatasetByProc("call GetInterdepoDetails('"+ddlChallano.SelectedValue+"')");
        lblSenderDepo.Text = ds12.Tables[0].Rows[0]["SupplierDepo"].ToString();
        lblReceiverDepot.Text = ds12.Tables[0].Rows[0]["DemandingDepot"].ToString();
        //GetInterdepoDetails
        lblChallan.Text = ddlChallano.SelectedItem.Text;
    }
    protected void btnClose(object sender, EventArgs e)
    {
        Div9.Style.Add("display", "none");
        Div10.Style.Add("display", "none");
     
     }

    protected void grdPrinterBundleDetailsRowdata(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Label lblPerBundle = (Label)e.Row.Cells[3].FindControl("lblPerBundle");
             

            List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
            TextBox txtb = (TextBox)e.Row.FindControl("txtb");
            txtb.Visible = true;
            Label BandalNo = (Label)e.Row.FindControl("BundleNo_I");
            Label txtf = (Label)e.Row.FindControl("FromNo_I");
            Label txtPer = (Label)e.Row.FindControl("lblPer");
            Label txtTo = (Label)e.Row.FindControl("ToNo_I");
            CheckBoxList obChkLooseBundleList = (CheckBoxList)e.Row.FindControl("ChkLooseBundleList");
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
            obChkLooseBundleList.DataSource = List;
            obChkLooseBundleList.DataTextField = "BookNo";
            obChkLooseBundleList.DataBind();
            //
            //CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
            //Label txtf = (Label)grd.FindControl("FromNo_I");
            //Label txtPer = (Label)grd.FindControl("lblPer");
            //Label txtTo = (Label)grd.FindControl("ToNo_I");
            // CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
           // txtb.Text=HiddenField6.Value;
            //int id = Convert.ToInt32(HiddenField6.Value);
            //TotalBandal = TotalBandal + id;
            //foreach (ListItem items in obChkLooseBundleList.Items)
            //{
            //    count12 = count12 + 1;
            //    if (id >= count12)
            //    {
            //        items.Selected = true;
            //    }
            //    else
            //    { items.Selected = false; }

            //}
            //
       
    }
        
    }
    protected void Button16_Click(object sender, EventArgs e)
    {
        obCommonFuction.FillDatasetByProc("call USP_DPTInterDepoPaikBundleSuply("+ddlChallano.SelectedValue+","+Session["UserID"]+",'"+ddlSessionYear.SelectedValue +"')");
        Button3_Click1( sender,  e);
    }
    protected void Button15_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        GridViewRow grd = (GridViewRow)(btn.NamingContainer);
        HiddenField hd1 = (HiddenField)grd.FindControl("HiddenField3");
        HiddenField hd2 = (HiddenField)grd.FindControl("hdType");
        Div13.Style.Add("display", "block");
        Div14.Style.Add("display", "block");
        GridView6.DataSource = obCommonFuction.FillDatasetByProc("call USP_InterDepoBunlde(" + ddlChallano.SelectedValue + "," + hd2.Value + "," + hd1.Value+ ")");
        GridView6.DataBind();
        //TitleID HiddenField3
        //hdType 
    }
    protected void Button18C(object sender, EventArgs e)
    {
        Div13.Style.Add("display", "none");
        Div14.Style.Add("display", "none");
    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obCommonFuction.FillDatasetByProc("delete from dpt_interdepoBookSupply where dpt_interdepoBookSupply.ID="+GridView1.DataKeys[e.RowIndex].Value+"");
  Button3_Click1( sender,  e);
    }
}