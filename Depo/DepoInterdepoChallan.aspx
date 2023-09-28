<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepoInterdepoChallan.aspx.cs" Inherits="Depo_DepoInterdepoChallan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box table-responsive">
        <div class="card-header">
            <h2>&#2309;&#2344;&#2381;&#2340;&#2352; &#2337;&#2367;&#2346;&#2379; &#2325;&#2375; &#2330;&#2366;&#2354;&#2366;&#2344; </h2>
        </div>
        <table width="100%">





           




            <tr>
                <td colspan="2">
                    <asp:Button ID="Button3" runat="server" CssClass="btn" Text="&#2344;&#2351;&#2366; &#2330;&#2366;&#2354;&#2366;&#2344; &#2348;&#2344;&#2366;&#2351;&#2375; " OnClick="Button3_Click1" />
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
                            <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                             <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2377;">
                                                 <ItemTemplate>
                                                 <a href="InterDepoSendChallan.aspx?ChallanID=<%#Eval("ChallanNo_V") %>"><%#Eval("ChallanNo_V")%></a>    
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>

                            <asp:BoundField DataField="" HeaderText="" />
                            <asp:BoundField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " DataField="ChallanDate_D" />
                            <asp:BoundField HeaderText="&#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; &#2325;&#2366; &#2310;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;." DataField="OrderNo_I" />
                        </Columns>
                    </asp:GridView>
                </td>


            </tr>
        </table>
    </div>
</asp:Content>

