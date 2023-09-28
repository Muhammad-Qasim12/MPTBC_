using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.Academic;
using System.Data;

public partial class Academic_PrintingProofStatus : System.Web.UI.Page
{
    MessageC m = new MessageC();
    StatusMaster obStatusMaster = new StatusMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["ID"] != null)
                {
                    showdata(new APIProcedure().Decrypt(Request.QueryString["ID"]));
                }

            }
            catch { }
            finally { obStatusMaster = null; }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            obStatusMaster = new StatusMaster();
            obStatusMaster.Status_V = Convert.ToString(txtStatus.Text);
            obStatusMaster.Trans_I = 0;

            obStatusMaster.StatusMasterTrno_I = 0;
            if (hdnStatusTrno.Value != "")
            {
                obStatusMaster.Trans_I = 1;
                obStatusMaster.StatusMasterTrno_I = Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["ID"]));
            }
            obStatusMaster.InsertUpdate();

            hdnStatusTrno.Value = "";
        }
        catch
        {
            m.ShowMessage("e");
        }
        finally
        {
            obStatusMaster = null;
        }
        Response.Redirect("ViewPrintingProofStatus.aspx");
    }
    public void showdata(string ID)
    {
        try
        {
            obStatusMaster = new StatusMaster();
            obStatusMaster.StatusMasterTrno_I = Convert.ToInt32(ID); //Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["ID"]));
            DataSet obDataSet = obStatusMaster.Select();
            txtStatus.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Status_V"]);
            obStatusMaster.Trans_I = 1;
            hdnStatusTrno.Value = Request.QueryString["ID"];
        }
        catch (Exception)
        {
        }
    }
}