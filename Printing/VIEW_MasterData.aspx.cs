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
public partial class PRI_VIEW_PRI002 : System.Web.UI.Page
{
    PRI002 obj = null ;
    CommonFuction obCommonFuction = null;
    int rowSNO;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }

    }

    private void loadPoject(int intApprovalStatus)
    {
        
        PRI002 obj = new PRI002();
        //try
        //{

        if (rdNew.Checked == true)
        {

            obj.strQry = txtSearch.Text;

            obj.InsertSql();
           
        }
        else
        {
            obj.strQry = txtSearch.Text;

            gvProjectMaster.DataSource = obj.SelectSql();
            gvProjectMaster.DataBind();
        }
        //}
        //catch { }
        //finally { }
    }
   
    protected void gvProjectMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
        
       
     

    }
   
    
    protected void rdApproved_CheckedChanged(object sender, EventArgs e)
    {
      //  loadPoject(1);
    }
    protected void rdNew_CheckedChanged(object sender, EventArgs e)
    {
      // loadPoject(0);

    }



   
   
    protected void gvProjectMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            rowSNO++;
            int pagedRowNum = gvProjectMaster.PageIndex * gvProjectMaster.PageSize + rowSNO;
            e.Row.Cells[0].Text = pagedRowNum.ToString();

        }
    }
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        loadPoject(0);
    }
    protected void gvProjectMaster_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        gvProjectMaster.PageIndex = e.NewPageIndex;
        loadPoject(0);
    }
}
