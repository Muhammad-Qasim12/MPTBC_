<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="ViewRoleMaster.aspx.cs" Inherits="Admin_ViewRoleMaster" Title="&#2352;&#2379;&#2354; (निर्माण/सुधार) / Role (Insert/Update)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>&#2352;&#2379;&#2354; (निर्माण/सुधार) / Role (Insert/Update)</span></h2>
        </div>
        <div style="padding: 0 10px 15px;">
            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none;
                padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlRoleMaster" runat="server">
                <asp:Button ID="btnNewRole" OnClick="btnNewRole_Click" runat="server" Text="&#2344;&#2351;&#2366; &#2352;&#2379;&#2354;  &#2332;&#2379;&#2396;&#2375;&#2306; / Add New Role"
                    CssClass="btn"></asp:Button>
                <asp:GridView ID="gvRoleMaster" CssClass="tab" AutoGenerateColumns="false" PageSize="20"
                    DataKeyNames="Roletrno_I" AllowPaging="true" OnPageIndexChanging="gvRoleMaster_PageIndexChanging"
                    OnRowEditing="gvRoleMaster_RowEditing" OnRowDeleting="gvRoleMaster_RowDeleting"
                    runat="server">
                    <Columns>
                        <asp:BoundField DataField="Roletrno_I" Visible="false" ReadOnly="true" HeaderText="&#2352;&#2379;&#2354; &#2352;&#2381;&#2310;&#2312;. &#2337;&#2368;."/>
                        <asp:BoundField DataField="Role_V" ReadOnly="true" HeaderText="&#2352;&#2379;&#2354; / Role" />
                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn" CommandName="Edit"
                            Text="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;&#2306; / Edit" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" CssClass="btn" Visible="false" runat="server" CommandName="Delete" Text="&#2361;&#2335;&#2366;&#2319;&#2306; / Remove"
                                    OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                     <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
                <asp:HiddenField ID="hdnRoletrno" runat="server" />
            </asp:Panel>
            <asp:Panel ID="pnlNewRole" Visible="false" runat="server">
                <table>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblErrorMessage" Font-Bold ForeColor="Red" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &#2352;&#2379;&#2354 / Role
                        </td>
                        <td>
                            <asp:TextBox ID="txtRole" MaxLength="35" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; &#2344;&#2366;&#2350; / Module Name
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlModule" AutoPostBack="true" OnSelectedIndexChanged="ddlModule_OnSelectedIndexChanged"
                                runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:GridView AutoGenerateColumns="false" CssClass="tab" ID="gvRoleForms" runat="server">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="gvlblFormTrno" Visible="false" runat="server" Text='<%# Eval("FormTrno_I") %>'></asp:Label>
                                            <asp:CheckBox ID="chkSelectForm" Checked='<%# Convert.ToBoolean(Eval("CheckStatus")) %>'
                                                runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ReadOnly="true" DataField="ModuleName_V" HeaderText="&#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; &#2344;&#2366;&#2350; / Module Name" />
                                    <asp:BoundField ReadOnly="true" DataField="SubModuleName_V" HeaderText="&#2360;&#2348; &#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; &#2344;&#2366;&#2350; / Sub Module Name" />
                                    <asp:BoundField ReadOnly="true" DataField="FormDesc_V" HeaderText="&#2347;&#2377;&#2352;&#2381;&#2350; / Form" />
                                    <asp:BoundField ReadOnly="true" DataField="FormPath_V" HeaderText="&#2347;&#2377;&#2352;&#2381;&#2350; &#2346;&#2366;&#2341; / Form Path" />
                                    <asp:BoundField ReadOnly="true" DataField="Status_V" HeaderText="&#2347;&#2377;&#2352;&#2381;&#2350; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; / Form Type" />
                                </Columns>
                                 <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="2">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; / Save"
                                OnClientClick='javascript:return ValidateAllTextForm();' CssClass="btn"></asp:Button>
                        </td>
                        <td style="text-align: center" colspan="2">
                            <asp:Button ID="btnClose" OnClick="btnClose_Click" runat="server" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; / Close"
                                CssClass="btn"></asp:Button>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
