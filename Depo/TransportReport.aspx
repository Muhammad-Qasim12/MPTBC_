<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TransportReport.aspx.cs" Inherits="Depo_TransportReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                &#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Transport Details
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
               <tr>
                    <td>
                        &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;</td>
                    <td>
                                        <asp:DropDownList ID="ddlFyYear" runat="server" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)">
                                        </asp:DropDownList>

                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" CssClass="btn" 
                            Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306; / Report" 
                            onclick="Button3_Click " OnClientClick="return ValidateAllTextForm();"/>
                    </td>
                </tr>
               <tr>
                    <td colspan="3"><asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                            OnClientClick="return PrintPanel();" Text="Export to PDF  & Print" />
                       </td>
                </tr>
               <tr>
                    <td colspan="3"><div id="ExportDiv" runat="server" visible="false" >
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
            </td></tr><tr><td>
          
                &#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Transport Details
           
&nbsp;:
          &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;  :  
                                 <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                      &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325; : <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td></tr></table>
                       
                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" onselectedindexchanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335; &#2325;&#2350;&#2381;&#2346;&#2344;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; / Transporter Company Name">
                                    <ItemTemplate>
                                        <a href='ShowtransportDetails.aspx?ID=<%# api.Encrypt(Eval("TransportID_I").ToString()) %>' 
                                            target="_blank"><%#Eval("TransportName_V")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="TransportOwnerName_V" 
                                    HeaderText="&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Transporter Name"/>
                                <asp:BoundField HeaderText="&#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2346;&#2379;&#2335;&#2352; &#2325;&#2366; &nbsp;&#2346;&#2340;&#2366; / Transporter Address " 
                                    DataField="Address_V" />
                                <asp:BoundField DataField="RegistrationNo_V" 
                                    HeaderText="&#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2344;&#2306;&#2348;&#2352; / Reg. No." />
                                <asp:BoundField DataField="RegistrationDate_D" 
                                    HeaderText="&#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Reg. Date" />
                                <asp:BoundField HeaderText="&#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; / Mobile No." 
                                    DataField="MobileNo_N" />
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
            <div id="fadeDiv0" runat="server" class="modalBackground" 
                style="display: none;">
            </div>
            <div id="Messages0" runat="server" class="popupnew" style="display: none;">
                <div class="msg MT10">
                    <p>
                    </p>
                </div>
                <a id="fancybox-close0" onclick="javascript:closeMessagesDiv();" 
                    style="display: inline;"></a>
            </div>
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

