<?php
	/*1. прочитать содержимое шаблона main.tpl в текстовую переменную.*/
	$main_tpl = file_get_contents('templates/main.tpl');

	/*2. плейсхолдер {MAIN_MENU} заменить на содержимое шаблона main_menu.tpl*/
	$main_tpl_menu = file_get_contents('templates/main_menu.tpl');
	$main_tpl = str_replace('{MAIN_MENU}',$main_tpl_menu,$main_tpl);

	/*3. Блоки: а) с основным текстом страницы, б) новостями, в) областью с адресом и копирайтом 
		удалить из шаблона main.tpl, пометив места их расположения плейсхолдерами. 
		содержимое удаляемых блоков разместить в отдельных шаблонах. 
		обеспечить замену плейсхолдеров содержимым соответствующих шаблонов*/
	$text_tpl = file_get_contents('templates/text.tpl');
	$main_tpl = str_replace('{TEXT}',$text_tpl,$main_tpl);

	$news_tpl = file_get_contents('templates/news.tpl');
	$main_tpl = str_replace('{NEWS}',$news_tpl,$main_tpl);

	$address_tpl = file_get_contents('templates/address.tpl');
	$main_tpl = str_replace('{ADDRESS}',$address_tpl,$main_tpl);
	
	/*4. плейсхолдеры {TODAY_D}, {TODAY_M}, {TODAY_Y}, {NOW_H}, {NOW_M}, {NOW_S} заменить 
		на фрагменты текущей даты и времени: день, мес€ц, год, час, минута, секунда соответственно.*/
	$main_tpl = str_replace('{TODAY_D}',date("d"),$main_tpl);
	$main_tpl = str_replace('{TODAY_M}',date("m"),$main_tpl);
	$main_tpl = str_replace('{TODAY_Y}',date("y"),$main_tpl);
	$main_tpl = str_replace('{NOW_H}',date("h"),$main_tpl);
	$main_tpl = str_replace('{NOW_M}',date("i"),$main_tpl);
	$main_tpl = str_replace('{NOW_S}',date("s"),$main_tpl);

	/*5. создать конфигурационный файл site.cfg */
	$cfg_file = file('site.cfg');
	for($i = 0; $i < count($cfg_file); $i++)
	{
		$param = '{'.substr($cfg_file[$i], 0, strpos($cfg_file[$i], '=')).'}';
		$value = substr($cfg_file[$i], strpos($cfg_file[$i], '=')+1);
		$main_tpl = str_replace($param, $value, $main_tpl);
	}
	
	echo($main_tpl);
?>










