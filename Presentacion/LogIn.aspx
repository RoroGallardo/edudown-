<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Presentacion.LogIn" %>
 
<head runat="server">
    <title>LOGIN</title>
     <link href="css/bootstrap.min.css" rel="stylesheet" />
     <link href="css/login.css" rel="stylesheet" />
     <link href="css/animated.css" rel="stylesheet" />

     <script type="text/javascript" src="js/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" src="js/timepicker/jquery.timepicker.js"></script>
    <script type="text/javascript" src="js/transition.min.js"></script>
  
    <link rel="stylesheet" type="text/css" href="js/timepicker/jquery.timepicker.css" />
    <link rel="stylesheet" type="text/css" href="js/dtp/jquery.datetimepicker.css"/>
 
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/bootstrap-datetimepicker.min.css"></script>
    <script type="text/javascript" src="js/bootstrap-datetimepicker.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <br><br><br><br>
    <div class="container fadeIn animated">
        <div class="card card-container  ">
            <!-- <img class="profile-img-card" src="//lh3.googleusercontent.com/-6V8xOA6M7BA/AAAAAAAAAAI/AAAAAAAAAAA/rzlHcD0KYwo/photo.jpg?sz=120" alt="" /> -->
            <img id="profile-img" class="profile-img-card" src="//ssl.gstatic.com/accounts/ui/avatar_2x.png" />
            <p id="profile-name" class="profile-name-card"></p>
            <form class="form-signin">
                <span id="reauth-email" class="reauth-email"></span>
                  <asp:TextBox ID="txtUsername" CssClass="form-control" placeholder="USERNAME" requiered runat="server"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" CssClass="text-danger"  runat="server" ErrorMessage="CAMPO OBLIGATORIO" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
                  <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="PASSWORD" runat="server" TextMode="Password"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" CssClass="text-danger" runat="server" ErrorMessage="CAMPO OBLIGATORIO" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                  <asp:Button ID="btnIngresar" runat="server" Text="Login"  onclick="btnIngresar_Click" CssClass="btn btn-lg btn-primary btn-block btn-signin" />

            </form> 
        
        </div> 
    </div> 
 













 
    </form>
</body>
</html>
