<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="ViewPrintingProofInfo.aspx.cs" Inherits="Academic_ViewPrintingProofInfo"
    Title="&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2375; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2361;&#2375;&#2340;&#2369; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="portlet-header ui-widget-header">
        &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2375; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2361;&#2375;&#2340;&#2369; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;/ Printing Proof Status
    </div>
    <div class="box table-responsive">

        <div style="padding: 0 10px;">
            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
                <span id="tmpSpan"></span>
            </asp:Panel>
            <asp:Panel ID="pnlJob" runat="server">
                <table width="100%">
                  
                    <tr><td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year:</td><td align="left">
                        <asp:DropDownList ID="DdlACYear" Width="250px"  runat="server" CssClass="txtbox" AutoPostBack="true" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                        </asp:DropDownList>
                        </td><td></td></tr>
                    <tr><td>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; /  Tender Name:</td><td>
                        <asp:DropDownList ID="ddlTender" Width="250px"  runat="server" CssClass="txtbox" AutoPostBack="true" >
                        </asp:DropDownList>
                        </td><td></td></tr>
                      <tr>
                       
                        <td>&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Printer Name :
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlPrinter" Width="250px" CssClass="txtbox reqirerd" OnInit="ddlPrinter_Init">
                                <asp:ListItem Text="Select"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:GridView ID="grdJobList" OnRowEditing="grdJobList_OnRowEditing" class="tab"
                                AutoGenerateColumns="False" runat="server" OnSelectedIndexChanged="grdJobList_SelectedIndexChanged1">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/S.No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TenderNo_V" ReadOnly="true" HeaderText="TenderNo/TenderNo" />
                                    <asp:BoundField DataField="TenderType_V" ReadOnly="true" HeaderText="TenderType/TenderType" />

                                    <asp:BoundField DataField="Jobcode_V" ReadOnly="true" HeaderText="&#2332;&#2377;&#2348; &#2325;&#2379;&#2337;/Job Code" />
                                    <asp:BoundField DataField="ArgDate_D" ReadOnly="true" DataFormatString="{0:dd-MMM-yyyy}"
                                        HeaderText="&#2319;&#2327;&#2381;&#2352;&#2368;&#2350;&#2375;&#2306;&#2335; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Agreement Date" />
                                    <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Printer Name">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtWorkOrderID" Visible="false" MaxLength="30" Text='<%# Eval("WorkOrderID_I") %>'
                                                runat="server"></asp:TextBox>
                                            <asp:TextBox ID="txtPrinterName" Visible="false" MaxLength="30" Text='<%# Eval("nameofpress_v") %>'
                                                runat="server"></asp:TextBox>
                                            <asp:TextBox ID="txtPrinterID" Visible="false" MaxLength="30" Text='<%# Eval("Printer_RedID_I") %>'
                                                runat="server"></asp:TextBox>
                                            

                                            <asp:LinkButton ID="lnkPrinter"  CommandName="Edit" runat="server"><%# Eval("nameofpress_v")%></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="tblJobDetails" runat="server" Visible="false">
                <table class="tab01">
                    <tr style="font-weight: bold;">
                        <td> <asp:Button ID="BtnBack" runat="server" CssClass="btn" Text="&#2357;&#2366;&#2346;&#2367;&#2360; &#2332;&#2366;&#2319;&#2305; / Back" OnClick="BtnBack_Click1" /> </td>
                        <td runat="server">&#2332;&#2377;&#2348; &#2325;&#2379;&#2337;
                        / Job Code
                        </td>
                        <td runat="server">
                            <asp:Label ID="lblJobCode" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hdnWorkID" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnPrinterID" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnPrinterProofID" Value="0" runat="server" />
                        </td>
                        <td runat="server">&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;/ Printer Name</td>
                        <td runat="server">
                            <asp:Label ID="lblPrinterName" runat="server" Text=""></asp:Label>
                        </td>
                       
                    </tr>
                    <tr><td colspan="5"> &#2319;&#2327;&#2381;&#2352;&#2368;&#2350;&#2375;&#2306;&#2335; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Agreement Date :     <asp:Label ID="lblAgreementdate" Font-Bold="true" runat="server" Text=""></asp:Label></td></tr>
                </table>
                <table>
                    <tr>
                        <td colspan="4">
                            <%--  <div>

                                <asp:PlaceHolder ID="pnlJobTitles" runat="server"></asp:PlaceHolder>
                            </div>--%>
                             <table width="100%" class="tab">
    <tr>
				<th align="center" rowspan="2">&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No. </th><th align="center" rowspan="2">&#2325;&#2325;&#2381;&#2359;&#2366; / Class</th><th align="center" rowspan="2">&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title</th><th align="center" rowspan="2">&#2327;&#2381;&#2352;&#2369;&#2346; / Group</th><th align="center" colspan="2">&#2346;&#2366;&#2339;&#2381;&#2337;&#2369;&#2354;&#2367;&#2346;&#2367; &#2346;&#2381;&#2352;&#2342;&#2366;&#2344; /Provide CD Proof </th><th align="center" colspan="2"> &#2346;&#2381;&#2352;&#2370;&#2347; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; / Receive Proof</th><th align="center" colspan="2">  RSK/TBC &#2325;&#2379; &#2346;&#2381;&#2352;&#2370;&#2347; &#2349;&#2375;&#2332;&#2344;&#2366; / Send Proof to RSK/TBC</th><th align="center" colspan="2">  &#2346;&#2381;&#2352;&#2370;&#2347; &#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2344; / Proof Aprooval</th><th align="center" colspan="2"> &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2310;&#2342;&#2375;&#2358; &#2332;&#2366;&#2352;&#2368; &#2325;&#2352;&#2344;&#2366; / Issue Print Order</th><th align="center" colspan="2">&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2360;&#2366;&#2350;&#2366;&#2327;&#2381;&#2352;&#2368; &#2325;&#2368; &#2357;&#2366;&#2346;&#2360;&#2368; / Return of Printing Material</th><th align="center" rowspan="2">&#2309;&#2344;&#2381;&#2351; &#2357;&#2367;&#2357;&#2352;&#2339; / Other Details</th>
			</tr><tr>
				<th scope="col">&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No</th><th scope="col">&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date</th><th scope="col">&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No</th><th scope="col">&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date</th><th scope="col">&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No</th><th scope="col">&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date</th><th scope="col">&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No</th><th scope="col">&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date</th><th scope="col">&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No</th><th scope="col">&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date</th><th scope="col">&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No</th><th scope="col">&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date</th><th scope="col">Print</th>
			</tr>
       
	</table>
                                <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Width="103%" Height="300px" >
                            
                            <asp:GridView ID="grdJobDetails" AutoGenerateColumns="false" CssClass="tab" OnRowCreated="GrdViewDetails_Rowcreated"
                                OnRowEditing="grdJobDetails_RowEditing" CellPadding="0"  OnRowDataBound="GrdViewDetails_RowDataBound" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No." HeaderStyle-Width="10px" >
                                        <ItemTemplate >
                                            <%# Container.DataItemIndex+1 %>
                                             <asp:HiddenField ID="hdWorkNumber" Value= '<%# Eval("WorkOrderID_I") %>' runat="server"  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ReadOnly="true" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; / Class" DataField="Classdet_V" />
                                    <asp:BoundField ReadOnly="true" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title" DataField="TitleHindi_V" />
                                    <asp:BoundField ReadOnly="true" HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; / Group" DataField="groupno_v" />
                                    <%--1--------------------------------%>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtTitleID" Visible="false" Text='<%# Eval("TitleID_I") %>' runat="server"></asp:TextBox>
                                            <asp:TextBox ID="txtCDProofLetterNo" Width="60px"  MaxLength="12" Text='<%# Eval("CDProofLetterNo_V") %>' runat="server"></asp:TextBox>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCDProofLetterDate" Width="60px"  MaxLength="12" Text='<%# Eval("CDProofLetterDate_D").ToString()=="" ? "" : Convert.ToDateTime(Eval("CDProofLetterDate_D").ToString()).ToString("dd/MM/yyyy") %>' runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="ccextendTxtLetterDate" TargetControlID="txtCDProofLetterDate"
                                                Format="dd/MM/yyyy" runat="server">
                                            </cc1:CalendarExtender>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-----------------2------------------%>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCDProofRetLetterNo" Width="60px"  MaxLength="12" Text='<%# Eval("CDProofRetLetterNo_V") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCDProofRetLetterDate" Width="60px" MaxLength="12" Text='<%# Eval("CDProofRetLetterDate_D").ToString()=="" ? "" : Convert.ToDateTime(Eval("CDProofRetLetterDate_D").ToString()).ToString("dd/MM/yyyy") %>' runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="ccextendtxtCDProofRetLetterDate" TargetControlID="txtCDProofRetLetterDate"
                                                Format="dd/MM/yyyy" runat="server">
                                            </cc1:CalendarExtender>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%------------3-----------------------%>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDepSendProofLetterNo" MaxLength="12" Width="60px" Text='<%# Eval("DepSendProofLetterNo_V") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDepSendProofLetterDate" MaxLength="12" Width="60px"  Text='<%# Eval("DepSendProofLetterDate_D").ToString()=="" ? "" : Convert.ToDateTime(Eval("DepSendProofLetterDate_D").ToString()).ToString("dd/MM/yyyy") %>' runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="ccextendtxtDepSendProofLetterDate" TargetControlID="txtDepSendProofLetterDate"
                                                Format="dd/MM/yyyy" runat="server">
                                            </cc1:CalendarExtender>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-------------------4----------------%>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtProofAcceptLetterNo" Width="60px"  MaxLength="12" Text='<%# Eval("ProofAcceptLetterNo_V") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtProofAcceptLetterDate" Width="60px"  MaxLength="12" Text='<%# Eval("ProofAcceptLetterDate_D").ToString()=="" ? "" : Convert.ToDateTime(Eval("ProofAcceptLetterDate_D").ToString()).ToString("dd/MM/yyyy") %>' runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="ccextendtxtProofAcceptLetterDate" TargetControlID="txtProofAcceptLetterDate"
                                                Format="dd/MM/yyyy" runat="server">
                                            </cc1:CalendarExtender>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%----------5------------------------%>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPrintOrderLetterNo" Width="60px"  MaxLength="12" Text='<%# Eval("PrintOrderLetterNo_V") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPrintOrderLetterDate" Width="60px"  MaxLength="12" Text='<%# Eval("PrintOrderLetterDate_D").ToString()=="" ? "" : Convert.ToDateTime(Eval("PrintOrderLetterDate_D").ToString()).ToString("dd/MM/yyyy") %>' runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="ccetxtPrintOrderLetterDate" TargetControlID="txtPrintOrderLetterDate"
                                                Format="dd/MM/yyyy" runat="server">
                                            </cc1:CalendarExtender>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%----------6-------------------------%>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Letter No">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRetProofLetterNo" Width="60px"  MaxLength="12" Text='<%# Eval("RetProofLetterNo_V") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Letter Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRetProofLetterDate" Width="60px"  MaxLength="12" Text='<%# Eval("RetProofLetterDate_D").ToString()=="" ? "" : Convert.ToDateTime(Eval("RetProofLetterDate_D").ToString()).ToString("dd/MM/yyyy") %>' runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="ccextendtxtRetProofLetterDate" TargetControlID="txtRetProofLetterDate"
                                                Format="dd/MM/yyyy" runat="server">
                                            </cc1:CalendarExtender>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-----------------------------------%>
                                    <asp:TemplateField HeaderText="Detail">
                                        <ItemTemplate>
                                            <asp:Button CommandName="Edit" CssClass="btn" Width="120px"  runat="server" ID="btnDetail" Text="&#2357;&#2367;&#2357;&#2352;&#2339; / Details" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Print">
                                        <ItemTemplate>
                                            <a href="PrinCdLetter.aspx?TitleID='<%#Eval("TitleID_I")%>'&WorkID='<%# Eval("WorkOrderID_I") %>'&Yeara=<%=DdlACYear.SelectedValue %>" target="_blank" >Print Cd Letter</a><br /><br />
                                              <a href="ProfLetter.aspx?TitleID='<%#Eval("TitleID_I")%>'&WorkID='<%# Eval("WorkOrderID_I") %>'&Yeara=<%=DdlACYear.SelectedValue %>" target="_blank" >Print Proof to RSK/TBC</a> <br /> <br />
                                            <a href="PrinterLetter.aspx?TitleID='<%#Eval("TitleID_I")%>'&WorkID='<%# Eval("WorkOrderID_I") %>'&Yeara=<%=DdlACYear.SelectedValue %>" target="_blank" > &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2310;&#2342;&#2375;&#2358;</a><br /> <br />
                                        <a href="PrintingReturn.aspx?TitleID='<%#Eval("TitleID_I")%>'&WorkID='<%# Eval("WorkOrderID_I") %>'&Yeara=<%=DdlACYear.SelectedValue %>" target="_blank" > &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2360;&#2366;&#2350;&#2366;&#2327;&#2381;&#2352;&#2368; &#2325;&#2368; &#2357;&#2366;&#2346;&#2360;&#2368; </a><br /> <br />

                                             <a href="PrintDetails.aspx?TitleID='<%#Eval("Printer_RedID_I")%>'&WorkID='<%# Eval("WorkOrderID_I") %>'&Yeara='<%=DdlACYear.SelectedValue %>'" target="_blank" >&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2310;&#2352;&#2381;&#2337;&#2352; &#2337;&#2367;&#2335;&#2375;&#2354;&#2381;&#2360;  </a><br /> <br />
                                        
                                        </ItemTemplate> </asp:TemplateField> 

                                </Columns>
                            </asp:GridView></asp:Panel>
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
            <table width="100%" class="tab">
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
                        <asp:DropDownList ID="ddlStatus" CssClass="txtbox" runat="server">
                        </asp:DropDownList>
                        <input type="hidden" runat="server" id="hdnTitleID" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtPopupLetterNo" MaxLength="6" Width="55px" CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPopupLetterDate" MaxLength="12" Width="110px" CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="ccextendTxtPopupLetterDate" TargetControlID="txtPopupLetterDate"
                            Format="dd/MM/yyyy" runat="server">
                        </cc1:CalendarExtender>
                        
                    </td>
                    <td>
                        <asp:TextBox ID="txtPopupRemark" MaxLength="30" CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <%-- <input type="button" id="btnSaveOtherDetails1" value="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" class="btn" onclick="return SaveOtherDetails()" />--%>
                        <asp:Button ID="btnSaveOtherDetails" runat="server" CssClass="btn" OnClientClick='javascript:return ValidateAllTextForm1();' Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" OnClick="btnSaveOtherDetails_Click" />
                    </td>
                </tr>
            </table>
            <%--  <div id="divOtherDetails" runat="server">
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
