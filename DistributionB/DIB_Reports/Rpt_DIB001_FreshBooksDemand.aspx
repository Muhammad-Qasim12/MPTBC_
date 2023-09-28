<%@ Page Title="रा०शि०के से नि:शुल्क पुस्तकों की मांग की स्थिति" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="Rpt_DIB001_FreshBooksDemand.aspx.cs" EnableEventValidation="false" 
    Inherits="DistributionB_DIB_Reports_Rpt_DIB001_FreshBooksDemand" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        रा०शि०के से नि:शुल्क पुस्तकों की मांग / Free Books Demand From RSK
    </div>
    <div class="portlet-content">
        <div class="box table-responsive">
            <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>दिनांक से
                            <br />
                            From Date
                        </td>
                        <td>
                            <asp:TextBox ID="txtFromDate" MaxLength="12" CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="ccextendtxtLetterDate" TargetControlID="txtFromDate"
                                Format="dd/MM/yyyy" runat="server">
                            </cc1:CalendarExtender>
                            <cc1:MaskedEditExtender ID="meeLetterDate" MaskType="Date" TargetControlID="txtFromDate"
                                Mask="99/99/9999" runat="server">
                            </cc1:MaskedEditExtender>
                        </td>
                        <td>दिनांक तक
                            <br />
                            To Date
                        </td>
                        <td>
                            <asp:TextBox ID="txtToDate" MaxLength="12" CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="txtToDate"
                                Format="dd/MM/yyyy" runat="server">
                            </cc1:CalendarExtender>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" MaskType="Date" TargetControlID="txtToDate"
                                Mask="99/99/9999" runat="server">
                            </cc1:MaskedEditExtender>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                OnClientClick="return ValidateAllTextForm1();" OnClick="btnSearch_Click" /></td>
                        <td></td>
                        <td></td>
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
                                                                    <asp:Label ID="lblAcademicYear" runat="server" Text="-"></asp:Label>
                                                                    <hr />
                                                                </td>
                                                                <td colspan="2" style="font-size: 16px; font-weight: 200; text-align: right;">दिनांक:
                                                                    <asp:Label ID="lblDate" runat="server" Text="-"></asp:Label>
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">रा०शि०के से नि:शुल्क पुस्तकों की मांग / Free Books Demand From RSK
                                                                <hr />
                                                                </td>

                                                            </tr>
                                                            <tr>

                                                                <td colspan="2" style="font-size: 16px; font-weight: 200; text-align: left;">मांग का विवरण दिनांक से
                                                                    <asp:Label ID="lblFromDate" runat="server" Text="-"></asp:Label>
                                                                </td>
                                                                <td colspan="2" style="font-size: 16px; font-weight: 200; text-align: right;">विवरण दिनांक तक
                                                                    <asp:Label ID="lblToDate" runat="server" Text="-"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                                    <asp:GridView ID="GrdLetterInfo" runat="server" OnPageIndexChanging="GrdViewPrinterProof_PageIndexChanging"
                                                                        AutoGenerateColumns="False" OnRowDataBound="GrdLetterInfo_RowDataBound" EmptyDataText="Record Not Found.">
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <table width="100%" class="tab01">
                                                                                        <tr>
                                                                                            <th>क्रमांक /<br />
                                                                                                S.No. : <%# Container.DataItemIndex+1 %></th>
                                                                                            <th></th>
                                                                                            <th>पत्र / नोटशीट क्र. /<br />
                                                                                                Letter / Notesheet No. :
                                                                                                <asp:Label ID="lblLetterNo_V" runat="server" Text='<%#Eval("LetterNo_V") %>'></asp:Label>
                                                                                            </th>
                                                                                            <th></th>
                                                                                            <th>पत्र  / नोटशीट दिनांक /<br />
                                                                                                Letter / Notesheet Date :
                                                                                                 <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("LetterDate_D").ToString()).ToString("dd.MM.yyyy") %>'></asp:Label>
                                                                                            </th>
                                                                                            <th>

                                                                                                <th>प्रदाय का स्थान /<br />
                                                                                                    Supply From : 
                                                                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("SupplyFrom_V") %>'></asp:Label>
                                                                                                    <asp:Label ID="lblFreeBooksDistributionID_I" runat="server" Text='<%#Eval("FreeBooksDistributionID_I") %>' Visible="false"></asp:Label>
                                                                                                </th>
                                                                                                <th></th>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="8">
                                                                                                <asp:GridView ID="grdSelectedTitle" runat="server" AutoGenerateColumns="False" CssClass="tab"
                                                                                                    AllowPaging="false" EmptyDataText="Record Not Found.">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField HeaderText="क्रमांक">
                                                                                                            <ItemTemplate>
                                                                                                                <%# Container.DataItemIndex+1 %>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:BoundField DataField="Class" ReadOnly="true" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366;" />
                                                                                                        <asp:BoundField DataField="Medium" ReadOnly="true" HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;" />
                                                                                                        <asp:BoundField DataField="Title" ReadOnly="true" HeaderText=" &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                                                                                                        <asp:BoundField DataField="Rate" ReadOnly="true" HeaderText=" &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2350;&#2370;&#2354;&#2381;&#2351;" />
                                                                                                        <asp:BoundField DataField="TotalBooks" ReadOnly="true" HeaderText="&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" />
                                                                                                        <asp:BoundField DataField="TotalAmount" DataFormatString="{0:N}" ReadOnly="true"
                                                                                                            HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &nbsp;&#2325;&#2366; &#2350;&#2370;&#2354;&#2381;&#2351; (रुपये)" />
                                                                                                        <asp:BoundField DataField="Discount" DataFormatString="{0:N}" ReadOnly="true" HeaderText="&#2331;&#2370;&#2335; (रुपये)" />
                                                                                                        <asp:BoundField DataField="NetAmount" DataFormatString="{0:N}" ReadOnly="true" HeaderText=" &#2358;&#2369;&#2342;&#2381;&#2343; &#2350;&#2370;&#2354;&#2381;&#2351; (रुपये)" />
                                                                                                    </Columns>
                                                                                                    <PagerStyle CssClass="Gvpaging" />
                                                                                                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                                                                </asp:GridView>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <th>शुद्ध मूल्य (रुपए) /Net Amount(Rs.)</th>
                                                                                            <th>
                                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Convert.ToDecimal(Eval("NetAmount_I").ToString()).ToString("N") %>'></asp:Label></th>
                                                                                            <th colspan="6"></th>
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
    </div>
</asp:Content>
