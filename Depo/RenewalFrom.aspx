<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RenewalFrom.aspx.cs" Inherits="Depo_RenewalFrom" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box table-responsive">
        <div class="card-header">
            <h2>
                &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; <span>&nbsp;&#2346;&#2306;&#2332;&#2368;&#2351;&#2344; &#2344;&#2357;&#2368;&#2344;&#2325;&#2352;&#2339; </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left" colspan="6">
                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; : 
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </td>
                </tr>


                <tr>
                    <td style="text-align: left">
                        &#2344;&#2357;&#2368;&#2344;&#2368;&#2325;&#2352;&#2339; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                     <td style="text-align: left" >
                         <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
                              <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt1" Format="dd/MM/yyyy">
                                         </cc1:CalendarExtender>
                    </td>
                     <td style="text-align: left" >
                         &#2309;&#2357;&#2343;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                     <td style="text-align: left" >
                         <asp:TextBox ID="txtFromdate" runat="server" AutoPostBack="True" OnTextChanged="txtFromdate_TextChanged"></asp:TextBox>
                           <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromdate" Format="dd/MM/yyyy">
                                         </cc1:CalendarExtender>
                    </td>
                     <td style="text-align: left" >
                         &#2340;&#2325; </td>
                     <td style="text-align: left" >
                         <asp:TextBox ID="txttilldate" runat="server"></asp:TextBox>
                          <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txttilldate" Format="dd/MM/yyyy">
                                         </cc1:CalendarExtender>
                    </td>
                </tr>


                <tr>
                    <td style="text-align: left">
                        &#2352;&#2366;&#2358;&#2368; &#2332;&#2350;&#2366; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; </td>
                     <td style="text-align: left" >
                         <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                             <asp:ListItem Selected="True" Value="1">&#2337;&#2368;.&#2337;&#2368;. &#2360;&#2375; </asp:ListItem>
                             <asp:ListItem Value="2">&#2344;&#2327;&#2342;</asp:ListItem>
                         </asp:RadioButtonList>
                    </td>
                     <td style="text-align: left" >
                         &nbsp;</td>
                     <td style="text-align: left" >
                         &nbsp;</td>
                     <td style="text-align: left" >
                         &nbsp;</td>
                     <td style="text-align: left" >
                         &nbsp;</td>
                </tr>


                <tr>
                    <td style="text-align: left">
                        &#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                     <td style="text-align: left" >
                         <asp:DropDownList ID="DDLBank" runat="server">
                         </asp:DropDownList>
                    </td>
                     <td style="text-align: left" >
                         &#2337;&#2368;.&#2337;&#2368;/&#2344;&#2325;&#2342; &#2352;&#2360;&#2368;&#2342; &#2344;&#2306;&#2348;&#2352;</td>
                     <td style="text-align: left" >
                         <asp:TextBox ID="txtDDNo" runat="server"></asp:TextBox>
                    </td>
                     <td style="text-align: left" >
                         &#2337;&#2368;.&#2337;&#2368;./&#2344;&#2325;&#2342;
                         <br />
                         &#2352;&#2360;&#2368;&#2342; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                     <td style="text-align: left" >
                         <asp:TextBox ID="txtDDdate" runat="server"></asp:TextBox>
                          <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDDdate" Format="dd/MM/yyyy">
                                         </cc1:CalendarExtender>
                    </td>
                </tr>


                <tr>
                    <td style="text-align: left">
                        &#2352;&#2366;&#2358;&#2367; &#2352;&#2370;. &#2350;&#2375;&#2306; </td>
                     <td style="text-align: left" >
                         <asp:TextBox ID="txtAmount"   onkeyup='javascript:tbx_fnSignedNumericCheck(this);' runat="server"></asp:TextBox>
                    </td>
                     <td style="text-align: left" >
                         &#2332;&#2368;.&#2319;&#2360;.&#2335;&#2368;. &#2344;&#2306;&#2348;&#2352;</td>
                     <td style="text-align: left" >
                         <asp:TextBox ID="txtGST" runat="server"></asp:TextBox>
                    </td>
                     <td style="text-align: left" >
                         &#2310;&#2343;&#2366;&#2352; &#2344;&#2306;&#2348;&#2352; </td>
                     <td style="text-align: left" >
                         <asp:TextBox ID="txtadhar" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr> <td style="text-align: left">&#2357;&#2367;&#2354;&#2350;&#2381;&#2348; &#2358;&#2369;&#2354;&#2381;&#2325; </td><td style="text-align: left"><asp:TextBox ID="txtBilam"   onkeyup='javascript:tbx_fnSignedNumericCheck(this);' runat="server"></asp:TextBox></td><td style="text-align: left"></td><td style="text-align: left"></td><td style="text-align: left"></td><td style="text-align: left"></td></tr>

                <tr>
                    <td style="text-align: left" colspan="6">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" Height="38px" OnClick="Button1_Click" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" />
                    </td>
                </tr>


            </table>


        </div>
         </div>
</asp:Content>

