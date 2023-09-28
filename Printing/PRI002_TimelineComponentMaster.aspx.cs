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
public partial class SPY_SPY004_ComponentMaster : System.Web.UI.Page
{

    
    PRI002 obj = null;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["UserTrno"] = "1";
          //ADM_GeneralCls objuser = new ADM_GeneralCls();
          //string UR= objuser.userAuthontication(Convert.ToInt32 (Session["UserTrno"]),  "PRI002");

          //if (UR == "W")
          //{
          //    panMain.Enabled = true;  
      
          //}
          //else  
          //  {
          //      panMain.Enabled = false;
          //}



         //   loadProject();
          //  loadType();
            if (Request.QueryString["Cid"] != null)
            {
                LoadComponentMaster();
            }
            
          
        }

    }
   
    
    

    private void insertComponentMaster()
    {
        PRI002 obj = new PRI002(); 
        try
        { 
            obj.intTrno_I = 0;
            obj.intUserTrnoNo_I = 1;
          //  obj.beginTransaction();
            obj.chvComponentname_V = txtcomponentname.Text;
           obj.intOrderNo_I  = Convert.ToInt32((txtComOrder.Text));
            obj.InsertUpdate();
            

        }
        catch (Exception feException)
        {
            //obj.rollBackTransaction();
            throw new Exception(feException.Message);
        }
        finally
        {
         //     obj.commitTransaction();
         //     obj.closeConnection();
        }
    }

    private void updateComponentMaster()
    {
        PRI002 obj = new PRI002();
        try
        {
             
          //  obj.beginTransaction();
            obj.intTrno_I  = Convert.ToInt32(Request.QueryString["Cid"]);

            obj.intUserTrnoNo_I = 1;
            obj.chvComponentname_V = txtcomponentname.Text;
            obj.intOrderNo_I   = Convert.ToInt32(txtComOrder.Text   );
            
            obj.InsertUpdate();
            
        }
        catch (Exception feException)
        {
            //obj.rollBackTransaction();
            throw new Exception(feException.Message);
        }
        finally
        {
          //  obj.commitTransaction();
          //  obj.closeConnection();
        }
    }

    private void LoadComponentMaster()
    {
        PRI002 obj = new PRI002();
        try
        {
           // obj.openConnection();
            obj.intTrno_I  = Convert.ToInt32(Request.QueryString["Cid"]);

            int i = obj.ShowData(); 
            //obj.closeConnection();

            
            
            
            
            txtcomponentname.Text = obj.chvComponentname_V.ToString();
            txtComOrder.Text = obj.intOrderNo_I.ToString();   
            
            //if (obj.intisApproved == 1)
            //{
            //    chkApproval.Checked = true;
            //    panMain.Enabled = false;
            //}
            //else
            //{
            //    chkApproval.Checked = false;
            //}

        }
        catch (Exception feException)
        {
            throw new Exception(feException.Message);
        }
        finally
        {
            obj = null;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Cid"] != null)
        {
            updateComponentMaster();
            Response.Redirect("VIEW_PRI002.aspx");
        }
        else
        {
            insertComponentMaster();
            Response.Redirect("VIEW_PRI002.aspx");
        }
    }



    protected void btnClear_Click1(object sender, EventArgs e)
    {
        txtcomponentname.Text = "";
        txtComOrder.Text = "";
    }
}
