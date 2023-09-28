using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distribution_VitranNirdeshPrint : System.Web.UI.Page
{
    int Total1, Total2, Total3;
    DIS_DemandEstimation ObjDemandEstimation = new DIS_DemandEstimation();
    CommonFuction obCommonFuction = new CommonFuction();
    public string MessageB;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblAcademicYear.Text = "शिक्षा सत्र : " + DdlACYear.SelectedValue;
        if (!IsPostBack)
        {

           // lblDate.Text = System.DateTime.Now.ToString("MMM dd, yyyy");
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            DdlACYear_SelectedIndexChanged( sender,  e);

            //ddlOrderNo.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            //ddlOrderNo.DataValueField = "DepoTrno_I";
            //ddlOrderNo.DataTextField = "DepoName_V";
            //ddlOrderNo.DataBind();
            //ddlOrderNo.Items.Insert(0, new ListItem("All", "0"));

            //DDLPrinter.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DistributionorderonWorkorder('" + DdlACYear.SelectedValue.ToString() + "')");
            //DDLPrinter.DataValueField = "Printer_regid_i";
            //DDLPrinter.DataTextField = "NameofPress_V";
            //DDLPrinter.DataBind();
            //DDLPrinter.Items.Insert(0, new ListItem("All", "0"));

            //DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            //DdlClass.DataValueField = "ClassTrno_I";
            //DdlClass.DataTextField = "ClassDesc_V";
            //DdlClass.DataBind();
            //DdlClass.Items.Insert(0, new ListItem("All", "0"));

            //DdlTitle.Items.Insert(0, new ListItem("All", "0"));
            //ddlType.Items.Insert(0, new ListItem("All", "0"));

            //DdlGroup.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS002_GroupCreationLoad(0)");
            //DdlGroup.DataValueField = "GroupId";
            //DdlGroup.DataTextField = "GroupName";
            //DdlGroup.DataBind();
            //DdlGroup.Items.Insert(0, new ListItem("All", "0"));
        }
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd = new DataSet();
        if (RadioButtonList1.SelectedValue == "1")
        {
            dd = obCommonFuction.FillDatasetByProc(@"select distinct Printer_RedID_I Printer_regid_i,TRIM( REPLACE( REPLACE(REPLACE( NameofPressHindi_V ,'Ms ',''),'M./s',''),'M/s','')) NameofPress_V from dis_vitrannirdesh
inner join pri_printerregistration_t on pri_printerregistration_t.Printer_RedID_I=PrinterID
where AcYear='" + DdlACYear.SelectedValue + "' order by TRIM( REPLACE( REPLACE(REPLACE( NameofPressHindi_V ,'Ms ',''),'M./s',''),'M/s',''))");
        }
        else
        {
            dd = obCommonFuction.FillDatasetByProc(@"select distinct Printer_RedID_I Printer_regid_i,TRIM( REPLACE( REPLACE(REPLACE( NameofPressHindi_V ,'Ms ',''),'M./s',''),'M/s','')) NameofPress_V from dis_vitrannirdeshwithdrawal
inner join pri_printerregistration_t on pri_printerregistration_t.Printer_RedID_I=PrinterID
where AcYear='" + DdlACYear.SelectedValue + "' order by TRIM( REPLACE( REPLACE(REPLACE( NameofPressHindi_V ,'Ms ',''),'M./s',''),'M/s',''))");
        }
      
        DDLPrinter.DataSource = dd.Tables[0];
        DDLPrinter.DataValueField = "Printer_regid_i";
        DDLPrinter.DataTextField = "NameofPress_V";
        DDLPrinter.DataBind();
        DDLPrinter.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ExportDiv.Visible = true;
        DataSet ddd = new DataSet();
        Label11.Text = "0";
        Label12.Text = "0";
        Label13.Text = "0";
        lblBundle1.Text = "0";
        lblbundle2.Text = "0";
        lblTotalB.Text = "0";
        if (RadioButtonList1.SelectedValue == "1")
        {
            ddd = obCommonFuction.FillDatasetByProc("call GetVitranNIrdesh('" + ddlOrderNo.SelectedValue + "'," + DDLPrinter.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "','4')");

        }
        else
        {
            ddd = obCommonFuction.FillDatasetByProc("call GetVitranNIrdeshWithdra('" + ddlOrderNo.SelectedValue + "'," + DDLPrinter.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "','4')");

        }
        
        GrdVitranNirdesh.DataSource = ddd.Tables[0];
        GrdVitranNirdesh.DataBind();
        GrdVitranNirdesh0.DataSource = ddd.Tables[1];
        GrdVitranNirdesh0.DataBind(); if (ddd.Tables[1].Rows.Count > 0)
        {
            a.Style.Add("display", "block");
        }
        try { 

        lblBookName.Text = ddd.Tables[2].Rows[0]["TitleHindi_V"].ToString();
        lblBookType.Text = ddd.Tables[2].Rows[0]["BookType"].ToString();
        lblPrinterName.Text = ddd.Tables[2].Rows[0]["NameofPress_V"].ToString();
        lblPaddress.Text = ddd.Tables[2].Rows[0]["FullAddress_V"].ToString(); 

        lblPerbundle.Text = ddd.Tables[2].Rows[0]["BooksPerBundle"].ToString();
        lblPerbundle0.Text = ddd.Tables[2].Rows[0]["BooksPerGaddi"].ToString();
        try { 
        lblGroup.Text = ddd.Tables[2].Rows[0]["GroupName"].ToString();
        }
        catch { }
        lblKra.Text = ddd.Tables[2].Rows[0]["VitranNo"].ToString();
        lblDate.Text = ddd.Tables[2].Rows[0]["VitranDate"].ToString();
        lblM.Text = "";
        DataSet drt = obCommonFuction.FillDatasetByProc("call GetVitranSupply('"+ddlOrderNo.SelectedItem.Text+"','"+DdlACYear.SelectedValue+"')");
        try
        {
            lblM.Text = drt.Tables[0].Rows[0]["a"].ToString();
        }
        catch { }
            
            //if (lblBookType.Text == "योजना")
        //{
        //    Label11.Text = ddd.Tables[0].Rows[0]["NoOfBooks"].ToString();


        //    lblBundle1.Text = ddd.Tables[0].Rows[0]["TotalBundels"].ToString();
        //}
        //else
        //{

        //    Label12.Text = ddd.Tables[0].Rows[0]["NoOfBooks"].ToString();


        //    lblbundle2.Text = ddd.Tables[0].Rows[0]["TotalBundels"].ToString();
        //}

        if (lblBundle1.Text == "")
        {
            lblBundle1.Text = "0";
        }
        if (lblbundle2.Text == "")
        {
            lblbundle2.Text = "0";
        }

        if (Label11.Text == "")
        {
            Label11.Text = "0";
        }
        if (Label12.Text == "")
        {
            Label12.Text = "0";
        }
        Label13.Text = Convert.ToString(Convert.ToInt32(Label11.Text)+Convert.ToInt32(Label12.Text));
        lblTotalB.Text = Convert.ToString(Convert.ToInt32(lblBundle1.Text) + Convert.ToInt32(lblbundle2.Text));
        }
        catch { }
    }
    protected void DDLPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GetVitranNIrdesh
        DataSet dd = new DataSet();
        if (RadioButtonList1.SelectedValue == "1")
        {
             dd = obCommonFuction.FillDatasetByProc("call GetVitranNIrdesh(0," + DDLPrinter.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "' ,'0')");
        }
        else
        {
            dd = obCommonFuction.FillDatasetByProc("call GetVitranNIrdeshWithdra(0," + DDLPrinter.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "' ,'0')");
        
        }
       
        ddlOrderNo.DataSource = dd.Tables[0];
        ddlOrderNo.DataValueField = "VitranNo";
        ddlOrderNo.DataTextField = "VitranNo";
        ddlOrderNo.DataBind();
        ddlOrderNo.Items.Insert(0, new ListItem("Select", "0"));
    }
    protected void GrdVitranNirdesh_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet dst = new DataSet();
       
            if (RadioButtonList1.SelectedValue == "1")
            { dst = obCommonFuction.FillDatasetByProc("call GetVitranNIrdesh('" + ddlOrderNo.SelectedItem.Text + "'," + DDLPrinter.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "','-1' )"); 
            }
            else
            {
                dst = obCommonFuction.FillDatasetByProc("call GetVitranNIrdesh('" + ddlOrderNo.SelectedItem.Text + "'," + DDLPrinter.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "','-2' )"); 
            }

            Label lbl1 = (Label)e.Row.FindControl("lbl1");
            Label lbl2 = (Label)e.Row.FindControl("lbl2");
            Label lbl3 = (Label)e.Row.FindControl("lbl3");
            try {
            //Label lblFLoojBook = (Label)e.Row.FindControl("lblFLoojBook");
            lbl1.Text = dst.Tables[0].Rows[0]["NoOfBooks"].ToString();
            lbl2.Text = dst.Tables[0].Rows[0]["TotalBundels"].ToString();
            lbl3.Text = dst.Tables[0].Rows[0]["NoOfBooks"].ToString();
            Label11.Text = dst.Tables[0].Rows[0]["NoOfBooks"].ToString();
            lblBundle1.Text = dst.Tables[0].Rows[0]["TotalBundels"].ToString();
            if (lblBundle1.Text == "")
            {
                lblBundle1.Text = "0";
            }
            }
            catch { }
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
           

    }
    protected void GrdVitranNirdesh0_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet dst = new DataSet();
        if (RadioButtonList1.SelectedValue == "1")
        {
             dst = obCommonFuction.FillDatasetByProc("call GetVitranNIrdesh('" + ddlOrderNo.SelectedItem.Text + "'," + DDLPrinter.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "','-1' )"); 

        }
        else {
            dst = obCommonFuction.FillDatasetByProc("call GetVitranNIrdesh('" + ddlOrderNo.SelectedItem.Text + "'," + DDLPrinter.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "','-2' )"); 
        
        } Label lbl1 = (Label)e.Row.FindControl("lbl4");
        Label lbl2 = (Label)e.Row.FindControl("lbl5");
        Label lbl3 = (Label)e.Row.FindControl("lbl6");
        //Label lblFLoojBook = (Label)e.Row.FindControl("lblFLoojBook");
        try { 
        lbl1.Text = dst.Tables[1].Rows[0]["NoOfBooks"].ToString();
        lbl2.Text = dst.Tables[1].Rows[0]["TotalBundels"].ToString();
        lbl3.Text = dst.Tables[1].Rows[0]["NoOfBooks"].ToString();
        Label12.Text = dst.Tables[1].Rows[0]["NoOfBooks"].ToString();
        lblbundle2.Text = dst.Tables[1].Rows[0]["TotalBundels"].ToString();
        if (lblbundle2.Text == "")
        {
            lblbundle2.Text = "0";
        }
        }
        catch { }

    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DdlACYear_SelectedIndexChanged( sender,  e);
        DDLPrinter_SelectedIndexChanged(sender, e);
    }
}