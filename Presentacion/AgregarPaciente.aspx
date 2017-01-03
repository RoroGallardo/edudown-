<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarPaciente.aspx.cs" Inherits="Presentacion.AgregarPaciente" %>
<head id="Head1" runat="server">
    <title>AGREGAR PACIENTE</title>
      <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript" src="timepicker/jquery.timepicker.js"></script>
    <link rel="stylesheet" type="text/css" href="timepicker/jquery.timepicker.css" />
    <script type="text/javascript" src="timepicker/lib/bootstrap-datepicker.js"></script>
    <link rel="stylesheet" type="text/css" href="timepicker/lib/bootstrap-datepicker.css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
      <div class="container col-md-8">
<div class ="row">
<asp:Label ID="lblSuccess" runat="server" CssClass="label label-success center-block" Font-Size="15px" Visible="false" Text=" "></asp:Label>
      <asp:Label ID="lblError" runat="server" CssClass="label label-danger center-block" Visible="false" Text=" "></asp:Label>
<div class="form-group">
    <asp:Label ID="Label1" CssClass="label label-info center-block" Font-Size="15px" runat="server" Text="Nombre"></asp:Label>    
    <asp:TextBox ID="txtNombre" required = "true" style="text-align:center"  required="" CssClass="form-control"  runat="server"></asp:TextBox>
    
</div>
<div class="form-group">
    <asp:Label ID="Label2" CssClass="label label-info center-block" runat="server" Font-Size="15px" Text="Rut"></asp:Label>
    <asp:TextBox ID="txtRut" required = "true" style="text-align:center"  required="" CssClass="form-control"  runat="server"></asp:TextBox>
</div>
<div class="form-group">
    <asp:Label ID="Label3" runat="server" CssClass="label label-info center-block" Font-Size="15px"  Text="Apellido"></asp:Label>
    <asp:TextBox ID="txtApellido" required = "true" style="text-align:center"   required="" CssClass="form-control"  runat="server"></asp:TextBox>
</div>
<div class="form-group">
    <asp:Label ID="Label4" runat="server" CssClass="label label-info center-block" Font-Size="15px"  Text="Edad"></asp:Label>
    <asp:TextBox ID="txtEdad" required = "true" style="text-align:center"  required="" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Button ID="btnAgregar" runat="server" 
        CssClass="btn btn-success center-block" Text="AGREGAR PACIENTE" 
        onclick="btnAgregar_Click"   />
</div>

</div>

</div>
</form>

</body>
</html>