<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Formate11.aspx.cs" Inherits="Depo_Formate11" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>

   <%--  <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                            <ProgressTemplate>
                                <div class="fade">
                                </div>
                                <div class="progress">
                                    <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                                </div>
                            </ProgressTemplate>
                            </asp:UpdateProgress>--%>
    <div class="box">
        <div class="card-header">
            <h2>&#2349;&#2380;&#2340;&#2367;&#2325; &#2360;&#2340;&#2381;&#2351;&#2366;&#2346;&#2344; &#2346;&#2381;&#2352;&#2346;&#2340;&#2381;&#2352; -11</h2>
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
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                <Columns>
                                     <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                    <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="TitleHindi_V" />
                                    <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2368; &#2346;&#2370;&#2360;&#2381;&#2340;&#2325;">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval ("RemainYojna") %>'></asp:Label>  
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("TitleID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; ">
                                          <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval ("RemainSamany") %>'></asp:Label>  
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2349;&#2380;&#2340;&#2367;&#2325;&#2368; &#2360;&#2340;&#2381;&#2351;&#2366;&#2346;&#2344; &#2350;&#2375;&#2306;  &#2346;&#2366;&#2312; (&#2351;&#2379;&#2332;&#2344;&#2366; )">
                                         <ItemTemplate>

                                             <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval ("RemainYojna") %>'></asp:TextBox>
                                         </ItemTemplate> 

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2349;&#2380;&#2340;&#2367;&#2325;&#2368; &#2360;&#2340;&#2381;&#2351;&#2366;&#2346;&#2344; &#2350;&#2375;&#2306;  &#2346;&#2366;&#2312; (&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; )">
                                         <ItemTemplate>

                                             <asp:TextBox ID="TextBox2" runat="server" Text='<%#Eval ("RemainSamany") %>'></asp:TextBox>
                                         </ItemTemplate> 

                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="Save" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;</td>
                    </tr>
                </table> </div> </ContentTemplate> </asp:UpdatePanel> 
</asp:Content>

