<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma1.aspx.cs" Inherits="Laboratorinis_1.Forma1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Įkelkite duomenų failą"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Reikalingas duomenų failas (.txt)" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Patvirtinti" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            <br />
            <asp:Table ID="Table1" runat="server" Width="100%">
            </asp:Table>
        </div>
    </form>
</body>
</html>
