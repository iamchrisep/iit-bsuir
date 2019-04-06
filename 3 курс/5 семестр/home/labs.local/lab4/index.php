<?php
	$cfg = array();
	/*Получить $count новостей*/
	function GetNews($count)
	{
		$news_tpl = file_get_contents('templates/news.tpl');
		$news_str = "";
		
		$connection = new mysqli("localhost", "root", "1111", "lis");
		if ($connection->connect_errno) {
			printf("Не удалось подключиться: %s\n", $connection->connect_error);
			exit();
		}
		if (!$connection->set_charset("utf8")) {
			printf("Ошибка при загрузке набора символов utf8: %s\n", $connection->error);
			exit();
		}
		$qry = $connection->query("SELECT newsid, newsdate, newsheader, newstext FROM news ORDER BY newsdate desc limit 0, $count ");
		while($row = $qry->fetch_array(MYSQLI_BOTH))
		{
			$new_str = $news_tpl;
			$new_str = str_replace('{NEWS_DATE}', $row['newsdate'], $new_str);
			$new_str = str_replace('{NEWS_HEADER}', $row['newsheader'], $new_str);
			$news_str .=$new_str;
		}
		
		$qry->close();
		$connection->close();
		
		return $news_str;
	}
	
	function GetMenu()
	{
		/*?><script src = "../typer.js"></script><?php*/
		
		$menu_str = '';
		$connection = new mysqli("localhost", "root", "1111", "lis");
		if ($connection->connect_errno) {
			return "Не удалось подключиться: ". $connection->connect_error;
		}
		if (!$connection->set_charset("utf8")) {
			return "Ошибка при загрузке набора символов utf8: ".$connection->error;
			exit();
		}
		$qry = $connection->query("SELECT pageid, pageparentid, pageheader, pagetext FROM pages");
		while($row = $qry->fetch_array(MYSQLI_ASSOC))
		{
			$menu[] =  $row;
			//array("pageid" => $row['pageid'], "pageparentid" => $row['pageparentid'], "pageheader" => $row['pageheader'], "pagetext" => $row['pagetext']);
		}
		
		$qry->close();
		$connection->close();

		if (!json_encode($menu))
		{
			return 'json_last_error()='.json_last_error();
		}
		
		//echo json_encode($menu);
		return "<script>addMenuText('".json_encode($menu)."');</script>";
	}

	function ReadConfig()
	{
		global $cfg;
		$cfg_file = file('site.cfg');
		for($i = 0; $i < count($cfg_file); $i++)
		{
			$param = substr($cfg_file[$i], 0, strpos($cfg_file[$i], '='));
			$value = substr($cfg_file[$i], strpos($cfg_file[$i], '=')+1);
			$cfg[$param] = $value;
		}
		//print_r($cfg);
	}

	ReadConfig();
	
	$main_tpl = file_get_contents('templates/main.tpl');

	//$main_tpl_menu = file_get_contents('templates/main_menu.tpl');
	//$main_tpl_menu = "<script>getMenuText(MenuArr)</script>";
	$main_tpl = str_replace('{MAIN_MENU}',GetMenu(),$main_tpl);
	;

	$text_tpl = file_get_contents('templates/text.tpl');
	$main_tpl = str_replace('{TEXT}',$text_tpl,$main_tpl);

	$address_tpl = file_get_contents('templates/address.tpl');
	$main_tpl = str_replace('{ADDRESS}',$address_tpl,$main_tpl);
	
	$main_tpl = str_replace('{TODAY_D}',date("d"),$main_tpl);
	$main_tpl = str_replace('{TODAY_M}',date("m"),$main_tpl);
	$main_tpl = str_replace('{TODAY_Y}',date("y"),$main_tpl);
	$main_tpl = str_replace('{NOW_H}',date("h"),$main_tpl);
	$main_tpl = str_replace('{NOW_M}',date("i"),$main_tpl);
	$main_tpl = str_replace('{NOW_S}',date("s"),$main_tpl);

	/*3. Написать функцию, отображающую на сайте N самых свежих новостей*/
	$main_tpl = str_replace('{NEWS}', GetNews($cfg['news_count']), $main_tpl);
	
	/*5. На основе таблицы сформировать меню сайта. Меню должно иметь не менее трёх уровней вложенности.*/
	//в разработке.
	
	foreach ($cfg as $name => $value)
	{
		$main_tpl = str_replace('{'.$name.'}',$value,$main_tpl);
	}

	echo($main_tpl);
?>










