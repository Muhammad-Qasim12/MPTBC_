<%@ Page Title="योजना वार शीर्षक की जानकारी/ Information Of Schemewise Title " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SchemeMappingReport.aspx.cs"
    EnableEventValidation="false" Inherits="Distribution_SchemeMappingReport" %>

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
      योजना वार शीर्षक की जानकारी/ Information Of Schemewise Title 
    </div>
    <div class="portlet-content">
        <div class="table-responsive">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>योजना का नाम
                        <br />
                        Scheme Name
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlScheme" Width="250px"
                            CssClass="txtbox reqirerd">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>शैक्षणिक सत्र / Academic Year</td>
                    <td>
                            <asp:DropDownList ID="ddlAcademicYr" CssClass="txtbox" runat="server">
                                <asp:ListItem Value="0" Text="Select.."></asp:ListItem>
                            </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                            OnClientClick="return ValidateAllTextForm();" OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center" id="tdPrintContent" runat="server" visible="false">
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
                        <div style="width: auto; height: auto;">
                            <center>
                                <div class="MT20">
                                    <asp:Panel ID="Panel1" runat="server" Width="100%">
                                        <div id="ExportDiv" runat="server">
                                            <div style="width: 900px;">
                                                <div style="padding: 10px;">
                                                    <table width="100%">
                                                        <tr>
                                                            <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">मध्य प्रदेश पाठ्यपुस्तक निगम
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">" वितरण शाखा "
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="25%;">
                                                                <div style="float: right; padding-right: 20px;">
                                                                    शैक्षणिक सत्र :<asp:Label ID="lblYear" runat="server"></asp:Label>
                                                                </div>
                                                            </td>
                                                            <td colspan="2" style="font-size: 25px; font-weight: 200; text-align: center; width: 50%;"> योजना वार शीर्षक की जानकारी
                                                            </td>
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
                                                            <td colspan="4" style="font-weight: 200; text-align: center;">
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                                    Width="100%" CssClass="tab" EmptyDataText="Record Not Found." AllowPaging="false">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo"  HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex+1 %>.
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="शीर्षक का नाम<br /> Title Name" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%#Eval("TitleHindi_V")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="कक्षा का नाम   <br /> Class Name" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate> 
                                                                                <%#Eval("Classdet_V")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:TemplateField HeaderText="योजना का नाम   <br /> Scheme Name" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate> 
                                                                                <%#Eval("Schemes")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
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


