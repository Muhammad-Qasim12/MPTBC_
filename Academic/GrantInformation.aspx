<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GrantInformation.aspx.cs" 
    Inherits="Academic_GrantInformation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span> &#2309;&#2344;&#2369;&#2342;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <cc1:TabContainer ID="tcTitle" runat="server">
                <cc1:TabPanel ID="tbOrderIssue" HeaderText="&#2309;&#2344;&#2369;&#2342;&#2366;&#2344; &#2350;&#2366;&#2306;&#2327; &#2346;&#2381;&#2352;&#2340;&#2381;&#2352;&#2325; " runat="server">
                    <ContentTemplate>
                       <table>
                            <tr>
                                <td colspan="4" style="font-weight: bold">
                                    <asp:HiddenField ID="hdData" runat="server" />
                                    <asp:Panel class="form-message error" runat="server" ID="Panel1" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="Label1" class="notification" runat="server"></asp:Label>
            </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td> &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; </td>
                                <td colspan="3">
                                    <asp:DropDownList ID="DdlACYear"  CssClass="txtbox " runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2350;&#2366;&#2306;&#2327;&#2325;&#2352;&#2381;&#2340;&#2366; &#2360;&#2306;&#2360;&#2381;&#2341;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDepartment" MaxLength="200" CssClass="txtbox " runat="server"></asp:TextBox>
                                  
                                   
                                </td>
                                <td>&#2350;&#2342;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMad" MaxLength="100" CssClass="txtbox " runat="server"></asp:TextBox>
                                   
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>&#2350;&#2366;&#2306;&#2327;&#2325;&#2352;&#2381;&#2340;&#2366; &#2360;&#2306;&#2360;&#2381;&#2341;&#2366; &#2325;&#2366; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </td>
                                <td>
                                    <asp:TextBox ID="txtLetterNo" MaxLength="20" CssClass="txtbox " runat="server"></asp:TextBox>
                                  
                                   
                                </td>
                                <td>&nbsp;&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLetterDate" CssClass="txtbox reqirerd" runat="server" ></asp:TextBox>
                                    <cc1:CalendarExtender ID="ccextendTxtExpectedRetDate" TargetControlID="txtLetterDate"
                                        Format="dd/MM/yyyy" runat="server" Enabled="True">
                                    </cc1:CalendarExtender>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>&#2309;&#2344;&#2369;&#2342;&#2366;&#2344; &#2352;&#2366;&#2358;&#2368; </td>
                                <td>
                                    <asp:TextBox ID="txtAmount" MaxLength="10" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnSignedInteger(event, this);" runat="server"></asp:TextBox>
                                  
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="4" style="font-weight: bold">
                                    <asp:Button ID="btnOrder" runat="server" OnClick="btnOrder_Click" 
                                        CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="grdSelectedTitle" AutoGenerateColumns="False" DataKeyNames="GratnID"
                                        PageSize="25" CssClass="tab"  EmptyDataText="No title selected" runat="server" OnSelectedIndexChanged="grdSelectedTitle_SelectedIndexChanged">
                                        <Columns>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Fyyear" HeaderText="&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; " />
                                            <asp:BoundField DataField="DepartmentName" HeaderText="&#2350;&#2366;&#2306;&#2327;&#2325;&#2352;&#2381;&#2340;&#2366; &#2360;&#2306;&#2360;&#2381;&#2341;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                                            <asp:BoundField DataField="Mad" HeaderText="&#2350;&#2342; " />
                                            <asp:BoundField DataField="LetterNo" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" />
                                            <asp:BoundField DataField="LetterDate" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                                            <asp:BoundField HeaderText="&#2309;&#2344;&#2369;&#2342;&#2366;&#2344; &#2352;&#2366;&#2358;&#2368; " DataField="Amount" />
                                            <asp:CommandField ShowSelectButton="True" />
                                        </Columns>  <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td colspan="3" align="center">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="tbRecieveProof" HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;" runat="server">
                    <ContentTemplate>
                       <table>
                            <tr>
                                <td colspan="4" style="font-weight: bold">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:Panel class="form-message error" runat="server" ID="Panel2" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="Label2" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2350;&#2366;&#2306;&#2327;&#2325;&#2352;&#2381;&#2340;&#2366; &#2360;&#2306;&#2360;&#2381;&#2341;&#2366; &#2325;&#2366; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2319;&#2357;&#2306; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                                <td>
                                    <asp:DropDownList ID="ddlLetterNo"  CssClass="txtbox reqirerd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLetterNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                  
                                   
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="Label3" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2344;&#2367;&#2327;&#2350; &#2325;&#2366; &#2360;&#2306;&#2342;&#2352;&#2381;&#2349;&#2367;&#2340; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</td>
                                <td>
                                   
                                  
                                   
                                    <asp:TextBox ID="txtLetterNoa" MaxLength="50" CssClass="txtbox reqirerd"  runat="server"></asp:TextBox>
                                  
                                   
                                   
                                </td>
                                <td>&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                                <td>
                                    <asp:TextBox ID="txtLetterDatea" MaxLength="12" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                                   
                                                                      <cc1:CalendarExtender ID="txtDratfNo_CalendarExtender" TargetControlID="txtLetterDatea"
                                        Format="dd/MM/yyyy" runat="server">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2327;&#2312; &#2352;&#2366;&#2358;&#2367;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmounta" MaxLength="8" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnSignedInteger(event, this);" runat="server"></asp:TextBox>
                                  
                                   
                                </td>
                                <td>&#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;&nbsp;
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPayment" runat="server">
                                        <asp:ListItem>DD</asp:ListItem>
                                        <asp:ListItem>Check</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                                <td>
                                   
                                  
                                   
                                    <asp:TextBox ID="txtBankName" MaxLength="8" CssClass="txtbox reqirerd"  runat="server"></asp:TextBox>
                                  
                                   
                                   
                                </td>
                                <td>&nbsp;&#2337;&#2368;.&#2337;&#2368;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtdddNo" CssClass="txtbox reqirerd" runat="server" ></asp:TextBox>
                                   
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>&#2337;&#2368;.&#2337;&#2368;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                                <td>
                                    <asp:TextBox ID="txtddDate" MaxLength="10" CssClass="txtbox reqirerd"  runat="server"></asp:TextBox>
                                   <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="txtddDate"
                                        Format="dd/MM/yyyy" runat="server">
                                    </cc1:CalendarExtender>
                                </td>
                                <td>&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; </td>
                                <td>
                                    <asp:TextBox ID="txtRemark" MaxLength="200" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                                  
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>&#2358;&#2366;&#2360;&#2344; &#2350;&#2306;&#2337;&#2354; &#2360;&#2375; &#2309;&#2344;&#2369;&#2350;&#2340;&#2367; </td>
                                <td>
                                    <asp:DropDownList ID="ddlLetterNo0"  CssClass="txtbox reqirerd" runat="server">
                                        <asp:ListItem Value="0">&#2330;&#2369;&#2344;&#2375; </asp:ListItem>
                                        <asp:ListItem>&#2346;&#2370;&#2352;&#2381;&#2357; &#2350;&#2375;&#2306; </asp:ListItem>
                                        <asp:ListItem>&#2325;&#2366;&#2352;&#2381;&#2351;&#2379;&#2340;&#2381;&#2340;&#2352; </asp:ListItem>
                                    </asp:DropDownList>
                                  
                                   
                                </td>
                                <td>&#2348;&#2376;&#2336;&#2325; &#2325;&#2366; &#2348;&#2367;&#2306;&#2342;&#2369; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </td>
                                <td>
                                    <asp:TextBox ID="txtDratfNo" MaxLength="200" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                                  

                                  
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>&#2358;&#2366;&#2360;&#2344; &#2325;&#2368; &#2348;&#2376;&#2336;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </td>
                                <td>
                                    <asp:TextBox ID="txtMettingNo" MaxLength="200" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                                  
                                   
                                </td>
                                <td>&#2348;&#2376;&#2336;&#2325; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                                <td>
                                    <asp:TextBox ID="txtMettingDate" MaxLength="200" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                                  
                                   <cc1:CalendarExtender ID="CalendarExtender2" TargetControlID="txtMettingDate"
                                        Format="dd/MM/yyyy" runat="server">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="font-weight: bold">
                                    <asp:Button ID="Button1" runat="server" OnClick="btnOrder1_Click" 
                                        CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="grdSelectedTitle1" AutoGenerateColumns="False" DataKeyNames="id"
                                        PageSize="25" CssClass="tab"  EmptyDataText="No title selected" runat="server" OnSelectedIndexChanged="grdSelectedTitle1_SelectedIndexChanged" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DepartmentName" HeaderText="&#2350;&#2366;&#2306;&#2327;&#2325;&#2352;&#2381;&#2340;&#2366; &#2360;&#2306;&#2360;&#2381;&#2341;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                                            <asp:TemplateField HeaderText="&#2350;&#2366;&#2306;&#2327;&#2325;&#2352;&#2381;&#2340;&#2366; &#2360;&#2306;&#2360;&#2381;&#2341;&#2366;  &#2325;&#2366; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352; &#2319;&#2357;&#2306; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; ">
                                                <ItemTemplate>
                                                  <%# Eval("LetterNoDate") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="LetterNo" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" />
                                            <asp:BoundField DataField="LetterDate" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                                            <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2327;&#2312; &#2352;&#2366;&#2358;&#2367; " DataField="Amount" />
                                            <asp:BoundField DataField="BankNamw" HeaderText="&#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                            <asp:BoundField DataField="DDNO" HeaderText="&#2337;&#2368;.&#2337;&#2368;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; " />
                                            <%--<asp:BoundField DataField="ddDate" HeaderText="&#2337;&#2368;.&#2337;&#2368;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />--%>
                                            <asp:CommandField ShowSelectButton="True" />
                                        </Columns>  <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td colspan="3" align="center">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </cc1:TabPanel>
            </cc1:TabContainer>
        </div>
    </div>
</asp:Content>

