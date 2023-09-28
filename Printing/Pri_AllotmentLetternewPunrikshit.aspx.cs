using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using MPTBCBussinessLayer;
using Microsoft.Reporting.WebForms;

public partial class Printing_Pri_AllotmentLetternewPunrikshit : System.Web.UI.Page
{
    public CommonFuction comm = new CommonFuction();
    public DataSet dd = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dd = comm.FillDatasetByProc("CALL USP_PRI011_GroupAllotementLetterprintpunrishit('" + Request.QueryString["Printerid"] + "','" + Request.QueryString["Fyear"] + "','" + Request.QueryString["Tenderid"] + "')");

            GridView1.DataSource = dd.Tables[0];
            //comm.FillDatasetByProc("call GetpaperDetailsbyOrder('9174')");
            GridView1.DataBind();
            GridView2.DataSource = dd.Tables[1];
            GridView2.DataBind();


        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int rowIndex = GridView1.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow gvRow = GridView1.Rows[rowIndex];
            GridViewRow gvPreviousRow = GridView1.Rows[rowIndex + 1];
            for (int cellCount = 0; cellCount < gvRow.Cells.Count; cellCount++)
            {

                if (cellCount < 0)
                {
                }
                else
                {
                    //if (cellCount == 1 || cellCount == 3 || cellCount == 12 || cellCount == 13 || cellCount == 14)
                    if (cellCount == 1)
                    {
                        if ((gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text))
                        // && (gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text))
                        {
                            if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                            {
                                gvRow.Cells[cellCount].RowSpan = 2;
                            }
                            else
                            {
                                gvRow.Cells[cellCount].RowSpan = gvPreviousRow.Cells[cellCount].RowSpan + 1;
                            }
                            gvPreviousRow.Cells[cellCount].Visible = false;
                        }
                    }
                }
            }
        }

    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int rowIndex = GridView2.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow gvRow = GridView2.Rows[rowIndex];
            GridViewRow gvPreviousRow = GridView2.Rows[rowIndex + 1];
            for (int cellCount = 0; cellCount < gvRow.Cells.Count; cellCount++)
            {

                if (cellCount < 0)
                {
                }
                else
                {
                    //if (cellCount == 1 || cellCount == 3 || cellCount == 12 || cellCount == 13 || cellCount == 14)
                    if (cellCount == 1)
                    {
                        if ((gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text))
                        // && (gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text))
                        {
                            if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                            {
                                gvRow.Cells[cellCount].RowSpan = 2;
                            }
                            else
                            {
                                gvRow.Cells[cellCount].RowSpan = gvPreviousRow.Cells[cellCount].RowSpan + 1;
                            }
                            gvPreviousRow.Cells[cellCount].Visible = false;
                        }
                    }
                }
            }
        }
    }
}