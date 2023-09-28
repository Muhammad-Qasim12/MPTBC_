using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
using System.IO;
public partial class Depo_ExtraDenad : System.Web.UI.Page
{
    string DepoTrno_Ia, MediumIDa, classA;
    string Bookstatus;
    Dis_TentativeDemandHistory objTentativeDemandHistory;
    CommonFuction obCommonFuction = new CommonFuction();
    Decimal value1, value2, value3, value4, value5, value6;
    string demandType1;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            DDlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DDlDepot.DataValueField = "DepoTrno_I";
            DDlDepot.DataTextField = "DepoName_V";
            DDlDepot.DataBind();
            DDlDepot.Items.Insert(0, new ListItem("--Select--", "0"));

            objTentativeDemandHistory = new Dis_TentativeDemandHistory();
            DdlScheme.DataSource = objTentativeDemandHistory.MedumFill();
            DdlScheme.DataValueField = "MediumTrno_I";
            DdlScheme.DataTextField = "MediunNameHindi_V";
            DdlScheme.DataBind();
            DdlScheme.Items.Insert(0, new ListItem("--Select--", "0"));
            Random rand = new Random();
            int randnum = rand.Next(100000, 10000000);
            TextBox1.Text = randnum.ToString();
            // TextBox1.Enabled = false;
            TextBox2.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button3.Visible = true;
        if (RadioButtonList1.SelectedValue == "1")
        {
            Bookstatus = "1";
        }
        else if (RadioButtonList1.SelectedValue == "2")
        {
            Bookstatus = "0,2";
        }
        else
        {

            Bookstatus = "0,1,2";
        }
        //`db_live_mptbctest`.`GetDemandFinal` (YearID varchar(50),DepoTrno_Ia int,MediumIDa int,classA varchar(50))
        if (DDlDepot.SelectedIndex == 0)
        {
            DepoTrno_Ia = "0";
        }
        else
        {
            DepoTrno_Ia = DDlDepot.SelectedValue;
        }
        if (DdlScheme.SelectedIndex == 0)
        {
            MediumIDa = "0";
        }
        else
        {
            MediumIDa = DdlScheme.SelectedValue;
        }
        if (DDLClass.SelectedIndex == 0)
        {
            classA = "0";
        }
        else
        {
            if (DDLClass.SelectedValue.ToString() == "1-8")
            {
                classA = "1,2,3,4,5,6,7,8";
            }
            else if (DDLClass.SelectedValue.ToString() == "9-12")
            {
                classA = "9,10,11,12";
            }

            // = DDLClass.SelectedValue;
        }
        CommonFuction comm = new CommonFuction();
        DataSet dd = comm.FillDatasetByProc("call GetDemandFinal1('" + DdlACYear.SelectedItem.Text + "'," + DepoTrno_Ia + "," + MediumIDa + ",'" + classA + "','" + Bookstatus + "')");

        GridView1.DataSource = dd.Tables[0];
        GridView1.DataBind();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        //TextBox TextBox = (TextBox)sender;
        //GridViewRow grd = (GridViewRow)(TextBox.NamingContainer);
        //TextBox txtPer = (TextBox)grd.FindControl("txtPerBundle");
        //TextBox txtSchemcDe = (TextBox)grd.FindControl("txtSchemcDe");
        //TextBox txtSchemcDe1 = (TextBox)grd.FindControl("txtSchemcDe1");

        //TextBox txtOpnMkt1 = (TextBox)grd.FindControl("txtOpnMkt1");
        //TextBox txtOpnMkt = (TextBox)grd.FindControl("txtOpnMkt");
        //TextBox txtNetDemand = (TextBox)grd.FindControl("txtNetDemand");

        //txtSchemcDe.Text = Convert.ToString((Math.Round((Convert.ToDecimal(txtSchemcDe1.Text) / Convert.ToDecimal(txtPer.Text))) * Convert.ToDecimal(txtPer.Text)));
        //txtOpnMkt.Text = Convert.ToString((Math.Round((Convert.ToDecimal(txtOpnMkt1.Text) / Convert.ToDecimal(txtPer.Text))) * Convert.ToDecimal(txtPer.Text)));
        //txtNetDemand.Text = Convert.ToString(Convert.ToInt16(txtSchemcDe.Text) + Convert.ToInt16(txtOpnMkt.Text));
        //// var pack = Convert.ToInt32(lblnoofbooks.Text) / Convert.ToInt32(txtPerbundlebook1.Text);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        //    try
        //    {

