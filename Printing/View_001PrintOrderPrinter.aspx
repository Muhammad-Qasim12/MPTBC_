<%@ Page Title="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2310;&#2352;&#2381;&#2337;&#2352;" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View_001PrintOrderPrinter.aspx.cs" Inherits="Printing_View_001PrintOrderPrinter" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                <span>&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2310;&#2352;&#2381;&#2337;&#2352; / Print Order</span></h2>
        </div>
       <div class="box table-responsive">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left" width="20%">
                            
                        </td>
                        <td style="text-align: right" width="75%">
                            <asp:TextBox ID="txtSearch" MaxLength="200"  
                                runat="server"></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="5%">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="3">
                            <asp:GridView ID="GrdPaperMaster" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." 
                                PageSize="10"  AllowPaging="True" OnPageIndexChanging="GrdPaperMaster_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/<br>SNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / <br> Letter No.">
                                        <ItemTemplate>
                                            <%#Eval("PrintOrderLetterNo_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / <br> Letter Date">
                                        <ItemTemplate>
                                            <%#Eval("PrintOrderLetterDate_D")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2319;&#2357;&#2306; &#2325;&#2325;&#2381;&#2359;&#2366; / <br> Book title">
                                        <ItemTemplate>
                                            
                                            <%#Eval("TitleHindi_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2371;&#2359;&#2381;&#2336; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / <br> No of Pages">
                                        <ItemTemplate>
                                            <%#Eval("Pages_N")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2350;&#2375;&#2306; &#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2325;&#2367;&#2351;&#2366; &#2332;&#2366;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2350;&#2370;&#2354;&#2381;&#2351;(&#2352;&#2370;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;) / <br> Rate Printed on Book (in Rs.)">
                                        <ItemTemplate>
                                            <%#Eval("Rate_N")%>
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
