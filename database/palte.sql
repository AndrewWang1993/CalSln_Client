CREATE DATABASE  IF NOT EXISTS `pale` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `pale`;
-- MySQL dump 10.13  Distrib 5.6.17, for Win32 (x86)
--
-- Host: localhost    Database: pale
-- ------------------------------------------------------
-- Server version	5.6.19-log

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
-- Table structure for table `car_pale`
--

DROP TABLE IF EXISTS `car_pale`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `car_pale` (
  `pale` varchar(50) NOT NULL,
  `regtime` datetime DEFAULT NULL,
  `name` varchar(45) NOT NULL,
  `community` varchar(45) DEFAULT NULL,
  `building` varchar(45) DEFAULT NULL,
  `unit` varchar(45) DEFAULT NULL,
  `room` varchar(45) DEFAULT NULL,
  `statue` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `car_pale`
--

LOCK TABLES `car_pale` WRITE;
/*!40000 ALTER TABLE `car_pale` DISABLE KEYS */;
INSERT INTO `car_pale` VALUES ('京A47521','2014-03-02 12:11:11','李四','万科城','十七号楼','三单元','4852','已预约'),('桂D56163','2014-03-02 12:11:11','张三','第五园','十八栋','二单元','857','已预约'),('渝CC2020','2014-10-20 15:38:41','万科前台1',NULL,NULL,NULL,NULL,'已入场'),('豫C85214','2014-03-02 12:11:11','万科前台1',NULL,NULL,NULL,NULL,'已入场'),('粤Y68558','2014-10-28 11:46:02','万科前台1',NULL,NULL,NULL,NULL,'已预约'),('港UJB668','2014-10-28 11:46:38','万科前台1',NULL,NULL,NULL,NULL,'已入场'),('宁YHBBJN','2014-10-28 16:10:30','万科前台1',NULL,NULL,NULL,NULL,'已入场'),('沪GVHJNN','2014-10-28 16:21:54','万科前台1',NULL,NULL,NULL,NULL,'已预约'),('粤G34555','2014-11-04 02:23:31','万科前台1',NULL,NULL,NULL,NULL,'已入场'),('粤FXXDDZ','2014-11-19 17:03:08','万科前台1',NULL,NULL,NULL,NULL,'已预约'),('粤FCVTGV','2014-11-24 10:14:36','万科前台1',NULL,NULL,NULL,NULL,'已预约'),('粤SASDFA','2014-11-25 11:44:12','sdsf','','','','','已预约');
/*!40000 ALTER TABLE `car_pale` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mac_name`
--

DROP TABLE IF EXISTS `mac_name`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mac_name` (
  `mac` varchar(20) NOT NULL DEFAULT '',
  `name` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mac_name`
--

LOCK TABLES `mac_name` WRITE;
/*!40000 ALTER TABLE `mac_name` DISABLE KEYS */;
INSERT INTO `mac_name` VALUES ('00:0b:82:64:34:a9','万科前台1'),('00:0b:82:******','万科前台2');
/*!40000 ALTER TABLE `mac_name` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `record`
--

DROP TABLE IF EXISTS `record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `record` (
  `pale` varchar(50) NOT NULL,
  `regtime` datetime DEFAULT NULL,
  `gate` varchar(45) DEFAULT NULL,
  `direction` varchar(45) DEFAULT NULL,
  `time` datetime DEFAULT NULL,
  `pic` varchar(45) DEFAULT NULL,
  KEY `pale_idx` (`pale`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `record`
--

LOCK TABLES `record` WRITE;
/*!40000 ALTER TABLE `record` DISABLE KEYS */;
INSERT INTO `record` VALUES ('京A47521','2014-03-02 12:11:11','3号','出口1号车道','2014-06-04 22:40:00','20140604_22-40-00_3gate_out1.jpg'),('粤F00S06','2014-03-02 12:11:11','1号','入口2号车道','2014-08-26 15:55:21','20140826_15-55-21_1gate_in2.jpg'),('粤F00S06','2014-03-02 12:11:11','1号','出口2号车道','2014-08-26 15:58:22','20140826_15-58-22_1gate_out2.jpg'),('渝CC2020','2014-09-30 14:36:41','1号','入口2号车道','2014-10-28 13:13:04','20140604_22-40-00_3gate_out1.jpg'),('港UJB668','2014-08-28 14:00:14','3号','入口2号车道','2011-09-18 15:58:22','20140826_15-55-21_1gate_in2.jpg');
/*!40000 ALTER TABLE `record` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `usr` varchar(50) NOT NULL,
  `pwd` varchar(45) NOT NULL,
  PRIMARY KEY (`usr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES ('test1','111'),('test2','222');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-11-25 13:57:49
