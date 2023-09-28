using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using MPTBCBussinessLayer;
public partial class Printing_AddPrinterPenalty : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);

    PRI_PrinterRegistration obPRI_PrinterRegistration = new PRI_PrinterRegistration();
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new System.Data.DataSet();
            ds = obPRI_PrinterRegistration.PrinterRegistrationLoad();
            ddlprinterName.DataSource = ds.Tables[0];
            ddlprinterName.DataValueField = "Printer_RedID_I";
            ddlprinterName.DataTextField = "NameofPress_V";
            ddlprinterName.DataBind();
            ddlprinterName.Items.Insert(0, new ListItem("Select..", "0"));

            DataSet asdf = comm.FillDatasetByProc("call USP_DPTOPeningStock(0,1,0,0,0,0)");
            ddlTital.DataSource = asdf.Tables[0];
            ddlTital.DataTextField = "TitleHindi_V";
            ddlTital.DataValueField = "TitleID_I";
            ddlTital.DataBind();
            ddlTital.Items.Insert(0, new ListItem("Select..", "0"));
            fillgrd();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       // CommonFuction comm = new CommonFuction();
        if (HiddenField1.Value == "")
        {
            comm.FillDatasetByProc("call GetPrinterPanalty(0,"+ddlprinterName.SelectedValue+","+ddlTital.SelectedValue+","+TextBox2.Text+",'"+TextBox1.Text+"')");
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
        }
        else
        {
            comm.FillDatasetByProc("call GetPrinterPanalty("+HiddenField1.Value+"," + ddlprinterName.SelectedValue + "," + ddlTital.SelectedValue + "," + TextBox2.Text + ",'" + TextBox1.Text + "')");
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record Updated successfully.');</script>");
        }
        fillgrd();
        comm.EmptyTextBoxes(this);
    }
    public void fillgrd()
    {
        DataSet dd = comm.FillDatasetByProc("call GetPrinterPanalty(-1,0,0,0,0)");
        GridView1.DataSource = dd.Tables[0];
        GridView1.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrd();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dda = comm.FillDatasetByProc("call GetPrinterPanalty(-2,"+GridView1.SelectedDataKey.Value.ToString ()+",0,0,0)");
        ddlTital.SelectedValue = dda.Tables[0].Rows[0]["TitileID"].ToString();
        ddlprinterName.SelectedValue = dda.Tables[0].Rows[0]["PrinterID"].ToString();
        TextBox1.Text = dda.Tables[0].Rows[0]["Remark"].ToString();
        TextBox2.Text = dda.Tables[0].Rows[0]["Percetage"].ToString();
        HiddenField1.Value = dda.Tables[0].Rows[0]["ID"].ToString();
    }
}