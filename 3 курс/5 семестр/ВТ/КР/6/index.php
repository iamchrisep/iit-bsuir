<?php
  $fmain = file_get_contents('templates/main.tpl');

  $fmainmenu = getContains();
  $fmain = str_replace('{MAIN_MENU}',$fmainmenu,$fmain);

  $text = file_get_contents('templates/text.tpl');
  $fmain = str_replace('{text}',$text,$fmain);

  $fmain = str_replace('{TODAY_D}',date("d"),$fmain);
  $fmain = str_replace('{TODAY_M}',date("m"),$fmain);
  $fmain = str_replace('{TODAY_Y}',date("y"),$fmain);
  $fmain = str_replace('{NOW_H}',date("H"),$fmain);
  $fmain = str_replace('{NOW_M}',date("i"),$fmain);
  $fmain = str_replace('{NOW_S}',date("s"),$fmain);

  $fnews = file_get_contents('templates/news.tpl');
  $fnews_str = file_get_contents('templates/news_str.tpl');

  $flogo = file_get_contents('templates/logo.tpl');
  $fmain = str_replace('{LOGO}',$flogo,$fmain);

  $news_all = new SimpleXMLElement(getNews());
  $str_all = "";
	for($i = 0; $i < count($news_all->channel[0]->item); $i++)
	{
			$str1 = $fnews_str;
			$str1 = str_replace('{news_date}',$news_all->channel[0]->item[$i]->pubDate,$str1);
			$str1 = str_replace('{news_text}',$news_all->channel[0]->item[$i]->title,$str1);
			$str_all .=$str1;
	}

  $fnews = str_replace('{news_str}', $str_all, $fnews);
  $fmain = str_replace('{news}', $fnews, $fmain);

  $mcfg = file('site.cfg');
  $cfg0 = str_word_count($mcfg[0], 1);

  $cfg1 = str_word_count($mcfg[1], 1);

  $fmain = str_replace('{main_color}', $cfg0[2], $fmain);

  $fmain = str_replace('{copyright_color}', $cfg1[2], $fmain);
  echo($fmain);

  function getNews()
  {
    $html = '<?xml version="1.0" encoding="utf-8" ?>
     <rss version="2.0">
      <channel>
      <title>Название ленты новостей</title>
      <link>http://www.somesite.com/rss/</link>
      <description>Описание ленты новостей</description>
      <lastBuildDate>'.date(DATE_RSS).'</lastBuildDate>
    ';

    $connection = new mysqli("localhost", "root", "12345", "news");
    if ($connection->connect_errno) {
      printf("Не удалось подключиться: %s\n", $connection->connect_error);
      exit();
    }
    if (!$connection->set_charset("utf8")) {
      printf("Ошибка при загрузке набора символов utf8: %s\n", $connection->error);
      exit();
    }
    $qry = $connection->query("SELECT * FROM rss");
    while($row = $qry->fetch_array(MYSQLI_BOTH)){
      $html .= '
      <item>
      <title>'.$row[0].'</title>
      <link>'.$row[1].'</link>
      <description>'.$row[2].'</description>
      <comments>http:'.$row[3].'</comments>
      <pubDate>'.$row[4].'</pubDate>
      <guid>'.$row[5].'</guid>
      </item>';
    }
    $html .= '</channel>
      </rss>
    ';

    $qry->close();
    $connection->close();

    return $html;
  }

  function getItemMenu($id)
  {
    $connection = new mysqli("localhost", "root", "12345", "news");
    if ($connection->connect_errno) {
      printf("Не удалось подключиться: %s\n", $connection->connect_error);
      exit();
    }
    if (!$connection->set_charset("utf8")) {
      printf("Ошибка при загрузке набора символов utf8: %s\n", $connection->error);
      exit();
    }
    $qry = $connection->query("SELECT * FROM pages WHERE ID = $id");
    while($row = $qry->fetch_array(MYSQLI_BOTH))
    {
      return $row[2];
    }

    $qry->close();
    $connection->close();
  }

  function getContains()
  {
    return '
      <ul class="nav">
          <li><a href="#">'. getItemMenu(1).'</a></li>
          <li><a href="#">'. getItemMenu(2).'</a>
              <ul class="sub_level">
                  <li><a href="#">'. getItemMenu(3).'</a></li>
                  <li><a href="#">'. getItemMenu(4).'</a>
                      <ul class="sub_sub_level">
                          <li><a href="#">'. getItemMenu(5).'</a></li>
                          <li><a href="#">'. getItemMenu(6).'</a></li>
                          <li><a href="#">'. getItemMenu(7).'</a></li>
                      </ul>
                  </li>
                  <li><a href="#">'. getItemMenu(8).'</a></li>
                  <li><a href="#">'. getItemMenu(9).'</a></li>
              </ul>
          </li>
          <li><a href="#">'. getItemMenu(6).'</a></li>
          <li><a href="#">'. getItemMenu(7).'</a></li>
      </ul>
    ';
  }
?>
