<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookSellerChallanPrint.aspx.cs" Inherits="Depo_BookSellerChallanPrint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
    
    
     <div class="box table-responsive">
           <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" 
                            OnClientClick="return PrintPanel();" Text=" Print"  />
         <div id="ExportDiv" runat="server" >
        <div class="card-header">
            <h2>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2325;&#2366; &#2330;&#2366;&#2354;&#2366;&#2344; </h2>
        </div>
        <div style="padding: 0 10px;">

            <table width="100%">
                <tr>
                    <td class="auto-style1" >
                        
                                    &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;
                        
                                    </td>
                    <td class="auto-style1" >
                        
                                    <%=Request.QueryString["BooksellerName"] %></td>
                    <td class="auto-style1" >
                        
                                    &#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352;
                        
                                    </td>
                      <td class="auto-style1" >
                        
                                    <%=Request.QueryString["OrderNo"] %></td>
                </tr>
                <tr>
                    <td class="auto-style1" >
                        
                                    &nbsp;</td>
                    <td class="auto-style1" >
                        
                                    &nbsp;</td>
                    <td class="auto-style1" >
                        
                                    &nbsp;</td>
                      <td class="auto-style1" >
                        
                                    &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" >
                        
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                            <asp:BoundField DataField="BookNumber" HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" />
                                            <asp:BoundField DataField="DestributeBook" HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                                            <asp:BoundField DataField="PaikBandal" HeaderText="&#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; " />
                                            <asp:BoundField DataField="LoojBandal" HeaderText="&#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; " />
                                        </Columns>
                                    </asp:GridView>
                    </td>
                </tr>
                </table> 
            </div> </div> 
          </div> 
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
</asp:Content>

