using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.IO;
using System.Data;

public partial class Depo_Tender_TenderChecklist : System.Web.UI.Page
{
    Vehicle003_Tender obTender = null;
    CommonFuction obCommonFuction = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Cid"] != null)
            { LoadCheckList(); }
            else { Response.Redirect("VIEW003_TenderParticipent.aspx"); }

        }
    }
    public void LoadCheckListCondition()
    {
        DataSet ds = new DataSet();
        obTender = new Vehicle003_Tender();
        obTender.TenderCheckListTrno = Convert.ToInt32(0);
        if (Request.QueryString["TDId"] != null)
        {
            obCommonFuction = new CommonFuction();
            ds = obCommonFuction.FillDatasetByProc("call DPT_checklistcondition(0," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["Cid"])) + "," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["TDId"])) + ",0,4)");
            if (ds.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                ds = obCommonFuction.FillDatasetByProc("call DPT_checklistcondition(0," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["Cid"])) + "," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["TDId"])) + ",0,1)");
            }
        }

        GrdCondition.DataSource = ds;
        GrdCondition.DataBind();
    }


    public int SaveCheckList()
    {
        int i = 0;

        obTender = new Vehicle003_Tender();

        try
        {
            if (Request.QueryString["Cid"] != null)
            {
                obTender.TenderParID_I = Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["Cid"]));
            }

            APIProcedure objApi = new APIProcedure();
            string FilePath = "", uploadStatus = "";
            obCommonFuction = new CommonFuction();
            foreach (GridViewRow gv in GrdCondition.Rows)
            {
                FilePath = "";
                FileUpload FileUpload = (FileUpload)gv.FindControl("Fileregistration_V");
                if (FileUpload.HasFile)
                {
                    uploadStatus = objApi.SingleuploadFile(FileUpload, "Vehicle/VehicleFile", 3000);
                    if (uploadStatus != "Ok")
                    {
                        message(uploadStatus, "ERROR");
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('" + uploadStatus + "');</script>");
                    }
                }
                else
                {
                    uploadStatus = "NotOk";
                }
                if (uploadStatus == "Ok")
                {
                    FilePath = "VehicleFile/" + objApi.FullFileName;
                }

                Label lblTermConditionID = (Label)gv.FindControl("lblId");
                Label lblIdSrNo = (Label)gv.FindControl("lblIdSrNo");
                Label lblFilePath = (Label)gv.FindControl("lblFilePath");
                CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                if (lblIdSrNo.Text == "0")
                {
                    obCommonFuction.FillDatasetByProc("call DEpo_TenderCheckLiastInsertAll(0," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["Cid"])) + "," + int.Parse(lblTermConditionID.Text) + ",'" + FilePath + "'," + Convert.ToByte(chkSelect.Checked) + "," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["TDId"])) + ",0)");
                }
                else
                {
                    if (uploadStatus == "NotOk")
                    {
                        FilePath = lblFilePath.Text;
                    }

                    obCommonFuction.FillDatasetByProc("call DEpo_TenderCheckLiastInsertAll(" + int.Parse(lblIdSrNo.Text) + "," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["Cid"])) + "," + int.Parse(lblTermConditionID.Text) + ",'" + FilePath + "'," + Convert.ToByte(chkSelect.Checked) + "," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["TDId"])) + ",1)");
                }
                i = 1;
            }

            // i = obTender.ChkListSaveUpdate();
            //}
        }

        catch (Exception ex) { }

        finally { obTender = null; }

        return i;

    }



    public void LoadCheckList()
    {
        DataSet ds = new DataSet();

        obTender = new Vehicle003_Tender();
        try
        {
            obTender.TenderParID_I = Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["Cid"]));
            LoadCheckListCondition();

            //ds = obTender.LoadTenderChkList();

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    GrdCondition.DataSource = ds;
            //    GrdCondition.DataBind();
            //}
            //else
            //{
            //    LoadCheckListCondition();
            //}

        }

        catch (Exception ex) { }

        finally { obTender = null; }


    }

    protected void GrdCondition_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblCheckStatus = (Label)e.Row.FindControl("lblDisplayStatus");
            Label lblDocPath = (Label)e.Row.FindControl("lblDocPath");
            Label lblFilePath = (Label)e.Row.FindControl("lblFilePath");

            if (lblFilePath.Text == "")
            {
                lblDocPath.Text = "<a href='#'>देखे / View</a>";
            }
            else
            {
                lblDocPath.Text = "<a href='" + lblFilePath.Text + "' target='_blank'>देखे / View</a>";
            }
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            if (Request.QueryString["Cid"] != null)
            {
                if (lblCheckStatus.Text.ToLower() == "0")
                {
                    chkSelect.Checked = false;
                }
                else
                {
                    chkSelect.Checked = true;
                }

            }
            else
            {
                if (lblCheckStatus.Text.ToLower() == "0")
                {
                    chkSelect.Checked = false;
                }
                else
                {
                    chkSelect.Checked = true;
                }

            }
        }
    }

    protected void btnSaveCheckList_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Cid"] != null)
        {
            if (SaveCheckList() > 0)
            {
                message("Details Saved.", "SUCCESS");

                Response.Redirect("VIEW003_TenderParticipent.aspx");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Details Saved.');</script>");
            }
            else
            {

                //message("Error", "ERROR");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Error');</script>");
            }
        }
        else
        {
            Response.Redirect("VIEW003_TenderParticipent.aspx");
        }
    }



    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("VIEW003_TenderParticipent.aspx");
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


    protected void RadioNoofVehicle_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void RadioStaxregistration_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}