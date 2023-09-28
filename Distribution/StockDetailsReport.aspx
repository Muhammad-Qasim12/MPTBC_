<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StockDetailsReport.aspx.cs" Inherits="Distribution_StockDetailsReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        <div class="card-header">
            <h2>&#2360;&#2381;&#2335;&#2377;&#2325; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Stock Details</h2>
        </div>
        <div style="padding: 0 10px;">

            <table width="100%">
                <tr>
                    <td class="auto-style1">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; :</td>
                    <td>

                    &nbsp;<asp:DropDownList ID="ddlSessionYear" runat="server">
                        </asp:DropDownList>

                    </td><td>&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; </td><td>
                    <asp:DropDownList ID="DdlDepot" runat="server" CssClass="txtbox">
                         <asp:ListItem Value="0">All</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;
                    </td>
                    <td>

                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd" >
                    </asp:DropDownList>

                    </td><td>&#2325;&#2325;&#2381;&#2359;&#2366; / Class</td><td>
                    <asp:DropDownList ID="DDLClass" runat="server" CssClass="txtbox" >
                        <asp:ListItem Value="0">Select..</asp:ListItem>
                        <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                        <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                    </asp:DropDownList>
                
                        </td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="4">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " />
                    &nbsp;<a class="btn" href="#" onclick="return PrintPanel();" style="color: White;">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;</a></td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="4">
                        <div id="ExportDiv" runat="server">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="TitleHindi_V" />
                                <asp:BoundField DataField="RemainYojna" HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;" />
                                <asp:BoundField DataField="RemainSamany" HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; " />
                            </Columns>
                        </asp:GridView></div>
                    </td>
                </tr>
                </table> 
        </div> 
</asp:Content>

