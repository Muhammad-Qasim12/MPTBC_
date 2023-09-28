<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GetPaper.aspx.cs" Inherits="CenterDepot_GetPaper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="box">
        <div class="card-header">
            <h2>&#2346;&#2375;&#2346;&#2352; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2375; &#2354;&#2367;&#2319; &#2348;&#2306;&#2337;&#2354; /&#2352;&#2368;&#2354; &#2348;&#2344;&#2366;&#2351;&#2375; </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">

                <table width="100%">
                    
                    <tr style="display:none;">
                        <td colspan="2">&#2310;&#2352;&#2381;&#2337;&#2352; &#2335;&#2366;&#2311;&#2346; </td>
                        <td class="auto-style1" colspan="3">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                <asp:ListItem Value="1" Selected="True">&#2344;&#2351;&#2366; </asp:ListItem>
                                <asp:ListItem>&#2360;&#2369;&#2343;&#2366;&#2352;</asp:ListItem>
                            </asp:RadioButtonList>


                        </td>

                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" CssClass="txtbox reqirerd" Width="119px" Enabled="False"></asp:TextBox>
                            <br />
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="txtbox " AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="false" >
                            </asp:DropDownList>
                </td>
                <td>                    &nbsp;</td>

                        <td>
                            &nbsp;</td>                         

                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>

                        <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; /Acadmic Year </td>
                        <td class="auto-style1">
                    <asp:DropDownList ID="ddlAcYear" Width="120px" runat="server" ></asp:DropDownList>
                        </td>

                        <td class="auto-style1">
                            &#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2335;&#2366;&#2311;&#2346;
                        </td>
                        <td class="auto-style1">
                            <asp:DropDownList ID="ddlGSM" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlGSM_SelectedIndexChanged">
                            </asp:DropDownList>


                        </td>
                        <td>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; </td>
                        <td>
                            <asp:DropDownList ID="ddlVenderFill" runat="server">
                            </asp:DropDownList>
                        </td>
                        
                       
                        <td>
                            <asp:TextBox ID="txtRoleNo" runat="server" Width="126px" CssClass="txtbox reqirerd" Visible="false"></asp:TextBox>
                            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Get Data"  />
                        </td>
                        <td>
                            <asp:Label ID="lblTotal" runat="server" Text="Total Sheets" Visible="false" ></asp:Label>
                            <asp:TextBox ID="txtTotalSheets" runat="server" Width="94px" Visible="false" CssClass="txtbox reqirerd" ></asp:TextBox>
                        </td>
                    </tr>
                    
                  
                   

                </table>  </div></div>

           
       </div>


</asp:Content>

