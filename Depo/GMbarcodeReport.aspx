<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GMbarcodeReport.aspx.cs" Inherits="Depo_GMbarcodeReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>&#2348;&#2366;&#2352;&#2325;&#2379;&#2337; &#2360;&#2375; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2348;&#2306;&#2337;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </h2>
        </div>
        <table width="100%">
            <tr>
                <td >&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;</td> 
                <td >
                    <asp:DropDownList ID="ddlSessionYear" runat="server">
                    </asp:DropDownList>
                </td> 
                <td >
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Report" />
                </td> 
            </tr>
            <tr>
                <td colspan="3" >
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                        <Columns>
                              <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                            <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                            <asp:BoundField DataField="PaikBandal" HeaderText="&#2325;&#2369;&#2354; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                            <asp:BoundField DataField="BundleNo" HeaderText="&#2348;&#2366;&#2352;&#2325;&#2379;&#2337; &#2360;&#2375; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                            <asp:BoundField DataField="ToalPer" HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; " />
                        </Columns>
                    </asp:GridView>
                </td> 
            </tr>
        </table>
    </div>
</asp:Content>

