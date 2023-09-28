<%@ Page Title="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2379; &#2348;&#2367;&#2354; &#2350;&#2375;&#2306; &#2332;&#2379;&#2396;&#2344;&#2375; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ChallanreportDepo.aspx.cs" Inherits="Printing_ChallanSendByDepo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      
        <div class="portlet-content">
         <div><table>
                <tr>
                    <td style="text-align: left">
                        <%-- <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375;"   
                            onclick="btnSave_Click" />--%>
                        <table>
                            <tr>
                                <td align="center" >
                                    <table  >
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <center style="width: 100px; height: 25px">
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" 
                                onselectedindexchanged="DdlACYear_SelectedIndexChanged">
                                <asp:ListItem>..Select..</asp:ListItem>
                                <asp:ListItem>2012-13</asp:ListItem>
                                <asp:ListItem>2013-14</asp:ListItem>
                                <asp:ListItem>2014-15</asp:ListItem>
                            </asp:DropDownList>
                                    <asp:Label ID="Label1" runat="server" Text="&#2350;&#2343;&#2381;&#2351;&#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; "></asp:Label>
                            <asp:DropDownList ID="ddlPrinter" runat="server" AutoPostBack="True" 
                                
                                OnSelectedIndexChanged="ddlPrinter_SelectedIndexChanged">
                            </asp:DropDownList>
                                    </center> 
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center"  >&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style2">
                                <center style="width: 1096px"> 
                                    <asp:Label ID="Label2" runat="server" Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;"></asp:Label>
                                    </center> 
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdChallanDetail" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" 
                            onselectedindexchanged="GrdChallanDetail_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                    <ItemTemplate>
                                        <%#Eval("NameofPress_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <%#Eval("ChallanNo_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <%#Eval("ChallanDate")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2325; ">
                                    <ItemTemplate>
                                        <%#Eval("Receiveddate_D")%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2349;&#2375;&#2332;&#2375; &#2327;&#2319; &#2348;&#2339;&#2381;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                    <ItemTemplate>
                                        <%#Eval("TotalNoOfReceiveBundle_I")%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2379; &#2348;&#2339;&#2381;&#2337;&#2354; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                    <ItemTemplate>
                                        <%#Eval("TotalNoOfReceiveBundle_I")%>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;">
                                    <ItemTemplate>
                                        <%#Eval("TitleHindi_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; ">
                                    <ItemTemplate>
                                        <%#Eval("NoOFgenralBook_I")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;  &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &#2351;&#2379;&#2332;&#2344;&#2366; ">
                                    <ItemTemplate>
                                        <%#Eval("NofSchemeBook_I")%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText=" &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2360;&#2366;&#2311;&#2395; ">
                                    <ItemTemplate>
                                        <%#Eval("BookDimention_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
          </div>
        </div>    
</asp:Content>


<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style2
        {
            width: 1154px;
        }
        .style3
        {
            width: 98%;
        }
    </style>
</asp:Content>



