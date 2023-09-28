<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PaperDetails.aspx.cs" Inherits="Printing_PaperDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="box">
        <div class="card-header">
            <h2>
                Paper Details </h2>
        </div>
     <div class="box table-responsive">
            <table width="100%">
                <tr>
                    <td style="text-align: center">
                        &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td style="text-align: center">
                        <asp:DropDownList ID="ddlprinterName" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: center">
                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                    <td style="text-align: center">
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="TextBox4">
                        </cc1:CalendarExtender>
                    </td>
                    <td style="text-align: center">
                       
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2375;&#2326;&#2375;" />
                                
                                   </td>
                    
                </tr>
                <tr>
                    <td style="text-align: center" colspan="3">
                        <strong>&#2325;&#2369;&#2354; &#2354;&#2327;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2325;&#2366;&#2327;&#2332;</strong></td>
                    <td style="text-align: center" colspan="2">
                        <strong>&#2310;&#2342;&#2375;&#2358;&#2367;&#2340; &#2325;&#2366;&#2327;&#2332; </strong></td>
                    
                </tr>
                <tr>
                     <td style="text-align: center" colspan="5">
                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                             CssClass="tab">
                             <Columns>
                                 <asp:TemplateField HeaderText="GSM70">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt1" runat="server" CssClass="txtbox" Width="126px" 
                                             Text='<%# Eval("GSM70a") %>' ></asp:TextBox>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="GSM80">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt2" runat="server" CssClass="txtbox" Width="126px"  Text='<%# Eval("GSM80a") %>' ></asp:TextBox>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="GSM230">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt3" runat="server" CssClass="txtbox" Width="126px"  Text='<%# Eval("GSM230a") %>' ></asp:TextBox>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="GSM250">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt4" runat="server" CssClass="txtbox" Width="126px"  Text='<%# Eval("GSM250a") %>' ></asp:TextBox>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText=" GSM70">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt5" runat="server" CssClass="txtbox" Width="126px"  Text='<%# Eval("GSM70b") %>' ></asp:TextBox>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="GSM80">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt6" runat="server" CssClass="txtbox" Width="126px"  Text='<%# Eval("GSM80b") %>' ></asp:TextBox>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="GSM230">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt7" runat="server" CssClass="txtbox" Width="126px"  Text='<%# Eval("GSM230b") %>' ></asp:TextBox>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="GSM250">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt8" runat="server" CssClass="txtbox" Width="126px"  Text='<%# Eval("GSM250b") %>' ></asp:TextBox>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                             </Columns>
                         </asp:GridView>
                     </td>
                  
                </tr>
                <tr>
                    <td style="text-align: center" colspan="5">
                        <%--</asp:Panel>--%>
                        <%--</asp:Panel>--%>
                       
                        <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" 
                            Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " />
                                
                    </td>
                </tr>
                </table>
        </div>
    </div>
</asp:Content>

