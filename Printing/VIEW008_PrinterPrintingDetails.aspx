<%@ Page Title="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2375; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW008_PrinterPrintingDetails.aspx.cs" Inherits="Printing_VIEW008_PrinterPrintingDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:Panel ID="messDiv" runat="server">
        <asp:Label runat="server" ID="lblMess" class="notification"></asp:Label>
    </asp:Panel>

    <div class="portlet-header ui-widget-header">&#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2325;&#2368; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2325;&#2368; &#2342;&#2376;&#2344;&#2367;&#2325; &#2346;&#2381;&#2352;&#2327;&#2340;&#2367; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Daily Progress Report of Printer </div>
    <div class="portlet-content">
        <div class="box table-responsive">
            <table Width="100%" id="tblShowDetails" runat="server">
                <tr>
                    
                    <td  colspan="2" align="right">
                        <asp:LinkButton ID="lnkSave" runat="server" CausesValidation="false" Text="New Entry" CssClass="btn" OnClick="lnkSave_Click"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Panel runat="server" ID="pnlShowData">

                            <asp:GridView runat="server" ID="gvShowDetails" AutoGenerateColumns="false"
                                 CssClass="tab" Width="100%" OnRowDataBound="gvShowDetails_RowDataBound" OnPageIndexChanging="gvShowDetails_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;. / SNo">

                                        <ItemTemplate>

                                            <%# Container.DataItemIndex +1 %> 
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2342;&#2376;&#2344;&#2367;&#2325; &#2346;&#2381;&#2352;&#2327;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;  / Daily Progress Date">

                                        <ItemTemplate>
                                          <asp:Label id="lblTranDate" runat= "server" Text='<%# Eval("Transdate_D") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="&#2342;&#2376;&#2344;&#2367;&#2325; &#2346;&#2381;&#2352;&#2327;&#2340;&#2367; &#2360;&#2381;&#2340;&#2352; / Status Of Daily Progress">

                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSend" runat="server" CausesValidation="false" Text="Send To Head Office" OnClick ="lnkSend_Click"></asp:LinkButton>
                                            <asp:Label id="lblSend" runat= "server"  ></asp:Label>
                                            <asp:Label id="lblSendSts" runat= "server" Text='<%# Eval("SendSts") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;/ Edit">

                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" Text="Edit" OnClick="lnkEdit_Click"></asp:LinkButton>

                                        </ItemTemplate>

                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />

                            </asp:GridView>



                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table id="tblEntry" runat="server" visible="false">
                <tr>
                    <td>
                        <asp:Label ID="LblAcYear" runat="server" Width="180px">शिक्षा सत्र <br /> Academic Year:</asp:Label>
                        <asp:DropDownList ID="DdlACYear" runat="server" AutoPostBack="True" CssClass="txtbox" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                        </asp:DropDownList>
