<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CPDTrnsContactPerson.aspx.cs" Inherits="CenterDepot_CPDTrnsContactPerson" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;
    </div>
    <div class="table-responsive">
        <table width="100%">
            <tr style="display:none;">
                <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;/ Year :</td>
                <td>
                    <asp:DropDownList ID="DdlACYear" Width="100px" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label Width="144px" ID="Label7" runat="server">&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; / Printer</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DDLPrinter" runat="server" Visible="false">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352;&nbsp; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                <td>
                    <asp:TextBox ID="txt1" runat="server" Visible="false"></asp:TextBox>
                     <asp:DropDownList ID="ddlTransporter" runat="server" >
                    </asp:DropDownList>
                </td>
                <td>Contact No </td>
                <td>
                    <asp:TextBox ID="txt2" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtContactNo" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Contact Person</td>
                <td>
                    <asp:TextBox ID="txtContactPerson" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Save" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="ID" OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting">
                        <Columns><asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                            <asp:BoundField DataField="Transportername" HeaderText="&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;" />
                            <asp:BoundField DataField="Contactperson" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                            <asp:BoundField DataField="ContactNO" HeaderText="&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352;&nbsp; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                          
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

