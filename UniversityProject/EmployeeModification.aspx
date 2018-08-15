<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="EmployeeModification.aspx.cs" Inherits="UniversityProject.EmployeeModification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <link rel="stylesheet" type="text/css" href="UniStyle.css" />
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
            .auto-style1 {
                width: 93px;
            }
    </style>
    <br/>
    <div style="float:center; text-align:center; text-decoration: underline; height:10%;">
        <asp:label ID="lblEmpInfo"  runat="server" text="EMPLOYEE MODIFICATION" Font-Names="Copperplate Gothic Bold" Font-Size="Large" Font-Bold="True"></asp:label>
     </div> 
    <br />

    <div style="height:430px">
        <div style="float:left; width:50%">
            <table cellspacing="15px">
                <tr>
                    <td>
                        <asp:Label ID="lblEmpID" runat="server" Text="EMPLOYEE ID:" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="lblEmployeeId" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td colspan="3">

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmpName" runat="server" Text="EMPLOYEE NAME:" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtEmpName" runat="server" ErrorMessage="Enter Employee name " ControlToValidate="txtEmpName" ValidationGroup="UPDATE"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmpName" ErrorMessage="Please enter a valid name" ValidationExpression="^[a-zA-Z\s]+$" ValidationGroup="UPDATE"></asp:RegularExpressionValidator>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSex" runat="server" Text="SEX :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td class="auto-style1" colspan="2">
                        <asp:RadioButton ID="rbMale" runat="server" GroupName="Sex" AutoPostBack="true"  Text="Male" CssClass="lblStyle" />
                        <asp:RadioButton ID="rbFemale" runat="server" GroupName="Sex" AutoPostBack="true" Text="Female" CssClass="lblStyle" />
                    </td>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPF" runat="server" Text="P. F. No. :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtPF" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="txtPF" ErrorMessage="Please enter P.F. Number" ValidationGroup="UPDATE"></asp:RequiredFieldValidator>
                    </td>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDOB" runat="server" Text="D.O.B. :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td class="auto-style1" colspan="3">
                        <asp:DropDownList ID="ddlDOBday" runat="server">   </asp:DropDownList>
                        <asp:DropDownList ID="ddlDOBmon" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="ddlDOByear" runat="server"> </asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
                <tr>
                     <td>
                        <asp:Label ID="lblDOJ" runat="server" Text="D.O.J. :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td class="auto-style1" colspan="3">
                        <asp:DropDownList ID="ddlDOJday" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="ddlDOJmon" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="ddlDOJyear" runat="server"></asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNDL" runat="server" Text="N.D.L. :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td class="auto-style1" colspan="3">
                        <asp:DropDownList ID="ddlNDLday" runat="server"></asp:DropDownList>
                         <asp:DropDownList ID="ddlNDLmon" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="ddlNDLyear" runat="server"></asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDOR" runat="server" Text="D.O.R. :" CssClass="lblStyle"></asp:Label>
                    </td>
                     <td class="auto-style1" colspan="3">
                        <asp:DropDownList ID="ddlDORday" runat="server"></asp:DropDownList>
                         <asp:DropDownList ID="ddlDORmon" runat="server"></asp:DropDownList>
                         <asp:DropDownList ID="ddlDORyear" runat="server"></asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFacID" runat="server" Text="FACULTY:" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlFacName" runat="server" DataTextField="FACNAME" DataValueField="FACNAME" ><%--DataSourceID="SqlDataSource1" --%> </asp:DropDownList>
                        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityDatabaseConnectionString %>" SelectCommand="SELECT [FACNAME] FROM [FACULTY_PROFILE$]"></asp:SqlDataSource> --%>
                    </td>
                    <td colspan="3"></td>
                </tr>
              
                <tr>
                    <td>
                        <asp:Label ID="lblDeptID" runat="server" Text="DEPARTMENT:" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlDeptName" runat="server" DataTextField="DEPTNAME" DataValueField="DEPTNAME"><%-- DataSourceID="SqlDataSource2" --%></asp:DropDownList>
                        <%-- <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityDatabaseConnectionString %>" SelectCommand="SELECT [DEPTNAME] FROM [DEPT_PROFILE$]"></asp:SqlDataSource>--%>
                    </td>
                    <td colspan="3"></td>
                </tr>
            </table>
        </div>


        <div style="float:right; width:50%;">
            <table cellspacing="15px">
                <tr>
                    <td>
                        <asp:Label ID="lblDesignation" runat="server" Text="DESIGNATION:" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter Designation"  ControlToValidate="txtDesignation" ValidationGroup="UPDATE"></asp:RequiredFieldValidator>
                    </td>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblGrade" runat="server" Text="GRADE :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtGrade" runat="server"></asp:TextBox>
                     </td>
                    <td colspan="3"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPayScale" runat="server" Text="PAY SCALE:" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPayScale" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter Pay Scale" ControlToValidate="txtPayScale" ValidationGroup="UPDATE"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:regularexpressionvalidator runat="server" errormessage="Please enter a valid number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ControlToValidate="txtPayScale"></asp:regularexpressionvalidator>
                    </td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPhone" runat="server" Text="PHONE :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="3"></td>
                </tr>
                <tr>
                    <td>
                    <asp:Label ID="lblMobile" runat="server" Text="MOBILE :" CssClass="lblStyle"></asp:Label>
                        </td>
                    <td>
                        <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatortxtMobile" runat="server" ErrorMessage="Enter a valid mobile number" ControlToValidate="txtMobile" ValidationExpression="(\d*-)?\d{10}"  ValidationGroup="UPDATE"></asp:RegularExpressionValidator>
                    </td>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPan" runat="server" Text="PAN NO. :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPan" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtPan" runat="server" ErrorMessage="Enter Pan number " ControlToValidate="txtPan"  ValidationGroup="UPDATE"></asp:RequiredFieldValidator>
                    </td>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblBankAccNo" runat="server" Text="BANK ACC. NO.:" CssClass="lblStyle"></asp:Label> 
                    </td>
                    <td>
                        <asp:TextBox ID="txtBankAccNo" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="3"></td>
                </tr>
                <tr>
                    <td>
                    <asp:Label ID="lblPensionCpf" runat="server" Text="PENSION/CPF:" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:RadioButton ID="rbPension" runat="server" GroupName="PensionCpf" AutoPostBack="true"  Text="PENSION" CssClass="lblStyle"/>
                        <asp:RadioButton ID="rbCpf" runat="server" GroupName="PensionCpf" AutoPostBack="true" Text="CPF" CssClass="lblStyle"/>
                        <asp:RadioButton ID="rbNewPension" runat="server" GroupName="PensionCpf" AutoPostBack="true" Text="NEW PENSION SCHEME" CssClass="lblStyle"/>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDeath" runat="server" Text="DEATH ON:" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlDeathDay" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="ddlDeathMon" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="ddlDeathYear" runat="server"></asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblVrs" runat="server" Text="V.R.S. ON:" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlVrsDay" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="ddlVrsMon" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="ddlVrsYear" runat="server"> </asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
    </div>

    <div align="center">
        <asp:Button ID="btnSave" runat="server" Text="EDIT" OnClick="btnSave_Click" ValidationGroup="UPDATE"  CssClass="btnCss"/>
        <asp:Button ID="btnCancel" runat="server" Text="CANCEL" OnClick="btnCancel_Click" CausesValidation="false" CssClass="btnCss" />
    </div>


</asp:Content>
