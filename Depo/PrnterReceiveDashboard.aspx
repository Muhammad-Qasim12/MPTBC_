<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrnterReceiveDashboard.aspx.cs" Inherits="Depo_PrnterReceiveDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                  मुद्रक से प्राप्त पुस्तक की स्कैनिंग की रिपोर्ट </h2>
        </div>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="tab">
            <Columns>
                 <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                <asp:BoundField DataField="DepoName_V" HeaderText="डिपो का नाम " />
                <asp:BoundField DataField="Total" HeaderText="प्रिंटर द्वारा भेजे गए बंडल " />
                <asp:BoundField DataField="barcode" HeaderText="बारकोड से  अपलोड  बंडल " />
                <asp:TemplateField HeaderText="प्रतिशत ">
                    <ItemTemplate>
                       <a href=""><%#Eval("Per") %> %</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
          </div> 
</asp:Content>

