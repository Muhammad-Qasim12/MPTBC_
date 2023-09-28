<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TrnsferChallan.aspx.cs" Inherits="Depo_TrnsferChallan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="card-header">
            <h2>
                &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325; &#2337;&#2367;&#2346;&#2379; &#2348;&#2342;&#2354;&#2375; </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;/ Year :<asp:HiddenField ID="HiddenField2" runat="server" />
&nbsp;<asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
                      </td> 
                    <td style="text-align: left">&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; :
                        <asp:DropDownList ID="ddlPrinter" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="ddlPrinter_SelectedIndexChanged" >
            </asp:DropDownList>
                      </td> <td> &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; :
            <asp:DropDownList ID="ddlDepot" runat="server" CssClass="txtbox">
            </asp:DropDownList></td>
                    <td> &nbsp; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; :
            <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox">
            </asp:DropDownList></td>
                    <td><asp:Button ID="btnAdd0" runat="server" CssClass="btn" OnClick="btnAdd0_Click" Text="&#2337;&#2366;&#2335;&#2366; &#2342;&#2375;&#2326;&#2375; " Width="157px" /></td>
                </tr>

                <tr>
                    <td style="text-align: left" colspan="5">
                        <asp:GridView ID="GrdChallan" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="tab hastable" OnRowDataBound="GrdChallan_RowDataBound" onselectedindexchanged="GrdChallan_SelectedIndexChanged" PageSize="20" ShowFooter="True" ShowHeader="true" OnPageIndexChanging="GrdChallan_PageIndexChanging1">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                <ItemTemplate>
                                    <%# Eval("DepoName_V")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Eval("ChalanNo")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Eval("ChalanDate")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                <ItemTemplate>
                                    <%# Eval("TitleHindi_V")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  ">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("TotalNoOfBooks")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2306;&#2348;&#2352; &#2360;&#2375; - &#2340;&#2325;  ">
                                <ItemTemplate>
                                    <%# Eval("BooksFrom") %>- <%# Eval("BooksTo")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; ">
                                <ItemTemplate>
                                    <%# Eval("BookType").ToString()=="1" ? "&#2351;&#2379;&#2332;&#2344;&#2366;" : "&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;"    %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("PriTransID").ToString() %>' />
                                    <asp:LinkButton ID="LinkButton1" runat="server" visible='<%# Eval("Isdepotstatus").ToString()=="1" ? false  : true %>'  OnCommand='<%#Eval("PriTransID").ToString() %>' OnClick="btnClick">&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325; &#2337;&#2367;&#2346;&#2379; &#2348;&#2342;&#2354;&#2375; </asp:LinkButton>
                                   <%-- <a   href='CreateChallan.aspx?Cid=<%#new APIProcedure().Encrypt( Eval("PriTransID").ToString()) %>'  > </a>
                               --%>
                                
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" ">
                                <ItemTemplate>
                                    <a href='PrinterChallanRpt.aspx?ID=&#039;<%#Eval("PriTransID") %>&#039;'>&#2330;&#2366;&#2354;&#2366;&#2344; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="Gvpaging" />
                        <EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView></td> 
                </tr>

            </table></div>
     <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
            </div>
            <div id="Messages" style="display: none;" class="popupnew" runat="server">


               &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325; &#2337;&#2367;&#2346;&#2379; &#2325;&#2366;  &#2344;&#2366;&#2350; : 
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList> 
                <asp:Button ID="Button1" runat="server" Text="Change" OnClick="Button11" />
                <asp:Button ID="Button2" runat="server" Text="Close" OnClick="Button22" />
                </div> 
</asp:Content>

