<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/Control/DateTimePicker.ascx" TagName="DateTimePicker" TagPrefix="DateTime" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Date Time Picker</title>
    <link href="CSS/bootstrap-combined.min.css" rel="stylesheet" type="text/css" />
    <link href="CSS/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />

    <script src="Script/jquery-1.10.2.min.js" type="text/javascript"></script>

    <script src="Script/bootstrap.min.js" type="text/javascript"></script>

    <script src="Script/bootstrap-datetimepicker.min.js" type="text/javascript"></script>

    <script src="Script/bootstrap-datetimepicker.pt-BR.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            Select DateTime :
                        </td>
                        <td>
                 
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="lblMessage" runat="server" Style="color: Red;" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            &nbsp;<asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
