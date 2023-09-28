<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CDProof.aspx.cs" Inherits="Academic_CDProof"
    Title="&#2346;&#2366;&#2339;&#2381;&#2337;&#2369;&#2354;&#2367;&#2346;&#2367; &#2340;&#2376;&#2351;&#2366;&#2352; &#2325;&#2352;&#2366;&#2344;&#2375; &#2361;&#2375;&#2340;&#2369;" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                &#2346;&#2366;&#2339;&#2381;&#2337;&#2369;&#2354;&#2367;&#2346;&#2367; &#2344;&#2367;&#2352;&#2381;&#2350;&#2366;&#2339;<span> &#2361;&#2375;&#2340;&#2369; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2354;&#2375;&#2326;&#2344; &#2357;&#2367;&#2349;&#2366;&#2327; &#2325;&#2379; &#2346;&#2340;&#2381;&#2352; </span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <cc1:TabContainer ID="tcTitle" runat="server">
                <cc1:TabPanel ID="tbOrderIssue" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2354;&#2375;&#2326;&#2344; &#2357;&#2367;&#2349;&#2366;&#2327; &#2325;&#2379; &#2346;&#2340;&#2381;&#2352; &#2346;&#2381;&#2352;&#2375;&#2359;&#2367;&#2340; &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; " runat="server">
                    <ContentTemplate>
                        <table>
                          

                            <tr>
                                <td colspan="4" style="font-weight: bold">
                                    <asp:HiddenField ID="hdnAcademicYear" runat="server" />
                                    <asp:HiddenField ID="hdnCDProofID" runat="server" />
                                   
                                </td>
                            </tr>
                              <tr>
                                <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year </td>
                                <td>
                                   <%-- <asp:Label ID="lblAcademicYear" runat="server" Text="-"></asp:Label> --%>
                                    <asp:DropDownList ID="DdlACYear" runat="server">
                                    </asp:DropDownList>
                                  </td>
                                  <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td> &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2354;&#2375;&#2326;&#2344; &#2357;&#2367;&#2349;&#2366;&#2327; / Publicatio Department
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDepartment" CssClass="txtbox reqirerd" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>&#2344;&#2367;&#2327;&#2350; &#2325;&#2366; &#2360;&#2306;&#2342;&#2352;&#2381;&#2349;&#2367;&#2340; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Corporation Letter No 
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLetterNo" MaxLength="30" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2344;&#2367;&#2327;&#2350; &#2325;&#2366; &#2360;&#2306;&#2342;&#2352;&#2381;&#2349;&#2367;&#2340; &#2346;&#2340;&#2381;&#2352; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /Corporation Letter Date
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLetterDate" MaxLength="12" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender ID="ccextendtxtLetterDate" TargetControlID="txtLetterDate"
                                        Format="dd/MM/yyyy" runat="server" Enabled="True">
                                    </cc1:CalendarExtender>
                                    
                                </td>
                                <td>&#2309;&#2346;&#2375;&#2325;&#2381;&#2359;&#2367;&#2340; &#2346;&#2366;&#2339;&#2381;&#2337;&#2369;&#2354;&#2367;&#2346;&#2367; &#2357;&#2366;&#2346;&#2360;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /Expected Return Date of Verified CD Proof
                                </td>
                                <td>
                                    <asp:TextBox ID="txtExpectedReturnDate" CssClass="txtbox reqirerd" runat="server" OnTextChanged="txtExpectedReturnDate_TextChanged" AutoPostBack="True"></asp:TextBox>
                                    <cc1:CalendarExtender ID="ccextendTxtExpectedRetDate" TargetControlID="txtExpectedReturnDate"
                                        Format="dd/MM/yyyy" runat="server" Enabled="True">
                                    </cc1:CalendarExtender>
                                  
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="4" style="font-weight: bold">&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2366; &#2330;&#2351;&#2344; &#2325;&#2352;&#2375;&#2306; / Select Title
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / Medium
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlMedium" AutoPostBack="True" OnSelectedIndexChanged="ddlMedium_OnSelectedIndexChanged"
                                        CssClass="txtbox" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>&#2325;&#2325;&#2381;&#2359;&#2366; /Class
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlClass" AutoPostBack="True" CssClass="txtbox" OnSelectedIndexChanged="ddlMedium_OnSelectedIndexChanged"
                                        runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="grdTitles" AutoGenerateColumns="False" DataKeyNames="TitleID_I" PageSize="25" CssClass="tab"
                                        EmptyDataText="No title found" runat="server">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelectTitle" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="MediunNameHindi_V" HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / Medium" />
                                            <asp:BoundField DataField="Classdet_V" HeaderText=" &#2325;&#2325;&#2381;&#2359;&#2366; / Class" />
                                            <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title" />
                                            <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2381;&#2352;&#2340;&#2367;&#2351;&#2366;&#2305; / Total Copies">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTotalCopies" Text="5" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnInteger(event, this);'
                                                        runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2360;&#2368;. &#2337;&#2368;./ Total CD">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTotalCD" Text="1" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnInteger(event, this);'
                                                        runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>  <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td align="right">
                                    <asp:Button ID="btnAddTitle" OnClick="btnAddTitle_Click" runat="server" CssClass="btn"
                                        Text="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2332;&#2379;&#2337;&#2375;&#2306; /Add Title " />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="font-weight: bold">&#2330;&#2351;&#2344;&#2367;&#2340; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; / Selected Titles
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="grdSelectedTitle" AutoGenerateColumns="False" DataKeyNames="TitleID"
                                        PageSize="25" CssClass="tab" OnRowDeleting="grdSelectedTitle_OnRowDeleting" EmptyDataText="No title selected" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Medium" HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;/Medium" />
                                            <asp:BoundField DataField="Class" HeaderText=" &#2325;&#2325;&#2381;&#2359;&#2366;/Class" />
                                            <asp:BoundField DataField="Title" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;/Title" />
                                            <asp:BoundField DataField="TotalCopies" HeaderText="&#2325;&#2369;&#2354; &#2346;&#2381;&#2352;&#2340;&#2367;&#2351;&#2366;&#2305;/ Total Copies" />
                                            <asp:BoundField DataField="TotalCD" HeaderText="&#2325;&#2369;&#2354; &#2360;&#2368;. &#2337;&#2368;./Total CD" />
                                            <asp:TemplateField HeaderText="&#2361;&#2335;&#2366;&#2319;&#2305; / Delete">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDelete" CssClass="btn" runat="server" CommandName="Delete" Text="&#2361;&#2335;&#2366;&#2319;&#2306;"
                                                        OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>  <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td colspan="3" align="center">
                                    <asp:Button ID="btnOrder" runat="server" OnClick="btnOrder_Click" OnClientClick='javascript:return ValidateAllTextForm();'
                                        CssClass="btn" Text="&#2310;&#2342;&#2375;&#2358; &#2332;&#2366;&#2352;&#2368; &#2325;&#2352;&#2375;&#2306; " />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="tbRecieveProof" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2354;&#2375;&#2326;&#2344; &#2357;&#2367;&#2349;&#2366;&#2327; &#2360;&#2375; &#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2367;&#2340; &#2346;&#2366;&#2339;&#2381;&#2337;&#2369;&#2354;&#2367;&#2346;&#2367; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; " runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2354;&#2375;&#2326;&#2344; &#2357;&#2367;&#2349;&#2366;&#2327; &#2325;&#2366; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Publication Department  Letter No
                                    <asp:HiddenField ID="hdnRetCDProof" runat="server" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRecLetterNo" MaxLength="30" CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                                </td>
                                <td>&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /Letter Date
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRecLetterDate" MaxLength="12" CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender ID="ccextendTxtRecLetterDate" TargetControlID="txtRecLetterDate"
                                        Format="dd/MM/yyyy" runat="server">
                                    </cc1:CalendarExtender>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;/Medium
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlRecMedium" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlRecMedium_OnSelectedIndexChanged"
                                        runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>&#2325;&#2325;&#2381;&#2359;&#2366;/Class
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlRecClass" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlRecMedium_OnSelectedIndexChanged" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="grdRecTitle" DataKeyNames="TitleID_I" EmptyDataText="No title present"
                                        AutoGenerateColumns="false" CssClass="tab" runat="server">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRecSelectTitle" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/S.No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="MediunNameHindi_V" HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;/Medium" />
                                            <asp:BoundField DataField="Classdet_V" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366;/Class" />
                                            <asp:BoundField DataField="TitleHindi_V" HeaderText=" &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;/Title" />
                                            <asp:BoundField DataField="LetterNo_V" HeaderText=" &#2344;&#2367;&#2327;&#2350; &#2325;&#2366; &#2360;&#2306;&#2342;&#2352;&#2381;&#2349;&#2367;&#2340; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/Corporation Letter No." />
                                            <asp:BoundField DataField="LetterDate_D" DataFormatString="{0:dd/MM/yyyy}" HeaderText=" &#2344;&#2367;&#2327;&#2350; &#2325;&#2366; &#2360;&#2306;&#2342;&#2352;&#2381;&#2349;&#2367;&#2340; &#2346;&#2340;&#2381;&#2352; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/Corporation Letter Date" />
                                            <asp:TemplateField HeaderText="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325;/Remark">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRecRemark" MaxLength="30" runat="server"></asp:TextBox>
                                                     <asp:TextBox ID="txtCDProofID" Visible="false" MaxLength="30" Text='<%# Eval("CDProofVerificationTrno_I") %>' runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CD &#2309;&#2346;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375;&#2306;/Upload CD">
                                                <ItemTemplate>
                                                    <asp:FileUpload ID="fileCDProof" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>  <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                                    </asp:GridView>


                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:Button ID="btnRecAddTitle" OnClick="btnRecAddTitle_OnClick" CssClass="btn"
                                        runat="server" Text="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2332;&#2379;&#2337;&#2375;&#2306; /Add Title " />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="font-weight: bold">&#2330;&#2351;&#2344;&#2367;&#2340; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; /Selected Title
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="grdRetSelectedTitles" AutoGenerateColumns="false" EmptyDataText="No title selected"
                                        OnRowDeleting="grdRetSelectedTitles_OnRowDeleting" DataKeyNames="TitleID" PageSize="25" CssClass="tab" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/S.No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Medium" HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;/Medium" />
                                            <asp:BoundField DataField="Class" HeaderText=" &#2325;&#2325;&#2381;&#2359;&#2366;/Class" />
                                            <asp:BoundField DataField="Title" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;/Title" />
                                            <asp:BoundField DataField="LetterNo" HeaderText="&#2344;&#2367;&#2327;&#2350; &#2325;&#2366; &#2360;&#2306;&#2342;&#2352;&#2381;&#2349;&#2367;&#2340; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/Corporation Letter No. " />
                                            <asp:BoundField DataField="LetterDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText=" &#2344;&#2367;&#2327;&#2350; &#2325;&#2366; &#2360;&#2306;&#2342;&#2352;&#2381;&#2349;&#2367;&#2340; &#2346;&#2340;&#2381;&#2352; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/Corporation Letter Date" />
                                            <asp:BoundField DataField="Remark" HeaderText="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325;/Remark" />
                                            <asp:BoundField DataField="CDPath" HeaderText="&#2347;&#2366;&#2311;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350; / File Name" />
                                                                                        <asp:BoundField DataField="NigamLetter" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2354;&#2375;&#2326;&#2344; &#2357;&#2367;&#2349;&#2366;&#2327; &#2325;&#2366; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" />
                                             <asp:BoundField DataField="NigamLetterDate" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /Letter Date" />
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                      <asp:Label ID="lblUploadFileName" Visible="false" Text='<%# Eval("UploadFilePath") %>'
                                                         runat="server"></asp:Label>
                                                    <asp:Label ID="lblCDProofID" Visible="false" Text='<%# Eval("CDProofVerificationTrno") %>'
                                                        MaxLength="30" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2361;&#2335;&#2366;&#2319;&#2306;/Delete">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnRetSelectedDelete" CssClass="btn" runat="server" CommandName="Delete" Text="&#2361;&#2335;&#2366;&#2319;&#2306;"
                                                        OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>  <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                                    </asp:GridView>

                                </td>
                            </tr>

                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:Button ID="btnRecTitle" CssClass="btn" OnClientClick='javascript:return ValidateAllTextForm1();'
                                        OnClick="btnRecTitle_OnClick" runat="server" Text="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2352;&#2375;&#2306;" />
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </cc1:TabPanel>
            </cc1:TabContainer>
        </div>
    </div>
</asp:Content>
