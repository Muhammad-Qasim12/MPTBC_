<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true"
    CodeFile="ViewPaperVendorRFID.aspx.cs" Inherits="ViewPaperVendorRFID" Title="पेपर मिल को असाइन आर.एफ.आई.डी. नंबर / Assign RFID No. to Paper Mill"
    EnableEventValidation="false" %>

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
    <div class="box">
        <div class="card-header">
            <h2>
                <span>पेपर मिल को असाइन आर.एफ.आई.डी. नंबर  / Assign RFID No. to Paper Mill
                </span>
            </h2>
        </div>
        <div class="table-responsive">
            <table width="100%">
                <tr>
                    <td colspan="4" style="height: 10px;"></td>
                </tr>
                <tr>
                    <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                        <br />
                        Academic Year
                    </td>
                    <td>
                        <asp:Label ID="lblAcYear" runat="server" Visible="false"></asp:Label>
                        <asp:DropDownList runat="server" ID="DdlACYear" Width="262px"
                            CssClass="txtbox reqirerd">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%--Select Vendor (--%>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;<br />
                        Name Of Paper Mill
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlVendor" Width="262px" OnInit="ddlVendor_Init" AutoPostBack="true"
                            CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;"></td>
                </tr>
                <tr id="tdPrintContent" runat="server" visible="false">
                    <td>
                        <a href="#" class="btn" style="color: White;" onclick="return PrintPanel();">Print</a>
                    </td>
                    <td>
                        <asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" CssClass="btn" OnClick="btnExport_Click" />
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Panel ID="Panel1" runat="server" Width="100%">
                            <div id="ExportDiv" runat="server">
                                <div style="width: 900px;">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" PageSize="50"
                                        Width="100%" EmptyDataText="Record Not Found." AllowPaging="True" CssClass="tab" OnPageIndexChanging="GridView1_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1 %>.
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Year">
                                                <ItemTemplate>
                                                    <%#Eval("AcYear")%>
                                                    <asp:HiddenField ID="hdPaperVendor" runat="server" Value='<%#Eval("PaperVendorTrId_I")%>' />
                                                    <asp:HiddenField ID="hdRFIDNo" runat="server" Value='<%#Eval("RFIDNo")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="RFID No.">
                                                <ItemTemplate>
                                                    <%#Eval("RFID_Serial")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Challan No.">
                                                <ItemTemplate>
                                                    <%#Eval("ChallanNo")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Roll No.">
                                                <ItemTemplate>
                                                    <%#Eval("RollNo")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
