<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BankMaster.aspx.cs" Inherits="Depo_BankMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                &#2348;&#2376;&#2306;&#2325;<span>&nbsp; &#2350;&#2366;&#2360;&#2381;&#2335;&#2352;</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td>
                        &#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
                    <td>
                        <asp:TextBox ID="txtHeadname" runat="server" CssClass="txtbox reqirerd" MaxLength="40" onkeypress="javascript:tbx_fnAlphaOnly(event, this)"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; "   OnClientClick="return ValidateAllTextForm();"
                            onclick="btnSave_Click" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="BankId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                <asp:BoundField DataField="BankName" HeaderText="BankName" />
                                <asp:CommandField ShowSelectButton="True" HeaderText="Update" />
                            </Columns>
                        </asp:GridView>
                        
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
</asp:Content>

