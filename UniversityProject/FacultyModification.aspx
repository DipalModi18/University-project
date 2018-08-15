<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="FacultyModification.aspx.cs" Inherits="UniversityProject.FacultyModification" %>

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

        </style>
    <br />
    <div style="float: center; text-align: center; text-decoration: underline; height: 10%;">
        <asp:label id="lblFacInfo" runat="server" text="FACULTY MODIFICATION" font-names="Copperplate Gothic Bold" font-size="Large" font-bold="True"></asp:label>
    </div>

    <div style="height: 50%">
        <div style="float: left; width: 50%">
            <table cellspacing="20px">
                <tr>
                    <td>
                        <asp:label id="lblFacId" runat="server" text="FACULTY ID :" cssclass="lblStyle"></asp:label>
                    </td>
                    <td>
                        <%-- <asp:DropDownList ID="ddlFacID" runat="server"></asp:DropDownList>--%>
                        <asp:label id="lblShowFacId" runat="server" text="Label"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="lblFacName" runat="server" text="FACULTY NAME :" cssclass="lblStyle"></asp:label>
                    </td>
                    <td>
                        <asp:textbox id="txtFacName" runat="server" validationgroup="UPDATE"></asp:textbox>
                    </td>
                    <td>
                        <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" errormessage="Please enter FACULTY NAME" controltovalidate="txtFacName" validationgroup="UPDATE"></asp:requiredfieldvalidator>
                    </td>
                    <td>
                        <asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" controltovalidate="txtFacName" errormessage="Please enter a valid name" validationexpression="^[a-zA-Z\s]+$" validationgroup="UPDATE"></asp:regularexpressionvalidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="lblAdd1" runat="server" text="ADDRESS 1 :" cssclass="lblStyle"></asp:label>
                    </td>
                    <td>
                        <asp:textbox id="txtAdd1" runat="server"></asp:textbox>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:label id="lblAdd2" runat="server" text="ADDRESS 2 :" cssclass="lblStyle"></asp:label>
                    </td>
                    <td>
                        <asp:textbox id="txtAdd2" runat="server"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="lblCity" runat="server" text="CITY :" cssclass="lblStyle"></asp:label>
                    </td>
                    <td>
                        <asp:textbox id="txtCity" runat="server" validationgroup="UPDATE"></asp:textbox>
                    </td>
                    <td>
                        <asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" controltovalidate="txtCity" errormessage="Please enter a valid City name" validationexpression="^[a-zA-Z\s]+$" validationgroup="UPDATE"></asp:regularexpressionvalidator>
                    </td>
                    <td>
                        <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" errormessage="Please enter City name" controltovalidate="txtCity" validationgroup="UPDATE"></asp:requiredfieldvalidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="lblPin" runat="server" text="PINCODE :" cssclass="lblStyle"></asp:label>
                    </td>
                    <td>
                        <asp:textbox id="txtPin" runat="server" validationgroup="UPDATE"></asp:textbox>
                    </td>
                    <td>
                        <asp:rangevalidator id="RangeValidator1" runat="server" controltovalidate="txtPin" errormessage="Please Enter a valid pincode" maximumvalue="999999" minimumvalue="100000" validationgroup="UPDATE"></asp:rangevalidator>
                    </td>
                    <td>
                        <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" errormessage="Please enter Pincode" controltovalidate="txtPin" validationgroup="UPDATE"></asp:requiredfieldvalidator>
                    </td>
                </tr>
            </table>
        </div>

        <div style="float: right; width: 50%">
            <table cellspacing="14px">
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="lblDean" runat="server" text="DEAN :" cssclass="lblStyle"></asp:label>
                    </td>
                    <td>
                        <asp:textbox id="txtDean" runat="server" validationgroup="UPDATE"></asp:textbox>
                    </td>
                    <td>
                        <asp:regularexpressionvalidator id="RegularExpressionValidator4" runat="server" controltovalidate="txtDean" errormessage="Please enter a valid Dean name" validationexpression="[A-Za-z]+[. ]*([A-Za-z]+[ ]*)*" validationgroup="UPDATE"></asp:regularexpressionvalidator>
                    </td>
                    <td>
                        <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" errormessage="Please enter Dean name" validationgroup="UPDATE" controltovalidate="txtDean"></asp:requiredfieldvalidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="lblRegister" runat="server" text="REGISTER :" cssclass="lblStyle"></asp:label>
                    </td>
                    <td>
                        <asp:textbox id="txtRegister" runat="server" Height="19px"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="lblFax" runat="server" text="FAX :" cssclass="lblStyle"></asp:label>
                    </td>
                    <td>
                        <asp:textbox id="txtFax" runat="server"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="lblPhone" runat="server" text="PHONE :" cssclass="lblStyle"></asp:label>
                    </td>
                    <td>
                        <asp:textbox id="txtPhone" runat="server" validationgroup="UPDATE"></asp:textbox>
                    </td>
                    <td>
                        <asp:regularexpressionvalidator id="RegularExpressionValidator5" runat="server" controltovalidate="txtPhone" errormessage="Please enter a valid Phone number" validationexpression="^[0-9]+$" validationgroup="UPDATE"></asp:regularexpressionvalidator>
                    </td>
                    <td>
                        <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" errormessage="Please enter Phone number" controltovalidate="txtPhone" validationgroup="UPDATE"></asp:requiredfieldvalidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="lblTanNo" runat="server" text="TAN NO :" cssclass="lblStyle"></asp:label>
                    </td>
                    <td>
                        <asp:textbox id="txtTanNo" runat="server"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="lblData" runat="server" text="DATA :" cssclass="lblStyle"></asp:label>
                    </td>
                    <td>
                        <asp:textbox id="txtData" runat="server"></asp:textbox>
                    </td>
                </tr>
            </table>
        </div>
    </div>


    <div>
        <table cellspacing="10px">
            <tr>
                <td></td>
            </tr>
            <tr>
                <td></td>
            </tr>
        </table>
    </div>



    <div align="center">
        <asp:button id="btnEdit" runat="server" text="EDIT" onclick="btnEdit_Click" validationgroup="UPDATE" CssClass="btnCss" />
        <asp:button id="btnCancel" runat="server" text="CANCEL" onclick="btnCancel_Click" causesvalidation="false" CssClass="btnCss" />
    </div>


</asp:Content>
