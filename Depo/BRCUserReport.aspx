<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BRCUserReport.aspx.cs" Inherits="Depo_BRCUserReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script type="text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=Panel1.ClientID %>");
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
 <div class="box">
        <div class="card-header">
            <h2>
                &#2337;&#2367;&#2346;&#2379; &#2357;&#2366;&#2311;&#2332; &#2348;&#2381;&#2354;&#2366;&#2325;&nbsp; &#2351;&#2370;&#2332;&#2352; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;&nbsp; </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
              &nbsp;<asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none;
                padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <table width="100%">
                  <tr>
                    <td style="text-align: left">
                        
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">BRC</asp:ListItem>
                            <asp:ListItem Value="2">BEO</asp:ListItem>
                            <asp:ListItem Value="3">DEO</asp:ListItem>
                            <asp:ListItem Value="4">DPC</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                  <tr>
                    <td style="text-align: left">
                        
                        &#2332;&#2367;&#2354;&#2366;&nbsp; &#2330;&#2369;&#2344;&#2375; / Choose District : <asp:DropDownList ID="DdlDistrict" 
                            runat="server" CssClass="txtbox">
                        </asp:DropDownList>      &nbsp;&nbsp;&nbsp;&nbsp;      <asp:Button ID="btnSave" 
                            runat="server" CssClass="btn" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; / See Report "   
                            onclick="btnSave_Click" />
                    </td>
                </tr>
                </table>
              <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="false" >
                   <table>
                <tr>
                <td>
                 <a href="#" class="btn" style="color:White;" onclick="return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;</a>
                </td>
                <td>
                 <asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" CssClass="btn" OnClick="btnExport_Click" />
                </td>
               
                </tr>
                </table>      
                                    <div id="ExportDiv" runat="server">
               <table width="100%">
                 <tr>
                                                    <td  style="font-size: 18px; font-weight: bold; text-align: center;" colspan="3">
                                                      &#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td  style="font-size: 16px; font-weight: 200; text-align: center;" colspan="3">
                                                      " &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2349;&#2357;&#2344; "
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="25%;">
                                                        &nbsp;</td>
                                                    <td style="font-size: 16px; font-weight: 200; text-align: center;width:50%;">&#2357;&#2367;&#2325;&#2366;&#2360;&#2326;&#2306;&#2337; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; </td>
                                                    <td style="font-size: 16px; font-weight: 200; text-align: center;width:25%;">
                                                        <div style="float: right; padding-right: 20px;">
                                                            <asp:Label ID="lblDate" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td  colspan="3" style="font-size: 16px; font-weight: bold; text-align: center;">
                                                       <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                <tr>
                    <td style="text-align: center" colspan="3">
                        <asp:GridView ID="gvUserMaster" runat="server" AutoGenerateColumns="False" CssClass="tab"
                           >
                            <Columns>
                             <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                                                                           
                                                                                                                                                              
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                 <asp:BoundField HeaderText="&#2348;&#2381;&#2354;&#2366;&#2325;/&#2332;&#2367;&#2354;&#2366;  &#2325;&#2366; &#2344;&#2366;&#2350;  " DataField="BlockName_V" ReadOnly="true" />
                                <asp:BoundField HeaderText="&#2351;&#2370;&#2332;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / User Name " DataField="Username_V" ReadOnly="true" />
                                <asp:BoundField HeaderText="&#2351;&#2370;&#2332;&#2352; &#2325;&#2366; &#2346;&#2366;&#2360;&#2357;&#2352;&#2381;&#2337; / User Password " DataField="Password_V" ReadOnly="true" />
                                <asp:BoundField DataField="name" HeaderText=" &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; / Officer Name" ReadOnly="true" />
                                <asp:BoundField DataField="DptName" HeaderText=" &#2351;&#2370;&#2332;&#2352; &#2325;&#2366; &#2357;&#2367;&#2349;&#2366;&#2327; / User Department" ReadOnly="true" />
                                <%-- <asp:BoundField DataField="name" ReadOnly="true" HeaderText="&#2358;&#2366;&#2326;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; / Branch Name" />--%>
                                                          
                            </Columns>
                            <PagerStyle CssClass="pagination" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
                                        </div>
                  </asp:Panel>
        </div>
    </div>
</asp:Content>

