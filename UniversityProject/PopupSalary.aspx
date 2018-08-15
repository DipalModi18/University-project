<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopupSalary.aspx.cs" Inherits="UniversityProject.PopupSalary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style>
        body {
            background-color: #fff;
            font-family: Segoe UI,'Helvetica Neue';
            font-size: 18px;
        }

        * {
            box-sizing: border-box;
        }

        .gBtn {
            display: inline-block;
            text-align: center;
            border: none;
            background-color: #008000;
            background-image: -webkit-linear-gradient(top,#00cc00,#008000);
            border-radius: 2px;
            cursor: pointer;
            color: #fff;
            font-size: 16px;
            font-weight: 500;
            box-shadow: 0 2px 2px 0 rgba(0,0,0,0.14);
            transition: 0.4s;
            width: 460px;
            padding: 15px 0;
        }

            .gBtn:hover {
                background-color: #00b300;
                background-image: -webkit-linear-gradient(top,#00ff00,#00b300);
                color: #eee;
            }

        .bBtn {
            display: inline-block;
            text-align: center;
            border: 2px solid #1a8cff;
            background-color: #3399ff;
            border-radius: 2px;
            cursor: pointer;
            color: #fff;
            font-size: 16px;
            font-weight: 500;
            box-shadow: 0 2px 2px 0 rgba(0,0,0,0.14);
            transition: 0.4s;
            width: 140px;
            padding: 6px 0;
        }

            .bBtn:hover {
                border: 2px solid #66b3ff;
                background-color: #80bfff;
                color: #eee;
            }

        .txt,
        .slt {
            width: 100%;
            max-width: 400px;
            padding: 12px 10px;
            font-size: 16px;
            font-weight: 200;
            margin: 5px 0;
            border: 1px solid #ccc;
            border-radius: 3px;
            color: #0c4d6f;
            background-color: #fff;
            transition: 0.3s;
            max-width: 100%;
        }

            .txt:focus,
            .slt:focus {
                border-color: #11bbc1;
            }

        .dlg {
            display: none;
            height: 100%;
            width: 100%;
            z-index: 2000;
            position: fixed;
            top: 0;
            right: 0;
            background-color: transparent;
            overflow-y: hidden;
            transition: 0.3s;
        }

        .dlgcontent {
            margin: 0 auto 0 auto;
            padding: 0px;
            width: 100%;
            max-width: 500px;
            height: auto;
            color: #666;
            background-color: #f9f9f9;
            box-shadow: 0 4px 20px 0 rgba(0,0,0,0.2),0 6px 15px 0 rgba(0,0,0,0.18),0 4px 15px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.18);
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 18px;
        }

        .dlgheader {
            width: 100%;
            height: 80px;
            margin-bottom: 3px;
            background-color: #3399ff;
            color: #e1e1e1;
            padding: 0 5px;
            letter-spacing: 4px;
            border-top-left-radius: 4px;
            border-top-right-radius: 4px;
            font-size: 20px;
        }

        .dlgbody {
            padding: 5px 15px;
            height: auto;
        }

        .dlgfooter {
            width: 100%;
            height: 80px;
            padding: 2px 16px;
            margin-top: 3px;
            border-top: 1px solid #f2f2f2;
        }

        .dlgbtnX {
            display: inline-block;
            float: right;
            text-align: left;
            font-size: 40px;
            color: #e1e1e1;
            border: none;
            background-color: transparent;
            cursor: pointer;
            margin: 0;
            padding: 0;
        }

            .dlgbtnX:hover,
            .dlgbtnX:focus {
                outline: none;
                color: #fff;
            }

        .dlgTable {
            width: 100%;
            height: 100%;
        }

        .bodyTD {
            text-align: center;
            vertical-align: middle;
            height: 60px;
        }
            .auto-style1 {
                display: none;
                height: 100%;
                width: 100%;
                z-index: 2000;
                position: fixed;
                top: -43px;
                right: 67px;
                background-color: transparent;
                overflow-y: hidden;
                transition: 0.3s;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="dialogbox" class="auto-style1" style="display:block">
     <table class="dlgTable">
            <tr>
                <td>
                    <div class="dlgcontent">
                        <div class="dlgheader">
                            <table class="dlgTable">
                                <tr>
                                    <td class="bodyTD">
                                        <p>Salary Report Details</p>
                                    </td>
                                    <%-- <td style="width: 40px;">
                                        <input type="button" class="dlgbtnX" value="×" onclick="hide_dialog()" />
                                    </td>--%>
                                    <%-- <td style="width:40px;">
                                        <asp:Button ID="btnClose" runat="server" Text="X" />
                                    </td>--%>
                                </tr>
                            </table>
                        </div>
                        <div class="dlgbody">
                            <table class="dlgTable">
                                <tr>
                                    <td class="bodyTD" style="text-align:left">
                                        <asp:Label ID="lblMonth" runat="server" Text="Enter Month :"></asp:Label>
                                        <asp:TextBox ID="txtMonth" runat="server" CssClass="txt"></asp:TextBox>
                                    </td>
                                    <td class="bodyTD">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <%-- <td class="bodyTD" style="text-align: left;">Please enter your name and select your favorite color:
                                    </td>--%>
                                    <td class="bodyTD" style="text-align:left">
                                        <asp:Label ID="lblYear" runat="server" Text="Enter Year :"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <%-- <td class="bodyTD">
                                        <input type="text" id="txtName" class="txt" placeholder="Your Name" />
                                    </td>--%>
                                    <td class="bodyTD">
                                        <asp:TextBox ID="txtYear" runat="server" CssClass="txt"></asp:TextBox>                         
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color:red">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter a Valid Year" ControlToValidate="txtYear" ValidationExpression="^[1-9]([0-9]{3})$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color:red">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter a Valid Month (Month first 3 Initials in Capital) " ControlToValidate="txtMonth" ValidationExpression="[A-Z]{3}"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td class="bodyTD">
                                        <select id="sltColor" class="slt">
                                            <option value="">Select your favorite color</option>
                                            <option value="Black">Black</option>
                                            <option value="Red">Red</option>
                                            <option value="Green">Green</option>
                                            <option value="White">White</option>
                                            <option value="Other">Other</option>
                                        </select>
                                    </td>
                                </tr>--%>
                            </table>
                        </div>
                        <div class="dlgfooter">
                            <table class="dlgTable">
                                <tr>
                                   <%--  <td class="bodyTD">
                                        <div class="bBtn" onclick="Submit_Form()">SUBMIT</div>
                                    </td>--%>
                                    <td class="bodyTD">
                                        <asp:Button ID="Button1" runat="server" Text="SUBMIT" CssClass="bBtn" OnClick="Button1_Click" />
                                    </td>
                                    <%-- <td class="bodyTD">
                                        <div class="bBtn" onclick="hide_dialog()">CANCEL</div>
                                    </td>--%>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
