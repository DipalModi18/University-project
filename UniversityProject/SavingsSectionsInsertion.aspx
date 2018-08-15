<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="SavingsSectionsInsertion.aspx.cs" Inherits="UniversityProject.SavingsSectionsInsertion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <br />
    <br />
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
        <table>
            <asp:label id="LblTitle" runat="server" text="SAVINGS SECTIONS INSERTION" font-bold="True" font-names="Copperplate Gothic Bold" font-size="X-Large" font-underline="True"></asp:label>
        </table>
    </div>
    <div align="center">
        <table cellspacing="20px">
            <tr>
                <td>
                    <asp:label id="lblName" runat="server" text="NAME:" cssclass="lblStyle"></asp:label>
                </td>
                <td>
                    <asp:textbox id="txtName" runat="server"></asp:textbox>
                </td>
                <td>
                    <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" controltovalidate="txtName" errormessage="This field is compulsory."></asp:requiredfieldvalidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:label id="lblAmount" runat="server" text="AMOUNT:" cssclass="lblStyle"></asp:label>
                </td>
                <td>
                    <asp:textbox id="txtAmount" runat="server"></asp:textbox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtAmount" ErrorMessage="Enter valid number" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:label id="lblYear1" runat="server" text="YEAR1:" cssclass="lblStyle"></asp:label>
                </td>
                <td>
                    <asp:textbox id="txtYear1" runat="server"></asp:textbox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TxtYear1" ErrorMessage="Enter valid number" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:label id="lblYear2" runat="server" text="YEAR2:" cssclass="lblStyle"></asp:label>
                </td>
                <td>
                    <asp:textbox id="txtYear2" runat="server"></asp:textbox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TxtYear2" ErrorMessage="Enter valid number" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                
                <td>
                    <asp:Button ID="btnInsert" runat="server" Text="INSERT" CssClass="btnCss" OnClick="btnInsert_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="CANCEL" CssClass="btnCss" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
