<%@ Page Title="&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2381;&#2352;&#2367;&#2319;&#2358;&#2344; / Group creation" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GroupCreation.aspx.cs" Inherits="Printing_GroupCreation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="card">
                <div class="card-header">
                    <h2>ग्रुप निर्माण</h2>
                </div>
                <div class="card-body">
                    <div class="row g-3">
                        <div class="col-md-12">
                            <asp:Label ID="Label3" runat="server" CssClass="alert alert-success" Font-Bold="True" ForeColor="Red" Style="display: none"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="DdlACYear" runat="server" AutoPostBack="True" CssClass="form-select" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>2012-13</asp:ListItem>
                                    <asp:ListItem>2013-14</asp:ListItem>
                                    <asp:ListItem>2014-15</asp:ListItem>
                                </asp:DropDownList>
                                <label>शिक्षा सत्र</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DataList ID="DlistGroup" runat="server" RepeatColumns="8"
                                    RepeatDirection="Horizontal"
                                    OnSelectedIndexChanged="DlistGroup_SelectedIndexChanged">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkGroupName" AutoPostBack="false" runat="server" Text='<%#Eval("GroupName") %>' OnCheckedChanged="chkGroupName_CheckedChanged" />
                                        <asp:Label ID="lblGroupId" runat="server" Text='<%#Eval("GroupId") %>' Visible="false"></asp:Label>

                                    </ItemTemplate>
                                </asp:DataList>
                                <%--<asp:DropDownList ID="DlistGroup" runat="server" AutoPostBack="True" CssClass="form-select" OnSelectedIndexChanged="DlistGroup_SelectedIndexChanged">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>--%>
                                <label>बुक मार्क का नाम </label>
                            </div>
                        </div>
                    </div>
                    <div class="inner-box">
                        <div class="row">
                            <h5><b>पुस्तक की जानकारी</b></h5>
                            <div class="col-md-4">
                                <div class="form-floating">
                                    <asp:DropDownList ID="ddlColourCover1n4" runat="server" CssClass="form-select">
                                        <asp:ListItem>Select..</asp:ListItem>
                                        <asp:ListItem Text="Single Colour" Value="Single Colour"></asp:ListItem>
                                        <asp:ListItem Text="Double Colour" Value="Double Colour"></asp:ListItem>
                                        <asp:ListItem Text="Multi Colour" Value="Multi Colour"></asp:ListItem>
                                    </asp:DropDownList>
                                    <label>रंग योजना कवर पेज 1 एवं 4</label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-floating">
                                    <asp:DropDownList ID="ddlColourCover2n3" runat="server" CssClass="form-select">
                                        <asp:ListItem Selected="True">Select..</asp:ListItem>
                                        <asp:ListItem Text="Single Colour" Value="Single Colour"></asp:ListItem>
                                        <asp:ListItem Text="Double Colour" Value="Double Colour"></asp:ListItem>
                                        <asp:ListItem Text="Multi Colour" Value="Multi Colour"></asp:ListItem>
                                    </asp:DropDownList>
                                    <label>रंग योजना कवर पेज 2 एवं 3</label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-floating">
                                    <asp:DropDownList ID="ddlColourCover" runat="server" CssClass="form-select">
                                        <asp:ListItem Selected="True">Select..</asp:ListItem>
                                        <asp:ListItem Text="Single Colour" Value="Single Colour"></asp:ListItem>
                                        <asp:ListItem Text="Double Colour" Value="Double Colour"></asp:ListItem>
                                        <asp:ListItem Text="Multi Colour" Value="Multi Colour"></asp:ListItem>
                                    </asp:DropDownList>
                                    <label>रंग योजना मैटर</label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-floating">
                                    <asp:DropDownList ID="ddlPrintingPaperInformation_V" runat="server" CssClass="form-select">
                                    </asp:DropDownList>
                                    <label>मुद्रण पेपर की जानकारी</label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-floating">
                                    <asp:DropDownList ID="ddlCoverPaperinformation_V" runat="server" CssClass="form-select">
                                    </asp:DropDownList>
                                    <label>कवर पेपर की जानकारी</label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-floating">
                                    <asp:DropDownList ID="Binding" runat="server" CssClass="form-select">
                                        <asp:ListItem>Select..</asp:ListItem>
                                        <asp:ListItem>Perfect Binding</asp:ListItem>
                                        <asp:ListItem>Non Perfect (Chemical Binding)</asp:ListItem>
                                    </asp:DropDownList>
                                    <label>बाइंडिंग की जानकारी</label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-floating">
                                    <asp:DropDownList ID="CheckBoxList1" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged" CssClass="form-select">
                                    </asp:DropDownList>
                                    <%--<asp:CheckBoxList ID="CheckBoxList1" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True">
                                    </asp:CheckBoxList>--%>
                                    <label>कक्षा</label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-floating">
                                    <asp:DropDownList ID="ddlTital" runat="server" CssClass="form-select">
                                    </asp:DropDownList>
                                    <label>शीर्षक का नाम</label>
                                </div>
                            </div>
                            <div class="col-md-12 mt-2 mb-2">
                                <asp:Button ID="btnSearch0" runat="server" CssClass="btn btn-submit" OnClick="btnSearch_Click" Text="खोजे" />
                            </div>
                            <div class="col-md-12">
                                <asp:Label ID="lblDepoList" Font-Bold="true" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-12">
                                <h5><b>कुल मुद्रण पेपर की मात्रा (टन में) :</b>
                                    <asp:Label ID="Label1" runat="server" CssClass="txtbox" Font-Bold="True"></asp:Label></h5>
                            </div>
                            <div class="mt-2 mb-2" id="tblbookDtl" runat="server" width="100%">
                                <asp:GridView ID="grdBooksDes" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" EmptyDataText="Record Not Found" Width="90%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; / Book Title">
                                            <ItemTemplate>
                                                <%# Eval("TitleHindi_V")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; / Class">
                                            <ItemTemplate>
                                                <%# Eval("Class")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379;">
                       <ItemTemplate>
                           <%# Eval("DepoName_V")%>
                       </ItemTemplate>
                   </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="&#2346;&#2375;&#2332;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No of Pages">
                                            <ItemTemplate>
                                                <%# Eval("Noofpages")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2361;&#2379;&#2344;&#2375; &#2357;&#2366;&#2354;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (&#2335;&#2344; &#2350;&#2375; ) / Printing Book Quantity (in Ton.)">
                                            <ItemTemplate>
                                                <%# Eval("TotNoOfBooks")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2335;&#2344; &#2350;&#2375; ) / Printing Paper Quantity (in Ton.)">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Qty_PriPaper")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2358;&#2368;&#2335; &#2350;&#2375;&#2306; ) / Cover Paper Quantity (in Sheet)">
                                            <ItemTemplate>
                                                <%# Eval("Qty_Covpaper")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2330;&#2351;&#2344; &#2325;&#2352;&#2375; / Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkChoose" runat="server" AutoPostBack="True" OnCheckedChanged="chkChoose_CheckedChanged" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2360;&#2348; &#2327;&#2381;&#2352;&#2369;&#2346; &#2344;&#2306;&#2348;&#2352; &#2337;&#2366;&#2354;&#2375; ">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtSubgroup" runat="server" MaxLength="2" Visible="False" Width="40px">0</asp:TextBox>
                                                <asp:HiddenField ID="Hdnclasstrno_i" runat="server" Value='<%# Eval("classtrno_i") %>' />
                                                <asp:HiddenField ID="HdnDepoId" runat="server" Value='<%# Eval("DepoID") %>' />
                                                <asp:HiddenField ID="HdnTitleId" runat="server" Value='<%# Eval("TitleID") %>' />
                                                <asp:HiddenField ID="HdnPriDemandId" runat="server" Value='<%# Eval("PriDemandID") %>' />
                                                <asp:HiddenField ID="HdnGroupname" runat="server" Value='<%# Eval("DepoName_V") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="Gvpaging" />
                                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                    <div class="col-md-4">
                        <div class="form-floating">
                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-select reqirerd">
                            </asp:DropDownList>
                            <asp:HiddenField ID="HdnDepoID_I" runat="server" Value="0" />
                            <asp:HiddenField ID="HdnGrpId_I" runat="server" Value="0" />
                            <label>केटेगरी का नाम </label>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-floating">
                            <asp:DropDownList ID="ddlTenderType" runat="server" CssClass="form-select reqirerd">
                                <asp:ListItem>Web Offset</asp:ListItem>
                                <asp:ListItem>Sheet Fed</asp:ListItem>
                            </asp:DropDownList>
                            <label>टेंडर का प्रकार</label>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-floating">
                            <asp:TextBox ID="txtGroupNo" runat="server" CssClass="form-control reqirerd" MaxLength="8"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="filterGroupNo" runat="server" TargetControlID="txtGroupNo" ValidChars="0123456789">
                            </cc1:FilteredTextBoxExtender>
                            &nbsp;<asp:TextBox ID="txtBankName_V" runat="server" CssClass="form-control" MaxLength="3" onkeypress="javascript:tbx_fnSignedNumeric(event, this);" Visible="False"></asp:TextBox>
                            <label>ग्रुप क्रमांक </label>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-floating">
                            <asp:TextBox ID="txtEMDAmount_N" runat="server" CssClass="form-control reqirerd" MaxLength="8" onkeypress="javascript:tbx_fnSignedNumeric(event, this);" Visible="False"></asp:TextBox>
                            <asp:Label ID="lblCatDes" runat="server"></asp:Label>
                            <asp:TextBox ID="txtBankDetails" runat="server" CssClass="form-control" onkeypress="tbx_fnAlphaNumericOnly(event, this);" TextMode="MultiLine" Visible="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <asp:Button ID="btnSaveGroup" runat="server" CssClass="btn btn-submit" OnClick="btnSaveGroup_Click" OnClientClick="return ValidateAllTextForm();" Text="ग्रुप सुरक्षित करे" />
                    </div>
                        </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>


