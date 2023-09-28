<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="addSubject.aspx.cs" Inherits="Academic_addSubject" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                &#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2350;&#2375;&#2306; &#2354;&#2375;&#2326;&#2325; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366;&nbsp; &#2309;&#2306;&#2358;&nbsp; &#2332;&#2379;&#2396;&#2375; &#2332;&#2366;&#2344;&#2375; &#2360;&#2306;&#2348;&#2343;&#2368;
            </h2>
        </div>
        <div style="padding: 0 10px;">
             <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <cc1:TabContainer ID="tcTitle" runat="server">
                <cc1:TabPanel ID="tbOrderIssue" HeaderText="&#2354;&#2375;&#2326;&#2325; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2309;&#2306;&#2358; &#2332;&#2379;&#2396; &#2332;&#2366;&#2344;&#2375; &#2325;&#2375; &#2360;&#2350;&#2381;&#2348;&#2344;&#2381;&#2343; &#2350;&#2375;&#2306;  " runat="server">
                    <ContentTemplate>
       <table>
                            <tr>
                                <td colspan="4" style="font-weight: bold">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>&#2354;&#2375;&#2326;&#2325; /&#2352;&#2330;&#2344;&#2366;&#2325;&#2366;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                                <td colspan="3">
                                   
                                  
                                   
                                    <asp:TextBox ID="txtlekhak" MaxLength="100" CssClass="txtbox "  runat="server"></asp:TextBox>
                                  
                                   
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</td>
                                <td>
                                   
                                  
                                   
                                    <asp:TextBox ID="txtLetterNoa" MaxLength="8" CssClass="txtbox "  runat="server"></asp:TextBox>
                                  
                                   
                                   
                                </td>
                                <td>&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                                <td>
                                    <asp:TextBox ID="txtLetterDatea" MaxLength="12" CssClass="txtbox " runat="server"></asp:TextBox>
                                   
                                                                      <cc1:CalendarExtender ID="txtDratfNo_CalendarExtender" TargetControlID="txtLetterDatea"
                                        Format="dd/MM/yyyy" runat="server" Enabled="True">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2325;&#2325;&#2381;&#2359;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                                <td>
                                   
                                  
                                   
                                    <asp:DropDownList ID="ddlclass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged">
                                    </asp:DropDownList>
                                  
                                   
                                   
                                </td>
                                <td>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                                <td>
                                    <asp:DropDownList ID="ddltitle" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2357;&#2367;&#2359;&#2351;&#2357;&#2360;&#2381;&#2340;&#2369; </td>
                                <td>
                                   
                                  
                                   
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem Value="0">&#2330;&#2369;&#2344;&#2375; ...</asp:ListItem>
                                        <asp:ListItem>&#2344;&#2367;&#2348;&#2306;&#2343; </asp:ListItem>
                                        <asp:ListItem>&#2325;&#2357;&#2367;&#2340;&#2366; </asp:ListItem>
                                        <asp:ListItem>&#2325;&#2361;&#2366;&#2344;&#2368; </asp:ListItem>
                                    </asp:DropDownList>
                                  
                                   
                                   
                                </td>
                                <td>&#2309;&#2346;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375;&#2306; </td>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="font-weight: bold">
                                    <asp:Button ID="Button1" runat="server" OnClick="btnOrder1_Click" OnClientClick='javascript:return ValidateAllTextForm();'
                                        CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " />
                                    <asp:HiddenField ID="HiddenField2" runat="server" />
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
                                            <asp:BoundField DataField="Name" HeaderText="&#2354;&#2375;&#2326;&#2325; /&#2352;&#2330;&#2344;&#2366;&#2325;&#2366;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                            <asp:BoundField DataField="LetterNo" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" />
                                            <asp:BoundField DataField="LetterDate" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                                            <asp:BoundField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="ClassID" />
                                            <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                            <asp:BoundField DataField="Subject" HeaderText="&#2357;&#2367;&#2359;&#2351;&#2357;&#2360;&#2381;&#2340;&#2369; " />
                                            <asp:TemplateField HeaderText="&#2309;&#2346;&#2354;&#2379;&#2337; &#2347;&#2366;&#2311;&#2354; ">
                                                <ItemTemplate>
                                                    <a href='<%#Eval("FileUpload")%>' target="_blank" >show Details</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                <cc1:TabPanel ID="tbRecieveProof" HeaderText="RSK &#2325;&#2379; &#2346;&#2340;&#2381;&#2352; &#2346;&#2381;&#2352;&#2375;&#2359;&#2367;&#2340; &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;" runat="server">
                    <ContentTemplate>
                       <table>
                            <tr>
                                <td colspan="4" style="font-weight: bold">
                                    <asp:HiddenField ID="HiddenField3" runat="server" />
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>&#2354;&#2375;&#2326;&#2325; /&#2352;&#2330;&#2344;&#2366;&#2325;&#2366;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </td>
                                <td colspan="3">
                                   
                                  
                                   
                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</td>
                                <td>
                                   
                                  
                                   
                                    <asp:TextBox ID="txtLetterNo1" MaxLength="50" CssClass="txtbox "  runat="server"></asp:TextBox>
                                  
                                   
                                   
                                </td>
                                <td>&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                                <td>
                                    <asp:TextBox ID="txtLelleterdate1" MaxLength="12" CssClass="txtbox " runat="server"></asp:TextBox>
                                   
                                                                      <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="txtLelleterdate1"
                                        Format="dd/MM/yyyy" runat="server">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; </td>
                                <td colspan="3">
                                   
                                  
                                   
                                    <asp:TextBox ID="txtRemarka" MaxLength="150" CssClass="txtbox "  runat="server" Height="44px" TextMode="MultiLine" Width="291px"></asp:TextBox>
                                  
                                   
                                   
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="font-weight: bold">
                                    <asp:Button ID="Button2" runat="server" 
                                        CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " OnClick="Button2_Click" />
                                    <asp:HiddenField ID="HiddenField4" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="GridView1" AutoGenerateColumns="False" DataKeyNames="id"
                                        PageSize="25" CssClass="tab"  EmptyDataText="Data Not Found" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  >
                                        <Columns>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="nameandDate" HeaderText="&#2354;&#2375;&#2326;&#2325; /&#2352;&#2330;&#2344;&#2366;&#2325;&#2366;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                            <asp:BoundField DataField="LetterNo" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" />
                                            <asp:BoundField DataField="dateL" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                                           
                                            <asp:BoundField DataField="Remark" HeaderText="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; " />
                                           
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
            </div> </div> 
</asp:Content>

