<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="inertDepoBookReceived.aspx.cs" Inherits="Depo_inertDepoBookReceived" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box">

                            <div class="card-header">
                                <h2><span> &#2309;&#2306;&#2340;&#2352;&#2381;&#2337;&#2367;&#2346;&#2379; &#2360;&#2375; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; / Recieved Book From InterDepo  </span></h2>
                            </div>
                            <div style="padding:0 10px;">
                                       <asp:Panel   class="form-message sucess" runat="server" id="mainDiv" style="display: none;padding-top:10px;padding-bottom:10px;">
                <asp:Label  id="lblmsg" class="notification" runat="server">
                
            </asp:Label>
            </asp:Panel>
                             <table id="tblDepo" runat="server" width="100%">
                                        <tr><td>&nbsp;&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/Challan No</td> <td><asp:DropDownList ID="ddlOrderNo" runat="server" AutoPostBack="true"></asp:DropDownList> <asp:Button CssClass="btn" Text="&#2310;&#2327;&#2375;  &#2348;&#2338;&#2375;" ID="btnSearch" runat="server" OnClick="SerarchDepoOrdere" /> </td> </tr>
                                        <tr><td colspan="2">
                                            <asp:GridView ID="grdInterdepoRequest" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; /Titile">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblt" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="BOOKTYPE" HeaderText="पुस्तक का प्रकार " />
                                                    <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/Total Book No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblt12" runat="server" Text='<%#Eval("NOOfBooks") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" &#2348;&#2306;&#2337;&#2354;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/BundleNo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblt1" runat="server" Text='<%#Eval("BundleCount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/Lose books no.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblt11" runat="server" Text='<%#Eval("LooseBundleCount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            </td> </tr>
                                        <tr><td colspan="2">
                                            <table width="100%" id="divDepo" style="display:none" runat="server"  >
                                                <tr>
                                                    <td>&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360; &#2330;&#2369;&#2344;&#2375;/Ware House </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddldepoWarehouse" runat="server" CssClass="txtbox reqirerd"></asp:DropDownList> 
                                                    </td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>&#2313;&#2340;&#2352;&#2366;&#2312;/ UnLoading</td>
                                                    <td>
                                                        <asp:TextBox ID="txtdepolOading" runat="server" CssClass="txtbox reqirerd" Text="0" MaxLength="5" onkeyup="javascript:tbx_fnSignedNumericCheck(this);"></asp:TextBox>
                                                    </td>
                                                    <td>&#2330;&#2338;&#2366;&#2312;/ UpLoading</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDepoUnloading" runat="server" CssClass="txtbox reqirerd" Text="0" MaxLength="5" onkeyup="javascript:tbx_fnSignedNumericCheck(this);"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&#2346;&#2352;&#2367;&#2357;&#2361;&#2344;/ Transport</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDepoTransport" runat="server" CssClass="txtbox reqirerd" Text="0" MaxLength="5" onkeyup="javascript:tbx_fnSignedNumericCheck(this);"></asp:TextBox>
                                                    </td>
                                                    <td>&#2309;&#2344;&#2381;&#2351;/ Others</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDepoother" runat="server" CssClass="txtbox reqirerd" MaxLength="5" Text="0" onkeyup="javascript:tbx_fnSignedNumericCheck(this);"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&#2332;&#2368;.&#2310;&#2352; .&#2344;&#2306;&#2348;&#2352; / G.R. No.</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDepoGrno" runat="server" CssClass="txtbox reqirerd" MaxLength="20"></asp:TextBox>
                                                    </td>
                                                    <td>&#2332;&#2368;.&#2310;&#2352;.&#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ G.R. Date</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDepoGrnoDate" runat="server" CssClass="txtbox reqirerd" MaxLength="14"></asp:TextBox>
                                                       <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                            TargetControlID="txtDepoGrnoDate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352; /Truck No.</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDepoTruck" runat="server" CssClass="txtbox reqirerd" MaxLength="10" SkinID="30"></asp:TextBox>
                                                    </td>
                                                    <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; / Book Reciever Name</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="txtbox reqirerd">
                                                            <asp:ListItem>Select..</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:Button ID="Button5" runat="server" CssClass="btn" OnClick="Button1_Click" OnClientClick="return ValidateAllTextForm();" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; " />
                                                    </td>
                                                </tr>
                                            </table>
                                            </td> </tr>
                                        </table> </div> 
</asp:Content>

