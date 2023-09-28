<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPT_VoucherDetails_MilWise.aspx.cs" Inherits="Paper_PaperReport_RPT_VoucherDetails_MilWise" %>

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
         }

    </script>
    <div class="portlet-header ui-widget-header">&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; &#2350;&#2375;&#2306; &#2346;&#2375;&#2350;&#2375;&#2306;&#2335; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; </div>
    <table class="table">
        <tr>
            <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;</td>
            <td>
                <asp:DropDownList ID="ddlAcYear" placeholder="Select" runat="server" OnInit="ddlAcYear_Init"></asp:DropDownList></td>
            <td>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354;</td>
            <td>
                <asp:DropDownList ID="ddlVendorName" placeholder="Select" runat="server" OnInit="ddlVendorName_Init"></asp:DropDownList></td>
            <td>&#2346;&#2375;&#2350;&#2375;&#2306;&#2335; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;</td>
            <td>
                <asp:DropDownList ID="ddlPaymentType" placeholder="Select" AutoPostBack="true" runat="server" OnInit="ddlPaymentType_Init" OnSelectedIndexChanged="ddlPaymentType_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Style="padding: 7px 5px 5px 7px !Important;" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                    OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>

    <asp:Panel ID="Panel1" Visible="false" runat="server" Style="padding: 10px;">
        <asp:Button ID="btnExport" runat="server" CssClass="btn" Style="padding: 7px 5px 5px 7px !Important;" Text="Export to Excel" OnClick="btnExport_Click" />
        <asp:Button ID="btnPrint" runat="server" CssClass="btn" Style="padding: 7px 5px 5px 7px !Important;" Text="Print" OnClientClick="return PrintPanel();" />

        <div id="ExportDiv" runat="server">
            <div style="padding: 10px;">
                <table width="100%">
                    <tr>
                        <td style="font-size: 18px; font-weight: bold; text-align: center;">&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;
                        </td>
                    </tr>
                    <tr>
                        <td style="font-size: 16px; font-weight: 200; text-align: center;">" &#2346;&#2375;&#2346;&#2352; &#2357;&#2367;&#2349;&#2366;&#2327; "
                        </td>
                    </tr>
                    <tr>
                        <td style="font-size: 18px; font-weight: bold; text-align: center;">&#2357;&#2366;&#2313;&#2330;&#2352; &#2325;&#2367;
                            <asp:Label ID="lblPercent" runat="server" Text=""></asp:Label>
                            &nbsp;&#2346;&#2375;&#2350;&#2375;&#2306;&#2335; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;:
                                            <asp:Label ID="lblYr" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblDate" runat="server" Style="float: right" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="GV_RPT_VOUCHER" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." PageSize="20"
                    AllowPaging="True" OnPageIndexChanging="GV_RPT_VOUCHER_PageIndexChanging"
                    ShowFooter="true" FooterStyle-BackColor="WhiteSmoke" OnRowDataBound="GV_RPT_VOUCHER_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&#2357;&#2366;&#2313;&#2330;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br/>Voucher No.">
                            <ItemTemplate>
                                <%# Eval("VouCHARNo") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&#2357;&#2366;&#2313;&#2330;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; <br/> Voucher Date">
                            <ItemTemplate>
                                <%# Eval("VouCHARDate") %>
                            </ItemTemplate>
                            <FooterTemplate>&#2325;&#2369;&#2354;: </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="&#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;) <br/> Amount">
                            <ItemTemplate >
                                <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>' Font-Bold="true"></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblF100Amount" runat="server" Font-Bold="true"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&#2357;&#2332;&#2344;(&#2350;&#2375;. &#2335;&#2344; &#2350;&#2375;&#2306;) <br/> Weight(Metric Ton)">
                            <ItemTemplate>
                                <asp:Label ID="lblWeight" runat="server" Text='<%# Eval("NetWt") %>' Font-Bold="true"></asp:Label>

                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblFWeight" runat="server" Font-Bold="true" Visible="true"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

