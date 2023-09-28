<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="DefectiveReelStsReportsByweight.aspx.cs" Inherits="DefectiveReelStsReportsByweight"
    Title="बंडल / रील की जानकारी / Information Of Bundel / Reel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
        बंडल / रील की जानकारी / Information Of Bundel / Reel
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left">
                            <table>
                                <tr>
                                      <td> 
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                        <br />
                        Academic Year
                    </td>
                    <td>
                           <asp:DropDownList ID="ddlAcYear" runat="server" CssClass="txtbox" AutoPostBack="true" Width="200px"  >
                        </asp:DropDownList>
                    </td>
                                    <td>पेपर मिल का नाम<br />
                                        Name Of Paper Mill
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlVendor" Width="200px" OnInit="ddlVendor_Init"
                                            CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged">
                                            <asp:ListItem Text="All"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>नेट वजन (K.G.)  <br /> Net Weight(K.G.)
                                    </td>
                                    <td>
                                         <asp:TextBox ID="txtSearchWeight" runat="server" MaxLength="200" Width="200px" placeholder="नेट वजन (K.G.) खोजे / Search by Net Weight(K.G.)"></asp:TextBox>
                                     <asp:DropDownList runat="server" ID="ddlChallanNo" Width="200px"  
                                            CssClass="txtbox reqirerd" Visible="false">
                                            <asp:ListItem Text="All"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                      <td>प्रयुक्त / अप्रयुक्त<br />
                                        Used/Unused
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlUsed" Width="200px" 
                                            CssClass="txtbox reqirerd">
                                            <asp:ListItem Text="Select"></asp:ListItem>
                                            <asp:ListItem Text="Used"></asp:ListItem>
                                            <asp:ListItem Text="Unused"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                     <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                     <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Enabled="false" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                            OnClientClick="return ValidateAllTextForm();" OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="width: 40px; color: White;">
                                <table>
                                    <tr>
                                        <td>
                                            <a href="#" class="btn" style="color: White;" onclick="return PrintPanel();">प्रिंट</a>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" CssClass="btn" OnClick="btnExport_Click" />
                                        </td>

                                    </tr>
                                </table>
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:Panel ID="Panel1" runat="server" Width="100%">
                                <div id="ExportDiv" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">मध्य प्रदेश पाठ्यपुस्तक निगम
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">" केंद्रीय भण्डार "
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-size: 16px;font-weight: bold; text-align: center;"> 
                                                बंडल / रील की प्रदाय /अप्रदाय जानकारी 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%;">
                                                <div style="float: right; padding-right: 20px;">
                                                    शैक्षणिक सत्र :<asp:Label ID="lblYear" runat="server"></asp:Label>
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
                                            <td colspan="4" style="font-size: 12px; text-align: right;">यूनिट मेट्रिक टन में / Unit in Matric Ton
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                         <%--       <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    Width="100%" EmptyDataText="Record Not Found."
                                                    AllowPaging="True" OnPageIndexChanging="GrdLOI_PageIndexChanging"
                                                    OnRowDataBound="GrdLOI_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex+1 %>.
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>

                                                            <ItemTemplate>
                                                                <asp:Label ID="lblChallanNo" runat="server" Text='<%#Eval("ChallanNo")%>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lblPaperVendorTrId_I" runat="server" Text='<%#Eval("PaperVendorTrId_I")%>' Visible="false"></asp:Label>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td width="25%" style="padding-bottom: 10px;">&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350; Name Of Paper Mill </td>
                                                                        <td width="25%" style="padding-bottom: 10px; font-weight: bold;"><%#Eval("PaperVendorName_V")%></td>
                                                                        <td width="25%" style="padding-bottom: 10px;">&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;  Challan No. </td>
                                                                        <td width="25%" style="padding-bottom: 10px; font-weight: bold;"><%#Eval("ChallanNo")%></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="25%">&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;  Paper Type </td>
                                                                        <td width="25%" style="font-weight: bold;"><%#Eval("PaperType")%></td>
                                                                        <td width="25%">&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352; Paper Size</td>
                                                                        <td width="25%" style="font-weight: bold;"><%#Eval("CoverInformation")%></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" rowspan="2">--%>
                                                                            <asp:GridView ID="GvReelDetails" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." OnRowDataBound="GvReelDetails_RowDataBound"
                                                                                AllowPaging="false" ShowFooter="true">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                        <ItemTemplate>
                                                                                            <%# Container.DataItemIndex+1 %>.
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="&#2352;&#2379;&#2354; &#2344;&#2306;&#2348;&#2352;<br> Role No." HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                       <asp:TemplateField HeaderText="चालान क्रमांक <br> Challan No." HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblChallanNo" runat="server" Text='<%#Eval("ChallanNo")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    
                                                                                    <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2358;&#2368;&#2335; &#2346;&#2381;&#2352;&#2340;&#2367; &#2352;&#2368;&#2350;/&#2352;&#2368;&#2354; <br> Total Sheets Per Reem / Reel" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblTotalSheets" runat="server" Text='<%#Eval("TotalSheets")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            कुल / Total:
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; (K.G.) <br>Net Weight(K.G.)" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Label ID="lblTotNetWt" runat="server"></asp:Label>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (K.G.)<br> Gross Weight(K.G.)" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Label ID="lblTotGrossWt" runat="server"></asp:Label>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="बंडल / रील का स्तर <br> Status Of Bundel / Reel" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblTotStock" runat="server" Text='<%#Eval("TotStock") %>'></asp:Label>
                                                                                        </ItemTemplate>

                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>

                                                          <%--  </ItemTemplate>
                                                        </asp:TemplateField>



                                                    </Columns>
                                                    <PagerStyle CssClass="Gvpaging" />
                                                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                </asp:GridView>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>

                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
