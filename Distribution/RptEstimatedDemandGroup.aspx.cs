using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distrubution_RptEstimatedDemandGroup : System.Web.UI.Page
{
    decimal SchemeDemand = 0, OpnMktDemand = 0, TotalDemand = 0, StockYojna = 0, StockOpenMkt = 0, TotalStock = 0, NetSchemeDemand = 0, NetOpenMkt = 0, NetDemand = 0;
    CommonFuction obCommonFuction = new CommonFuction();
    DIS_DemandEstimation ObjDemandEstimation = new DIS_DemandEstimation();
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();
        if (!IsPostBack)
        {

            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            DdlACYear_SelectedIndexChanged( sender,  e);

            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookGroupName()");
            DdlDepot.DataValueField = "GroupId";
            DdlDepot.DataTextField = "GroupName";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, "Select");

            DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            DdlClass.DataValueField = "ClassTrno_I";
            DdlClass.DataTextField = "Classdet_V";
            DdlClass.DataBind();
            //DdlClass.Items.Insert(0, new ListItem("-Select-", "-1"));
            //DdlClass.Items.Insert(1, new ListItem("-All-", "0"));

            DdlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)");
            DdlMedium.DataValueField = "MediumTrno_I";
            DdlMedium.DataTextField = "MediunNameHindi_V";
            DdlMedium.DataBind();
            DdlMedium.Items.Insert(0, "Select");


        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string strclasses = "";

          
            foreach (ListItem item in DdlClass.Items)
            {
                if (item.Selected)
                {
                    strclasses = strclasses + "," + item.Value;
                }

            }
            DataSet obDataset = obCommonFuction.FillDatasetByProc("Call USP_DIS_RptDemandEstimationGroup('" + DdlACYear.SelectedValue.ToString() + "'," + Convert.ToInt32(DdlDepot.SelectedValue) + "," + Convert.ToInt32(DdlMedium.SelectedValue) + ",'" + strclasses + "','"+DropDownList2.SelectedValue+"')");
            if (obDataset.Tables[0].Rows.Count > 0)
            {
                lblAcYearRpt.Text = DdlACYear.SelectedItem.Text;
                lblDate.Text = System.DateTime.Now.ToString("d MMM yyyy");
                GrdBooksMaster.DataSource = obDataset;
                GrdBooksMaster.DataBind();
                if (obDataset.Tables[1].Rows.Count > 0)
                {
                    lblDepoName.Text = " ग्रुप का नाम : " + DdlDepot.SelectedItem.Text + ", " + "माध्यम : " + DdlMedium.SelectedItem.Text + " ," + " कक्षा : " + strclasses + ", डिपो : " + obDataset.Tables[1].Rows[0][0].ToString();
                }
                else
                {
                    lblDepoName.Text = "";
                }
                tdPrintContent.Visible = true;
            }
            else
            {
                GrdBooksMaster.DataSource = string.Empty;
                GrdBooksMaster.DataBind();
                lblDepoName.Text = "";
                tdPrintContent.Visible = false;
            }

        }
        catch { }
    }
    protected void GrdBooksMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSchemeDemand = (Label)e.Row.FindControl("lblSchemeDemand");
            Label lblOpnMktDemand = (Label)e.Row.FindControl("lblOpnMktDemand");
            Label lblTotalDemand = (Label)e.Row.FindControl("lblTotalDemand");
            Label lblStockYojna = (Label)e.Row.FindControl("lblStockYojna");
            Label lblStockOpenMkt = (Label)e.Row.FindControl("lblStockOpenMkt");
            Label lblTotalStock = (Label)e.Row.FindControl("lblTotalStock");
            Label lblNetSchemeDemand = (Label)e.Row.FindControl("lblNetSchemeDemand");
            Label lblNetOpenMkt = (Label)e.Row.FindControl("lblNetOpenMkt");
            Label lblNetDemand = (Label)e.Row.FindControl("lblNetDemand");
            try
            {
                SchemeDemand = SchemeDemand + decimal.Parse(lblSchemeDemand.Text);
            }
            catch { }
            try
            {
                OpnMktDemand = OpnMktDemand + decimal.Parse(lblOpnMktDemand.Text);
            }
            catch { }
            try
            {
                TotalDemand = TotalDemand + decimal.Parse(lblTotalDemand.Text);
            }
            catch { }
            try
            {
                StockYojna = StockYojna + decimal.Parse(lblStockYojna.Text);
            }
            catch { }
            try
            {
                StockOpenMkt = StockOpenMkt + decimal.Parse(lblStockOpenMkt.Text);
            }
            catch { }
            try
            {
                TotalStock = TotalStock + decimal.Parse(lblTotalStock.Text);
            }
            catch { }
            try
            {
                NetSchemeDemand = NetSchemeDemand + decimal.Parse(lblNetSchemeDemand.Text);
            }
            catch { }
            try
            {
                NetOpenMkt = NetOpenMkt + decimal.Parse(lblNetOpenMkt.Text);
            }
            catch { }
            try
            {
                NetDemand = NetDemand + decimal.Parse(lblNetDemand.Text);
            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblfSchemeDemand = (Label)e.Row.FindControl("lblfSchemeDemand");
            Label lblfOpnMktDemand = (Label)e.Row.FindControl("lblfOpnMktDemand");
            Label lblfTotalDemand = (Label)e.Row.FindControl("lblfTotalDemand");
            Label lblfStockYojna = (Label)e.Row.FindControl("lblfStockYojna");
            Label lblfStockOpenMkt = (Label)e.Row.FindControl("lblfStockOpenMkt");
            Label lblfTotalStock = (Label)e.Row.FindControl("lblfTotalStock");
            Label lblfNetSchemeDemand = (Label)e.Row.FindControl("lblfNetSchemeDemand");
            Label lblfNetOpenMkt = (Label)e.Row.FindControl("lblfNetOpenMkt");
            Label lblfNetDemand = (Label)e.Row.FindControl("lblfNetDemand");

            try
            {
                lblfSchemeDemand.Text = SchemeDemand.ToString();
            }
            catch { }
            try
            {
                lblfOpnMktDemand.Text = OpnMktDemand.ToString();
            }
            catch { }
            try
            {
                lblfTotalDemand.Text = TotalDemand.ToString();
            }
            catch { }
            try
            {
                lblfStockYojna.Text = StockYojna.ToString();
            }
            catch { }
            try
            {
                lblfStockOpenMkt.Text = StockOpenMkt.ToString();
            }
            catch { }
            try
            {
                lblfTotalStock.Text = TotalStock.ToString();
            }
            catch { }
            try
            {
                lblfNetSchemeDemand.Text = NetSchemeDemand.ToString();
            }
            catch { }
            try
            {
                lblfNetOpenMkt.Text = NetOpenMkt.ToString();
            }
            catch { }
            try
            {
                lblfNetDemand.Text = NetDemand.ToString();
            }
            catch { }

        }
    }
    protected void DdlClasses_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    ////////  EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "DemandReport.xls"));
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
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.DataSource = obCommonFuction.FillDatasetByProc("select distinct OrderNo from dis_demandtoprintingnew where AcYear='" + DdlACYear.SelectedItem.Text + "'");
        DropDownList2.DataValueField = "OrderNo";
        DropDownList2.DataTextField = "OrderNo";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("-Select-", "0"));
    }
}