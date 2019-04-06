<?php
	header("Content-Type:text/xml");
	error_reporting(E_ALL);
	//date_default_timezone_set('Europe/Minsk'); 
	
	$page = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>
		<rss version=\"2.0\">
			<channel>
			<title>IT новости</title>
				<link>http://www.somesite.com/rss/</link>
				<description>Лабораторная работа 6. Лисовский</description>
				<lastBuildDate>".date(DATE_RSS)."</lastBuildDate>";

	$connection = new mysqli("localhost", "root", "1111", "lis");
	if ($connection->connect_errno) {
		$page .= "Не удалось подключиться: %s\n".$connection->connect_error;
		exit();
	}

	$qry = $connection->query("SELECT newsid, newsdate, newsheader, newstext FROM news ORDER BY newsdate desc");
	while($row = $qry->fetch_array(MYSQLI_ASSOC))
	{
		$page .= "<item>";
		$page .= "<title>${row['newsheader']} (${row['newsdate']})</title>";
		$page .= "<link>http://www.somesite.com/news/newsid${row['newsid']}/</link>";
		$page .= "<description>${row['newstext']}</description>";
		$page .= "<comments>http://www.somesite.com/news/newsid${row['newsid']}/</comments>";
		$page .= "<pubDate>".date(DATE_RSS, strtotime($row['newsdate']))."</pubDate>";
		$page .= "<guid>http://www.somesite.com/news/newsid${row['newsid']}/</guid>";
		$page .= "</item>";
	}
	$qry->close();
	$connection->close();
	
	$page .= "</channel>";
	$page .= "</rss>";
	echo $page;
?>
