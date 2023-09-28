using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;

public partial class Depo_DPT005_HeadMaster : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    HeadMaster obHeadMaster = null;
  
    CommonFuction obCommonFuction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
              
                if (Request.QueryString["ID"] != null)
                {
                    showdata(Request.QueryString[ID]);
                }
              

            }
            catch { }
            finally { obCommonFuction = null; }
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        try
        {
            obHeadMaster = new HeadMaster();
            obHeadMaster.HeadName_V = Convert.ToString(txtHeadname.Text);
            obHeadMaster.transID_I = 0;
            if (HiddenField1.Value != "")
            {
                obHeadMaster.transID_I = 1;
                obHeadMaster.HeadID_I = Convert.ToInt32(HiddenField1.Value);
            }
            obHeadMaster.TransactionDate_D = Convert.ToDateTime(System.DateTime.Now, cult);
            obHeadMaster.InsertUpdate();
            obCommonFuction = new CommonFuction();
            obCommonFuction.EmptyTextBoxes(this);
        }
        catch { }
        finally
        {
            obHeadMaster = null;
        }
        Response.Redirect("VIEW_DPT005.aspx");
    }
    public void showdata(string ID)
    {
        obHeadMaster = new HeadMaster ();
        obHeadMaster.HeadID_I = Convert.ToInt32(Request.QueryString["ID"]);
        DataSet obDataSet = obHeadMaster.Select();
        txtHeadname.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["HeadName_V"]);
        HiddenField1.Value = (Request.QueryString["ID"]);
    }
}