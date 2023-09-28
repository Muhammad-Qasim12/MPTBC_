<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DemandReport.aspx.cs" Inherits="Distribution_DemandReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box table-responsive">
                <div class="card-header">
                    <h2 >&#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; </h2>
                </div>

        <table width="100%">

            <tr>

                <td align="center" >
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" Width="324px" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged">
                        <asp:ListItem Value="1">&#2351;&#2379;&#2332;&#2344;&#2366;</asp:ListItem>
                        <asp:ListItem Value="2">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;</asp:ListItem>
                        <asp:ListItem Value="3">&#2309;&#2344;&#2381;&#2351; </asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>

            <tr>

                <td>
                    <asp:RadioButtonList ID="RD1" runat="server" CssClass="txtbox" Visible="False">
                        <asp:ListItem Value="Rpt_BlockWiseDemand.aspx">&#2357;&#2367;&#2325;&#2366;&#2360;&#2326;&#2306;&#2337; &#2357;&#2366;&#2352; &#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / Demand Of Block Wise Report</asp:ListItem>
                        <asp:ListItem Value="Rpt_DistrictWiseDemand.aspx">&#2332;&#2367;&#2354;&#2366;&#2357;&#2366;&#2352; &#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / District Wise Demand Report</asp:ListItem>
                        <asp:ListItem Value="Rpt_DepotWiseDemand.aspx">&#2337;&#2367;&#2346;&#2379;&#2357;&#2366;&#2352; &#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / Depot Wise Demand Report </asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    <asp:RadioButtonList ID="RD2" runat="server" CssClass="txtbox" Visible="False">
                        <asp:ListItem Value="Rpt_BlockWiseDemandMedium.aspx">&#2357;&#2367;&#2325;&#2366;&#2360;&#2326;&#2306;&#2337; &#2357;&#2366;&#2352; &#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / Demand Of Block Wise Report</asp:ListItem>
                        <asp:ListItem Value="Rpt_DistrictWiseDemandMedium.aspx">&#2332;&#2367;&#2354;&#2366;&#2357;&#2366;&#2352; &#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / District Wise Demand Report</asp:ListItem>
                        <asp:ListItem Value="Rpt_DepotWiseDemandMedium.aspx">&#2337;&#2367;&#2346;&#2379;&#2357;&#2366;&#2352; &#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / Depot Wise Demand Report </asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    <asp:RadioButtonList ID="RD3" runat="server" CssClass="txtbox" Visible="False">
                       
                        <asp:ListItem Value="Rpt_SchemeWiseBlockWiseDemand.aspx">&#2357;&#2367;&#2325;&#2366;&#2360;&#2326;&#2306;&#2337; &#2357;&#2366;&#2352; &#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; (&#2351;&#2379;&#2332;&#2344;&#2366;) / Demand Of Block Wise Report (Scheme)</asp:ListItem>
                        <asp:ListItem Value="Rpt_SchemeWiseDepoWiseDemand.aspx">&#2337;&#2367;&#2346;&#2379;&#2357;&#2366;&#2352; &#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; (&#2351;&#2379;&#2332;&#2344;&#2366;) / Demand Of Depot Wise Report (Scheme)</asp:ListItem>
                        <asp:ListItem Value="Rpt_SchemeWiseDistrictWiseDemand.aspx">&#2332;&#2367;&#2354;&#2366;&#2357;&#2366;&#2352; &#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; (&#2351;&#2379;&#2332;&#2344;&#2366;) / Demand Of District Wise Report (Scheme)</asp:ListItem>
                        <asp:ListItem Value="Rpt_GroupWiseDemandMediumWthAllGrp.aspx">&#2327;&#2381;&#2352;&#2369;&#2346; &#2357;&#2366;&#2352; &#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / Group Wise Demand Report </asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>

            <tr>

                <td>
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Report" />
                </td>
            </tr>
        </table>
     </div> 
</asp:Content>

