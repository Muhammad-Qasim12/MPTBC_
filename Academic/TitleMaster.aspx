<%@ Page Title="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Title Information" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="TitleMaster.aspx.cs" Inherits="Academic_TitleMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
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
            control.makeTransliteratable(['ctl00_ContentPlaceHolder1_txtTitleHindi']);
          
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
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Title Information</span></h2>
        </div>
        <div style="padding: 0 10px;">
            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <table>
                <tr>
                    <td colspan="2"><asp:Button ID="btnSave0" CssClass="btn" OnClick="btnSave0_Click" runat="server" Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2351;&#2375; " />
                    <br />
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">&#2344;&#2351;&#2366; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2332;&#2379;&#2396;&#2375; </asp:ListItem>
                            <asp:ListItem Value="2">&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;.</asp:ListItem>
                        </asp:RadioButtonList>
                    &nbsp;</td>
                </tr>
                <tr id="a1" runat="server" visible="false">
                    <td>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2330;&#2369;&#2344;&#2375;</td>
                    <td>
                        <asp:DropDownList ID="ddlclass1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlclass1_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="a" runat="server" visible="false">
                    <td>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2330;&#2369;&#2344;&#2375;</td>
                    <td>
                        <asp:DropDownList ID="ddlTitle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTitle_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; / Academic Year
                    </td>
                    <td><asp:DropDownList ID="ddlAcYear" Width="250px" CssClass="reqirerd" runat="server" OnInit="ddlAcYear_Init"></asp:DropDownList>
                        <asp:Label ID="lblAcademicYear" runat="server" Text="--" Visible="false"></asp:Label>
                        <asp:HiddenField ID="hdnAcademicYearID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;/Medium
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMedium" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&#2325;&#2325;&#2381;&#2359;&#2366;/Class
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlClass" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2354;&#2375;&#2326;&#2344; &#2357;&#2367;&#2349;&#2366;&#2327; / Publication Department
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDepartment" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; &#2311;&#2306;&#2327;&#2381;&#2354;&#2367;&#2358; &#2350;&#2375;&#2306; 
                        / Title Name in English</td>
                    <td>
                        <asp:TextBox ID="txtTitleEnglish" MaxLength="70" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; &#2361;&#2367;&#2306;&#2342;&#2368; &#2350;&#2375;&#2306;
                        / Title Name in Hindi</td>
                    <td>
                        <asp:TextBox ID="txtTitleHindi" MaxLength="70" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>&#2310;&#2325;&#2366;&#2352;  (&#2360;&#2375;.&#2350;&#2368;. x &#2360;&#2375;.&#2350;&#2368;.)&nbsp; / Size(CMxCm)</td>
                    <td>
                        <asp:TextBox ID="txtSize" MaxLength="10" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                        (&#2330;&#2380;&#2396;&#2366;&#2312;x&#2354;&#2350;&#2381;&#2348;&#2366;&#2312;)
                       
                    </td>
                </tr>
                <tr>
                    <td>&#2346;&#2371;&#2359;&#2381;&#2336; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Total Pages</td>
                    <td>
                        <asp:TextBox ID="txtPages" MaxLength="5" onkeypress='javascript:tbx_fnInteger(event, this);'
                            CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&#2352;&#2306;&#2327; &#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2357;&#2352; &#2346;&#2375;&#2332; 1 &#2319;&#2357;&#2306; 4 / Colour Scheme Coverpage 1 &amp; 4</td>
                    <td>
                        <asp:DropDownList ID="ddlColourCover1n4" CssClass="txtbox" runat="server">
                            <asp:ListItem Text="Single Colour" Selected="True" Value="Single Colour"></asp:ListItem>
                            <asp:ListItem Text="Double Colour" Value="Double Colour"></asp:ListItem>
                            <asp:ListItem Text="Multi Colour" Value="Multi Colour"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&#2352;&#2306;&#2327; &#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2357;&#2352; &#2346;&#2375;&#2332; 2 &#2319;&#2357;&#2306; 3 / Colour Scheme Coverpage 2 &amp; 3</td>
                    <td>
                        <asp:DropDownList ID="ddlColourCover2n3" runat="server">
                            <asp:ListItem Text="Single Colour" Selected="True" Value="Single Colour"></asp:ListItem>
                            <asp:ListItem Text="Double Colour" Value="Double Colour"></asp:ListItem>
                            <asp:ListItem Text="Multi Colour" Value="Multi Colour"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&#2352;&#2306;&#2327; &#2351;&#2379;&#2332;&#2344;&#2366; &#2350;&#2376;&#2335;&#2352; / Colour Scheme Matter</td>
                    <td>
                        <asp:DropDownList ID="ddlColourText" runat="server">
                            <asp:ListItem Text="Single Colour" Selected="True" Value="Single Colour"></asp:ListItem>
                            <asp:ListItem Text="Double Colour" Value="Double Colour"></asp:ListItem>
                            <asp:ListItem Text="Multi Colour" Value="Multi Colour"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2350;&#2370;&#2354;&#2381;&#2351;(&#2352;&#2370;&#2346;&#2319;)/Price(Rs.)
                    </td>
                    <td>
                        <asp:TextBox ID="txtRate" MaxLength="6" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnNumeric(event, this);'
                            runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Printing Paper Details*</td>
                    <td>
                        <asp:DropDownList ID="ddlPrintingPaperInformation_V" runat="server" CssClass="txtbox reqirerd" >
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Cover paper Details *</td>
                    <td>
                        <asp:DropDownList ID="ddlCoverPaperinformation_V" runat="server" 
                            CssClass="txtbox reqirerd" 
                           >
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>&#2348;&#2366;&#2311;&#2306;&#2337;&#2367;&#2306;&#2327; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Binding Details *</td>
                    <td>
                        <asp:DropDownList ID="Binding" runat="server" 
                            CssClass="txtbox reqirerd" 
                           >
                            <asp:ListItem>Perfect Binding</asp:ListItem>
                            <asp:ListItem>Non Perfect (Chemical Binding)</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>&#2350;&#2370;&#2354;&#2381;&#2351; &#2360;&#2370;&#2330;&#2368; &#2319;&#2357;&#2306; &#2350;&#2366;&#2306;&#2327; &#2346;&#2340;&#2381;&#2352;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Rate List &amp; Demand Form S.No. </td>
                    <td>
                        <asp:TextBox ID="txtRateListSNo" MaxLength="4" Text="1" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnNumeric(event, this);'
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="txtPaperSize" MaxLength="5" Visible="false" CssClass="txtbox reqirerd" Text="0" onkeypress='javascript:tbx_fnInteger(event, this);' runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtCoverSize" MaxLength="5" Visible="false" CssClass="txtbox reqirerd" Text="0" onkeypress='javascript:tbx_fnInteger(event, this);' runat="server"></asp:TextBox>

                        <asp:Button ID="btnSave" CssClass="btn" OnClick="btnSave_Click" OnClientClick='javascript:return ValidateAllTextForm();' runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" />
                    &nbsp;</td>
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
            control.makeTransliteratable(['ctl00_ContentPlaceHolder1_txtTitleHindi']);

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
