<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ExtraDemandVitranReport.aspx.cs" Inherits="Distribution_ExtraDemandVitranReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="card-header">
            <h2>
                <span>
                    <asp:Label ID="lblTitleName" runat="server">&#2360;&#2306;&#2358;&#2379;&#2343;&#2367;&#2340; &#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; (&#2309;&#2306;&#2340;&#2352;)  </asp:Label>
                </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                 <asp:Panel class="response-msg inf ui-corner-all" runat="server" ID="mainDiv" Style="display: block; padding-top: 10px; padding-bottom: 10px;">
                            <asp:Label ID="lblmsg" class="notification" runat="server" Text="&#2337;&#2366;&#2335;&#2366; &#2342;&#2375;&#2326;&#2344;&#2375; &#2325;&#2368; &#2354;&#2367;&#2319; &#2325;&#2371;&#2346;&#2351;&#2366; &#2360;&#2349;&#2368; &#2310;&#2346;&#2381;&#2358;&#2344; &#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335; &#2325;&#2352;&#2375; / Please Select All Options To View Data ">
                                </asp:Label>
                        </asp:Panel>
                 <asp:Panel ID="Panel1" runat="server"><table width="100%">
                   <tr>
                        <td>
                            <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;<br /> Academic Year :</asp:Label>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged1">
                            </asp:DropDownList>


                        </td>

                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblDepot" runat="server">&#2337;&#2367;&#2346;&#2379; <br /> Depot :</asp:Label>
                            <asp:DropDownList ID="DDlDepot" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                        </td>


                        <td style="width: 30%; font-size: medium;" valign="top">
                            &#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352;
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="txtbox" >
                            </asp:DropDownList>
                        </td>


                    </tr>
                    <tr>

                        <td style="font-size: medium;" valign="top" colspan="3">
                            <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="&#2337;&#2366;&#2335;&#2366; &#2342;&#2375;&#2326;&#2375; " />
                        </td>

                    </tr>
                     <tr>
                         <td colspan="3" style="font-size: medium;" valign="top">
                             <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server" DocumentMapWidth="100%" Height="" SizeToReportContent="True">
                            </rsweb:ReportViewer>
                         </td>
                     </tr>
                     </table> </asp:Panel> </div> 
</asp:Content>

