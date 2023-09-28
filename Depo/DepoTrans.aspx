<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepoTrans.aspx.cs" Inherits="Depo_DepoTrans" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box">
        <div class="card-header">
            <h2>
                &#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2347;&#2352; &#2310;&#2342;&#2375;&#2358;</h2>
        </div>
        <div style="padding: 0 10px;">
           
            
            <table width="100%">
                <tr>
                    <td>
                        &#2310;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &nbsp;
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                        </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="&#2337;&#2366;&#2335;&#2366; &#2342;&#2375;&#2326;&#2375; " CssClass="btn" OnClick="Button1_Click" />
                         </td>
                    </tr> 
                <tr>
                    <td>
                        &#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2379;
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrderNo" runat="server" CssClass="txtbox reqirerd" Enabled="False"></asp:TextBox>
                        </td>
                    <td>
                        &#2310;&#2352;&#2381;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                        <asp:TextBox ID="txtDate" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                          <cc1:calendarextender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtDate">
                                    </cc1:calendarextender>
                         </td>
                    </tr> 
                <tr>
                    <td>
                        &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2379; .</td>
                    <td>
                        <asp:TextBox ID="txtBillTiNo" runat="server" CssClass="txtbox reqirerd"  ></asp:TextBox>
                         
                        </td>
                    <td>
                        &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                        <asp:TextBox ID="txtbiltiDate" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                         <cc1:calendarextender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtbiltiDate">
                                    </cc1:calendarextender>
                         </td>
                    </tr> 
                <tr>
                    <td>
                        &#2335;&#2381;&#2352;&#2325; &#2344;&#2379;.</td>
                    <td>
                        <asp:TextBox ID="txtTruckNo" runat="server"></asp:TextBox>
                         
                        </td>
                    <td>
                        &#2335;&#2381;&#2352;&#2325; &#2337;&#2381;&#2352;&#2366;&#2312;&#2357;&#2352; &#2344;&#2306;&#2348;&#2352;
                        <asp:TextBox ID="txtTruckDriver" runat="server"></asp:TextBox>
                         </td>
                    </tr> 
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns>
                                <asp:BoundField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366;  &#2344;&#2366;&#2350; " DataField="b" />
                                <asp:BoundField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; " DataField="TitleHindi_V" />
                                <asp:BoundField DataField="SubTitleHindi_V" HeaderText="&#2313;&#2346; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; " />
                                <asp:BoundField DataField="TotalNoofBooks" HeaderText="&#2310;&#2342;&#2375;&#2358;&#2367;&#2340; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366; &#2330;&#2369;&#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " DataField="Distribute" />
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("DepoTo")%>' />
                                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("SubID")%>' />
                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    </tr> 
                <tr>
                    <td colspan="3">
                        <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="&#2360;&#2375;&#2357; &#2325;&#2352;&#2375; " />
                    </td>
                    </tr> </table> </div> 
         </div> 
</asp:Content>

