<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="PayLots.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Oops ha ocurrido un error.</title>

    <style>
	@import url(https://fonts.googleapis.com/css?family=Raleway:700);



*, *:before, *:after {
  box-sizing: border-box;
}
html {
    height: 100%;
}

body{
    font-family: 'Raleway', sans-serif;
    background-color: #342643; 
    height: 100%;
}
/*body {
    background: url(https://i.imgur.com/76NZB7A.gif) no-repeat center center fixed; 
    background-size: cover;
    font-family: 'Raleway', sans-serif;
    background-color: #342643; 
    height: 100%;
}*/

.text-wrapper {
    height: 100%;
   display: flex;
   flex-direction: column;
   align-items: center;
   justify-content: center;
}

.title {
    font-size: 6em;
    font-weight: 700;
    color: #EE4B5E;
}

.subtitle {
    font-size: 40px;
    font-weight: 700;
    color: #1FA9D6;
}

.buttons {
    margin: 30px;}
    
    a.button {
        font-weight: 700;
        border: 2px solid #EE4B5E;
        text-decoration: none;
        padding: 15px;
        text-transform: uppercase;
        color: #EE4B5E;
        border-radius: 26px;
        transition: all 0.2s ease-in-out;}
        
        a.button:hover {
            background-color: #EE4B5E;
            color: white;
            transition: all 0.2s ease-in-out;
        }
    

    

</style>
</head>
<body>
    <form id="form1" runat="server">
         <div class="Container" style="margin-top:10%;">
    
    <div class="text-wrapper">
    <div class="title" data-content="404">
       Disculpe...
    </div>
     <img src="Content/Imagenes/error-page-icon.png" />
    <div class="subtitle">
        Oops, al parecer se presentó un error.
    </div>

    <div class="buttons">
        <a class="button" href="Default.aspx">Ir al Inicio</a>
    </div>
</div>
    
  </div>
    </form>
</body>
</html>
