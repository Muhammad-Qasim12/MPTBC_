<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Rpt_SchemeWiseBlockWiseDemand.aspx.cs" 
    Inherits="Distrubution_Rpt_SchemeWiseBlockWiseDemand" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                <span>
                    <asp:Label ID="lblTitleName" runat="server"></asp:Label>
                </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;<br /> Academic Year :</asp:Label>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            </asp:DropDownList>


                        </td>

                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblDepot" runat="server">&#2337;&#2367;&#2346;&#2379; <br /> Depot :</asp:Label>
                            <asp:DropDownList ID="DDlDepot" runat="server" CssClass="txtbox"
                                OnSelectedIndexChanged="DDlDepot_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>


                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblDistrict" runat="server">&#2332;&#2367;&#2354;&#2366; <br /> District  :</asp:Label>
                            <asp:DropDownList ID="DdlDistrict" runat="server" CssClass="txtbox" Enabled="false">
                            </asp:DropDownList>
                        </td>


                    </tr>
                    <tr>

                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblDemandType" runat="server" Width="200px">&#2350;&#2366;&#2306;&#2327; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br />Demand Type :</asp:Label>
                            <asp:DropDownList ID="DDlDemandType" runat="server" CssClass="txtbox">
                            </asp:DropDownList> 
                        </td>

                        <td style="width: 30%; font-size: medium;" valign="top">
                          
                        </td>
                        <td style="font-size: medium;" valign="top">
                            
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; / See Report" CssClass="btn" OnClick="Button1_Click" />
                        </td>

                    </tr>
                </table>
                <div style="overflow: auto" class="rdlc">
                    <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server"
                        DocumentMapWidth="100%" Height="" SizeToReportContent="True">
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

