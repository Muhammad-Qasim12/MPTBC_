<%@ Page Title="टेक्निकल बिड का तुलनात्मक पत्रक / Comparative Form Of Technical Bid" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TechnicalBid.aspx.cs" Inherits="Paper_TechnicalBid" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <script type = "text/javascript">
          function checkAll(objRef) {
              var GridView = objRef.parentNode.parentNode.parentNode;
              var inputList = GridView.getElementsByTagName("input");
              for (var i = 0; i < inputList.length; i++) {
                  //Get the Cell To find out ColumnIndex
                  var row = inputList[i].parentNode.parentNode;
                  if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                      if (objRef.checked) {
                          inputList[i].checked = true;
                      }
                      else {
                          inputList[i].checked = false;
                      }
                  }
              }
          }
</script>
    <div class="box">
        <div class="headlines">
            <h2>
                <span>
                    <%--Tender Evaluation--%> टेक्निकल बिड का तुलनात्मक पत्रक / Comparative Form Of Technical Bid
                </span>
            </h2>
        </div>
        <div class="table-responsive">
            <table width="100%">
                <tr>
                    <td>
                        <b>
                           शिक्षा सत्र  <br />Acadmic Year :	</b>
                    </td>
                    <td>
                            <asp:Label ID="lblAcYear" runat="server" ></asp:Label>
                    </td>
                    <td>
                        <b>
                            <%--Tender No. (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;.<br /> Tender No.</b>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlTenderType" AutoPostBack="True" CssClass="txtbox reqirerd"
                            OnInit="ddlTenderType_Init" OnSelectedIndexChanged="ddlTenderType_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Panel ID="Panel1" runat="server" BorderColor="gray" BorderStyle="solid" BorderWidth="1px">
                            <table width="100%">
                                <tr>
                                    <td colspan="4" style="height: 10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--RFP No. (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br /> Tender No.
                                        </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderNo" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <b>
                                            <%--Date (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br /> Tender Date
                                        </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderDt" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--Name of Work (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;<br /> Tender Name</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderWork" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <b>
                                            <%--Tender Type (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br /> Tender Type
                                        </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderType" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--Details (--%>&#2357;&#2367;&#2357;&#2352;&#2339; <br /> Description </b>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="lblTenderDtl" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--EMD. (--%>&#2312; .&#2319;&#2350;.&#2337;&#2368;. &#2352;&#2366;&#2358;&#2367;
                                            (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375; )<br />E.M.D. Amount</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEMd" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <b>
                                            <%--Tender Fee (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2347;&#2368;&#2360;(&#2352;&#2369;&#2346;&#2351;&#2375;
                                            &#2350;&#2375; )<br /> Tender Fee</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderFee" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--Submission Date (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2332;&#2350;&#2366;
                                            &#2325;&#2352;&#2344;&#2375; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br /> Submission Date</b>
                                    </td>
                                    <td >
                                        <asp:Label ID="lblSubDt" runat="server"></asp:Label>
                                    </td>
                                    <td>कुल वांछित पेपर मात्रा <br />
Total Required Paper Quantity</td><td><asp:Label ID="Label1" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 10px;">
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <b>
                            <%--Total No. of Participant (--%>&#2344;&#2367;&#2357;&#2367;&#2342;&#2366; &#2325;&#2352;&#2344;&#2375;
                            &#2357;&#2366;&#2354;&#2368; &#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2368;
                            &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; <br /> Details Of Participate Company</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table class="tab">
                            <tr>
                                <th style="width:50%;">
                                    <%--Name Of Company--%>&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350;<br />Name Of Company
                                </th>
                                <th  style="width:50%;">
                                    <%--Company Address--%>&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2346;&#2340;&#2366;<br />Company Address
                                </th>
                            </tr>
                            <tr>
                                <td  style="width:50%;">
                                    <asp:DropDownList runat="server" ID="ddlVenderFill" AutoPostBack="True" CssClass="txtbox reqirerd"
                                        OnInit="ddlVenderFill_Init" OnSelectedIndexChanged="ddlVenderFill_SelectedIndexChanged">
                                        <asp:ListItem Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td  style="width:50%;">
                                    <asp:Label ID="lblCompAdd" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <b>
                            <%--Total No. of Participant (--%>तुलनात्मक पत्रक<br />Comparative Form </b>
                    </td>
                </tr>
                <tr>
                    
                    <td colspan="4">
                        <asp:GridView ID="GrdWorkPlan" runat="server" AutoGenerateColumns="false" GridLines="None"
                            DataKeyNames="Tender_Cond_Id" CssClass="tab" EmptyDataText="Record Not Found."
                            Width="100%" AllowPaging="false" 
                            onrowdatabound="GrdWorkPlan_RowDataBound" >
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br> SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="&#2330;&#2369;&#2344;&#2375;<br> Select">
                                     <HeaderTemplate>
                                        <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />  चुने </br>Select
                                    </HeaderTemplate>
                                    <ItemTemplate> 
                                    <asp:Label ID="lblCheckStatus" runat="server" Text='<%#Eval("CheckStatus")%>' Visible="false"></asp:Label>   
                                        <asp:CheckBox ID="chkSelect" runat="server" />                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2358;&#2352;&#2381;&#2340;&#2375;<br>Conditions  ">
                                    <ItemTemplate>   
                                    <asp:Label ID="lblTechn_TrId" runat="server" Text='<%#Eval("Techn_TrId")%>' Visible="false"></asp:Label>                                     
                                        <asp:Label ID="lblTndrCondition" runat="server" Text='<%#Eval("TndrCondition")%>'></asp:Label>                               
                                        <asp:Label ID="lblTender_Cond_Id" runat="server" Text='<%#Eval("Tender_Cond_Id")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                             
                            </Columns>
                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                                     <PagerStyle CssClass="Gvpaging" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr> 
                     <td >
                 <a href="javascript:history.go(-1)" style="font-family: Arial; font-size: large; color: #3366CC"><B> Back</B></a> 
                 </td>
                    <td colspan="3">
                        <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save"
                            CssClass="btn" OnClick="btnSave_Click" OnClientClick="return ValidateAllTextForm();"  />
                      
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
