<%@ Page Title="Paper Vendor" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false"
     CodeFile="PVDeliveryChallanDetail.aspx.cs" Inherits="PaperVendor_VendorReport_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <div class="portlet-header ui-widget-header">
        &#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2360;&#2375;&#2306;&#2335;&#2381;&#2352;&#2354; &#2337;&#2367;&#2346;&#2379; &#2325;&#2379; &#2337;&#2367;&#2360;&#2381;&#2346;&#2376;&#2330; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;  / Dispatch Information Of Paper Mill To Central Depot
    </div>
    <div class="portlet-content">
        <div class="table-responsive">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;<br />
                        Name Of Paper Mill
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlVendor" Width="250px" OnInit="ddlVendor_Init"
                            CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged" Enabled="False">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>शिक्षा सत्र / Academic Year
                            <asp:DropDownList ID="DdlACYear" runat="server" OnInit="DdlACYear_Init" CssClass="txtbox" AutoPostBack="true" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    <td>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />
                        L.O.I. No.
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlLOINo" Width="250px"  
                            CssClass="txtbox reqirerd">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                            OnClientClick="return ValidateAllTextForm();" OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="center" id="tdPrintContent" runat="server" visible="false">
                        <div style="width: 40px; color: White;">
                            <table>
                                <tr>
                                    <td>
                                        <a href="#" class="btn" style="color: White;" onclick="return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;</a>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" CssClass="btn" OnClick="btnExport_Click" />
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
                                                    <table width="100%">
                                                        <tr>
                                                            <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">&quot; &#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &quot;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="font-size: 16px; font-weight: bold; text-align: center;">&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2360;&#2375;&#2306;&#2335;&#2381;&#2352;&#2354; &#2337;&#2367;&#2346;&#2379; &#2325;&#2379; &#2337;&#2367;&#2360;&#2381;&#2346;&#2376;&#2330; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;
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
                                                            <td colspan="4" style="font-size: 16px; text-align: center;">
                                                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="font-size: 12px; text-align: right;">&#2351;&#2370;&#2344;&#2367;&#2335; &#2350;&#2375;&#2335;&#2381;&#2352;&#2367;&#2325; &#2335;&#2344; &#2350;&#2375;&#2306; / Unit in Matric Ton
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="tab  "
                                                                    Width="100%" PageSize="20" EmptyDataText="Record Not Found." OnPageIndexChanging="GridView1_PageIndexChanging">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo<br/><br/><br/><br/><br/>1" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex+1 %>.
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br/>Challan No.<br/><br/><br/>2" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%#Eval("ChallanNo")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br/>Challan Date<br/><br/><br/>3" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%#Eval("ChallanDate")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br>Paper Type<br/><br/><br/>4" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%#Eval("PaperType")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352; <br>Paper Size<br/><br/><br/><br/><br/>5" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%#Eval("CoverInformation")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="कुल आवंटित मात्रा<br>Total Allotted Quantity<br/>6" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%#Eval("ReqQty")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366;<br>Supply Quantity<br/><br/><br/>7" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%#Eval("VdrSendQty")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2352;&#2368;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;<br>No Of Reel<br/>8" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%#Eval("SndrReel")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; <br>Received Quantity<br/><br/> <br/><br/>9" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%#Eval("ReceivedQty")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2352;&#2368;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;<br>No Of Reel Received  <br/><br/>10" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%#Eval("NoOfReels")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2335;&#2368; &#2352;&#2368;&#2354; <br/><br/><br/><br/><br/><br/>11" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                
                                                                                <asp:Panel ID="pnlRemark" runat="server" Visible='<%#Eval("ReceivedQty").ToString().Equals("")?false:true%>'>
                                                                                &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2352;&#2368;&#2354;&#2379; &#2350;&#2375;&#2306; &#2325;&#2369;&#2354; 
                                                                                    <b style="font-weight: bold;">
                                                                                        <%#Eval("DefReel")%></b>
                                                                                &#2352;&#2368;&#2354; &#2325;&#2335;&#2368; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2361;&#2369;&#2312; &#2332;&#2367;&#2360;&#2350;&#2375;&#2306; &#2325;&#2369;&#2354;  <b style="font-weight: bold;">
                                                                                    <%#Eval("DefWt")%></b>
                                                                                &#2350;&#2368;. &#2335;&#2344; &#2341;&#2348;&#2381;&#2348;&#2366; &#2344;&#2367;&#2325;&#2354;&#2344;&#2375; &#2325;&#2368; &#2360;&#2306;&#2349;&#2366;&#2348;&#2344;&#2366; &#2361;&#2376; | 
                                                                               </asp:Panel>
                                                                            </ItemTemplate>

                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                      <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4"></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </center>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>

