using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.Distribution;
using MPTBCBussinessLayer;


public partial class Distrubution_GroupMas : System.Web.UI.Page
{

    PRIN_GroupCreation obGroupCreation = null;
    CommonFuction obCommon = null;
    MessageC m = new MessageC();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // PRIN_GroupCreation obGroupCreation = new PRIN_GroupCreation() ;
            CommonFuction obCommon = new CommonFuction();
            DdlACYear.DataSource = obCommon.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommon.GetFinYear();

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

        for (int i = 0; i < chkDepots.Items.Count; i++)
        {
            if (chkDepots.Items[i].Selected == true)
            {
                Ids = Ids + chkDepots.Items[i].Value + ",";

            }

        }
        return Ids;
    }
    public void LoadChkList()
    {

        obGroupCreation = new PRIN_GroupCreation();

        obGroupCreation.isSatellite_I = 0;
        chkDepots.DataValueField = "DepoTrno_I";
        chkDepots.DataTextField = "DepoName_V";

        chkDepots.DataSource = obGroupCreation.GroupListLoad();
        chkDepots.DataBind();

    }
    public void LoadGrd()
    {
        obGroupCreation = new PRIN_GroupCreation();
        obGroupCreation.ACYear = Convert.ToString(DdlACYear.SelectedValue);
        obGroupCreation.GroupId = 0;
        grdGroup.DataSource = obGroupCreation.Select();
        grdGroup.DataBind();


    }
    public int SaveGroup()
    {
        obGroupCreation = new PRIN_GroupCreation();
        obCommon = new CommonFuction();

        int i = 0;

        try
        {
            obGroupCreation.GroupId = Convert.ToInt32(HdnGroupId.Value);
            obGroupCreation.GroupName = Convert.ToString(txtGroupName.Text);
            obGroupCreation.DepotIds = GetDepoIds();
            obGroupCreation.ACYear = Convert.ToString(DdlACYear.SelectedValue);
            //obCommon.GetFinYear();

            if (GetDepoIds() != "")
            {
                obGroupCreation.Description = Convert.ToString(txtDescription.Text);
                i = obGroupCreation.InsertUpdate();

            }

        }

        catch (Exception ex) { }
        finally { obGroupCreation = null; }
        return i;
    }
    public void SaveBlockDepo()
    {
        obGroupCreation = new PRIN_GroupCreation();
        obCommon = new CommonFuction();


        try
        {
            for (int i = 0; i < chkDepots.Items.Count; i++)
            {
                if (chkDepots.Items[i].Selected == true)
                {
                    obGroupCreation.BlockDepoTrno_I = 0;
                    obGroupCreation.GroupId = Convert.ToInt32(HdnGroupId.Value);

                    obGroupCreation.DepoTrno_I = Convert.ToInt32(chkDepots.Items[i].Value);

                    obGroupCreation.UserTrno_I = Convert.ToInt32(Session["UserID"]);

                    obGroupCreation.ACYear = Convert.ToString(DdlACYear.SelectedValue);
                    //obCommon.GetFinYear();

                    obGroupCreation.SaveBlockDepo();
                }
            }

        }

        catch (Exception ex) { }
        finally { obGroupCreation = null; }


    }
    protected void btnSaveGroup_Click(object sender, EventArgs e)
    {
        string msg = "";
        if (txtGroupName.Text.Trim() == "")
        {
            msg += "ग्रुप का नाम भरे";
        }
        if (msg == "")
        {
            HdnGroupId.Value = SaveGroup().ToString();

            if (Convert.ToInt32(HdnGroupId.Value) > 0)
            {
                SaveBlockDepo();                
                LoadGrd();
                Clear();
                m.ShowMessage("s");
            }
            else
            {
                m.ShowOtherMessage("e", "Please Check your entry either Duplicate or not Correct");
            }
        }
        else
        {
            m.ShowOtherMessage("e", msg);
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
            //LoadChkList();
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < chkDepots.Items.Count; j++)
                {

                    if (chkDepots.Items[j].Text == s[i].Trim())
                    {
                        chkDepots.Items[j].Selected = true;
                    }

                }
            }
            HdnGroupId.Value = (Row.FindControl("HdnGroupId") as HiddenField).Value;
            txtGroupName.Text = (Row.FindControl("lblGroupName") as Label).Text;
            txtDescription.Text = (Row.FindControl("lblDescription") as Label).Text;            
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
            obGroupCreation = new PRIN_GroupCreation();
            obGroupCreation.GroupId = Convert.ToInt32(HdnGroupId.Value);
            obGroupCreation.Delete(Convert.ToInt32(HdnGroupId.Value));
            HdnGroupId.Value = "0";
            m.ShowMessage("d");
            Load();
            Clear();
        }
        catch (Exception)
        {
        }
    }
    public void Clear()
    {
        txtGroupName.Text = txtDescription.Text = string.Empty;
        LoadChkList();

        HdnGroupId.Value = "0";

    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}