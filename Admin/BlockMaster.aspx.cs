using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
public partial class Admin_BlockMaster : System.Web.UI.Page
{
    APIProcedure objdb = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            DistrictMaster onDistrictMaster = new DistrictMaster();
            ddlDistrict.DataSource = onDistrictMaster.Select();
            ddlDistrict.DataValueField = "DistrictTrno_I";
            ddlDistrict.DataTextField = "District_Name_Hindi_V";
            ddlDistrict.DataBind();
          

            if (Request.QueryString["ID"] != null)
            {
                Blockmaster obBlockmaster = new Blockmaster();
                obBlockmaster.BlockTrno_I = Convert.ToInt32(objdb.Decrypt(Request.QueryString["ID"].ToString()));
                DataSet ds = obBlockmaster.Select();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txtBlockName.Text = Convert.ToString(dr["Blockname_v"]);
                    ddlDistrict.SelectedValue = Convert.ToString(dr["DistrictTrno_I"]);

                    txtHindiBlockName.Text = Convert.ToString(dr["BlockNameHindi_V"]);
                    txtKramank.Text = Convert.ToString(dr["Srno"]);
                }

            }

        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
        //    Blockmaster obBlockmaster = new Blockmaster();
        //    obBlockmaster.BlockTrno_I = Convert.ToInt32(objdb.Decrypt(Request.QueryString["ID"].ToString()));
        //    obBlockmaster.BlockName_V = txtBlockName.Text;
        //    obBlockmaster.DistrictTrno_I = Convert.ToInt32(ddlDistrict.SelectedValue);
        //    obBlockmaster.BlockNameHindi_V = txtHindiBlockName.Text;
            
        //    obBlockmaster.InsertUpdate();
          CommonFuction obcomm = new CommonFuction();
            obcomm.FillDatasetByProc("call BlockMasterUpdate('" + txtBlockName.Text + "'," + ddlDistrict.SelectedValue + ",'" + txtHindiBlockName.Text + "'," + txtKramank.Text + "," + Convert.ToInt32(objdb.Decrypt(Request.QueryString["ID"].ToString())) + ")");
            Response.Redirect("View_0011.aspx");
        
        }
        else
        {
            Blockmaster obBlockmaster = new Blockmaster();

            obBlockmaster.BlockName_V = txtBlockName.Text;
            obBlockmaster.DistrictTrno_I = Convert.ToInt32(ddlDistrict.SelectedValue);
            obBlockmaster.BlockNameHindi_V = txtHindiBlockName.Text;
            obBlockmaster.InsertUpdate();
     
            Response.Redirect("View_0011.aspx");
        }

    }
}