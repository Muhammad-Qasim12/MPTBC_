using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class Paper_PaperReport_PaperCalu : System.Web.UI.Page
{
    double Pbooks=0, Abooks=0, Tbooks,Ppaper,Apper,TPaper;
    double Noofbooks1,Noofbooks2, printingPaper = 0, CoverPaper = 0, printingPaper1 = 0, CoverPaper1 = 0;
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
            DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            DdlClass.DataValueField = "ClassTrno_I";
            DdlClass.DataTextField = "Classdet_V";
            DdlClass.DataBind();
            DdlClass.Items.Insert(0, "--Select--");
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ExportDiv.Visible = true;
        btnExport.Visible = true;
        if (RadioButtonList1.SelectedValue == "1")
        {
            try { 
            DataSet dd1 = obCommonFuction.FillDatasetByProc("call USP_GetClassWisePaperCalc (0,'" + DdlACYear.SelectedItem.Text + "'," + RadioButtonList2.SelectedValue + ")");
            gvPapCalculation0.DataSource = dd1.Tables[0];
            gvPapCalculation0.DataBind();
            }
            catch { }
            a1.Style.Add("display", "none");
            a.Style.Add("display", "none");
        }
        else
        {
            try { 
        DataSet dd = obCommonFuction.FillDatasetByProc("call USP_GetClassWisePaperCalc ("+DdlClass.SelectedValue+",'"+DdlACYear.SelectedItem.Text+"',0)");
        try { 
HiddenField1.Value = dd.Tables[0].Rows[0]["PrintingPaperDetails"].ToString();
        HiddenField2.Value = dd.Tables[0].Rows[0]["CoverpaperDetails"].ToString();
        }
        catch { }
                gvPapCalculation.DataSource = dd.Tables[0];
        gvPapCalculation.DataBind();
        GridView1.DataSource = dd.Tables[1];
        GridView1.DataBind();
        a1.Style.Add("display", "block");
        a.Style.Add("display", "block");
            }
            catch { }
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((Label)e.Row.FindControl("Label1") as Label).Text = HiddenField1.Value;
            ((Label)e.Row.FindControl("lbl1") as Label).Text = HiddenField2.Value;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblPrintingPaper = (Label)e.Row.FindControl("lblPriPaper");
                try
                {
                    printingPaper1 = printingPaper1 + Convert.ToDouble(lblPrintingPaper.Text);
                }
                catch { }
                Label lblcoverPaper = (Label)e.Row.FindControl("lblCovpaper");
                try
                {
                    CoverPaper1 = CoverPaper1 + Convert.ToDouble(lblcoverPaper.Text);
                }
                catch { }
                Label lblNoofpages = (Label)e.Row.FindControl("lblNoofpages");
                try
                {
                    Noofbooks2 = Noofbooks2 + Convert.ToDouble(lblNoofpages.Text);
                }
                catch { }
            
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[5].Text = printingPaper1.ToString();
            e.Row.Cells[6].Text = CoverPaper1.ToString();
            e.Row.Cells[2].Text = Noofbooks2.ToString();
            
        }
    }
    protected void gvPapCalculation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((Label)e.Row.FindControl("Label1") as Label).Text = HiddenField1.Value;
            ((Label)e.Row.FindControl("lbl1") as Label).Text = HiddenField2.Value;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblNoofpages = (Label)e.Row.FindControl("lblNoofpages");
                try
                {
                    Noofbooks1 = Noofbooks1 + Convert.ToDouble(lblNoofpages.Text);
                }
                catch { }
            Label lblPrintingPaper = (Label)e.Row.FindControl("lblPriPaper");
                try
                {
                    printingPaper = printingPaper + Convert.ToDouble(lblPrintingPaper.Text);
                }
                catch { }
                Label lblcoverPaper = (Label)e.Row.FindControl("lblCovpaper");
                try
                {
                    CoverPaper = CoverPaper + Convert.ToDouble(lblcoverPaper.Text);
                }
                catch { }
            
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[5].Text = printingPaper.ToString();
            e.Row.Cells[6].Text = CoverPaper .ToString();
            e.Row.Cells[2].Text = Noofbooks1.ToString();
            
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ExportDiv.Visible = false;
        btnExport.Visible = false;
        gvPapCalculation0.DataSource = null;
        gvPapCalculation0.DataBind();
        gvPapCalculation.DataSource = null;
        gvPapCalculation.DataBind();
        GridView1.DataSource = null;
        GridView1.DataBind();
        if (RadioButtonList1.SelectedValue == "1")
        {
            RadioButtonList2.Visible = true;
            DdlClass.Visible = false;
            LblClass.Visible = false;
        }
        else
        {
            RadioButtonList2.Visible = false;
            DdlClass.Visible = true;
            LblClass.Visible = true;
        }
    }

    protected void gvPapCalculation0_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblPBooks = (Label)e.Row.FindControl("lblPBooks");
            try
            {
                Pbooks = Pbooks + Convert.ToDouble(lblPBooks.Text);
            }
            catch { }
            Label lblABooks = (Label)e.Row.FindControl("lblABooks");
            try
            {
                Abooks = Abooks + Convert.ToDouble(lblABooks.Text);
            }
            catch { }

            Label lblTBooks = (Label)e.Row.FindControl("lblTBooks");
            try
            {
                Tbooks = Tbooks + Convert.ToDouble(lblTBooks.Text);
            }
            catch { }

            Label lblPaperP = (Label)e.Row.FindControl("lblPaperP");
            try
            {
                Ppaper = Ppaper + Convert.ToDouble(lblPaperP.Text);
            }
            catch { }
            Label lblPaperA = (Label)e.Row.FindControl("lblPaperA");
            try
            {
                Apper = Apper + Convert.ToDouble(lblPaperA.Text);
            }
            catch { }

            Label lblPaperT = (Label)e.Row.FindControl("lblPaperT");
            try
            {
                TPaper = TPaper + Convert.ToDouble(lblPaperT.Text);
            }
            catch { }

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[2].Text = Pbooks.ToString();
            e.Row.Cells[3].Text = Abooks.ToString();
            e.Row.Cells[4].Text = Tbooks.ToString();
            e.Row.Cells[5].Text = Ppaper.ToString();
            e.Row.Cells[6].Text = Apper.ToString();
            e.Row.Cells[7].Text = TPaper.ToString();
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
        try
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
        catch { }
    }

    protected void btnExport_Click1(object sender, EventArgs e)
    {
        ExportToExcell();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}