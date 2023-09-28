<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VitranOrder.aspx.cs" Inherits="Depo_VitranOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box table-responsive">
                <div class="card-header"> &#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; 
                </div>

         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
             <Columns>
                  <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <table width="90%" >
                             <tr><td align="left">
                        <%# Eval("PrinterName") %> दिनांक : <%# Eval ("VitranDate") %>  कुल पुस्तक : <%#Eval ("NoOfBooks") %>
                                 </td></tr>
                             </table>
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
                </asp:GridView>
         </div> 
</asp:Content>

