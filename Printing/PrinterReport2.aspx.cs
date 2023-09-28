using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Printing_PrinterReport2 : System.Web.UI.Page
{
    DepoReport obDepoReport = new DepoReport();
    CultureInfo cult = new CultureInfo("gu-IN", true);
   public  CommonFuction COMM = new CommonFuction();
    public DataSet ds1;
    public int i;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}