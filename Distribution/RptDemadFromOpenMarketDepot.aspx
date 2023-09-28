<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RptDemadFromOpenMarketDepot.aspx.cs" EnableEventValidation="false" Inherits="Distrubution_RptDemadFromOpenMarketDepot" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        function CheckAll(rb) {
            var gv = document.getElementById("<%= ddlClass.ClientID  %>");

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
    <%--<asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                <ProgressTemplate>
                    <div class="fade">
                    </div>
                    <div class="progress">
                        <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>

    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&#2337;&#2367;&#2346;&#2379;&#2357;&#2366;&#2352; &#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2350;&#2375;&#2306; &#2357;&#2367;&#2325;&#2381;&#2352;&#2351; &#2361;&#2375;&#2340;&#2369; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; 
                    / Depot wise Textbooks Demand For Open Market Sell
                </span></h2>
        </div>
        <div class="portlet-content">
            <asp:Panel class="response-msg inf ui-corner-all" runat="server" ID="mainDiv" Style="display: block; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg"
                    Text="&#2325;&#2371;&#2346;&#2351;&#2366; &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2342;&#2375;&#2326;&#2344;&#2375; &#2325;&#2375; &#2354;&#2367;&#2319; &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;, &#2337;&#2367;&#2346;&#2379; , &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; &#2340;&#2341;&#2366; &#2325;&#2325;&#2381;&#2359;&#2366; &#2330;&#2369;&#2344;&#2375; / Please select Academic Year , Depot , Medium and Class to view demand"
                    class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <div class="table-responsive">
                <table>
                    <tr>
                        <td style="width: 185px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSessionYear" runat="server" CssClass="txtbox reqirerd">
                            </asp:DropDownList>
                        </td>
                        <td>डिपोवार मांग का प्रकार / Depot Wise Demand Type :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDepoMaster" runat="server" CssClass="txtbox "
                                Width="300px">
                                <asp:ListItem Value="1">पिछले सत्र में विक्रय की गई पुस्तकों की संख्या</asp:ListItem>
                                <asp:ListItem Value="2">आगामी सत्र हेतु आंकलित आवश्यकता</asp:ListItem>
                                <asp:ListItem Value="3">वर्तमान सत्र में विक्री पश्चात बचने वाला संभावित स्टॉक</asp:ListItem>
                                <asp:ListItem Value="4">आगामी सत्र हेतु शुद्ध आवश्यकता</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; &#2330;&#2369;&#2344;&#2375; / Medium :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMedum" runat="server" CssClass="txtbox reqirerd" OnInit="ddlMedum_Init"
                                Width="150">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table>
                                <tr>
                                    <td>&#2325;&#2325;&#2381;&#2359;&#2366; / Class:
                                    </td>
                                    <td style="border: 1px solid  lightgrey">

                                        <label id="Name">&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; / Select All </label>
                                        <input type="checkbox" id="chkSelect" value="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; " name="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; " onclick="CheckAll(this);" />
                                        <%-- <asp:CheckBox ID="chkSelect1" runat="server"   Text="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; "  onclick="CheckAll(this);" TextAlign="Left"/>--%>
                                        <asp:CheckBoxList ID="ddlClass" OnInit="ddlClass_Init" RepeatDirection="Horizontal" CssClass="reqirerd" RepeatColumns="8" TextAlign="Left" runat="server">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>

                            </table>
                        </td>
                        <td style="font-size: medium;"> 
                            <asp:Button Text="View / &#2342;&#2375;&#2326;&#2375;&#2306; " ID="BtnView" runat="server" CssClass="btn" OnClientClick='javascript:return ValidateAllTextForm();' OnClick="ddlClass_SelectedIndexChanged" />
                        </td>
                    </tr> 
                    <tr>
                        <td colspan="6" style="text-align: center">
                            <div style="width: 700px">
                                <rsweb:ReportViewer ID="ReportViewer1" runat="server"
                                    Height="" SizeToReportContent="True">
                                </rsweb:ReportViewer>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
