<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPTStockParivartan.aspx.cs" Inherits="Depo_RPTStockParivartan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="card-header">
        <h2>&#2360;&#2381;&#2335;&#2377;&#2325; &#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2344; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;&nbsp;</h2>
    </div>
    <div style="padding: 0 10px;">
        <asp:HiddenField ID="hdnId" runat="server" />

        <table  width="100%">
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; </td>
                <td>

                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd">
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " /> </td>
            </tr>
            <tr>
                <td colspan="2"><div id="ExportDiv" runat="server" >
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2360;.&#2325;&#2381;&#2352;.<br>1">
                                <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br>2">
                                <ItemTemplate>
                                                     <%#Eval("DateS")%>
                                                     
                                                 </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;<br>3">
                                <ItemTemplate>
                                                     <%#Eval("TitleHindi_V")%>
                                                     
                                                 </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; &#2350;&#2375;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;  &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;&lt;br&gt;4">
                                <ItemTemplate>
                                                     <%#Eval("TotalBookpaik")%>
                                                     
                                                 </ItemTemplate>
                            </asp:TemplateField>
                          
                            <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352;<br>5">
                                <ItemTemplate>
                                                     <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="200px" Height="30px"><%#Eval("Paikbandle")%></asp:Panel>
                                                     
                                                 </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2354;&#2370;&#2332;  &#2348;&#2306;&#2337;&#2354; &#2350;&#2375;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;  &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &lt;br&gt;5">
                                <ItemTemplate>
                                                     <%#Eval("Loojbandle")%>
                                                     
                                                 </ItemTemplate>
                            </asp:TemplateField>

                          
                            
                            <asp:TemplateField HeaderText="&#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352;<br>6 ">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("LoojBook") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;<br>7 ">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("kulbook") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                        </Columns>
                    </asp:GridView></div>
                    <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                                OnClientClick="return PrintPanel();" Text="Export to PDF & Print" />
                </td>
            </tr></table>


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

