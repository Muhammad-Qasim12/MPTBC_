<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="AdvancePayment.aspx.cs" Inherits="DistributionB_AdvancePayment" Title="&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2352;&#2366;&#2358;&#2367; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                <span>&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2352;&#2366;&#2358;&#2367; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;/Advance Payment Recieve Details</span></h2>
        </div>
        <div style="padding: 0 10px 15px;">

            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlModuleMaster" runat="server">
                <asp:Button ID="btnNewModule" OnClick="btnNewModule_Click" runat="server" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; / New Data"
                    CssClass="btn"></asp:Button>
                <asp:GridView ID="gvModuleMaster" CssClass="tab" AutoGenerateColumns="False" PageSize="20"
                    AllowPaging="True" OnPageIndexChanging="gvModuleMaster_PageIndexChanging" DataKeyNames="AdvancePaymentID_I"
                    OnRowEditing="gvModuleMaster_RowEditing" OnRowDeleting="gvModuleMaster_RowDeleting"
                    runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FyYear" Visible="true" ReadOnly="true" HeaderText="&#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2357;&#2352;&#2381;&#2359;/ Financial Year" />
                        <asp:BoundField DataField="DepName_V" Visible="true" ReadOnly="true" HeaderText="&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2357;&#2367;&#2349;&#2366;&#2327; &#2325;&#2366; &#2344;&#2366;&#2350; / Advance Recieved from Department" />
                        <asp:BoundField DataField="TitleHindi_V" ReadOnly="true" HeaderText="&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2366;&#2327;&#2381;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; / Other then TextBook Item" />
                        <asp:BoundField DataField="LetterNo_Date" ReadOnly="true" HeaderText="&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2357;&#2367;&#2349;&#2366;&#2327; &#2325;&#2366; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2319;&#2357;&#2306; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Recieve Advance Payment Department Letter No & Date" />
                        <asp:BoundField DataField="AdvanceType_V"  HeaderText="&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;/ Type of Advance Payment" ReadOnly="True" />
                         <asp:BoundField DataField="PaymentAmount_I" HeaderText="&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2352;&#2366;&#2358;&#2367;(&#2352;&#2369;&#2346;&#2319;)/ Advance Payment(Rs.)" ReadOnly="True" />
                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn" CommandName="Edit"
                            Text="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;&#2306;">
                            <ControlStyle CssClass="btn" />
                        </asp:ButtonField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" CssClass="btn" runat="server" CommandName="Delete" Text="&#2361;&#2335;&#2366;&#2319;&#2306;"
                                    OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:HiddenField ID="hdnPaymentID" Value="0" runat="server" />
            </asp:Panel>
            <asp:Panel ID="pnlNewModule" Visible="false" runat="server">
                <table>
                    <tr>
                        <td>&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2357;&#2367;&#2349;&#2366;&#2327; &#2325;&#2366; &#2344;&#2366;&#2350; / Advance Recieved from Department
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDepartment" CssClass="txtbox reqirerd" runat="server"></asp:DropDownList>
                        </td>
                        <td>&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2366;&#2327;&#2381;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; / Other then TextBook Item
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTitle" CssClass="txtbox reqirerd" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlAcademicYr" 
                                CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlAcademicYr_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>&#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2357;&#2352;&#2381;&#2359; / Financial Year
                        </td>
                        <td>
                            <asp:Label ID="lblFinancialYr" runat="server">--</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2357;&#2367;&#2349;&#2366;&#2327; &#2325;&#2366; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Recieve Advance Payment Department Letter No 
                        </td>
                        <td>
                            <asp:TextBox ID="txtLetterNo" MaxLength="10" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                        </td>
                        <td>&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2357;&#2367;&#2349;&#2366;&#2327; &#2325;&#2366; &#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;  / Recieve Advance Payment Department Letter Date</td>
                        <td>
                            <asp:TextBox ID="txtLetterDate" MaxLength="12" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="calLetterDate" TargetControlID="txtLetterDate" Format="dd/MM/yyyy"
                                runat="server" Enabled="True">
                            </cc1:CalendarExtender>
                          
                        </td>
                    </tr>
                    <tr>
                        <td>&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;/ Type of Advance Payment</td>
                        <td>
                            <asp:DropDownList ID="ddlAdvanceType" CssClass="txtbox reqirerd" runat="server" AutoPostBack="false">
                                <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                <asp:ListItem>Cheque</asp:ListItem>
                                <asp:ListItem>Internet Banking</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2357;&#2367;&#2357;&#2352;&#2339; /&nbsp; Advance Payment Details</td>
                        <td>
                            <asp:TextBox ID="txtPaymentDetails" runat="server" CssClass="txtbox reqirerd" MaxLength="40"></asp:TextBox>
                           
                        </td>
                    </tr>
                    <tr>
                        <td>&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2352;&#2366;&#2358;&#2367; (&#2352;&#2370;&#2346;&#2319;)/ Recieve Advance Payment (Rs.)
                        </td>
                        <td>
                            <asp:TextBox ID="txtAdvancePayment"  runat="server" onkeypress='javascript:tbx_fnNumeric(event, this);'
                                CssClass="txtbox reqirerd">
                            </asp:TextBox>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="4">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;"
                                OnClientClick='javascript:return ValidateAllTextForm();' CssClass="btn"></asp:Button>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
