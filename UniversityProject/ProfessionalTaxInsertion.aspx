<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="ProfessionalTaxInsertion.aspx.cs" Inherits="UniversityProject.ProfessionalTaxInsertion" %>
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

        <div align="center">
        <br />
        <br />
        <asp:Label ID="LblTitle" runat="server" Text=" MONTHLY PROFESSIONAL TAX INFORMATION" Font-Bold="True" Font-Names="Copperplate Gothic Bold" Font-Size="X-Large" Font-Underline="True"></asp:Label>
    </div>


    <div align="center">
        <table cellspacing="20px">
            <tr>
                <td>
                    <asp:Label ID="Lblyear1" runat="server" Text="YEAR 1:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtYear1" runat="server" OnTextChanged="TxtYear1_TextChanged"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtYear1" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TxtYear1" ErrorMessage="Enter valid number" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:Label ID="lblyear2" runat="server" Text="YEAR 2:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtYear2" runat="server"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblSlabNo" runat="server" Text="SLAB NUMBER:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtSlabNo" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtSlabNo" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TxtSlabNo" ErrorMessage="Enter valid number" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblLb" runat="server" Text="LOWER BOUND:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Txtlb" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txtlb" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Txtlb" ErrorMessage="Enter valid number" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblUb" runat="server" Text="UPPER BOUND:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtUb" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtUb" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TxtUb" ErrorMessage="Enter valid number" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblRs" runat="server" Text="Rs. :" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtRs" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="%" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtRs" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TxtRs" ErrorMessage="Enter valid number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </div>

        <div align="center">

        <asp:Button ID="btnsave" runat="server" Text="SAVE" CssClass="btnCss" OnClick="btnsave_Click" />


        &nbsp;&nbsp;&nbsp;
                   <asp:Button ID="btnclear" runat="server" Text="CANCEL" CssClass="btnCss" CausesValidation="false" OnClick="btnclear_Click" />

    </div>

</asp:Content>
