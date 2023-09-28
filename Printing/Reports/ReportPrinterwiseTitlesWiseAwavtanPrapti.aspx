<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportPrinterwiseTitlesWiseAwavtanPrapti.aspx.cs" Inherits="Printing_Reports_ReportPrinterwiseTitlesWiseAwavtanPrapti" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_ddlPrinterName label {
            padding-left: 23px;
            text-indent: -15px;
            float: left;
        }

        .chkChoice input {
            width: 13px;
            height: 13px;
            padding: 0;
            margin: 0;
            vertical-align: bottom;
            position: relative;
            top: -1px;
            *overflow: hidden;
            float: left;
        }

        .chkChoice td {
            padding-left: 10px;
        }

        .PnlDesign {
            border: solid 1px #000000;
            height: 150px;
            width: 330px;
            overflow-y: scroll;
            background-color: #EAEAEA;
            font-size: 15px;
            font-family: Arial;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var rptCtrl = '<%=ReportViewer1.ClientID%>' + '_ctl09';
        var rptCtrl11 = '<%=ReportViewer1.ClientID%>';
    </script>
    <script type="text/javascript" src="../../js/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../../js/printrdlc.js"></script>
    <div class="portlet-header ui-widget-header">
        &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2319;&#2357;&#2306; &#2357;&#2367;&#2340;&#2352;&#2339; 
    </div>

    <table width="100%">




        <tr>

            <td style="font-size: medium;" valign="middle">
                <asp:Label ID="LblAcYear" Width="144px" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;/ Year :</asp:Label>
                <asp:DropDownList ID="DdlACYear" Width="100px" AutoPostBack="true" runat="server" CssClass="txtbox reqirerd" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                </asp:DropDownList>
            </td>

            <td style="font-size: medium;" valign="top">
                <asp:Label Width="144px" ID="Label7" runat="server">&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; / Printer</asp:Label>
                <asp:DropDownList runat="server" ID="ddlPrinterName" CssClass="txtbox reqirerd">
                    <asp:ListItem Text="All"></asp:ListItem>
                </asp:DropDownList>
            </td>



            <td style="font-size: medium;" valign="top">
                <asp:Label Width="144px" ID="Label2" runat="server">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;  / Title</asp:Label>
                <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox" Width="100px"></asp:DropDownList>
            </td>



            <td style="font-size: medium;" valign="top">
                <asp:Label Width="144px" ID="lblDepo" runat="server">&#2337;&#2367;&#2346;&#2379; / Depot</asp:Label>
                <asp:DropDownList ID="DdlDepot" runat="server">
                </asp:DropDownList>
            </td>



            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search " OnClick="btnSearch_Click" />
            </td>
        </tr>



    </table>
    <div style="overflow: scroll;" width="1200px">
        <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server" DocumentMapWidth="100%"
            Height="" SizeToReportContent="True">
        </rsweb:ReportViewer>
    </div>

 
</asp:Content>

