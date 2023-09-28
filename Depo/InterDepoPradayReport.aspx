<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InterDepoPradayReport.aspx.cs" Inherits="Depo_InterDepoPradayReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
                    <div class="card-header">
                     <h2> &#2309;&#2306;&#2340;&#2352;&#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2367; </h2>
                          
                    </div>
        <table width="100%">
            <tr><td>&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; </td><td>
                        <asp:DropDownList ID="ddlfyyear" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                    </td><td>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325; &#2337;&#2367;&#2346;&#2379;</td><td>
                        <asp:DropDownList ID="ddldepoName" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                    </td></tr>
            <tr><td colspan="4">&nbsp;<asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;" />
                   
                &nbsp;<asp:Button ID="btnExportPDF" runat="server" CssClass="btn" OnClientClick="return PrintPanel();" Text="Export to PDF &amp; Print" Visible="False" Width="201px" />
                   
                </td></tr>
            <tr><td colspan="4">
                <div id="ExportDiv" runat="server">
                 <center>  <b>अंतरडिपो प्रदाय की स्थिति</b></center> 
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                    <Columns>
                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; ">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                        <asp:BoundField DataField="ReqNo" HeaderText="&#2310;&#2352;&#2381;&#2337;&#2352; &#2344;." />
                        <asp:BoundField DataField="ChallanNo" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; " />
                        <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                        <asp:BoundField DataField="bookTypes" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; " />
                        <asp:BoundField DataField="NetDemand" HeaderText="&#2310;&#2342;&#2375;&#2358;&#2367;&#2340; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                        <asp:BoundField DataField="Supply" HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" />
                        <asp:BoundField DataField="Remain" HeaderText="&#2358;&#2375;&#2359; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" />
                        <asp:BoundField DataField="DepoName_V" HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325; &#2337;&#2367;&#2346;&#2379; " />
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

