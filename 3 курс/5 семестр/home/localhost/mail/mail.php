<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>Рассылка писем на Email</title>
  <link rel="stylesheet" href="style.css"> 
</head>
<body>
<div class="email">
  <div class="text">
    <p>Введите тему письма</p>
    <p>Введите адрес отправителя</p>
    <p>Выберите базу Email адресов в формате csv</p>
    <p>Выберите письмо в формате html</p>
  </div>
  <div class="input">
    <form action="" method="POST" enctype="multipart/form-data">
<input type="text" name="subject" required><br>  
<input type="text" name="email" required><br>
 <input type="file" name="address" accept='.csv' required><br>
 <input type="file" name="text" accept='.html' required><br>
  <input type="submit" name="submit" value="отправить">
 </div>
 
  </form>
  
</div>
</body>
</html>


<?php
// несколько получателей
if(isset($_POST['submit'])){

  $subject = $_POST['subject'];
  $email = $_POST['email'];
  $address = file_get_contents($_FILES['address']['tmp_name']);
  $address= explode("\n", $address);
  $j = count($address)-1;
 
  $message = file_get_contents($_FILES['text']['tmp_name']);
  for ($i=0; $i <$j ; $i++) { 
    $to = $address[$i];
    $headers  = 'MIME-Version: 1.0' . "\r\n";
    $headers .= 'Content-type: text/html; charset=utf-8' . "\r\n";
    $headers .= 'From:  <'.$email.'>' . "\r\n";
    mail($to, $subject, $message, $headers);
  }
  echo '<script type="text/javascript">alert("Готово")</script>';

  
  
  
  // Where the file is going to be placed
}


?>