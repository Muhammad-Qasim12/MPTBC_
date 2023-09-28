<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CategoryMas.aspx.cs" Inherits="Depo_CategoryMas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="card-header">
                                <h2>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2325;&#2368; &#2325;&#2335;&#2375;&#2327;&#2352;&#2368;</h2>
                            </div>

                            <div style="padding:0 10px;">
                                <table width="100%">
                                    <tr><td>&#2325;&#2335;&#2375;&#2327;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; </td><td>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="txtbox"></asp:TextBox>
                                        </td></tr>
                                    <tr><td>&#2337;&#2367;&#2360;&#2381;&#2325;&#2366;&#2313;&#2306;&#2335; &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; </td><td>
                                        <asp:TextBox ID="txtAmount" runat="server" CssClass="txtbox"  onkeypress='javascript:tbx_fnNumeric(event, this);' ></asp:TextBox>
                                        </td></tr>
                                    <tr><td colspan="2">
                                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Save" />
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                            <Columns>
                                                <asp:BoundField DataField="CategoryName" HeaderText="&#2325;&#2335;&#2375;&#2327;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                                <asp:BoundField DataField="Amount" HeaderText="&#2337;&#2367;&#2360;&#2381;&#2325;&#2366;&#2313;&#2306;&#2335; &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340;" />
                                            </Columns>
                                        </asp:GridView>
                                        </td></tr>
                                    <tr><td colspan="2">
                                        &nbsp;</td></tr>
                                </table>

                            </div> 
</asp:Content>

