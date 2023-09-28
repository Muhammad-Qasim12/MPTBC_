<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterExpChallan.aspx.cs" Inherits="Depo_PrinterExpChallan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
      <script type = "text/javascript">
          function PrintPanel() {
              var panel = document.getElementById("<%=ExportDiv.ClientID %>");

                      var printWindow = window.open('', '', 'height=400,width=800');
                      printWindow.document.write('<html><head><title></title><style>.tab {width: 100%;  border-collapse: collapse;  border-left: 1px solid #d8d8d8; }.tab th { color: #000;border-bottom: 1px solid #d8d8d8;  border-top: 1px solid #d8d8d8;  background: #f1f1f1;  font-weight: bold; }   .tab th, .tab td {  padding: 8px 10px;  text-align: center;  font-size: 1em;    border-bottom: 1px solid #d8d8d8; border-right: 1px solid #d8d8d8;  border-left: 1px solid #d8d8d8; background: transparent; }  .tab th { color: #000;  border-bottom: 1px solid #d8d8d8;  border-top: 1px solid #d8d8d8;  background: #f1f1f1;  font-weight: bold;  } .tab th, .tab td { padding: 8px 10px; text-align: left; font-size: 1em; border-bottom: 1px solid #d8d8d8;   border-right: 1px solid #d8d8d8;   border-left: 1px solid #d8d8d8;   background: transparent; }</style>');
                      printWindow.document.write('</head><body >');
                      printWindow.document.write(panel.innerHTML);
                      printWindow.document.write('</body></html>');
                      printWindow.document.close();
                      setTimeout(function () {
                          printWindow.print();
                      }, 500);
                      return false;
                  }</script>         
     <div class="box">
        <div class="card-header">
            <h2>
                &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2375; 3 &#2342;&#2367;&#2357;&#2360; &#2325;&#2375; &#2348;&#2366;&#2342; &#2346;&#2375;&#2306;&#2337;&#2367;&#2306;&#2327; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;
            </h2>
        </div>
        <div style="padding: 0 10px;">
           
            
            <table  >
                <tr>
                    <td>
                        &#2360;&#2340;&#2381;&#2352;
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlACYear" runat="server">
</asp:DropDownList>
</td>
                    <td>
                        <asp:Button ID="Button3" runat="server" CssClass="btn" 
                            Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306;" 
                            onclick="Button3_Click" OnClientClick="return ValidateAllTextForm();" />

                        <asp:Button ID="btnExport" runat="server" CssClass="btn" 
                            Text="Export to Excel"   />&nbsp;
                        <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" 
                            OnClientClick="return PrintPanel();" Text=" Print"  />
                    </td>
                     
                </tr>
                <tr>
                    <td colspan="3"><div id="ExportDiv" runat="server">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns> <asp:TemplateField HeaderText="क्रमांक / Sr.No.">
                                   <ItemTemplate>
                                       <%# Container.DataItemIndex+1 %>
                                   </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:BoundField DataField="NameofPress_V" HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:BoundField DataField="ChalanNo" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;." />
                                <asp:BoundField DataField="ChalanDate" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                                <asp:BoundField DataField="TotalNoBook" HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                            </Columns>
                        </asp:GridView></div>
                    </td>
                   
                </tr></table> </div> </div> 
</asp:Content>

