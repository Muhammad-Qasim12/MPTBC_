<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterNameIndexing.aspx.cs" Inherits="Depo_PrinterNameIndexing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="card-header">
        <h2 style="margin: 0px; padding: 0px; border: 0px; outline: 0px; font-weight: inherit; font-style: normal; font-size: 14px; font-family: Arial, Verdan, sans-serif; vertical-align: baseline; color: rgb(255, 255, 255); font-variant: normal; letter-spacing: normal; line-height: 14px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px;">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2309;&#2306;&#2340;&#2367;&#2350; &#2327;&#2339;&#2344;&#2366; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2325;&#2368; &#2344;&#2306;&#2348;&#2352;&#2367;&#2306;&#2327; </h2>
    </div>
    <div style="padding: 0 10px;">
        <table width="100%">
            <tr>
                <td>&#2358;&#2376;&#2325;&#2381;&#2359;&#2367;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;</td>
                <td>
                    <asp:DropDownList ID="ddlSessionYear" runat="server" CssClass="txtbox">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;<asp:Button ID="Button3" runat="server" CssClass="btn" onclick="Button3_Click" OnClientClick="return ValidateAllTextForm();" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306;" />
                <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" 
                            OnClientClick="return PrintPanel();" Text="Print"  /> </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div id="ExportDiv" runat="server"  >
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                            <asp:BoundField DataField="NameofPress_V" HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; /&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                            <asp:BoundField HeaderText="&#2346;&#2375;&#2332; &#2344;&#2306;&#2348;&#2352; " />
                        </Columns>
                    </asp:GridView></div>
                </td></tr> 
           
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

