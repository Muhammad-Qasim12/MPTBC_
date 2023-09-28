<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FinalReport.aspx.cs" Inherits="Depo_FinalReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
        <div class="card-header">
            <h2 style="margin: 0px; padding: 0px; border: 0px; outline: 0px; font-weight: inherit; font-style: normal; font-size: 14px; font-family: Arial, Verdan, sans-serif; vertical-align: baseline; color: rgb(255, 255, 255); font-variant: normal; letter-spacing: normal; line-height: 14px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
                
               &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2309;&#2306;&#2340;&#2367;&#2350; &#2327;&#2339;&#2344;&#2366; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;</h2>
           
        </div>
        <div style="padding: 0 10px;">
           
            
            <table width="100%">
                <tr>
                    <td>
                        &#2358;&#2376;&#2325;&#2381;&#2359;&#2367;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;</td>
                    <td>
                        <asp:DropDownList ID="ddlSessionYear" CssClass="txtbox" runat="server">
                        </asp:DropDownList>
                        
                        
                    </td>
                    <td>
                        &nbsp;<asp:Button ID="Button3" runat="server" CssClass="btn" 
                            Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306;" 
                            onclick="Button3_Click" OnClientClick="return ValidateAllTextForm();" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="grnMain" runat="server" AutoGenerateColumns="False" 
                    CssClass="tab">
                    <Columns>
                       <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("Printer_RedID_I") %>' />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                        <asp:BoundField DataField="NameofPress_V" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                        <asp:BoundField DataField="FromDate_D" HeaderText=" &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;" />
                        <asp:BoundField DataField="Totaldate_D" HeaderText=" &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325; " />
                                             
                         
                                  <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit">
                                    <ItemTemplate>
                                        <a href="FinalDetailsreport.aspx?ID=<%#(Eval("Printer_RedID_I").ToString ()) %>&Fromdate=<%# Eval("FromDate_D") %>&Todate=<%# Eval ("Totaldate_D") %>&fyear=<%# Eval ("AcYear") %>&DepoName=<%# Eval("DepoName_V") %>" target="_blank" >Show Details </a>
                                    </ItemTemplate>
                                </asp:TemplateField>            

                    </Columns>
                </asp:GridView>
                           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                               CssClass="tab" onselectedindexchanged="GridView1_SelectedIndexChanged">
                               <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                                                                           
                                                                                                                                                              
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                   <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;" 
                                        DataField="NameofPress_V" />
                                    <asp:BoundField DataField="ChallanNo_V" 
                                        HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; " />
                                    <asp:BoundField DataField="ChallanDate" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" />
                                    <asp:BoundField DataField="GRNo_V" HeaderText="&#2332;&#2368;.&#2310;&#2352;.&#2325;&#2381;&#2352;." />
                                    <asp:BoundField DataField="GRDate_D" HeaderText="&#2332;&#2368;.&#2310;&#2352;.&#2342;&#2367;&#2344;&#2366;&#2325;" />
                                   <asp:BoundField HeaderText=" 25% &#2327;&#2339;&#2344;&#2366; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " 
                                        DataField="TotalBook" />
                                    <asp:BoundField DataField="Date_D" HeaderText=" 25% &#2327;&#2339;&#2344;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" />
                                    <asp:BoundField DataField="ReceivedBookNo_I" 
                                        HeaderText="&#2309;&#2306;&#2340;&#2367;&#2350; &#2327;&#2339;&#2344;&#2366; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                                    <asp:BoundField DataField="Receiveddate_D" HeaderText="&#2309;&#2306;&#2340;&#2367;&#2350; &#2327;&#2339;&#2344;&#2366; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" />
                                    <asp:BoundField DataField="Amount" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2342;&#2370;&#2357;&#2366;&#2352;&#2366; &#2325;&#2367;&#2351;&#2366; &#2327;&#2351;&#2366; &#2325;&#2369;&#2354; &#2357;&#2381;&#2351;&#2351;" />
                                    <asp:BoundField DataField="TotalNotuseful_N" 
                                        HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2350;&#2375;&#2306; &#2348;&#2367;&#2325;&#2368; &#2309;&#2351;&#2379;&#2327;&#2381;&#2351; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" />
                                    <asp:BoundField DataField="Remarks_V" HeaderText="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325;" />
                               </Columns>
                               <EmptyDataTemplate>
                                   Data Not Found.......
                               </EmptyDataTemplate>
                           </asp:GridView>
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
</asp:Content>