&nbsp;&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Date <asp:TextBox runat="server" ID="txtDate" AutoPostBack="true" OnTextChanged="txtDate_TextChanged" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender runat="server" ID="calDate" Format="dd/MM/yyyy" TargetControlID="txtDate"></cc1:CalendarExtender></td>
                    <td>
                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Panel runat="server" ID="pnlMain" Width="85%" ScrollBars="Both" Height="90%">

                            <asp:GridView runat="server" ID="grdPrintingDetail" AutoGenerateColumns="false" CssClass="tab">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <tr>
                                                <th rowspan="2">&#2325;&#2381;&#2352;.
                                                    <br>
                                                    / SNo </th>
                                                <th rowspan="2">&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;
                                                    <br>
                                                    / Title</th>
                                                <th rowspan="2">&#2325;&#2325;&#2381;&#2359;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;
                                                    <br>
                                                    / Class </th>
                                                <th rowspan="2">&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2366; &#2344;&#2366;&#2350;
                                                    <br>
                                                    / Group  </th>
                                                <th rowspan="2">&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2375; &#2325;&#2369;&#2354; &#2398;&#2377;&#2352;&#2381;&#2350;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; 
                                                    <br>
                                                    / Total Form Nos    </th>
                                                <th colspan="3">&#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2361;&#2379; &#2330;&#2369;&#2325;&#2375; &#2347;&#2366;&#2352;&#2381;&#2350;&#2379; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;
                                                    <br>
                                                    / Printed Forms Description  </th>
                                                <th colspan="3">&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2350;&#2375;&#2306; &#2330;&#2354; &#2352;&#2361;&#2375; &#2347;&#2366;&#2352;&#2381;&#2350;&#2379; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;
                                                    <br>
                                                    / Running Printing Form Nos   </th>
                                                <th rowspan="2">&#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2325;&#2357;&#2352; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                    <br />
                                                    / No of Printed Cover Paper </th>
                                                <th rowspan="2">&#2327;&#2375;&#2342;&#2352;&#2367;&#2306;&#2327; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2325;&#2381;&#2352;&#2367;&#2351;&#2366;&#2343;&#2368;&#2344; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No of Books in Gathering Process</th>
                                                <th rowspan="2">&#2360;&#2381;&#2335;&#2367;&#2330;&#2367;&#2306;&#2327; &#2348;&#2366;&#2311;&#2306;&#2337;&#2367;&#2306;&#2327; &#2346;&#2381;&#2352;&#2325;&#2381;&#2352;&#2367;&#2351;&#2366; &#2350;&#2375;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /
                                                    <br />
                                                    No of Books in Binding Process </th>
                                                <th rowspan="2">&#2347;&#2367;&#2344;&#2367;&#2358;&#2367;&#2306;&#2327; &#2325;&#2335;&#2367;&#2306;&#2327; &#2350;&#2375;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /<br />
                                                    No of Books in Finishing Cutting Process </th>
                                                <th rowspan="2">&#2344;&#2350;&#2381;&#2348;&#2352;&#2367;&#2306;&#2327; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2325;&#2381;&#2352;&#2367;&#2351;&#2366;&#2343;&#2368;&#2344; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                    <br />
                                                    No of Books in Numbering Process </th>


                                            </tr>

                                            <tr>
                                                <th>&#2347;&#2377;&#2352;&#2381;&#2350; &#2360;&#2375;
                                                    <br>
                                                    / From Formno </th>
                                                <th>&#2347;&#2377;&#2352;&#2381;&#2350; &#2340;&#2325;
                                                    <br>
                                                    / To Formno </th>
                                                <th>&#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /
                                                    <br>
                                                    Nos </th>

                                                <th>&#2347;&#2377;&#2352;&#2381;&#2350; &#2360;&#2375;
                                                    <br>
                                                    From Formno </th>
                                                <th>&#2347;&#2377;&#2352;&#2381;&#2350; &#2340;&#2325;
                                                    <br>
                                                    /To Formno </th>
                                                <th>&#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /
                                                    <br>
                                                    /Nos </th>

                                            </tr>

                                        </HeaderTemplate>


                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <%# Container.DataItemIndex +1 %>
                                                    <asp:HiddenField runat="server" ID="HdnPrinterBookDetailTrno_I" Value='<%# Eval("PrinterBookDetailTrno_I") %>' />
                                                    <asp:HiddenField runat="server" ID="HdnPrinter_RedID_I" Value='<%# Eval("Printer_RedID_I") %>' />

                                                </td>
                                                <td>
                                                    <%# Eval("TitleHindi_V")%>
                                                    <asp:HiddenField runat="server" ID="HDNTitleID_I" Value='<%# Eval("TitleID_I") %>' />
                                                </td>
                                                <td>
                                                    <%# Eval("Classdet_V")%>
                                                    <asp:HiddenField runat="server" ID="HDNClassTrno_I" Value='<%# Eval("ClassTrno_I") %>' />
                                                </td>
                                                <td>
                                                    <%# Eval("GroupNO_V")%>
                                                    <asp:HiddenField runat="server" ID="HDNGrpID_I" Value='<%# Eval("GrpID_I") %>' />
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtTitleTotalFormQty_I" onkeypress='javascript:tbx_fnInteger(event, this);' Width="80px" MaxLength="8" Text='<%# Eval("TitleTotalFormQty_I") %>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtComFrmFrom" Width="80px" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="8" Text='<%# Eval("CompFormFrom") %>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtComFrmTo" Width="80px" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="8" Text='<%# Eval("CompFormTo") %>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtCompQuantity" onkeypress='javascript:tbx_fnInteger(event, this);' Width="80px" MaxLength="8" Text='<%# Eval("CompQuantity") %>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtPenFrmFrom" Width="80px" MaxLength="8" Text='<%# Eval("PenFrmFrom") %>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtPenFrmTo" Width="80px" MaxLength="8" Text='<%# Eval("PenFrmTo") %>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtPenQuantity" onkeypress='javascript:tbx_fnInteger(event, this);' Width="80px" MaxLength="8" Text='<%# Eval("PenQuantity") %>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtPrintingCover" onkeypress='javascript:tbx_fnInteger(event, this);' Width="80px" MaxLength="8" Text='<%# Eval("PrintingCover") %>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtGathering" onkeypress='javascript:tbx_fnInteger(event, this);' Width="80px" MaxLength="8" Text='<%# Eval("Gathering") %>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtStiching" onkeypress='javascript:tbx_fnInteger(event, this);' Width="80px" MaxLength="8" Text='<%# Eval("Stiching") %>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtFinishing" onkeypress='javascript:tbx_fnInteger(event, this);' Width="80px" MaxLength="8" Text='<%# Eval("Finishing") %>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtNumbering" onkeypress='javascript:tbx_fnInteger(event, this);' Width="80px" MaxLength="8" Text='<%# Eval("Numbering") %>'></asp:TextBox></td>
                                            </tr>



                                        </ItemTemplate>

                                    </asp:TemplateField>

                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />

                            </asp:GridView>



                        </asp:Panel>
                    </td>
                </tr>


                <tr>
                    <td colspan="2">

                        <asp:Button runat="server" ID="btnSave" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; /Save " OnClick="btnSave_Click" OnClientClick="return ValidateAllTextForm();" />
                          <asp:Button runat="server" ID="btnClose" CssClass="btn" CausesValidation="false" Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2351;&#2375; / Back " OnClick="btnClose_Click" />
                    </td>

                </tr>
            </table>


        </div>
    </div>
</asp:Content>

