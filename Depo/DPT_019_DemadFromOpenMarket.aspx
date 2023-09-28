<%@ Page Title="&#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2395;&#2366;&#2352; &#2360;&#2375; &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2319;&#2344;&#2381;&#2335;&#2381;&#2352;&#2368; &#2347;&#2377;&#2352;&#2381;&#2350; / Demand Entry Form From Open Market" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DPT_019_DemadFromOpenMarket.aspx.cs" Inherits="Distrubution_DIS_002_DemadFromOpenMarket" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

&nbsp;<script>
    function CalulateTotal(obj) {
        
        var lblCurntYearOpenBook = obj;
        var txtOpenTentetiveStock = document.getElementById(obj.id.replace("lblCurntYearOpenBook", "txtOpenTentetiveStock"));
        var txtNetDemand = document.getElementById(obj.id.replace("lblCurntYearOpenBook", "txtNetDemand"));
            
            if (lblCurntYearOpenBook.value != "" && txtOpenTentetiveStock.value != "") {
                if (lblCurntYearOpenBook.value != "" && txtOpenTentetiveStock.value != "") {
                    if ((parseInt(lblCurntYearOpenBook.value) - parseInt(txtOpenTentetiveStock.value)) > 0) {
                        txtNetDemand.value = parseInt(lblCurntYearOpenBook.value) - parseInt(txtOpenTentetiveStock.value);
                    }
                    else {
                        txtNetDemand.value = 0;
                    }

                }
            }
    
    }
     function CalulateTotal1(obj) {
         
         var lblCurntYearOpenBook = document.getElementById(obj.id.replace("txtOpenTentetiveStock", "lblCurntYearOpenBook"));
         var txtOpenTentetiveStock = obj;
         var txtNetDemand = document.getElementById(obj.id.replace("txtOpenTentetiveStock", "txtNetDemand"));

         if (lblCurntYearOpenBook.value != "" && txtOpenTentetiveStock.value != "") {
             if ((parseInt(lblCurntYearOpenBook.value) - parseInt(txtOpenTentetiveStock.value)) > 0) {

                 txtNetDemand.value = parseInt(lblCurntYearOpenBook.value) - parseInt(txtOpenTentetiveStock.value);
              }
             else {
                 txtNetDemand.value = 0;
             }

            }

     }
     function CalulateTotal2(obj) {
        
         var lblCurntYearOpenBook = document.getElementById(obj.id.replace("txtNetDemand", "lblCurntYearOpenBook"));
         var txtOpenTentetiveStock = document.getElementById(obj.id.replace("txtNetDemand", "txtOpenTentetiveStock"));
         var txtNetDemand = document.getElementById(obj.id.replace("txtNetDemand", "txtNetDemand"));
         if (lblCurntYearOpenBook.value != "" && txtOpenTentetiveStock.value != "") {
             txtNetDemand.value = parseInt(lblCurntYearOpenBook.value) - parseInt(txtOpenTentetiveStock.value);
         }

     }
