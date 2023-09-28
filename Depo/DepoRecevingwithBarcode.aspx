<%@ Page Title="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; / &#2309;&#2306;&#2340;&#2352;&#2381;&#2337;&#2367;&#2346;&#2379; &#2360;&#2375; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; / Printer / Depot Recieved Books" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepoRecevingwithBarcode.aspx.cs" Inherits="Depo_DepoRecevingwithBarcode" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div></div> 
     <div class="card-header">
                                <h2><span> &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; / &#2309;&#2306;&#2340;&#2352;&#2381;&#2337;&#2367;&#2346;&#2379; &#2360;&#2375; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; / Printer / Depot Recieved Books </span></h2>
                            </div>
                            <div style="padding:0 10px;">
<asp:HiddenField ID="hdnId" runat="server" />

                                <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2351;&#2375; " />

                                <table class="auto-style1">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"> <table width="100%" border=".5">
                                <tr>
                                    <td colspan="4" style="text-align: left">
                                        <asp:DropDownList ID="ddla" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddla_SelectedIndexChanged">
                                            <asp:ListItem Value="0">Select..</asp:ListItem>
                                            <asp:ListItem Value="1">&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352;</asp:ListItem>
                                            <asp:ListItem Value="2">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; </asp:ListItem>
                                            <asp:ListItem Value="3">&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </asp:ListItem>
                                            <asp:ListItem Value="4">&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;</asp:ListItem>
                                            <asp:ListItem Value="5">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;</asp:ListItem>
                                            <asp:ListItem Value="6">&#2348;&#2369;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; </asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txta" runat="server" CssClass="txtbox" Visible="False"></asp:TextBox>
                                        <asp:DropDownList ID="ddlbookType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddla_SelectedIndexChanged" Visible="False">
                                            <asp:ListItem Value="1">&#2351;&#2379;&#2332;&#2344;&#2366; </asp:ListItem>
                                            <asp:ListItem Value="0">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlTital" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddla_SelectedIndexChanged" Visible="False">
                                        </asp:DropDownList>
                                                                                <asp:DropDownList ID="ddlPrinter" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddla_SelectedIndexChanged" Visible="False">
                                        </asp:DropDownList>
                                        
                                        <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddla_SelectedIndexChanged" Visible="False">
                                        </asp:DropDownList>
                                       <asp:TextBox ID="txtFromdate" runat="server" CssClass="txtbox" Visible="False"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                            TargetControlID="txtFromdate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
                                        <asp:TextBox ID="txtTodate" runat="server" CssClass="txtbox" Visible="False"></asp:TextBox>
                                         <cc1:CalendarExtender ID="CalendarExtender3" runat="server" 
                                            TargetControlID="txtTodate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
                                        <asp:Button ID="Button8" runat="server" CssClass="btn" OnClick="Button4_Click" Text="&#2326;&#2379;&#2332;&#2375; " />
                                    </td>
                                </tr></table> </td>
                                    </tr>
                                    <tr>
                                        <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; / Chalan No.</td>
                                        <td>
                                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="Label2" runat="server"></asp:Label> -<asp:Label ID="Label3" runat="server"></asp:Label> - <asp:Label ID="Label4" runat="server"></asp:Label>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>&#2348;&#2339;&#2381;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; (&#2348;&#2366;&#2352;&#2325;&#2379;&#2337; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; ) </td>
                                        <td>

    <asp:TextBox ID="TxtCode" runat="server" ontextchanged="TxtCode_TextChanged" AutoPostBack="true" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox>
                                            <asp:Label ID="LblCode" runat="server">&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; / Bundle No.: </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">

  
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                               <asp:GridView ID="grdPrinterBundleDetails" runat="server" AutoGenerateColumns="False" CssClass="tab" >
                                                 <Columns>
                                                     <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; / Chalan No.">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("ChalanNo") %>' ID="ChalanNo" runat="server"  ></asp:Label>
                                                 <asp:HiddenField ID="TitleID_I" runat="server" Value='<%#Eval("StockDetailsID_I") %>' />
                                                
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Printer Name">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("NameofPress_V") %>' ID="NameofPress_V" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>


                                                 <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title Name">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("TitleHindi_V") %>' ID="TitleHindi_V" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Bundle No.">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("BundleNo_I") %>' ID="BundleNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375; / Book No. From">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("FromNo_I") %>' ID="FromNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325; / Book No. To">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("ToNo_I") %>' ID="ToNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; Book No.">
                                                 <ItemTemplate>
                                                  <%#Convert.ToInt32(Eval("ToNo_I"))-( Convert.ToInt32(Eval("FromNo_I")))+1%>
                                                
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                 </Columns>
                                                 </asp:GridView>

                                        </td>
                                    </tr>
                                </table>
    <br /><br />
       
    </div>
</asp:Content>

