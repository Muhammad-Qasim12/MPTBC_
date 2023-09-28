<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW_DPT005.aspx.cs" Inherits="Depo_VIEW_DPT005" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box">
        <div class="card-header">
            <h2>
                <span>हेड मास्टर</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="नया डाटा डाले"   
                            onclick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdHead" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="HeadID_I" 
                            
                            AllowPaging="True" 
                            onpageindexchanging="GrdHead_PageIndexChanging" 
                            onrowcommand="GrdHead_RowCommand">
                            <Columns> 
                             <asp:BoundField HeaderText="वित्तीय मद नाम " DataField="HeadName_V" />
                                                               
                                <asp:TemplateField HeaderText="डाटा में सुधार करे">
                                    <ItemTemplate>
                                        <a href="DPT005_HeadMaster.aspx?ID=<%#Eval("HeadID_I") %>">डाटा में सुधार करे</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="डाटा हटाये">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgbtnDelete" runat="server" CommandArgument='<%# Eval("HeadID_I") %>'
                                                    CommandName="eDelete" ImageUrl="" CssClass="btn" AlternateText="डाटा हटाये" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
</asp:Content>

