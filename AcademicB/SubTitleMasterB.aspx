<%@ Page Title="&#2313;&#2346; - &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="SubTitleMasterB.aspx.cs" Inherits="AcademicB_SubTitleMasterB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>&#2313;&#2346; -&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;/Sub-Title Information</span></h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%" class="table">
                <tr>
                    <td>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;/Title
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTitle" Enabled="false" CssClass="txtbox" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%-- &#2313;&#2346; - &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; &#2311;&#2306;&#2327;&#2381;&#2354;&#2367;&#2358; &#2350;&#2375;&#2306;--%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubTitleEnglish" Visible="false" MaxLength="200" CssClass="txtbox reqirerd"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&#2313;&#2346; - &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; &#2361;&#2367;&#2306;&#2342;&#2368; &#2350;&#2375;&#2306;/Sub-Title Name in Hindi
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubTitleHindi" MaxLength="200" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>&#2313;&#2346; - &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; &#2361;&#2367;&#2306;&#2342;&#2368; &#2350;&#2375;&#2306;/Price(Rs.)
                    </td>
                    <td>
                        <%--<asp:TextBox ID="txtRate" MaxLength="6" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnNumeric(event, this);' runat="server"></asp:TextBox>--%>
                        <asp:TextBox ID="txtRate" MaxLength="6" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlACYear" CssClass="txtbox reqirerd" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSave" CssClass="btn" OnClick="btnSave_Click" OnClientClick='javascript:return ValidateAllTextForm();'
                            runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" />
                        <asp:Button ID="btnCancel" CssClass="btn" OnClick="btnCancel_Click" Visible="false" runat="server" Text="रद्द करें/Cancel" />
                    </td>
                    <td>
                        <asp:Button ID="btnBack" CssClass="btn" OnClick="btnBack_Click" runat="server" Text="वापस जाएं" />
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:HiddenField ID="hdnSubTitleID" runat="server" />
                        <asp:GridView ID="GrdTitle" runat="server" CssClass="tab" DataKeyNames="SubTitleID_I"
                            AutoGenerateColumns="false" OnRowDeleting="GrdTitle_RowDeleting"
                            OnRowEditing="GrdTitle_RowEditing">
                            <Columns>
                                <%-- <asp:BoundField DataField="SubTitleID_I" HeaderText="&#2313;&#2346; -&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2310;&#2312;. &#2337;&#2368;." ReadOnly="true" />
                                <asp:BoundField DataField="TitleEnglish_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;" ReadOnly="true" />
                                   <asp:BoundField DataField="SubTitleEnglish_V" HeaderText="&#2313;&#2346; -&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; &#2311;&#2306;&#2327;&#2381;&#2354;&#2367;&#2358; &#2350;&#2375;&#2306;"
                                    ReadOnly="true" />
                                --%>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="SubTitleHindi_V" HeaderText="&#2313;&#2346; -&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; &#2361;&#2367;&#2306;&#2342;&#2368; &#2350;&#2375;&#2306;/Sub-Title in Hindi"
                                    ReadOnly="true" />
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;">
                                    <ItemTemplate>
                                        <%--  <a href="SubTitleMasterB.aspx?ID=<%#Eval("SubTitleID_I") %>">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</a>--%>
                                        <asp:Button ID="btnEdit" CssClass="btn" runat="server" CommandName="Edit" Text="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;/Edit" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" CssClass="btn" runat="server" CommandName="Delete" Text="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;/Delete"
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
    <script type="text/javascript">

        // Load the Google Transliterate API
        google.load("elements", "1", {
            packages: "transliteration"
        });

        function onLoad() {
            var options = {
                sourceLanguage:
                google.elements.transliteration.LanguageCode.ENGLISH,
                destinationLanguage:
                [google.elements.transliteration.LanguageCode.HINDI],
                //shortcutKey: 'ctrl+g',
                transliterationEnabled: true
            };

            // Create an instance on TransliterationControl with the required
            // options.
            var control =
            new google.elements.transliteration.TransliterationControl(options);

            // Enable transliteration in the textbox with id
            // 'transliterateTextarea'.
            control.makeTransliteratable(['<%= txtSubTitleHindi.ClientID %>']);

            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_initializeRequest(InitializeRequest);
            prm.add_endRequest(EndRequest);

            function InitializeRequest(sender, args) {
            }

            // this is called to re-init the google after update panel updates.
            function EndRequest(sender, args) {
                onLoad();
            }
        }
        google.setOnLoadCallback(onLoad);
    </script>
</asp:Content>
