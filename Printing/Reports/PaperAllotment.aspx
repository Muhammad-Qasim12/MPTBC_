<%@ Page Title="&#2346;&#2375;&#2346;&#2352; &#2310;&#2357;&#2306;&#2335;&#2344;
                    &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;  / Paper Allotment Details"
    Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PaperAllotment.aspx.cs" Inherits="Printing_PaperAllotment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>
                    <%--Paper Allotment Detail--%>&#2346;&#2375;&#2346;&#2352; &#2310;&#2357;&#2306;&#2335;&#2344;
                    &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;  / Paper Allotment Details</span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td>
                        <%--Academic Year  --%>
                        &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; / Academic Year
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAcadmicYear" runat="server" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlAcadmicYear_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%--Name of the Printer--%>&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366;
                        &#2344;&#2366;&#2350; / Name of the Printer
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPrinterName" runat="server" CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlPrinterName_SelectedIndexChanged1">
                        </asp:DropDownList>
                    </td>
                </tr>
                
                <tr>
                    <td>&#2357;&#2352;&#2381;&#2325; &#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; 
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlJoBCode" AutoPostBack="true"  runat="server" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlJoBCode_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>&#2346;&#2375;&#2346;&#2352; &#2310;&#2352;&#2381;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;  / Date
                    </td>
                    <td>
                        <asp:TextBox ID="txtSupplydate_D" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CalSupplydate_D" TargetControlID="txtSupplydate_D"
                            runat="server">
                        </cc1:CalendarExtender>
                      
                        <%-- <cc1:MaskedEditExtender ID="MasktxtRegDate_D" TargetControlID="txtSupplydate_D"  Mask="99/99/9999" UserDateFormat="None"  MaskType="Date" runat="server"></cc1:MaskedEditExtender>
                        --%>
                    </td>
                </tr>
                 <tr>
                    <td>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; 
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTitle" runat="server" CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlTitle_SelectedIndexChanged">
                        </asp:DropDownList>
                       <%-- <asp:CheckBoxList ID="ddlTitle" runat="server" AutoPostBack="True" ></asp:CheckBoxList>--%>
                    </td>
                    <td>&#2346;&#2375;&#2346;&#2352;  &#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352;  / Order No.
                    </td>
                    <td>
                       
                      <asp:TextBox ID="txtOrderNo" runat="server" AutoPostBack="true" CssClass="txtbox reqirerd"
                            MaxLength="10" onkeypress="javascript:fnSetPhoneDigits(event, this);" OnTextChanged="txtOrderNo_TextChanged"></asp:TextBox>
                        <%-- <cc1:MaskedEditExtender ID="MasktxtRegDate_D" TargetControlID="txtSupplydate_D"  Mask="99/99/9999" UserDateFormat="None"  MaskType="Date" runat="server"></cc1:MaskedEditExtender>
                        --%>
                    </td>
                </tr>
                 <tr>
                    <td><span style="color: rgb(34, 34, 34); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; line-height: 15px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(252, 253, 253);">&#2346;&#2375;&#2346;&#2352; &#2360;&#2367;&#2325;&#2381;&#2351;&#2370;&#2352;&#2367;&#2335;&#2368; &#2352;&#2366;&#2358;&#2367;</span></td>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                       
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td>
                        <asp:DropDownList ID="ddlVenderName" runat="server" CssClass="txtbox reqirerd" >
                        </asp:DropDownList>
                    </td>
                    <td>&#2360;&#2381;&#2335;&#2377;&#2325; &#2335;&#2366;&#2311;&#2346; </td>
                    <td>
                       
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">New</asp:ListItem>
                            <asp:ListItem Value="2">Old</asp:ListItem>
                        </asp:RadioButtonList>
                     </td>
                </tr>
                <tr>
                    <td colspan="4"> 
                        <asp:GridView ID="GrdWorkPlan0" runat="server" AutoGenerateColumns="False" GridLines="None"
                            CssClass="tab" EmptyDataText="Record Not Found." Width="100%"
                            OnRowDataBound="GrdWorkPlan_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="TitleHindi_V" />
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br> Paper Type">
                                    <ItemTemplate>
                                        <%#Eval("ptype")%>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size">
                                    <ItemTemplate>
                                        <%#Eval("aa")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; <br>Paper Quantity">
                                    <ItemTemplate>
    <%#Eval("paper")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; &#2335;&#2344 / रीम ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBox1" Text="0" runat="server" onkeypress='javascript:tbx_fnNumeric(event, this);' Width="50px" Visible='<%# Eval("PaperType_Id").ToString()=="2" ? false  : true %>'></asp:TextBox> <%--<%#Eval("TAN")%>--%>
                                        <asp:HiddenField ID="hdCoverPaperID" runat="server" Value='<%#Eval("CoverPaperID")%>' />
                                        <asp:HiddenField ID="hdPrintingPaperID" runat="server" Value='<%#Eval("PrintingPaperID")%>' />
                                     <asp:HiddenField ID="hdPaperType" runat="server" Value='<%#Eval("PaperType_Id")%>' />
                                     <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("TotalAllt")%>' />
                                        <asp:HiddenField ID="HiddenField3" runat="server" Value='<%#Eval("paper")%>' />
                                         <asp:HiddenField ID="TitleID_I" runat="server" Value='<%#Eval("paper")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="TotalAllt" HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366; &#2330;&#2369;&#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; " />
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; &#2358;&#2368;&#2335; &#2350;&#2375;&#2306; ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBox2" Text="0" runat="server" onkeypress='javascript:tbx_fnNumeric(event, this);' Width="50px"  Visible='<%# Eval("PaperType_Id").ToString()=="1" ? false  : true %>'></asp:TextBox> 
                                        </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2330;&#2369;&#2344;&#2375;  ">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--<asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366;  <br>Supply Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblVdrSendQty" runat="server" Text='<%#Eval("VdrSendQty")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />

                        </asp:GridView>

                    </td>
                </tr>
                <tr runat="server" visible="false"  >
                    <td colspan="4">
                        <asp:TextBox ID="txtPaperQuantity" runat="server" CssClass="txtbox reqirerd" MaxLength="12"
                            onkeypress="javascript:tbx_fnSignedNumeric(event, this);"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFieldPqty" ForeColor="Red" runat="server" ErrorMessage="Please enter quantity."
                            ControlToValidate="txtPaperQuantity" InitialValue="0" Text="*" ValidationGroup="VV"></asp:RequiredFieldValidator>
                        <asp:Button runat="server" ID="btnADD" CssClass="btn" ValidationGroup="VV" Text="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375; / Add "
                            OnClick="btnADD_Click" />
                        <asp:DropDownList ID="ddlPaperSize" runat="server" CssClass="txtbox reqirerd" OnInit="ddlPaperSize_Init">
                        </asp:DropDownList>
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlPaperType_SelectedIndexChanged" OnInit="ddlPaperType_Init">
                        </asp:DropDownList> 

                        <asp:TextBox runat="server" ID="txtTotalSheets" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                            MaxLength="15"></asp:TextBox>
                        </td>

                </tr>
                <tr runat="server"   >
                    <td colspan="4">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375; / Add "
                            OnClientClick="return ValidateAllTextForm();" OnClick="btnSave_Click" />
                        </td>

                </tr>
                <tr runat="server"   >
                    <td colspan="4">
                        <asp:GridView ID="GrdPaperAllotment" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GrdPaperAllotment_RowDataBound" ShowFooter="True">
                            <Columns>
                                <asp:BoundField DataField="AcadmicYR_V" HeaderText="&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; / Academic Year" />
                                <asp:BoundField DataField="NameofPress_V" HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Printer Name" />
                                <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:BoundField DataField="OrderNo" HeaderText="&#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352;  / Order No" />
                                <asp:BoundField DataField="Supplydate_D" HeaderText="&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Date" />
                                <asp:BoundField DataField="PaperQty_N" HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2346;&#2375;&#2346;&#2352;  / Printing Paper(Tons)" />
                                <asp:BoundField DataField="TotSheets" HeaderText="&#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352;  / Coverpaper Sheet" />
                             <%--<asp:BoundField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; / paper Type" DataField="PaperType" />
                              <asp:BoundField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352; / Paper Size" DataField="CoverInformation" />
                             <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2346;&#2375;&#2346;&#2352; (&#2335;&#2344; &#2350;&#2375; )/&#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; (&#2358;&#2368;&#2335; &#2350;&#2375; ) Printing Paper (in Ton) / Cover Paper (in Sheet)" Visible="false" >
                                    <ItemTemplate>
                                    <%#Eval("PaperOpt_I").ToString().Equals("True") ? "&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2346;&#2375;&#2346;&#2352;" : "&#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352;"%>
                                        </ItemTemplate>
                                </asp:TemplateField>
                           
                             <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2346;&#2375;&#2346;&#2352; (&#2335;&#2344; &#2350;&#2375; )/&#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; (&#2358;&#2368;&#2335; &#2350;&#2375; ) Printing Paper (in Ton) / Cover Paper (in Sheet)" DataField="PaperQty_N" />
                                --%>
                               
                               
                                <asp:BoundField DataField="PaperVendorName_V" HeaderText="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:BoundField DataField="Typea" HeaderText="&#2360;&#2381;&#2335;&#2377;&#2325; &#2335;&#2366;&#2311;&#2346; " />
                               
                               
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                        </td>

                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GrdWorkPlan" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" EmptyDataText="Record Not Found." Width="100%" AllowPaging="false"
                            OnRowDataBound="GrdWorkPlan_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br> Paper Type">
                                    <ItemTemplate>
                                        <%#Eval("PaperType")%>
                                        <asp:Label ID="lblPaperType_I" runat="server" Text='<%#Eval("PaperType_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblPaperMstrTrId_I" runat="server" Text='<%#Eval("PaperMstrTrId_I")%>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblpprAlltChild_id" runat="server" Text='<%#Eval("pprAlltChild_id")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCoverInformation" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; <br>Paper Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaperQuantity_N" runat="server" Text='<%#Eval("PaperQty_N")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366;  <br>Supply Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblVdrSendQty" runat="server" Text='<%#Eval("VdrSendQty")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText=" &#2325;&#2369;&#2354; &#2358;&#2368;&#2335; / Total Sheets">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalSheets" runat="server" Text='<%#Eval("TotSheets")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkUpdate" OnClick="lnkUpdate_Click" runat="server">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" OnClientClick="javascript:return confirm('Are you sure to delete ?')"
                                            runat="server" Visible="false">&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; / Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />

                        </asp:GridView>

                    </td>

                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnADD0" CssClass="btn" ValidationGroup="VV" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; "
                            OnClick="btnADD0_Click" Visible="False" />
                        </td>
                </tr>
                <tr>
                    <td colspan="4"></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
