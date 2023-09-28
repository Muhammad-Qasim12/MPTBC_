<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DataRefres.aspx.cs" Inherits="DataRefres" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>
  <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                            <ProgressTemplate>
                                <div class="fade">
                                </div>
                                <div class="progress">
                                    <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                                </div>
                            </ProgressTemplate>
                            </asp:UpdateProgress>
    
     <div class="box">
         <div class="card-header">
                             
                                <h2></h2>
                            </div>
         <br />
         <asp:Button ID="Button1" runat="server" Text="MIS Data Refresh" CssClass="btn" Height="44px" OnClick="Button1_Click1" Width="350px" />


     </div> 
    </ContentTemplate> </asp:UpdatePanel> 

</asp:Content>

