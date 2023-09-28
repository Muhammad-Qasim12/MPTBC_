<%@ Page Title="Title Master" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="TitleMasterB.aspx.cs" Inherits="AcademicB_TitleMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <div class="card">
                <div class="card-header">
                    <h2>Title Master</h2>
                </div>
                <div class="card-body">
                    <div class="row g-3">
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtTitleEnglish" Visible="false" CssClass="form-control reqirerd" MaxLength="200"
                                    runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtTitleHindi" MaxLength="200" placeholder="" CssClass="form-control reqirerd" runat="server"></asp:TextBox>
                                <label>Item Name in Hindi</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="">
                                <asp:CheckBox ID="chkNoSubTitle" runat="server" Text="" />
                                <label>Title has no subtitles</label>
                            </div>
                        </div>
                        <div class="col-md-4"></div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtRate" MaxLength="6" CssClass="form-control reqirerd" placeholder="" runat="server"></asp:TextBox>
                                <label>Price of the Title</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="DdlACYear" CssClass="form-select reqirerd" runat="server"></asp:DropDownList>
                                <label>Academic Year</label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="btnSave" CssClass="btn btn-submit" OnClick="btnSave_Click" OnClientClick='javascript:return ValidateAllTextForm();'
                                runat="server" Text="Save" />
                        </div>
                    </div>
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
                    control.makeTransliteratable(['<%= txtTitleHindi.ClientID %>']);

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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
