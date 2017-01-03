<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modUsuario.aspx.cs" Inherits="Presentacion.modUsuario" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MODIFICA USUARIO</title>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript" src="timepicker/jquery.timepicker.js"></script>
    <link rel="stylesheet" type="text/css" href="timepicker/jquery.timepicker.css" />
    <script type="text/javascript" src="timepicker/lib/bootstrap-datepicker.js"></script>
    <link rel="stylesheet" type="text/css" href="timepicker/lib/bootstrap-datepicker.css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div class="col-md-9" id="editPanel">

       <div class="row" >
         <div class="form-group col-md-2" >
        <asp:Label ID="lblId" runat="server" CssClass="label label-info center-block" Font-Size="15px"  Text="ID"></asp:Label>
        <asp:TextBox ID="txtId" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-md-5" >
        <asp:Label ID="lblUser" runat="server" CssClass="label label-info center-block" Font-Size="15px"  Text="USERNAME"></asp:Label>
        <asp:TextBox ID="txtUserName" required = "true" style="text-align:center"  CssClass="form-control"  runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-md-5">
        <asp:Label ID="lblPass" runat="server" CssClass="label label-info center-block" Font-Size="15px" Text="PASSWORD"></asp:Label>
        <asp:TextBox ID="txtPass" required = "true" style="text-align:center" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
        </div>   


       </div>

       <div class="row">
        
        
        <div class="form-group col-md-6">

        <asp:Label ID="lblPer" Visible="false" runat="server" CssClass="label label-info center-block" Font-Size="15px"  Text="PERSONA"></asp:Label>
        <asp:TextBox ID="txtPersona" Visible="false"  CssClass="form-control"  runat="server"></asp:TextBox>

        </div>

       <div class="form-group col-md-6 ">
        <asp:Label ID="lblTipo" runat="server" CssClass="label label-info center-block" Font-Size="15px"  Text="TIPO DE USUARIO"></asp:Label>
        <asp:DropDownList ID="ddlTipos"  CssClass="form-control" runat="server">
        </asp:DropDownList>

        </div>

        </div>

   </div>
   <div class="col-md-3">
 
        <asp:Button ID="btnGuardar" CssClass="btn btn-success center-block" runat="server" 
            Text="GUARDAR " onclick="btnGuardar_Click" /> <br>
        <asp:Button ID="btnCancelar" runat="server"  CssClass="btn btn-danger center-block" 
          Text="CANCELAR" onclick="btnCancelar_Click" />
              </div>
    </div>
    </form>
</body>
</html>
