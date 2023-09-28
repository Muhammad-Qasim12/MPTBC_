<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowDetails.aspx.cs" Inherits="Depo_ShowDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span style="height: 1px">&#2360;&#2381;&#2335;&#2377;&#2325; &#2346;&#2379;&#2332;&#2368;&#2358;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Stock Position Details</span>
            </h2>
        </div>
        <div style="padding: 0 10px;">

            <asp:GridView ID="GridView1" CssClass="tab" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="NameofPress_V" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; /&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                    <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                    <asp:BoundField DataField="ChalanNo" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; " />
                    <asp:BoundField DataField="ChalanDate" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                    <asp:BoundField DataField="NofSchemeBook_I" HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366;" />
                    <asp:BoundField DataField="NoOFgenralBook_I" HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;" />
                </Columns>
            </asp:GridView>
            </div> 
        </div> 
</asp:Content>

