<%@ Page Title="&#2337;&#2375; &#2348;&#2369;&#2325; / Day Book" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DayBookReport.aspx.cs" Inherits="Depo_DayBookReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span style="height: 1px">&#2337;&#2375; &#2348;&#2369;&#2325; / Day Book</span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
          
           
                <table width="100%">
                    <tr>
                        <td colspan="7">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">&#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; </asp:ListItem>
                                <asp:ListItem Value="2">&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; </asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                   
                  
                    <tr>
                        <td>
                            &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375; / Date From
                            <br />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox1" Format="dd/MM/yyyy">
                     </cc1:CalendarExtender>
                        
                        
                        </td>
                        <td>
                            &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325; Date To</td>
                        <td>
                            <asp:TextBox ID="TextBox2" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" TargetControlID="TextBox2" Format="dd/MM/yyyy">
                     </cc1:CalendarExtender>
                        
                        
                        </td>
                        <td>
                            &#2325;&#2325;&#2381;&#2359;&#2366;
                        </td>
                        <td>
                <asp:DropDownList ID="DDLClass" runat="server"  CssClass="txtbox " >
                    <asp:ListItem>1-8</asp:ListItem>
                    <asp:ListItem>9-12</asp:ListItem>

                </asp:DropDownList>
                        </td>
                        <td>
                        &nbsp;
                        </td>
                    </tr>
                   
                  
                    <tr>
                        <td>
                            &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;
                        </td>
                        <td>
                <asp:DropDownList ID="ddlMedium" runat="server"  CssClass="txtbox  reqirerd" >

                </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="Button3" runat="server" CssClass="btn" onclick="Button3_Click" OnClientClick="return ValidateAllTextForm();" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306; / Report" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                  
                </table>
            <div style="overflow: scroll; width="1200px"">
                                    <rsweb:reportviewer id="ReportViewer1" width="100%" runat="server" documentmapwidth="100%"
                                        height="" sizetoreportcontent="True">
                                     </rsweb:reportviewer>  </div>
            </div>
      
    </div>
</asp:Content>

