<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewPrinterProof.aspx.cs" Inherits="AcademicB_ViewPrinterProof"
    Title="&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2325;&#2375; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2361;&#2375;&#2340;&#2369; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        &#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2325;&#2375; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2361;&#2375;&#2340;&#2369; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; / Printing Proof Status of Other then TextBook
       
    </div>
    <div class="box table-responsive">
         <table><tr><td>&#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; </td><td>       <asp:DropDownList ID="ddlPrinter_regid_i" runat="server"
                            CssClass="txtbox reqirerd"
                            OnSelectedIndexChanged="ddlPrinter_regid_i_SelectedIndexChanged"
                            AutoPostBack="true"  >
                        </asp:DropDownList></td></tr></table> 
        <div style="padding: 0 10px;">
            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px; padding-left:40px;">

                <span id="tmpSpan"> </span>
               <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlJob" runat="server">
                <asp:GridView ID="grdJobList" OnRowEditing="grdJobList_OnRowEditing" class="tab"
                    AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Jobcode_V" ReadOnly="true" HeaderText="&#2332;&#2377;&#2348; &#2325;&#2379;&#2337; / Job code" />
                        <asp:BoundField DataField="ArgDate_D" ReadOnly="true" DataFormatString="{0:dd-MMM-yyyy}"
                            HeaderText="&#2319;&#2327;&#2381;&#2352;&#2368;&#2350;&#2375;&#2306;&#2335; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Agreement Date " />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:TextBox ID="txtWorkOrderID" Visible="false" MaxLength="30" Text='<%# Eval("WorkOrderID_I") %>'
                                    runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtPrinterName" Visible="false" MaxLength="30" Text='<%# Eval("nameofpress_v") %>'
                                    runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtPrinterID" Visible="false" MaxLength="30" Text='<%# Eval("Printer_RedID_I") %>'
                                    runat="server"></asp:TextBox>
                                <asp:LinkButton ID="lnkPrinter" CommandName="Edit" runat="server"><%# Eval("nameofpress_v")%></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="tblJobDetails" runat="server" Visible="false">
                <table class="tab01">
                    <tr style="font-weight: bold;">
                        <td runat="server">&#2332;&#2377;&#2348; &#2325;&#2379;&#2337; / Job Code
                        </td>
                        <td runat="server">
                            <asp:Label ID="lblJobCode" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hdnWorkID" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnPrinterID" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnPrinterProofID" Value="0" runat="server" />
                        </td>
                        <td runat="server">&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Printer
                        </td>
                        <td runat="server">
                            <asp:Label ID="lblPrinterName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td colspan="4" runat="server">
                            <%-- <div style="overflow: scroll; width: 1190px">
                            <asp:PlaceHolder ID="pnlJobTitles" runat="server"></asp:PlaceHolder>
                        </div>--%>
                            <asp:GridView ID="grdJobDetails" AutoGenerateColumns="false" CssClass="tab" OnRowCreated="grdJobDetails_RowCreated"
                                OnRowEditing="grdJobDetails_RowEditing" OnRowDataBound="grdJobDetails_RowDataBound" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ReadOnly="true" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; / Class" Visible="false" DataField="groupno_v" />
                                    <asp:BoundField ReadOnly="true" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title" DataField="TitleHindi_V" />
                                    <asp:BoundField ReadOnly="true" HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; / Group" DataField="groupno_v" />
                                    <%--1--------------------------------%>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtTitleID" Visible="false" Text='<%# Eval("SubTitleID_I") %>' runat="server"></asp:TextBox>
                                            <asp:TextBox ID="txtCDProofLetterNo" Width="80px" Enabled='<%#  Eval("CDProofLetterNo_V").ToString() == "" ? true : false %>' MaxLength="12" Text='<%# Eval("CDProofLetterNo_V") %>' runat="server"></asp:TextBox>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCDProofLetterDate" Width="80px"     Enabled='<%#  Eval("CDProofLetterDate_D").ToString() == "" ? true : false %>' MaxLength="12" Text='<%# Eval("CDProofLetterDate_D").ToString()=="" ? "" : Convert.ToDateTime(Eval("CDProofLetterDate_D").ToString()).ToString("dd/MM/yyyy") %>' runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="ccextendTxtLetterDate" TargetControlID="txtCDProofLetterDate"
                                                Format="dd/MM/yyyy" runat="server">
                                            </cc1:CalendarExtender>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-----------------2------------------%>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCDProofRetLetterNo"  Width="80px"  Enabled='<%#  Eval("CDProofRetLetterNo_V").ToString() == "" ? true : false %>' MaxLength="12" Text='<%# Eval("CDProofRetLetterNo_V") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCDProofRetLetterDate"  Width="80px"  Enabled='<%#  Eval("CDProofRetLetterDate_D").ToString() == "" ? true : false %>' MaxLength="12" Text='<%# Eval("CDProofRetLetterDate_D").ToString()=="" ? "" : Convert.ToDateTime(Eval("CDProofRetLetterDate_D").ToString()).ToString("dd/MM/yyyy") %>' runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="ccextendtxtCDProofRetLetterDate" TargetControlID="txtCDProofRetLetterDate"
                                                Format="dd/MM/yyyy" runat="server">
                                            </cc1:CalendarExtender>
                                         
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%------------3-----------------------%>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDepSendProofLetterNo" MaxLength="12"  Width="80px"  Enabled='<%#  Eval("DepSendProofLetterNo_V").ToString() == "" ? true : false %>' Text='<%# Eval("DepSendProofLetterNo_V") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDepSendProofLetterDate" MaxLength="12"  Width="80px"  Enabled='<%#  Eval("DepSendProofLetterDate_D").ToString() == "" ? true : false %>' Text='<%# Eval("DepSendProofLetterDate_D").ToString()=="" ? "" : Convert.ToDateTime(Eval("DepSendProofLetterDate_D").ToString()).ToString("dd/MM/yyyy") %>' runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="ccextendtxtDepSendProofLetterDate" TargetControlID="txtDepSendProofLetterDate"
                                                Format="dd/MM/yyyy" runat="server">
                                            </cc1:CalendarExtender>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                      


                                    <%-------------------4----------------%>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtProofAcceptLetterNo"  Width="80px"  Enabled='<%#  Eval("ProofAcceptLetterNo_V").ToString() == "" ? true : false %>' MaxLength="12" Text='<%# Eval("ProofAcceptLetterNo_V") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtProofAcceptLetterDate"  Width="80px"  Enabled='<%#  Eval("ProofAcceptLetterDate_D").ToString() == "" ? true : false %>' MaxLength="12" Text='<%# Eval("ProofAcceptLetterDate_D").ToString()=="" ? "" : Convert.ToDateTime(Eval("ProofAcceptLetterDate_D").ToString()).ToString("dd/MM/yyyy") %>' runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="ccextendtxtProofAcceptLetterDate" TargetControlID="txtProofAcceptLetterDate"
                                                Format="dd/MM/yyyy" runat="server">
                                            </cc1:CalendarExtender>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                  


                                    <%----------5------------------------%>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPrintOrderLetterNo"  Width="80px"  Enabled='<%#  Eval("PrintOrderLetterNo_V").ToString() == "" ? true : false %>' MaxLength="12" Text='<%# Eval("PrintOrderLetterNo_V") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPrintOrderLetterDate"  Width="80px"  Enabled='<%#  Eval("PrintOrderLetterDate_D").ToString() == "" ? true : false %>' MaxLength="12" Text='<%# Eval("PrintOrderLetterDate_D").ToString()=="" ? "" : Convert.ToDateTime(Eval("PrintOrderLetterDate_D").ToString()).ToString("dd/MM/yyyy") %>' runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="ccetxtPrintOrderLetterDate" TargetControlID="txtPrintOrderLetterDate"
                                                Format="dd/MM/yyyy" runat="server">
                                            </cc1:CalendarExtender>
                                         
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%----------6-------------------------%>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRetProofLetterNo"  Width="80px"  Enabled='<%#  Eval("RetProofLetterNo_V").ToString() == "" ? true : false %>' MaxLength="12" Text='<%# Eval("RetProofLetterNo_V") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRetProofLetterDate"  Width="80px"  Enabled='<%#  Eval("RetProofLetterDate_D").ToString() == "" ? true : false %>' MaxLength="12" Text='<%# Eval("RetProofLetterDate_D").ToString()=="" ? "" : Convert.ToDateTime(Eval("RetProofLetterDate_D").ToString()).ToString("dd/MM/yyyy") %>' runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="ccextendtxtRetProofLetterDate" TargetControlID="txtRetProofLetterDate"
                                                Format="dd/MM/yyyy" runat="server">
                                            </cc1:CalendarExtender>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                   



                                    <%-----------------------------------%>
                                    <asp:TemplateField HeaderText="Detail">
                                        <ItemTemplate>
                                            <asp:Button CommandName="Edit" CssClass="btn" runat="server" ID="btnDetail" Text="&#2357;&#2367;&#2357;&#2352;&#2339; / Details" />
                                        </ItemTemplate>
                                    </asp:TemplateField>




                                      <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ 50% Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtProofAcceptLetterDate50"  Width="80px"  Enabled='<%#  Eval("ProofAcceptLetterDate_D50").ToString() == "" ? true : false %>' MaxLength="12" Text='<%# Eval("ProofAcceptLetterDate_D50").ToString()=="" ? "" : Convert.ToDateTime(Eval("ProofAcceptLetterDate_D50").ToString()).ToString("dd/MM/yyyy") %>' runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="ccextendtxtProofAcceptLetterDate50" TargetControlID="txtProofAcceptLetterDate50"
                                                Format="dd/MM/yyyy" runat="server">
                                            </cc1:CalendarExtender>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ 100% Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtProofAcceptLetterDate100"  Width="80px"  Enabled='<%#  Eval("ProofAcceptLetterDate_D100").ToString() == "" ? true : false %>' MaxLength="12" Text='<%# Eval("ProofAcceptLetterDate_D100").ToString()=="" ? "" : Convert.ToDateTime(Eval("ProofAcceptLetterDate_D100").ToString()).ToString("dd/MM/yyyy") %>' runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="ccextendtxtProofAcceptLetterDate100" TargetControlID="txtProofAcceptLetterDate100"
                                                Format="dd/MM/yyyy" runat="server">
                                            </cc1:CalendarExtender>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnSave" CssClass="btn" runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" OnClick="btnSave_Click" />
                        </td>
                        <td colspan="2">
                            <asp:Button ID="btnClose" CssClass="btn" runat="server" Visible="false" Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2319;&#2306;"
                                OnClick="btnClose_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="Messages" style="display: none;" class="popupnew1" runat="server">
        <h2></h2>
        <h4></h4>
        <table width="100%" class="tab">
            <asp:Panel class="form-message error" runat="server" ID="pnlPopupMessage" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblPopupMessage" class="notification" runat="server"></asp:Label>
            </asp:Panel>
            <tr>
                <th>&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Printer Name
                </th>
                <th>
                    <asp:Label ID="lblPopupPrinterName" runat="server"></asp:Label>

                </th>
                <th>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; / Title
                </th>
                <th>
                    <asp:Label ID="lblPopupTitle" runat="server"></asp:Label>
                </th>
            </tr>
        </table>
        <div>
            <table class="tab">
                <tr>
                    <th>&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;  / Status 
                    </th>
                    <th>&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Letter No 
                    </th>
                    <th>&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Letter Date
                    </th>
                    <th>&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; / Remark
                    </th>
                    <th></th>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlStatus" CssClass="txtbox" runat="server"></asp:DropDownList>
                        <input type="hidden" runat="server" id="hdnTitleID" />

                    </td>
                    <td>
                        <asp:TextBox ID="txtPopupLetterNo" MaxLength="12" Width="55px" CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPopupLetterDate" MaxLength="12" Width="110px" CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="ccextendTxtPopupLetterDate" TargetControlID="txtPopupLetterDate"
                            Format="dd/MM/yyyy" runat="server">
                        </cc1:CalendarExtender>
                       
                    </td>
                    <td>
                        <asp:TextBox ID="txtPopupRemark" MaxLength="15" CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%--  <input type="button" id="btnSaveOtherDetails" value="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" class="btn" onclick="return SaveOtherDetails()" />--%>
                        <asp:Button ID="btnSaveOtherDetails" runat="server" CssClass="btn" OnClientClick='javascript:return ValidateAllTextForm1();' Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" OnClick="btnSaveOtherDetails_Click" />

                    </td>
                </tr>
            </table>
            <%-- <div id="divOtherDetails" runat="server">
            </div>--%>
            <asp:GridView ID="grdOtherDetails" AutoGenerateColumns="false" OnRowDeleting="grdOtherDetails_RowDeleting" CssClass="tab" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="LetterNo_V" ReadOnly="true" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Letter No" />
                    <asp:BoundField DataField="LetterDate_D" DataFormatString="{0: dd/MM/yyyy}" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Letter Date" />
                    <asp:BoundField DataField="Status_V" HeaderText="&#2309;&#2344;&#2381;&#2351; &#2357;&#2367;&#2357;&#2352;&#2339; / Other Status" />
                    <asp:BoundField DataField="Remark_V" HeaderText="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; / Remark" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblPrinterProofVerificationOtherDetailsTrno" Visible="false" runat="server" Text='<%# Eval("PrinterProofVerificationOtherDetailsTrno_I") %>'></asp:Label>
                            <asp:Button ID="btnDelete" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" CommandName="delete" CssClass="btn" runat="server" Text="&#2361;&#2335;&#2366;&#2319;&#2306; / Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <%--  <input type="button" onclick="ClosePopUp()" class="btn" value="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306;" />--%>
            <asp:Button ID="btnClosePopUp" runat="server" CssClass="btn" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306;" CausesValidation="false" OnClick="btnClosePopUp_Click" />

        </div>
    </div>
</asp:Content>
