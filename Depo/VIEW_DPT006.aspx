<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW_DPT006.aspx.cs" Inherits="Depo_VIEW_DPT006" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&#2319;&#2337;&#2357;&#2366;&#2306;&#2360; &#2346;&#2340;&#2381;&#2352;&#2325; / Advance Report</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; / New Data"   
                            onclick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;. / No.">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1%>
                </ItemTemplate>
            </asp:TemplateField>

                                  <asp:TemplateField HeaderText="&#2350;&#2366;&#2361;">
                <ItemTemplate>
                 
                    <asp:LinkButton OnClick="lnkClick" runat="server"  CommandArgument='<%#Eval("AdvanceDetailsID")%>'  Text='<%#Eval("Quartera")%>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

                                <asp:BoundField HeaderText="&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; " DataField="FyYear" />
                                 
                                <asp:BoundField HeaderText="&#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " DataField="Ddate_D1" />
                                <asp:BoundField HeaderText="&#2350;&#2366;&#2306;&#2327; " DataField="Amount" />
                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351;" DataField="PradayAmount" />
                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " DataField="PradayDate" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">

                        
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
      <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Messages" style="display: none;" class="popupnew1" runat="server" >
                  <asp:Button ID="Button1" runat="server" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375; " CssClass="btn"  onclick="Button1_Click" />
                        <asp:GridView ID="GrdAdvanceDetails" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="AdvanceDetailsID" 
                            
                             AllowPaging="false" 
                            onpageindexchanging="GrdAdvanceDetails_PageIndexChanging" 
                            onrowcommand="GrdAdvanceDetails_RowCommand">
                            <Columns> 
                                <asp:BoundField HeaderText="&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year" DataField="FyYear" />
                             <asp:BoundField HeaderText="&#2350;&#2342; &#2325;&#2366; &#2344;&#2366;&#2350; / Name Of Item" DataField="HeadName_V" />
                             <asp:BoundField HeaderText="&#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2325;&#2366; &#2350;&#2366;&#2361; " DataField="Quartera" />
                                <asp:BoundField HeaderText="&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Date" DataField="Ddate_D1" /> 
                                 <asp:BoundField HeaderText="&#2309;&#2344;&#2369;&#2350;&#2366;&#2344;&#2367;&#2340; &#2352;&#2366;&#2358;&#2367; / Amount" DataField="Amount" /> 
                                  <asp:BoundField HeaderText="&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2325;&#2368; &#2327;&#2312; &#2352;&#2366;&#2358;&#2367; " DataField="PradayAmount" /> 
                                                                
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;/ Edit">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("AdvanceDetailsID") %>' />
                                    
                                       <asp:LinkButton ID="LinkButton1" visible='<%# Eval("Status").ToString()=="1" ? false  : true %>' runat="server" OnCommand='<%#Eval("AdvanceDetailsID").ToString() %>' OnClick="btnClick">&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 
                                
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                </div> 
</asp:Content>

