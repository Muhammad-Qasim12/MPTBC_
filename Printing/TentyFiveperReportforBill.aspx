<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TentyFiveperReportforBill.aspx.cs" Inherits="Depo_TentyFiveperReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2 style="margin: 0px; padding: 0px; border: 0px; outline: 0px; font-weight: inherit; font-style: normal; font-size: 14px; font-family: Arial, Verdan, sans-serif; vertical-align: baseline; color: rgb(255, 255, 255); font-variant: normal; letter-spacing: normal; line-height: 14px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
                
                25 % &#2327;&#2339;&#2344;&#2366; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / 25% Calculation Report</h2>
           
        </div>
        <div style="padding: 0 10px;">
           
            
            <table width="100%">
                <tr>
                    <td>
                          <asp:Button ID="btnExport" runat="server" CssClass="btn_gry" 
                            Text="Export to Excel" OnClick="btnExport_Click1"  />
                        <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                            OnClientClick="return PrintPanel();" Text="Print"  />
                         <div id="ExportDiv" runat="server" >
                        <div id="aa" runat="server" visible="false" >
                         <table width="100%"><tr><td align="center" > <b>&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; ,&#2360;&#2306;&#2349;&#2366;&#2327;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;<br />
        <br />
&nbsp;<asp:Label ID="lblAddress" runat="server"></asp:Label>
        <br />
        </b> 
        </td></tr><tr><td>&nbsp;&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; :<b><asp:Label ID="lblfyYaer" runat="server"></asp:Label>
            </b> 
                                 &nbsp;&nbsp;&nbsp; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; : <b>
            <asp:Label ID="lblDate" runat="server"></asp:Label>
            </b> 
            </td></tr><tr><td>25 % &#2327;&#2339;&#2344;&#2366; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / 25% Calculation Report :
          &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;  :  
                                 <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                      &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325; : <asp:Label ID="Label2" runat="server" Text=""></asp:Label>&nbsp;, प्रिंटर का नाम :
                                 <asp:Label ID="Label3" runat="server"></asp:Label>
                                 </td></tr></table>

                        <br />
                            <br /></center></div>
                           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                               CssClass="tab">
                               <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                                                                           
                                                                                                                                                              
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                   <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Printers Name">
                                        <ItemTemplate>
                                           <a href="ShowTwentyPerReptforbill.aspx?id=<%# api.Encrypt(Eval("StockReceivedTPerID_I").ToString ()) %>&Printerid=<%=PrinID%>&dtfrom=<%=mDtfrom%>&Dtto=<%=mDtto%>&myear=<%=myear%>"><%#Eval("NameofPress_V")%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 
                                    <asp:BoundField DataField="DepoName_V" HeaderText="डिपो का नाम " />
                                 
                                    <asp:BoundField DataField="ChallanNo_V" 
                                        HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Chalan No." />
                                    <asp:BoundField DataField="ChallanDate" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Chalan Date" />
                                    <asp:BoundField DataField="BookType" HeaderText="पुस्तक का प्रकार " />
                                   <asp:BoundField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title Name" 
                                        DataField="TitleHindi_V" />
                                   <asp:BoundField DataField="BookReceived" 
                                        HeaderText="प्राप्त पुस्तकों की संख्या  / No of Book Received" />
                                   <asp:BoundField DataField="LoadingExp" 
                                        HeaderText="डिपो के खर्चे  / Depo Expenditure" />
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2344;&#2306;&#2348;&#2352; / Letter No">
                                        <ItemTemplate>
                                           <a href="ShowTwentyPerReptforbill.aspx?id=<%# api.Encrypt(Eval("StockReceivedTPerID_I").ToString ()) %>&Printerid=<%=PrinID%>&dtfrom=<%=mDtfrom%>&Dtto=<%=mDtto%>&myear=<%=myear%>"><%#Eval("LetterNo_V")%></a>
                                        
                                        </ItemTemplate>
                                    </asp:TemplateField>
                               </Columns>
                                                           <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                               <EmptyDataTemplate>
                                   Data Not Found............
                               </EmptyDataTemplate>
                           </asp:GridView></div> 
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

