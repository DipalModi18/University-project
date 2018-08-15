<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="UniversityProject.ChangePassword" %><%-- MasterPageFile="~/Site3.Master" --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btnCss {
    background-color: #323299;
    border: none;
    color: white;
    padding: 10px 16px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 16px;
}
        .lblStyle {
            font-family: "Lucida Fax","Times New Roman";
            color: #00688b;
        }
    </style>
    <br />
    <br /><br />
    <br /><br />
    
   <div style="text-align:center; text-decoration:underline; height:10%">
       <asp:label ID="LblTitle" runat="server" text="CHANGE PASSWORD" Font-Bold="True" Font-Names="Copperplate Gothic Bold" Font-Size="Large"></asp:label>
    </div>
    <br />
    <div style="align-content:center">
        <table cellspacing="4em">
    <tr>
        <td>
            <asp:Label ID="LblOldPassword" runat="server" Text="Enter Your Old Password" CssClass="lblStyle"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                 ControlToValidate="txtOldPassword"
                ErrorMessage="You Have To Enter Old Password" ></asp:RequiredFieldValidator>
        </td>
    </tr>
            
    <tr>
    <td>
        <asp:Label ID="LblNewPassword" runat="server" Text="Enter New Password" CssClass="lblStyle"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
    </td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtNewPassword"
                ErrorMessage="This Field Is Compulsory" ></asp:RequiredFieldValidator>
    </tr>
            
    <tr>
    <td>
        <asp:Label ID="LblReEnterPassword" runat="server" Text="Re-Enter Your Password" CssClass="lblStyle"></asp:Label>
        
    </td>
    <td>
        <asp:TextBox ID="txtReEnterPassword" runat="server" TextMode="Password"></asp:TextBox>
    </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="txtReEnterPassword"
                ErrorMessage="You Have To Re-Enter Password" ></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ErrorMessage="Your New Password Doesnot Match"
            ControlToCompare="txtNewPassword" ControlToValidate="txtReEnterPassword"></asp:CompareValidator>
        </td>
    </tr>
            
    
</table>
        </div>
    <div align="center">
                <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btnCss" onclick="BtnSave_Click"/>
         &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BtnCancel" runat="server" Text="CANCEL" CausesValidation="false" CssClass="btnCss" onclick="BtnCancel_Click"/>

    </div>
</asp:Content>
