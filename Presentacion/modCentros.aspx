<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modCentros.aspx.cs" Inherits="Presentacion.modCentros" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" src="js/timepicker/jquery.timepicker.js"></script>
    <script type="text/javascript" src="js/transition.min.js"></script>
  
    <link rel="stylesheet" type="text/css" href="js/timepicker/jquery.timepicker.css" />
    <link rel="stylesheet" type="text/css" href="js/dtp/jquery.datetimepicker.css"/>
 
 
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/bootstrap-datetimepicker.min.css"></script>
    <script type="text/javascript" src="js/bootstrap-datetimepicker.min.js"></script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div class="col-md-9 "Font-Size="30px" id="editPanel">

       <div class="row" >
         <div class="form-group col-md-2" >
        <asp:Label ID="lblId" runat="server"  Font-Size="15px" CssClass="label label-info center-block"  Text="ID"></asp:Label>
        <asp:TextBox ID="txtId" required = "true" ReadOnly style="text-align:center" CssClass="form-control"  runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-md-5" >
        <asp:Label ID="lblNom" runat="server"  Font-Size="15px" CssClass="label label-info center-block"  Text="NOMBRE"></asp:Label>
        <asp:TextBox ID="txtNombre"  required = "true" style="text-align:center" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-md-5">
        <asp:Label ID="lblDire" runat="server"  Font-Size="15px" CssClass="label label-info center-block"  Text="DIRECCIÓN"></asp:Label>
        <asp:TextBox ID="txtDire" required = "true" style="text-align:center"  CssClass="form-control" runat="server"></asp:TextBox>
        </div>   
       </div>
       <div class="row">
        <div class="form-group col-md-6">
        <asp:Label ID="lblTel" runat="server" Font-Size="15px" CssClass="label label-info center-block"  Text="TELEFONO"></asp:Label>
        <asp:TextBox ID="txtTelefono" required = "true" style="text-align:center"  CssClass="form-control"  runat="server"></asp:TextBox>

        </div>

        </div>

   </div>
   <div class="col-md-3">
 
        <asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server" 
            Text="GUARDAR " onclick="btnGuardar_Click" /> <br>
        <asp:Button ID="btnCancelar" runat="server"  CssClass="btn btn-danger" 
            Text="CANCELAR" onclick="btnCancelar_Click" />
              </div>

    
    </div>
    </form>
</body>
</html>
