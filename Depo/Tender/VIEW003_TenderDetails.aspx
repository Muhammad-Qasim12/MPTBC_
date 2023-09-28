<%@ Page Title="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Tender Information" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW003_TenderDetails.aspx.cs" Inherits="Vehicle_VIEW003_TenderDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="portlet-header ui-widget-header">&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Tender Information</div>
        <div class="portlet-content">
            <div class="table-responsive ">
                <table width="100%">
                    <tr>
                        <td colspan="2">
                            <asp:Button runat="server" ID="btnAdd" Text="&#2332;&#2379;&#2396;&#2375; / Add" CssClass="btn" OnClick="btnAdd_Click" />
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2">
                           
                                <asp:GridView runat="server" ID="grdTender" AutoGenerateColumns="false" CssClass="tab hastable">

                                    <Columns>
                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Sr.No. ">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Tender Name">
                                            <ItemTemplate>
                                                <%# Eval("TenderNo_V")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2340;&#2366;&#2352;&#2368;&#2326; / Tender Date">
                                            <ItemTemplate>
                                                <%# Eval("TenderDate_D")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="NIT &#2332;&#2366;&#2352;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / NIT Publish Date">
                                            <ItemTemplate>
                                                <%# Eval("NITDate_D")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2337;&#2377;&#2325;&#2381;&#2351;&#2370;&#2350;&#2375;&#2306;&#2335; &#2347;&#2368;&#2360; / Tender Document Fee ">
                                            <ItemTemplate>
                                                <%# Eval("TenderDocFee_N")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2332;&#2350;&#2366; &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Tender Submission Date">
                                            <ItemTemplate>
                                                <%# Eval("TenderSubmissionDate_D")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="&#2335;&#2375;&#2325;&#2381;&#2344;&#2368;&#2325;&#2354; &#2348;&#2367;&#2337; &#2326;&#2369;&#2354;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Tech Bid Opening Date">
                                            <ItemTemplate>
                                                <%# Eval("TechBidopeningDate_D")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="&#2325;&#2350;&#2352;&#2381;&#2360;&#2367;&#2309;&#2354; &#2348;&#2367;&#2337; &#2326;&#2369;&#2354;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Commecial Bid Opening Date">
                                            <ItemTemplate>
                                                <%# Eval("CommecialBidOpeningdate_D")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>




                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <a href="DPT002_TenderMaster.aspx?Cid=<%# new APIProcedure().Encrypt( Eval("TenderId_I").ToString()) %>">&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit </a>

                                            </ItemTemplate>
                                        </asp:TemplateField>


                                    </Columns>
                                    <PagerStyle CssClass="Gvpaging" />
                                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                </asp:GridView>

                        </td>

                    </tr>

                </table>
            </div>
        </div>
    </div>
</asp:Content>

