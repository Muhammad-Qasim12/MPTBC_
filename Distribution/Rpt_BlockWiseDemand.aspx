<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Rpt_BlockWiseDemand.aspx.cs" Inherits="Distrubution_Rpt_BlockWiseDemand" %>
 
 
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <style type="text/css">
       #ctl00_ContentPlaceHolder1_ddlPrinterName label {
  /**display: block;*/
  padding-left: 23px;
  text-indent: -15px;
  float: left;
}

.chkChoice input 
{ 
    width: 13px;
  height: 13px;
  padding: 0;
  margin:0;
  vertical-align: bottom;
  position: relative;
  top: -1px;
  *overflow: hidden;
  float: left;
}

.chkChoice td 
{ 
    padding-left: 10px; 
}

.PnlDesign
{
            border: solid 1px #000000;
            height: 150px;
            width: 330px;
            overflow-y:scroll;
            background-color: #EAEAEA;
            font-size: 15px;
            font-family: Arial;
}
    </style>
     <script type="text/javascript">
         var rptCtrl = '<%=ReportViewer1.ClientID%>' + '_ctl09';
         var rptCtrl11 = '<%=ReportViewer1.ClientID%>';
    </script>
    <script type="text/javascript" src="../../js/jquery-1.3.2.js"></script> 
    <script type="text/javascript" src="../../js/printrdlc.js"></script> 
    <div class="box">
        <div class="card-header">
            <h2>
                <span>
                    <asp:Label ID="lblTitleName" runat="server"></asp:Label>
                </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;<br /> Academic Year :</asp:Label>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            </asp:DropDownList>


                        </td>

                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblDepot" runat="server">&#2337;&#2367;&#2346;&#2379; <br /> Depot :</asp:Label>
                            <asp:DropDownList ID="DDlDepot" runat="server" CssClass="txtbox"
                                OnSelectedIndexChanged="DDlDepot_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>


                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblDistrict" runat="server">&#2332;&#2367;&#2354;&#2366; <br /> District  :</asp:Label>
                            <asp:DropDownList ID="DdlDistrict" runat="server" CssClass="txtbox" Enabled="false">
                            </asp:DropDownList>
                        </td>


                    </tr>
                    <tr>

                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblClass" runat="server">&#2325;&#2325;&#2381;&#2359;&#2366; <br /> Class :</asp:Label>
                            <asp:DropDownList ID="DDLClass" runat="server" CssClass="txtbox"
                                OnSelectedIndexChanged="DDLClass_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                                <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                            </asp:DropDownList>
                        </td>

                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblScheme" runat="server">&#2351;&#2379;&#2332;&#2344;&#2366; <br /> Scheme :</asp:Label>
                            <asp:DropDownList ID="DdlScheme" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                        </td>
                        <td style="font-size: medium;" valign="top">
                            <asp:Label ID="LblDemandType" runat="server" Width="200px">&#2350;&#2366;&#2306;&#2327; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br />Demand Type :</asp:Label>
                            <asp:DropDownList ID="DDlDemandType" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; / See Report" CssClass="btn" OnClick="Button1_Click" />
                        </td>

                    </tr>
                </table>
                <div style="overflow: auto" class="rdlc">
                    <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server"
                        DocumentMapWidth="100%" Height="" SizeToReportContent="True">
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

