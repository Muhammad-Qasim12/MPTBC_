<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="rpt_OtherThenDeliveryInstruction.aspx.cs" Inherits="Depo_rpt_OtherThenDeliveryInstruction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script type="text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("Panel1.ClientID");
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
         }


    </script>
    <script type="text/javascript" src="../js/jquery-1.3.2.js"></script> 
    <script type="text/javascript" src="../js/printrdlc.js"></script> 
    <div class="portlet-header ui-widget-header">
        &#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;
    </div>
    <div class="portlet-content">
        <div class="box table-responsive">
            <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
                <table width="100%" cellpadding="0" cellspacing="0">

                    <tr>
                      <td> <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year</asp:Label>
                <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" Width="120px" OnInit="ddlAcYear_Init">                  
                </asp:DropDownList>
                    </td>
                     <td> 
                            <asp:Button ID="Button1" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                OnClientClick="return ValidateAllTextForm1();" OnClick="Button1_Click" />
                                            <a href="#" class="btn" style="color: White;display:none;" onclick="return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;</a>
                                        </td>
                  
                    </tr>
                    
                    <tr>
                        <td colspan="2" align="center" id="tdPrintContent" runat="server" visible="true">
                            
                            <div style="width: auto; height: auto;">
                                <center>
                                    <div class="MT20">
                                        
                                                   
                                                        <table width="100%">
                                                            <%--<tr>
                                                                <td colspan="4" style="font-size: 14px;font-weight: bold; text-align:left;line-height:2em;">
                                                                   &#2352;&#2366;&#2332;&#2381;&#2351; &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2325;&#2375;&#2306;&#2342;&#2381;&#2352; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <asp:Label ID="lblLetterNo" runat="server"></asp:Label><br />
                                                                    &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; <asp:Label ID="lblLetterDate" runat="server"></asp:Label> &#2325;&#2375; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; 
                                                                    <asp:Label ID="lblTitle" runat="server" Font-Size="16px"></asp:Label><br />
                                                                    &#2325;&#2368; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2332;&#2367;&#2354;&#2375;&#2357;&#2366;&#2352;/&#2348;&#2381;&#2354;&#2379;&#2325;&#2357;&#2366;&#2352; &#2350;&#2366;&#2306;&#2327; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &#2325;&#2366; &#2357;&#2367;&#2340;&#2352;&#2339;
                                                                </td>
                                                            </tr>--%>
                                                           
                                                           
                                                            

                                                           

                                                            <tr>
                                                                <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                                    <!--Repeat data-->

                                                                  
                                                                    
                                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                                                        <Columns>
                                                                             <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                                                                            <asp:BoundField DataField="OrderNo" HeaderText="&#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; " />
                                                                            <asp:BoundField DataField="OrderDate" HeaderText="&#2310;&#2352;&#2381;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                                                                            <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                                                            <asp:BoundField DataField="NameofPress_V" HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                                                            <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                                                            <asp:BoundField DataField="SubTitleHindi_V" HeaderText="&#2313;&#2346;&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                                                            <asp:BoundField DataField="TotalNoOFBooks" HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; " />
                                                                        
                                                                       
                                                                             <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                                                                 <ItemTemplate>
                                                                                <%# Eval ("Pack") %> 
                                                                                 </ItemTemplate>
                                                                             </asp:TemplateField>
                                                                        
                                                                       
                                                                        </Columns>
                                                                    </asp:GridView>

                                                                  
                                                                    
                                                                </td>
                                                            </tr>


                                                            <%-- <tr>
                                                                <td colspan="4" style="font-size: 14px; font-weight: bold; text-align: right;line-height:2em;">
                                                                 &#2313;&#2346;&#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325; (&#2357;&#2367;&#2340;&#2352;&#2339; '&#2348;')<br />
                                                               &#2350;&#2343;&#2381;&#2351;&#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;<br />
                                                                       &#2349;&#2379;&#2346;&#2366;&#2354;
                                                                    </td>
                                                               
                                                                </tr>--%>
                                                        </table>
                                                   
                                             
                                    </div>
                                </center>
                            </div>
                        </td>
                    </tr>
                    </table>

            </div>

        </div>
    </div>
</asp:Content>

