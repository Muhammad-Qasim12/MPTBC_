using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MPTBCBussinessLayer;
using System.Globalization;

public partial class Printing_MachineMas : System.Web.UI.Page
{
    PRI_MachineMaster obj = null;
    MessageC m = new MessageC();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            clearform();
            LoadMachineMaster(0);
        }
    }
    public DataSet LoadMachineMaster(int Ch)
    {
        PRI_MachineMaster obj = new PRI_MachineMaster();
        DataSet ds = new DataSet();
        try
        {
            if (Ch == 0)
            {
                obj.MachineID_I = 0;
                ds = obj.Select();
                grdMachineMaster.DataSource = ds;
                grdMachineMaster.DataBind();
            }
            else
            {
                obj.MachineID_I = Convert.ToInt32(HdnMachineMasterID.Value);
                ds = obj.Select();
                grdMachineMaster.DataSource = ds;
                grdMachineMaster.DataBind();
            }
        }
        catch { }
        finally { }
        return ds;
    }

    public int SaveMachineMaster()
    {
        int i = 0;
        try
        {
            obj = new PRI_MachineMaster();
            obj.MachineID_I = Convert.ToInt32(HdnMachineMasterID.Value);
            obj.MachineType_V = Convert.ToString(ddlMachineType_V.SelectedValue);
            obj.MachineSize_V = Convert.ToString(HdnMachineSize_V.Value);
            obj.MachineCat_V = Convert.ToString(ddlMachineCat_V.SelectedValue);
            obj.MacPrintCapOneColor_V = Convert.ToString(txtMacPrintCapOneColor_V.Text);
            obj.MacPrintCapTwoColor_V = Convert.ToString(txtMacPrintCapTwoColor_V.Text);
            obj.MacPrintCapFourColor_V = Convert.ToString(txtMacPrintCapFourColor_V.Text);

            i = obj.InsertUpdate();

        }
        catch (Exception)
        {
        }
        return i;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (SaveMachineMaster() > 0)
            {
                m.ShowMessage("s");
                LoadMachineMaster(0);
            }
            else
            {
                // ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Error');</script>");
                LoadMachineMaster(0);
            }
            clearform();
        }

        catch (Exception ex)
        {
            m.ShowMessage("e");
        }
        finally { obj = null; }
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        clearform();
    }

    protected void grdMachineMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            ddlMachineType_V.SelectedValue = Convert.ToString(((Label)grdMachineMaster.Rows[e.RowIndex].FindControl("lblMachineType")).Text);
            ddlMachineCat_V.SelectedValue = Convert.ToString(((Label)grdMachineMaster.Rows[e.RowIndex].FindControl("lblMachineCat")).Text);
            txtMachineSize_V.Text = Convert.ToString(((Label)grdMachineMaster.Rows[e.RowIndex].FindControl("lblMachineSize")).Text);
            txtMacPrintCapOneColor_V.Text = Convert.ToString(((Label)grdMachineMaster.Rows[e.RowIndex].FindControl("lblMacPrintCapOne")).Text);
            txtMacPrintCapTwoColor_V.Text = Convert.ToString(((Label)grdMachineMaster.Rows[e.RowIndex].FindControl("lblMacPrintCapTwo")).Text);
            txtMacPrintCapFourColor_V.Text = Convert.ToString(((Label)grdMachineMaster.Rows[e.RowIndex].FindControl("lblMacPrintCapFour")).Text);
            HdnMachineMasterID.Value = Convert.ToString(((HiddenField)grdMachineMaster.Rows[e.RowIndex].FindControl("HdnMachineMasterGrdID")).Value);
        }
        catch (Exception)
        {
        }
    }
    protected void grdMachineMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdMachineMaster.PageIndex = e.NewPageIndex;
            LoadMachineMaster(0);
        }
        catch (Exception)
        {
        }
    }
    private void clearform()
    {
        ddlMachineType_V.SelectedValue = "0";
        ddlMachineCat_V.SelectedValue = "0";

        txtMachineSize_V.Text = "";
        txtMacPrintCapOneColor_V.Text = "";
        txtMacPrintCapTwoColor_V.Text = "";
        txtMacPrintCapFourColor_V.Text = "";
        txtVal1.Text = "";
        txtVal2.Text = "";

        HdnMachineMasterID.Value = "0";
        lblMsg.Text = "";
    }
}
