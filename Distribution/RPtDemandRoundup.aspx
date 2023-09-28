<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPtDemandRoundup.aspx.cs" Inherits="Distribution_RPtDemandRoundup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <h2>
                &#2327;&#2381;&#2352;&#2369;&#2346;&#2357;&#2366;&#2352; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2375; &#2310;&#2306;&#2325;&#2354;&#2344; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; </h2>
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

                        <td style="width: 30%; font-size: medium;" valign="top">

                            <asp:Label ID="LblScheme" runat="server">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;  <br /> Medium :</asp:Label>
                            <asp:DropDownList ID="DdlScheme" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="DdlScheme_SelectedIndexChanged">
                            </asp:DropDownList>


                        </td>


                        <td style="width: 30%; font-size: medium;" valign="top">&#2350;&#2366;&#2306;&#2327; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br />
                            Demand Type :
                             <asp:DropDownList ID="DDlDemandType" runat="server" CssClass="txtbox" Width="150px">
                             </asp:DropDownList>
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="txtbox" Width="80px">
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Yojna</asp:ListItem>
                                <asp:ListItem>Samanya</asp:ListItem>
                                <asp:ListItem>Total</asp:ListItem>
                            </asp:DropDownList>

                        </td>


                        <td style="width: 30%; font-size: medium;" valign="top">आर्डर नंबर
                            <br />
                            <asp:DropDownList ID="DropDownList1" runat="server">
                            </asp:DropDownList>
                        </td>


                    </tr>
                    <tr>


                        <td style="width: 30%; font-size: medium;" valign="top">
                            <table>
                                <tr>
                                    <td>&#2325;&#2325;&#2381;&#2359;&#2366; 
                                        <br />
                                        Class :
                                    </td>
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
                        <td style="width: 30%; font-size: medium;" valign="top">
                            <table>
                                <tr>
                                    <td>&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2366; &#2344;&#2366;&#2350;
                            <br />
                                        Group Name :
                                    </td>
                                    <td style="border: 1px solid  lightgrey">

                                        <%-- <asp:CheckBox ID="chkSelect1" runat="server"   Text="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; "  onclick="CheckAll(this);" TextAlign="Left"/>--%>
                                        <asp:CheckBoxList ID="ddlGroupName" RepeatDirection="Horizontal" RepeatColumns="4" TextAlign="Left" runat="server" CssClass="reqirerd">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>

                            </table>


                        </td>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="0">सभी </asp:ListItem>
                                <asp:ListItem Value="1">परिवर्तित </asp:ListItem>
                                <asp:ListItem Value="2">अपरिवर्तित </asp:ListItem>
                            </asp:RadioButtonList>
                        </td>

                        <td>
                            <asp:Button ID="Button1" runat="server" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; / See Report "
                                OnClientClick="return ValidateAllTextForm();" CssClass="btn" OnClick="Button1_Click" /></td>

                    </tr>
                </table>
                <div style="overflow: auto" class="rdlc">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                        InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                        Width="100%" Height="800px">
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

