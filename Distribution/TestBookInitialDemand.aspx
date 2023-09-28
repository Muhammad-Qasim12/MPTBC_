<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="TestBookInitialDemand.aspx.cs" Inherits="Distribution_TestBookInitialDemand"
    Title="&#2344;&#2367;&#2307;&#2358;&#2369;&#2354;&#2381;&#2325; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2340;&#2352;&#2339; &#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2375; &#2309;&#2306;&#2340;&#2352;&#2381;&#2327;&#2340; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2350;&#2366;&#2306;&#2327;" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">

        function CheckAll(rb) {
            var gv = document.getElementById("<%= DdlClass.ClientID  %>");

            var rbs = gv.getElementsByTagName("input");

            var row = rb.parentNode.parentNode;

            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "checkbox") {
                    rbs[i].checked = document.getElementById('chkSelect').checked;
                }
            }
            if (document.getElementById('chkSelect').checked == true) {
                document.getElementById('Name').innerHTML = "&#2360;&#2349;&#2368; &#2361;&#2335;&#2366;&#2351;&#2375;";
            }
            else {
                document.getElementById('Name').innerHTML = "&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375;";
            }
            // alert(document.getElementById('Name').innerHTML);
        }

    </script>
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
                <div class="card-body">
                    <div class="card-header">
                        <h2>निःशुल्क पाठ्यपुस्तक वितरण योजना के अंतर्गत प्राप्त मांग</h2>
                    </div>
                    <div class="row g-3">
                        <div class="col-md-12">
                            <asp:Panel class="alert alert-danger" runat="server" ID="mainDiv" Visible="false">
                                <asp:Label ID="lblmsg" class="notification" runat="server">                
                                </asp:Label>
                            </asp:Panel>
                        </div>
                        <div class="col-md-12">
                            <div class="form-floating">
                                <asp:RadioButtonList ID="RadBtnListAgency" runat="server"
                                    RepeatDirection="Horizontal" AutoPostBack="True"
                                    OnSelectedIndexChanged="RadBtnListAgency_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="1-8">राज्य शिक्षा केंद्र / RSK</asp:ListItem>
                                    <asp:ListItem Value="9-12">लोक शिक्षण संचालनालय / CPI</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox MaxLength="15" ID="TxtLetterNO" CssClass="form-control reqirerd" runat="server"></asp:TextBox>
                                <label id="Label1" runat="server">पत्र क्रमांक</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox MaxLength="15" ID="TxtLetDate" CssClass="form-control reqirerd" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="TxtLetDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                <label id="Label2" runat="server">पत्र दिनांक</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="DdlACYear" runat="server" CssClass="form-select"
                                    OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <label id="Label3" runat="server">शिक्षा सत्र</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox MaxLength="15" ID="LblFyYear" CssClass="form-control reqirerd" ReadOnly="true" Enabled="false" runat="server"></asp:TextBox>
                                <label id="Label4" runat="server">वित्तीय वर्ष</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="DDlDemandType" runat="server" CssClass="form-select">
                                </asp:DropDownList>
                                <label id="Label5" runat="server">मांग का प्रकार</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="DdlDepot" runat="server" CssClass="form-select"
                                    AutoPostBack="True" OnSelectedIndexChanged="DdlDepot_SelectedIndexChanged">
                                </asp:DropDownList>
                                <label id="Label6" runat="server">डिपो चुने</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="DdlDistrict" runat="server" CssClass="form-select"
                                    AutoPostBack="True" OnSelectedIndexChanged="DdlDistrict_SelectedIndexChanged">
                                </asp:DropDownList>
                                <label id="Label7" runat="server">जिला चुने</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="DdlScheme" runat="server" CssClass="form-select"
                                    OnSelectedIndexChanged="DdlScheme_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <label id="Label8" runat="server">योजना चुने</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <select multiple="multiple" class="multi-select form-control">
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3">3</option>
                                    <option value="4">4</option>
                                    <option value="5">5</option>
                                    <option value="6">6</option>
                                    <option value="7">7</option>
                                    <option value="8">8</option>
                                </select>
                                <label>कक्षा चुने</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <input type="checkbox" id="chkSelect" placeholder="Select All" value="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; " name="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; " onclick="CheckAll(this);" />
                                <asp:CheckBoxList ID="DdlClass" RepeatDirection="Horizontal" RepeatColumns="8" TextAlign="Left" runat="server">
                                </asp:CheckBoxList>
                                <label id="Label9" runat="server">कक्षा</label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="BtnViewAll" runat="server" CssClass="btn btn-primary" Text=" &#2342;&#2375;&#2326;&#2375;&#2306; / View" OnClick="BtnViewAll_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="table-responsive">
                <div id="ExportDiv1" runat="server">
                    <table width="100%" class="table table-bordered">
                        <tr>
                            <td colspan="3" style="font-size: medium;">
                                <div class="tabpad">
                                    <asp:DataList ID="gridDetails" runat="server"  CssClass="table table-bordered" EnableViewState="true" AutoGenerateColumns="false" ShowHeader="false"
                                        OnItemDataBound="gridDetails_ItemDataBound">

                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnkey" runat="server" Value='<%#Eval("BlockTrno_I") %>' />
                                            <div class="tabth">
                                                <asp:Label ID="lbas" Text='<%#Eval("BlockNameHindi_V") %>' runat="server"></asp:Label>
                                            </div>

                                            <asp:GridView ID="grdTitlegrid" CssClass="table table-bordered" Style="margin: 0px;" ShowHeader="false" runat="server"
                                                AutoGenerateColumns="false" OnRowDataBound="gridDetails_RowDataBound" ShowFooter="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="book name">
                                                        <ItemTemplate>
                                                            <asp:Label Text='<%#Eval("TitleHindi_V") %>' ID="txtl" runat="server" Width="200"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="tilleid" runat="server" Value='<%#Eval("TitleID_I") %>' />
                                                            <asp:TextBox ID="txtDemand" CssClass="reqirerd" onkeypress='javascript:tbx_fnInteger(event, this);' runat="server" Width="60" MaxLength="10" Text="0"></asp:TextBox>

                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblFooterSum" runat="server" Visible="false"></asp:Label>

                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle CssClass="Gvpaging" />
                                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                                            </asp:GridView>
                                        </ItemTemplate>

                                    </asp:DataList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="Button1" runat="server" Text="सुरक्षित करे"
                                    CssClass="btn btn-primary" OnClick="Button1_Click" Visible="false" OnClientClick='javascript:return ValidateAllTextForm();' />
                                <asp:Button ID="Button2" runat="server" CssClass="btn btn-secondary" Text="प्रिंट करें" OnClick="Button2_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblSaveMsg" runat="server" ForeColor="Red"></asp:Label>

                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <script>
                function myFunction() {
                    window.print();
                }

            </script>
            <script type="text/javascript">
                function PrintPanel1() {
                    var panel = document.getElementById("<%=ExportDiv1.ClientID %>");

                    var printWindow = window.open('', '', 'height=400,width=800');
                    printWindow.document.write('<html><head><title></title>');
                    printWindow.document.write('<style> @font-face {src: url("BarCodeFont/FREE3OF9.eot?") format("eot"),url("BarCodeFont/FREE3OF9.woff") format("woff"), url("BarCodeFont/FREE3OF9.ttf") format("truetype"), url("BarCodeFont/FREE3OF9.svg#Free3of9") format("svg");font-family: Free3of9Regular;font-weight: normal;font-style: normal;}');
                    printWindow.document.write('.BarCode { font-family: Free3of9Regular; font-size: 90px; padding: 10px; line-height: 80px; }</style>');
                    printWindow.document.write('</head><body >');
                    printWindow.document.write('<link href="style.css" rel="stylesheet" type="text/css" />');
                    printWindow.document.write(panel.innerHTML);
                    printWindow.document.write('</body></html>');
                    printWindow.document.close();
                    setTimeout(function () {
                        printWindow.print();
                    }, 500);
                    return false;
                }</script>
        </ContentTemplate>

    </asp:UpdatePanel>
    <asp:HiddenField ID="hdnblockid" runat="server" />


</asp:Content>
