<%@ Page Title="&#2357;&#2367;&#2325;&#2366;&#2360;&#2326;&#2306;&#2337; (&#2344;&#2367;&#2352;&#2381;&#2350;&#2366;&#2339;/&#2360;&#2369;&#2343;&#2366;&#2352;) / Block (Insert/Update)" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewBlock.aspx.cs" Inherits="Admin_ViewBlock" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>&#2357;&#2367;&#2325;&#2366;&#2360;&#2326;&#2306;&#2337; (&#2344;&#2367;&#2352;&#2381;&#2350;&#2366;&#2339;/&#2360;&#2369;&#2343;&#2366;&#2352;) / Block (Insert/Update)</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
              <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none;
                padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; / New Entry" OnClick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdBlockmaster" runat="server" AutoGenerateColumns="False" 
                            PageSize="30" CssClass="tab"
                            DataKeyNames="BlockTrno_I" OnRowDeleting="GrdAdvanceDetails_RowDeleting" AllowPaging="True"
                            OnPageIndexChanging="GrdAdvanceDetails_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No." DataField="BlockTrno_I" />
                                <asp:BoundField HeaderText=" &#2332;&#2367;&#2354;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;  District Name" DataField="District_Name_Hindi_V" />
                                <asp:BoundField HeaderText="&#2357;&#2367;&#2325;&#2366;&#2360;&#2326;&#2306;&#2337; &#2325;&#2366; &#2344;&#2366;&#2350; &#2311;&#2306;&#2327;&#2381;&#2354;&#2367;&#2358; &#2350;&#2375;&#2306; / Block Name In hindi " DataField="Blockname_v" />
                                <asp:BoundField HeaderText="&#2357;&#2367;&#2325;&#2366;&#2360;&#2326;&#2306;&#2337; &#2325;&#2366; &#2344;&#2366;&#2350; &#2361;&#2367;&#2306;&#2342;&#2368; &#2350;&#2375;&#2306; / Block Name In English" DataField="BlockNameHindi_V" />
                                <asp:BoundField HeaderText="Sr.No" DataField="SrNo" />
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit">
                                    <ItemTemplate>
                                        <a href="BlockMaster.aspx?ID=<%# new APIProcedure().Encrypt(Eval("BlockTrno_I").ToString()) %>">&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                         <asp:Button ID="btnDelete" CssClass="btn" Visible="false" runat="server" CommandName="Delete" Text="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; / Remove"
                                    OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>                               
                            </Columns>
                             <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
