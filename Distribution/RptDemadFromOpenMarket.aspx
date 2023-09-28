<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RptDemadFromOpenMarket.aspx.cs" EnableEventValidation="false" Inherits="Distrubution_RptDemadFromOpenMarket" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        function CheckAll(rb) {
            var gv = document.getElementById("<%= ddlClass.ClientID  %>");

            var rbs = gv.getElementsByTagName("input");

            var row = rb.parentNode.parentNode;

            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "checkbox") {
                    rbs[i].checked = document.getElementById('chkSelect').checked;
                }
            }
            if (document.getElementById('chkSelect').checked == true) {
                document.getElementById('Name').innerHTML = "&#2360;&#2349;&#2368; &#2361;&#2335;&#2366;&#2351;&#2375;";
            }
            else {
                document.getElementById('Name').innerHTML = "&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375;";
            }
            // alert(document.getElementById('Name').innerHTML);
        }

    </script>
    <%--<asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                <ProgressTemplate>
                    <div class="fade">
                    </div>
                    <div class="progress">
                        <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>
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
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&#2337;&#2367;&#2346;&#2379;&#2357;&#2366;&#2352; &#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2350;&#2375;&#2306; &#2357;&#2367;&#2325;&#2381;&#2352;&#2351; &#2361;&#2375;&#2340;&#2369; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; 
                    / Depot wise Textbooks Demand For Open Market Sell
                </span></h2>
        </div>
        <div class="portlet-content">
            <asp:Panel class="response-msg inf ui-corner-all" runat="server" ID="mainDiv" Style="display: block; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg"
                    Text="&#2325;&#2371;&#2346;&#2351;&#2366; &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2342;&#2375;&#2326;&#2344;&#2375; &#2325;&#2375; &#2354;&#2367;&#2319; &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;, &#2337;&#2367;&#2346;&#2379; , &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; &#2340;&#2341;&#2366; &#2325;&#2325;&#2381;&#2359;&#2366; &#2330;&#2369;&#2344;&#2375; / Please select Academic Year , Depot , Medium and Class to view demand"
                    class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <div class="table-responsive">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 185px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSessionYear" runat="server" CssClass="txtbox reqirerd">
                            </asp:DropDownList>
                        </td>
                        <td>&#2337;&#2367;&#2346;&#2379; &#2330;&#2369;&#2344;&#2375; / Depot:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDepoMaster" runat="server" CssClass="txtbox " OnInit="ddlDepoMaster_Init"
                                Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; &#2330;&#2369;&#2344;&#2375; / Medium :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMedum" runat="server" CssClass="txtbox reqirerd" OnInit="ddlMedum_Init"
                                Width="150">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table>
                                <tr>
                                    <td>&#2325;&#2325;&#2381;&#2359;&#2366; / Class:
                                    </td>
                                    <td style="border: 1px solid  lightgrey">

                                        <label id="Name">&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; / Select All </label>
                                        <input type="checkbox" id="chkSelect" value="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; " name="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; " onclick="CheckAll(this);" />
                                        <%-- <asp:CheckBox ID="chkSelect1" runat="server"   Text="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; "  onclick="CheckAll(this);" TextAlign="Left"/>--%>
                                        <asp:CheckBoxList ID="ddlClass" OnInit="ddlClass_Init" RepeatDirection="Horizontal" CssClass="reqirerd" RepeatColumns="8" TextAlign="Left" runat="server">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>

                            </table>
                        </td>
                        <td style="font-size: medium;">

                            <asp:Button Text="View / &#2342;&#2375;&#2326;&#2375;&#2306; " ID="BtnView" runat="server" CssClass="btn"  OnClick="ddlClass_SelectedIndexChanged" />


                        </td>
                    </tr>
                    <tr>

                        <td><a href="#" class="btn" style="color: White;" onclick="return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;</a></td>
                        <td>
                            <asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" CssClass="btn" OnClick="btnExport_Click" /></td>
                        <td></td>
                        <td style="font-size: medium;"></td>
                    </tr>

                    <tr id="tdPrintContent" runat="server" visible="false">
                        <td colspan="6" style="text-align: center">
                            <asp:Panel ID="Panel1" runat="server" Width="100%">
                                <div id="ExportDiv" runat="server">

                                    <div style="padding: 10px;">

                                        <table width="100%">
                                            <tr>
                                                <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">" &#2357;&#2367;&#2340;&#2352;&#2339; (&#2309;) &#2358;&#2366;&#2326;&#2366; "
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">&#2337;&#2367;&#2346;&#2379;&#2357;&#2366;&#2352; &#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2350;&#2375;&#2306; &#2357;&#2367;&#2325;&#2381;&#2352;&#2351; &#2361;&#2375;&#2340;&#2369; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="25%;">
                                                    <div style="float: right; padding-right: 20px;">
                                                        &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; :<asp:Label ID="lblYear" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td colspan="2" style="font-size: 16px; font-weight: 200; text-align: center; width: 50%;"></td>
                                                <td style="font-size: 16px; font-weight: 200; text-align: center; width: 25%;">
                                                    <div style="float: right; padding-right: 20px;">
                                                        <asp:Label ID="lblDate" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="font-size: 16px; font-weight: bold; text-align: center;">
                                                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                    <asp:GridView ID="GrdBooksMaster" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                        CssClass="tab" EmptyDataText="Record Not Found." Width="100%" ShowFooter="true" OnRowDataBound="GrdBooksMaster_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText=" " HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 70px;">&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                                                                <br>
                                                                                S.No.
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>1
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex+1 %>.
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 70px;">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; 
                                                                <br>
                                                                                Book Title
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>2
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#Eval("TitleHindi_V")%>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    Total :
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText=" " HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 70px;">&#2346;&#2367;&#2331;&#2354;&#2375; &#2360;&#2340;&#2381;&#2352; &#2350;&#2375;&#2306; &#2357;&#2367;&#2325;&#2381;&#2352;&#2351; &#2325;&#2368; &#2327;&#2312; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                                <br>
                                                                                No Of Books Sold In Last Session
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>3
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLastYearSaleBook" runat="server" Text='<%#Eval("LastYearSale") %>'></asp:Label>

                                                                </ItemTemplate>
                                                                <FooterTemplate>

                                                                    <asp:Label ID="lblFLastYearSaleBook" runat="server"></asp:Label>

                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText=" " HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 70px;">&#2310;&#2327;&#2366;&#2350;&#2368; &#2360;&#2340;&#2381;&#2352; &#2361;&#2375;&#2340;&#2369; &#2310;&#2306;&#2325;&#2354;&#2367;&#2340; &#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; 
                                                                <br>
                                                                                Estimated Demand For Upcommimg Session
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>4
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCurntYearOpenBook" runat="server" Text='<%#Eval("CurntYarNeed") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblFCurntYearOpenBook" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 70px;">&#2357;&#2352;&#2381;&#2340;&#2350;&#2366;&#2344; &#2360;&#2340;&#2381;&#2352; &#2350;&#2375;&#2306; &#2357;&#2367;&#2325;&#2381;&#2352;&#2368; &#2346;&#2358;&#2381;&#2330;&#2366;&#2340; &#2348;&#2330;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2360;&#2306;&#2349;&#2366;&#2357;&#2367;&#2340; &#2360;&#2381;&#2335;&#2377;&#2325; 
                                                                             <br>
                                                                                Possible Stock In Current Session After Sales
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>5
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblOpenTentetiveStock" runat="server" Text='<%#Eval("OpnMrketStk") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>

                                                                    <asp:Label ID="lblFOpenTentetiveStock" runat="server" Text='<%#Eval("OpnMrketStk") %>'></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 70px;">&#2310;&#2327;&#2366;&#2350;&#2368; &#2360;&#2340;&#2381;&#2352; &#2361;&#2375;&#2340;&#2369; &#2358;&#2369;&#2342;&#2381;&#2343; &#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; 
                                                                <br>
                                                                                Net Demand For Upcomming Session
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>6
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNetDemand" runat="server" Text='<%#Eval("NetDemand") %>'></asp:Label>

                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblFNetDemand" runat="server"></asp:Label>

                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 70px;">&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325;
                                                                <br>
                                                                                Remark 
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>7
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#Eval("Remark_v")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