        //        try
        //        {
        //            value1 += e.Row.Cells[3].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[3].Text);
        //        }
        //        catch { }
        //        try
        //        {
        //            value2 += e.Row.Cells[4].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[4].Text);
        //        }
        //        catch { }
        //        try
        //        {
        //            value3 += e.Row.Cells[5].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[5].Text);
        //        }
        //        catch { }
        //        try
        //        {
        //            value4 += e.Row.Cells[6].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[6].Text);
        //        }
        //        catch { }
        //        try
        //        {
        //            value5 += e.Row.Cells[7].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[7].Text);
        //        }
        //        catch { }
        //        try
        //        {
        //            //txtPerBundle2
        //            TextBox lblkulbook = (TextBox)e.Row.Cells[4].FindControl("txtPerBundle2");
        //            value6 += lblkulbook.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(lblkulbook.Text);
        //            //value6 += e.Row.Cells[8].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[8].Text);
        //        }
        //        catch { }


        //    }
        //    catch { }
        //}
        //if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    Label FToNo_I0 = (Label)e.Row.FindControl("FToNo_I0");
        //    Label lblFLoojBook = (Label)e.Row.FindControl("lblFLoojBook");
        //    e.Row.Style.Add("background", "#f1f1f1");
        //    e.Row.Cells[0].Text = "Total";
        //    e.Row.Cells[3].Text = value1.ToString();
        //    e.Row.Cells[4].Text = value2.ToString();
        //    e.Row.Cells[5].Text = value3.ToString();
        //    e.Row.Cells[6].Text = value4.ToString();
        //    e.Row.Cells[7].Text = value5.ToString();
        //    e.Row.Cells[8].Text = value6.ToString();
        }

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        //if (DDLClass.SelectedValue.ToString() == "1-8")
        //{
        //    classA = "1,2,3,4,5,6,7,8";
        //}
        //else if (DDLClass.SelectedValue.ToString() == "9-12")
        //{
        //    classA = "9,10,11,12";
        //}
        //if (CheckBox1.Checked == true)
        //{
        //    demandType1 = "1";
        //}
        //else
        //{
        //    demandType1 = "0";
        //}
        //obCommonFuction.FillDatasetByProc("call InsertPrintingData (" + DdlScheme.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "'," + DDlDepot.SelectedValue + ",'" + classA + "','" + TextBox1.Text + "','" + Convert.ToDateTime(TextBox2.Text, cult).ToString("yyyy-MM-dd") + "'," + RadioButtonList1.SelectedValue + "," + demandType1 + ")");

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (((TextBox)GridView1.Rows[i].FindControl("txtSchemcDe")).Text != "0" || ((TextBox)GridView1.Rows[i].FindControl("txtOpnMkt")).Text != "0")
            { 

            obCommonFuction.FillDatasetByProc("insert into dis_demandtoprintingnew ( TitleId,MediumId,AcYear,DepotID,SchemeDemand,OpnMktDemand,NetSchemeDemand,NetOpenMkt,DATE,UserId,TotSchemeDemand , TotNetSchemeDemand,  TotOpnMktDemand , TotNetOpenMkt , OrderNo ,  OrderDate )values (" + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value + "," + DdlScheme.SelectedValue + ",'" + DdlACYear.SelectedValue + "','" + DDlDepot.SelectedValue + "','" + ((TextBox)GridView1.Rows[i].FindControl("txtSchemcDe")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("txtOpnMkt")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("txtSchemcDe")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("txtOpnMkt")).Text + "','" + Convert.ToDateTime(System.DateTime.Now).ToString("yyyy-MM-dd") + "',25,'" + ((TextBox)GridView1.Rows[i].FindControl("txtSchemcDe")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("txtSchemcDe")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("txtOpnMkt")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("txtOpnMkt")).Text + "','" + TextBox1.Text + "','"+Convert.ToDateTime(TextBox2.Text,cult).ToString("yyyy-MM-dd")+"')");
            }
        }
        //SELECT  TitleId,MediumId,AcYear,DepotID,SchemeDemand,OpnMktDemand,NetSchemeDemand,NetOpenMkt,DATE,UserId,TotSchemeDemand , TotNetSchemeDemand,  TotOpnMktDemand , TotNetOpenMkt , OrderNo ,  OrderDate  FROM 
        mainDiv.Style.Add("display", "block");
        lblmsg.Style.Add("display", "block");
        mainDiv.Visible = true;
        lblmsg.Visible = true;
        lblmsg.Text = "डाटा प्रिंटिंग शाखा के उपयोग के लिए सुरक्षित कर लिया गया है | ";
        GridView1.DataSource = null;
        GridView1.DataBind();
        Button3.Visible = false;
        Random rand = new Random();
        int randnum = rand.Next(100000, 10000000);
        TextBox1.Text = randnum.ToString();
        //TextBox1.Enabled = false;

    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcell();
        }
        catch { }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "AVASKIJANKARI.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - word";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }
}