<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BillDetails.aspx.cs" Inherits="BillDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function isNumberKey(evt, obj) {

             var charCode = (evt.which) ? evt.which : event.keyCode
             var value = obj.value;
             var dotcontains = value.indexOf(".") != -1;
             if (dotcontains)
                 if (charCode == 46) return false;
             if (charCode == 46) return true;
             if (charCode > 31 && (charCode < 48 || charCode > 57))
                 return false;
             return true;
         }
    </script>
    <asp:HiddenField ID="hfApprovedFlag" runat="server" />    
     <asp:HiddenField ID="hfDesignationId" runat="server" />
                     <asp:HiddenField ID="HiddenField8" runat="server" />
                    <asp:HiddenField ID="hfDepartmentId" runat="server" />
                     <asp:HiddenField ID="hfEmployeeId" runat="server" />
     <asp:HiddenField ID="hfLoggedInDepartment" runat="server" />

    <div class="card-header">        <h2>
            BILL DETAILS</h2>
    </div>
   
        <table width="30%">
           
            <tr id="tblPri" runat="server">
                 <td style="font-weight:bold;">Printing Bill :</td>
                <td>
                    <asp:RadioButtonList ID="rdPriBill" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" OnSelectedIndexChanged="rdPriBill_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="Running Bill" Value="r"></asp:ListItem>
                        <asp:ListItem Text="Final Bill" Value="f"></asp:ListItem>
                    </asp:RadioButtonList>

                     <asp:HiddenField ID="HiddenField13" runat="server" />
                    <asp:HiddenField ID="HiddenField14" runat="server" />
                    <asp:HiddenField ID="HiddenField15" runat="server" />
                     <asp:Label ID="HDNRedirect" runat="server" Visible="false" />
                    <asp:HiddenField ID="HiddenField16" runat="server" />
                    
                </td>
            </tr>
        
           
            <tr id="tblBldg" runat="server">
                 <td style="font-weight:bold;">Building/Vehicle Bill :</td>
                <td>
                    <asp:RadioButtonList ID="rdBldgbill" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" OnSelectedIndexChanged="rdBldgbill_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="Building" Value="b"></asp:ListItem>
                        <asp:ListItem Text="Vehicle" Value="v"></asp:ListItem>
                    </asp:RadioButtonList>

                     <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                    <asp:HiddenField ID="HiddenField3" runat="server" />
                     <asp:Label ID="Label1" runat="server" Visible="false" />
                    <asp:HiddenField ID="HiddenField4" runat="server" />
                    
                </td>
            </tr>
        </table>
   
   

 
</asp:Content>

