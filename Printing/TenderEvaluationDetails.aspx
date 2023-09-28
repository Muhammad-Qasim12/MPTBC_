<%@ Page Title="&#2335;&#2375;&#2337;&#2352; &#2350;&#2375;&#2306; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2349;&#2366;&#2327; &#2354;&#2375;&#2344;&#2375;&#2357;&#2366;&#2354;&#2375; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375;&#2306; / Tender Participant Detail" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TenderEvaluationDetails.aspx.cs" Inherits="Printing_TenderDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div   class="box table-responsive"> 
        <div class="card-header">
            <h2>
                <span>&#2335;&#2375;&#2337;&#2352; &#2350;&#2375;&#2306; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2349;&#2366;&#2327; &#2354;&#2375;&#2344;&#2375;&#2357;&#2366;&#2354;&#2375; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375;&#2306; / Tender Participant Detail</span>
            </h2>
        </div>
        <div id="messageDiv" runat="server" class="form-message" style="display: none;">
        </div>
        <div style="padding: 0 10px;">
                                    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="LUN &#2325;&#2368; &#2354;&#2367;&#2360;&#2381;&#2335; &#2360;&#2375; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2379; &#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2366; &#2310;&#2357;&#2306;&#2335;&#2344; &#2325;&#2352;&#2375;&nbsp;" OnClick="Button1_Click"
                            />
                        
            <fieldset>
                <legend>&#2335;&#2375;&#2306;&#2337;&#2352; &#2350;&#2375;&#2306; &#2310;&#2344;&#2375; &#2357;&#2366;&#2354;&#2375; &#2327;&#2381;&#2352;&#2369;&#2346; &#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335; &#2325;&#2352;&#2375;&#2306; / Select Group</legend>
                <table width="100%">
                    <tr>
                        <td style="text-align: center">
                            <asp:GridView ID="GrdGroupDetails" runat="server" AutoGenerateColumns="False" CssClass="tab hashtable"
                                DataKeyNames="GrpID_I" OnRowDataBound="GrdGroupDetails_RowDataBound" OnSelectedIndexChanged="GrdGroupDetails_SelectedIndexChanged"
                                OnRowUpdating="GrdGroupDetails_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                            <asp:HiddenField ID="HdnGRP" runat="server" Value='<%# Eval("GrpID_I") %>' />
                                            <asp:HiddenField ID="HDNTenID" runat="server" Value='<%# Eval("Tenderid_I") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; / Group name  (1)">
                                      
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblGroupNO_V" runat="server" Text='<%#Eval("GroupNO_V") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField HeaderText="&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;" DataField="GroupNO_V" />--%>
                                    <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; / Title  (2) ">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cLASSDET_V" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; / Class  (3)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Pages_n" HeaderText="&#2346;&#2375;&#2332;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No of Pages  (4)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="noofBookYojna" HeaderText="&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2351;&#2379;&#2332;&#2344;&#2366; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Allotment Scheme (in no)   (5)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="noofBookSamana" HeaderText="&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /  Allotment General (in no)  (6)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="totnoofbooks" HeaderText="&#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2344; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Total no of Allotment  (7)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="qty_pripaper" HeaderText="&#2354;&#2327;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2346;&#2375;&#2346;&#2352; (&#2335;&#2344; &#2350;&#2375; ) / Printing paper (in Ton)  (8)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="qty_Covpaper" HeaderText="&#2354;&#2327;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; (&#2358;&#2368;&#2335; &#2350;&#2375; ) / Cover paper (in Sheet)  (9)"      >
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        
                                    </asp:BoundField>
                                    <%-- 
                                <asp:BoundField HeaderText="&#2337;&#2367;&#2346;&#2379;" DataField="DepoID_I" />
                                         <asp:BoundField DataField="" HeaderText="&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2351;&#2379;&#2332;&#2344;&#2366;">     <asp:BoundField HeaderText="&#2325;&#2376;&#2335;&#2375;&#2327;&#2352;&#2368;" DataField="PrintingCategory_V"/>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    --%>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <div id="fadeDiv" runat="server" class="modalBackground" style="display: none">
                </div>
                <div id="Messages" style="display: none; width: 50%; left: 25%; top: 10px;" class="popupnew"
                    runat="server">
                    <asp:Panel runat="server" ID="PnlPop" ScrollBars="Auto" Height="800px">
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="GrdPrinter" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                        <Columns>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1 %></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="&#2357;&#2367;&#2359;&#2351;" DataField="nameofpress_v" />
                                            <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2325;&#2376;&#2346;&#2375;&#2360;&#2367;&#2335;&#2368; (&#2335;&#2344; &#2350;&#2375;&#2306;)"
                                                DataField="CapTwoColor" />
                                            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2335;&#2367;&#2306;&#2327; &#2342;&#2352;">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRate" runat="server" Width="106px" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                                                        MaxLength="8" Text='<%# Eval("RateQuoated_N") %>'></asp:TextBox>
                                                    <asp:HiddenField ID="HdnPrinterID" runat="server" Value='<%# Eval("PrinterID_I") %>' />
                                                    <asp:HiddenField ID="HdnTenEval" runat="server" Value='<%# Eval("TenEvalID_I") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnSavePrinter" Enabled="false" runat="server" CssClass="btn" OnClick="btnSavePrinter_Click"
                                        Text="&#2360;&#2375;&#2357; / Save" />
                                    <asp:Button ID="ButClose" runat="server" CssClass="btn" OnClick="ButClose_Click"
                                        Text=" &#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2351;&#2375; " />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </fieldset>
            <table width="100%">
                <tr>
                    <td style="text-align: center">
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="HiddenField3" runat="server" />
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save "
                            OnClientClick='javascript:return ValidateAllTextForm();' OnClick="btnSave_Click" Visible="False" />
                        <asp:Button runat="server" ID="BtnLOI" Text="Generate LOI" CssClass="btn" OnClick="BtnLOI_Click"
                            Enabled="False" Visible="False" />
                        <asp:Button runat="server" ID="btnViewLOI" Text="LOI &#2342;&#2375;&#2326;&#2375; / Show LOI"
                            CssClass="btn" OnClick="btnViewLOI_Click" />
                    </td>
                </tr>
            </table>
            <div>
              <div id="dIVaLLOTEDtENDER" style="display: none; width: 50%; left: 25%; top: 10px;"
                    class="popupnew" runat="server">
                    <asp:Button runat="server" ID="ButClose2" Text="Close" CssClass="btn" OnClick="ButClose2_Click" />
                    <asp:Panel runat="server" ID="Panel1" ScrollBars="Auto" Height="800px">
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="gRDaLLOTEDtENDER" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                        <Columns>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1 %></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="groupno_v" />
                                            <asp:BoundField DataField="titlename" />
                                            <asp:BoundField DataField="Qty_priPaper" />
                                            <asp:BoundField DataField="nameofpress_v" />
                                            <asp:BoundField DataField="Ratequoated_n" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div> 
                <div id="dIVLOI" style="display: none; width: 50%; left: 25%; top: 10px;" class="popupnew"
                    runat="server">
                    <asp:Button runat="server" ID="butclose1" Text="Close" CssClass="btn" OnClick="butclose1_Click" />
                    <asp:Panel runat="server" ID="Panel2" ScrollBars="Auto" Height="800px">
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="GRVLOI" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                        <Columns>
                                            <asp:BoundField HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346;" DataField="Groupno_V" />
                                            <asp:BoundField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; " DataField="titlename" />
                                            <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352; "
                                                DataField="Qty_pripaper" />
                                            <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; "
                                                DataField="nameofpress_v" />
                                            <asp:BoundField HeaderText="&#2352;&#2375;&#2335;" DataField="Ratequoated_n" />
                                        </Columns>
                                         <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
