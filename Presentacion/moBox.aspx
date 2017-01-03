<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/moBox.aspx.cs" Inherits="Presentacion.moBox" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
        <asp:Label ID="lblId" runat="server" CssClass="label label-info center-block" Font-Size="15px" Text="ID"></asp:Label>
        <asp:TextBox ID="txtId"  CssClass="form-control" ReadOnly="true"  runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-md-5" >
        <asp:Label ID="lblNombre" runat="server" CssClass="label label-info center-block" Font-Size="15px" Text="DESCRIPCION"></asp:Label>
        <asp:TextBox ID="txtDescripcion" required = "true" style="text-align:center"  CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-md-5">
        <asp:Label ID="lbltipo" runat="server" CssClass="label label-info center-block" Font-Size="15px" Text="TIPO"></asp:Label>
            <asp:DropDownList ID="ddlTipo"  CssClass="form-control"  runat="server">
            </asp:DropDownList>
        </div>   
         <div class="form-group col-md-5">
        <asp:Label ID="lblCentro" runat="server" CssClass="label label-info center-block" Font-Size="15px" Text="CENTRO MEDICO"></asp:Label>
            <asp:DropDownList ID="ddlCentro" CssClass="form-control"  runat="server" 
                DataSourceID="SqlDataSource" DataTextField="NOMBRE" DataValueField="IDCENTRO">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                SelectCommand="SELECT * FROM &quot;CENTROS&quot;"></asp:SqlDataSource>
        </div>  

       </div>

       <div class="row">
        
        
        <div class="form-group col-md-6">

        <asp:Label ID="lblTam" runat="server" CssClass="label label-info center-block" Font-Size="15px" Text="TAMAÑO"></asp:Label>
            <asp:DropDownList ID="ddlTamaño" runat="server" CssClass="form-control"  >
            </asp:DropDownList>
        </div>

        </div>

   </div>
   <div class="col-md-3 ">
 
       <div class="row">
             <asp:Button ID="btnGuardar" CssClass="btn btn-success center-block" runat="server" 
                Text="GUARDAR " onclick="btnGuardar_Click" /> <br>
            <asp:Button ID="btnCancelar" runat="server"  CssClass="btn btn-danger center-block" 
              Text="CANCELAR" onclick="btnCancelar_Click" />
       </div>
    </div>


    </div> 
    </form>
</body>
</html>
