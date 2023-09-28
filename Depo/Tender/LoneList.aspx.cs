using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_Tender_LoneList : System.Web.UI.Page
{
    CommonFuction obCommonFuction = null;
    string blockName;
    CultureInfo cult = new CultureInfo("gu-IN", true);
  protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTender();
        }

    }
    public void LoadTender()
    {
        // obTender = new Vehicle003_Tender();
        obCommonFuction = new CommonFuction();
        DataSet ds = obCommonFuction.FillDatasetByProc("call Depo_TenderDetailsLoad(0," + Session["UserID"].ToString() + ")");
        ddlTenderID_I.DataTextField = "TenderNo_V";
        ddlTenderID_I.DataValueField = "TenderId_I";
        try
        {
            //   obTender.TenderID_I = 0;

            ddlTenderID_I.DataSource = ds.Tables[0];
            ddlTenderID_I.DataBind();
        }
        catch (Exception ex) { }
        finally { }

        ddlTenderID_I.Items.Insert(0, new ListItem("Select", "0"));
    }
    protected void ltrLeader_DataBinding(object sender, EventArgs e)
    {
        Literal lt = (Literal)sender;
        lt.Text = Eval("District_Name_Hindi_V").ToString();
        if (!string.Equals(lt.Text, blockName))
        {
            blockName = lt.Text;
        }
        else
        {
            lt.Text = string.Empty;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //GelLoneList
        obCommonFuction = new CommonFuction();
        DataSet ds1 = obCommonFuction.FillDatasetByProc("call GelLoneList(" + Session["UserID"].ToString() + ","+ddlTenderID_I.SelectedValue+")");
        grdblock.DataSource = ds1.Tables[0];
        grdblock.DataBind();
    }
}