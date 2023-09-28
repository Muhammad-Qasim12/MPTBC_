<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateChallan.aspx.cs" Inherits="Depo_UpdateChallan" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="card-header">
        <h2>
            <span>&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2349;&#2375;&#2332;&#2375; &#2327;&#2351;&#2375; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;  </span></h2>
    </div>
     <table width="100%">
                                                                  
                                 <tr>
                                    <td>
                                        &#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                     </td>
                                    <td>
                                        &#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                     </td>
                                </tr>
                                 
                                 <tr>
                                    <td>
                                        &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352;&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtGrNo" runat="server" CssClass="txtbox reqirerd" MaxLength="20"></asp:TextBox></td>
                                    <td>
                                        &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                                    <td>
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="txtbox reqirerd" MaxLength="14"></asp:TextBox></td>
                                </tr>
                                 
                                 <tr>
                                    <td>
                                          
                                           &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                                    <td>
                                          <asp:TextBox ID="txtPdate" runat="server" CssClass="txtbox reqirerd" MaxLength="20" Enabled="false" ></asp:TextBox>
                                          <cc1:calendarextender ID="txtDate_CalendarExtender" runat="server" 
                                            TargetControlID="txtPdate" Format="dd/MM/yyyy">
        </cc1:calendarextender>
     
                                            </td>
                                    <td>
                                        &#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352; </td>
                                    <td>
                                        <asp:TextBox ID="txtTruckNo" runat="server" CssClass="txtbox reqirerd" 
                                             MaxLength="10"></asp:TextBox>
                                        </td>
                                </tr>
                                 
                                <tr>
                                <td colspan="4">
                                
                                
                                </td>
                                </tr>
                                <tr > 
                                    <td style="text-align: center; height: 20px;" colspan="4" class="card-header">
                                      
                                     <h2>  &#2337;&#2367;&#2346;&#2379; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2325;&#2367;&#2351;&#2375; &#2327;&#2351;&#2375; &#2357;&#2381;&#2351;&#2351; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;/Expense Details By Depot</h2>  </td>
                                </tr>
                               <tr >
                                    <td>
                                        &#2313;&#2340;&#2352;&#2366;&#2312;</td>
                                    <td>
                                        <asp:TextBox ID="txtunloding" runat="server" CssClass="txtbox" MaxLength="5"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);' Text="0"></asp:TextBox></td>
                                    <td>
                                        &#2330;&#2338;&#2366;&#2312;</td>
                                    <td>
                                        <asp:TextBox ID="txtloding" runat="server" CssClass="txtbox" MaxLength="5"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);' Text="0"></asp:TextBox></td>
                                </tr>
                                <tr >
                                    <td>
                                        &#2346;&#2352;&#2367;&#2357;&#2361;&#2344;</td>
                                    <td>
                                        <asp:TextBox ID="txtTransport" runat="server" CssClass="txtbox" MaxLength="5"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);' Text="0"></asp:TextBox></td>
                                    <td>
                                        &#2309;&#2344;&#2381;&#2351;</td>
                                    <td>
                                        <asp:TextBox ID="txtOther" runat="server" CssClass="txtbox" MaxLength="5"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);' Text="0"></asp:TextBox></td>
                                </tr>
                                <tr >
                                    <td style="height: 26px">
                                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                                    <td colspan="3" style="height: 26px">
                                        <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="txtbox reqirerd">
                                            <asp:ListItem>Select..</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>

                                <tr >
                                    <td style="height: 26px" colspan="4">
                                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " />
                                    </td>
                                </tr>

    </table>
</asp:Content>

