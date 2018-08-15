<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeFile="MedicalPremiumAllowanceInsertion.aspx.cs" Inherits="UniversityProject.MedicalPremiumAllowanceInsertion" %>

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
        <asp:Label ID="LblTitle" runat="server" Text="MEDICAL PREMIUM ALLOWANCE INFORMATION" Font-Bold="True" Font-Names="Copperplate Gothic Bold" Font-Size="X-Large" Font-Underline="True"></asp:Label>
    </div>
    <br />
    <div align="center">
        <table cellspacing="20px">
            <tr>
                <td>
                    <asp:Label ID="LblFor" runat="server" Text="FOR:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <%-- <asp:DropDownList ID="DdlFor" runat="server">
                                    <asp:ListItem Value="SELF"> SELF </asp:ListItem>
                                    <asp:ListItem Value="PARENTS"> PARENTS </asp:ListItem>
                        </asp:DropDownList>
                    --%>
                    <asp:CheckBoxList ID="CheckBoxListSelfParent" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>SELF</asp:ListItem>
                        <asp:ListItem>PARENTS</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
                <td>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Please Select At least one CheckBox" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblAge" runat="server" Text="AGE GROUP:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <%-- <asp:DropDownList ID="DdlAge" runat="server">
                                    <asp:ListItem Value="SENIOR_CITIZEN"> SENIOR CITIZEN </asp:ListItem>
                                    <asp:ListItem Value="NO_SENIOR_CITIZEN"> NOT A SENIOR CITIZEN </asp:ListItem>
                        </asp:DropDownList>--%>
                    <asp:CheckBoxList ID="CheckBoxListSeniorCitizen" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>SENIOR CITIZEN</asp:ListItem>
                        <asp:ListItem>NOT A SENIOR CITIZEN</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
                <td>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Please Select At least one CheckBox" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblYear" runat="server" Text="YEAR:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtYr1" runat="server" AutoPostBack="true" ValidationGroup="YEAR1" OnTextChanged="TxtYr1_TextChanged"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TxtYr2" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtYr1" ErrorMessage="This field is compulsory." ValidationGroup="YEAR1"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator54" runat="server" ControlToValidate="txtYr1" ValidationExpression="^\d{4}$" ErrorMessage="Enter a valid Year" ValidationGroup="YEAR1"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblAmt" runat="server" Text="AMOUNT :" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtAmount" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtAmount" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TxtAmount" ErrorMessage="Enter valid number" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div align="center">

        <asp:Button ID="btnsave" runat="server" Text="SAVE" CssClass="btnCss" OnClick="btnsave_Click" />


        &nbsp;&nbsp;&nbsp;
                   <asp:Button ID="btnclear" runat="server" Text="CLEAR" CssClass="btnCss" OnClick="btnclear_Click" CausesValidation="false" />

    </div>

</asp:Content>
