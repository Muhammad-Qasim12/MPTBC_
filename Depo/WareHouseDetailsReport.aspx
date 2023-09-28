<%@ Page Title="म.प्र पाठ्यपुस्तक निगम / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WareHouseDetailsReport.aspx.cs" Inherits="Depo_WareHouseDetailsReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>&#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Godown Details
            </h2>

        </div>
        <div style="padding: 0 10px;">
             <asp:Button ID="btnExport" runat="server" CssClass="btn_gry"
                OnClick="btnExport_Click" Text="Export to Excel" />
            <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry"
                OnClientClick="return PrintPanel();" Text="Print" />
            <div id="ExportDiv" runat="server">
                <table width="100%">

                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <center>
                                <b style="font-size: 12pt;">
                                    मध्य प्रदेश पाठ्यपुस्तक निगम, संभागीय भंडार
                                    <br /><br />
                                    डिपो -&nbsp;&nbsp;<asp:Label ID="lblDepoName" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    गोदाम की जानकारी / Godown Details
                                </b>
                                <br />
                                <br />
                                शिक्षा सत्र :&nbsp;&nbsp;<asp:Label ID="lblFYear" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;दिनांक :&nbsp;&nbsp;<asp:Label ID="lblCurrentDate" runat="server"></asp:Label>
                            </center>
                            <br /><br />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                CssClass="tab">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="District_Name_Hindi_V" HeaderText="&#2332;&#2367;&#2354;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; / District Name" />
                                    <asp:BoundField DataField="WarehouseType" HeaderText="&#2360;&#2381;&#2341;&#2366;&#2351;&#2368; /&#2309;&#2360;&#2381;&#2341;&#2366;&#2351;&#2368; / Pemanent / Temporary" />
                                    <asp:TemplateField HeaderText="&#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350; / Godown Name">
                                        <ItemTemplate>
                                            <a href='ShowWarehouseDetails.aspx?ID=<%# api.Encrypt(Eval("WareHouseID_I").ToString ()) %>'
                                                target="_blank"><%#Eval("WareHouseName_V")%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="WareHouseAddress_V"
                                        HeaderText="&#2346;&#2340;&#2366; / Address " />
                                    <asp:BoundField HeaderText="&#2360;&#2350;&#2381;&#2348;&#2306;&#2343;&#2367;&#2340; &#2357;&#2381;&#2351;&#2325;&#2381;&#2340;&#2367;  &#2325;&#2366; &#2344;&#2366;&#2350; / Related Person Name"
                                        DataField="WareHouseOwnerName_V" />
                                    <asp:BoundField DataField="MobileNo_N" HeaderText="&#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; / Mobile No." />
                                    <asp:BoundField DataField="DDDate"
                                        HeaderText="&#2310;&#2343;&#2367;&#2346;&#2340;&#2381;&#2351; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Date" />
                                    <asp:BoundField DataField="CarpateArea_V" HeaderText="&#2325;&#2366;&#2352;&#2346;&#2375;&#2335; &#2319;&#2352;&#2367;&#2351;&#2366; / Carpet Area" />
                                    <asp:BoundField DataField="RentDate_D" HeaderText="&#2325;&#2367;&#2352;&#2366;&#2351;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Rental Date " />
                                    <asp:BoundField DataField="RentAmount_N" HeaderText="&#2325;&#2367;&#2352;&#2366;&#2351;&#2366; &#2352;&#2366;&#2358;&#2368; / Rental Amount" />
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                                <EmptyDataTemplate>
                                    Data not Found
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
           
            <div id="fadeDiv0" runat="server" class="modalBackground"
                style="display: none;">
            </div>
            <div id="Messages0" runat="server" class="popupnew" style="display: none;">
                <div class="msg MT10">
                    <p>
                    </p>
                </div>
                <a id="fancybox-close0" onclick="javascript:closeMessagesDiv();"
                    style="display: inline;"></a>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=ExportDiv.ClientID %>");

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
</asp:Content>

