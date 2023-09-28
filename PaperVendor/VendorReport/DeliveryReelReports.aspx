<%@ Page Title="&#2337;&#2367;&#2354;&#2368;&#2357;&#2352;&#2368; &#2330;&#2366;&#2354;&#2366;&#2344; &#2350;&#2375;&#2306; &#2352;&#2368;&#2354; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / Reel Report in Delivery Challan " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DeliveryReelReports.aspx.cs" Inherits="Paper_PaperReport_WorkPlanReports" EnableEventValidation="false" %>

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
        &#2337;&#2367;&#2354;&#2368;&#2357;&#2352;&#2368; &#2330;&#2366;&#2354;&#2366;&#2344; &#2350;&#2375;&#2306; &#2352;&#2368;&#2354; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / Reel Report in Delivery Challan 
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
                            CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                     <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year
                            <asp:DropDownList ID="DdlACYear" runat="server" OnInit="DdlACYear_Init" CssClass="txtbox" AutoPostBack="true" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />
                        Challan No.
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlChallanNo" Width="250px" CssClass="txtbox reqirerd">
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
                                                            <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">&quot; &#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354;&quot;
                                                            </td>
                                                        </tr>
                                                          <tr>
                                                            <td colspan="4" style="font-size: 18px; font-weight: bold;text-align: center;">" &#2337;&#2367;&#2354;&#2368;&#2357;&#2352;&#2368; &#2330;&#2366;&#2354;&#2366;&#2344; &#2350;&#2375;&#2306; &#2352;&#2368;&#2354; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; "
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="25%;">
                                                                <div style="float: right; padding-right: 20px;">
                                                                    &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; :<asp:Label ID="lblYear" runat="server"></asp:Label>
                                                                </div>
                                                            </td>
                                                            <td colspan="2" style="font-size: 16px; font-weight: 200; text-align: center; width: 50%;"> 
                                                            </td>
                                                            <td style="font-size: 16px; font-weight: 200; text-align: center; width: 25%;">
                                                                <div style="float: right; padding-right: 20px;">
                                                                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="font-size: 16px;  text-align: center;">
                                                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                                    Width="100%" EmptyDataText="Record Not Found." OnRowDataBound="GridView1_RowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo ">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex+1 %>.
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;<br />
                                                                                            Name Of Paper Mill
                                                                                    <asp:Label ID="lblVouchar_Tr_Id" runat="server" Visible="false" Text='<%#Eval("ChallanNo") %>'></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <%#Eval("PaperVendorName_V")%>
                                                                                        </td>
                                                                                        <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                                                                                            <br />
                                                                                            Challan No./Date
                                                                                        </td>
                                                                                        <td>
                                                                                            <%#Eval("ChallanNo")%> / <%#Eval("ChallanDate")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                                                            <asp:GridView ID="GrdLabInspection" runat="server" AutoGenerateColumns="false" GridLines="None" AllowPaging="false" ShowFooter="true"
                                                                                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." OnRowDataBound="GrdLabInspection_RowDataBound">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo <br><br><br><br><br>1" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                                        <ItemTemplate>
                                                                                                            <%# Container.DataItemIndex+1 %>.
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br>Paper Type  <br><br><br>2" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                                        <ItemTemplate>
                                                                                                            <%#Eval("PaperType")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size   <br><br><br><br><br>3" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                                        <ItemTemplate>
                                                                                                            <%#Eval("CoverInformation")%>
                                                                                                        </ItemTemplate>
                                                                                                        <FooterTemplate>
                                                                                                            <b>Total :</b>
                                                                                                        </FooterTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="	&#2352;&#2379;&#2354; &#2344;&#2306;&#2348;&#2352; <br>Role No.    <br><br><br>4" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                                        <ItemTemplate>
                                                                                                            <%#Eval("RollNo")%>
                                                                                                        </ItemTemplate>
                                                                                                        
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2358;&#2368;&#2335; &#2346;&#2381;&#2352;&#2340;&#2367; &#2352;&#2368;&#2350;/&#2352;&#2368;&#2354; <br> Total Sheets Per Reem / Reel   <br><br><br><br>5" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblTotalSheets" runat="server" Text='<%#Eval("TotalSheets")%>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <FooterTemplate>
                                                                                                            <asp:Label ID="lblFTotalSheets" runat="server" Font-Bold="true"></asp:Label>
                                                                                                        </FooterTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; (K.G.)<br>Net Weight(K.G.)   <br><br><br><br>6" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">

                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt")%>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <FooterTemplate>
                                                                                                            <asp:Label ID="lblFNetWt" runat="server" Font-Bold="true"></asp:Label>
                                                                                                        </FooterTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (K.G.)<br>Gross Weight(K.G.)   <br><br><br><br>7" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">

                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt")%>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <FooterTemplate>
                                                                                                            <asp:Label ID="lblFGrossWt" runat="server"  Font-Bold="true"></asp:Label>
                                                                                                        </FooterTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                            </asp:GridView>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                    </Columns>
                                                                    <PagerStyle CssClass="Gvpaging" />
                                                                    <EmptyDataRowStyle CssClass="GvEmptyText" />
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
