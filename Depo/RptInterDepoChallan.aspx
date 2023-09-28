<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptInterDepoChallan.aspx.cs" Inherits="Depo_RptInterDepoChallan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="card-header">
        <h2>&#2346;&#2381;&#2352;&#2342;&#2366;&#2351;&#2367;&#2340; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </h2>
    </div>
    <table style="align-content: center" width="100%">
        <tr >
            <td><span>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; / Challan No</span></td>
            <td>
                <asp:DropDownList ID="ddlChallano" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show " />
                       <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" 
                            OnClientClick="return PrintPanel();" Text=" Print"  />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table class="auto-style1">
                    <tr>
                        <td> <div id="ExportDiv" runat="server" >
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                <Columns>
                                         <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; ">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                    <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                    <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                    <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; ">
                                        <ItemTemplate>
                                             <%# Eval("IsScheme").ToString()=="1" ? "&#2351;&#2379;&#2332;&#2344;&#2366;"  : "&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;" %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DestributeBook" HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                                    <asp:BoundField DataField="PaikBandal" HeaderText="&#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; " />
                                    <asp:BoundField DataField="LoojBandal" HeaderText="&#2354;&#2370;&#2332; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375; " />
                                </Columns>
                                <EmptyDataTemplate>
                                    Data Not Found
                                </EmptyDataTemplate>
                            </asp:GridView></div> 
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
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

