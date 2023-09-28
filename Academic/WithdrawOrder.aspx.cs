using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Academic_WithdrawOrder : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFunction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFunction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFunction.GetFinYear();
            fillgrd();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = obCommonFunction.FillDatasetByProc("call USP_GetVithdraData('"+DdlACYear.SelectedValue+"')");
        GridView1.DataBind();
        
    }
    public void fillgrd()
    {
       DataSet dt= obCommonFunction.FillDatasetByProc("call USP_GetVithdraData('" + DdlACYear.SelectedValue + "')");
       GridView2.DataSource = dt.Tables[1];
        GridView2.DataBind();
    
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        obCommonFunction.FillDatasetByProc("call USP_AC_PrinDatewithdraOrderSave(0,0,0,'','','"+DdlACYear.SelectedValue+"')");
       

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (((TextBox)GridView1.Rows[i].FindControl("TextBox1")).Text != "")
            {
                string DateS ;

                if (((TextBox)GridView1.Rows[i].FindControl("TextBox2")).Text == "")
                {
                    DateS = "1900-01-01";
                }
                else { DateS = ((TextBox)GridView1.Rows[i].FindControl("TextBox2")).Text; }
                  

                try {
            obCommonFunction.FillDatasetByProc("call USP_AC_PrinDatewithdraOrderSave(1," + ((HiddenField)GridView1.Rows[i].FindControl("hdPrinter_RedID_I")).Value + "," + ((HiddenField)GridView1.Rows[i].FindControl("hdTitleID_I")).Value + ",'" + Convert.ToDateTime(((TextBox)GridView1.Rows[i].FindControl("TextBox1")).Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(DateS,cult).ToString("yyyy-MM-dd") + "','" + DdlACYear.SelectedValue + "')");
                }
                catch { }
            }

        }
        GridView1.DataSource = null;
        GridView1.DataBind();
        mainDiv.CssClass = "form-message success";
        mainDiv.Style.Add("display", "block");
        lblmsg.Text = "Record saved successfully";
        fillgrd();
    }
}