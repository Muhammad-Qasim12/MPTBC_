<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookNotSupplydepoaspx.aspx.cs" Inherits="Depo_BookNotSupplydepoaspx" %>

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
  
    
     <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>
                    <%--Tender Related Information--%>&#2350;&#2369;&#2342;&#2381;&#2352;&#2325;&#2379;&#2306; &#2360;&#2375; &#2309;&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td colspan="5" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Name of Work --%>&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlACYear" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;</td>
                    <td>
                        <asp:DropDownList ID="ddlMedium" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Show Report" OnClick="Button1_Click" />
                    </td></tr> 
                <tr>
                    <td colspan="5">
                        &nbsp; <a class="btn" href="#" onclick="return PrintPanel();" style="color: White;">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;</a><asp:Button ID="btnExport" runat="server" CssClass="btn" Height="28px" OnClick="btnExport_Click" Text="Export to Excel" />
                    </td>
                    </tr> </table><div id ="ExportDiv" runat="server">  <table width="100%">
              <tr>
                    <td colspan="5">
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <%=DdlACYear.SelectedItem.Text %>&nbsp; &#2325;&#2375; &#2354;&#2367;&#2319; &#2350;&#2369;&#2342;&#2381;&#2352;&#2325;&#2379;&#2306; &#2360;&#2375; &#2309;&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2325;&#2366; &#2346;&#2340;&#2381;&#2352;&#2325;
                    </td>
                    </tr> 
                <tr>
                    <td colspan="5">
                        
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                            <Columns>
                                 <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325;  &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="NamePrinters" />
                                <asp:BoundField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; " DataField="class" />
                                <asp:BoundField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="SUBJECT" />
 
                                 <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2344;">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("TOTAL_Allot") %>'></asp:Label>  
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    </tr> </table></div> </div> 
</asp:Content>

