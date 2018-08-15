<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeFile="IncomeTaxModification.aspx.cs" Inherits="UniversityProject.IncomeTaxModification" %>

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
        <asp:Label ID="LblTitle" runat="server" Text="INCOME TAX MODIFICATION" Font-Bold="True" Font-Names="Copperplate Gothic Bold" Font-Size="X-Large" Font-Underline="True"></asp:Label>
    </div>
    <br />
    <div align="center">
        <table cellspacing="20px">
            <tr>
                <td>
                    <asp:Label ID="Lblyear" runat="server" Text="YEAR:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblYearDis1" runat="server" Text="" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblYearDis2" runat="server" Text="" CssClass="lblStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblSlabNo" runat="server" Text="SLAB NUMBER:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblSlabNoDis" runat="server" Text="" CssClass="lblStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblGender" runat="server" Text="GENDER:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblGenDis" runat="server" Text="" CssClass="lblStyle"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblAge" runat="server" Text="AGE GROUP:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblAgeDis" runat="server" Text="" CssClass="lblStyle"></asp:Label>
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
                    <asp:Label ID="LblUb" runat="server" Text="UPER BOUND:" CssClass="lblStyle"></asp:Label>
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
                    <asp:Label ID="LblPer" runat="server" Text="PERCENTAGE :" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtPecent" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtPecent" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TxtPecent" ErrorMessage="Enter valid number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEducess" runat="server" Text="EDUCATION CESS :" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEducess" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEducess" ErrorMessage="Please Enter Education Cess"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtEducess" ErrorMessage="Enter valid number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblHigherEducess" runat="server" Text="HIGHER EDU CESS :" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtHigherEducess" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtHigherEducess" ErrorMessage="Please enter Higher Edu cess"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtHigherEducess" ErrorMessage="Enter valid number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
                </td>
            </tr>

        </table>
    </div>
    <br />
    <div align="center">

        <asp:Button ID="btnEdit" runat="server" Text="EDIT" CssClass="btnCss" OnClick="btnEdit_Click" />


        &nbsp;&nbsp;&nbsp;
                   <asp:Button ID="btnclear" runat="server" Text="CANCEL" CssClass="btnCss" CausesValidation="false" OnClick="btnclear_Click" />

    </div>

</asp:Content>
