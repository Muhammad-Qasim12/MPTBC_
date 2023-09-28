<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChallanStatusUpdate.aspx.cs" Inherits="Depo_ChallanStatusUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
     <div class="box">
                    <div class="card-header">
                        <br />
                     <h2> Overdues Challan Details</h2>
                          
                    </div>
         <table width="100%">
             <tr><td colspan="2">
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                     <Columns>
                         <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                         <asp:BoundField DataField="ChalanNo" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2377; ." />
                         <asp:BoundField DataField="ChalanDate" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                         <asp:BoundField DataField="NameofPressHindi_V" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                         <asp:CommandField ShowSelectButton="True" />
                     </Columns>
                 </asp:GridView>
                 </td></tr>

             <tr><td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2377;.</td><td>
                 <asp:TextBox ID="TextBox1" runat="server" Enabled="False" CssClass="txtbox reqirerd" ></asp:TextBox>
                 </td></tr>

             <tr><td>&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; </td><td>
                 <asp:TextBox ID="TextBox2" runat="server" Height="67px" TextMode="MultiLine" Width="411px" CssClass="txtbox reqirerd" ></asp:TextBox>
                 </td></tr>

             <tr><td colspan="2">
                 <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Save" OnClientClick="javascript:return ValidateAllTextForm();" />
                 </td></tr>

         </table>
         </div> 
</asp:Content>

