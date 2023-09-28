<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportPrinterwiseTitlesWiseMasterRpt.aspx.cs" Inherits="ReportPrinterwiseTitlesWiseMasterRpt" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_ddlPrinterName label {
            /**display: block;*/
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
        /*.txtbox
        {
            background-image: url(../../images/drpdwn.png);
            background-position: right top;
            background-repeat: no-repeat;
            cursor: pointer;
            cursor: hand;
        }*/
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
            <td colspan="5">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="1">पाठ्य सामग्री </asp:ListItem>
                    <asp:ListItem Value="2">अन्य पाठ्य सामग्री </asp:ListItem>
                    <asp:ListItem Value="3">पाठ्य सामग्री/अन्य पाठ्य सामग्री </asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;</td>
            <td>&nbsp; <asp:Button ID="btnRefress" runat="server" CssClass="btn" Text="Refress " OnClick="btnRefress_Click" /></td>
        </tr>



        <tr>
            <td>
                <asp:Label ID="LblAcYear" runat="server">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Name of Printer</asp:Label>
                <%-- <asp:DropDownList ID="ddlPrinterName" runat="server" CssClass="txtbox" Width="100px">
                </asp:DropDownList>--%>

                <asp:DropDownList ID="txtCustomer" runat="server" CssClass="txtbox" Height="23px" Width="60px">
                    <asp:ListItem Text="All" Value="" hidden></asp:ListItem>
                </asp:DropDownList>
                <asp:Panel ID="PnlCust" runat="server" CssClass="PnlDesign">
                    <asp:CheckBoxList ID="ddlPrinterName" runat="server" CssClass="chkChoice">
                    </asp:CheckBoxList>
                </asp:Panel>
                <cc1:PopupControlExtender ID="PceSelectCustomer" runat="server" TargetControlID="txtCustomer"
                    PopupControlID="PnlCust" Position="Bottom">
                </cc1:PopupControlExtender>
            </td>
            <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;
                <br />
                <asp:DropDownList ID="DdlScheme" runat="server" CssClass="txtbox" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="DdlScheme_SelectedIndexChanged"></asp:DropDownList>

            </td>
            <td>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;/ Title
                <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox" Width="100px"></asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="LblClass" runat="server" Width="85px">&#2325;&#2325;&#2381;&#2359;&#2366;  / Class</asp:Label>
                <asp:DropDownList ID="DdlClass" runat="server" CssClass="txtbox" TabIndex="4" Width="60px">
                    <asp:ListItem Value="0">All</asp:ListItem>
                    <asp:ListItem Value="1">1 To 8</asp:ListItem>
                    <asp:ListItem Value="2">9 To 12  </asp:ListItem>
                    <asp:ListItem Value="3">1 To 12</asp:ListItem>
                    <asp:ListItem Value="4">NCERT</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlBookType" runat="server" CssClass="txtbox reqirerd" Width="120px" Visible="false">
                    <asp:ListItem Value="0">All</asp:ListItem>
                    <asp:ListItem Value="1">&#2351;&#2379;&#2332;&#2344;&#2366;</asp:ListItem>
                    <asp:ListItem Value="2">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;</asp:ListItem>
                </asp:DropDownList>
            </td>

            <%--  <td>
                <asp:RadioButton ID="rdoRptSummary" runat="server" GroupName="rptType" Text="Summery" Checked="true" />
                <asp:RadioButton ID="rdoRptDetail" runat="server" GroupName="rptType" Text="Detail" />
            </td>--%>
            <td>
                <asp:CheckBox ID="chkOrderByDate" runat="server" Text="Order By 100% Date" onclick="clearAllRadios()" />
            </td>
            <td>
                <asp:RadioButton ID="rdoAll" runat="server" GroupName="rptAll" Text="All" />
                <asp:RadioButton ID="rdoL100" runat="server" GroupName="rptAll" Text="Less Than 100%" />
                <asp:RadioButton ID="rdoH100" runat="server" GroupName="rptAll" Text="Equal To 100%" />
            </td>
            <td><br />
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search " OnClick="btnSearch_Click" />
            </td>
        </tr>



    </table>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        interactivedeviceinfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
        Width="100%" Height="657px">
    </rsweb:ReportViewer>

    <script type="text/javascript">
        function clearAllRadios() {
            var radList = document.getElementsByName('ctl00$ContentPlaceHolder1$rptAll');
            for (var i = 0; i < radList.length; i++) {
                if (radList[i].checked) radList[i].checked = false;
            }
        }
    </script>
</asp:Content>

