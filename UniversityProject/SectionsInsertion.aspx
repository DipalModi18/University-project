<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeFile="SectionsInsertion.aspx.cs" Inherits="UniversityProject.SectionsInsertion" %>

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
    <br />
    <div align="center">
        <br />
        <br />
        <asp:Label ID="LblTitle" runat="server" Text="SECTION WITH AMOUNT INFORMATION" Font-Bold="True" Font-Names="Copperplate Gothic Bold" Font-Size="X-Large" Font-Underline="True"></asp:Label>
    </div>
    <br />
    <div align="center">
        <table cellspacing="20px">
            <tr>
                <td>
                    <asp:Label ID="Lblyear" runat="server" Text="NUMBER:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtYear" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtYear" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblName" runat="server" Text="NAME:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtName" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblAmount" runat="server" Text="AMOUNT:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtAmt" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtAmt" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtAmt" ErrorMessage="Enter valid number" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div align="center">

        <asp:Button ID="btnsave" runat="server" Text="SAVE" CssClass="btnCss" OnClick="btnsave_Click" />
        &nbsp;&nbsp;&nbsp;
                   <asp:Button ID="btnclear" runat="server" Text="CANCEL" CssClass="btnCss" CausesValidation="false" OnClick="btnclear_Click" />

    </div>

</asp:Content>
