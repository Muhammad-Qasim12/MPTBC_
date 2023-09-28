using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data ;
public partial class Distribution_SchemeWiseSrNo : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_SchemeLoadClassWise(0)");
            DdlScheme.DataTextField = "SchemeName_Hindi";
            DdlScheme.DataValueField = "SchemeID";
            DdlScheme.DataBind();
            DdlScheme.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
        }

    }
    //Usp_GetSchemeSrNo
    protected void DdlScheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = obCommonFuction.FillDatasetByProc("call Usp_GetSchemeSrNo(" + DdlScheme.SelectedValue + ",'"+ddlAcYear.SelectedValue+"')");
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
      // `mptbc_development`.`USPSaveSchemData` (IDa int, TitleIDa int, SrNoa int, SchemeIDa int)

        obCommonFuction.FillDatasetByProc("call USPSaveSchemData(1,0,0,"+DdlScheme.SelectedValue+")");
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            string v = "";
            string s= ((TextBox)GridView1.Rows[i].FindControl("Textbox1")).Text;
            if(!string.IsNullOrEmpty(s)) 
            { 
            v = s;
            }
            else
            { v = "0"; }
            obCommonFuction.FillDatasetByProc("call USPSaveSchemData(0," + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value + ","+ v +"," + DdlScheme.SelectedValue + ")");
        }

        GridView1.DataSource = null;
        GridView1.DataBind();
        DdlScheme.SelectedIndex = 0;
    }
}