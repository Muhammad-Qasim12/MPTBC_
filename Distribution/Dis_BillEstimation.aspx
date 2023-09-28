<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dis_BillEstimation.aspx.cs"
    Inherits="Distrubution_Dis_BillEstimation" MasterPageFile="~/MasterPage.master" %>

 
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
          <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                <ProgressTemplate>
                    <div class="fade">
                    </div>
                    <div class="progress">
                        <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="box table-responsive">
                <div class="card-header">
                    <h2>
                        <span style="font-size: medium;">&#2348;&#2367;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of Bill
                        </span>
                    </h2>
                </div>
                <div class="portlet-content">
                    <div class="table-responsive">
                        <table width="100%">
                            <tr>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:Label ID="LblAcYear" runat="server" >&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br />Academic Year :</asp:Label>
                                    <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:Label ID="LblClass" runat="server" >&#2325;&#2325;&#2381;&#2359;&#2366; <br />Class :</asp:Label>
                                    <asp:DropDownList ID="DdlClass" runat="server" CssClass="txtbox" OnSelectedIndexChanged="DdlClass_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem Value="1,2,3,4,5">1-5</asp:ListItem>
                                        <asp:ListItem Value="6,7,8">6-8</asp:ListItem>
                                        <asp:ListItem Value="9,10,11,12">9-12</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:Label ID="LblScheme" runat="server" >&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; <br />Scheme :</asp:Label>
                                    <asp:DropDownList ID="DdlScheme" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                                </td>
                                 <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:Label ID="Label1" runat="server" >&#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2335;&#2366;&#2311;&#2346; <br />Demand Type:</asp:Label>
                                    <asp:DropDownList ID="DDlDemandType" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td  style="width: 25%; font-size: medium;" valign="top" >
                              
                                    <asp:DropDownList ID="ddlBillDetails" runat="server" Width="300px">
                                        <asp:ListItem Value="100">&#2348;&#2367;&#2354; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; &#2342;&#2375;&#2326;&#2375; / Show Bill</asp:ListItem>
                                        <asp:ListItem Value="80">80 % &#2325;&#2366; &#2348;&#2367;&#2354; &#2342;&#2375;&#2326;&#2375; / Show 80% Bill</asp:ListItem>
                                        <asp:ListItem Value="20">20 % &#2325;&#2366; &#2348;&#2367;&#2354; &#2342;&#2375;&#2326;&#2375; / Show 20% Bill</asp:ListItem>
                                        <asp:ListItem Value="15">
                                            15 % &#2325;&#2366; &#2348;&#2367;&#2354; &#2342;&#2375;&#2326;&#2375; / Show 15% Bill
                                        </asp:ListItem>
                                        <asp:ListItem Value="85">85 % &#2325;&#2366; &#2348;&#2367;&#2354; &#2342;&#2375;&#2326;&#2375; / Show 85% Bill</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                
                                <td style="width: 25%; font-size: medium;" valign="top">&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340;
                                    <asp:TextBox ID="TextBox1" runat="server" Width="65px">100</asp:TextBox>
                                    %</td>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:Button ID="ButtonView85Bill" runat="server" CssClass="btn" OnClick="BtnShow_Click" Text="&#2348;&#2367;&#2354; &#2342;&#2375;&#2326;&#2375; / Show Bill" />
                                </td>
                                <td style="width: 25%; font-size: medium;" valign="top">&nbsp;</td>
                                
                            </tr>
                            <tr>
                                <td  style="text-align: left; " colspan="4" >
                              
                                    &nbsp;</td>
                                
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align: center">
                                    <%--<asp:GridView ID="GrdBillEstimation" runat="server" GridLines="None" CssClass="tab"
                                        EmptyDataText="Record Not Found." Width="100%" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1 %>.
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTitleID_I" runat="server" Text='<%#Eval("TitleID_I") %>' Visible="false"></asp:Label>
                                                    <%#Eval("TitleHindi_V")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Rate_N" HeaderText="Rate"></asp:BoundField>
                                            <asp:BoundField DataField="Total_Allotment" HeaderText="Total Allotment"></asp:BoundField>
                                            <asp:BoundField DataField="Total_Amount" HeaderText="Total Amount"></asp:BoundField>
                                            <asp:BoundField DataField="80_Per_Books" HeaderText="No. of books 80 %"></asp:BoundField>
                                            <asp:BoundField DataField="20_per_Books" HeaderText="No. of books 20 %"></asp:BoundField>
                                            <asp:BoundField DataField="80_per_books_rate" HeaderText="Amount for 80 % books">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="20_per_Books_rate" HeaderText="Amount for 20 % books">
                                            </asp:BoundField>
                                        </Columns>
                                         <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                                    </asp:GridView>--%>
                                    <rsweb:reportviewer id="ReportViewer1" width="100%" runat="server" documentmapwidth="100%"
                                        height="" sizetoreportcontent="True">
                                     </rsweb:reportviewer>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
