<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewData.aspx.cs" Inherits="Depo_ViewData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>&nbsp;&#2309;&#2306;&#2340;&#2337;&#2367;&#2346;&#2379; &#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2347;&#2352;</h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; / Enter New Data"
                            OnClick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns>
                                <asp:BoundField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;" DataField="SubTitleHindi_V" />
                                <asp:BoundField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="DepoName_V" />
                                <asp:BoundField HeaderText="&#2310;&#2352;&#2381;&#2337;&#2352; &#2344;." DataField="OrderNo" />
                                <asp:BoundField HeaderText="&#2310;&#2352;&#2381;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " DataField="OrderDate" />
                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " DataField="Toalbook" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

