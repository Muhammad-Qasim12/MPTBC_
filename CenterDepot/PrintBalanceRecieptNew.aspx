<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrintBalanceRecieptNew.aspx.cs" Inherits="CenterDepot_PrintBalanceRecieptNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="../css/printrcpt.css" rel="stylesheet" media="all" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2348;&#2376;&#2354;&#2375;&#2306;&#2360; &#2346;&#2352;&#2381;&#2330;&#2368; / Print Balance Reciept
    </div>
    <div>
        <table>
            <tr>
                <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; /Acadmic Year :
                    <asp:DropDownList ID="ddlAcYear" runat="server" Width="100px" OnInit="ddlAcYear_Init" AutoPostBack="true" OnSelectedIndexChanged="ddlAcYear_SelectedIndexChanged"></asp:DropDownList></td>
                <td>&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;<br />
                    Printer Name</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlPrinter" Width="200px" OnSelectedIndexChanged="ddlPrinter_OnSelectionChanged" AutoPostBack="true" CssClass="txtbox reqirerd">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" >
                        <asp:ListItem Value="1">&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2360;&#2375; &#2346;&#2361;&#2354;&#2375; </asp:ListItem>
                        <asp:ListItem Selected="True" Value="2">&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2360;&#2375; &#2348;&#2366;&#2342; </asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>&#2326;&#2366;&#2340;&#2366; &#2325;&#2381;&#2352;.</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlBRRecieptNo" Width="160px" CssClass="txtbox reqirerd" >
                    </asp:DropDownList>
                </td>
                <td><asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search" OnClick="btnSearch_Click" /></td>
                <td>
                    <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" OnClientClick="return PrintPanel();" Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;" OnClick="btnExportPDF_Click" />
                </td>
            </tr>
        </table>
    </div>

    <div style="width: auto; height: auto;">
        <center>
            <div class="MT20">
                <asp:Panel ID="Panel1" runat="server" Width="100%">
                    <div id="ExportDiv" runat="server">
                        <div style="width: 900px;">
                            <div style="padding: 10px;">
                                <asp:Repeater ID="rptPrint" runat="server" OnItemDataBound="rpt_ItemDataBound">
                                    <HeaderTemplate>
                                        <table align="center">
                                            <thead>
                                                <tr>

                                                    <th colspan="6">&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;, &#2325;&#2375;&#2306;&#2342;&#2381;&#2352;&#2368;&#2351; &#2349;&#2339;&#2381;&#2337;&#2366;&#2352; ,
                                                        <asp:Label ID="lblWarehousename" runat="server"></asp:Label>
                                                        <br />
                                                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                                                        <asp:Label ID="lblAcYear" runat="server"></asp:Label>
                                                        &#2361;&#2375;&#2340;&#2369; &#2325;&#2366;&#2327;&#2332; &#2325;&#2366; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;
                                                    </th>

                                                </tr>

                                            </thead>
                                        </table>
                                        <br />
                                        <br />

                                        <table class="hastable" cellspacing="10" style="border-collapse: collapse;">
                                            <tr>
                                                <td colspan="8" style="border-right: 1px solid black; font-weight: bold; border-top: 1px solid black;">&#2350;&#2369;&#2342;&#2381;&#2352;&#2325;/ &#2360;&#2306;&#2360;&#2381;&#2341;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; &#2357; &#2346;&#2340;&#2366;: 
                                                    <asp:Label ID="lblPRinterNameAddress" runat="server" Style="font-weight: normal;"></asp:Label>
                                                    <div style="float: right;">&#2326;&#2366;&#2340;&#2366; &#2325;&#2381;&#2352;.
                                                        <asp:Label ID="lblBRNo" Style="font-weight: normal;" runat="server"></asp:Label></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8" style="border-right: 1px solid black; font-weight: bold; border-top: 1px solid black;text-align:left;">शीर्षक का नाम:&nbsp;&nbsp; 
                                                   <asp:Label ID="lblTitle_V" runat="server" Font-Bold="false"></asp:Label>
                                                </td>


                                            </tr>
                                            <tr>
                                                <th colspan="3" style="border-top: 1px solid black; font-weight: bold;">&#2342;&#2367;&#2344;
                                                    <asp:Label ID="lblBRDate" runat="server"></asp:Label>
                                                    &#2325;&#2379; &#2358;&#2375;&#2359; &#2325;&#2366;&#2327;&#2332; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; </th>
                                                <th colspan="5" style="border-right: 1px solid black; border-top: 1px solid black; font-weight: bold;">&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;</th>
                                            </tr>
                                            <tr>
                                                <th style="width: 10%">&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</th>
                                                <th>&#2325;&#2366;&#2327;&#2332; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;</th>                                               
                                                <th>&#2357;&#2332;&#2344;/&#2352;&#2368;&#2350;/&#2358;&#2368;&#2335; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</th>
                                                 <th id="thBefore" runat="server">बेलेंस पर्ची में कुल प्रदाय</th>
                                                <th>&#2352;&#2368;&#2354; /&#2352;&#2368;&#2350;/&#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</th>
                                                <th>&#2344;&#2375;&#2335; &#2357;&#2332;&#2344;/ &#2358;&#2368;&#2335; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</th>
                                                <th style="border-right: 1px solid black;">&#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</th>
                                                <th style="border-right: 1px solid black;">पेपर मिल</th>
                                               
                                            </tr>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <td style="width: 10%"><%# Container.ItemIndex+1 %>.</td>
                                            <td><%#Eval("PaperInformation")%></td>
                                            <td><%#Eval("Balance")%></td>
                                            <td id="tdBefore" runat="server"><%#Eval("Supply")%> </td>
                                           
                                            <td><%#Eval("NoOfReels")%></td>
                                            <td><%#Eval("NetWt")%></td>
                                            <td style="border-right: 1px solid black;">
                                               <%if (RadioButtonList1.SelectedValue=="2")
                                                  { %>
                                                <%#Eval("WareHouseName_V")%> - <%#Eval("RegistrationNo_V")%>
                                                <%} %>
                                            </td>
                                             <td style="border-right: 1px solid black;"><%#Eval("PaperVendorName_V")%></td>
                                          
                                        </tr>

                                    </ItemTemplate>

                                    <FooterTemplate>
                                        <tr>
                                            <td colspan="8" style="border-right: 1px solid black;">&#2313;&#2346;&#2352;&#2379;&#2325;&#2381;&#2340; &#2325;&#2366;&#2327;&#2332; &#2357;&#2366;&#2361;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                                                <asp:Label ID="lblTruck" runat="server"></asp:Label>
                                                &#2350;&#2375; &#2354;&#2379;&#2337; &#2325;&#2352;&#2366;&#2351;&#2366; &#2327;&#2351;&#2366; &#2404; 
                        
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="border-top: 1px solid black; font-weight: bold;">&#2348;&#2376;&#2354;&#2375;&#2344;&#2381;&#2360; &#2332;&#2366;&#2352;&#2368;&#2325;&#2352;&#2381;&#2340;&#2366;
                                                <br />
                                                &#2325;&#2375; &#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352;: 
                                                <asp:Label ID="lblBalanceParchiIssuePerson" runat="server" Style="font-weight: normal;"></asp:Label></td>
                                            <td colspan="3" style="border-top: 1px solid black; font-weight: bold">&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366;
                                                <br />
                                                &#2325;&#2375; &#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352;:
                                                <asp:Label ID="lblPraaptkarta" runat="server" Style="font-weight: normal;"></asp:Label></td>
                                            <td colspan="2" style="border-right: 1px solid black; border-top: 1px solid black; font-weight: bold">&#2346;&#2381;&#2352;&#2342;&#2366;&#2351;&#2325;&#2352;&#2381;&#2340;&#2366;
                                                <br />
                                                &#2325;&#2375; &#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352;:
                                                <asp:Label ID="lblPradaykarta" runat="server" Style="font-weight: normal;"></asp:Label></td>
                                        </tr>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>

                                

                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </center>
    </div>





    <script type="text/javascript">

        function PrintPreview() {
            var toPrint = document.getElementById('pntDiv');
            var popupWin = window.open('', '_blank', 'width=800,height=400,location=no,left=200px');
            popupWin.document.open();
            popupWin.document.write('<html><title>::Print Preview::</title><link rel="stylesheet" type="text/css" href="../css/printrcpt.css" media="screen"/></head><body">')
            popupWin.document.write(toPrint.innerHTML);
            popupWin.document.write('</html>');
            popupWin.document.close();
            return false;
        }

        function PrintPanel() {
            var panel = document.getElementById("<%=Panel1.ClientID %>");
         var printWindow = window.open('', '', 'height=400,width=900');
         printWindow.document.write('<html><head><title></title><link href="../css/printrcpt.css" rel="stylesheet" />');
         printWindow.document.write('</head><body >');
         printWindow.document.write(panel.innerHTML);
         printWindow.document.write('</body></html>');
         printWindow.document.close();
         setTimeout(function () {
             printWindow.print();
         }, 500);
         return false;
     }
    </script>
</asp:Content>

