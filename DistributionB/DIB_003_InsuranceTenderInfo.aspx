<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Title=" &#2357;&#2366;&#2352;&#2381;&#2359;&#2367;&#2325; &#2360;&#2381;&#2335;&#2377;&#2325; &#2348;&#2368;&#2350;&#2366; &#2325;&#2375; &#2344;&#2367;&#2357;&#2367;&#2342;&#2366;&#2325;&#2366;&#2352;&#2379;&#2306; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;" CodeFile="DIB_003_InsuranceTenderInfo.aspx.cs"
    Inherits="Distribution_InsuranceTenderInfo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="table-responsive">
    
     <div class="portlet-header ui-widget-header">
        &#2357;&#2366;&#2352;&#2381;&#2359;&#2367;&#2325; &#2360;&#2381;&#2335;&#2377;&#2325; &#2348;&#2368;&#2350;&#2366; &#2325;&#2375; &#2344;&#2367;&#2357;&#2367;&#2342;&#2366;&#2325;&#2366;&#2352;&#2379;&#2306; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;
    </div>
    <div class="portlet-content">
        <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none;
            padding-top: 10px; padding-bottom: 10px;">
            <asp:Label ID="lblmsg" class="notification" runat="server">
                
            </asp:Label>
        </asp:Panel>
        <table width="100%">
            <tr>
                <td>
                    &#2357;&#2367;&#2340;&#2381;&#2340;&#2367;&#2351; &#2357;&#2352;&#2381;&#2359; :
                    <asp:HiddenField ID="hdnInsuranceCompanyTrno" runat="server" />
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlFinaicalYear" Visible="true">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &#2344;&#2367;&#2357;&#2367;&#2342;&#2366;&#2325;&#2366;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;
                </td>
                <td>
                    <asp:TextBox ID="txtInsuranceCompanyName" MaxLength="30" CssClass="txtbox reqirerd"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                                &#2348;&#2367;&#2350;&#2366; &#2309;&#2357;&#2343;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;</td>
                <td>
                              <asp:TextBox ID="txtInsuranceFrom" MaxLength="12" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender ID="ccextendtxtInsuranceFrom" TargetControlID="txtInsuranceFrom"
                                      Format="dd/MM/yyyy"   runat="server">
                                    </cc1:CalendarExtender>
                                    
                </td>
                <td>
                              &#2348;&#2367;&#2350;&#2366; &#2309;&#2357;&#2343;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325;</td>
                <td>
                               <asp:TextBox ID="txtInsuranceTo" MaxLength="12" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender ID="ccextendtxtInsuranceTo" TargetControlID="txtInsuranceTo"
                                      Format="dd/MM/yyyy"   runat="server">
                                    </cc1:CalendarExtender>
                                   
                </td>
            </tr>
          
            <tr>
                <td colspan="2">
                    <h3>
                        &#2340;&#2325;&#2344;&#2368;&#2325;&#2368; &#2358;&#2352;&#2381;&#2340;&#2375;&#2306;</h3>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
          
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GrdTechnicalCondition" runat="server" 
                      DataKeyNames="Tender_Cond_Id"  CssClass="tab"  AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="चुनें ">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkTechCondition" Checked='<%# Convert.ToBoolean(Eval("IsSelected")) %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>    
                            <asp:BoundField DataField="TndrCondition" HeaderText="&#2358;&#2352;&#2381;&#2340;&#2375;&#2306;" />                    
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>रिमार्क</td>
                <td>
                    <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnSave" OnClick="btnSave_Click" CssClass="btn" runat="server" OnClientClick='javascript:return ValidateAllTextForm();'
                        Text="Save" />
                </td>
               
            </tr>
        </table>
    </div></div>
</asp:Content>
