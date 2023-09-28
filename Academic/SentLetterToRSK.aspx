<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SentLetterToRSK.aspx.cs"
    Inherits="Academic_SentLetterToRSK" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>&#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2367;&#2340; /&#2309;&#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2367;&#2340; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2361;&#2375;&#2340;&#2369; &#2346;&#2340;&#2381;&#2352;
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>

            <table>
                <tr>
                    <td colspan="4" style="font-weight: bold">
                        <asp:HiddenField ID="HiddenField3" runat="server" />

                    </td>
                </tr>
                <tr>
                    <td>&#2360;&#2306;&#2360;&#2381;&#2341;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td colspan="3">



                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&#2344;&#2367;&#2327;&#2350; &#2325;&#2366; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</td>
                    <td>



                        <asp:TextBox ID="txtLetterNo1" MaxLength="50" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>



                    </td>
                    <td>&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                    <td>
                        <asp:TextBox ID="txtLelleterdate1" MaxLength="12" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>

                        <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="txtLelleterdate1"
                            Format="dd/MM/yyyy" runat="server">
                        </cc1:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td>&#2309;&#2346;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375;&#2306; </td>
                    <td colspan="3">



                        <asp:FileUpload ID="FileUpload1" runat="server" />



                    </td>
                </tr>
                <tr>
                    <td>&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; </td>
                    <td colspan="3">



                        <asp:TextBox ID="txtRemarka" MaxLength="150" CssClass="txtbox reqirerd" runat="server" Height="44px" TextMode="MultiLine" Width="291px"></asp:TextBox>



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
                            PageSize="25" CssClass="tab" EmptyDataText="Data Not Found" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DepName_V" HeaderText="&#2360;&#2306;&#2360;&#2381;&#2341;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:BoundField DataField="LetterNo" HeaderText="&#2344;&#2367;&#2327;&#2350; &#2325;&#2366;  &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" />
                                <asp:BoundField DataField="LetterDate" HeaderText="&#2344;&#2367;&#2327;&#2350; &#2325;&#2366;  &#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />

                                <asp:BoundField DataField="Remark" HeaderText="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; " />
                                <asp:TemplateField HeaderText="&#2309;&#2346;&#2354;&#2379;&#2337; &#2347;&#2366;&#2311;&#2354; ">
                                    <ItemTemplate>
                                        <a href='<%#Eval("FileUpload")%>' target="_blank">Show Document</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="डाटा में सुधार करे">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="LinkEdit" CommandName="select" CssClass="btn btn-sm btn-primary"><i class="bi bi-pencil"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="3" align="center">&nbsp;</td>
                </tr>
            </table>


            <table>
                <tr>
                    <td colspan="4" style="font-weight: bold">
                        <asp:HiddenField ID="HiddenField1" runat="server" />

                    </td>
                </tr>
                <tr>
                    <td>&#2344;&#2367;&#2327;&#2350; &#2325;&#2366; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2319;&#2357;&#2306; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                    <td colspan="3">



                        <asp:DropDownList ID="ddlNigamLetter" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>RSK &#2325;&#2366; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</td>
                    <td>



                        <asp:TextBox ID="txtLetterNo" MaxLength="50" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>



                    </td>
                    <td>&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                    <td>
                        <asp:TextBox ID="txtLelleterdate" MaxLength="12" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>

                        <cc1:CalendarExtender ID="CalendarExtender2" TargetControlID="txtLelleterdate"
                            Format="dd/MM/yyyy" runat="server">
                        </cc1:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td>&#2309;&#2346;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375;&#2306; </td>
                    <td colspan="3">



                        <asp:FileUpload ID="FileUpload2" runat="server" />



                    </td>
                </tr>
                <tr>
                    <td>&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; </td>
                    <td colspan="3">



                        <asp:TextBox ID="txtRemark" MaxLength="150" CssClass="txtbox reqirerd" runat="server" Height="44px" TextMode="MultiLine" Width="291px"></asp:TextBox>



                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="font-weight: bold">
                        <asp:Button ID="Button1" runat="server"
                            CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " OnClick="Button1_Click" />
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GridView2" AutoGenerateColumns="False" DataKeyNames="id"
                            PageSize="25" CssClass="tab" EmptyDataText="Data Not Found" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="LeeterN" HeaderText="&#2344;&#2367;&#2327;&#2350; &#2325;&#2366;  &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2319;&#2357;&#2306; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" />
                                <asp:BoundField DataField="LetterDate" HeaderText=" RSK &#2325;&#2366; &#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />

                                <asp:BoundField DataField="LetterNO" HeaderText=" RSK &#2325;&#2366;  &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" />

                                <asp:BoundField DataField="Remark" HeaderText="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; " />

                                <asp:TemplateField HeaderText="डाटा में सुधार करे">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="LinkEdit" CommandName="select" CssClass="btn btn-sm btn-primary"><i class="bi bi-pencil"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="3" align="center">&nbsp;</td>
                </tr>
            </table>


        </div>
    </div>
</asp:Content>

