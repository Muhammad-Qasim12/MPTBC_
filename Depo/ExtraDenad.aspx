<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ExtraDenad.aspx.cs" Inherits="Depo_ExtraDenad" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <script type = "text/javascript">
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
                <span>
                    <asp:Label ID="lblTitleName" runat="server">&#2310;&#2357;&#2358;&#2381;&#2325;&#2340;&#2366; &#2325;&#2368; &#2346;&#2370;&#2352;&#2381;&#2340;&#2367; &#2325;&#2375; &#2354;&#2367;&#2319; RKS &#2325;&#2375; &#2309;&#2340;&#2367;&#2352;&#2367;&#2325;&#2381;&#2340; &#2337;&#2367;&#2350;&#2366;&#2306;&#2337;  </asp:Label>
                </span></h2>
        </div>

        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                 <asp:Panel class="response-msg inf ui-corner-all" runat="server" ID="mainDiv" Style="display: block; padding-top: 10px; padding-bottom: 10px;">
                            <asp:Label ID="lblmsg" class="notification" runat="server" Text="&#2337;&#2366;&#2335;&#2366; &#2342;&#2375;&#2326;&#2344;&#2375; &#2325;&#2368; &#2354;&#2367;&#2319; &#2325;&#2371;&#2346;&#2351;&#2366; &#2360;&#2349;&#2368; &#2310;&#2346;&#2381;&#2358;&#2344; &#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335; &#2325;&#2352;&#2375; / Please Select All Options To View Data ">
                                </asp:Label>
                        </asp:Panel>
                 <asp:Panel ID="Panel1" runat="server"><table width="100%">
                   <tr>
                        <td>
                            <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;<br /> Academic Year :</asp:Label>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            </asp:DropDownList>


                        </td>

                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblDepot" runat="server">&#2337;&#2367;&#2346;&#2379; <br /> Depot :</asp:Label>
                            <asp:DropDownList ID="DDlDepot" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                        </td>


                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblScheme" runat="server">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;  <br /> Medium :</asp:Label>
                            <asp:DropDownList ID="DdlScheme" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                        </td>


                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblClass" runat="server">&#2325;&#2325;&#2381;&#2359;&#2366; <br /> Class :</asp:Label>
                            <asp:DropDownList ID="DDLClass" runat="server" CssClass="txtbox"
                                >
                                 <asp:ListItem Text="Select.." Value="0"></asp:ListItem>
                                <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                                <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                            </asp:DropDownList>


                        </td>

                        <td style="width: 30%; font-size: medium;" valign="top">
                            &#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; :
                            <asp:TextBox ID="TextBox1" runat="server" Width="136px"></asp:TextBox>
                        </td>


                        <td style="width: 30%; font-size: medium;" valign="top">
                            &#2310;&#2352;&#2381;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; :
                            <asp:TextBox ID="TextBox2" runat="server" Width="128px"></asp:TextBox>
                             <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                            TargetControlID="TextBox2" Format="dd/MM/yyyy"></cc1:CalendarExtender> 
                        </td>


                    </tr>
                     <tr>
                         <td>
                             <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="300px">
                                 <asp:ListItem Selected="True" Value="3">&#2360;&#2349;&#2368;</asp:ListItem>
                                 <asp:ListItem Value="1">&#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2367;&#2340; </asp:ListItem>
                                 <asp:ListItem Value="2">&#2309;&#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2367;&#2340; </asp:ListItem>
                             </asp:RadioButtonList>
                         </td>
                         <td colspan="2" style="font-size: medium;" valign="top">
                            
                             (&#2351;&#2342;&#2367; &#2350;&#2366;&#2306;&#2327; &#2360;&#2306;&#2358;&#2379;&#2343;&#2367;&#2340; &#2361;&#2376; &#2340;&#2379; &#2330;&#2375;&#2325; &#2348;&#2366;&#2325;&#2381;&#2360; &#2350;&#2375;&#2306; &#2330;&#2375;&#2325; &#2325;&#2352;&#2375; )</td>
                     </tr>
                    <tr>

                        <td style="width: 30%; font-size: medium;" valign="top">
                            &nbsp;</td>

                        <td style="font-size: medium;" valign="top" colspan="2">
                            
                            <asp:Button ID="Button2" runat="server" Text="&#2337;&#2366;&#2335;&#2366; &#2342;&#2375;&#2326;&#2375; " CssClass="btn" OnClick="Button2_Click" />
                              <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Print" OnClientClick="return PrintPanel();"  />
                            &nbsp;<asp:Button ID="btnExport" runat="server" CssClass="btn" OnClick="btnExport_Click" Text="Export to Excel" />
                        </td>

                    </tr>
                    <tr>

                        <td style="font-size: medium;" valign="top" colspan="3">
                            <div id="ExportDiv" runat="server" >

                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2360;.&#2325;&#2381;&#2352;.">
                                        <ItemTemplate>
                                            
                                                     <%#Container.DataItemIndex+1 %>

                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("TitleId_I")%>' /> 
                                              
                                            <asp:CheckBox ID="CheckBox2" runat="server" />   
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                        <ItemTemplate>
                                            <%#Eval("TitleHindi_V")%>
                                         
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                        <ItemTemplate>
                                            <%#Eval("BookNumber")%>
                                            <asp:TextBox ID="txtPerBundle" runat="server" MaxLength="3" Width="40px"  Text='<%#Eval("BookNumber")%>'  AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" Visible="false" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                  
                                     <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2325;&#2375; &#2350;&#2366;&#2344; &#2360;&#2375; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSchemcDe" runat="server" Text="0"    ></asp:TextBox>
                                   
                                        </ItemTemplate>

                                    </asp:TemplateField> 
                                    
                                      <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2325;&#2375; &#2350;&#2366;&#2344; &#2360;&#2375; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtOpnMkt" runat="server" Text="0"    ></asp:TextBox>
                                   
                                        </ItemTemplate>

                                    </asp:TemplateField> 
                                   
                                     
                                    
                                   
                                      </Columns>
                            </asp:GridView></div> 
                        </td>

                    </tr>
                    <tr>

                        <td style="font-size: medium;" valign="top">
                            
                          
                            
                        </td>

                    </tr>
                </table></asp:Panel>   <asp:Button ID="Button3" runat="server" Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2358;&#2366;&#2326;&#2366; &#2325;&#2379; &#2349;&#2375;&#2332;&#2375; " CssClass="btn" OnClick="Button3_Click" Visible="False" />
                <div style="overflow: auto" class="rdlc">
                </div>
            </div>
        </div>
    </div>
           
</asp:Content>

