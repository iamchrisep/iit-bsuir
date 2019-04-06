<?php
    echo php_uname();
    echo '<br />'.'<br />'.'<br />'.'<br />';
    echo '<b>Задание 1</b>';
    echo '<br />'.'<br />';
    $int = 123;
    echo $int.'<br />';
    $str = 'Строка';
    echo $str.'<br />';
    $flo = 1.23;
    echo $flo.'<br />';
    $boo = true;
    echo $boo.'<br />';
    $arr = array ('Элемент 1', 'Элемент 2', 'Элемент 3');
    foreach ($arr as $key => $value) {
        echo '['.$key.'] = '.$value.'<br />';
    }
    unset($key);
    unset($value);
    echo '<br />'.'<br />';
    echo '<b>Задание 2</b>';
    echo '<br />'.'<br />';
    $a=555;
    $b='ZZZ';
    echo $a.'<br />';
    echo $b.'<br />';
    echo $a + $b.'<br />';
    echo $a . $b.'<br />';
    echo '<br />'.'<br />';
    echo '<b>Задание 3</b>';
    echo '<br />'.'<br />';
    $arrarr = array ( 0 => array ( 'name' => 'Иванов',
                                           'phone' => '111-22-33',
                                           'email' => 'ivanov@domain.com'
                                         ),
                      1  => array ( 'name' => 'Петров',
                                           'phone' => '112-24-36',
                                           'email' => 'petrov@domain.com'
                                         ),
                      2 => array ( 'name' => 'Сидоров',
                                           'phone' => '113-25-37',
                                           'email' => 'sidorov@domain.com'
                                         )
                    );
    foreach($arrarr as $k => $v) {
        echo $k.':<br />';
        foreach($v as $key => $value) {
            echo '['.$key.'] = '.$value.'<br />';
        }
    }
    unset($key);
    unset($value);
    unset($k);
    unset($v);
    echo '<br />'.'<br />';
    echo '<b>Задание 4</b>';
    echo '<br />'.'<br />';
    $data = array(1, 2, "A", 3.764, 34, "B", 12);
    foreach ($data as $key => $value) {
        echo '['.$key.'] = '.$value.'<br />';
    }
    unset($key);
    unset($value);
    echo '<br />';
    foreach ($data as $key => $value) {
        if (!is_int($value) and !is_float($value)) {
            unset ($data[$key]) ;
        }
    }
    unset($key);
    unset($value);
    foreach ($data as $key => $value) {
        echo '['.$key.'] = '.$value.'<br />';
    }
    unset($key);
    unset($value);
    echo '<br />'.'<br />';
    echo '<b>Задание 5</b>';
    echo '<br />'.'<br />';
    echo '<table border="2" bordercolor="#000000" cellpadding="0" cellspacing="0">';
    echo '<tr>
                <th>№</th>
                <th>Цвет</th>
                <th>Значение</th>
               </tr>';
    $col = 0x00;
    for ($i = 1; $i <= 1000; $i++) {
        $cols = dechex($col);
        if (strlen($cols) == 1) {
            $cols = '0'.$cols;
        }
        $cols = strtoupper($cols.$cols.$cols);
        echo '<tr>';
        echo '<td>'.$i.'</td>';
        echo '<td style="background: #'.$cols.'; width: 70px;"></td>';
        echo '<td>'.$cols.'</td>';
        echo '</tr>';
        if ($col == 0xFF) {
            $col = 0x00;
        } else {
            $col++;
        }
    }
    echo '</table>';
    echo '<br />'.'<br />';
    echo '<b>Дополнительное задание</b>';
    echo '<br />'.'<br />';
    echo '
    <form method="post" action="index.php">
        <p>
            Name: <input type="text" name="name">
        </p>
        <p>
            Email: <input type="email" name="email">
        </p>
        <p>
            Password: <input type="password" name="password">
        </p>
        <p>
            Phone: <input type="tel" name="phone">
        </p>
        <p>
            <input type="checkbox" name="food[]" value="Пирог"> Пирог
            <input type="checkbox" name="food[]" value="Торт"> Торт
            <input type="checkbox" name="food[]" value="Кекс"> Кекс
        </p>
        <p>
            <input type="radio" name="drink" value="Сок"> Сок
            <input type="radio" name="drink" value="Чай"> Чай
            <input type="radio" name="drink" value="Кофе"> Кофе
        </p>
        <p>
            Date: <input type="date" name="date">
        </p>
        <p>
            Color: <input type="color" name="color">
        </p>
        <p>
            Range: <input type="range" name="range">
        </p>
        <input type="submit">
    </form>
    ';

    if ($_POST) {
        $t='';
        foreach($_POST as $k => $v) {
            if ($k == 'food') {
                foreach($v as $key => $value) {
                    $t.=$k."[".$key."] = \"".$value."\" \n";
               }
            } else {
                $t.=$k." = \"".$v."\" \n";
            }
       }
       $f = fopen('form.txt', 'w');
       fwrite($f, $t);
       fclose($f);
    }
?>
