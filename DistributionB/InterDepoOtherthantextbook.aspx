<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InterDepoOtherthantextbook.aspx.cs" Inherits="DistributionB_InterDepoOtherthantextbook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box">
                    <div class="card-header">
                     <h2>&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2309;&#2344;&#2381;&#2340;&#2352;&#2337;&#2367;&#2346;&#2379; </h2>
                          
                    </div>

                     <table style="width: 100%">
                <tr>
                    <td  >
                   &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;  </td>
                    <td>
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox reqirerd"  >
                        </asp:DropDownList>
                    </td>
                    <td style="width: 30%; font-size: medium;" valign="top">
                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td >
                        
                        <asp:DropDownList ID="ddlBookName" runat="server" CssClass="txtbox reqirerd"  >
                        </asp:DropDownList>
                    </td>
                </tr> 
                <tr>
                    <td  >
                        &#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; </td>
                    <td>
                        <asp:TextBox ID="txtOrderNo" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                    <td style="width: 30%; font-size: medium;" valign="top">
                      &#2321;&#2352;&#2381;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                    <td >
                        
                        <asp:TextBox ID="txtOrderDate" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                </tr> 
                <tr>
                    <td  >
                        &#2337;&#2367;&#2346;&#2379; &#2325;&#2361;&#2366; &#2360;&#2375;  </td>
                    <td>
                        <asp:DropDownList ID="ddlDepoFrom" runat="server" CssClass="txtbox reqirerd"  >
                        </asp:DropDownList>
                    </td>
                    <td style="width: 30%; font-size: medium;" valign="top">
                      &#2325;&#2367;&#2360; &#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; </td>
                    <td >
                        
                        <asp:DropDownList ID="ddlDepoTo" runat="server" CssClass="txtbox reqirerd"  >
                        </asp:DropDownList>
                    </td>
                </tr> 
                <tr>
                    <td  >
                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2325;&#2381;&#2351;&#2366; </td>
                    <td>
                        <asp:TextBox ID="txtNoofbooks" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                    <td  >
                        &nbsp;</td>
                    <td >
                        
                        &nbsp;</td>
                </tr> 
                <tr>
                    <td colspan="4"  >
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click" OnClientClick="javascript:return ValidateAllTextForm();" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save  " />
                    </td>
                </tr> 
                         </table> </div> 
</asp:Content>

