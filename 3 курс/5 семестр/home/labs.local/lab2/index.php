<html>
<head>
    <meta http-equiv="content-type" content="text/html;charset=utf-8" />
    <title>Лабораторная работа 2</title>
</head>
<body>
<?php
echo 'Версия и название ОС: ';
echo php_uname('s').' '.php_uname('r').' '.php_uname('v');

echo '<br><br>';

//------------------------------------------------------------------------------------------------------
echo '<b>1. Объявить переменные следующих типов: целочисленную, строковую, дробную, логическую, массив.</b><br><br>';
$int = 3;
echo "целочисленная - $int <br>";

$str = 'БГУИР';
echo "строковая - $str <br>";

$float = 3.12;
echo "дробная - $float <br>";

$bool_t = true;
echo "логическая (true) - $bool_t <br>";
$bool_f = false;
echo "логическая (false) - $bool_f <br>";

echo "массив:";
$arr = array();
$arr[1] = 'БГУИР';
$arr[] = 'ИИТ';
$arr[] = '581072';
$arr[] = 'Лисовский';
echo '<pre>';
print_r($arr);
echo '</pre>';
/*
foreach ($arr as $i => $value)
	echo "[$i] = $value <br>";
*/
	
echo '<br><br>';
//------------------------------------------------------------------------------------------------------
echo '<b>2. Объявить переменные $a=555 и $b="ZZZ" и сложить их: а) как числа, б) как строки. Результат сложения не помещать в новую переменную, а сразу выводить на экран.</b><br><br>';
$a = 555;
echo "a - $a <br>";
$b = "ZZZ";
echo "b - $b <br>";

echo 'Сложение чисел - ';
echo $a + $b;
echo '<br>';

echo 'Сложение строк - ';
echo $a . $b;
echo '<br>';

echo '<br>';

//------------------------------------------------------------------------------------------------------
echo '<b>3. Есть три сотрудника. Объявить двухмерный массив, первый уровень которого пронумерован, начиная с нуля, а второй уровень содержит элементы name, phone, email, в которых хранятся соответствующие данные вышеназванных сотрудников.</b><br><br>';
$employees = array();
$employees[] = array(
  'name'  => 'Иванов',
  'phone' => '111-22-33',
  'email' => 'ivanov@domain.com');
$employees[] = array(
  'name'  => 'Петров',
  'phone' => '112-24-36',
  'email' => 'petrov@domain.com');
$employees[] = array(
  'name'  => 'Сидоров',
  'phone' => '113-25-37',
  'email' => 'sidorov@domain.com');

echo '<pre>';
print_r($employees);
echo '</pre>';

/*foreach ($employees as $i => $n)
{
  echo "[$i] : ";
  foreach ($n as $i => $row) 
  {
    echo "[<i>$i</i>] - $row ";
    foreach ($row as $i => $row2) 
	{
      echo "[<i>$i</i>] - $row2 ";
    }   
  }        
  echo "<br>";
}*/

echo "<br>";

//------------------------------------------------------------------------------------------------------
echo '<b>4. Дан массив, содержащий элементы: 1, 2, "A", 3.764, 34, "B", 12. Объявить этот массив, проанализировать его содержимое и удалить из него все элементы, не являющиеся целыми или дробными числами.</b><br><br>';

$arr4 = array(1, 2, "A", 3.764, 34, "B", 12);
echo "Исходные данные: <br>";
print_r($arr4);

foreach($arr4 as $i => $val)
{
	if (!is_numeric($val))
	{
		unset($arr4[$i]);
	}
}
echo "<br>";
echo "Обработанные данные: <br>";
print_r($arr4);

echo "<br><br>";

//------------------------------------------------------------------------------------------------------
echo '<b>5. Сгенерировать HTML-таблицу, состоящую из трёх колонок и 1000 строк. В первой колонке разместить номера строк таблицы. Цвет каждой строки таблицы должен изменяться по алгоритму: R+1, G+1, B+1, начиная с 000000. Т.е.: первая строка: 000000, вторая – 010101, третья -020202 и т.д.</b><br><br>';
for($i=0; $i<1000; $i++)
{
$clr = sprintf('%02X', $i%0X100);
echo '
<table border="1">
	<tr>
		<td width="100">'.($i+1).'</td>
		<td width="100" bgcolor="#'.$clr.$clr.$clr.'"></td>
		<td width="100" ><font face="Consolas">'.$clr.$clr.$clr.'</font></td>
	</tr>
</table>
';
}
?>
<br><br>



<?php
if (isset($_POST) && count($_POST) != 0) {
    /*echo '<pre>';
    print_r($_POST);
    echo '</pre>';*/

	$file = 'data.txt';
	$current = file_get_contents($file);
	foreach($_POST as $i => $val)
	{
		$current .= "$i=\"$val\"\n";
	}
	file_put_contents($file, $current);
	
	$_POST = array();
}
?>


<form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="POST">
	Марка: <input type="text" name="car" /> <br>
	Модель: <input type="text" name="model" /> <br>
	Пробег: <input type="number" name="distance" /> <br>
	Двигатель: <input type="number" name="engine" min="0" max="50" step="0.1" /> <br>
	Цена: <input type="number" name="cost" /> <br>
	<input type="submit" value="Добавить">
</form>

</body>
