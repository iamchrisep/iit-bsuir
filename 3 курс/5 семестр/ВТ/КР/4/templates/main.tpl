<!DOCTYPE html>
 <html>

 <head>
     <meta charset="utf-8" />
     <!--[if lt IE 9]><script src="https://cdnjs.cloudflare.com/ajax/libs/html5shiv/3.7.3/html5shiv.min.js"></script><![endif]-->
     <title>4</title>
     <meta name="keywords" content="{HEADER_KEYWORDS}" />
     <meta name="description" content="{HEADER_DESCRIPTION}" />
     <link href="css/style.css" rel="stylesheet">
 </head>

 <body>
     <div class="wrapper">
         {LOGO}
         <div class="container">
             <aside class="left-sidebar">
               Сейчас: {TODAY_D}.{TODAY_M}.{TODAY_Y} {NOW_H}:{NOW_M}:{NOW_S}

               {MAIN_MENU}

                 <div class="login">
                     <form class="" action="index.html" method="post">
                         <label for="login">Логин:</label>
                         <input id="login" type="text" />
                         <br />
                         <br />
                         <label for="password">Пароль:</label>
                         <input id="password" type="password" />
                         <br />
                         <br />
                         <button>Войти</button>
                     </form>
                 </div>
             </aside>
             <!-- .left-sidebar -->

             <aside class="right-sidebar">
                 {news}
             </aside>
             <!-- .right-sidebar -->


             <main class="content" style="background: {main_color};">
                 <p>
                   {text}
                 </p>
             </main>
             <!-- .content -->

             <div class="contacts" style="background: {copyright_color};">
                 <p>&copy; 2007-2008, Название фирмы.</p>
                 <p>Тел. 111-22-33, адрес: ул. Имени-кого-то, дом 999</p>
             </div>

         </div>
         <!-- .container-->

         <footer class="footer">
             <a href="#"><img src="images/image1.bmp" /></a>
             <a href="#"><img src="images/image1.gif" /></a>
             <a href="#"><img src="images/image3.bmp" /></a>
         </footer>
         <!-- .footer -->
     </div>
     <!-- .wrapper-->

     <script src="js/jquery-3.2.1.min.js"></script>
     <script src="js/script.js"></script>
 </body>

 </html>
