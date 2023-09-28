using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
public partial class Distrubution_DIS_0011_DemandTypeMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


           

            if (Request.QueryString["ID"] != null)
            {
                DemandTypeMaster onDemandTypeMaster = new DemandTypeMaster();
                onDemandTypeMaster.DemandTypeId  = Convert.ToInt32(Request.QueryString["ID"]);
                DataSet ds = onDemandTypeMaster.Select();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txtDemandTypeHindi.Text = Convert.ToString(dr["DemandTypeHindi"]);
                    txtDemandTypeEng.Text  = Convert.ToString(dr["DemandTypeEng"]);

                    txtDemandDisc.Text = Convert.ToString(dr["Discription"]);
                }

            }


        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    { 
        DemandTypeMaster onDemandTypeMaster = new DemandTypeMaster();
        if (Request.QueryString["ID"] != null)
        { 
            onDemandTypeMaster.DemandTypeId  = Convert.ToInt32(Request.QueryString["ID"]);
        }
        else {
            onDemandTypeMaster.DemandTypeId= 0 ;
        }

            onDemandTypeMaster.DemandTypeHindi = txtDemandTypeHindi.Text ;
            onDemandTypeMaster.DemandTypeEng = txtDemandTypeEng.Text;
            onDemandTypeMaster.Discription  = txtDemandDisc.Text;
            onDemandTypeMaster.InsertUpdate();
            Response.Redirect("View_001.aspx");

        }
             

    }