</script><div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span style="font-size: medium;">&#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2395;&#2366;&#2352; &#2360;&#2375; &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2319;&#2344;&#2381;&#2335;&#2381;&#2352;&#2368; &#2347;&#2377;&#2352;&#2381;&#2350; / Demand Entry Form From Open Market</span></h2>
        </div>
        <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
       <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                            <ProgressTemplate>
                                <div class="fade">
                                </div>
                                <div class="progress">
                                    <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                                </div>
                            </ProgressTemplate>
                            </asp:UpdateProgress>--%>
        <div style="padding: 0 10px;">
            <table style="width: 100%">
                <tr>
                    <td style="font-size: medium;">
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSessionYear" runat="server" CssClass="txtbox reqirerd" OnSelectedIndexChanged="dddd" AutoPostBack="true" >
                            
                        </asp:DropDownList>
                    </td>
                    <td style="font-size: medium;">
                        
                    </td>
                    <td style="font-size: medium;">
                        
                    </td>
                </tr>
                <tr>
                    <td style="font-size: medium;">
                        &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; &#2330;&#2369;&#2344;&#2375; / Choose Medium:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMedum" runat="server" CssClass="txtbox reqirerd" OnInit="ddlMedum_Init"  Width="114px">
                        </asp:DropDownList>
                    </td>
                    <td style="font-size: medium;">
                        &#2325;&#2325;&#2381;&#2359;&#2366;: / Class 
                    </td>
                    <td>
                       <%-- <asp:DropDownList ID="ddlClass" runat="server" CssClass="txtbox reqirerd" AutoPostBack="true"
                            OnInit="ddlClass_Init" Width="114px" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                        </asp:DropDownList>--%>
                          <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" RepeatColumns="4" 
                                        onselectedindexchanged="CheckBoxList1_SelectedIndexChanged" 
                                        RepeatDirection="Horizontal">
                                    </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: medium;">
                    </td>
                    <td>
                    </td>
                    <td style="font-size: medium;">
                        <%--&#2357;&#2367;&#2325;&#2366;&#2360;&#2326;&#2306;&#2337; &#2330;&#2369;&#2344;&#2375; :--%>
                    </td>
                    <td>
                        <%--<asp:DropDownList ID="DropDownList5" runat="server" CssClass="txtbox">
                            </asp:DropDownList>--%>
                    </td>
                </tr>
               <%-- <tr>
                    <td style="font-size: medium;">
                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;:
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="DropDownList4" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:GridView ID="GrdBooksMaster" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" EmptyDataText="Record Not Found." Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Book Name  ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTitleID_I" runat="server" Text='<%#Eval("TitleID_I") %>' Visible="false"></asp:Label>
                                        <%#Eval("TitleHindi_V")%><asp:HiddenField ID="HiddenField1" Value='<%#Eval("ClassTrno_I") %>'  runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2367;&#2331;&#2354;&#2375; &#2360;&#2340;&#2381;&#2352; &#2350;&#2375;&#2306; &#2357;&#2367;&#2325;&#2381;&#2352;&#2351; &#2325;&#2368; &#2327;&#2351;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375; / Last Year Sales Book ">
                                    <ItemTemplate>
                                      <asp:TextBox ID="lblLastYearSaleBook" runat="server"   onkeypress='javascript:tbx_fnNumeric(event, this);' Text='<%#Eval("LastYearSale") %>' ></asp:TextBox>
                                     
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2379;&#2332;&#2369;&#2342;&#2366; &#2360;&#2340;&#2381;&#2352; &#2350;&#2375;&#2306; &#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2361;&#2375;&#2340;&#2369; &#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; / Current Year Open Market Sales Book">
                                    <ItemTemplate>                                        
                                         <asp:TextBox ID="lblCurntYearOpenBook" runat="server" onblur="CalulateTotal(this);" onkeypress='javascript:tbx_fnNumeric(event, this);'   OnTextChanged="lblCurntYearOpenBook" Text='<%#Eval("CurntYarNeed") %>' ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                          <%--      <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2361;&#2375;&#2340;&#2369; &#2348;&#2330;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2360;&#2306;&#2349;&#2366;&#2357;&#2367;&#2340; &#2360;&#2381;&#2335;&#2377;&#2325; ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPlanStock" runat="server" CssClass="txtbox"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="&#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2361;&#2375;&#2340;&#2369; &#2348;&#2330;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2360;&#2306;&#2349;&#2366;&#2357;&#2367;&#2340; &#2360;&#2381;&#2335;&#2377;&#2325; / Remain Stock As Per Open Market">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOpenTentetiveStock" onblur="CalulateTotal1(this);" onkeypress='javascript:tbx_fnNumeric(event, this);'  OnTextChanged="lblCurntYearOpenBook" runat="server" CssClass="txtbox" Text='<%#Eval("OpnMrketStk") %>' MaxLength="10" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2379;&#2332;&#2369;&#2342;&#2366; &#2360;&#2340;&#2381;&#2352; &#2361;&#2375;&#2340;&#2369; &#2344;&#2375;&#2335; &#2350;&#2366;&#2306;&#2327; / Net Demand on Current Year
                                     ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtNetDemand"  runat="server" CssClass="txtbox" Enabled="false" MaxLength="10" Text='<%#Eval("NetDemand") %>' onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; " Visible="false">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRemark" runat="server" CssClass="txtbox"  MaxLength="200"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                  </asp:GridView>
                        <br />
                        <asp:Button ID="btnSave" Visible="false" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save  " 
                            OnClientClick="return ValidateAllTextForm();" onclick="btnSave_Click" />
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                    </td>
                </tr>

                <tr><td colspan="4">
                <asp:GridView ID="grdSendForApproval" runat="server" AutoGenerateColumns="False" GridLines="None"
                            CssClass="tab" EmptyDataText="Record Not Found." Width="100%" DataKeyNames="OpnMrktId_I" OnRowDeleting="grdSendForApproval_RowDeleting" OnSelectedIndexChanged="grdSendForApproval_SelectedIndexChanged" OnRowDataBound="grdSendForApproval_RowDataBound" ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:BoundField DataField="Session_v" HeaderText=" &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;  / Academic Year" />
                               
                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Book Name  ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTitleID_I" runat="server" Text='<%#Eval("TitleID_I") %>' Visible="false"></asp:Label>
                                        <%#Eval("TitleHindi_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2367;&#2331;&#2354;&#2375; &#2360;&#2340;&#2381;&#2352; &#2350;&#2375;&#2306; &#2357;&#2367;&#2325;&#2381;&#2352;&#2351; &#2325;&#2368; &#2327;&#2351;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375; / Sold Books in Last Year ">
                                    <ItemTemplate>
                                      <asp:Label ID="lblLastYearSaleBook" runat="server"   onkeypress='javascript:tbx_fnNumeric(event, this);' Text='<%#Eval("LastYearSale") %>' ></asp:Label>
                                     
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2379;&#2332;&#2369;&#2342;&#2366; &#2360;&#2340;&#2381;&#2352; &#2350;&#2375;&#2306; &#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2361;&#2375;&#2340;&#2369; &#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; / Need As Per Open Market In Current Year">
                                    <ItemTemplate>                                        
                                         <asp:Label ID="lblCurntYearOpenBook" runat="server" onblur="CalulateTotal(this);" onkeypress='javascript:tbx_fnNumeric(event, this);'   OnTextChanged="lblCurntYearOpenBook" Text='<%#Eval("CurntYarNeed") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                          <%--      <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2361;&#2375;&#2340;&#2369; &#2348;&#2330;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2360;&#2306;&#2349;&#2366;&#2357;&#2367;&#2340; &#2360;&#2381;&#2335;&#2377;&#2325; ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPlanStock" runat="server" CssClass="txtbox"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="&#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2361;&#2375;&#2340;&#2369; &#2348;&#2330;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2360;&#2306;&#2349;&#2366;&#2357;&#2367;&#2340; &#2360;&#2381;&#2335;&#2377;&#2325; / To Remain Pssible Stock  As Per Open Market ">
                                    <ItemTemplate>
                                        <asp:Label ID="txtOpenTentetiveStock" onblur="CalulateTotal1(this);" onkeypress='javascript:tbx_fnNumeric(event, this);'  OnTextChanged="lblCurntYearOpenBook" runat="server" 
                                        
                                        
                                        
                                        
                                         Text='<%#Eval("OpnMrketStk") %>' MaxLength="10" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2379;&#2332;&#2369;&#2342;&#2366; &#2360;&#2340;&#2381;&#2352; &#2361;&#2375;&#2340;&#2369; &#2344;&#2375;&#2335; &#2350;&#2366;&#2306;&#2327; / Net Demand In Current Year ">
                                    <ItemTemplate>
                                        <asp:Label ID="txtNetDemand"  runat="server"  Enabled="false" MaxLength="10" Text='<%#Eval("NetDemand") %>' onkeypress='javascript:tbx_fnInteger(event, this);'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325;" Visible="false">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRemark" runat="server" CssClass="txtbox"  MaxLength="200"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                                <asp:CommandField ShowSelectButton="True" HeaderText="Update" />
                            </Columns>
                                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                
                <asp:Button Text="&#2357;&#2367;&#2340;&#2352;&#2339; &#2358;&#2366;&#2326;&#2366; &#2325;&#2379; &#2346;&#2381;&#2352;&#2375;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " CssClass="btn" ID="btnsend" runat="server"  OnClick="send" />
                
                </td> </tr>
            </table>

              <div id="fadeDiv" runat="server" class="modalBackground" style="display: none">
    </div>
     <div id="Messages" style="display: none; width:80%; left:5%" class="popupnew" runat="server">

          <div class="card-header">
                 <h2>
                    <span>&#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; </span></h2> </div>
         <br />
         <b>
              &#2325;&#2371;&#2346;&#2351;&#2366; &#2343;&#2381;&#2351;&#2366;&#2344; &#2342;&#2375; &#2325;&#2368; &#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; &#2325;&#2375;&#2357;&#2354; &#2319;&#2325; &#2348;&#2366;&#2352; &#2361;&#2368; &#2360;&#2349;&#2368; &#2357;&#2367;&#2359;&#2351;&#2379;&#2306; &#2325;&#2368; &#2325;&#2352;&#2344;&#2368; &#2361;&#2376; &#2309;&#2340; &#2346;&#2352;&#2381;&#2351;&#2366;&#2346;&#2381;&#2340; &#2357;&#2367;&#2330;&#2366;&#2352; &#2357;&#2367;&#2350;&#2352;&#2381;&#2358; &#2319;&#2357;&#2306; &#2310;&#2306;&#2325;&#2354;&#2344; &#2325;&#2375; &#2348;&#2366;&#2342; &#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; &#2349;&#2375;&#2332;&#2375;|<br />
              &#2311;&#2360; &#2350;&#2366;&#2306;&#2327; &#2350;&#2375;&#2306; &#2325;&#2367;&#2360;&#2368; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; &#2325;&#2366; &#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2344; &#2348;&#2366;&#2342; &#2350;&#2375;&#2306; &#2360;&#2381;&#2357;&#2368;&#2325;&#2371;&#2340; &#2344;&#2361;&#2368;&#2306; &#2361;&#2379;&#2327;&#2366;|</b>
              <br /><br />    <asp:Button Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375; " CssClass="btn" ID="Button12" runat="server"  OnClick="btn1" />
                
        </div>

        </ContentTemplate>
        <Triggers>
        <asp:PostBackTrigger ControlID="btnSave" />
        <asp:PostBackTrigger ControlID="btnsend" />
        
        </Triggers>
          
    
        </asp:UpdatePanel>
        
    </div>
</asp:Content>
