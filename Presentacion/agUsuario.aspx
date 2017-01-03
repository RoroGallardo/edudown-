<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agUsuario.aspx.cs" Inherits="Presentacion.agUsuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
   <div class ="container">
<div class="">
 <asp:Label ID="lblSuccess" runat="server" Font-Size="15px" CssClass="label label-success center-block" Visible="false" Text=" "></asp:Label>
      <asp:Label ID="lblError" runat="server" Font-Size="15px" CssClass="label label-danger center-block" Visible="false" Text=" "></asp:Label>
    <div class="form-group col-md-3 ">
    <asp:Label ID="Label4" runat="server" Font-Size="15px" CssClass="label label-info center-block" Text="USERNAME"></asp:Label>
    <asp:TextBox ID="txtUsername" required = "true" style="text-align:center"  CssClass="form-control" runat="server"></asp:TextBox>  
    </div> 
</div>
   <br>

    <div >   
    <div class="form-group col-md-3">
    <asp:Label ID="Label2" runat="server" Font-Size="15px" CssClass="label label-info center-block"  Text="PASSWORD"></asp:Label>
    <asp:TextBox ID="txtPass" required = "true" style="text-align:center"  CssClass="form-control" TextMode="Password" runat="server" ></asp:TextBox>   
    </div>

    <div class="form-group col-md-3">
    <asp:Label ID="lblTipo" runat="server"  CssClass="label label-info center-block" Font-Size="15px"  Text="TIPO USUARIO"></asp:Label>
        <asp:DropDownList ID="ddlTipo" CssClass="form-control" runat="server">      
        </asp:DropDownList>
    </div>

     <div class="form-group col-md-3">
    <asp:Label ID="Label1" runat="server" CssClass="label label-info center-block" Font-Size="15px" Text="RUT USUARIO"></asp:Label>
        <asp:DropDownList ID="ddlRut"  CssClass="form-control" runat="server">      
        </asp:DropDownList>
    </div>

    <asp:Button ID="btnGuardar" runat="server" Text="GUARDAR" CssClass="btn btn-success center-block"  
        onclick="btnGuardar_Click" />

    </div>


    </div>




    </form>
</body>
</html>
