<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="Rpt_DIB005_BillProcess.aspx.cs" Inherits="DistributionB_DIB_Reports_Rpt_DIB005_BillProcess" %>

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
        बिल प्रोसेस रिपोर्ट/Bill Process Report
    </div>
    <div class="portlet-content">
        <div class="box table-responsive">
            <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>दिनांक से
                            <br />
                            From Date :
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
                            To Date :
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
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>शिक्षा सत्र / <br /> Academic Year :</td>
                        <td>
                            <asp:DropDownList ID="ddlAcademicYear" CssClass="txtbox" runat="server"></asp:DropDownList></td>
                        <td>मांगकर्ता विभाग का नाम / <br /> Demand Receive from Department :</td>
                        <td> <asp:DropDownList ID="ddlDepartmentName" CssClass="txtbox" runat="server"></asp:DropDownList></td>
                        <td>अन्य पाठ्यसामाग्री का नाम / <br /> Other then TextBook Item :</td>
                        <td> <asp:DropDownList ID="ddlTitle" CssClass="txtbox" runat="server"></asp:DropDownList></td>
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
                        <td colspan="6" align="center" id="tdPrintContent" runat="server" visible="false">
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
                                                                <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">बिल प्रोसेस रिपोर्ट/Bill Process Report
                                                                <hr />
                                                                </td>

                                                            </tr>
                                                            <tr>

                                                                <td colspan="2" style="font-size: 16px; font-weight: 200; text-align: left;">बिल का विवरण दिनांक से
                                                                    <asp:Label ID="lblFromDate" runat="server" Text="-"></asp:Label>
                                                                </td>
                                                                <td colspan="2" style="font-size: 16px; font-weight: 200; text-align: right;">बिल का विवरण दिनांक तक
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
                                                                                            <th>बिल का प्रकार /
                                                                                                <br />
                                                                                                Type of Bill :
                                                                                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("BillType_V") %>'></asp:Label>
                                                                                            </th>
                                                                                            <th>बिल क्रमांक/<br />
                                                                                                Bill No :
                                                                                                <asp:Label ID="lblLetterNo_V" runat="server" Text='<%#Eval("LetterNo_V") %>'></asp:Label>
                                                                                            </th>
                                                                                            <th></th>
                                                                                            <th>बिल दिनांक / <br />Bill Date :
                                                                                                 <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("LetterDate_D").ToString()).ToString("dd.MM.yyyy") %>'></asp:Label>
                                                                                            </th>
                                                                                            <th>

                                                                                                <th>संस्था का नाम /<br />
                                                                                                    Bill to Department:                                                                                                 

                                                                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("DepartmentName_V") %>'></asp:Label>
                                                                                                    <asp:Label ID="lblProcessBillTrno_I" runat="server" Text='<%#Eval("ProcessBillTrno_I") %>' Visible="false"></asp:Label>
                                                                                                </th>
                                                                                                <th></th>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="8">

                                                                                                <asp:GridView ID="grdSelectedTitle" runat="server" AutoGenerateColumns="False" CssClass="tab" AllowPaging="True">
                                                                                                    <Columns>
                                                                                                        <asp:BoundField DataField="Title" ReadOnly="true" HeaderText=" &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;/Title" />
                                                                                                        <asp:BoundField DataField="SubTitle" ReadOnly="true" HeaderText="&#2313;&#2346; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;/Sub Title" />
                                                                                                        <asp:BoundField DataField="Rate" DataFormatString="{0:N}" ReadOnly="true" HeaderText=" &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2350;&#2370;&#2354;&#2381;&#2351;/Rate" />
                                                                                                        <asp:BoundField DataField="TotalBooks" ReadOnly="true" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/Total Items" />
                                                                                                        <asp:BoundField DataField="TotalAmount" DataFormatString="{0:N}" ReadOnly="true"
                                                                                                            HeaderText="कुल राशि (रुपए) / Net Amount(Rs.)" />
                                                                                                        <asp:BoundField DataField="DiscountPercent" DataFormatString="{0:N}" ReadOnly="true"
                                                                                                            HeaderText="&#2331;&#2370;&#2335; &#2325;&#2366; &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340;/Discount %" />
                                                                                                        <asp:BoundField DataField="Discount" DataFormatString="{0:N}" ReadOnly="true" HeaderText="&#2331;&#2370;&#2335;(रुपए)/Discount(Rs.)" />
                                                                                                        <asp:BoundField DataField="NetAmount" DataFormatString="{0:N}" ReadOnly="true" HeaderText=" &#2358;&#2369;&#2342;&#2381;&#2343; &#2352;&#2366;&#2358;&#2368;(रुपए)/Net Amount(Rs.)" />
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
                    <tr>
                        <td colspan="6" align="center" id="tdNoRecord" runat="server" visible="false">No Record Found.
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>


</asp:Content>
