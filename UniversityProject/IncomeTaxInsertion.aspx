<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeFile="IncomeTaxInsertion.aspx.cs" Inherits="UniversityProject.IncomeTaxInsertion" %>

<%@ Register TagPrefix="asp" Namespace="Saplin.Controls" Assembly="DropDownCheckBoxes" %>

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
        <asp:Label ID="LblTitle" runat="server" Text="INCOME TAX INFORMATION" Font-Bold="True" Font-Names="Copperplate Gothic Bold" Font-Size="X-Large" Font-Underline="True"></asp:Label>
    </div>
    <br />
    <div align="center">
    <div style="align-content:center;" >
        <table cellspacing="20px">
            <tr>
                <td>
                    <asp:Label ID="Lblyear1" runat="server" Text="YEAR 1:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtYear1" runat="server" OnTextChanged="TxtYear1_TextChanged"></asp:TextBox>
                </td>
                 <td>
                    <asp:Label ID="lblyear2" runat="server" Text="YEAR 2:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtYear2" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtYear1" ErrorMessage="Year1 field is compulsory."></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TxtYear1" ErrorMessage="Enter valid number" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                </td>
                <td>

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
                <td colspan="2"></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblGender" runat="server" Text="GENDER:" CssClass="lblStyle"></asp:Label>
                </td>
                <%-- <td>
                    <asp:DropDownList ID="Ddlgender" runat="server">
                        <asp:ListItem Value="MALE"> MALE </asp:ListItem>
                        <asp:ListItem Value="FEMALE"> FEMALE </asp:ListItem>
                    </asp:DropDownList>
                </td>--%>
                <td>
                    <asp:CheckBoxList ID="CheckBoxListGender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>MALE</asp:ListItem>
                        <asp:ListItem>FEMALE</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
                <td>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Please Select At least one CheckBox" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                </td>
                <td colspan="3"></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblAge" runat="server" Text="AGE:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <%-- <asp:DropDownList ID="DdlAge" runat="server">
                        <asp:ListItem> SENIOR CITIZEN </asp:ListItem>
                        <asp:ListItem> NOT A SENIOR CITIZEN </asp:ListItem>
                    </asp:DropDownList>--%>
                    <asp:CheckBoxList ID="CheckBoxListAgegroup" runat="server"  RepeatDirection="Horizontal">
                        <asp:ListItem>SENIOR CITIZEN</asp:ListItem>
                        <asp:ListItem>NOT A SENIOR CITIZEN</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
                <td>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Please Select At least one CheckBox" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
                </td>
                <td colspan="3"></td>
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
                <td colspan="2"></td>
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
                <td colspan="2"></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblPer" runat="server" Text="PERCENTAGE :" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtPecent" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="%" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtPecent" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TxtPecent" ErrorMessage="Enter valid number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEduCess" runat="server" Text="EDUCATION CESS:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEduCess" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="%" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEduCess" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtEduCess" ErrorMessage="RegularExpressionValidator" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblHigherEducess" runat="server" Text="HIGHER & SECONDARY EDUCATION CESS:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtHigherEducess" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="%" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtHigherEducess" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtHigherEducess" ErrorMessage="RegularExpressionValidator" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+"></asp:RegularExpressionValidator>
                </td>
                <td></td>
            </tr>
        </table>
    </div>
    <br />
    <div align="center">

        <asp:Button ID="btnsave" runat="server" Text="SAVE" CssClass="btnCss" OnClick="btnsave_Click" />


        &nbsp;&nbsp;&nbsp;
                   <asp:Button ID="btnclear" runat="server" Text="CANCEL" CssClass="btnCss" CausesValidation="false" OnClick="btnclear_Click" />

    </div>
    </div>
</asp:Content>

