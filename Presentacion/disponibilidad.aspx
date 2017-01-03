<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="disponibilidad.aspx.cs" Inherits="Presentacion.disponibilidad" %>
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
    <div class="container" style="text-align:center;">
    
    <div class=" col-md-3 pull-left ">
   <div>
    <h5>SELECCIONA TIPO TRATAMIENTO</h5>
       <asp:DropDownList ID="cmbTrataminetos" CssClass="dropdown success form-control" runat="server"></asp:DropDownList>
    </div>
<br>
    <div>
       <asp:Calendar ID="cldFecha" CssClass=" " runat="server"></asp:Calendar>
    </div>
     <div>
     <div class="demo">
        <h4>SELECCIONA LA HORA</h4>
         <div class="input-group">
            <asp:TextBox   id="basicExample"  type="text"  CssClass="time form-control "   runat="server"></asp:TextBox>
           <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
         </div>
     </div>

     <script type ="text/javascript">
         $(function () {
             $('#Main_basicExample').timepicker();
         });
     </script>
    </div>

    <br><br>
    <div>
      <asp:Button ID="btnConsultar" runat="server" CssClass="btn btn-success btn-block" 
                                Text="CONSULTAR" onclick="btnConsultar_Click" />
    </div>  
  </div> 

  <div class =" ">
  
    <div class =" col-md-5">

    <div  class="table-responsive success">
        <asp:Label ID="lblTitleOcupados" CssClass="label label-danger center-block" runat="server" Text="BOXS OCUPADOS"></asp:Label>
         <asp:GridView ID="grvOcupados" CssClass="table table-bordered success "  
            runat="server" Visible="true" >
         </asp:GridView>
    </div>
<br>
    <div  class="table-responsive  success">
        <asp:Label ID="lblTitleLibres" CssClass="label label-success center-block" runat="server" Text="BOXS LIBRES"></asp:Label>
        <asp:GridView ID="grvLibres" CssClass="table table-bordered success "  
            runat="server" onselectedindexchanged="grvLibres_SelectedIndexChanged" 
            onrowcommand="grvLibres_RowCommand" >
            <Columns>
                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-success" 
                    CommandName="agendarHora" Text="AGENDAR" >
<ControlStyle CssClass="btn btn-success"></ControlStyle>
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
    </div>

    <div  class="table-responsive success">
        <asp:Label ID="lblTitleGral" CssClass="label label-info center-block" runat="server" Text="TODOS LOS BOXS"></asp:Label>
        <asp:GridView ID="grvGral" CssClass="table table-bordered success "  runat="server" Visible="true" >
        </asp:GridView>
    </div>
   </div>
  </div>


    </div>
</asp:Content>
