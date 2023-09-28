<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OtherthanPraday.aspx.cs" Inherits="Depo_OtherThankPraday" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="box">
                    <div class="card-header">
                     <h2> &#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; </h2>
                          
                    </div>
                     <table style="width: 100%">
                <tr>
                    <td style="font-size: medium;">
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Financial Year</td>
                    <td>
                        <asp:DropDownList ID="ddlSessionYear" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 30%; font-size: medium;" valign="top">
                        <asp:Label ID="LblDistrict0" runat="server" Width="263px">&#2332;&#2367;&#2354;&#2366;/ District Name :</asp:Label>
                    </td>
                    <td style="font-size: medium;">
                        
                        <asp:DropDownList ID="DdlDistrict" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" onselectedindexchanged="DdlDistrict_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: medium;">
                        कक्षा </td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem Value="1">1-8</asp:ListItem>
                            <asp:ListItem Value="2">9-12</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 30%; font-size: medium;" valign="top">
                        &nbsp;</td>
                    <td style="font-size: medium;">
                        
                        &nbsp;</td>
                </tr>
                   
                    
               
                <tr>
                        <td>
                            &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;/Receiver Name</td>
                        <td>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                   
                    <asp:ListItem Value="0">Select..</asp:ListItem>
                    <asp:ListItem Value="1">&#2348;&#2368; &#2310;&#2352; &#2360;&#2368; </asp:ListItem>
                    <asp:ListItem Value="2">&#2348;&#2368; &#2312; &#2323; </asp:ListItem>
                    <asp:ListItem Value="3">&#2337;&#2368; &#2312; &#2323; </asp:ListItem>
                    <asp:ListItem Value="4">&#2337;&#2368; &#2346;&#2368; &#2360;&#2368; </asp:ListItem>
                    <asp:ListItem Value="5">डी.पी.आई .</asp:ListItem>
                    <asp:ListItem Value="6">आर.एस . के.</asp:ListItem>
                </asp:DropDownList>
                        </td>
                        <td>
                            &#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;&nbsp; 
                            /Bolck Name</td>
                        <td>
                        
                            <asp:DropDownList ID="ddlBlock" runat="server"  CssClass="txtbox reqirerd">
                            </asp:DropDownList>
                        </td>
                    </tr>
                   
                    
               
               
                   
                    
               
                <tr>
                        <td>
                            &#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; 
                        </td>
                        <td>
                            <asp:TextBox ID="txtChalanNo" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                        </td>
                        <td>
                
                            &#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /Challan Date  
                
                        </td>
                        <td>
                            <asp:TextBox ID="txtChalanDate" runat="server"  CssClass="txtbox reqirerd" ></asp:TextBox>
            
            <cc1:calendarextender ID="txtDate_CalendarExtender" runat="server" 
                                            TargetControlID="txtChalanDate" Format="dd/MM/yyyy">
        </cc1:calendarextender>
                        </td>
                    </tr>
                   
                    
               
               
                   
                    
               
                     <tr><td> 
                
                            &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352;/Bilti No&nbsp; 
                
                </td><td>
                            <asp:TextBox ID="txtGRNO" runat="server" MaxLength="10"  CssClass="txtbox reqirerd"></asp:TextBox>  
                        </td> <td>
                            &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;&nbsp;/Bilti Date</td><td><asp:TextBox ID="txtGRNDate" runat="server"  CssClass="txtbox reqirerd" ></asp:TextBox>
        <cc1:calendarextender ID="txtDate_CalendarExtender1" runat="server" 
                                            TargetControlID="txtGRNDate" Format="dd/MM/yyyy">
        </cc1:calendarextender>
           
           
                </td></tr>
            
            
               
            <tr><td> 
                
                            &#2337;&#2381;&#2352;&#2366;&#2312;&#2357;&#2352; &#2325;&#2366; &#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; /Driver Mobile No&nbsp; &nbsp;&nbsp;</td><td>
                            <asp:TextBox ID="txtDriverMobileNo" MaxLength="10" runat="server"  CssClass="txtbox reqirerd" ></asp:TextBox>
           
                        </td> <td>
                            &#2335;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2306;&#2348;&#2352;&nbsp;/ Truck No</td><td> <asp:TextBox ID="txtTrucko" runat="server" MaxLength="10"  CssClass="txtbox reqirerd"></asp:TextBox> </td></tr>
            
            
               
            <tr><td> 
                
                            &#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325;/ Remark&nbsp;&nbsp;&nbsp;</td><td colspan="3">
                            <asp:TextBox ID="txtRemark" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' TextMode="MultiLine" runat="server" MaxLength="200" ></asp:TextBox>
                        </td> </tr>
             <tr>
                        <td colspan="4">
                            <asp:Button Text="&#2337;&#2366;&#2335;&#2366; &#2342;&#2375;&#2326;&#2375;" runat="server"  ID="btnSaveMasterData"  CssClass="btn" OnClick="btnSaveMasterData_Click"/> 
                        </td>
                    </tr>
                    
             <tr>
                        <td colspan="4"> <asp:GridView ID="grBook" runat="server" AutoGenerateColumns="False" CssClass="tab" >
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;. / No.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2330;&#2369;&#2344;&#2375; / Choose">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" onclick="Check_Click(this)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Title" HeaderText="&#2357;&#2367;&#2359;&#2351; / Subject" />
                                    <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Books Per Bundle">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPerbundlebook" runat="server" AutoPostBack="True" Enabled="False" OnTextChanged="calculate" Text='<%# Eval("BookNumber") %>' Width="50px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2310;&#2348;&#2306;&#2335;&#2344; / Alloted">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("SubTitleID") %>' />
                                            <asp:TextBox ID="txtNofBooks" runat="server" Enabled="False" Text='<%#Eval("BRCSupply") %>' Width="106px"></asp:TextBox>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366; &#2330;&#2369;&#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAbook" runat="server" Text='<%# Eval("PradayBook") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; / Distribution">
                                        <ItemTemplate>
                                            <asp:TextBox ID="lblnoofbooks" runat="server" AutoPostBack="True" OnTextChanged="calculate" Text='<%#Convert.ToInt32(Eval("BRCSupply")) - Convert.ToInt32(Eval("PradayBook"))%>' Width="106px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; / Pack Bundle">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPackbundle" runat="server" Text='<%#(Convert.ToInt32(Eval("BRCSupply"))- Convert.ToInt32(Eval("PradayBook"))) / Convert.ToInt32(Eval("BookNumber"))%>' Width="106px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2354;&#2370;&#2360; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Loose Books">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtloose" runat="server" Text='<%#(Convert.ToInt32(Eval("BRCSupply"))- Convert.ToInt32(Eval("PradayBook"))) % Convert.ToInt32(Eval("BookNumber"))%>' Width="106px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                
                            &nbsp;</td>
                    </tr>
                    
             <tr>
                        <td colspan="4"> 
                            <asp:Button Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; " runat="server"  ID="btnSave"  CssClass="btn" OnClick="btnSave_Click"/> 
                        </td>
                    </tr>
                    
                   </table></div>
</asp:Content>

