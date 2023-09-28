<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InsuranceDetails.aspx.cs" 
    Inherits="DistributionB_InsuranceDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 37px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="box table-responsive">
        <div class="card-header">
            <h2>
                &#2348;&#2368;&#2350;&#2366; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left" colspan="4">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        &#2350;&#2366;&#2361;
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlMonth" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: left">
                        &#2360;&#2340;&#2381;&#2352;
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlYear" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="DdlDepot" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: left">
                        &#2360;&#2306;&#2354;&#2344; &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2346;&#2340;&#2366;
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TextBox1" runat="server" Height="62px" TextMode="MultiLine" Width="260px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        &#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TextBox2" runat="server" onkeypress='javascript:tbx_fnNumeric(event, this);'></asp:TextBox>
                    </td>
                    <td style="text-align: left">
                        &#2352;&#2366;&#2358;&#2367;
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TextBox3" runat="server" onkeypress='javascript:tbx_fnNumeric(event, this);'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left" colspan="4" class="auto-style1">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click1" Text="Save" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left" colspan="4">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" AllowPaging="True" DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" PageSize="40">
                            <Columns>
                                <asp:BoundField HeaderText="&#2350;&#2366;&#2361; " DataField="MonthShortName" />
                                <asp:BoundField HeaderText="&#2360;&#2340;&#2381;&#2352; " DataField="YEAR" />
                                <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                                <asp:BoundField DataField="Address" HeaderText="&#2360;&#2306;&#2354;&#2344; &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                                <asp:BoundField DataField="TotalBook" HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" />
                                <asp:BoundField DataField="Amount" HeaderText="&#2352;&#2366;&#2358;&#2367; " />
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
               </table> </div> </div> 
               
</asp:Content>

