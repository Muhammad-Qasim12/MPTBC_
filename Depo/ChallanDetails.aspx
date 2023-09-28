<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChallanDetails.aspx.cs" Inherits="Depo_ChallanDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;/Distribute books Details </h2>
        </div>
        <table width="100%">





            <tr>
                <td class="auto-style1">&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; / Challan No. </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlChallano" runat="server" ></asp:DropDownList>
                </td>
            </tr>





            <tr>
                <td colspan="2">
                    <asp:Button ID="Button3" runat="server" CssClass="btn" Text="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2375;&#2326;&#2375; /View Challan Detail" OnClick="Button3_Click1" />
                </td>


            </tr>





            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                        <Columns>
                             <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                            <asp:BoundField DataField="ChallanNo_V" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2377;" />
                            <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; " />
                            <asp:BoundField DataField="matcha" HeaderText="&#2360;&#2381;&#2335;&#2377;&#2325; &#2350;&#2375;&#2306; &#2350;&#2367;&#2354;&#2344;&#2375; &#2357;&#2366;&#2354;&#2375; &#2348;&#2306;&#2337;&#2354; " />
                            <asp:BoundField DataField="" HeaderText=" " />
                            

                             <asp:TemplateField HeaderText="&#2360;&#2381;&#2335;&#2377;&#2325; &#2350;&#2375;&#2306; &#2344;&#2361;&#2368;&#2306; &#2350;&#2367;&#2354;&#2344;&#2375; &#2357;&#2366;&#2354;&#2375; &#2348;&#2306;&#2337;&#2354;">
                                                 <ItemTemplate>
                                                 <%# Eval("Unmatch") %> -  <%# Eval("ChallanID") %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                            
                             <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                        </Columns>
                    </asp:GridView>
                </td>


            </tr>
        </table>
    </div>
</asp:Content>

