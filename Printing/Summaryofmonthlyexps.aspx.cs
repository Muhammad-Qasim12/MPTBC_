using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Paper_PaperReport_PaperCalu : System.Web.UI.Page
{
    double Pbooks=0, Abooks=0, Tbooks,Ppaper,Apper,TPaper;
    double Noofbooks1,Noofbooks2, printingPaper = 0, CoverPaper = 0, printingPaper1 = 0, CoverPaper1 = 0;
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
                     

            
                //
                for (int i = 2015; i <= System.DateTime.Now.Year + 1; i++)
                {
                    ddlYear.Items.Add(i.ToString());
                }
                ddlMonth.DataTextField = "MonthFullName";
                ddlMonth.DataValueField = "MonthId";
                ddlMonth.DataSource = obCommonFuction.FillDatasetByProc("call hr_get_months()");
                ddlMonth.DataBind();
                ddlMonth.Items.Insert(0, "सलेक्ट करे ..");

                DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
                DdlDepot.DataValueField = "DepoTrno_I";
                DdlDepot.DataTextField = "DepoName_V";
                DdlDepot.DataBind();
                DdlDepot.Items.Insert(0, "--Select--");
                if (Session["RoleId"].ToString() == "3")
                {
                    DdlDepot.SelectedValue = Session["UserID"].ToString();
                    DdlDepot.Enabled = false;
                }
            }
        }

   
    

    
    
    
 
     
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ExportDiv.Visible = true;
        btnExport.Visible = true;
         
            try
            {
                DataSet dd = obCommonFuction.FillDatasetByProc("CALL `Usp_monthly_Exp` (" + ddlYear.SelectedValue + ",'" + ddlMonth.SelectedIndex  + "',7)");
                
                gvPapCalculation.DataSource = dd.Tables[0];
                gvPapCalculation.DataBind();
                 
                a1.Style.Add("display", "block");
                a.Style.Add("display", "block");
            }
            catch { }
        
    }

    protected void gvPapCalculation_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}