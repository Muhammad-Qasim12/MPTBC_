<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptGroupwiseRemaingDemand.aspx.cs" Inherits="Distribution_RptGroupwiseRemaingDemand" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    <div class="box">
        <div class="card-header">
            <h2><span>
                <asp:Label ID="lblTitleName" runat="server"></asp:Label>
                </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year :</asp:Label>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 30%; font-size: medium;" valign="top">&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2366; &#2344;&#2366;&#2350;
                            <br />
                            Group Name :
                            <asp:DropDownList ID="ddlGroupName" runat="server" CssClass="txtbox reqirerd">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 30%; font-size: medium;" valign="top">
                            <%--   <asp:Label ID="LblDistrict" runat="server" Width="100px">&#2332;&#2367;&#2354;&#2366;  :</asp:Label>
                        <asp:DropDownList ID="DdlDistrict" runat="server" CssClass="txtbox"  Enabled ="false">
                        </asp:DropDownList >--%>
                            <asp:Label ID="LblScheme" runat="server">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;  <br /> Medium :</asp:Label>
                            <asp:DropDownList ID="DdlScheme" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%; font-size: medium;" valign="top">
                            <table>
                                <tr>
                                    <td>&#2325;&#2325;&#2381;&#2359;&#2366;
                                        <br />
                                        Class : </td>
                                    <td style="border: 1px solid  lightgrey">
                                        <label id="Name">
                                        &#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; / Select All
                                        </label>
                                        <input id="chkSelect" name="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; " onclick="CheckAll(this);" type="checkbox" value="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; " />
                                        <%-- <asp:CheckBox ID="chkSelect1" runat="server"   Text="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; "  onclick="CheckAll(this);" TextAlign="Left"/>--%>
                                        <asp:CheckBoxList ID="DdlClass" runat="server" CssClass="reqirerd" RepeatColumns="8" RepeatDirection="Horizontal" TextAlign="Left">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 30%; font-size: medium;" valign="top">Order No:
                            <asp:DropDownList ID="DDlDemandType" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" OnClientClick="return ValidateAllTextForm();" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; / See Report " />
                        </td>
                    </tr>
                </table>
                <div class="rdlc" style="overflow: auto">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="800px" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

