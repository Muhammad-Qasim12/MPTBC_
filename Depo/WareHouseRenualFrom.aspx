<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WareHouseRenualFrom.aspx.cs" Inherits="Depo_WareHouseRenualFrom" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360; / &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2348;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2352;&#2375;&#2344;&#2369;&#2309;&#2354; &#2347;&#2377;&#2352;&#2381;&#2350; / WareHouse/Book Seller Renewal Form</span>
            </h2>
        </div>
        <asp:UpdatePanel ID="up1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="mainDiv" runat="server" class="form-message error" 
                    style="display: none;padding-top:10px;padding-bottom:10px;">
                    <asp:Label ID="lblmsg" runat="server" class="notification">
                
            </asp:Label>
                </asp:Panel>
                <div>
                    </div>
                <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
                    <table width="100%">
                        <tr>
                            <td>
                                &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; &#2330;&#2369;&#2344;&#2375; / Choose
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                                    RepeatDirection="Horizontal" Width="274px">
                                    <asp:ListItem Value="1">&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360; / WareHouse</asp:ListItem>
                                    <asp:ListItem Value="2">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2348;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; / Book Seller</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="GrdWarehouse" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" CssClass="tab" DataKeyNames="WareHouseID_I" 
                                    onpageindexchanging="GrdWarehouse_PageIndexChanging" onselectedindexchanged="GrdWarehouse_SelectedIndexChanged" 
                                    >
                                    <Columns>
                                        <asp:BoundField DataField="WareHouseName_V" 
                                            HeaderText="&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;/ &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350; / WareHouse/Godown Name" />
                                        <asp:BoundField DataField="RegistrationNo_V" HeaderText="&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Reg. No." />
                                        <asp:BoundField DataField="RegistrationDate_D" HeaderText="&#2310;&#2343;&#2367;&#2346;&#2340;&#2381;&#2351; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Date" />
                                        <asp:BoundField DataField="WareHouseAddress_V" 
                                            HeaderText="&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;/ &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2346;&#2340;&#2366; / WareHouse/ Godown Name" />
                                        <asp:BoundField DataField="PanNo_V" HeaderText="&#2346;&#2376;&#2344; &#2344;&#2350;&#2381;&#2348;&#2352; / PAN No." />
                                        <asp:BoundField DataField="EmailID_V" HeaderText="&#2312; &#2350;&#2375;&#2354; &#2310;&#2312;.&#2337;&#2368;. / Email ID" />
                                        <asp:BoundField DataField="MobileNo_N" HeaderText="&#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; / Mobile No." />
                                        <asp:CommandField HeaderText="&#2352;&#2367;&#2344;&#2381;&#2351;&#2370;&#2309;&#2354; " SelectText="&#2352;&#2367;&#2344;&#2381;&#2351;&#2370;&#2309;&#2354; &#2325;&#2352;&#2375; / Renewal" 
                                            ShowSelectButton="True" />
                                    </Columns>
                                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                </asp:GridView>
                                <asp:HiddenField ID="HVWareHouse" runat="server" />
                                <asp:HiddenField ID="HVBookSeller" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;<asp:GridView ID="GrdBookSeleer" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" CssClass="tab" 
                                    DataKeyNames="Booksellerregistration_I" 
                                    onpageindexchanging="GrdBookSeleer_PageIndexChanging" 
                                   
                                    onselectedindexchanged="GrdBookSeleer_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="BooksellerName_V" HeaderText="&#2348;&#2369;&#2325; &#2360;&#2375;&#2354;&#2352; &#2344;&#2366;&#2350; / Bookn Seller Name" />
                                        <asp:BoundField DataField="RegistrationNo_V" 
                                            HeaderText="&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Reg. No." />
                                        <asp:BoundField DataField="RegistrationDate_D" 
                                            HeaderText=" &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2342;&#2367;&#2344;&#2366;&#2325; / Reg. Date" />
                                        <asp:BoundField DataField="Address_V" HeaderText="&#2348;&#2369;&#2325; &#2360;&#2375;&#2354;&#2352; &#2325;&#2366; &#2346;&#2340;&#2366; / Book Seller address" />
                                        <asp:BoundField DataField="EmailID_V" HeaderText="&#2312; &#2350;&#2375;&#2354; &#2310;&#2312;.&#2337;&#2368;. / Email Id" />
                                        <asp:BoundField DataField="MobileNo_N" HeaderText="&#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; / Mobile no." />
                                        <asp:CommandField HeaderText="&#2352;&#2367;&#2344;&#2381;&#2351;&#2370;&#2309;&#2354; / Renewal" SelectText="&#2352;&#2367;&#2344;&#2381;&#2351;&#2370;&#2309;&#2354; &#2325;&#2352;&#2375; / Renewal" 
                                            ShowSelectButton="True" />
                                    </Columns>
                                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                </asp:GridView>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table style="display:none " id="a" runat="server"  >
                                    <tr>
                                        <td>
                                            &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" CssClass="txtbox"></asp:Label>
                                        </td>
                                        <td>
                                            &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" CssClass="txtbox"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr >
                                        <td>
                                           &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; 
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRenweNo" runat="server" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)" MaxLength="20"></asp:TextBox>
                                        </td>
                                        <td>
                                           &#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; 
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRenewalDate" CssClass="txtbox reqirerd" runat="server" MaxLength="10"></asp:TextBox>
                                             <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtRenewalDate" Format="dd/MM/yyyy">
                     </cc1:CalendarExtender>
                         
                                        </td>
                                    </tr>
                                    <tr id="aj" runat="server" >
                                        <td>
                                            &#2352;&#2367;&#2344;&#2381;&#2351;&#2370;&#2309;&#2354; &#2325;&#2368; &#2352;&#2366;&#2358;&#2368;
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAmount" CssClass="txtbox " runat="server" onkeypress='javascript:tbx_fnNumeric(event, this);' MaxLength="6"></asp:TextBox>
                                        </td>
                                        <td>
                                            &#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; </td>
                                        <td>
                                            <asp:TextBox ID="txtremark" runat="server" CssClass="txtbox" MaxLength="100"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Button ID="Button2" runat="server" Text="Save" 
                                                OnClientClick="return ValidateAllTextForm();" CssClass="btn" 
                                                onclick="Button2_Click"/>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <script>

            
        var Globlephoto =  document.getElementById("PhotoUpload").innerHTML;
        $('#ctl00_ContentPlaceHolder1_FlAgrimentFile').live('change', function () {

            //this.files[0].size gets the size of your file.
             if (this.files[0].size / 1024 > 500) {
                 alert("file size cannot geater then 500 kb");
                  document.getElementById("PhotoUpload").innerHTML=Globlephoto;
                
            }

          });
          var Globlephoto2 = document.getElementById("PhotoUpload3").innerHTML;
          $('#ctl00_ContentPlaceHolder1_FlMapFile').live('change', function () {

              //this.files[0].size gets the size of your file.
              if (this.files[0].size / 1024 > 500) {
                  alert("file Size cannot geater then 500 kb");
                  document.getElementById("PhotoUpload3").innerHTML = Globlephoto2;

              }

          });
        
        </script>


                   <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Messages" style="display: none;" class="popupnew" runat="server" >

                <div class="msg MT10">
                    <p> <b> &#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360; /&#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2375; &#2344;&#2357;&#2368;&#2344;&#2368;&#2325;&#2352;&#2339; &#2325;&#2375; &#2354;&#2367;&#2319; &#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2409; &#2350;&#2366;&#2361; &#2346;&#2370;&#2352;&#2381;&#2357; &#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; &#2325;&#2379; &#2346;&#2381;&#2352;&#2375;&#2359;&#2367;&#2340; &#2325;&#2367;&#2351;&#2366; &#2332;&#2366;&#2351;&#2375;&#2327;&#2366; /&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2325;&#2366; &#2346;&#2306;&#2332;&#2368;&#2351;&#2344; &#2325;&#2366; &#2344;&#2357;&#2368;&#2344;&#2368;&#2325;&#2352;&#2339; &#2310;&#2346;&#2325;&#2375; &#2337;&#2367;&#2346;&#2379; &#2360;&#2381;&#2340;&#2352; &#2360;&#2375; &#2361;&#2379;&#2327;&#2366; </b> </p> </div> 
           <asp:Button ID="Button1" runat="server" Text="&#2310;&#2327;&#2375; &#2348;&#2338;&#2375; " CssClass="btn"  onclick="Button1_Click" />
                  </div> 
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

