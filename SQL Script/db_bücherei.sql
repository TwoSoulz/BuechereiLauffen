DROP Database IF EXISTS buecherei;
CREATE DATABASE  IF NOT EXISTS `buecherei` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `buecherei`;
-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: buecherei
-- ------------------------------------------------------
-- Server version	5.5.8

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
-- Table structure for table `ausleihen`
--

DROP TABLE IF EXISTS `ausleihen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ausleihen` (
  `Leser_ID` int(11) NOT NULL,
  `Buch_ISBN` varchar(14) NOT NULL,
  `Datum` datetime NOT NULL,
  PRIMARY KEY (`Datum`,`Buch_ISBN`,`Leser_ID`),
  KEY `fk_Leser_has_Buch_Buch2_idx` (`Buch_ISBN`),
  KEY `fk_Leser_has_Buch_Leser2_idx` (`Leser_ID`),
  CONSTRAINT `fk_Leser_has_Buch_Leser2` FOREIGN KEY (`Leser_ID`) REFERENCES `leser` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Leser_has_Buch_Buch2` FOREIGN KEY (`Buch_ISBN`) REFERENCES `buch` (`ISBN`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ausleihen`
--

LOCK TABLES `ausleihen` WRITE;
/*!40000 ALTER TABLE `ausleihen` DISABLE KEYS */;
/*!40000 ALTER TABLE `ausleihen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `buch`
--

DROP TABLE IF EXISTS `buch`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `buch` (
  `ISBN` varchar(14) NOT NULL,
  `Titel` varchar(45) DEFAULT NULL,
  `buecher_autor_ID` int(11) NOT NULL,
  `buecher_genre_ID` int(11) NOT NULL,
  `verlage_ID` int(11) NOT NULL,
  PRIMARY KEY (`ISBN`),
  KEY `fk_Buecher_buecher_autor_idx` (`buecher_autor_ID`),
  KEY `fk_Buecher_buecher_genre1_idx` (`buecher_genre_ID`),
  KEY `fk_Buecher_verlage1_idx` (`verlage_ID`),
  CONSTRAINT `fk_Buecher_buecher_autor` FOREIGN KEY (`buecher_autor_ID`) REFERENCES `buecher_autor` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Buecher_buecher_genre1` FOREIGN KEY (`buecher_genre_ID`) REFERENCES `buecher_genre` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Buecher_verlage1` FOREIGN KEY (`verlage_ID`) REFERENCES `buecher_verlage` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `buch`
--

LOCK TABLES `buch` WRITE;
/*!40000 ALTER TABLE `buch` DISABLE KEYS */;
/*!40000 ALTER TABLE `buch` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `buecher_autor`
--

DROP TABLE IF EXISTS `buecher_autor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `buecher_autor` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Autor` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `buecher_autor`
--

LOCK TABLES `buecher_autor` WRITE;
/*!40000 ALTER TABLE `buecher_autor` DISABLE KEYS */;
/*!40000 ALTER TABLE `buecher_autor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `buecher_genre`
--

DROP TABLE IF EXISTS `buecher_genre`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `buecher_genre` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Genre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `buecher_genre`
--

LOCK TABLES `buecher_genre` WRITE;
/*!40000 ALTER TABLE `buecher_genre` DISABLE KEYS */;
/*!40000 ALTER TABLE `buecher_genre` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `buecher_verlage`
--

DROP TABLE IF EXISTS `buecher_verlage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `buecher_verlage` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Verlag` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `buecher_verlage`
--

LOCK TABLES `buecher_verlage` WRITE;
/*!40000 ALTER TABLE `buecher_verlage` DISABLE KEYS */;
/*!40000 ALTER TABLE `buecher_verlage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `leser`
--

DROP TABLE IF EXISTS `leser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `leser` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Vorname` varchar(45) DEFAULT NULL,
  `Nachname` varchar(45) DEFAULT NULL,
  `Hausnummer` varchar(45) DEFAULT NULL,
  `Straße` varchar(45) DEFAULT NULL,
  `leser_ort_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_Leser_leser_ort1_idx` (`leser_ort_ID`),
  CONSTRAINT `fk_Leser_leser_ort1` FOREIGN KEY (`leser_ort_ID`) REFERENCES `leser_ort` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `leser`
--

LOCK TABLES `leser` WRITE;
/*!40000 ALTER TABLE `leser` DISABLE KEYS */;
/*!40000 ALTER TABLE `leser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `leser_ort`
--

DROP TABLE IF EXISTS `leser_ort`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `leser_ort` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Ort` varchar(45) DEFAULT NULL,
  `PLZ` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `leser_ort`
--

LOCK TABLES `leser_ort` WRITE;
/*!40000 ALTER TABLE `leser_ort` DISABLE KEYS */;
/*!40000 ALTER TABLE `leser_ort` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mitarbeiter`
--

DROP TABLE IF EXISTS `mitarbeiter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mitarbeiter` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Vorname` varchar(45) DEFAULT NULL,
  `Passwort` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mitarbeiter`
--

LOCK TABLES `mitarbeiter` WRITE;
/*!40000 ALTER TABLE `mitarbeiter` DISABLE KEYS */;
/*!40000 ALTER TABLE `mitarbeiter` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservierungen`
--

DROP TABLE IF EXISTS `reservierungen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reservierungen` (
  `Leser_ID` int(11) NOT NULL,
  `Buch_ISBN` varchar(14) NOT NULL,
  `Datum` datetime NOT NULL,
  PRIMARY KEY (`Leser_ID`,`Buch_ISBN`,`Datum`),
  KEY `fk_Leser_has_Buch_Buch1_idx` (`Buch_ISBN`),
  KEY `fk_Leser_has_Buch_Leser1_idx` (`Leser_ID`),
  CONSTRAINT `fk_Leser_has_Buch_Leser1` FOREIGN KEY (`Leser_ID`) REFERENCES `leser` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Leser_has_Buch_Buch1` FOREIGN KEY (`Buch_ISBN`) REFERENCES `buch` (`ISBN`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservierungen`
--

LOCK TABLES `reservierungen` WRITE;
/*!40000 ALTER TABLE `reservierungen` DISABLE KEYS */;
/*!40000 ALTER TABLE `reservierungen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'buecherei'
--

--
-- Dumping routines for database 'buecherei'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-12-13 10:16:34
