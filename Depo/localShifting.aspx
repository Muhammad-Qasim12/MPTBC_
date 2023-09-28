<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="localShifting.aspx.cs" Inherits="Depo_localShifting" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="card-header">
                                <h2>&#2354;&#2379;&#2325;&#2354; &#2358;&#2367;&#2347;&#2381;&#2335;&#2367;&#2306;&#2327; </h2>
                            </div>

                            <div style="padding:0 10px;">
                                <table width="100%">
                                    <tr><td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td><td>
                                        <asp:TextBox ID="txtDate" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                                          <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
                     </cc1:CalendarExtender>
                                        </td><td>&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;</td><td>
                                        <asp:DropDownList ID="DdlACYear" runat="server">
                                        </asp:DropDownList>
                                        </td></tr>

                                    <tr><td>&#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; </td><td>
                                        <asp:TextBox ID="txtPaik" CssClass="txtbox reqirerd" runat="server" AutoPostBack="True" OnTextChanged="txtPaik_TextChanged"></asp:TextBox>
                                        </td><td>&#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; </td><td>
                                        <asp:TextBox ID="txtLooj" runat="server" CssClass="txtbox " ></asp:TextBox>
                                             
                                        </td></tr>

                                    <tr><td>&#2352;&#2366;&#2358;&#2367; </td><td>
                                       <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                        </td><td>&#2309;&#2346;&#2354;&#2379;&#2337; &#2352;&#2360;&#2368;&#2342; </td><td>
                                        <asp:FileUpload ID="FileUpload1" CssClass="txtbox" runat="server" />
                                        </td></tr>

                                    <tr><td colspan="4">
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn" onclick="btnSave_Click" OnClientClick="return ValidateAllTextForm();" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; " />
                                        </td></tr>

                                    <tr><td colspan="4">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="ID" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="DateD" HeaderText="&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                                                <asp:BoundField DataField="Year" HeaderText="&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;" />
                                                <asp:BoundField DataField="Paik" HeaderText="&#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; " />
                                                <asp:BoundField DataField="looj" HeaderText="&#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; " />
                                                <asp:BoundField HeaderText="&#2352;&#2366;&#2358;&#2367;" DataField="Amount" />
                                                <asp:CommandField ShowDeleteButton="True" />
                                            </Columns>
                                        </asp:GridView>
                                        </td></tr>

                                </table>
                                </div> 
</asp:Content>

