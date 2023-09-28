<%@ Page Title="" Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DPT001_BookDistribution.aspx.cs" Inherits="Depo_DPT001_BookDistribution" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HiddenField ID="hdnDistrictID" runat="server" />
<asp:HiddenField ID="hdnOrderID" runat="server" />
  <asp:HiddenField ID="hdnblockname"  runat="server"  />
               
            
                <div class="box">
                    <div class="card-header">
                     <h2> &#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2366; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; / Books Distribution Of Scheme</h2>
                          
                    </div>
                     <table style="width: 100%">
                <tr>
                    <td style="font-size: medium;">
                        &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; /Distribution Type </td>
                    <td>
                        <asp:DropDownList ID="ddltype" runat="server" >
                            <asp:ListItem Text="&#2351;&#2379;&#2332;&#2344;&#2366;" Value="0"> </asp:ListItem>
                            <asp:ListItem Text="&#2309;&#2340;&#2367;&#2352;&#2367;&#2325;&#2381;&#2340; &#2350;&#2366;&#2306;&#2327;" Value="1"> </asp:ListItem>
                            <asp:ListItem Text="&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; " Value="2"> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 30%; font-size: medium;" valign="top">
                        &nbsp;</td>
                    <td style="font-size: medium;">
                        
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="font-size: medium;">
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                        / Financial Year</td>
                    <td>
                        <asp:DropDownList ID="ddlSessionYear" runat="server" CssClass="txtbox reqirerd">
                            
                        </asp:DropDownList>
                    </td>
                    <td style="width: 30%; font-size: medium;" valign="top">
                     <asp:Label ID="LblDistrict" runat="server" Width="263px">जिला/ District Name :</asp:Label>
                    
                    </td>
                    <td style="font-size: medium;">
                        
                        <asp:DropDownList ID="DdlDistrict" runat="server"  CssClass="txtbox reqirerd" 
                            AutoPostBack="True" onselectedindexchanged="DdlDistrict_SelectedIndexChanged">
                           
                        </asp:DropDownList>
                    
                    </td>
                </tr>
                <tr>
                        <td>
                            &#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;&nbsp; 
                            /Bolck Name</td>
                        <td>
                            <asp:DropDownList ID="ddlBlock" runat="server"  CssClass="txtbox reqirerd">
                            </asp:DropDownList>
                        </td>
                        <td>
                            स्कीम का नाम </td>
                        <td>
                        <asp:DropDownList ID="ddlScheme" runat="server"  CssClass="txtbox reqirerd" >
                           
                        </asp:DropDownList>
                    
                        </td>
                    </tr>
                   
                    
               
            <tr>
            <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352;/Challan No&nbsp; :</td> <td> <asp:TextBox ID="txtChalanNo" MaxLength="10" runat="server"  CssClass="txtbox reqirerd"></asp:TextBox> </td> <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /Challan Date </td> <td><asp:TextBox ID="txtChalanDate" runat="server"  CssClass="txtbox reqirerd" ></asp:TextBox></td>
            </tr>
             <tr>
            <td>&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352;/Bilti No&nbsp;  :</td> <td> <asp:TextBox ID="txtGRNO" runat="server" MaxLength="10"  CssClass="txtbox reqirerd"></asp:TextBox> </td> <td>&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;&nbsp;/Bilti Date</td> <td><asp:TextBox ID="txtGRNDate" runat="server"  CssClass="txtbox reqirerd" ></asp:TextBox></td>
            </tr>
            <tr>
            <td>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;/Receiver Name&nbsp; :</td> <td> <asp:TextBox ID="txtReceiverName" MaxLength="40" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'   runat="server" Visible="False"></asp:TextBox> 
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>&#2348;&#2368; &#2310;&#2352; &#2360;&#2368; </asp:ListItem>
                    <asp:ListItem>&#2348;&#2368; &#2312; &#2323; </asp:ListItem>
                    <asp:ListItem>&#2337;&#2368; &#2346;&#2368; &#2360;&#2368; </asp:ListItem>
                    <asp:ListItem>&#2337;&#2368; &#2312; &#2323; </asp:ListItem>
                    <asp:ListItem>&#2309;&#2344;&#2381;&#2351; </asp:ListItem>
                </asp:DropDownList>
                </td> <td>ड्राईवर का मोबाइल नंबर /Driver Mobile No&nbsp; </td> <td><asp:TextBox ID="txtDriverMobileNo" MaxLength="10" runat="server"  CssClass="txtbox reqirerd" ></asp:TextBox>
           
            </td>
            </tr>
            <tr>
            <td>&#2335;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2306;&#2348;&#2352;&nbsp;/ Truck No :</td> <td> <asp:TextBox ID="txtTrucko" runat="server" MaxLength="10"  CssClass="txtbox reqirerd"></asp:TextBox> </td> <td>&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325;/ Remark&nbsp; :</td> <td><asp:TextBox ID="txtRemark" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' TextMode="MultiLine" runat="server" MaxLength="200" ></asp:TextBox></td>
            </tr>

            <tr><td><asp:Button Text="&#2310;&#2327;&#2375; &#2348;&#2338;&#2375;" runat="server" OnClick="btnSave" ID="btnSaveMasterData" OnClientClick="return ValidateAllTextForm();"  CssClass="btn"/> 
                <br />
                <br />
                </td> </tr>
            
            
         </table></div>
            
            <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                            TargetControlID="txtChalanDate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
        <cc1:CalendarExtender ID="txtDate_CalendarExtender1" runat="server" 
                                            TargetControlID="txtGRNDate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
           
           
       <div id="fadeDiv" runat="server" class="modalBackground" style="display: none">
                </div>
                <script type="text/javascript">
                    function closeMessagesDiv(obj) {
                       // document.getElementById("ContentPlaceHolder1_pnldiv").style.display = "none";
                      <%-- // document.getElementById('<%=pnldiv.ClientID %>').style.display = "none";
                       // document.getElementById('<%=fadeDiv.ClientID %>').style.display = "none";--%>
                        return false;
                    }
                
                </script>
</asp:Content>

   