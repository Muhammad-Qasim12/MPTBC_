<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="Rpt_DIB008_BillPayment.aspx.cs" Inherits="DistributionB_DIB_Reports_Rpt_DIB005_BillProcess" %>

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
        बिल प्राप्त राशि का विवरण / Bill Received Payment Information
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
                        <td>शिक्षा सत्र /
                            <br />
                            Academic Year :</td>
                        <td>
                            <asp:DropDownList ID="ddlAcademicYear" CssClass="txtbox" runat="server"></asp:DropDownList></td>
                        <td>मांगकर्ता विभाग का नाम /
                            <br />
                            Demand Receive from Department :</td>
                        <td>
                            <asp:DropDownList ID="ddlDepartmentName" CssClass="txtbox" runat="server"></asp:DropDownList></td>
                        <td>अन्य पाठ्यसामाग्री का नाम /
                            <br />
                            Other then TextBook Item :</td>
                        <td>
                            <asp:DropDownList ID="ddlTitle" CssClass="txtbox" runat="server"></asp:DropDownList></td>
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
                                                                <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">बिल प्राप्त राशि का विवरण / Bill Received Payment Information
                                                                <hr />
                                                                </td>

                                                            </tr>
                                                            <tr>

                                                                <td colspan="2" style="font-size: 16px; font-weight: 200; text-align: left;">बिल प्राप्त राशि का विवरण दिनांक से :
                                                                    <asp:Label ID="lblFromDate" runat="server" Text="-"></asp:Label>
                                                                </td>
                                                                <td colspan="2" style="font-size: 16px; font-weight: 200; text-align: right;">बिल प्राप्त राशि का विवरण दिनांक तक :
                                                                    <asp:Label ID="lblToDate" runat="server" Text="-"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>

                                                                <td colspan="2" style="font-size: 16px; font-weight: 200; text-align: left;">चयनित शिक्षा सत्र :
                                                                    <asp:Label ID="lblAcademicYrSelected" runat="server" Text="-"></asp:Label>
                                                                    &nbsp; मांगकर्ता विभाग का नाम :
                                                                      <asp:Label ID="lblDepartment" runat="server" Text="-"></asp:Label>
                                                                </td>
                                                                <td colspan="2" style="font-size: 16px; font-weight: 200; text-align: right;">अन्य पाठ्यसामाग्री का नाम :
                                                                      <asp:Label ID="lblTitle" runat="server" Text="-"></asp:Label>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                                    <asp:GridView ID="GrdLetterInfo" runat="server" OnPageIndexChanging="GrdViewPrinterProof_PageIndexChanging" CssClass="tab"
                                                                        AutoGenerateColumns="False" OnRowDataBound="GrdLetterInfo_RowDataBound" EmptyDataText="Record Not Found.">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="क्रमांक / S.No." >
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex+1 %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="AcYear" ReadOnly="true" HeaderText=" शिक्षा सत्र / Academic Year" />
                                                                            <asp:BoundField DataField="Title" ReadOnly="true" HeaderText=" &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;/Title" />
                                                                            <asp:TemplateField HeaderText="बिल क्रमांक एवं दिनांक /Bill No & Date ">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblgdBillNo"  runat="server" Text='<%# Eval("LetterNo_V") %>'></asp:Label>/
                                                                                    <asp:Label ID="lblgdBillDate"  runat="server" Text='<%# Convert.ToDateTime(Eval("LetterDate_D").ToString()).ToString("dd.MM.yyyy") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:BoundField DataField="DepartmentName_V" ReadOnly="true" HeaderText="मांगकर्ता विभाग का नाम / Demand Receive from Department " />
                                                                            <asp:BoundField DataField="NetAmount_I" DataFormatString="{0:N}" ReadOnly="true" HeaderText="कुल देयक राशि (रुपए) / Net Bill Amount(Rs.)" />                                                                            
                                                                            <asp:BoundField DataField="PaidAmount_I" DataFormatString="{0:N}" ReadOnly="true" HeaderText="कुल प्राप्त राशि (रुपए) / Total Payment Recieved (Rs.)" />
                                                                            <asp:BoundField DataField="TdsAmount_I"  DataFormatString="{0:N}" ReadOnly="true" HeaderText="कुल TDS (रुपए) / Total TDS (Rs.)" />                                                                      
                                                                            <asp:BoundField DataField="PayDetail" ReadOnly="true" HeaderText="भुगतान प्राप्ति का विवरण / Receive Payment Details" />

                                                                      
                                                                        </Columns>
                                                                        <PagerStyle CssClass="Gvpaging" />
                                                                        <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                                    </asp:GridView>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">कुल देयक राशि (रुपए) / Total Bill Amount(Rs.) : 
                                                                    <asp:Label ID="lblTotalBillAmount" runat="server" Text="0"></asp:Label>
                                                                </td>
                                                                <td colspan="2"> कुल प्राप्त राशि / Total Received  Amount(Rs.) :
                                                                    <asp:Label ID="lblTotalReceivedAmount" runat="server" Text="0"></asp:Label>
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
