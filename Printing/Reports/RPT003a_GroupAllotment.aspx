<%@ Page Title="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2375; &#2327;&#2381;&#2352;&#2369;&#2346; &#2310;&#2357;&#2306;&#2335;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPT003a_GroupAllotment.aspx.cs" EnableEventValidation="false"  Inherits="Printing_Reports_RPT003a_GroupAllotment" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="portlet-header ui-widget-header">
      &#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2375; &#2327;&#2381;&#2352;&#2369;&#2346; &#2310;&#2357;&#2306;&#2335;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; 
        </div>
        <div class="portlet-content">
 <asp:Panel runat="server" ScrollBars="Horizontal" Direction ="LeftToRight" >
        <table width="100%">

        <tr>

        <td>
        &#2358;&#2375;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;
        </td>
        
        <td>
        <asp:DropDownList ID="ddlAcYearId" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddlAcYearId_SelectedIndexChanged" >
        
        </asp:DropDownList>


        </td>
            <td>&nbsp;</td>
            <td>
                 <asp:DropDownList ID="ddlTenderID_I" CssClass="txtbox" runat="server" Visible="False"></asp:DropDownList>
            </td>
        <td>
        &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;
        </td>
        
        <td>
        <asp:DropDownList ID="ddlPrinter" runat="server"  >
        
        </asp:DropDownList>
            <a href="RPT003_GroupAllotment.aspx"></a>
            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375;"
                        OnClick="btnSearch_Click"   OnClientClick="return ValidateAllTextForm();"/>
        </td>
        </tr>
            

        <tr>
        <td colspan="6">
        <div runat="server" id = "ExportDiv">

             <table align = "center"  width="100%" >
       <tr><td  style="text-align:center;font-weight:bold;font-family:Verdana;font-size:18px;" > 
          &#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;

           </td></tr>
              <tr><td align = "center"  style="width: 100%;font-weight:bold;" > 
     <div style="text-align:center;">

            &#2350;&#2369;&#2342;&#2381;&#2352;&#2325;&#2357;&#2366;&#2352; &#2310;&#2348;&#2306;&#2335;&#2367;&#2340; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2309;&#2342;&#2381;&#2351;&#2340;&#2344; &#2360;&#2381;&#2341;&#2367;&#2340;&#2367;
         </div>
                  </td>
                  </tr>
 <tr><td align = "center"  style="width: 100%;font-weight:bold;" > 
     <div style="text-align:center;">
          <asp:Label ID="lblTitle" runat="server" ></asp:Label></div>
          </td></tr>
                 <tr><td align = "center"  style="width: 100%;font-weight:bold;" >

      
        <asp:GridView ID="GrdGroupDetails" runat="server" AutoGenerateColumns="False" CssClass="tab" OnSelectedIndexChanged="GrdGroupDetails_SelectedIndexChanged"
            OnRowDataBound="GrdGroupDetails_RowDataBound" OnDataBound="GrdGroupDetails_DataBound"  OnRowCreated = "OnRowCreated">
                        <Columns>
                            <asp:TemplateField HeaderText="&lt;br&gt;&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                      <%# Eval("rowno")%>
                                   <%-- <%# Container.DataItemIndex+1 %>--%>
                                    <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("PrinterID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <%--  <asp:TemplateField HeaderText="&lt;br&gt;&#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2325;&#2366;  &#2344;&#2366;&#2350; &#2319;&#2357;&#2306; &#2342;&#2370;&#2352;&#2349;&#2366;&#2359;">
                    <ItemTemplate>
                    <%# Eval("NamePrinters")%>
                    </ItemTemplate> 
                    </asp:TemplateField> --%>
                           
                            <asp:BoundField HtmlEncode="false" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2325;&#2366;  &#2344;&#2366;&#2350; &#2319;&#2357;&#2306; &#2342;&#2370;&#2352;&#2349;&#2366;&#2359;" DataField="NamePrinters"/>
                            <asp:BoundField HeaderText="&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;" DataField="SUBJECT" />
                             <asp:BoundField HeaderText="&#2348;&#2376;&#2306;&#2325; &#2327;&#2366;&#2352;&#2306;&#2335;&#2368; / &#2319;&#2347; &#2337;&#2368; &#2310;&#2352;  &#2352;&#2366;&#2358;&#2367;" DataField="bankguarent" />
                             <asp:BoundField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  &#2344;&#2367;&#2357;&#2367;&#2342;&#2366; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; " DataField="TENDERTOTAL" />
                             <asp:BoundField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  &#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; " DataField="VITRANTOT" />
                              <asp:BoundField HeaderText="&#2325;&#2369;&#2354; &#2354;&#2327;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2325;&#2366;&#2327;&#2395; &#2344;&#2367;&#2357;&#2367;&#2342;&#2366; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; ( &#2335;&#2344; ) " DataField="QtyAsPerTender" />

                            <asp:BoundField HeaderText="कुल लगने वाला कागज़ वितरण अनुसार ( टन )" DataField="VITRANTOT_TON" />

                             <asp:BoundField HeaderText="&#2309;&#2344;&#2369;&#2348;&#2306;&#2343;  &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;       " DataField="AGRIMENTdt" />
                             <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2370;&#2347; &#2332;&#2350;&#2366; &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2340;&#2367;&#2341;&#2367;" DataField="Pandudt" />

                            <asp:BoundField HeaderText="&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2367;&#2340; &#2346;&#2381;&#2352;&#2370;&#2347; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataField="PROOFRECEdt" />
                            <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2310;&#2342;&#2375;&#2358; &#2342;&#2367;&#2344;&#2366;&#2325; " DataField="Printorderdt" />

                            <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2358;&#2366;&#2326;&#2366; &#2342;&#2370;&#2357;&#2366;&#2352;&#2366; &#2310;&#2342;&#2375;&#2358;&#2367;&#2340;  &#2325;&#2366;&#2327;&#2332;" DataField="PaperIssue" />
                            <asp:BoundField DataField="CPDIssue" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2342;&#2370;&#2357;&#2366;&#2352;&#2366; CPD &#2360;&#2375; &#2313;&#2336;&#2366;&#2351;&#2366; &#2327;&#2351;&#2366; &#2325;&#2366;&#2327;&#2332;" />
                            <asp:BoundField HeaderText="&#2313;&#2336;&#2366;&#2344;&#2375;  &#2325;&#2375; &#2354;&#2367;&#2319; &#2358;&#2375;&#2359; &#2325;&#2366;&#2327;&#2332; " Visible="True" DataField="RemainPaper" />
                            <asp:BoundField HeaderText="&#2348;&#2376;&#2306;&#2325; &#2327;&#2366;&#2352;&#2306;&#2335;&#2368; &#2325;&#2368; &#2309;&#2340;&#2367;&#2352;&#2367;&#2325;&#2381;&#2340; &#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366;" Visible="True" DataField="bankguarentaddition" />
                            <asp:BoundField HeaderText="प्राप्त पुस्तकों की संख्या" Visible="True" DataField="total_rec" />
                               
                          <%--  <asp:TemplateField HeaderText="&lt;br&gt;&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;">
                                <ItemTemplate>
                                <asp:Label ID="lblGroupNO_V" runat="server" Text='<%#Eval("SUBJECT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            
                            <asp:TemplateField HeaderText="&lt;br&gt;&#2348;&#2376;&#2306;&#2325; &#2327;&#2366;&#2352;&#2306;&#2335;&#2368; / &#2319;&#2347; &#2337;&#2368; &#2310;&#2352;  &#2352;&#2366;&#2358;&#2367;">
                                <ItemTemplate>
                                <asp:Label ID="lblTitleHindi_V" runat="server" Text='<%#Eval("bankguarent") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="&lt;br&gt;&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  &#2344;&#2367;&#2357;&#2367;&#2342;&#2366; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; ">
                                <ItemTemplate>
                                <asp:Label ID="lblNoofpages" runat="server" Text='<%#Eval("TENDERTOTAL") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="&lt;br&gt;&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  &#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; ">
                                <ItemTemplate>
                                <asp:Label ID="lblTotNoOfBooks" runat="server" Text='<%#Eval("VITRANTOT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="&lt;br&gt;&#2325;&#2369;&#2354; &#2354;&#2327;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2325;&#2366;&#2327;&#2395; &#2344;&#2367;&#2357;&#2367;&#2342;&#2366; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; ( &#2335;&#2344; ) " Visible="True">
                                <ItemTemplate>
                                <asp:Label ID="lblQty_PriPaperj" runat="server" Text='<%#Eval("QtyAsPerTender") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                                    
                            
                              <asp:TemplateField HeaderText="&lt;br&gt;&#2309;&#2344;&#2369;&#2348;&#2306;&#2343;  &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;       " Visible="True">
                                <ItemTemplate>
                                <asp:Label ID="lblQty_PriPaperk" runat="server" Text='<%#Eval("AGRIMENTdt") %>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="&lt;br&gt;&#2346;&#2381;&#2352;&#2370;&#2347; &#2332;&#2350;&#2366; &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2340;&#2367;&#2341;&#2367;" Visible="True">
                                <ItemTemplate>
                                <asp:Label ID="lblQty_PriPaper11t" runat="server" Text='<%#Eval("Pandudt") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                 
                                          
                           
                           <asp:TemplateField HeaderText="&lt;br&gt;&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2367;&#2340; &#2346;&#2381;&#2352;&#2370;&#2347; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" Visible="True">
                                <ItemTemplate>
                                <asp:Label ID="lblQty_PriPaper11p" runat="server" Text='<%#Eval("PROOFRECEdt") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>  


                            <asp:TemplateField HeaderText="&lt;br&gt;&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2310;&#2342;&#2375;&#2358; &#2342;&#2367;&#2344;&#2366;&#2325; " Visible="True">
                                <ItemTemplate>
                                <asp:Label ID="lblQty_PriPaper11r" runat="server" Text='<%#Eval("Printorderdt") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                             
                            <asp:TemplateField HeaderText="&lt;br&gt;&#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2342;&#2370;&#2357;&#2366;&#2352;&#2366; &#2313;&#2336;&#2366;&#2351;&#2366; &#2327;&#2351;&#2366; &#2325;&#2366;&#2327;&#2332;" Visible="True">
                                <ItemTemplate>
                                <asp:Label ID="lblQty_PriPaper11q" runat="server" Text='<%#Eval("PaperIssue") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 

                            <asp:TemplateField HeaderText="&lt;br&gt;&#2313;&#2336;&#2366;&#2344;&#2375; &#2361;&#2375;&#2340;&#2369; &#2358;&#2375;&#2359; &#2325;&#2366;&#2327;&#2395; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366;" Visible="True">
                                <ItemTemplate>
                                <asp:Label ID="lblQty_PriPaper11o" runat="server" Text='<%#Eval("RemainPaper") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                           
                            <asp:TemplateField HeaderText="&lt;br&gt;&#2348;&#2376;&#2306;&#2325; &#2327;&#2366;&#2352;&#2306;&#2335;&#2368; &#2325;&#2368; &#2309;&#2340;&#2367;&#2352;&#2367;&#2325;&#2381;&#2340; &#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366;" Visible="True">
                                <ItemTemplate>
                               <%-- <asp:Label ID="lblQty_PriPaper11e" runat="server" Text='<%#Eval("bankguarentaddition") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> --%>
                           

                       
                           
                            
                             
                            
                           
                           


                            
                             
                            
                           
                        </Columns>
                    </asp:GridView>
                                          </td>
                     </tr>
                 </table>
                    </div>
        </td>
        </tr>

       <tr>
        <td colspan="4">
          <asp:Button ID="btnExport" runat="server" Text="Export to Excel" CssClass="btn_gry" OnClick="btnExport_Click" />

           <asp:Button ID="btnExportPDF" runat="server" Text="Export to PDF" 
                OnClientClick  = "return PrintPanel();" CssClass="btn_gry" 
                onclick="btnExportPDF_Click" />    
                     
        </td>
        </tr>
        </table>
      </asp:Panel>
        </div> 

         <script type = "text/javascript">
             function PrintPanel() {
                 var panel = document.getElementById("<%=ExportDiv.ClientID %>");

                 var printWindow = window.open('', '', 'height=400,width=800');
                 printWindow.document.write('<html><head><title>Printer Tender Allotement</title>');
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

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style1
        {
            width: 1016px;
        }
    </style>
</asp:Content>


