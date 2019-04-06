-- MySQL dump 10.13  Distrib 5.7.20, for Linux (x86_64)
--
-- Host: localhost    Database: news
-- ------------------------------------------------------
-- Server version	5.7.20-0ubuntu0.16.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `news`
--

DROP TABLE IF EXISTS `news`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `news` (
  `id` int(11) NOT NULL,
  `datatime` datetime NOT NULL,
  `title_news` text NOT NULL,
  `news_text` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=cp1251;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `news`
--

LOCK TABLES `news` WRITE;
/*!40000 ALTER TABLE `news` DISABLE KEYS */;
INSERT INTO `news` VALUES (1,'2017-10-22 04:16:22','Новость 1','Текст новости 1'),(2,'2017-10-10 00:00:00','Новость 2','Текст новости 2'),(3,'2017-10-18 02:05:08','Новость 3','Текст новости 3'),(4,'2017-10-17 16:38:28','Новость 4','Текст новости 4');
/*!40000 ALTER TABLE `news` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pages`
--

DROP TABLE IF EXISTS `pages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pages` (
  `ID` int(11) NOT NULL,
  `INFO_TEXT` text NOT NULL,
  `MENU_TEXT` text NOT NULL,
  `PAGETEXT` text
) ENGINE=InnoDB DEFAULT CHARSET=cp1251;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pages`
--

LOCK TABLES `pages` WRITE;
/*!40000 ALTER TABLE `pages` DISABLE KEYS */;
INSERT INTO `pages` VALUES (1,'Красный','Красный','Красный'),(2,'Зеленый','Зеленый','Зеленый'),(3,'Синий','Синий','Синий'),(4,'Желтый','Желтый','Желтый'),(5,'Фиолетовый','Фиолетовый','Фиолетовый'),(6,'Белый','Белый','Белый'),(7,'Черный','Черный','Черный'),(8,'Лимонный','Лимонный','Лимонный'),(9,'Оранжевый','Оранжевый','Оранжевый'),(10,'Хаки','Хаки','Хаки');
/*!40000 ALTER TABLE `pages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rss`
--

DROP TABLE IF EXISTS `rss`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rss` (
  `Title` text NOT NULL,
  `Link` text NOT NULL,
  `Description` text NOT NULL,
  `comments` text NOT NULL,
  `pubDate` date NOT NULL,
  `guid` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=cp1251;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rss`
--

LOCK TABLES `rss` WRITE;
/*!40000 ALTER TABLE `rss` DISABLE KEYS */;
INSERT INTO `rss` VALUES ('Заглавие новости 1','http://www.somesite.com/news/1/','Краткое содержание новости 1','http://www.somesite.com/news/1/','2017-10-11','http://www.somesite.com/news/1/'),('Заглавие новости 2','http://www.somesite.com/news/2/','Краткое содержание новости 2','http://www.somesite.com/news/2/','2017-10-19','http://www.somesite.com/news/2/'),('Заглавие новости  3','http://www.somesite.com/news/3/','Краткое содержание новости 3','http://www.somesite.com/news/3/','2017-10-16','http://www.somesite.com/news/3/'),('Заглавие новости  4','http://www.somesite.com/news/4/','Краткое содержание новости 4','http://www.somesite.com/news/4/','2017-10-17','http://www.somesite.com/news/4/');
/*!40000 ALTER TABLE `rss` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-01-12  6:31:20
