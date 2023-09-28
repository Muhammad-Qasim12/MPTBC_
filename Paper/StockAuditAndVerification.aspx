<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="StockAuditAndVerification.aspx.cs" Inherits="Paper_StockAuditAndVerification"
    Title="&#2360;&#2381;&#2335;&#2377;&#2325; &#2321;&#2337;&#2367;&#2335; &#2319;&#2357;&#2306; &#2360;&#2340;&#2381;&#2351;&#2366;&#2346;&#2344; / Stock Audit And Verification" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="headlines">
            <h2>
                <span>
                    <%--Stock Audit And Verification--%>&#2360;&#2381;&#2335;&#2377;&#2325; &#2321;&#2337;&#2367;&#2335; &#2319;&#2357;&#2306; &#2360;&#2340;&#2381;&#2351;&#2366;&#2346;&#2344; / Stock Audit And Verification</span></h2>
        </div>
       <div class="table-responsive">
            <table width="100%">
                 <tr>
                    <td style="text-align: left" width="20%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                        <br />
                        Acadmic Year :
                    </td>
                    <td style="text-align: left" >
                        <asp:DropDownList ID="ddlAcYear" runat="server" OnInit="ddlAcYear_Init" AutoPostBack="true"   Width="250px" OnSelectedIndexChanged="ddlAcYear_SelectedIndexChanged" ></asp:DropDownList>
                    </td>
                    <td>
                        <%--Date of Inspection (--%>&#2344;&#2367;&#2352;&#2367;&#2325;&#2381;&#2359;&#2339; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; <br />Date Of Inspection
                    </td>
                    <td colspan="1">
                        <asp:TextBox runat="server" ID="txtInspectionDate" CssClass="txtbox reqirerd" MaxLength="10" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Officer name (--%>&#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350;<br />Officer Name
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOfficeName" runat="server" AutoPostBack="True" OnInit="ddlOfficeName_Init"
                            OnSelectedIndexChanged="ddlOfficeName_SelectedIndexChanged" Width="250px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%--Designation (--%>&#2346;&#2342;<br /> Post
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDesignation" Width="250px" ReadOnly="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqDes" ForeColor="Red" runat="server" Text="*" ControlToValidate="txtDesignation" ValidationGroup="dd" ErrorMessage="Please select officer name."></asp:RequiredFieldValidator>
                        <asp:Button runat="server" ID="btnADD" CssClass="btn" ValidationGroup="dd" Text="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375; / Add "
                            OnClick="btnADD_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GrdOfficerDetail" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" EmptyDataText="Record Not Found." Width="100%" AllowPaging="false" OnRowDataBound="GrdOfficerDetail_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--      <asp:TemplateField HeaderText="&#2344;&#2367;&#2352;&#2367;&#2325;&#2381;&#2359;&#2339; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; ">
                                <ItemTemplate>
                                    <asp:Label ID="lblInspectionDate" runat="server" Text='<%#Eval("InspectionDate") %>'></asp:Label>    
                                    
                                    
                                </ItemTemplate>

                            </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="&#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350;<br>Officer Name ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOfficeid" Visible="false" runat="server" Text='<%#Eval("OfficerId") %>'></asp:Label>
                                        <asp:Label ID="lblOfficeName" runat="server" Text='<%#Eval("OfficeName") %>'></asp:Label>
                                        <asp:Label ID="lblAuditDtld_I" Visible="false" runat="server" Text='<%#Eval("AuditDtld_I") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2342;<br>Post">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPost" runat="server" Text='<%#Eval("OfficerPost") %>'></asp:Label>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkUpdate" OnClick="lnkUpdate_Click" runat="server">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                       <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete"  OnClientClick="javascript:return confirm('Are you sure to delete ?')" OnClick="lnkDelete_Click" runat="server" Visible="false">&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; / Delete</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                            </Columns>
                                      <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--LOI No. (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />L.O.I. No.
                    </td>
                    <td colspan="3">
                           <asp:DropDownList runat="server" ID="ddlLOINo" Width="250px" CssClass="txtbox reqirerd"
                        OnInit="ddlLOINo_Init" >
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Verification Report if Any (--%>&#2360;&#2340;&#2381;&#2351;&#2366;&#2346;&#2344; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;<br />Verification Report
                    </td>
                    <td colspan="3">
                       <asp:TextBox runat="server" ID="txtVerificationRpt" CssClass="txtbox reqirerd"  TextMode="MultiLine" MaxLength="200" Width="250px"  onkeypress="MaxLengthCount('ContentPlaceHolder1_txtVerificationRpt',200);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Remark (--%>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;<br />Remark
                    </td>
                    <td colspan="3">
                      <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine"  MaxLength="140" Width="250px"  onkeypress="MaxLengthCount('ContentPlaceHolder1_txtRemark',140);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Upload Report (--%>
                        &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2309;&#2346;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375;<br />Upload Report
                    </td>
                    <td colspan="3">
                        <asp:FileUpload runat="server" ID="fileUp1" Width="300px"></asp:FileUpload>
                    </td>
                </tr>
                <tr>
                <td colspan="4" style="height: 10px;">
                    <asp:Label ID="lblMsg" runat="server" ></asp:Label>
                
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save"
                        CssClass="btn" OnClick="btnSave_Click" OnClientClick="return ValidateAllTextForm();"  />
                
                </td>
            </tr>
                
            </table>
        </div>
    </div>
    <asp:HiddenField ID="hdnFile" runat="server" />
                     <asp:HiddenField ID="hdChildId" runat="server" />
    <cc1:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="txtInspectionDate"
        format="dd/MM/yyyy">
    </cc1:calendarextender>
</asp:Content>
