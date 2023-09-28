<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TitleWiseSummary.aspx.cs" Inherits="Distribution_TitleWiseSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div id="a" runat="server" class="card-header" visible="false">
            <h2>&#2337;&#2367;&#2346;&#2379; &#2323;&#2346;&#2344;&#2367;&#2306;&#2327; &#2360;&#2381;&#2335;&#2377;&#2325; </h2>
        </div>
        <table width="100%">
            <tr>
                <td><span style="color: rgb(34, 34, 34); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: bold; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(252, 253, 253); display: inline !important; float: none;">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;</span></td>
                <td>
                    <asp:DropDownList ID="DdlACYear" runat="server" AutoPostBack="True" CssClass="txtbox">
                    </asp:DropDownList>
                </td>
                <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; </td>
                <td>
                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Data" />
                </td>
            </tr>
            <tr>
                <td colspan="5"> <div id="ExportDiv" runat="server" >
            <center>  &#2323;&#2346;&#2344;&#2367;&#2306;&#2327; &#2360;&#2381;&#2335;&#2377;&#2325; &#2360;&#2350;&#2352;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; 
                    &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350; :<%=ddlMedium.SelectedItem.Text %> &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;:<%=DdlACYear.SelectedItem.Text %></center>  
                  <center>
                      <asp:GridView ID="GridView1" runat="server" 
                          CssClass="tab" AutoGenerateColumns="False" 
                           OnRowDataBound="GridView1_RowDataBound" ShowFooter="True" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;.">
                                <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                            <asp:BoundField DataField="YojanaBook" HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; " />
                            <asp:BoundField DataField="samanyBook" HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; " />
                            <asp:BoundField DataField="Total" HeaderText="&#2325;&#2369;&#2354; " />
                        </Columns>
                    </asp:GridView></center></div> 
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                                OnClientClick="return PrintPanel();" Text="Export to PDF & Print" />
                </td>
            </tr>
        </table>
    </div>
    <script type = "text/javascript">
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

