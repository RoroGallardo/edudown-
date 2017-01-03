<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aHora.aspx.cs" Inherits="Presentacion.aHora" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript" src="js/timepicker/jquery.timepicker.js"></script>
    <link rel="stylesheet" type="text/css" href="js/timepicker/jquery.timepicker.css" />
    <script type="text/javascript" src="js/timepicker/lib/bootstrap-datepicker.js"></script>
    <link rel="stylesheet" type="text/css" href="js/timepicker/lib/bootstrap-datepicker.css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
<h2>AGREGAR HORA</h2>
    <div class="container">

        <hr />
                <div class="col-md-5">   

                   <asp:Label ID="lblRut" Font-Size="15px" runat="server" CssClass="label label-info center-block" Text="INGRESE EL RUT DEL PACIENTE"></asp:Label>
                    <asp:TextBox ID="txtRut" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorRut" CssClass="text-danger" runat="server" ErrorMessage="EL RUT ES OBLIGATORIO" ControlToValidate="txtRut"></asp:RequiredFieldValidator>
                    <asp:Button ID="btnRut" Font-Size="15px" runat="server" Text="BUSCAR"  onclick="btnBuscar_Click" CssClass="btn btn-default" />
                    
                        <asp:Label ID="Label4" Font-Size="15px" runat="server" Text="NOMBRE"  CssClass="label label-info center-block" ></asp:Label>
                        <asp:TextBox ID="txtNombre" ReadOnly ="true" CssClass="form-control" runat="server" ></asp:TextBox>
                        <asp:Label ID="Label1" Font-Size="15px" runat="server" Text="EDAD" CssClass="label label-info center-block" ></asp:Label>
                        <asp:TextBox ID="txtEdad" ReadOnly ="true" CssClass="form-control" runat="server" ></asp:TextBox>
                        <asp:Label ID="Label2" Font-Size="15px" runat="server" Text="N° DE FICHA" CssClass="label label-info center-block" ></asp:Label>
                        <asp:TextBox ID="txtFicha" ReadOnly ="true" CssClass="form-control" runat="server" ></asp:TextBox>
                        <asp:Label ID="Label3" Font-Size="15px" runat="server" CssClass="control-label" Text="SELECCIONE DOCTOR"></asp:Label>                       
                        <asp:DropDownList ID="ddpDoctores" CssClass="form-control" runat="server"></asp:DropDownList>
                        <h4>HORA DE INICIO SELECCIONADA</h4>
                        <div class="input-group" >
                        <asp:TextBox id="txtInicio" type="text" ReadOnly ="true" CssClass="form-control"     runat="server"></asp:TextBox>
                         <span class="input-group-addon"><span class="glyphicon glyphicon-time   "></span></span>
                        </div>
                        <h4>SELECCIONA LA HORA DE TERMINO</h4>
                        <div class="input-group" >
                        <asp:TextBox id="basicExample"     type="text" class="time"  CssClass="form-control"   runat="server"></asp:TextBox>
                         <span class="input-group-addon"><span class="glyphicon glyphicon-time   "></span></span>
                        </div>
                        <script type ="text/javascript">
                            $(function () {
                                $('#Main_basicExample').timepicker();
                            });
                        </script>
                </div>
        <asp:Button ID="btnAgregar" runat="server" Text="AGREGAR"  onclick="btnAgregar_Click" CssClass="btn btn-default center-block" />
        <!--- Sign in end  -->
    </div>
    </div>
    </form>
</body>
</html>
