<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PendingChallanlist.aspx.cs" Inherits="Depo_PendingChallanlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="card-header">
            <h2>
                &#2346;&#2375;&#2306;&#2337;&#2367;&#2306;&#2327; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </h2>
        </div>
        <div class="table-responsive">

            <table width="100%">
                <tr><td colspan="4">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
                    </td></tr>

                <tr><td><span style="color: rgb(0, 0, 0); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: bold; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(241, 241, 241); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;</span></td><td>
                    <asp:DropDownList ID="ddlSessionYear" runat="server">
                    </asp:DropDownList>
                    </td><td>
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Details" />
                        <br />
                    </td><td>
                        &nbsp;</td></tr>

                <tr><td colspan="3">
                    <div ID="ExportDiv" runat="server" >
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                        <Columns>
                            <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                <ItemTemplate>
                                   <a href="ShowDetails1.aspx?ID=<%#Eval("UserID") %>" target="_blank"><%#Eval("NoChaaln")%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView></div>
                    </td><td>
                        &nbsp;</td></tr>

                <tr><td colspan="3">
                    <asp:Button ID="btnPrint" runat="server" CssClass="btn" OnClientClick="return PrintPanel()" Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;&#2306;" Width="150" />
                    </td><td>
                        &nbsp;</td></tr>
                </table> </div> 

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

