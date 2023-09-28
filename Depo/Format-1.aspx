<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Format-1.aspx.cs" Inherits="Depo_Format_1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 249px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
       <asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>

     <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                            <ProgressTemplate>
                                <div class="fade">
                                </div>
                                <div class="progress">
                                    <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                                </div>
                            </ProgressTemplate>
                            </asp:UpdateProgress>
    <div class="box">
        <div class="card-header">
            <h2>&#2349;&#2380;&#2340;&#2367;&#2325; &#2360;&#2340;&#2381;&#2351;&#2366;&#2346;&#2344; &#2346;&#2381;&#2352;&#2346;&#2340;&#2381;&#2352; -1</h2>
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
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&#2360;&#2340;&#2381;&#2351;&#2366;&#2346;&#2344; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
                        <td class="auto-style1">
                            <asp:DropDownList ID="ddlPEmp" runat="server" CssClass="txtbox reqirerd">
                            </asp:DropDownList>


                        </td>
                        <td>&#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2357;&#2344;&#2381;&#2343;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                        <td>
                            <asp:DropDownList ID="ddlDepoManager" runat="server" CssClass="txtbox reqirerd">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>&#2360;&#2381;&#2335;&#2379;&#2352; &#2325;&#2368;&#2346;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                        <td class="auto-style1">
                            <asp:DropDownList ID="ddlstoreKee" runat="server" CssClass="txtbox reqirerd">
                            </asp:DropDownList>


                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Data" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">

                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                <Columns>
                                     <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                    <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />

                                    <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2352;&#2350;&#2381;&#2349;&#2367;&#2325; &#2358;&#2375;&#2359; (&#2351;&#2379;&#2332;&#2344;&#2366;)">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("TitleID") %>' />
                                            <asp:TextBox ID="txt1" runat="server" Width="84px" Text='<%# Eval ("YojanaBook") %>' AutoPostBack="True" OnTextChanged="txt1_TextChanged"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2352;&#2350;&#2381;&#2349;&#2367;&#2325; &#2358;&#2375;&#2359; (&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;)">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt2" runat="server" Width="84px" Text='<%# Eval ("samanyBook") %>' AutoPostBack="True" OnTextChanged="txt2_TextChanged"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; (&#2351;&#2379;&#2332;&#2344;&#2366;)">
                                        <ItemTemplate>
                                          <asp:TextBox ID="txt3" runat="server" Width="84px" Text='<%# Eval ("NoOfbookYojana") %>' AutoPostBack="True" OnTextChanged="txt3_TextChanged"  ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; (&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;)">
                                        <ItemTemplate>
                                         <asp:TextBox ID="txt4" runat="server" Width="84px" Text='<%# Eval ("NoOfBookSamanya") %>' AutoPostBack="True" OnTextChanged="txt4_TextChanged"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2309;&#2344;&#2381;&#2340;&#2337;&#2367;&#2352;&#2381;&#2346;&#2379; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; (&#2351;&#2379;&#2332;&#2344;&#2366;)">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt5" runat="server" Width="84px" Text='<%# Eval ("InterDepoYojna") %>' AutoPostBack="True" OnTextChanged="txt5_TextChanged"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2309;&#2344;&#2381;&#2340;&#2337;&#2367;&#2352;&#2381;&#2346;&#2379; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;(&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;)">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt6" runat="server" Width="84px" Text='<%# Eval ("InterNoOfBookSamanya") %>' AutoPostBack="True" OnTextChanged="txt6_TextChanged"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2366; &#2351;&#2379;&#2327; ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt7" runat="server" Width="84px" Text='<%# Eval ("YojnaTotal") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2325;&#2366; &#2351;&#2379;&#2327; ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt8" runat="server" Width="84px" Text='<%# Eval ("samanyTotal") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2351;&#2379;&#2327; ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt9" runat="server" Width="84px" Text='<%# Eval ("Total") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">

                            <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="Save" Visible="False" OnClientClick="return ValidateAllTextForm();" />

                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </ContentTemplate> </asp:UpdatePanel>
</asp:Content>

