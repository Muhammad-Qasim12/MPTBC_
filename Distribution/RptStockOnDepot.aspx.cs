using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Distrubution_RptStockOnDepot : System.Web.UI.Page
{

    decimal yojna = 0, OpnMkt = 0, Total = 0,Totalamount;
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();
        if (!IsPostBack)
        {
            lblAcademicYear.Text = "शिक्षा सत्र : " + obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
            lblDate.Text = System.DateTime.Now.ToString("MMM dd, yyyy");
            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, new ListItem("Select", "-1"));
            DdlDepot.Items.Insert(1, new ListItem("-All-", "0"));

            DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            DdlClass.DataValueField = "ClassTrno_I";
            DdlClass.DataTextField = "Classdet_V";
            DdlClass.DataBind();
            DdlClass.Items.Insert(0, new ListItem("Select", "-1"));
            DdlClass.Items.Insert(1, new ListItem("-All-", "0"));

            DdlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)");
            DdlMedium.DataValueField = "MediumTrno_I";
            DdlMedium.DataTextField = "MediunNameHindi_V";
            DdlMedium.DataBind();
           // DdlMedium.Items.Insert(0, new ListItem("-Select-", "-1"));
            DdlMedium.Items.Insert(0, new ListItem("-All-", "0"));
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();


        }
    }

    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DdlClass.SelectedItem.Text != "Select" && DdlMedium.SelectedItem.Text != "Select")
            {

                CommonFuction obCommonFuction = new CommonFuction();

                DataSet obDataset = obCommonFuction.FillDatasetByProc("Call USP_DD_SelectTitle(0," + Convert.ToInt32(DdlMedium.SelectedValue) + "," + Convert.ToInt32(DdlClass.SelectedValue) + ")");
                DdlTitle.DataSource = obDataset;
                DdlTitle.DataValueField = "TitleID_I";
                DdlTitle.DataTextField = "TitleHindi_V";
                DdlTitle.DataBind();
                DdlTitle.Items.Insert(0, new ListItem("Select", "-1"));
                DdlTitle.Items.Insert(1, new ListItem("-All-", "0"));
            }
        }
        catch { }
    }
    protected void GrdStock_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblyojna = (Label)e.Row.FindControl("lblyojna");
            Label lblOpnMkt = (Label)e.Row.FindControl("lblOpnMkt");
            Label lblTotal = (Label)e.Row.FindControl("lblTotal");
            Label lblTotal1 = (Label)e.Row.FindControl("lblTotal2");
            try
            {
                yojna = yojna + decimal.Parse(lblyojna.Text);
            }
            catch { }
            try
            {
                OpnMkt = OpnMkt + decimal.Parse(lblOpnMkt.Text);
            }
            catch { }
            try
            {
                Total = Total + decimal.Parse(lblTotal.Text);
            }
            catch { }
              try
            {
                Totalamount = Totalamount + decimal.Parse(lblTotal1.Text);
            }
            catch { }

            
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblfyojna = (Label)e.Row.FindControl("lblfyojna");
            Label lblfOpnMkt = (Label)e.Row.FindControl("lblfOpnMkt");
            Label lblfTotal = (Label)e.Row.FindControl("lblfTotal");
            Label lblfTotal2 = (Label)e.Row.FindControl("lblfTotal2");
            
            try
            {
                lblfyojna.Text = yojna.ToString();
            }
            catch { }
            try
            {
                lblfOpnMkt.Text = OpnMkt.ToString();
            }
            catch { }
            try
            {
                lblfTotal.Text = Total.ToString();
            }
            catch { }
            try
            {
                lblfTotal2.Text = Totalamount.ToString();
            }
            catch { }
            

        }
    }

    protected void BtnShow_Click(object sender, EventArgs e)
    {
        try
        {
            string strclasses = "";

            CommonFuction obCommonFuction = new CommonFuction();
            //foreach (ListItem item in DdlClass.Items)
            //{
            //    if (item.Selected)
            //    {
            //        strclasses = strclasses + "," + item.Value;
            //    }

            //}
            lblPageTitle.Text = " डिपो का नाम : " + DdlDepot.SelectedItem.Text.Replace("0", "सभी").Replace("-All-", "सभी") + ", " + "माध्यम : " + DdlMedium.SelectedItem.Text.Replace("0", "सभी").Replace("-All-", "सभी") + " ," + " कक्षा : " + DdlClass.SelectedItem.Value.Replace("0", "सभी").Replace("-All-", "सभी") + ", शीर्षक  : " + DdlTitle.SelectedItem.Text.Replace("-All-", "सभी");
               
            lblDate.Text = System.DateTime.Now.ToString("d MMM yyyy");
            DataSet obDataset = obCommonFuction.FillDatasetByProc("Call USP_DIS_RptstockOnDepot(" + Convert.ToInt32(DdlDepot.SelectedValue) + "," + Convert.ToInt32(DdlMedium.SelectedValue) + "," + DdlClass.SelectedItem.Value + "," + Convert.ToInt32(DdlTitle.SelectedValue) + ",'"+DdlACYear.SelectedValue +"')");
            GrdStock.DataSource = obDataset;
            GrdStock.DataBind();
            tdPrintContent.Visible = true;
        }
        catch { }
    }
    ////////  EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "StockReport.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }


    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }
    protected void GrdStock_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}