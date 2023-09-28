<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterSelectGroup.aspx.cs" Inherits="Printing_PrinterSelectGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="portlet-header ui-widget-header">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2375; &#2327;&#2381;&#2352;&#2369;&#2346; &#2350;&#2375;&#2306; &#2357;&#2352;&#2368;&#2351;&#2340;&#2366; &#2360;&#2369;&#2344;&#2367;&#2358;&#2367;&#2340; &#2325;&#2352;&#2375;  </div>
                     <div class="portlet-content">
                     <div class="table-responsive">
                     
                     <asp:Panel ID="messDiv" runat="server" >
        <asp:Label runat="server" ID="lblMess" class="notification" ></asp:Label>
        </asp:Panel> 


                    
                   <table width="100%">
                   
                   <tr>
                   <td>&nbsp;</td>
                   <td>
                  <%-- <asp:RadioButtonList ID="RbHDR" runat="server" RepeatDirection="Horizontal"  >
                   <asp:ListItem Text="Yes" Value="Yes" Selected ="True" ></asp:ListItem>
                   <asp:ListItem Text="No" Value="No"  ></asp:ListItem>
                   </asp:RadioButtonList>--%>
                   </td>

                   </tr>
                   
                   <tr>
                   <td colspan="2" align="center">
                   <asp:GridView ID="GrdEval" runat="server" CssClass="tab hastable" AutoGenerateColumns="false"   >
                       <Columns>
                         <asp:TemplateField>
                         <ItemTemplate>
                         <%--<asp:CheckBox runat="server" ID="chk" />--%>

                        <%-- <asp:HyperLink runat="server" ID="hypPRIReg" Text="Register" Target="_blank" ></asp:HyperLink>--%>
                              <%#Container.DataItemIndex+1 %>
                       <asp:HiddenField runat="server" ID="HdnPriId" Value='<%# Eval("PrinterId") %>' ></asp:HiddenField>

                        

                         </ItemTemplate>
                         </asp:TemplateField>
                         
                         <asp:TemplateField HeaderText="Printer Name" >
                         <ItemTemplate>
                             <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text='<%#Eval("CompanyName") %>' CommandArgument='<%#Eval("CompanyName") %>' />
                              </ItemTemplate>
                         </asp:TemplateField>
                         
                         
                        


                        

                       </Columns>
                       <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                       
                  
                       
                   </asp:GridView> 
                   
                   </td>
                   </tr>
                   <tr>
                   <td>
                       <asp:HiddenField ID="HiddenField1" runat="server" />
                   </td>
                   
                   </tr>


                   </table>


                     </div> </div> 
     <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
            </div>
   
            <div id="Messages" style="display: none;" class="popupnew1" runat="server">
                <asp:Label ID="Label1" runat="server" Text="" ></asp:Label>
                <asp:GridView ID="GridView1" runat="server" CssClass="tab hastable" AutoGenerateColumns="false"  FooterStyle-BackColor="White"    >
                       <Columns>
                         <asp:TemplateField>
                         <ItemTemplate> <%#Container.DataItemIndex+1 %>
                       <%--  <asp:CheckBox runat="server" ID="chk"  OnCheckedChanged="chkChoose_CheckedChanged" />--%>
                             <asp:HiddenField ID="HiddenField4" runat="server" Value='<%#Eval("PrinterCapecity") %>' />
                             <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("qty") %>' />
                              <asp:HiddenField ID="HiddenField3" runat="server" Value='<%#Eval("color") %>' />
                         </ItemTemplate>
                         </asp:TemplateField>
                         
                         <asp:BoundField DataField="GroupNO" HeaderText="Group Name" />
                         <asp:BoundField DataField="Company" HeaderText="Printer Name" />
                         <asp:BoundField DataField="Rates" HeaderText="Rates" />
                         <asp:BoundField DataField="Rank" HeaderText="Status" />

                            <asp:BoundField DataField="qty" HeaderText="Quantity" />
                        
                            <asp:TemplateField HeaderText="Priority NO">
                         <ItemTemplate>
                             <asp:TextBox ID="TextBox1" onkeypress='javascript:tbx_fnInteger(event, this);' runat="server" Width="50px" MaxLength="2" Text='<%#Eval("priorityNo")%>'></asp:TextBox>
                         </ItemTemplate>
                         </asp:TemplateField>
                       </Columns>
                       <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                       
                  
                       
                   </asp:GridView>
                
                <asp:Button ID="Button2" OnClick="Button2_Click" CssClass="btn" runat="server" Text="Close" />
                                  <asp:Button runat="server" ID="btnSave" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;/Save " 
                           OnClick="btnSave_Click" />
                       
                  </div> 
</asp:Content>

