<%@ Page Title="&#2319;&#2337;&#2357;&#2366;&#2306;&#2360; &#2346;&#2340;&#2381;&#2352;&#2325; / Advance Details" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DPT006_AdvanceDetails.aspx.cs" Inherits="Depo_DPT007_AdvanceDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>

<div class="box table-responsive">
                            <div class="card-header">
                                <h2><span>&#2319;&#2337;&#2357;&#2366;&#2306;&#2360; &#2346;&#2340;&#2381;&#2352;&#2325; / Advance Details</span></h2>
                            </div>
                            <div style="padding:0 10px;">
                            
                            <table width="100%">
                                <tr>
                                    <td >
                                        <asp:Label ID="LblAcYear" runat="server" Width="180px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year:</asp:Label>
                                    </td>
                                    <td colspan="3" >
                                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                                        </asp:DropDownList>
      
                                    </td>
                                </tr>
                                <tr>
                                    <td>&#2310;&#2325;&#2360;&#2381;&#2350;&#2367;&#2325; &#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2350;&#2366;&#2306;&#2327; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Next Demand Date</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDate">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        डिमांड की अवधी से </td>
                                    <td>
                                        <asp:DropDownList ID="ddlQ" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" onselectedindexchanged="ddlQ_SelectedIndexChanged">
                                            <asp:ListItem Value="0">सेलेक्ट</asp:ListItem>
                                            <asp:ListItem Value="1">1 अप्रैल से 30 जून</asp:ListItem>
                                            <asp:ListItem Value="2">1 जुलाई से 31 दिसम्बर</asp:ListItem>
                                            <asp:ListItem Value="3">1 अक्टुबर से 31 दिसम्बर</asp:ListItem>
                                            <asp:ListItem Value="4">1 जनवरी से 31 मार्च</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>डिमांड की अवधी तक </td>
                                    <td>
                                        <asp:DropDownList ID="ddlQ0" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" onselectedindexchanged="ddlQ_SelectedIndexChanged">
                                            <asp:ListItem Value="0">सेलेक्ट</asp:ListItem>
                                            <asp:ListItem Value="1">1 अप्रैल से 30 जून</asp:ListItem>
                                            <asp:ListItem Value="2">1 जुलाई से 31 दिसम्बर</asp:ListItem>
                                            <asp:ListItem Value="3">1 अक्टुबर से 31 दिसम्बर</asp:ListItem>
                                            <asp:ListItem Value="4">1 जनवरी से 31 मार्च</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                
                                

                                <tr>
                                    <td colspan="4">
                                           <asp:GridView ID="GrdAdvance" runat="server" 
                                        AutoGenerateColumns="False"  CssClass="tab" 
                                        onrowdatabound="GrdAdvance_RowDataBound" >
                                <Columns>
                                <asp:TemplateField>
                                <ItemTemplate>
                                  <asp:CheckBox ID="chk" runat="server"></asp:CheckBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2342; &#2325;&#2366; &#2344;&#2366;&#2350; / Item Name">
                                <ItemTemplate>
                                <asp:HiddenField ID="hdnHeadId" runat="server" Value='<%#Eval("HeadID_I") %>' />
                               <%-- <asp:Label ID="lblheadname" Text='<%#Eval("HeadName_V") %>' runat="server"></asp:Label>--%>
                                    <%#Eval("AcHead") %> - <%#Eval("HeadName_V") %>
                                </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2309;&#2344;&#2369;&#2350;&#2366;&#2344;&#2367;&#2340; &#2357;&#2381;&#2351;&#2351; / Cost">
                                <ItemTemplate>
                                <asp:TextBox ID="txtEstimateAmount" MaxLength="10"  onkeypress='javascript:tbx_fnNumeric(event, this);'  runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2313;&#2346;&#2354;&#2348;&#2381;&#2343; &#2352;&#2366;&#2358;&#2367; / Available Amount">
                                <ItemTemplate>
                                 <asp:TextBox ID="txtAvailableAmount" MaxLength="10"  onkeypress='javascript:tbx_fnNumeric(event, this);' AutoPostBack="true" OnTextChanged="txtAmountChanged" runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2366;&#2306;&#2327; / Demand">
                                <ItemTemplate>
                                  <asp:TextBox ID="txtrequestAmount" MaxLength="10" onkeypress='javascript:tbx_fnNumeric(event, this);' runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>रिमार्क </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TextBox1" runat="server" Height="63px" TextMode="MultiLine" Width="494px"></asp:TextBox>
                                    </td>
                                </tr>
                                
                                

                                <tr><td colspan="3">&nbsp;</td> </tr>
                             
                                
        <tr>
            <td colspan="3">
              <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save  "   OnClientClick="return ValidateAllTextForm();"
                            onclick="btnSave_Click" />
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
        </tr>
    </table>
                            
                            </div> </div>
</ContentTemplate>

</asp:UpdatePanel>
    
</asp:Content>

