<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptEstimatedDemandDepot.aspx.cs"
    EnableEventValidation="false"
    Inherits="Distrubution_RptEstimatedDemandDepot" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

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


    <div class="box table-responsive">

        <div class="card-header">
            <h2>
                <span style="font-size: medium;">&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; &#2325;&#2375; &#2310;&#2306;&#2325;&#2354;&#2344; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / Report Of Demand Assessment in Textbook
                </span>
            </h2>
        </div>
        <div class="box">

            <table width="100%">

                <tr>
                    <td style="font-size: medium;" valign="top">
                        <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year :</asp:Label>
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                    </td>

                    <td style="font-size: medium;">
                     डिपोवार मांग का प्रकार <br />Depot Wise Demand Type :
                        <asp:DropDownList ID="DdlDepot" runat="server" CssClass="txtbox reqirerd">
                            <asp:ListItem Value="1">योजना हेतु मांग</asp:ListItem>
                            <asp:ListItem Value="2">सामान्य हेतु मांग</asp:ListItem>
                            <asp:ListItem Value="3">कुल मांग </asp:ListItem>
                            <asp:ListItem Value="4">योजना का स्टॉक</asp:ListItem>
                            <asp:ListItem Value="5">सामान्य का स्टॉक </asp:ListItem>
                            <asp:ListItem Value="6">कुल स्टॉक</asp:ListItem>
                            <asp:ListItem Value="7">नेट योजना हेतु मांग</asp:ListItem>
                            <asp:ListItem Value="8">नेट सामाय हेतु मांग</asp:ListItem>
                            <asp:ListItem Value="9">कुल नेट मांग</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="font-size: medium;" valign="top">
                        <asp:Label ID="LblMedium" runat="server">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;<br /> Medium  :</asp:Label>
                        <asp:DropDownList ID="DdlMedium" runat="server" CssClass="txtbox reqirerd"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: medium;" valign="top">
                        <table>
                            <tr>
                                <td style="border: 1px solid  lightgrey">
                                    <label id="Name">&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; / Select All </label>
                                    <input type="checkbox" id="chkSelect" value="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; " name="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; " onclick="CheckAll(this);" />
                                    <%-- <asp:CheckBox ID="chkSelect1" runat="server"   Text="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; "  onclick="CheckAll(this);" TextAlign="Left"/>--%>
                                    <asp:CheckBoxList ID="DdlClass" RepeatDirection="Horizontal" RepeatColumns="8" TextAlign="Left" runat="server" CssClass="reqirerd">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>

                        </table>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search "
                            OnClientClick="return ValidateAllTextForm();" OnClick="btnSearch_Click" />
                    </td>
                </tr>


                <tr>
                    <td colspan="4">

                        <div style="width: 700px">
                            <rsweb:ReportViewer ID="ReportViewer1" runat="server"
                                Height="" SizeToReportContent="True">
                            </rsweb:ReportViewer>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin-left: 80px;">
            &nbsp;
        </div>
    </div>

</asp:Content>

