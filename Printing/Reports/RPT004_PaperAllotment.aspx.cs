using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.IO;
public partial class Printing_Reports_RPT004_PaperAllotment : System.Web.UI.Page
{
    public string macyr, depo, classid; decimal A1, a2, a3, a4, a5;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            CommonFuction obCommonFuction = new CommonFuction();
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
           // DdlClass.Items.Insert(0, new ListItem("--Select Academic Year--", "0"));
          DdlACYear.Items.Insert(0, "--Select Academic Year--");
             DdlACYear.SelectedValue = obCommonFuction.GetFinYear();


            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM010_DepomasterLoad(0)");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, "--All--");

            DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            DdlClass.DataValueField = "ClassTrno_I";
            DdlClass.DataTextField = "Classdet_V";
            DdlClass.DataBind();
            //DdlClass.Items.Insert(0, new ListItem("All", "0"));
           DdlClass.Items.Insert(0, "--All--");
           ddlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
           ddlMedium.DataValueField = "MediumTrno_I";
           ddlMedium.DataTextField = "MediunNameHindi_V";
           ddlMedium.DataBind();
           ddlMedium.Items.Insert(0, new ListItem("All", "0"));
        }
    }


    

    private void loadgrid()
    {
        PRI009 obj = new PRI009();
        try
        {
            if (DdlACYear.SelectedIndex > 0)
            {

                int  DepoID=0, ClassIDa=0,MediumID;
                //obj.dtype = 3;
                //obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                //if (DdlClass.SelectedIndex == 0) { obj.intClasstrno_I = 0; }
                //else { obj.intClasstrno_I = Convert.ToInt32(DdlClass.SelectedValue); }

                //obj.intdepotrno_I = DdlDepot.SelectedIndex == 0 ? 0 : Convert.ToInt32(DdlDepot.SelectedValue);
                //gvPapCalculation.DataSource = obj.Select();
                //gvPapCalculation.DataBind();

                DepoID = DdlDepot.SelectedIndex == 0 ? 0 : Convert.ToInt32(DdlDepot.SelectedValue);
                ClassIDa = DdlClass.SelectedIndex == 0 ? 0 : Convert.ToInt32(DdlClass.SelectedValue);
                MediumID = ddlMedium.SelectedIndex == 0 ? 0 : Convert.ToInt32(ddlMedium.SelectedValue);
                CommonFuction comm = new CommonFuction();
                gvPapCalculation.DataSource = comm.FillDatasetByProc("call USP_PRI009_GetDemandFormDistribution(3,'" + DdlACYear.SelectedItem.Text + "'," + DepoID + "," + ClassIDa + "," + MediumID + ")");
                gvPapCalculation.DataBind();
                macyr = DdlACYear.SelectedItem.Text;
                lblTitle.Text = "शिक्षा सत्र :" + DdlACYear.SelectedItem.Text + ", डिपो का नाम : " + DdlDepot.SelectedItem.Text.ToString().Replace("--All--", "सभी डिपो ") + ", कक्षा :" + DdlClass.SelectedItem.Text.ToString().Replace("--All--", "सभी कक्षा");
 

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Select Financial Year');</script>"); 
            }
        }
        catch { }
        finally { }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        loadgrid();
    }
 
 
 
protected void  DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
{

}
protected void DdlDepot_SelectedIndexChanged(object sender, EventArgs e)
{

}
protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
{

}
public void ExportToExcell()
{
    Response.ClearContent();
    Response.Buffer = true;
    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Allotment.xls"));
    Response.Charset = "";
    Response.ContentType = "application / vnd.ms - word";

    StringWriter sw = new StringWriter();
    HtmlTextWriter HW = new HtmlTextWriter(sw);

    ExportDiv.RenderControl(HW);
    Response.Write(sw.ToString());
    Response.End();
    Response.Clear();
}
protected void btnExport_Click(object sender, EventArgs e)
{
    ExportToExcell();
}
public override void VerifyRenderingInServerForm(Control control)
{
    //base.VerifyRenderingInServerForm(control);
}
protected void gvPapCalculation_RowDataBound(object sender, GridViewRowEventArgs e)
{
    
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
          try
            {
                Label L1 = (Label)e.Row.Cells[4].FindControl("L1");
                A1 += L1.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(L1.Text);
              //  A1 += e.Row.Cells[5].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[5].Text);
            }
            catch { }
            try
            {
                Label L2 = (Label)e.Row.Cells[4].FindControl("L2");
                a2 += L2.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(L2.Text);
            }
            catch { }
            try
            {
              //  a3 += e.Row.Cells[7].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[7].Text);
                Label L3 = (Label)e.Row.Cells[4].FindControl("L3");
                a3 += L3.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(L3.Text);
            }
            catch { }
            try
            {
                //a4 += e.Row.Cells[8].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[8].Text);
                Label L4 = (Label)e.Row.Cells[4].FindControl("L4");
                a4 += L4.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(L4.Text);
            }
            catch { }
            try
            {
               // a5 += e.Row.Cells[9].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[9].Text);
                Label L5 = (Label)e.Row.Cells[4].FindControl("L5");
                a5 += L5.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(L5.Text);
            }
            catch { }
        }
    
    if (e.Row.RowType == DataControlRowType.Footer)
    {
        
        e.Row.Style.Add("background", "#f1f1f1");
        e.Row.Cells[0].Text = "Total";
        e.Row.Cells[4].Text = A1.ToString();
        e.Row.Cells[5].Text = a2.ToString();
        e.Row.Cells[6].Text = a3.ToString();
        e.Row.Cells[7].Text = a4.ToString();
        e.Row.Cells[8].Text = a5.ToString();
    }

}
}