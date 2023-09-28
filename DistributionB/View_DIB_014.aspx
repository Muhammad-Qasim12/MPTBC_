<%@ Page  Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="View_DIB_014.aspx.cs" Inherits="Paper_ViewTenderEvalution" Title="कमर्शियल बिड का तुलनात्मक पत्रक " %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>कमर्शियल बिड का तुलनात्मक पत्रक  </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
     <div class="table-responsive">       
         <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <table width="100%">
                            <tr>
                                <td>
                                    <a  class="btn" href="DIB_014_TenderEvaluation.aspx">                                        
                                            &#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375;
                                    </a>
                                </td>
                                <td></td>
                                <td></td>
                                <td align="right">
                                    <asp:TextBox ID="txtSearch" runat="server"  MaxLength="200"  placeholder="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; &#2326;&#2379;&#2332;&#2375;"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" CssClass="btn"   Text="&#2326;&#2379;&#2332;&#2375;" 
                                        onclick="btnSearch_Click"/>
                                </td> 
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center" colspan="4">
                        <asp:GridView ID="GrdTenderInfo" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="TenderTrId_I"
                             AllowPaging="True" OnPageIndexChanging="GrdTenderInfo_PageIndexChanging"
                            OnRowDataBound="GrdTenderInfo_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;.">
                                    <ItemTemplate>
                                        <%#Eval("TenderNo_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="टेंडर का नाम">
                                    <ItemTemplate>
                                        <%#Eval("WorkName_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;">
                                    <ItemTemplate>
                                        <%#Eval("TenderType_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2312; .&#2319;&#2350;.&#2337;&#2368;. &#2352;&#2366;&#2358;&#2367;
                                        (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375; )">
                                    <ItemTemplate>
                                        <%#Eval("EMDAmount_N")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2332;&#2350;&#2366;
                                        &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTenderSubmissionDate_D" runat="server" Text='<%#Eval("TenderSubmissionDate_D")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;">
                                    <ItemTemplate>
                                        <a href="DIB_014_TenderEvaluation.aspx?ID=<%#new APIProcedure().Encrypt(Eval("TenderTrId_I").ToString()) %>">&#2337;&#2366;&#2335;&#2366;
                                            &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</a> 
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns><PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table></div>
        </div>
    </div>
</asp:Content>
