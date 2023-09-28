<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReceiptPrint.aspx.cs" Inherits="CenterDepot_ReceiptPrint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="portlet-header ui-widget-header">
                            <asp:Label ID="lblTitle0" runat="server" Text="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2352;&#2360;&#2368;&#2342;"></asp:Label>
    </div>
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year</asp:Label>
                <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox"  Width="120px">
                    <asp:ListItem>..Select..</asp:ListItem>
                    <asp:ListItem>2012-13</asp:ListItem>
                    <asp:ListItem>2013-14</asp:ListItem>
                    <asp:ListItem>2014-15</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354;/Paper Mill
                <asp:DropDownList ID="ddlVendorName" runat="server" CssClass="txtbox" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="ddlVendorName_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td style="text-align: left;">&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; :<asp:DropDownList ID="ddlChallan" runat="server" CssClass="txtbox" Width="120px" >
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" OnClick="btnSearch_Click" Text="&#2326;&#2379;&#2332;&#2375; / Search " />
            </td>
        </tr>
        <tr>
            <td colspan="5"> <div align="left">
            <a href="#" class="btn" style="color: White;" onclick="return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;</a>
        </div>
                 <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="false" >
                <table width="100%">
                    <tr>
                        <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">&quot; &#2325;&#2375;&#2344;&#2381;&#2342;&#2381;&#2352;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352; &quot; </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">&#2309;&#2352;&#2375;&#2352;&#2366; &#2361;&#2367;&#2354;&#2381;&#2360; , &#2349;&#2379;&#2346;&#2366;&#2354; (&#2350;.&#2346;&#2381;&#2352;) 462011<br />
                            &#2342;&#2370;&#2352;&#2349;&#2366;&#2359; - 0755-2550727, 2551294, 2551565, &#2347;&#2376;&#2325;&#2381;&#2360; - 2551145,
                            <br />
                            &#2312;-&#2350;&#2375;&#2354; - infomptbc@mp.gov.in, &#2357;&#2375;&#2348;&#2360;&#2366;&#2311;&#2335;- mptbc.nic.in </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: left;" width="100%;">&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; :<asp:Label ID="lblYear" runat="server" Font-Bold="true"></asp:Label>
                            dddep;o</td>
                    </tr>
                    <tr>
                        <td colspan="4" style="font-size: 16px; font-weight: bold; text-align: center;">
                            <asp:Label ID="lblTitle" runat="server" Text="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2352;&#2360;&#2368;&#2342;"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="font-size: 12px; text-align: right;"></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                            <table width="100%">
                                <tr>
                                    <td style="text-align: left" width="50%">GSR &#2346;&#2375;&#2332; &#2325;&#2381;&#2352;&#2306;. :<asp:Label ID="lblGSRPagePrint" runat="server" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="text-align: right" width="50%">&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; :<asp:Label ID="lblReceiptPrint" runat="server" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&#2357;&#2366;&#2361;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; :<asp:Label ID="lblVehicleNoPrint" runat="server" Font-Bold="true"></asp:Label>
                                        &#2325;&#2375; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2369;&#2354; &#2352;&#2368;&#2354; / &#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                        <asp:Label ID="lblReceiptReelPrint" runat="server" Font-Bold="true"></asp:Label>
                                        &#2332;&#2367;&#2360;&#2350;&#2375;&#2306; &#2337;&#2376;&#2350;&#2375;&#2332; &#2352;&#2368;&#2354; / &#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                        <asp:Label ID="lblDamajReelPrint" runat="server" Font-Bold="true"></asp:Label>
                                        &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2368; &#2327;&#2312; | </td>
                                </tr>
                                <tr>
                                    <td style="height: 25px" width="50%"></td>
                                    <td width="50%"></td>
                                </tr>
                                <tr>
                                    <td width="50%">&#2360;&#2381;&#2335;&#2379;&#2352;&#2325;&#2368;&#2346;&#2352; </td>
                                    <td style="text-align: right" width="50%">&#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325; </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;" width="50%">.................................. </td>
                                    <td style="text-align: right" width="50%">................................. </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table></asp:Panel> 

            </td>
        </tr>
    </table>
     <script type="text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=Panel1.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }</script>
</asp:Content>

