<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Rpt_PaperCalReport.aspx.cs"
    Inherits="Printing_Rpt_PaperCalReport" EnableEventValidation="false" %>

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
        Paper Calculation
    </div>
    <div class="portlet-content">
        <div class="box table-responsive">
            <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
                <table width="100%" cellpadding="0" cellspacing="0" class="tab01">
                    <tr>
                        <td>शैक्षणिक सत्र / Academic Year
                            <asp:DropDownList ID="ddlAcademicYr" CssClass="txtbox" runat="server">
                                <asp:ListItem Value="0" Text="Select.."></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>प्रिंटर का नाम / Name of the Printer
                            <asp:DropDownList ID="ddlPrinterName" runat="server" CssClass="txtbox reqirerd">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="रिपोर्ट देखें" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
                <table width="100%" cellpadding="0" cellspacing="0">
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
                                                                <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">मध्यप्रदेश पाठ्यपुस्तक निगम                                                           
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">"पुस्तक भवन"
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">अरेरा हिल्स, भोपाल - 462011
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">दूरभाष - 0755-2550727, 2551294,2551565, फैक्स - 2551145, ई-मेल- info.mptbc@mp.gov.in वेबसाइट - mptbc.nic.in
                                                            <hr />
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td colspan="2" style="font-size: 16px; font-weight: 200; text-align: left;">शिक्षा सत्र :
                                                                     <asp:Label ID="lblAcYrInfo" runat="server" Text=""></asp:Label>
                                                                    <hr />
                                                                </td>
                                                                <td colspan="2" style="font-size: 16px; font-weight: 200; text-align: right;">दिनांक:
                                                                    <asp:Label ID="lblDate" runat="server" Text="-"></asp:Label>
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">Paper Calculation Information
                                                                <hr />
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                                    <asp:GridView ID="GrdTitle" runat="server" CssClass="tab" DataKeyNames="TitleID_I" PageSize="30" AutoGenerateColumns="False" OnPageIndexChanging="GrdTitle_PageIndexChanging"
                                                                        EmptyDataText="No Record Found..">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="क्रमांक <br/> S.No.">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex+1 %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="PrinterName" HeaderText="प्रिंटर का नाम / Printer Name" ReadOnly="true" />
                                                                            <asp:BoundField DataField="ClassTrno_I" HeaderText="कक्षा / Class" ReadOnly="true" />
                                                                            <asp:BoundField DataField="TitleHindi_V" HeaderText="शीर्षक का नाम / Title" ReadOnly="true" />
                                                                            <asp:BoundField DataField="VitranNoOfBooks" HeaderText="No.of Books" ReadOnly="true" />
                                                                            <asp:BoundField DataField="Pages_N" HeaderText="पृष्ठ संख्या / Total Pages" ReadOnly="true" />
                                                                            <asp:BoundField DataField="PaperRim" HeaderText="पेपर आवंटन / Paper Allotment (Rim)" ReadOnly="true" />
                                                                            <asp:BoundField DataField="AlltRim" HeaderText="प्रदाय की जा चुकी मात्रा (Rim)" ReadOnly="true" />
                                                                            <asp:BoundField DataField="TotalAlltRim" HeaderText="Remaining (Rim)" ReadOnly="true" />

                                                                            <asp:BoundField DataField="PaperTon" HeaderText="पेपर आवंटन / Paper Allotment (Tons)" ReadOnly="true" />
                                                                            <asp:BoundField DataField="AlltTon" HeaderText="प्रदाय की जा चुकी मात्रा (Tons)" ReadOnly="true" />
                                                                            <asp:BoundField DataField="TotalAlltTon" HeaderText="Remaining (Tons)" ReadOnly="true" />
                                                                        </Columns>
                                                                        <PagerStyle CssClass="Gvpaging" />
                                                                        <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                                    </asp:GridView>
                                                                </td>
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
                    <tr>
                        <td colspan="4" align="center" id="tdNORecord" runat="server" visible="false">No Record Found..
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <%-- <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span></span></h2>
        </div>
        <div style="padding: 0 10px;">
            <table class="tab01">
            </table>
            <table class="tab">
                <tr>
                    <th>
                      
                    </th>

                </tr>
            </table>
            <table>
                <tr>

                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnExport" runat="server" CssClass="btn" Text="रिपोर्ट Excel में भेजें/Export to Excel" OnClick="btnExport_Click" /></td>

                </tr>
            </table>
        </div>
    </div>--%>
</asp:Content>

