<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adUsuario.aspx.cs" Inherits="Presentacion.adUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
        <script type="text/javascript" src="js/jquery-3.1.1.min.js"></script>
        <script type="text/javascript" src="js/timepicker/jquery.timepicker.js"></script>
        <script type="text/javascript" src="js/transition.min.js"></script>
  
        <link rel="stylesheet" type="text/css" href="js/timepicker/jquery.timepicker.css" />
        <link rel="stylesheet" type="text/css" href="js/dtp/jquery.datetimepicker.css"/>
 
        <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="js/bootstrap.min.js"></script>
        <script type="text/javascript" src="js/bootstrap-datetimepicker.min.css"></script>
        <script type="text/javascript" src="js/bootstrap-datetimepicker.min.js"></script>


   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" runat="server">
</asp:Content>
     
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <div class="col-md-9 ">
    <div>
     <asp:Label ID="lblSuccess" runat="server" CssClass="label label-success center-block" Font-Size="15px" Visible="false" Text=" "></asp:Label>
      <asp:Label ID="lblError" runat="server" CssClass="label label-dangers center-block" Visible="false" Font-Size="15px" Text=" "></asp:Label>
    </div>
  <div> 
   
<div>
 
 <br><br>

 <asp:Button ID="btbAgregarr" runat="server" CssClass="btn btn-success pull-left" Text="AGREGAR USUARIO" 
            onclick="btnAgregarr_Click" />
            <div class="col-md-3"></div>
<div class="col-md-6 input-group">
         <asp:TextBox ID="texto" placeholder="BUSCAR.." CssClass= "form-control " runat="server"></asp:TextBox> 
          <span class="input-group-addon"><span class="glyphicon glyphicon-search   "></span></span>

          <script language="javascript" type="text/javascript">
              $(document).ready(function () {
                  //agregar una nueva columna con todo el texto 
                  //contenido en las columnas de la grilla 
                  // contains de Jquery es CaseSentive, por eso a minúscula
                  $(".filtrar tr:has(td)").each(function () {
                      var t = $(this).text().toLowerCase();
                      $("<td class='indexColumn'></td>")
                        .hide().text(t).appendTo(this);
                  });
                  //Agregar el comportamiento al texto (se selecciona por el ID) 
                  $("#Main_texto").keyup(function () {
                      var s = $(this).val().toLowerCase().split(" ");
                      $(".filtrar tr:hidden").show();
                      $.each(s, function () {
                          $(".filtrar tr:visible .indexColumn:not(:contains('"
                             + this + "'))").parent().hide();
                      });
                  });
              });
         </script>
 </div>
 <br>   
</div>


  <asp:GridView ID="grvGeneral" CssClass="table table-bordered filtrar table-info table-info"   runat="server" 
      onrowcommand="grvGeneral_RowCommand" onrowdeleting="grvGeneral_RowDeleting" 
            onrowupdating="grvGeneral_RowUpdating" >
        <Columns>
          <asp:ButtonField ControlStyle-CssClass="btn btn-warning " CommandName="Update" ButtonType="Button" Text="MODIFICAR" />
            <asp:ButtonField ControlStyle-CssClass="btn btn-danger " CommandName="Delete" ButtonType="Button" Text="ELIMINAR" />
        </Columns>

    </asp:GridView>


    </div>
    </div>
</asp:Content>
