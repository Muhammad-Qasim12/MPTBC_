<%@ Page Title="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; 100 % &#2327;&#2339;&#2344;&#2366; &#2352;&#2360;&#2368;&#2342; / Book's 100% Calculated Recipt" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DPT013_HundredPer.aspx.cs" Inherits="Depo_DPT013_HundredPer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
                            <div class="card-header">
                                <h2><span>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; 100 % &#2327;&#2339;&#2344;&#2366; &#2352;&#2360;&#2368;&#2342; / Book's 100% Calculated Receipt </span></h2>
                            </div>
                            <div style="padding:0 10px;">
                            
                            <table width="100%">
                                <tr  >
                                    <td style="height: 24px; " colspan="4">
                            <span>
                                    <asp:GridView ID="GrdMain" runat="server" AutoGenerateColumns="False" 
                                        CssClass="tab" DataKeyNames="PinterID_I" 
                                        onselectedindexchanged="GrdMain_SelectedIndexChanged">
                                        <Columns>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                            <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Printer Name " DataField="NameofPress_V" />
                                            <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2346;&#2340;&#2366; / Printers Address" DataField="FullAddress_V" />
                                            <asp:CommandField SelectText="&#2327;&#2339;&#2344;&#2366; &#2352;&#2360;&#2368;&#2342; &#2332;&#2366;&#2352;&#2368; &#2325;&#2352;&#2375; / Get  Recipt" ShowSelectButton="True" />
                                        </Columns>
                                        <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                    </asp:GridView>
    </span>
                                    </td>
                                </tr>
                                <div id="a" runat="server" visible="false" >
                                <tr  >
                                    <td >
                                        &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Printer Name </td>
                                    <td colspan="3" >
                                        <asp:Label ID="lblPriner" runat="server" CssClass="txtbox"></asp:Label></td>
                                </tr>
                             
                                <tr >
                                    <td colspan="4" >
                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="StockReceivedTPerID_I">
                                            <Columns>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     <asp:HiddenField ID="HiddenField1" runat="server" 
                                                         Value='<%# Eval("StockReceivedTPerID_I") %>' />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                                <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Book Name" DataField="TitleHindi_V" />
                                                 <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;  / Book Type" DataField="BookType" />
                                                <asp:BoundField  HeaderText=" &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Printers Chalan No.  / Date" 
                                                    DataField="ChallanNo_V" />
                                                <asp:BoundField  HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2349;&#2375;&#2332;&#2368; &#2327;&#2312; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Sent Books By Printers" 
                                                    DataField="TotalBooCount" />
                                                <asp:BoundField  HeaderText="(25%) &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Recieved Book( 25%)" 
                                                    DataField="TotalBooCount" />
                                                <asp:BoundField DataField="Trdate" HeaderText="प्राप्ति दिनांक" />
                                                <asp:BoundField  HeaderText="(25%)&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / (25%) Recieved Date" 
                                                    DataField="Receiveddate_D"  />
                                                <asp:BoundField  HeaderText="&#2337;&#2367;&#2346;&#2379; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2325;&#2367;&#2351;&#2375; &#2327;&#2351;&#2375; &#2325;&#2369;&#2354; &#2357;&#2381;&#2351;&#2351; / Total Expense By Depo" 
                                                    DataField="TotalCharge" />
                                                <asp:TemplateField HeaderText="&#2309;&#2306;&#2340;&#2367;&#2350; &#2327;&#2339;&#2344;&#2366; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / NO. Recieved Books in Last Calculation">
                                                    <ItemTemplate>
                                                        योजना :
                                                        <asp:TextBox ID="txtNoofBook" runat="server" Width="87px" CssClass="txtbox reqirerd" MaxLength="6" onkeyup='javascript:tbx_fnSignedNumericCheck(this);' Text='<%# Eval("TotalBook") %>'></asp:TextBox>
                                                        <br />
                                                         सामान्य :
                                                         <asp:TextBox ID="TextBox2" runat="server" Width="87px" CssClass="txtbox reqirerd" MaxLength="6" Text='<%# Eval("TotalNotuseful_N1") %>' onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="&#2309;&#2306;&#2340;&#2367;&#2350; &#2327;&#2339;&#2344;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Last Calculation Date">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtLdate" runat="server" Width="87px" CssClass="txtbox reqirerd" MaxLength="14" Text='<%#Eval ("datep")%>'></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txtLdate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                                   
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2350;&#2375;&#2306; &#2348;&#2367;&#2325;&#2381;&#2352;&#2368; &#2309;&#2351;&#2379;&#2327;&#2381;&#2351; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Untotal in Recieved Book">
                                                     <ItemTemplate>
                                                         <asp:TextBox ID="txtnotsell" runat="server" Width="87px" CssClass="txtbox reqirerd" MaxLength="6" Text='<%# Eval("TotalNotuseful_N") %>' onkeyup='javascript:tbx_fnSignedNumericCheck(this);' ></asp:TextBox> 
                                                     </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="&#2346;&#2352;&#2367;&#2357;&#2361;&#2344; &#2325;&#2366; &#2357;&#2381;&#2351;&#2351; ">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server" Width="80px" CssClass="txtbox reqirerd" MaxLength="6" onkeyup='javascript:tbx_fnSignedNumericCheck(this);' Text='<%# Eval("TotalCharge") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325;">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRemarkF" runat="server" TextMode="MultiLine"  Width="200px" CssClass="txtbox " MaxLength="200" Text='<%# Eval("BookwiseRemark") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr >
                                    <td >
                                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375; / From Date <span>*</span>
                                    </td>
                                    <td colspan="1" >
                                        <asp:TextBox ID="txtFrom" runat="server"  CssClass="txtbox reqirerd" ></asp:TextBox>
                                          <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom" Format="dd/MM/yyyy"> </cc1:CalendarExtender>
                                           

                                        </td>
                                    <td colspan="1" >
                                        &#2340;&#2325; / To Date <span>*</span></td>
                                    <td >
                                        <asp:TextBox ID="txtto" runat="server" CssClass="txtbox reqirerd" ></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtto" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
                                         
                                        </td>
                                </tr>
                                <tr >
                                    <td style="height: 32px; width: 94px;">
                                        &#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; / Remark
                                    </td>
                                    <td colspan="3" >
                                        <asp:TextBox ID="txtremark" runat="server" CssClass="txtbox" Height="51px" TextMode="MultiLine" onkeypress="MaxLengthCount('ContentPlaceHolder1_txtIns_CoverDetail_V',150);"
                                            Width="334px"></asp:TextBox>
                                    </td>
                                </tr>
        <tr >
            <td colspan="4" style="height: 23px">
                <asp:Button ID="Button1" CssClass="btn" runat="server" Text="&#2360;&#2375;&#2357; &#2325;&#2352;&#2375;&#2306; / Save" OnClick="Button1_Click" OnClientClick='javascript:return ValidateAllTextForm();'/>&nbsp;
            </td>
        </tr></div>
    </table>
                            
                            </div> </div> 
                             <script type="text/javascript" >

                                 function MaxLengthCount(txt, MaxLen) {
                                     var txtBox = document.getElementById(txt);
                                     var len = MaxLen;
                                     if (txtBox.value.length > len) {

                                         txtBox.value = txtBox.value.substring(0, len);
                                         alert("Character length is Exeed from " + len);
                                     }
                                     else { }
                                 }
          </script>
</asp:Content>

