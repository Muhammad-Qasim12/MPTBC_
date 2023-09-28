<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoojBundleDetails.aspx.cs" Inherits="Depo_LoojBundleDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>
<%--   <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                            <ProgressTemplate>
                                <div class="fade">
                                </div>
                                <div class="progress">
                                    <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                                </div>
                            </ProgressTemplate>
                            </asp:UpdateProgress>
    --%>
     <div class="box">
                    <div class="card-header">
                     <h2> &#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2379; &#2354;&#2370;&#2332; &#2348;&#2339;&#2381;&#2337;&#2354; &#2350;&#2375;&#2306; &#2348;&#2342;&#2354;&#2375;</h2>
                          
                    </div>

                     <table style="width: 100%">
                <tr>
                    <td style="font-size: medium;">
                      &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / Medium</td>
                    <td>
                        <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd"  >
                        </asp:DropDownList>
                    </td>
                    <td style="width: 30%; font-size: medium;" valign="top">
                        &#2325;&#2325;&#2381;&#2359;&#2366; / Class</td>
                    <td style="font-size: medium;">
                        
                        <asp:DropDownList ID="ddlCls" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCls_SelectedIndexChanged" CssClass="txtbox reqirerd"  >
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: medium;">
                        &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; </td>
                    <td>
                        <asp:DropDownList ID="ddlfyyear" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 30%; font-size: medium;" valign="top">
                        &#2357;&#2367;&#2359;&#2351; / Subject</td>
                    <td style="font-size: medium;">
                        
                        <asp:DropDownList ID="ddlsubject" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlsubject_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: medium;">
                        &#2335;&#2379;&#2335;&#2354; &#2348;&#2339;&#2381;&#2337;&#2354; &#2354;&#2370;&#2332; &#2350;&#2375;&#2306; &#2348;&#2342;&#2354;&#2344;&#2375; &#2361;&#2375;&#2340;&#2369; </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnSignedInteger(event, this);" OnTextChanged="TextBox1_TextChanged" MaxLength="2"></asp:TextBox>
                    </td>
                    <td style="width: 30%; font-size: medium;" valign="top">
                        &nbsp;</td>
                    <td style="font-size: medium;">
                        
                        <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="&#2360;&#2381;&#2335;&#2377;&#2325; &#2342;&#2375;&#2326;&#2375;&#2306; " Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td style="font-size: medium;" colspan="4">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns>
                                <asp:BoundField DataField="Sno" HeaderText="&#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; " />
                                <asp:TemplateField HeaderText="&#2348;&#2339;&#2381;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; " >
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="txtbox reqirerd"  onkeypress='javascript:tbx_fnSignedInteger(event, this);' Text='<%# Eval("BandalNo") %>' AutoPostBack="True" OnTextChanged="TextBox2_TextChanged" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: medium;" colspan="4">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click" OnClientClick="javascript:return ValidateAllTextForm();" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save  " />
                    </td>
                </tr>
                <tr>
                    <td style="font-size: medium;" colspan="4">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns>
                              <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2348;&#2339;&#2381;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; " >
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("BandalNuber")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr></table> </div> 
                 
     <div id="Div7" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Div8" style="display: none;" class="popupnew1" runat="server" >
                <asp:Button ID="B13" runat="server" CssClass="btn" OnClick="B13_Click"  Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " />
                <asp:GridView ID="grd15" runat="server" AutoGenerateColumns="False" CssClass="tab">
            <Columns>
                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &lt;br&gt; 1">
                    <ItemTemplate>
                       <%# Container.DataItemIndex +1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; &lt;br&gt; 2">
                     <ItemTemplate>
                         <%# Eval("Title") %>
                     </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  &lt;br&gt; 3">
                     <ItemTemplate>
                         <%# Eval("cnt1") %>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2375; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; ">
                    <ItemTemplate>
                        <asp:Panel ID="Panel1" runat="server" Width="200px" ScrollBars="Both" Height="200px">
                       
                         <%# Eval("bundlesS") %></asp:Panel>
                     </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                </div>                  
</ContentTemplate>

</asp:UpdatePanel>
</asp:Content>

