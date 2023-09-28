using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DistributionB_GroupCreation : System.Web.UI.Page
{
    Dib015GroupCreation obGroupCreation = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            LoadChkList();
            GroupGridLoad();
        }
    }

    public void LoadChkList()
    {

        obGroupCreation = new Dib015GroupCreation();

        obGroupCreation.isSatellite_I =1;
        chkDepots.DataValueField = "DepoTrno_I";
        chkDepots.DataTextField = "DepoName_V";

        chkDepots.DataSource = obGroupCreation.GroupListLoad();
        chkDepots.DataBind();

    }

    public void GroupGridLoad() 
    {
        grdGroup.DataSource = LoadGroup(0);
        grdGroup.DataBind();
    
    }


    public DataSet LoadGroup(int ID)
    {
        DataSet ds = new DataSet();

        obGroupCreation = new Dib015GroupCreation();
        try
        {
            obGroupCreation.GroupID_I = ID;


            ds = obGroupCreation.Select();
        }

        catch (Exception ex) { }
        finally { obGroupCreation = null; }
        return ds;
    }


    public int SaveGroupMaster()
    {
        int i = 0;
        obGroupCreation = new Dib015GroupCreation();
        try
        {
            obGroupCreation.GroupID_I = Convert.ToInt32(HdnGroupId.Value);

            obGroupCreation.GroupName = Convert.ToString(txtGroupName.Text);
            i = obGroupCreation.InsertUpdate();
        }

        catch (Exception ex) { message("Group already exist..", "ERROR"); }
        finally { obGroupCreation = null; }
        return i;
    }


    public int SaveGroupDetails(int grpId)
    {
        int re = 0;
        obGroupCreation = new Dib015GroupCreation();
        try
        {
            obGroupCreation.GroupDetailsID_I = 0;
            obGroupCreation.GroupID_I = grpId;

            for (int i = 0; i < chkDepots.Items.Count; i++)
            {
                if (chkDepots.Items[i].Selected == true)
                {

                    obGroupCreation.DepoID_I = Convert.ToInt32(chkDepots.Items[i].Value);

                    re = obGroupCreation.GroupDetailsSaveUpdate();

                }

                
            }



            
        }

        catch (Exception ex) 
        {
            
        
        }

        finally { obGroupCreation = null; }
        return re;
    }

    protected void btnSaveGroup_Click(object sender, EventArgs e) 
    {
        if (SaveGroupDetails(SaveGroupMaster()) > 0) 
        {
            chkDepots.ClearSelection();

            HdnGroupId.Value = "0";
            txtGroupName.Text = "";
            

            GroupGridLoad();
        }

    }


   

    protected void grdGroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void grdGroup_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow Row = (GridViewRow)grdGroup.Rows[e.RowIndex];

        HiddenField x = Row.FindControl("HdnDepotIds") as HiddenField;

        string y = x.Value;
        string[] s = y.Split(',');
        LoadChkList();
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 0; j < chkDepots.Items.Count; j++)
            {

                if (chkDepots.Items[j].Value == s[i])
                {
                    chkDepots.Items[j].Selected = true;
                }

            }
        }

        HdnGroupId.Value = (Row.FindControl("HdnGroupId") as HiddenField).Value;
        txtGroupName.Text = (Row.FindControl("lblGroupName") as Label).Text;
        //txtDescription.Text = (Row.FindControl("lblDescription") as Label).Text;

    }




    public void message(string mess, string messType)
    {
        messDiv.Style.Add("display", "block");
        lblMess.Text = mess;

        if (messType == "ERROR")
        {

            messDiv.CssClass = "response-msg error ui-corner-all";
        }

        else if (messType == "SUCCESS")
        {
            messDiv.CssClass = "response-msg success ui-corner-all";

        }

        else if (messType == "INFO")
        {
            messDiv.CssClass = "response-msg inf ui-corner-all";

        }

    }

    public class Dib015GroupCreation
    {
        private int _GroupID_I, _GroupDetailsID_I, _isSatellite_I, _DepoID_I;
        private string _GroupName;

        public int GroupID_I { get { return _GroupID_I; } set { _GroupID_I = value; } }
        public int GroupDetailsID_I { get { return _GroupDetailsID_I; } set { _GroupDetailsID_I = value; } }
        public int isSatellite_I { get { return _isSatellite_I; } set { _isSatellite_I = value; } }
        public int DepoID_I { get { return _DepoID_I; } set { _DepoID_I = value; } }

        public string GroupName { get { return _GroupName; } set { _GroupName = value; } }
      

        public int InsertUpdate()
        {
            DBAccess obDbAccess = new DBAccess();
            int i = 0;


            obDbAccess.execute("USP_DIB015_GroupMasterSaveUpdate", DBAccess.SQLType.IS_PROC);

            obDbAccess.addParam("mGroupID_I", GroupID_I);
            obDbAccess.addParam("mGroupName", GroupName);
           

            i = Convert.ToInt32(obDbAccess.executeMyScalar());

            return i;
        }



        public int GroupDetailsSaveUpdate()
        {
            DBAccess obDbAccess = new DBAccess();
            int i = 0;


            obDbAccess.execute("USP_DIB015_GroupDetailsSaveUpdate", DBAccess.SQLType.IS_PROC);

            obDbAccess.addParam("mGroupDetailsID_I", GroupDetailsID_I);
            obDbAccess.addParam("mGroupID_I", GroupID_I);
            obDbAccess.addParam("mDepoID_I", DepoID_I);


            i = obDbAccess.executeMyQuery();

            return i;
        }


        public DataSet GroupListLoad()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();


            obDbAccess.execute("USP_ADM010_DepomasterLoad", DBAccess.SQLType.IS_PROC);
            obDbAccess.addParam("mDepoTrno_I", 0);
            ds = obDbAccess.records();

            return ds;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();


            obDbAccess.execute("USP_DIB015_GroupDetailsLoad", DBAccess.SQLType.IS_PROC);
            obDbAccess.addParam("mGroupID_I", GroupID_I);
            ds = obDbAccess.records();

            return ds;
        }

        public int Delete(int id)
        {
            DBAccess obDbAccess = new DBAccess();
            int i = 0;


            obDbAccess.execute("USP_DIS002_GroupDelete", DBAccess.SQLType.IS_PROC);
            obDbAccess.addParam("mGroupId", id);
            i = obDbAccess.executeMyQuery();

            return i;
        }
    }

   
}