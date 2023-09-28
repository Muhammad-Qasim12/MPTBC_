<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BundelUpload.aspx.cs" Inherits="Depo_BundelUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;/Distribute books Details </h2>
        </div>
        <table width="100%">
            <tr>
                <td>&#2332;&#2367;&#2354;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                <td>
                    <asp:DropDownList ID="DdlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlDistrict_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td >&#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                <td>
                    <asp:DropDownList ID="ddlBlock" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>





            <tr>
                <td class="auto-style1">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Financial Year</td>
                <td>
                    <asp:DropDownList ID="ddlSessionYear" runat="server" CssClass="txtbox reqirerd">
                    </asp:DropDownList>
                </td>
                <td class="auto-style1">&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; / Challan No. </td>
                <td>
                    <asp:DropDownList ID="ddlChallano" runat="server"  ></asp:DropDownList>
                </td>
            </tr>





            <tr>
                <td colspan="4">
                    <asp:Button ID="Button3" runat="server" CssClass="btn" Text="&#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2313;&#2344;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375; " OnClick="Button3_Click1" />
                &nbsp;
                    </td>
            </tr>





            <tr>
                <td colspan="4">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;<asp:Button ID="Button4" runat="server" CssClass="btn" Text="&#2337;&#2366;&#2335;&#2366; &#2309;&#2346;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375;&#2306; " OnClick="Button4_Click" />
                </td>
            </tr>





            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server" Width="100%" >
                     <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" Width="100%">
                   <Columns>      
                       <asp:BoundField HeaderText="TitalID " DataField="TitalID" />
                       <asp:BoundField DataField="TitleHindi_V" HeaderText="TitleHindi_V" />
                       <asp:BoundField DataField="DestributeBook" HeaderText="DestributeBook" />
                       <asp:BoundField DataField="PaikBandal" HeaderText="PaikBandal" />
                       <asp:BoundField DataField="LoojBandal" HeaderText="LoojBandal" />
                        <asp:TemplateField HeaderText="UploadbundelNo"></asp:TemplateField>
                    </Columns> 
                       </asp:GridView>
                        </asp:Panel>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>

