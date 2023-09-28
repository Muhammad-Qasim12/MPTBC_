<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Problem.aspx.cs" Inherits="Depo_Problem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
        .auto-style2 {
            height: 201px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="https://www.google.com/jsapi" ></script>
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
            control.makeTransliteratable(['ctl00_ContentPlaceHolder1_TextBox1']);
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

    
    <div class="box">
                    <div class="card-header">
                     <h2> &#2360;&#2350;&#2360;&#2381;&#2351;&#2366; / &#2360;&#2369;&#2333;&#2366;&#2357;</h2>
                          
                    </div>
         <table style="width: 100%">
                <tr>
                    <td style="font-size: medium;" class="auto-style2">
                        <h3><span class="auto-style1">&#2360;&#2366;&#2347;&#2381;&#2335;&#2357;&#2375;&#2351;&#2352; &#2350;&#2375;&#2306; &#2310;&#2344;&#2375;&#2357;&#2366;&#2354;&#2368; &#2360;&#2350;&#2360;&#2381;&#2351;&#2366; &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375;&#2306;</span></h3>
                        <br />
                        <br />
&nbsp;<asp:TextBox ID="TextBox1" runat="server" Height="131px" TextMode="MultiLine" Width="867px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: medium;">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " />
                    </td>
                </tr>
                <tr>
                    <td style="font-size: medium;">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="40">
                            <Columns>
                                 <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                <asp:BoundField DataField="DepoName_V" HeaderText="विभाग का नाम " />
                                <asp:BoundField DataField="ProblemDetails" HeaderText="&#2360;&#2350;&#2360;&#2381;&#2351;&#2366; /&#2360;&#2369;&#2333;&#2366;&#2357; " />
                                <asp:BoundField DataField="ProblemDate" HeaderText="&#2360;&#2350;&#2360;&#2381;&#2351;&#2366; /&#2360;&#2369;&#2333;&#2366;&#2357; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                                <asp:BoundField DataField="Reply" HeaderText="&#2344;&#2367;&#2352;&#2366;&#2325;&#2352;&#2339; " />
                                <asp:BoundField DataField="ReplyDate" HeaderText="&#2344;&#2367;&#2352;&#2366;&#2325;&#2352;&#2339;  &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr></table> 

    </div> 
</asp:Content>

