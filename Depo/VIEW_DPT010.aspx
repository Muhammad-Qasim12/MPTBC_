<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW_DPT010.aspx.cs" Inherits="Depo_VIEW_DPT013" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box">
        <div class="card-header">
            <h2>
                <span>पुस्तक विक्रेता मॉग प्रत्रक</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="नया डाटा डाले"   
                            onclick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                       <asp:GridView ID="grnMain" runat="server" AutoGenerateColumns="False" 
                    CssClass="tab" AllowPaging="True" onpageindexchanging="grnMain_PageIndexChanging">
                    <Columns>
                       <asp:TemplateField HeaderText="क्रमांक">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                        <asp:BoundField DataField="RetDate_D" HeaderText="दिनांक" />
                        <asp:BoundField DataField="DepoName_V" HeaderText="डिपो नाम" />
                        <asp:BoundField DataField="TitleHindi_V" HeaderText="टाइटल " />
                        <asp:BoundField DataField="BookNo" HeaderText="पुस्तक क्रमांक " />
                           

                    </Columns>
                </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
</asp:Content>

