<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InsertDepoStock.aspx.cs" Inherits="Depo_InsertDepoStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="box table-responsive">
        <div class="card-header">
            <h2>&#2323;&#2346;&#2344;&#2367;&#2306;&#2327; &#2360;&#2381;&#2335;&#2377;&#2325; &#2361;&#2375;&#2340;&#2369; &#2344;&#2306;&#2348;&#2352;&#2367;&#2306;&#2327; &#2346;&#2381;&#2352;&#2325;&#2367;&#2351;&#2366; </h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                   
                    <td>&#2325;&#2325;&#2381;&#2359;&#2366; </td>
                    <td>
                        <asp:DropDownList ID="DdlClass" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                        
                        </td>
                     <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;
                                    </td>
                    <td>
                                        <asp:DropDownList ID="DdlTitle" runat="server" CssClass="txtbox reqirerd" >
                                        </asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;
                                    </td>
                    <td colspan="3">
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">&#2351;&#2379;&#2332;&#2344;&#2366; </asp:ListItem>
                                            <asp:ListItem Value="2">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </asp:ListItem>
                                        </asp:RadioButtonList>

                    </td>
                </tr>
                <tr>
                    <td>&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;
                                    </td>
                    <td>
                                        <asp:DropDownList ID="DdlDepot" runat="server" CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="DdlDepot_SelectedIndexChanged" >
                                        </asp:DropDownList>

                    </td>
                    <td>&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360; </td>
                    <td>
                                        <asp:DropDownList ID="ddlWarehouse" runat="server" CssClass="txtbox " onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)">
                                        </asp:DropDownList>

                        </td>
                </tr>
                <tr>
                    <td>&#2325;&#2369;&#2354; &#2348;&#2306;&#2337;&#2354;
                                    </td>
                    <td>
                                        <asp:TextBox ID="txtTotlebundle" runat="server" CssClass="txtbox" Width="104px" onkeypress='javascript:tbx_fnNumeric(event, this);'></asp:TextBox>

                    </td>
                    <td>&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2347;&#2381;&#2352;&#2377;&#2350; &#2360;&#2375; </td>
                    <td>
                        <asp:TextBox ID="txtbundleFrom" runat="server" CssClass="txtbox" Width="104px" onkeypress='javascript:tbx_fnNumeric(event, this);' ></asp:TextBox>
                        
                        </td>
                </tr>
                <tr>
                    <td class="auto-style1">&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                    </td>
                    <td class="auto-style1">
                                        <asp:TextBox ID="txtPerBundleBook" runat="server" CssClass="txtbox" Width="104px" onkeypress='javascript:tbx_fnNumeric(event, this);' ></asp:TextBox>

                    </td>
                    <td class="auto-style1">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2306;&#2348;&#2352; &#2347;&#2381;&#2352;&#2366;&#2350; </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtbookNoFrom" runat="server" CssClass="txtbox" Width="104px" onkeypress='javascript:tbx_fnNumeric(event, this);' ></asp:TextBox>
                        
                        </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " />
                                    </td>
                </tr></table> </div> </div> 
</asp:Content>

