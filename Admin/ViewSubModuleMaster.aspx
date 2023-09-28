<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="ViewSubModuleMaster.aspx.cs" Inherits="Admin_ViewSubModuleMaster" Title="&#2360;&#2348; &#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; (निर्माण/सुधार) / Sub Module (Insert/Update)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive ">
        <div class="headlines">
            <h2>
                <span>&#2360;&#2348; &#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; (निर्माण/सुधार) / Sub Module (Insert/Update)</span></h2>
        </div>
        <div style="padding: 0 10px 15px;">
            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlSubModuleMaster" runat="server">
                <asp:Button ID="btnNewSubModule" OnClick="btnNewSubModule_Click" runat="server" Text="&#2344;&#2351;&#2366; &#2360;&#2348; &#2350;&#2377;&#2337;&#2351;&#2370;&#2354; &#2332;&#2379;&#2396;&#2375;&#2306; / Add New Sub Module"
                    CssClass="btn"></asp:Button>
                <asp:GridView ID="gvSubModuleMaster" CssClass="tab" AutoGenerateColumns="False" PageSize="20"
                    AllowPaging="True" OnPageIndexChanging="gvSubModuleMaster_PageIndexChanging"
                    DataKeyNames="SubModuleTrno_I" OnRowEditing="gvSubModuleMaster_RowEditing" OnRowDeleting="gvSubModuleMaster_RowDeleting"
                    runat="server" OnSelectedIndexChanged="gvSubModuleMaster_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="SubModuleTrno_I" Visible="false" ReadOnly="true" HeaderText=" &#2360;&#2348; &#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; &#2310;&#2312;. &#2337;&#2368;. / Sub Module ID" />
                        <asp:BoundField DataField="ModuleName_V" ReadOnly="true" HeaderText="&#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; &#2344;&#2366;&#2350; / Module Name" />
                        <asp:BoundField DataField="SubModuleName_V" ReadOnly="true" HeaderText="&#2360;&#2348; &#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; / Sub Module" />
                        <asp:BoundField DataField="ModuleTrno_I" Visible="false" ReadOnly="true" HeaderText="&#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; &#2344;&#2366;&#2350; / Module Name" />

                        <asp:BoundField DataField="Path" ReadOnly="true" HeaderText="&#2347;&#2377;&#2352;&#2381;&#2350; &#2346;&#2366;&#2341; / Form Path" />
                        <asp:BoundField DataField="OrderNo" ReadOnly="true" HeaderText="&#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; / Order No." />


                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn" CommandName="Edit"
                            Text="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;&#2306; / Edit">
                            <ControlStyle CssClass="btn" />
                        </asp:ButtonField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="gvlblModuleTrno_I" Visible="false" runat="server" Text='<%# Eval("ModuleTrno_I") %>'></asp:Label>
                                <asp:Button ID="btnDelete" CssClass="btn" Visible="false" runat="server" CommandName="Delete" Text="&#2361;&#2335;&#2366;&#2319;&#2306; / Remove"
                                    OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
                <asp:HiddenField ID="hdnSubModuleId" runat="server" />
            </asp:Panel>
            <asp:Panel ID="pnlNewSubModule" Visible="false" runat="server">
                <table>
                    <tr>
                        <td width="15%">&#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; &#2344;&#2366;&#2350; / Module Name
                        </td>
                        <td width="85%">
                            <asp:DropDownList ID="ddlModule" CssClass="txtbox" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>&#2360;&#2348; &#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; &#2344;&#2366;&#2350; / Sub Module Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtSubModuleName" MaxLength="100" runat="server" CssClass="txtbox reqirerd">
                            </asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>&#2347;&#2377;&#2352;&#2381;&#2350; &#2346;&#2366;&#2341; / Form Path
                        </td>
                        <td>
                            <asp:TextBox ID="txtPath" MaxLength="100" runat="server" CssClass="txtbox">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; / Order No.
                        </td>
                        <td>
                            <asp:TextBox ID="txtOrderNo" MaxLength="30" runat="server" CssClass="txtbox reqirerd">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="2">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; / Save"
                                OnClientClick='javascript:return ValidateAllTextForm();' CssClass="btn"></asp:Button>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>

</asp:Content>
