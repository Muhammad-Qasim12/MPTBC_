<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OtherDistribution.aspx.cs" Inherits="Depo_OtherDistribution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>&#2309;&#2344;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">

                <table width="100%">
                    <tr>
                        <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;</td>
                        <td class="auto-style1">
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            </asp:DropDownList>


                        </td>
                        <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; </td>
                        <td>
                            <asp:DropDownList ID="DdlScheme" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>&#2325;&#2325;&#2381;&#2359;&#2366; </td>
                        <td class="auto-style1">
                            <asp:DropDownList ID="DDLClass" runat="server" CssClass="txtbox">
                                <asp:ListItem Text="Select.." Value="0"></asp:ListItem>
                                <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                                <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                            </asp:DropDownList>


                        </td>
                        <td colspan="2">
                            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Report" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                        <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("TitleID_I") %>' />
                                                 </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                    <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;  &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%#Eval ("Yojna") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval ("Samany") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            </td> </tr> 
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Save" CssClass="btn" />
                            </td> </tr> </table> </div> 
</asp:Content>

