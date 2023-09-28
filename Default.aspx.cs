using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using MPTBCBussinessLayer.DistributionB;
using System.IO;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    PRI003_RPTGroupAllotment obGroupAllotment = new PRI003_RPTGroupAllotment() ;
    PRI_PrinterRegistration obPriReg = new PRI_PrinterRegistration ();
    DemandfromOthers obDemandfromOthers = new DemandfromOthers();
    CommonFuction obCommon = new CommonFuction ();
    //MPTBCBussinessLayer.Admin.Login obLogin = new MPTBCBussinessLayer.Admin.Login();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null || Session["UserName"] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        if (!IsPostBack)
        {
            if (Session["UserName"].ToString() == "printing")
            {
                aa.Visible = true;
                LoadAcYear(); FillData();
            }
            else {
                aa.Visible = false ;
            }
           
        }
        //if (!IsPostBack)
        //{
        //     obLogin.UserName = string.Empty;
        //    obLogin.UserType = string.Empty;
        //    obLogin.Password = string.Empty;
        //    obLogin.QueryType = 0;
        //    obLogin.UserID = 0;
        //    obLogin.QueryType = 1;
        //    obLogin.UserID = int.Parse(Session["UserID"].ToString());
        //    DataSet dsSubModule = obLogin.Select();
        //    Menu mnuLinks = (Menu)Master.FindControl("mnuLinks");
        //    for (int i = 0; i < dsSubModule.Tables[0].Rows.Count; i++)
        //    {
        //        obLogin.QueryType = 2;
        //        obLogin.SubModuleTrno = int.Parse(dsSubModule.Tables[0].Rows[i]["SubModuleTrno_I"].ToString());
        //        MenuItem mnuSubModule = new MenuItem();
        //        mnuSubModule.Text = dsSubModule.Tables[0].Rows[i]["SubModuleName_V"].ToString();
        //        DataSet dsForms = obLogin.Select();
        //        for (int j = 0; j < dsForms.Tables[0].Rows.Count; j++)
        //        {
        //            MenuItem mnuForms = new MenuItem();
        //            mnuForms.NavigateUrl = dsForms.Tables[0].Rows[j]["FormPath_V"].ToString();
        //            mnuForms.Text = dsForms.Tables[0].Rows[j]["FormDesc_V"].ToString();
        //            mnuSubModule.ChildItems.Add(mnuForms);
        //        }

        //        mnuLinks.Items.Add(mnuSubModule);
        //    }
        //}
    }
    public void LoadAcYear()
    {
        obDemandfromOthers.QueryType = -1;
        ddlAcYearId.DataSource = obDemandfromOthers.Select();
        ddlAcYearId.DataTextField = "AcYear";
        ddlAcYearId.DataValueField = "AcYear";
        ddlAcYearId.DataBind();
       
        // BindTenderNo();

    }


    public void FillData()
    {
        try
        {
            obPriReg = new PRI_PrinterRegistration();

            ddlPrinter.DataTextField = "NameofPress_V";
            ddlPrinter.DataValueField = "Printer_RedID_I";

            obPriReg.Printer_RedID_I = 0;
            ddlPrinter.DataSource = obPriReg.PrinterRegistrationLoad();
            ddlPrinter.DataBind();


            ddlPrinter.Items.Insert(0, new ListItem("Select..", "0"));

        }
        catch (Exception ex)
        {
        }
        finally
        {
            obPriReg = null;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        obGroupAllotment.Printer_RedID_I = Convert.ToInt32(ddlPrinter.SelectedValue);
        obGroupAllotment.AcYearId = Convert.ToString(ddlAcYearId.SelectedValue);
        //GrdGroupDetails.DataSource = obGroupAllotment.LoadGroupAllotment();
        GrdGroupDetails.DataSource = GetLoadGroup(obGroupAllotment);
        GrdGroupDetails.DataBind();
        GrdGroupDetails0.DataSource = obCommon.FillDatasetByProc("call USP_PrintingPaperAllotment(" + ddlPrinter.SelectedValue + ",'" + ddlAcYearId.SelectedItem.Text + "')");
        GrdGroupDetails0.DataBind();
    }
    public DataSet GetLoadGroup(PRI003_RPTGroupAllotment ob)
    {
        int tenID = 0;
       
        DataSet ds1 = new DataSet();
        CommonFuction obCommonFuction = new CommonFuction();
        ds1 = obCommonFuction.FillDatasetByProc("call USP_PRI003_RPTGroupAllotmentNew(" + ob.Printer_RedID_I + ",'" + ob.AcYearId + "'," + tenID + ")"); ;
        return ds1;
    }
    double a1, a2, a3;
    double a11, a12, a13,a4,a5;
    protected void GrdGroupDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                try
                {
                    Label lblPerBundle = (Label)e.Row.FindControl("lblTotNoOfBooks");
                    a1 += lblPerBundle.Text.Trim().Length == 0 ? 0 : Convert.ToDouble(lblPerBundle.Text);
                  //  a1 += Convert.ToDouble(e.Row.Cells[5].Text);
                }
                catch { }
                try
                {
                    Label lblPerBundle1 = (Label)e.Row.FindControl("lbl1");
                    a2 += lblPerBundle1.Text.Trim().Length == 0 ? 0 : Convert.ToDouble(lblPerBundle1.Text);
                    //  a1 += Convert.ToDouble(e.Row.Cells[5].Text);
                }
                catch { }
                try
                {
                    Label lblPerBundle2 = (Label)e.Row.FindControl("lbl2");
                    a3 += lblPerBundle2.Text.Trim().Length == 0 ? 0 : Convert.ToDouble(lblPerBundle2.Text);
                    //  a1 += Convert.ToDouble(e.Row.Cells[5].Text);
                }
                catch { }
               
                

            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[5].Text = a1.ToString();
            e.Row.Cells[7].Text = a2.ToString();
            e.Row.Cells[8].Text = a3.ToString();
          
        }
    }
    protected void GrdGroupDetails_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                try
                {
                    Label lblPerBundle = (Label)e.Row.FindControl("lblTotNoOfBooks0");
                    a11 += lblPerBundle.Text.Trim().Length == 0 ? 0 : Convert.ToDouble(lblPerBundle.Text);
                    //  a1 += Convert.ToDouble(e.Row.Cells[5].Text);
                }
                catch { }
                try
                {
                    Label lblPerBundle1 = (Label)e.Row.FindControl("lbl3");
                    a12 += lblPerBundle1.Text.Trim().Length == 0 ? 0 : Convert.ToDouble(lblPerBundle1.Text);
                    //  a1 += Convert.ToDouble(e.Row.Cells[5].Text);
                }
                catch { }
                try
                {
                    Label lblPerBundle2 = (Label)e.Row.FindControl("lbl4");
                    a13 += lblPerBundle2.Text.Trim().Length == 0 ? 0 : Convert.ToDouble(lblPerBundle2.Text);
                    //  a1 += Convert.ToDouble(e.Row.Cells[5].Text);
                }
                catch { }
                try
                {

                    a4 += Convert.ToDouble(e.Row.Cells[9].Text);
                }
                catch { }
                try
                {

                    a5 += Convert.ToDouble(e.Row.Cells[10].Text);
                }
                catch { }

            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[5].Text = a11.ToString();
            e.Row.Cells[7].Text = a12.ToString();
            e.Row.Cells[8].Text = a13.ToString();
            e.Row.Cells[9].Text = a4.ToString();
             e.Row.Cells[10].Text = a5.ToString();
          
        }
    }
}