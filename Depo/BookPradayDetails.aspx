<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookPradayDetails.aspx.cs" Inherits="Depo_BookPradayDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="box">
        <div class="card-header">
            <h2>
                &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">

             <table width="100%">
                <tr>
                    <td>
                        &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;</td>
                    <td>
                        <asp:DropDownList ID="DdlMedium" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &#2325;&#2325;&#2381;&#2359;&#2366; </td>
                    <td>
                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="txtbox reqirerd">
                            <asp:ListItem Value="1,2,3,4,5,6,7,8">1-8</asp:ListItem>
                            <asp:ListItem Value="9,10,11,12">9-12</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlDepot" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td >
                        &#2360;&#2340;&#2381;&#2352; </td>
                    <td >
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                    </td>
                    <td >
                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;
                    </td>
                    <td >
                        <asp:DropDownList ID="ddlbooktype" runat="server" CssClass="txtbox">
                            <asp:ListItem Value="1">&#2351;&#2379;&#2332;&#2344;&#2366; </asp:ListItem>
                            <asp:ListItem Value="2">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td  colspan="4">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show data"  OnClientClick="return ValidateAllTextForm();" />
                    </td>
                </tr>
                <tr>
                    <td  colspan="4">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns>
                                  <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("TitleID_I") %>' />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt1" runat="server" Height="31px" Width="76px" Text='<%#Eval ("MainDemand") %>' onkeypress='javascript:tbx_fnNumeric(event, this);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2360;&#2375;&#2335;&#2375;&#2354;&#2366;&#2311;&#2335; &#2337;&#2367;&#2346;&#2379; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt2" runat="server" Height="31px" Width="76px" Text='<%#Eval ("Selelight") %>' onkeypress='javascript:tbx_fnNumeric(event, this);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2309;&#2306;&#2340;&#2352;&#2337;&#2367;&#2346;&#2379; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt3" runat="server" Height="31px" Width="76px" Text='<%#Eval ("InterDepo") %>' onkeypress='javascript:tbx_fnNumeric(event, this);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="2 % RKS">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt4" runat="server" Height="31px" Width="76px" Text='<%#Eval ("2PerRKS") %>' onkeypress='javascript:tbx_fnNumeric(event, this);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2348;&#2347;&#2352; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt5" runat="server" Height="31px" Width="76px" Text='<%#Eval ("Bafar") %>' onkeypress='javascript:tbx_fnNumeric(event, this);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2309;&#2344;&#2381;&#2351; ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt6" runat="server" Height="31px" Width="76px" Text='<%#Eval ("Other") %>' onkeypress='javascript:tbx_fnNumeric(event, this);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td  colspan="4">
                        <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="Save" Visible="False" />
                    </td>
                </tr></table> 
            </div> </div> 
</asp:Content>

