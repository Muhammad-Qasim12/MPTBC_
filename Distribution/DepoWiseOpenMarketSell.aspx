<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepoWiseOpenMarketSell.aspx.cs" Inherits="Distribution_DepoWiseOpenMarketSell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=btnExport.ClientID %>");

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
    
    <div class="box table-responsive">
                <div class="card-header">
                    <h2>
                        &#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2350;&#2375;&#2306; &#2357;&#2367;&#2325;&#2381;&#2352;&#2368; &#2325;&#2368; &#2327;&#2312; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;
                    </h2>
                </div>
                <div class="portlet-content">
                    <div class="table-responsive">
                        <table  >
                            <tr><td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;</td><td>
                                <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                                </asp:DropDownList>
                                </td><td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;</td><td>
                                <asp:DropDownList ID="DdlScheme" runat="server">
                                </asp:DropDownList>
                                </td>

                                <td>&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; </td><td>
                                <asp:DropDownList ID="DDlDepot" runat="server">
                                </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="&#2337;&#2366;&#2335;&#2366; &#2342;&#2375;&#2326;&#2375; " />
                                </td>
                            </tr>
                           
                            <tr><td colspan="7">  <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Print" OnClientClick="return PrintPanel();"  />
                            &nbsp;<asp:Button ID="btnExport" runat="server" CssClass="btn" OnClick="btnExport_Click" Text="Export to Excel" />
                                  <div id="ExportDiv" runat="server" >
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="&#2360;.&#2325;&#2381;&#2352;.">
                                             <ItemTemplate>
                                            
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                
                                        </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                        <asp:BoundField DataField="Total" HeaderText="&#2325;&#2369;&#2354; &#2357;&#2367;&#2325;&#2381;&#2352;&#2368; " />
                                    </Columns>
                                </asp:GridView></div> 
                                </td>
                            </tr>
                           
                            </table> 
                             </div> </div> 
        </div> 
</asp:Content>


