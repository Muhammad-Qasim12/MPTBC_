using System;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.IO;
using System.Web.UI;

public partial class Distrubution_RptDemandEstimation : System.Web.UI.Page
{
    DIS_DemandEstimation ObjDemandEstimation = new DIS_DemandEstimation();
    double DemandScheme = 0, DemandOpnMkt = 0, TotDemand = 0, YojnaStock = 0, OpenStock = 0, TotStock = 0, NetDemandScheme = 0, NetDemandOpen = 0, NetDemand = 0;

    CommonFuction objExec = new CommonFuction();
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

            DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS001_DemandTypeMasterLoad(0)");
            DDlDemandType.DataValueField = "DemandTypeId";
            DDlDemandType.DataTextField = "DemandTypeHindi";
            DDlDemandType.DataBind();
            DDlDemandType.Items.Insert(0, "--Select--");

            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, "All");

            //DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            //DdlClass.DataValueField = "ClassTrno_I";
            //DdlClass.DataTextField = "ClassDesc_V";
            //DdlClass.DataBind();
            //DdlClass.Items.Insert(0, new ListItem("-Select-", "-1"));
            //DdlClass.Items.Insert(1, new ListItem("-All-", "0"));

            DdlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)");
            DdlMedium.DataValueField = "MediumTrno_I";
            DdlMedium.DataTextField = "MediunNameHindi_V";
            DdlMedium.DataBind();
            DdlMedium.Items.Insert(0, "--Select--");

            ChkClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            ChkClass.DataValueField = "ClassTrno_I";
            ChkClass.DataTextField = "ClassDesc_V";
            ChkClass.DataBind();
        }
    }

    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet obDataset=new DataSet ();
        string strclasses = "";
        try
        {
            CommonFuction obCommonFuction = new CommonFuction();

            foreach (ListItem item in ChkClass.Items)
            {
                if (item.Selected)
                {
                    strclasses = strclasses + "," + item.Value;
                }

            }
            strclasses = strclasses.Substring(1, strclasses.Length - 1);
            string DepoVal = DdlDepot.SelectedItem.Text;
            int ddval = 0;
            if (DepoVal == "All")
            {
                ddval = 0;
                obDataset = obCommonFuction.FillDatasetByProc("Call USP_GetSummaryA('" + DdlACYear.SelectedValue.ToString() + "'," + Convert.ToInt32(DdlMedium.SelectedValue) + ",'" + strclasses + "','"+DDlDemandType.SelectedValue+"')");
            }
            else
            {
                ddval = Convert.ToInt32(DdlDepot.SelectedValue);
                obDataset = obCommonFuction.FillDatasetByProc("Call USP_DIS_DemandEstimation_BycheckBox(" + Convert.ToInt32(ddval) + "," + Convert.ToInt32(DdlMedium.SelectedValue) + ",'" + strclasses + "','" + DdlACYear.SelectedValue.ToString() + "'," + Convert.ToInt16(DDlDemandType.SelectedValue) + ",'0,1,2',100,1,1)");
            }
           
            GrdBooksMaster.DataSource = obDataset;
            if (obDataset.Tables[0].Rows.Count > 0)
            {
                lblYear.Text = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
                lblTitle.Text = "डिपो का नाम  : " + DdlDepot.SelectedItem.Text.Replace("All", "सभी") + ", " + " मांग का प्रकार :" + DDlDemandType.SelectedItem.Text.ToString() + ", माध्यम का नाम : " + DdlMedium.SelectedItem.Text.Replace("All", "सभी") + ", " + " कक्षा : " + strclasses;
                lblDate.Text = "दिनांक :" + System.DateTime.Now.ToString("dd MMM yyyy");
                tdPrintContent.Visible = true;

            }
            else
            {
                tdPrintContent.Visible = false;
            }

            GrdBooksMaster.DataBind();
            mainDiv.Style.Add("display", "None");
            lblmsg.Style.Add("display", "None");


        }
        catch (Exception ex)
        {
            mainDiv.Style.Add("display", "block");
            mainDiv.CssClass = "response-msg error ui-corner-all";
            lblmsg.Style.Add("display", "block");
            if (DDlDemandType.SelectedItem.Text.Contains("Select"))
                lblmsg.Text = "कृपया डिमांड टाइप चुने";
            //else if (DdlDepot.SelectedItem.Text.Contains("Select"))
            //    lblmsg.Text = "कृपया डिपो चुने";
            else if (DdlMedium.SelectedItem.Text.Contains("Select"))
                lblmsg.Text = "कृपया माध्यम चुने";
            //else if (DdlClass.SelectedItem.Text.Contains("Select"))
            //  lblmsg.Text = "कृपया कक्षा चुने";
            else if (strclasses == "")
                lblmsg.Text = "कृपया कक्षा चुने";
        }
    }
    protected void GrdBooksMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblDemandScheme = (Label)e.Row.FindControl("lblDemandScheme");
            Label lblDemandOpnMkt = (Label)e.Row.FindControl("lblDemandOpnMkt");
            Label lblTotDemand = (Label)e.Row.FindControl("lblTotDemand");
            Label lblYojnaStock = (Label)e.Row.FindControl("lblYojnaStock");
            Label lblOpenStock = (Label)e.Row.FindControl("lblOpenStock");
            Label lblTotStock = (Label)e.Row.FindControl("lblTotStock");
            Label lblNetDemandScheme = (Label)e.Row.FindControl("lblNetDemandScheme");
            Label lblNetDemandOpen = (Label)e.Row.FindControl("lblNetDemandOpen");
            Label lblNetDemand = (Label)e.Row.FindControl("lblNetDemand");
            try
            {
                DemandScheme += double.Parse(lblDemandScheme.Text) < 0 ? 0 : double.Parse(lblDemandScheme.Text);
            }
            catch { DemandScheme = 0; }
            try
            {
                DemandOpnMkt += double.Parse(lblDemandOpnMkt.Text) < 0 ? 0 : double.Parse(lblDemandOpnMkt.Text);
            }
            catch { DemandOpnMkt = 0; }
            try
            {
                TotDemand += double.Parse(lblTotDemand.Text) < 0 ? 0 : double.Parse(lblTotDemand.Text);
            }
            catch { TotDemand = 0; }
            try
            {
                YojnaStock += double.Parse(lblYojnaStock.Text) < 0 ? 0 : double.Parse(lblYojnaStock.Text);
            }
            catch { YojnaStock = 0; }
            try
            {
                OpenStock += double.Parse(lblOpenStock.Text) < 0 ? 0 : double.Parse(lblOpenStock.Text);
            }
            catch { OpenStock = 0; }
            try
            {
                TotStock += double.Parse(lblTotStock.Text) < 0 ? 0 : double.Parse(lblTotStock.Text);
            }
            catch { TotStock = 0; }
            try
            {
                NetDemandScheme += double.Parse(lblNetDemandScheme.Text) < 0 ? 0 : double.Parse(lblNetDemandScheme.Text);
            }
            catch { DemandScheme = 0; }
            try
            {
                NetDemandOpen += double.Parse(lblNetDemandOpen.Text) < 0 ? 0 : double.Parse(lblNetDemandOpen.Text);
            }
            catch { NetDemandOpen = 0; }
            try
            {
                NetDemand +=  double.Parse(lblNetDemand.Text)<0?0:double.Parse(lblNetDemand.Text);
            }
            catch { NetDemand = 0; }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblFDemandScheme = (Label)e.Row.FindControl("lblFDemandScheme");
            Label lblFDemandOpnMkt = (Label)e.Row.FindControl("lblFDemandOpnMkt");
            Label lblFTotDemand = (Label)e.Row.FindControl("lblFTotDemand");
            Label lblFYojnaStock = (Label)e.Row.FindControl("lblFYojnaStock");
            Label lblFOpenStock = (Label)e.Row.FindControl("lblFOpenStock");
            Label lblFTotStock = (Label)e.Row.FindControl("lblFTotStock");
            Label lblFNetDemandScheme = (Label)e.Row.FindControl("lblFNetDemandScheme");
            Label lblFNetDemandOpen = (Label)e.Row.FindControl("lblFNetDemandOpen");
            Label lblFNetDemand = (Label)e.Row.FindControl("lblFNetDemand");

            lblFDemandScheme.Text = DemandScheme.ToString();
            lblFDemandOpnMkt.Text = DemandOpnMkt.ToString();
            lblFTotDemand.Text = TotDemand.ToString();
            lblFYojnaStock.Text = YojnaStock.ToString();
            lblFOpenStock.Text = OpenStock.ToString();
            lblFTotStock.Text = TotStock.ToString();
            lblFNetDemandScheme.Text = NetDemandScheme.ToString();
            lblFNetDemandOpen.Text = NetDemandOpen.ToString();
           // lblFNetDemand.Text = (Convert.ToInt32(DemandScheme.ToString()) + Convert.ToInt32(YojnaStock.ToString())).ToString();
            lblFNetDemand.Text = NetDemand.ToString();
        }
    }
    ////////  EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Reports.xls"));
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
}
