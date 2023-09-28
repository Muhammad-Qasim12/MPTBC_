using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.Distribution;


public partial class Distrubution_GroupMaster : System.Web.UI.Page
{

    DIS001_GroupCreation obGroupCreation = null;
    MessageC m = new MessageC();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Load();
        }
    }
    public void Load()
    {
        LoadChkList();
        LoadGrd();
    }

    public string GetDepoIds()
    {
        string Ids = "";
        try
        {
            for (int i = 0; i < chkDepots.Items.Count; i++)
            {
                if (chkDepots.Items[i].Selected == true)
                {
                    Ids = Ids + chkDepots.Items[i].Value + ",";
                }
            }
        }
        catch (Exception)
        {
        }        
        return Ids;
    }

    public void LoadChkList()
    {
        try
        {
            obGroupCreation = new DIS001_GroupCreation();
            obGroupCreation.isSatellite_I = 0;
            chkDepots.DataValueField = "DepoTrno_I";
            chkDepots.DataTextField = "DepoName_V";
            chkDepots.DataSource = obGroupCreation.GroupListLoad();
            chkDepots.DataBind();
        }
        catch (Exception)
        {
        }
    }

    public void LoadGrd()
    {
        try
        {
            obGroupCreation = new DIS001_GroupCreation();
            obGroupCreation.GroupId = 0;
            grdGroup.DataSource = obGroupCreation.Select();
            grdGroup.DataBind();
        }
        catch (Exception)
        {
        }
    }

    public int SaveGroup()
    {
        obGroupCreation = new DIS001_GroupCreation();
        int i = 0;

        try
        {
            obGroupCreation.GroupId = Convert.ToInt32(HdnGroupId.Value);
            obGroupCreation.GroupName = Convert.ToString(txtGroupName.Text);
            obGroupCreation.DepotIds = GetDepoIds();
            if (GetDepoIds() != "")
            {
                obGroupCreation.Description = Convert.ToString(txtDescription.Text);
                i = obGroupCreation.InsertUpdate();
                Clear();
            }
        }
        catch (Exception ex) { }
        finally { obGroupCreation = null; }
        return i;
    }
    protected void btnSaveGroup_Click(object sender, EventArgs e)
    {
        if (SaveGroup() > 0)
        {
            m.ShowMessage("s");
            LoadGrd();
        }
        else
        {
            m.ShowMessage("e");
        }
    }
    protected void grdGroup_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridViewRow Row = (GridViewRow)grdGroup.Rows[e.RowIndex];
            Label x = Row.FindControl("lblDepotIds") as Label;
            string y = x.Text;
            string[] s = y.Split(',');
            LoadChkList();
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < chkDepots.Items.Count; j++)
                {

                    if (chkDepots.Items[j].Text == s[i])
                    {
                        chkDepots.Items[j].Selected = true;
                    }

                }
            }
            HdnGroupId.Value = (Row.FindControl("HdnGroupId") as HiddenField).Value;
            txtGroupName.Text = (Row.FindControl("lblGroupName") as Label).Text;
            txtDescription.Text = (Row.FindControl("lblDescription") as Label).Text;
            mainDiv.Style.Add("display", "none");
        }
        catch (Exception)
        {
        }
    }
    protected void grdGroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            GridViewRow Row = (GridViewRow)grdGroup.Rows[e.RowIndex];
            HdnGroupId.Value = (Row.FindControl("HdnGroupId") as HiddenField).Value;
            obGroupCreation = new DIS001_GroupCreation();
            obGroupCreation.GroupId = Convert.ToInt32(HdnGroupId.Value);
            obGroupCreation.Delete(Convert.ToInt32(HdnGroupId.Value));
            HdnGroupId.Value = "0";
            Load();
            Clear();
            m.ShowMessage("d");
        }
        catch (Exception)
        {
        }
    }
    public void Clear()
    {
        txtGroupName.Text = txtDescription.Text = string.Empty;
        LoadChkList();
    }
}