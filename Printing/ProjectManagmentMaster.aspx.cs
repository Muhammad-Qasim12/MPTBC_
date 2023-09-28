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

public partial class Printing_ProjectManagment : System.Web.UI.Page
{

    PRI_ProjectManagement obj = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            DescriptionLoad(ddlDescription, "TimeLineCompName_V", "TimeLineCompID_I");
            DescriptionLoad(ddlTimeline, "TimeLineCompName_V", "TimeLineCompID_I");
            Load();
        }
    }


    public void DescriptionLoad(DropDownList ddl,string dtf,string dvf) 
    {
        obj = new PRI_ProjectManagement();

        ddl.DataTextField = dtf;
        ddl.DataValueField = dvf;
        ddl.DataSource = obj.ProjectTimeLineDescriptionLoad();
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("Select", "0"));
    }

    public void  Load() 
    {
        obj = new PRI_ProjectManagement();

        GrdTimeLineDetail.DataSource= obj.ProjectTimeLineLoad();
        GrdTimeLineDetail.DataBind();

    }

    public int Save()
    {
        obj = new PRI_ProjectManagement();

        obj.TimelineTrno_I = Convert.ToInt32(HdnTimelineTrno_I.Value);
        obj.TimelineDay_I = Convert.ToInt32(txtTimeLineDays.Text);
        obj.TimelinebaseID_I = Convert.ToInt32(ddlDescription.SelectedValue);
        obj.TimelineCompid_I = Convert.ToInt32(ddlTimeline.SelectedValue);

        int i = obj.ProjectTimeLineSave();

        return i;

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Save() > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Details saved Successfully.');</script>");
                Load();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Error.');</script>");
                Load();
            }
        }

        catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert(" + ex.Message + ");</script>"); }
        finally { obj = null; }
    }

    public class PRI_ProjectManagement : DBAccess
    {
       private  int _TimelineTrno_I, _TimelineDay_I, _TimelinebaseID_I, _TimelineCompid_I;

       public int TimelineTrno_I { get { return _TimelineTrno_I; } set { _TimelineTrno_I = value; } }
       public int TimelineDay_I { get { return _TimelineDay_I; } set { _TimelineDay_I = value; } }
       public int TimelinebaseID_I { get { return _TimelinebaseID_I; } set { _TimelinebaseID_I = value; } }
       public int TimelineCompid_I { get { return _TimelineCompid_I; } set { _TimelineCompid_I = value; } }

        public DataSet ProjectTimeLineDescriptionLoad() 
        {
            DataSet ds= new DataSet();
            execute("USP_PRI003_ProjectManagementTileLineDescriptionLoad", SQLType.IS_PROC);

            ds = records();

            return ds;
        
        }

        public DataSet ProjectTimeLineLoad()
        {
            DataSet ds = new DataSet();
            execute("USP_PRI003_ProjectManagementTimeLineLoad", SQLType.IS_PROC);

            ds = records();

            return ds;

        }

        public int ProjectTimeLineSave()
        {
            int i = 0;
            execute("USP_PRI003_ProjectManagementTimeLineSaveUpdate", SQLType.IS_PROC);
            addParam("mTimelineTrno_I", TimelineTrno_I);
            addParam("mTimelineDay_I", TimelineDay_I);
            addParam("mTimelinebaseID_I", TimelinebaseID_I);
            addParam("mTimelineCompid_I", TimelineCompid_I);

            i = executeMyQuery();

            return i;

        }

    
    }



   
}
