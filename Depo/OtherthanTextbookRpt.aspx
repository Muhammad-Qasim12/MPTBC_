<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OtherthanTextbookRpt.aspx.cs" Inherits="Depo_OtherthanTextbookRpt" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">

        <div class="card-header">
            <h2>&#2332;&#2344;&#2352;&#2354; &#2360;&#2381;&#2335;&#2377;&#2325; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2352; / General Stock Register 
            </h2>
        </div>
        <div style="padding: 0 10px;">


            <table width="100%">

              



                <tr runat="server">
                      <td class="auto-style1">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Financial Yea</td>
                    <td>
                        <asp:DropDownList ID="ddlSessionYear" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                    </td>


                    <td>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;
                       
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTital" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTital_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>&#2313;&#2346; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
                    <td>
                        <asp:DropDownList ID="ddlSubTital" runat="server">
                        </asp:DropDownList></td>
               



                </tr>


                <tr>
                    <td colspan="5" align="center">
                        <asp:Button ID="btnviewReport" runat="server" CssClass="btn"
                            Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306; / See Report " OnClick="btnviewReport_Click" />
                    </td>
                </tr>

                <tr>
                    <td colspan="5">
                        <div style="overflow: auto" class="rdlc">
                            <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server" DocumentMapWidth="100%" Height="" SizeToReportContent="True">
                            </rsweb:ReportViewer>
                        </div>
                    </td>
                </tr>
            </table>

            <tr>
                <td colspan="4">

                    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
                    </div>
                    <div id="Messages" style="display: none;" class="popupnew" runat="server">

                        <div class="msg MT10">
                            <p>
                            </p>
                        </div>
                        <a id="fancybox-close" style="display: inline;" onclick="javascript:closeMessagesDiv();"></a>
                    </div>
                </td>

            </tr>
        </div>
    </div>

</asp:Content>

