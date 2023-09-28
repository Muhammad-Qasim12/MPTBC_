using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_TranportExpDetails : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("call USP_DD_SelectDistrict(" + Session["USERID"] + " ,0,0 )");
            DdlDistrict.DataValueField = "DistrictTrno_I";
            DdlDistrict.DataTextField = "District_Name_Hindi_V";
            DdlDistrict.DataBind();
            DdlDistrict.Items.Insert(0, "--Select--");
            RadioButtonList1_SelectedIndexChanged1( sender,  e);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        { 
        string DistID="0", BlockID="0";
        if (DdlDistrict.SelectedIndex == 0)
        {
            DistID = "0";
        }
        else
        {
            DistID = DdlDistrict.SelectedValue;
        }
        if (ddlBlock.SelectedIndex == 0)
        {
            BlockID = "0";
        }
        else
        {
            BlockID = ddlBlock.SelectedValue;
        }
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_GetDepoTranpotExp('" + DdlACYear.SelectedValue + "'," + Session["UserID"].ToString() + ","+DistID.ToString ()+","+BlockID.ToString ()+")");
        GridView1.DataBind();
        }
        else if (RadioButtonList1.SelectedValue == "2")
        {
            GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_InterDepoBill('" + DdlACYear.SelectedValue + "'," + Session["UserID"].ToString() + ")");
            GridView1.DataBind();
        
        }
    }
  
    public double TotalTan, ToalAmount;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
            TotalTan +=Convert.ToDouble (e.Row.Cells[8].Text);
            ToalAmount += Convert.ToDouble(e.Row.Cells[9].Text);
                //try
                ////{
                ////    Label lblToNo_I = (Label)e.Row.Cells[10].FindControl("lblToNo_I");
                ////    total_ToNo_I += lblToNo_I.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(lblToNo_I.Text);
                ////}
                ////catch { }
                ////Label lblLoojBook = (Label)e.Row.FindControl("lblLoojBook");
                ////try
                ////{
                ////    total_LoojBook = total_LoojBook + Convert.ToDecimal(lblLoojBook.Text);
                ////}
                ////catch { }


              
            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[8].Text = TotalTan.ToString();
            e.Row.Cells[9].Text = ToalAmount.ToString();
          
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void RadioButtonList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        GridView1.DataSource = null;
        GridView1.DataBind();
        if (RadioButtonList1.SelectedValue == "1")
        {
            Ar.Visible = true;
        }
        else
        {
            Ar.Visible = false;
        }
    }
    protected void DdlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlBlock.DataSource = obCommonFuction.FillDatasetByProc("call USP_BlockDistrictWise(" + DdlDistrict.SelectedValue + "  )");
            ddlBlock.DataValueField = "BlockTrno_I";
            ddlBlock.DataTextField = "BlockName_V";
            ddlBlock.DataBind();
            ddlBlock.Items.Insert(0, "--Select--");
        }
        catch { }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
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