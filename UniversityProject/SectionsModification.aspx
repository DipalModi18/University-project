<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeFile="SectionsModification.aspx.cs" Inherits="UniversityProject.SectionsModification" %>
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
       <asp:label ID="LblTitle" runat="server" text="SECTION WITH INFORMATION MODIFICATION" Font-Bold="True" Font-Names="Copperplate Gothic Bold" Font-Size="X-Large" Font-Underline="True"></asp:label>
    </div>
    <br />
    <div align="center">
            <table cellspacing="20px">
                <tr>
                    <td>
                        <asp:Label ID="Lblyear" runat="server" Text="NUMBER:" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LblYrDis" runat="server" Text="" CssClass="lblStyle"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblName" runat="server" Text="NAME:" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LblNameDis" runat="server" Text="" CssClass="lblStyle"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="LblAmount" runat="server" Text="AMOUNT:" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtAmount" runat="server"></asp:TextBox>
                    </td>
                     <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtAmount" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
        </td>
               <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtAmount" ErrorMessage="Enter valid number" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>  
                </td>
                </tr>
            </table>
    </div>
    <br />
    <div align="center">
            
                   <asp:button ID="btnEdit" runat="server" text="EDIT"  CssClass="btnCss" OnClick="btnEdit_Click"  />
                   

    &nbsp;&nbsp;&nbsp;
                   <asp:button ID="btnclear" runat="server" text="CANCEL"  CssClass="btnCss" CausesValidation="false" OnClick="btnclear_Click"/>

    </div>

</asp:Content>
