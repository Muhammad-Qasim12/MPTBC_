<%@ Page Title="&#2346;&#2375;&#2346;&#2352; &#2310;&#2357;&#2306;&#2335;&#2344;
                    &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;  / Paper Allotment Details"
    Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="View_PaperAllotmentReturn.aspx.cs" Inherits="View_PaperAllotmentReturn" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>
                    <%--Paper Allotment Detail--%>&#2346;&#2375;&#2346;&#2352; वापसी

                     &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;  / Paper Return Details</span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
        
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lblAcyear" runat="server" Visible="false"></asp:Label>

                    </td>
                </tr>
 
           
                <tr runat="server">
                    <td colspan="4">
                        <asp:GridView ID="GrdPaperAllotment" runat="server" AutoGenerateColumns="False" CssClass="tab"  ShowFooter="True">
                            <Columns>
                                <asp:BoundField DataField="AcYear" HeaderText="&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; / Academic Year" />
                                <asp:BoundField DataField="NameofPress_V" HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Printer Name" />
                                <asp:BoundField DataField="CoverInformation" HeaderText="Cover Information" />
                                <asp:BoundField DataField="PaperType" HeaderText="Paper Type" />
                                <asp:BoundField DataField="OrderNo" HeaderText="&#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352;  / Order No" />
                                <asp:BoundField DataField="ReternTo" HeaderText="ReternTo" />
                                <asp:BoundField DataField="IssueTo" HeaderText="IssueTo" />
                                <asp:BoundField DataField="NoOfReels" HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2346;&#2375;&#2346;&#2352;  / Printing Paper(Tons)" />
                                <asp:BoundField DataField="NetWt" HeaderText="&#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352;  / Coverpaper Sheet" />
                                 <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnPrinterDisTranId" runat="server" Value='<%#Eval("PrinterDisTranId")%>' />
                                            <asp:Panel ID="pnupdate221" runat="server" Visible='<%#(Eval("UpdateStatus").ToString().Equals("Send to central depot"))?true:false%>'>
                                                <asp:LinkButton ID="lnkChangeSts" runat="server" CausesValidation="false" OnClick="lnkChangeSts_Click" Text='<%#Eval("UpdateStatus") %>' OnClientClick="return confirm('Are you sure to sent this record to Central Depo ?');"></asp:LinkButton>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel1" runat="server" Visible='<%#(Eval("UpdateStatus").ToString().Equals("Send to central depot")|| Eval("UpdateStatus").ToString().Equals("Return paper"))?false:true%>'>
                                                <%#Eval("UpdateStatus") %>
                                            </asp:Panel>
                                             <asp:Panel ID="pnupdate1" runat="server" Visible='<%#(Eval("UpdateStatus").ToString().Equals("Return paper"))?true:false%>'>
                                                <a href="PaperReturnDispatch.aspx">कागज वापसी</a>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>

                </tr>
                
              
                <tr>
                    <td colspan="4"></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
