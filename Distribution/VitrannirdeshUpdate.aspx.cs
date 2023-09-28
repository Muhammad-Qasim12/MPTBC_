using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Distribution_VitrannirdeshUpdate : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            DdlACYear_SelectedIndexChanged(sender, e);
        }
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd = new DataSet();
     
            dd = obCommonFuction.FillDatasetByProc(@"select distinct Printer_RedID_I Printer_regid_i,TRIM( REPLACE( REPLACE(REPLACE( NameofPressHindi_V ,'Ms ',''),'M./s',''),'M/s','')) NameofPress_V from dis_vitrannirdesh
inner join pri_printerregistration_t on pri_printerregistration_t.Printer_RedID_I=PrinterID
where AcYear='" + DdlACYear.SelectedValue + "' order by TRIM( REPLACE( REPLACE(REPLACE( NameofPressHindi_V ,'Ms ',''),'M./s',''),'M/s',''))");
        
        DDLPrinter.DataSource = dd.Tables[0];
        DDLPrinter.DataValueField = "Printer_regid_i";
        DDLPrinter.DataTextField = "NameofPress_V";
        DDLPrinter.DataBind();
        DDLPrinter.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void DDLPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GetVitranNIrdesh
        DataSet dd = new DataSet();
      
            dd = obCommonFuction.FillDatasetByProc("call GetVitranNIrdesh(0," + DDLPrinter.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "' ,'0')");
      
        ddlOrderNo.DataSource = dd.Tables[0];
        ddlOrderNo.DataValueField = "VitranNo";
        ddlOrderNo.DataTextField = "VitranNo";
        ddlOrderNo.DataBind();
        ddlOrderNo.Items.Insert(0, new ListItem("Select", "0"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet ddd = obCommonFuction.FillDatasetByProc("call GetVitranNIrdeshN('" + ddlOrderNo.SelectedValue + "'," + DDLPrinter.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "','4')");
        GrdVitranNirdesh.DataSource = ddd.Tables[0];
     GrdVitranNirdesh.DataBind();
    
    }
    protected void txtChange(object sender, EventArgs e)
    {

        TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        TextBox TextBox1 = (TextBox)grd.FindControl("TextBox1");
        
        TextBox txt1 = (TextBox)grd.FindControl("lblTotalBundles");
         Label LblBundleNoFrom = (Label)grd.FindControl("LblBundleNoFrom");
         Label LblBundleNOTo = (Label)grd.FindControl("LblBundleNOTo");
         TextBox lblNoOfBooks = (TextBox)grd.FindControl("lblNoOfBooks");
         Label LblBookNoFrom = (Label)grd.FindControl("LblBookNoFrom");
         Label LblBookNoTo = (Label)grd.FindControl("LblBookNoTo");
        

         txt1.Text = Convert.ToString(Convert.ToInt32(lblNoOfBooks.Text) / Convert.ToInt32(TextBox1.Text));
         LblBundleNOTo.Text = Convert.ToString((Convert.ToInt32(txt1.Text) - 1) + Convert.ToInt32(LblBundleNoFrom.Text));
         LblBookNoTo.Text = Convert.ToString((Convert.ToInt32(lblNoOfBooks.Text) - 1) + Convert.ToInt32(LblBookNoFrom.Text));
    }
    protected void Button2_Click(object sender, EventArgs e)
    {//BooksPerBundlea INT,TotalBundelsa INT,BundleNoFroma INT,BundleNoToa INT ,IDa INT
       // UpdateVitran

        for (int i = 0; i < GrdVitranNirdesh.Rows.Count; i++)
        {
            obCommonFuction.FillDatasetByProc("call UpdateVitran('" + ((TextBox)GrdVitranNirdesh.Rows[i].FindControl("lblTotalBundles")).Text + "','" + ((Label)GrdVitranNirdesh.Rows[i].FindControl("LblBundleNOTo")).Text + "', '" + ((TextBox)GrdVitranNirdesh.Rows[i].FindControl("lblNoOfBooks")).Text + "', '" + ((Label)GrdVitranNirdesh.Rows[i].FindControl("LblBookNoFrom")).Text + "', '" + ((Label)GrdVitranNirdesh.Rows[i].FindControl("LblBookNoTo")).Text + "','" + ((HiddenField)GrdVitranNirdesh.Rows[i].FindControl("HiddenField1")).Value + "')");

        
        }
        GrdVitranNirdesh.DataSource = null;
        GrdVitranNirdesh.DataBind();
    }
}