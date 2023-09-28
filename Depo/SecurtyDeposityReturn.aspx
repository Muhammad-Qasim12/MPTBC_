<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SecurtyDeposityReturn.aspx.cs" Inherits="Depo_SecurtyDeposityReturn" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box table-responsive">
        <div class="card-header">
            <h2>
                &#2360;&#2367;&#2325;&#2381;&#2351;&#2379;&#2352;&#2367;&#2335;&#2368; &#2337;&#2367;&#2346;&#2366;&#2332;&#2367;&#2335; &#2357;&#2366;&#2346;&#2360;&#2368; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;&nbsp;&nbsp; / Security  Deposit Return Details
            </h2>
        </div>
        <div style="padding: 0 10px;">
           
            
            <table width="100%">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblmsg" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;/ Year :</td>
                    <td>
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                      &#2346;&#2366;&#2352;&#2381;&#2335;&#2368; &#2344;&#2366;&#2350; /  Party Name
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="txtbox" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem Value="0">Select...</asp:ListItem>
                            <asp:ListItem Value="1">Transporter </asp:ListItem>
                            <asp:ListItem Value="2">WareHouse</asp:ListItem>
                            <asp:ListItem Value="3">BookSelller Name</asp:ListItem>
                            <asp:ListItem Value="5">Printer</asp:ListItem>
                            <asp:ListItem Value="4">Other</asp:ListItem>

                        </asp:DropDownList>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GrdWarehouse" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="WareHouseID_I" AllowPaging="True" 
                            onpageindexchanging="GrdWarehouse_PageIndexChanging" OnSelectedIndexChanged="GrdWarehouse_SelectedIndexChanged">
                            <Columns> 
                                     <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                             <asp:BoundField HeaderText="&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;/ &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350; / Warehouse/ Godown Name" DataField="WareHouseName_V" />
                                <asp:BoundField HeaderText="&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;/ &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2346;&#2340;&#2366; / Warehouse/ Godown Address" 
                                    DataField="WareHouseAddress_V" />
                                <asp:BoundField HeaderText="&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Agreement No." DataField="RegistrationNo_V" />
                                <asp:BoundField HeaderText="&#2310;&#2343;&#2367;&#2346;&#2340;&#2381;&#2351; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Possession Date" DataField="RegistrationDate_D" />
                                     <asp:BoundField HeaderText="&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2368; &#2309;&#2357;&#2343;&#2367; (&#2350;&#2366;&#2361; &#2350;&#2375;&#2306; )/Agreement  Period (in month) " DataField="ServicePeriod_V" />
                                <asp:BoundField HeaderText="&#2360;&#2367;&#2325;&#2381;&#2351;&#2379;&#2352;&#2367;&#2335;&#2368; &#2325;&#2368; &#2352;&#2366;&#2358;&#2368; /Security  Amount" DataField="RegistrationAmount_N" />
                                
                                        <asp:BoundField HeaderText="&#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; / Mobile No." DataField="MobileNo_N" />
                                
                                     <asp:CommandField HeaderText="&#2360;&#2367;&#2325;&#2381;&#2351;&#2379;&#2352;&#2367;&#2335;&#2368; &#2337;&#2367;&#2346;&#2366;&#2332;&#2367;&#2335; &#2357;&#2366;&#2346;&#2360; &#2325;&#2352;&#2375;&#2306;" SelectText="&#2360;&#2367;&#2325;&#2381;&#2351;&#2379;&#2352;&#2367;&#2335;&#2368; &#2337;&#2367;&#2346;&#2366;&#2332;&#2367;&#2335; &#2357;&#2366;&#2346;&#2360; &#2325;&#2352;&#2375;&#2306;" ShowSelectButton="True" />
                                
                              
                                
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GrdBookSeleer" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="Booksellerregistration_I" 
                            
                             AllowPaging="True" 
                            onpageindexchanging="GrdBookSeleer_PageIndexChanging" OnSelectedIndexChanged="GrdBookSeleer_SelectedIndexChanged" 
                           >
                            <Columns> 
                                   <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                 
 <asp:TemplateField HeaderText="&#2350;&#2366;&#2354;&#2367;&#2325;  &#2325;&#2366; &#2344;&#2366;&#2350; / Owner Name">
                                       <ItemTemplate>
                                       <%#Eval("BooksellerOwnerName_V")%>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2325;&#2366; &#2346;&#2340;&#2366; / Address of Book Seller" DataField="Address_V" />
                                <asp:BoundField HeaderText="&#2360;&#2350;&#2381;&#2348;&#2306;&#2343;&#2367;&#2340; &#2357;&#2381;&#2351;&#2325;&#2381;&#2340;&#2367; &#2325;&#2366; &#2344;&#2366;&#2350; / Related Person Name" DataField="BooksellerOwnerName_V" />
                                <asp:BoundField HeaderText=" &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2344;&#2306;&#2348;&#2352; / Registration No" DataField="RegistrationNo_V" />
                                <asp:BoundField HeaderText="&#2360;&#2367;&#2325;&#2381;&#2351;&#2379;&#2352;&#2367;&#2335;&#2368; &#2325;&#2368; &#2352;&#2366;&#2358;&#2368; /Security  Amount" DataField="SecurityAmount" />
                                
                                 <asp:BoundField HeaderText="&#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; / Mobile No." DataField="MobileNo_N" />
                                
                                                             
                                
                                     <asp:CommandField HeaderText="&#2360;&#2367;&#2325;&#2381;&#2351;&#2379;&#2352;&#2367;&#2335;&#2368; &#2337;&#2367;&#2346;&#2366;&#2332;&#2367;&#2335; &#2357;&#2366;&#2346;&#2360; &#2325;&#2352;&#2375;&#2306;" SelectText="&#2360;&#2367;&#2325;&#2381;&#2351;&#2379;&#2352;&#2367;&#2335;&#2368; &#2337;&#2367;&#2346;&#2366;&#2332;&#2367;&#2335; &#2357;&#2366;&#2346;&#2360; &#2325;&#2352;&#2375;&#2306;" ShowSelectButton="True" />
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GrdTransport" runat="server" AutoGenerateColumns="False"   CssClass="tab" DataKeyNames="TransportID_I"                   
                             AllowPaging="True" onpageindexchanging="GrdTransport_PageIndexChanging" OnSelectedIndexChanged="GrdTransport_SelectedIndexChanged"   >
                            <Columns> 
                             <asp:BoundField HeaderText="&#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352;  &#2325;&#2350;&#2381;&#2346;&#2344;&#2368; &#2344;&#2366;&#2350; / Name of Transporter Company " DataField="TransportName_V" />
                                <asp:BoundField HeaderText="&#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Name of Transporter " DataField="TransportOwnerName_V" />
                                <asp:BoundField HeaderText=" &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2352;&#2366;&#2358;&#2368; / Registration " DataField="RegistrationAmount_N" />
                                <asp:BoundField HeaderText="&#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2325;&#2366; &#2346;&#2340;&#2366; / Address of Transporter" DataField="Address_V" />
                                <asp:BoundField HeaderText="&#2360;&#2367;&#2325;&#2381;&#2351;&#2379;&#2352;&#2367;&#2335;&#2368; &#2325;&#2368; &#2352;&#2366;&#2358;&#2368; /Security  Amount" DataField="RegistrationAmount_N" />
                                
                                                             
                                
                                 <asp:BoundField HeaderText="&#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352;/Mobile No" DataField="MobileNo_N" />
                                
                                                             
                                
                                     <asp:CommandField HeaderText="&#2360;&#2367;&#2325;&#2381;&#2351;&#2379;&#2352;&#2367;&#2335;&#2368; &#2337;&#2367;&#2346;&#2366;&#2332;&#2367;&#2335; &#2357;&#2366;&#2346;&#2360; &#2325;&#2352;&#2375;&#2306;" SelectText="&#2360;&#2367;&#2325;&#2381;&#2351;&#2379;&#2352;&#2367;&#2335;&#2368; &#2337;&#2367;&#2346;&#2366;&#2332;&#2367;&#2335; &#2357;&#2366;&#2346;&#2360; &#2325;&#2352;&#2375;&#2306;" ShowSelectButton="True" />
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GrdPrinterId" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="Printer_regid_i" AllowPaging="True" OnSelectedIndexChanged="GrdPrinterId_SelectedIndexChanged"   onpageindexchanging="GrdPrinterId_PageIndexChanging">
                            <Columns> 
                                     <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                             <asp:BoundField HeaderText="Printer Name" DataField="NameofPressHindi_V" />
                                <asp:BoundField HeaderText="Address" 
                                    DataField="FullAddress_V" />
                                <asp:BoundField HeaderText="Registration  No." DataField="RegistrationNo_V" />
                                <asp:BoundField HeaderText="Registration Date" DataField="RegistrationDate_D" />
                                 
                                <asp:BoundField HeaderText="Security  Amount" DataField="RegistrationAmount_N" />
                                
                                        <asp:BoundField HeaderText="Mobile No." DataField="MobileNo_N" />
                                
                                     <asp:CommandField HeaderText="&#2360;&#2367;&#2325;&#2381;&#2351;&#2379;&#2352;&#2367;&#2335;&#2368; &#2337;&#2367;&#2346;&#2366;&#2332;&#2367;&#2335; &#2357;&#2366;&#2346;&#2360; &#2325;&#2352;&#2375;&#2306;" SelectText="&#2360;&#2367;&#2325;&#2381;&#2351;&#2379;&#2352;&#2367;&#2335;&#2368; &#2337;&#2367;&#2346;&#2366;&#2332;&#2367;&#2335; &#2357;&#2366;&#2346;&#2360; &#2325;&#2352;&#2375;&#2306;" ShowSelectButton="True" />
                                
                              
                                
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"> <div style="padding: 0 10px;">
           
                        <table cellpadding="4" cellspacing="3" width="100%" style="display:none"  runat="Server" id="aa">
                            <tr>
                                <td>&#2346;&#2366;&#2352;&#2381;&#2335;&#2368; &#2344;&#2366;&#2350; /Party Name</td>
                                <td>
                                    <asp:Label ID="lblPartyName" runat="server" CssClass="txtbox"></asp:Label>
                                </td>
                                <td>&#2309;&#2327;&#2381;&#2352;&#2368;&#2350;&#2375;&#2306;&#2335; &#2344;&#2306;&#2348;&#2352; /Agrement No/Reg.No</td>
                                <td>
                                    <asp:Label ID="lblagrement" runat="server" CssClass="txtbox"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2352;&#2366;&#2358;&#2368; /Security Amount</td>
                                <td>
                                    <asp:Label ID="lblSecurityAmount" runat="server" CssClass="txtbox"></asp:Label>
                                </td>
                                <td>&#2350;&#2366;&#2354;&#2367;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Owner Name</td>
                                <td>
                                    <asp:Label ID="lblOwnerName" runat="server" CssClass="txtbox "></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2360;&#2306;&#2346;&#2352;&#2381;&#2325; &#2360;&#2370;&#2340;&#2381;&#2352; /Contact No</td>
                                <td>
                                    <asp:Label ID="lblContractNo" runat="server" CssClass="txtbox"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&#2319;&#2344;.&#2323;.&#2360;&#2368;.&#2344;&#2306;&#2348;&#2352; /NOC No</td>
                                <td>
                                    <asp:TextBox ID="txtNoc" runat="server" CssClass="txtbox"></asp:TextBox>
                                </td>
                                <td>&#2319;&#2344;.&#2323;.&#2360;&#2368;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /NOC Date</td>
                                <td>
                                    <asp:TextBox ID="txtNocDate" runat="server" CssClass="txtbox"></asp:TextBox>
                                  
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server"  TargetControlID="txtNocDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                      
                                </td>
                            </tr>
                            <tr>
                                <td>&#2319;&#2344;.&#2323;.&#2360;&#2368;.&#2309;&#2346;&#2354;&#2379;&#2337; /NOC Upload </td>
                                <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&#2346;&#2340;&#2381;&#2352; &#2344;&#2306;&#2348;&#2352; /Letter No</td>
                                <td>
                                    <asp:TextBox ID="txtLetterNo" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                </td>
                                <td>&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /Letter date</td>
                                <td>
                                    <asp:TextBox ID="txtLetterDate" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtLetterDate" Format="dd/MM/yyyy">
                     </cc1:CalendarExtender>
                        
                        
                                </td>
                            </tr>
                            <tr>
                                <td>&#2357;&#2366;&#2346;&#2360;&#2368; &#2352;&#2366;&#2358;&#2368; /Return Amount</td>
                                <td>
                                    <asp:TextBox ID="txtRamount" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                </td>
                                <td>&#2348;&#2376;&#2306;&#2325; &#2344;&#2366;&#2350; /Bank Name</td>
                                <td>
                                    <asp:TextBox ID="txtBankNaem" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2337;&#2368;.&#2337;&#2368;. &#2344;&#2306;&#2348;&#2352;  /DD No </td>
                                <td>
                                    <asp:TextBox ID="txtDDNo" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                </td>
                                <td> &#2337;&#2368;.&#2337;&#2368;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/DD Date</td>
                                <td>
                                    <asp:TextBox ID="txtDDdate" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                     <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDDdate" Format="dd/MM/yyyy">
                     </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Save" OnClick="Button1_Click" OnClientClick="return ValidateAllTextForm();"/>
                                </td>
                            </tr>
                        </table></div> 
                    </td>
                </tr></table> </div> 
</asp:Content>

