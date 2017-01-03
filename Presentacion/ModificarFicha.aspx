<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarFicha.aspx.cs" Inherits="Presentacion.ModificarFicha" %>

<head id="Head2" runat="server">
    <title>MODIFICAR FICHA</title>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript" src="timepicker/jquery.timepicker.js"></script>
    <link rel="stylesheet" type="text/css" href="timepicker/jquery.timepicker.css" />
    <script type="text/javascript" src="timepicker/lib/bootstrap-datepicker.js"></script>
    <link rel="stylesheet" type="text/css" href="timepicker/lib/bootstrap-datepicker.css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />

</head>
<body>
    <form id="form2" runat="server">
      <div class="container col-md-8">
<div class ="row">
<asp:Label ID="Label5" runat="server" CssClass="label label-success center-block" Font-Size="15px" Visible="false" Text=" "></asp:Label>
      <asp:Label ID="Label6" runat="server" CssClass="label label-danger center-block" Visible="false" Text=" "></asp:Label>
<div class="form-group">
    <asp:Label ID="Label7" CssClass="label label-info center-block" Font-Size="15px" runat="server" Text="Fecha Inicio"></asp:Label>    
    <asp:Calendar ID="FechaInicio" runat="server"></asp:Calendar>
    
</div>
<div class="form-group">
    <asp:Label ID="Label8" CssClass="label label-info center-block" runat="server" Font-Size="15px" Text="Rut"></asp:Label>
    <asp:TextBox ID="txtRut" required = "true" style="text-align:center" CssClass="form-control"  runat="server"></asp:TextBox>
</div>
<div class="form-group">
    <asp:SqlDataSource ID="SqlPatologia" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
        SelectCommand="SELECT &quot;IDPATOLOGIA&quot;, &quot;NOMBRE&quot; FROM &quot;PATOLOGIA&quot;"></asp:SqlDataSource>
    <asp:Label ID="Label9" runat="server" CssClass="label label-info center-block" Font-Size="15px"  Text="Patologia"></asp:Label>
    <asp:DropDownList ID="drdPatologia" CssClass="form-control" runat="server" DataSourceID="SqlPatologia" 
        DataTextField="NOMBRE" DataValueField="IDPATOLOGIA">
    </asp:DropDownList>
</div>
<div class="form-group">
    <asp:SqlDataSource ID="SqlTratamiento" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
        SelectCommand="SELECT * FROM &quot;TRATAMIENTO&quot;"></asp:SqlDataSource>
    <asp:Label ID="Label10" runat="server" CssClass="label label-info center-block" Font-Size="15px"  Text="Tratamiento"></asp:Label>
    <asp:DropDownList ID="drdTratamiento" CssClass="form-control" runat="server" 
        DataSourceID="SqlTratamiento" DataTextField="TIPOTRATAMIENTO" 
        DataValueField="IDTRATAMIENTO" >
    </asp:DropDownList>
</div>
<div>
    <asp:Button ID="Button1" runat="server" 
        CssClass="btn btn-success center-block" Text="MODIFICAR FICHA" 
        onclick="btnAgregar_Click"   />
</div>

</div>

</div>
</form>

</body>
</html>
