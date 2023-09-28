<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InterDepoBookReceived.aspx.cs" Inherits="Depo_InterDepoBookReceived" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>
   <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                            <ProgressTemplate>
                                <div class="fade">
                                </div>
                                <div class="progress">
                                    <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                                </div>
                            </ProgressTemplate>
                            </asp:UpdateProgress>
      <div class="card-header">
            <h2>
                <span></span></h2>
        </div>
  <div class="box">

    <asp:HiddenField ID="hdnTitleID" runat="server" />
     <asp:HiddenField ID="hdnMasterID" runat="server" />
     <asp:HiddenField ID="HdnTrasactionID" runat="server" />
                            <div class="card-header">
                                <h2><span> &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; / &#2309;&#2306;&#2340;&#2352;&#2381;&#2337;&#2367;&#2346;&#2379; &#2360;&#2375; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; / Recieved Book From InterDepo / Printers  </span></h2>
                            </div>
                            <div style="padding:0 10px;">
                                       <asp:Panel   CssClass="form-message sucess" runat="server" id="mainDiv" style="display: none;padding-top:10px;padding-bottom:10px;">
                <asp:Label  id="lblmsg" CssClass="notification" runat="server" Font-Bold="true" ForeColor="Red" >
                
            </asp:Label>
            </asp:Panel>
                            <table width="100%" border=".5">
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
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                        <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" CssClass="txtbox" onselectedindexchanged="RadioButtonList2_SelectedIndexChanged" RepeatDirection="Horizontal" Width="322px">
                                            <asp:ListItem Selected="True" Value="1">&#2346;&#2381;&#2352;&#2367;&#2344;&#2381;&#2335;&#2352;/Printer</asp:ListItem>
                                            <asp:ListItem Value="3">&#2309;&#2344;&#2381;&#2351;/Other</asp:ListItem>
                                        </asp:RadioButtonList>
                

                                    </td> </tr> 
                                <tr>
                                    <td colspan="4" style="text-align: center">&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2357;&#2352;&#2381;&#2359; :<asp:DropDownList ID="DdlACYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Select..</asp:ListItem>
                                        <asp:ListItem Value="1">&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352;</asp:ListItem>
                                        <asp:ListItem Value="2">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; </asp:ListItem>
                                        <asp:ListItem Value="3">&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </asp:ListItem>
                                        <asp:ListItem Value="4">&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;</asp:ListItem>
                                        <asp:ListItem Value="5">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;</asp:ListItem>
                                        <asp:ListItem Value="6">&#2348;&#2369;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; </asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                        <asp:Button ID="Button9" runat="server" CssClass="btn" OnClick="Button9_Click" Text="&#2348;&#2366;&#2352;&#2325;&#2379;&#2337;  &#2360;&#2375; &#2309;&#2346;&#2354;&#2379;&#2337; &#2348;&#2306;&#2337;&#2354; &#2351;&#2342;&#2367; &#2358;&#2379; &#2344;&#2361;&#2368;&#2306; &#2361;&#2379; &#2352;&#2361;&#2375; &#2361;&#2379; &#2340;&#2379; &#2311;&#2360; &#2346;&#2352; &#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375;&#2306; " />
                                    </td> </tr> 
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                    <div style="overflow:auto;" id="ra" runat="server"> 
                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" 
                                            CssClass="tab" DataKeyNames="PriTransID" 
                                            onselectedindexchanged="grdDetails_SelectedIndexChanged">
                                            <Columns>
                                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                     <asp:HiddenField ID="HiddenField1" runat="server"  Value='<%# Eval("TitleID_I") %>' />
                                                           <asp:HiddenField ID="Medium_I" runat="server" 
                                                         Value='<%# Eval("Medium_I") %>' />
                                                     <asp:HiddenField ID="ClassTrno_I" runat="server" 
                                                         Value='<%# Eval("ClassTrno_I") %>' />

                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                                 <ItemTemplate>
                                                     <%#Eval("DepoName") %>
                                                 </ItemTemplate> </asp:TemplateField> 
                                               <%-- <asp:BoundField DataField="DepoName" HeaderText="DepoName" />--%>

                                                <asp:BoundField DataField="BookType" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;" />
                                             <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; /Printer Name"><ItemTemplate><%# Eval("NameofPress_V")%></ItemTemplate></asp:TemplateField>
               
        <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/Challan No."><ItemTemplate><%# Eval("ChalanNo")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/Challan Date"><ItemTemplate><%# Eval("ChalanDate")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Book Name"><ItemTemplate><%# Eval("TitleHindi_V")%></ItemTemplate></asp:TemplateField>
                                                    <asp:BoundField DataField="bookno" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2306;&#2348;&#2352; " />
        <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;   /Total No. of Books "><ItemTemplate><%# Eval("TotalNoOfBooks")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (&#2351;&#2379;&#2332;&#2344;&#2366; ) / Book No. (Scheme) " Visible="false" >
            <ItemTemplate><%# Eval("TotalNoOfBooksYoj")%>

                                                                                                                                                                                          </ItemTemplate></asp:TemplateField>
                                                
                                         
                                               <%-- <asp:BoundField DataField="TotalAvantan" HeaderText="&#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2344;" />--%>
                                                
                                         
                                                <asp:TemplateField >
                                                 <ItemTemplate>
                                                 <asp:Button Text="&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2348;&#2367;&#2348;&#2352;&#2339; " ID="btnview" runat="server" OnClick="viewDatails" CommandArgument='<%#Eval("PriTransID") %>' CssClass="btn" />
                                                 <asp:Panel style="display:none;" id="DivR" class="popupnew1" runat="server">
                                                           <asp:Panel   class="form-message error" runat="server" id="mainDiv" style="display: none;padding-top:10px;padding-bottom:10px;">
                <asp:Label  id="lblmsg" class="notification" runat="server">
                
            </asp:Label>
            </asp:Panel>
                                        <a href="#" id="fancyboxclose" class="fancyboxclose" runat="server" style="display: block;" onclick="javascript:closeMessagesDiv(this);" ></a>                 
                                     
                                        
                                       <asp:GridView ID="GrdMismatch" runat="server" AutoGenerateColumns="false" CssClass="tab">
                                                 <Columns>
                                                 <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2360;&#2375; &#2349;&#2375;&#2332;&#2375; &#2327;&#2351;&#2375; &#2325;&#2369;&#2354; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("Toatl") %>' ID="lblTitleHindi_V" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="&#2348;&#2366;&#2352;&#2325;&#2379;&#2337; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2306;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("Received") %>' ID="lblbooktype" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2325;&#2375; &#2354;&#2367;&#2319; &#2348;&#2330;&#2375; &#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  ">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("Remain") %>' ID="lblBundleNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                
                                                   <asp:TemplateField HeaderText="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2375;&#2326;&#2375; ">
                                                 <ItemTemplate>
                                                <a href="ShowReceivedDetails.aspx?ID='<%#Eval("PriTransID") %>'&SubJectID_I='<%#Eval("SubJectID_I")%>'">&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2375;&#2326;&#2375;.</a>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                 </Columns>
                                                 </asp:GridView>
                            </asp:Panel>

                                                 
                                                 </ItemTemplate></asp:TemplateField>
                                                
                                         
                                                <asp:CommandField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2352;&#2375; " SelectText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2352;&#2375;" 
                                                    ShowSelectButton="True" />
                                                    <asp:TemplateField >
                                                 <ItemTemplate>
                                                
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                            </Columns>
                                        </asp:GridView>
                                        </div>
                                        <table id="tblDepo" runat="server">
                                        <tr><td>&nbsp;&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/Challan No</td> <td><asp:DropDownList ID="ddlOrderNo" runat="server" AutoPostBack="true"></asp:DropDownList> </td><td>&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360; &#2330;&#2369;&#2344;&#2375;/Ware House </td> <td> <asp:DropDownList ID="ddldepoWarehouse" runat="server" CssClass="txtbox reqirerd"></asp:DropDownList> <asp:Button CssClass="btn" Text="&#2310;&#2327;&#2375;  &#2348;&#2338;&#2375;" ID="btnSearch" runat="server" OnClick="SerarchDepoOrdere" /> </td> </tr>
                                        </table>
                               
                                         <asp:GridView ID="grdInterdepoRequest" runat="server" CssClass="tab" AutoGenerateColumns="False">
              <Columns>
               <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; /Titile" >
              <ItemTemplate>
              <asp:Label ID="lblt" runat="server" Text='<%#Eval("Title") %>' ></asp:Label>
              </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/Total Book No" >
              <ItemTemplate>
              <asp:Label ID="lblt" runat="server" Text='<%#Eval("NO Of Books") %>' ></asp:Label>
              </ItemTemplate>
              </asp:TemplateField>
             <asp:TemplateField HeaderText=" &#2348;&#2306;&#2337;&#2354;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/BundleNo" >
              <ItemTemplate>
              <asp:Label ID="lblt1" runat="server" Text='<%#Eval("BundleCount") %>' ></asp:Label>
              
              </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/Lose books no." >
               <ItemTemplate>
              <asp:Label ID="lblt11" runat="server" Text='<%#Eval("LooseBundleCount") %>' ></asp:Label>
              </ItemTemplate>
              </asp:TemplateField>
             
              </Columns>
              </asp:GridView>
              <asp:Button CssClass="btn" runat="server" Text="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2325;&#2368; &#2346;&#2381;&#2352;&#2325;&#2367;&#2351;&#2366; &#2360;&#2350;&#2366;&#2346;&#2381;&#2340; &#2325;&#2352;&#2375;" ID="btnSaveAll" Visible="false" OnClick ="SaveAll"/>
                                         

                                        <asp:GridView ID="grdDepoTransfer" runat="server" AutoGenerateColumns="False" 
                                            CssClass="tab" DataKeyNames="DemandChildTrno" 
                                            onselectedindexchanged="grdDetails_SelectedIndexChanged" 
                                            onrowdatabound="grdDepoTransfer_RowDataBound1">
                                            <Columns>
                                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/S.No">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                     <asp:HiddenField ID="HiddenField1" runat="server"  Value='<%# Eval("TitleID_i") %>' />
                                                     <asp:HiddenField ID="booktype" runat="server"  Value='<%# Eval("BookType") %>'/>
                                                      <asp:HiddenField ID="SDepoTrno_I" runat="server"  Value='<%# Eval("SDepoTrno_I") %>'/>
                                                           <asp:HiddenField ID="Medium_I" runat="server" 
                                                         Value='<%# Eval("Medium_I") %>' />
                                                     <asp:HiddenField ID="ClassTrno_I" runat="server" 
                                                         Value='<%# Eval("ClassTrno_I") %>' />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                               
                                            <%--    <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; / &#2309;&#2306;&#2340;&#2352;&#2381;&#2337;&#2367;&#2346;&#2379; &#2344;&#2366;&#2350; " DataField="NameofPress_V" />--%>
                                                <asp:BoundField HeaderText="&#2350;&#2366;&#2306;&#2327; &#2344;&#2306;&#2348;&#2352; /Request No" DataField="reqno" />
                                                <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;/Book Name" DataField="TitleHindi_V" />
                                                <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;/Book Type  (&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;/ &#2351;&#2379;&#2332;&#2344;&#2366;)" DataField="BookType"/>
                                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;/ InterDepo Name" DataField="SDepoName_V" />
                                                <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/Total books No" DataField="netdemand" />

                                                
                                                <asp:CommandField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2352;&#2375;" SelectText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2352;&#2375;" 
                                                    ShowSelectButton="True" />

                                                    <asp:TemplateField >
                                                        <ItemTemplate>
                                                           
                                                           <%--<a href="#" id="bundalNo" runat="server" onclick="GetPopupBundle(this)">&#2348;&#2306;&#2337;&#2354; &#2319;&#2357;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</a>--%>
                                                           <asp:Panel style="display:none;" id="DivR" class="popupnew1" runat="server">
                                                           <asp:Panel   class="form-message error" runat="server" id="mainDiv" style="display: none;padding-top:10px;padding-bottom:10px;">
                <asp:Label  id="lblmsg" class="notification" runat="server">
                
            </asp:Label>
            </asp:Panel>
                                        <a href="#" id="fancyboxclose" class="fancyboxclose" runat="server" style="display: block;" onclick="javascript:closeMessagesDiv(this);" ></a> 
                                        <asp:GridView ID="datalist" runat="server" AutoGenerateColumns="false"  onrowdatabound="grdDepoTransfer_RowDataBoundNew" CssClass="tab" >
                                        <Columns>
                                        <asp:TemplateField HeaderText="&#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                        <ItemTemplate>
                                           <asp:Label ID="lblbundalno" runat="server"  Text='<%#Eval("BundleNo_I") %>' />
                                           <asp:HiddenField ID="StockDetailsID_I" Value='<%#Eval("StockDetailsChildID_I") %>'  runat="server"/>
                                           <asp:HiddenField ID="hdnLooseBundal" Value='<%#Eval("RemaingLoose_V") %>'  runat="server"/>
                                           <asp:HiddenField ID="hdnFromNo_I" Value='<%#Eval("FromNo_I") %>'  runat="server"/>
                                            <asp:HiddenField ID="hdnToNo_I" Value='<%#Eval("ToNo_I") %>'  runat="server"/>
                                            <asp:HiddenField ID="HiddenField6" Value='<%#Eval("BookType") %>'  runat="server"/>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2346;&#2370;&#2352;&#2366; &#2348;&#2306;&#2337;&#2354; ">
                                        <ItemTemplate>
                                         <asp:CheckBox ID="chk" runat="server" OnCheckedChanged="ChechedChangeWholeBundle" AutoPostBack="true"  />
                                        </ItemTemplate>
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2354;&#2370;&#2395; &#2348;&#2306;&#2337;&#2354;">
                                        <ItemTemplate>
                                         <asp:CheckBox ID="chk1" runat="server"   OnCheckedChanged="ChechedChangeLooseBundle" AutoPostBack="true"/>
                                        </ItemTemplate>
                                       </asp:TemplateField> 
                                        <asp:TemplateField HeaderText="&#2354;&#2370;&#2395; &#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                        <ItemTemplate>
                                         <asp:CheckBoxList ID="chklist" runat="server" RepeatColumns="10"   />
                                        </ItemTemplate>
                                       </asp:TemplateField> 

                                        </Columns>
                                       </asp:GridView>
                                                        
                                       
                            </asp:Panel>
                                                            
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <div id="b" runat="server" visible ="false"  > 
                                <tr  >
                                    <td style="height: 24px" >
                                        &nbsp;</td>
                                    <td colspan="3" style="height: 24px" >
                                        &nbsp;</td>
                                </tr>
                                <tr  style="display:none;">
                                    <td >
                                        &#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; &#2310;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/Head Office Order No.</td>
                                    <td > 
                                        <asp:Label ID="lblorder" runat="server" ></asp:Label>
                                    </td>
                                    <td >
                                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/Date</td>
                                    <td >
                                        <asp:Label ID="lblorderDate" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr runat="server" visible="false"><td>&#2348;&#2366;&#2352;&#2325;&#2379;&#2337; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2368; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; </td> <td><asp:CheckBox ID="chkid" runat="server"  /> </td> </tr>
                                <tr >
                                    <td >
                                        &#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352;/Chalan No.</td>
                                    <td > 
                                        <asp:Label ID="lblchalan" runat="server" ></asp:Label>
                                    </td>
                                    <td >
                                        &#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /Chalan Date</td>
                                    <td >
                                        <asp:Label ID="lblchalandate" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr >
                                   
                                    <td>
                                        &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Printer name</td>
                                    <td>
                                        <asp:Label ID="lblAddress" runat="server" ></asp:Label>
                                        </td>
                                         <td>  </td>
                                    <td>
                                            </td>
                                </tr>
                                <tr>
                                    <td>
                                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Book Name</td>
                                    <td>
                                        <asp:Label ID="lblbookName" runat="server" ></asp:Label>
                                    </td>
                                    <td>
                                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; </td>
                                    <td>
                                        <asp:Label ID="lblBookType" runat="server"  ></asp:Label>
                                    </td>
                                </tr>
                                <tr >
                                    <td style="height: 32px">
                                    &#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2349;&#2375;&#2332;&#2375; &#2327;&#2351;&#2375; &#2325;&#2369;&#2354; &#2348;&#2339;&#2381;&#2337;&#2354; </td>
                                    <td style="height: 32px">
                                            <asp:Label ID="lblSBundleCount" runat="server" ></asp:Label>
                                    </td>
                                    <td style="height: 32px">&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2339;&#2381;&#2337;&#2354; </td>
                                    <td style="height: 32px">
                                            <asp:Label ID="lblYBundlecnt" runat="server"  ></asp:Label>
                                    </td>
                                </tr>
                                <tr >
                                    <td style="height: 32px; display: none;">
                                        &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;/From General Book No.</td>
                                    <td style="height: 32px; display: none;">
                                            <asp:Label ID="lblbookNofrom" runat="server" ></asp:Label>
                                    </td>
                                    <td style="height: 32px; display: none;">
                                        &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;/To General Book No.</td>
                                    <td style="height: 32px; display: none;">
                                        <asp:Label ID="lblbookNoto" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                    <tr>
                                        <td style="height: 32px; display: none;">
                                            &#2351;&#2379;&#2332;&#2344;&#2366; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;/FromScheme Book No</td>
                                        <td style="height: 32px; display: none;">
                                            <asp:Label ID="lblyfrom" runat="server" ></asp:Label>
                                        </td>
                                        <td style="height: 32px; display: none;">
                                            &#2351;&#2379;&#2332;&#2344;&#2366; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;/To Scheme Book No</td>
                                        <td style="height: 32px; display: none;">
                                            <asp:Label ID="lblyto" runat="server" ></asp:Label>
                                        </td>
                                    </tr>
                                 <tr>
                                    <td>
                                        &nbsp;&#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350; /Ware House Name
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlWarehouse" runat="server" CssClass="txtbox reqirerd">
                                        </asp:DropDownList>
                                     </td>
                                    <td>
                                          
                                           &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                                    <td>
                                          <asp:TextBox ID="txtPdate" runat="server" CssClass="txtbox reqirerd" MaxLength="20" Enabled="false" ></asp:TextBox>
                                          <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                            TargetControlID="txtPdate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
     
                                            </td>
                                </tr>
                                 
                                 <tr>
                                    <td>
                                        &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352;&nbsp; /Bilti No</td>
                                    <td>
                                        <asp:TextBox ID="txtGrNo" runat="server" CssClass="txtbox reqirerd" MaxLength="20"></asp:TextBox></td>
                                    <td>
                                        &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/Bilti date</td>
                                    <td>
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="txtbox reqirerd" MaxLength="14"></asp:TextBox></td>
                                </tr>
                                 
                                <tr >
                                    <td>
                                        &#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352; /Truck No.</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtTruckNo" runat="server" CssClass="txtbox reqirerd" 
                                             MaxLength="10"></asp:TextBox>
                                        <asp:HiddenField ID="TiltleID" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                <td colspan="4">
                                
                                
                                </td>
                                </tr>
                                <tr > 
                                    <td style="text-align: center; height: 20px;" colspan="4" class="card-header">
                                      
                                     <h2>  &#2337;&#2367;&#2346;&#2379; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2325;&#2367;&#2351;&#2375; &#2327;&#2351;&#2375; &#2357;&#2381;&#2351;&#2351; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;/Expense Details By Depot</h2>  </td>
                                </tr>
                               <tr >
                                    <td>
                                        &#2313;&#2340;&#2352;&#2366;&#2312;/UnLoading</td>
                                    <td>
                                        <asp:TextBox ID="txtunloding" runat="server" CssClass="txtbox" MaxLength="5"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);' Text="0"></asp:TextBox></td>
                                    <td>
                                        &#2330;&#2338;&#2366;&#2312;/ UpLoadin</td>
                                    <td>
                                        <asp:TextBox ID="txtloding" runat="server" CssClass="txtbox" MaxLength="5"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);' Text="0"></asp:TextBox></td>
                                </tr>
                                <tr >
                                    <td>
                                        &#2346;&#2352;&#2367;&#2357;&#2361;&#2344;/ Transport</td>
                                    <td>
                                        <asp:TextBox ID="txtTransport" runat="server" CssClass="txtbox" MaxLength="5"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);' Text="0"></asp:TextBox></td>
                                    <td>
                                        &#2309;&#2344;&#2381;&#2351;/Others </td>
                                    <td>
                                        <asp:TextBox ID="txtOther" runat="server" CssClass="txtbox" MaxLength="5"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);' Text="0"></asp:TextBox></td>
                                </tr>
                                <tr >
                                    <td style="height: 26px">
                                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; / Book Reciever Name</td>
                                    <td colspan="3" style="height: 26px">
                                        <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="txtbox reqirerd">
                                            <asp:ListItem>Select..</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr visible="false" runat="server"  >
                                    <td>
                                        &#2325;&#2381;&#2351;&#2366; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375; &#2350;&#2366;&#2344;&#2325; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2361;&#2376;/ Book is As Per As Scale</td>
                                    <td colspan="3">
                                        <asp:RadioButtonList ID="RdlManak" runat="server" RepeatDirection="Horizontal" 
                                            AutoPostBack="True" 
                                            OnSelectedIndexChanged="RadioButtonList3_SelectedIndexChanged" Width="546px" 
                                            CssClass="reqirerd">
                                            <asp:ListItem Value="1" Selected="True" >&#2361;&#2366;&#2306;</asp:ListItem>
                                            <asp:ListItem Value="2">(&#2344;&#2361;&#2368;&#2306;) &#2346;&#2340;&#2381;&#2352; &#2332;&#2366;&#2352;&#2368; &#2325;&#2352;&#2375; </asp:ListItem>
                                            <asp:ListItem Value="3">(&#2344;&#2361;&#2368;&#2306;) &#2346;&#2340;&#2381;&#2352; &#2348;&#2366;&#2342; &#2350;&#2375;&#2306; &#2332;&#2366;&#2352;&#2368; &#2325;&#2352;&#2375; </asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr runat="server" visible="false" >
                                    <td>
                                        &#2325;&#2381;&#2351;&#2366; &#2310;&#2346; 25 % &#2327;&#2339;&#2344;&#2366; &#2325;&#2368; &#2352;&#2360;&#2368;&#2342; &#2332;&#2366;&#2352;&#2368; &#2325;&#2352;&#2344;&#2366; &#2330;&#2366;&#2361;&#2340;&#2375; &#2361;&#2376;
                                    </td>
                                    <td colspan="3">
                                        <asp:RadioButtonList ID="RdlTwentyFivePer" AutoPostBack="true" 
                                            OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" runat="server" 
                                            RepeatDirection="Horizontal" CssClass="reqirerd">
                                            <asp:ListItem Value="1" Selected="True">&#2361;&#2366;&#2306;</asp:ListItem>
                                            <asp:ListItem Value="2">&#2344;&#2361;&#2368;&#2306;</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="Button1" CssClass="btn" runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; " OnClick="Button1_Click" OnClientClick="return ValidateAllTextForm();" />
                 
                <asp:HiddenField ID="ClassID" runat="server" />
                <asp:HiddenField ID="MediunID" runat="server" />
                <asp:HiddenField ID="hPrinterID" runat="server" />
            </td>
        </tr>
        </div>

                               <div id="divDepo" runat="server" visible="false">
                                <table>
                                

                                  <tr>
                                    <td style="height: 24px" >
                                        &nbsp;</td>
                                    <td colspan="3" style="height: 24px" >
                                        &nbsp;</td>
                                </tr>
                                <tr><td colspan="4" style="display:none;">
                                   <table>
                                    
                                
                                <tr>
                                    <td> &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; (&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;/ &#2351;&#2379;&#2332;&#2344;&#2366;)/ Book Type(General/Scheme)
                                            
                                    </td>
                                    <td>
                                            <asp:Label ID="lblDepoBookType" runat="server" CssClass="txtbox"></asp:Label>
                                    </td>
                                    <td>
                                        &#2309;&#2306;&#2340;&#2352;&#2381;&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;/ InterDepo Name
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDepoName" runat="server" CssClass="txtbox"></asp:Label>
                                        </td>
                                </tr>
                                <tr>
                                    <td>
                                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Book Name</td>
                                    <td>
                                        <asp:Label ID="lblDepoBookName" runat="server" CssClass="txtbox"></asp:Label>
                                    </td>
                                    <td>
                                        &#2335;&#2379;&#2335;&#2354; &#2348;&#2369;&#2325;/ Total Book</td>
                                    <td>
                                        <asp:Label ID="lblDepoTotalBook" runat="server" CssClass="txtbox"></asp:Label>
                                    </td>
                                </tr>
                                   </table>
                                </td>
                              

                                </tr>

                               
                                 <tr >
                                    <td>
                                        &#2313;&#2340;&#2352;&#2366;&#2312;/ UnLoading</td>
                                    <td>
                                        <asp:TextBox ID="txtdepolOading" runat="server" CssClass="txtbox reqirerd" MaxLength="5"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox></td>
                                    <td>
                                        &#2330;&#2338;&#2366;&#2312;/ UpLoading</td>
                                    <td>
                                        <asp:TextBox ID="txtDepoUnloading" runat="server" CssClass="txtbox reqirerd" MaxLength="5"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        &#2346;&#2352;&#2367;&#2357;&#2361;&#2344;/ Transport</td>
                                    <td>
                                        <asp:TextBox ID="txtDepoTransport" runat="server" CssClass="txtbox reqirerd" MaxLength="5"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox></td>
                                    <td>
                                        &#2309;&#2344;&#2381;&#2351;/ Others</td>
                                    <td>
                                        <asp:TextBox ID="txtDepoother" runat="server" CssClass="txtbox reqirerd" MaxLength="5"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox></td>
                                </tr>
                                  <tr>
                                    <td>
                                        &#2332;&#2368;.&#2310;&#2352; .&#2344;&#2306;&#2348;&#2352; / G.R. No.</td>
                                    <td>
                                        <asp:TextBox ID="txtDepoGrno" runat="server" CssClass="txtbox reqirerd" MaxLength="20"></asp:TextBox></td>
                                    <td>
                                        &#2332;&#2368;.&#2310;&#2352;.&#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ G.R. Date</td>
                                    <td>
                                        <asp:TextBox ID="txtDepoGrnoDate" runat="server" CssClass="txtbox reqirerd" MaxLength="14"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                            TargetControlID="txtDepoGrnoDate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
                                        </td>
                                </tr>
                                 
                                <tr >
                                    <td>
                                        &#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352; /Truck No.</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtDepoTruck" runat="server" CssClass="txtbox reqirerd" 
                                            SkinID="30" MaxLength="10"></asp:TextBox>
                                        <asp:HiddenField ID="HiddenField5" runat="server" />
                                    </td>
                                </tr>
                                <tr >
                                    <td style="height: 26px">
                                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; / Book Reciever Name</td>
                                    <td colspan="3" style="height: 26px">
                                        <asp:DropDownList ID="ddldepoEmployee" runat="server" CssClass="txtbox reqirerd">
                                            <asp:ListItem>Select..</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                       
                                     </td>
                                    <td>
                                          
                                            &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                  <tr>
            <td colspan="4">
                <asp:Button ID="Button5" CssClass="btn" runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; " OnClick="Button1_Click" OnClientClick="return ValidateAllTextForm();" />
                 
                <asp:HiddenField ID="HiddenField2" runat="server" />
                <asp:HiddenField ID="HiddenField3" runat="server" />
                <asp:HiddenField ID="HiddenField4" runat="server" />
            </td>
        </tr>
                                </table>
                              
                               </table>
                               
                               </div>
    </table>
                            
                            </div> </div> 
                              <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
            </div>
            <div id="Messages" style="display: none;" class="popupnew" runat="server">
                <h2>
                    
                </h2>
                <div class="msg MT10">
                <table class="tab" width="100%">
                    <tr>
                        <td>
           
                  &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2349;&#2375;&#2332;&#2375; &#2327;&#2319;  &#2348;&#2306;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (<asp:Label ID="Label2" runat="server" Text="" ></asp:Label>) &#2350;&#2375;&#2306; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (<asp:Label ID="Label1" runat="server" Text="" ></asp:Label>) &#2361;&#2376; &#2325;&#2381;&#2351;&#2366; &#2310;&#2346; &#2330;&#2366;&#2354;&#2366;&#2344; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2352;&#2344;&#2366; &#2330;&#2366;&#2361;&#2340;&#2375; &#2361;&#2379; !
                               </td>
                       
                    </tr>
                       <tr>
                        <td colspan="3">
                                                      
                              <asp:Button ID="Button3" CssClass="btn" runat="server" Text="&#2361;&#2366;&#2305;" OnClick="Close"  />
                            
                             <asp:Button ID="Button2" CssClass="btn" runat="server" Text="&#2344;&#2361;&#2368;&#2306; " OnClick="Close1"  />
                      
                            </td>
                            
                    </tr>
                </table>
                </div>
              
              
            </div>
            <script>
                function GetPopupBundle(obj, g) {

                    // obj = "'" + obj + "'";
                    //alert(obj);
                    //  alert(document.getElementById(obj.id.replace("bundalNo" ,"DivR"))


                    //  document.getElementById('"+obj+"').value = obj;
                    document.getElementById(obj.id.replace("bundalNo", "DivR")).style.display = "block";
                    document.getElementById('<%= fadeDiv.ClientID %>').style.display = "block";


                }
                function ValidateAllTextFormNew() {
                    if (document.getElementById(obj.id.replace("txtBundleNo", "btnSaveAll")).value == "") {
                        document.getElementById(obj.id.replace("txtBundleNo", "btnSaveAll")).focus();
                        return false;

                    }
                    //   document.getElementById(obj.id.replace("txtBundleNo", "btnSaveAll")).style.display = "block";
                    //document.getElementById("ContentPlaceHolder1_fadeDiv").style.display = "block";
                }
                function closeMessagesDiv(obj) {
                    document.getElementById(obj.id.replace("fancyboxclose", "DivR")).style.display = "none";
                    document.getElementById('<%= fadeDiv.ClientID %>').style.display = "none";
                    return false;
                }

                            </script>

</ContentTemplate>
</asp:UpdatePanel> 
  
</asp:Content>