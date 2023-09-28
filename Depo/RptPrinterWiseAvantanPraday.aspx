<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptPrinterWiseAvantanPraday.aspx.cs" Inherits="Depo_RptPrinterWiseAvantanPraday" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                &#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2375; &#2357;&#2367;&#2352;&#2369;&#2343;&#2381;&#2342; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;
            </h2>
        </div>
        <div style="padding: 0 10px;">
           
            
            <table width="100%">
                <tr>
                    <td>
                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromdate" runat="server" CssClass="txtbox reqirerd" MaxLength="10"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromdate" Format="dd/MM/yyyy">
                     </cc1:CalendarExtender>
                         
                    </td>
                    <td>
                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325;
                    </td>
                    <td>
                      
                        <asp:TextBox ID="txtTodate" runat="server" CssClass="txtbox reqirerd" MaxLength="10"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTodate" Format="dd/MM/yyyy">
                     </cc1:CalendarExtender>
                         
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;</td>
                    <td>
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="Button3" runat="server" CssClass="btn" 
                            Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306;" 
                            onclick="Button3_Click" OnClientClick="return ValidateAllTextForm();" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4"> <div runat="server" id="ExportDiv" visible="false" >
                          <center>
                      <b>  &#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;</b> <br />
                        <br />
                       <b> &#2337;&#2367;&#2346;&#2379; :<%=Session["UserName"]%> </b> 
                        <br />
                        <br />

                              <b>   &#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2375; &#2357;&#2367;&#2352;&#2369;&#2343;&#2381;&#2342; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;</b> 
        
                              <br />
                                                            <br />
                            <br /></center>
                           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                               CssClass="tab">
                               <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                                                                           
                                                                                                                                                              
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                   <asp:BoundField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366;  &#2344;&#2366;&#2350; " 
                                        DataField="TitalName" />
                                   <asp:BoundField HeaderText="&#2335;&#2379;&#2335;&#2354; &#2310;&#2357;&#2306;&#2335;&#2344;" 
                                        DataField="TotalAvantan" />
                                   <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="PrinterName" />
                                 
                                    <asp:BoundField HeaderText=" &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2369;&#2325; " 
                                        DataField="PrinterBook" />
                                    <asp:BoundField DataField="DepoStock" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; &#2313;&#2346;&#2354;&#2348;&#2381;&#2343; &#2360;&#2381;&#2335;&#2377;&#2325;" />
                                    <asp:BoundField DataField="TotalDepoPrinter" 
                                        HeaderText="&#2350;&#2361;&#2366;&#2351;&#2379;&#2327;" />
                                    <asp:BoundField DataField="RemeingBook" HeaderText="&#2358;&#2375;&#2359;" />
                               </Columns>
                               <EmptyDataTemplate>
                                   Data Not Found............
                               </EmptyDataTemplate>
                           </asp:GridView></div> 
                    </td>
                </tr>
                <tr>
                    <td colspan="4"> 
                        <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                            OnClientClick="return PrintPanel();" Text="Export to PDF"  />
                    </td>
                </tr>
            </table>
          
            <tr>
                <td colspan="4">
                         
                 <div id="fadeDiv" class="modalBackground" style="display: none;"  runat="server">
            </div>
            <div id="Messages" style="display: none;" class="popupnew"   runat="server">
             
                <div class="msg MT10">
                    <p>
                     
                
                    </p>
                </div>
                <a id="fancybox-close" style="display: inline;" onclick="javascript:closeMessagesDiv();">
                </a>
            </div>
                </td>
            
            </tr>
        </div>
    </div>
   <script type = "text/javascript">
       function PrintPanel() {
           var panel = document.getElementById("<%=ExportDiv.ClientID %>");

           var printWindow = window.open('', '', 'height=400,width=800');
           printWindow.document.write('<html><head><title>Area,Gender and Category wise Distribution of Student</title>');
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


