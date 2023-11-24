<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Lab3.WebForm1" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        *{
            font-family:Verdana;
            font-size:large;
            padding:5px;
        }
        .auto-style1 {
            background-color: #66FFFF;
            width: 100%;
        }
        .auto-style2 {
            width: 584px;
        }
        .auto-style3 {
            width: 584px;
            height: 54px;
        }
        .auto-style4 {
            height: 54px;
        }
        .auto-style5 {
            width: 584px;
            height: 64px;
        }
        .auto-style6 {
            height: 64px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />

            <table class="auto-style1">
                <tr>
                    <td colspan="2" style="text-align:center">Student formStudent form</td>
                </tr>
                <tr>
                    <td class="auto-style2">StudentPK</td>
                    <td>
                        <asp:Label ID="LabStudentPK" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Name</td>
                    <td>
                        <asp:TextBox ID="TextBoxName" runat="server" MaxLength="20" Width="350px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Surname</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBoxSurname" runat="server" MaxLength="30" Width="350px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td class="auto-style3">Student no</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBoxStudentNo" runat="server" MaxLength="6"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td class="auto-style5">
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" Width="150px" />
                     </td>
                    <td class="auto-style6">
                        <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" Width="150px" />
                     </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" Width="150px" />
                    </td>
                    <td class="auto-style6">
                        <asp:Button ID="btnUpdate" runat="server" Enabled="False" Text="Update" Width="150px" OnClick="btnUpdate_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
            </table>

            <br />
        </div>
    </form>
</body>
</html>
