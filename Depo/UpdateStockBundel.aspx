<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateStockBundel.aspx.cs" Inherits="Depo_UpdateStockBundel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <div class="card-header">
            <h2>&#2348;&#2306;&#2337;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; </h2>
        </div>
        <div style="padding: 0 10px;">

            <table width="100%">
                <tr>
                    <td class="auto-style1">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; :</td>
                    <td>

                    &nbsp;<asp:DropDownList ID="ddlSessionYear" runat="server">
                        </asp:DropDownList>

                    </td><td>&nbsp;</td><td>
                    &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;
                    </td>
                    <td>

                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
                    </asp:DropDownList>

                    </td><td>&#2325;&#2325;&#2381;&#2359;&#2366; / Class</td><td>
                    <asp:DropDownList ID="DDLClass" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="DDLClass_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select..</asp:ListItem>
                        <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                        <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                    </asp:DropDownList>
                
                        </td>
                </tr>
                <tr>
                    <td class="auto-style1">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;&nbsp;&nbsp;&nbsp;</td>
                    <td>

                        <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox" OnSelectedIndexChanged="ddlTital_SelectedIndexChanged">
                        </asp:DropDownList>
                
                    </td><td colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="4">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" Width="879px" DataKeyNames="StockDetailsChildID_I" OnRowDeleting="GridView1_RowDeleting">
                            <Columns>
                                 <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352;">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                        </ItemTemplate> </asp:TemplateField> 
                                <asp:BoundField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="TitleEnglish_V" />
                                <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; " DataField="BundleType_I" />
                      
                                <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352;">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("StockDetailsChildID_I") %>'/>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("BundleNo_I") %>' Width="112px" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;. &#2360;&#2375; ">
                                     <ItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("FromNo_I") %>' Width="112px" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;. &#2340;&#2325; ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("ToNo_I") %>' Width="112px" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="4">
                        <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2367;&#2351;&#2375; &#2337;&#2366;&#2335;&#2366; &#2325;&#2379; &#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " />
                    </td>
                </tr>
                </table> 
        </div> 
</asp:Content>

