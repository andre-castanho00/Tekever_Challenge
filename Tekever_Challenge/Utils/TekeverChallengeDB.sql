CREATE DATABASE  IF NOT EXISTS `tekeverchallengedb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `tekeverchallengedb`;
-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: localhost    Database: tekeverchallengedb
-- ------------------------------------------------------
-- Server version	8.0.43

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20251016170651_Initial','8.0.0'),('20251017135710_EpisodesDuration','8.0.0');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `actors`
--

DROP TABLE IF EXISTS `actors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `actors` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `BirthDate` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `actors`
--

LOCK TABLES `actors` WRITE;
/*!40000 ALTER TABLE `actors` DISABLE KEYS */;
INSERT INTO `actors` VALUES (1,'Cillian Murphy',NULL),(2,'Bryan Cranston',NULL),(3,'Jennifer Aniston',NULL),(4,'Pedro Pascal',NULL),(5,'Millie Bobby Brown',NULL),(6,'Henry Cavill',NULL),(7,'Emma D\'Arcy',NULL),(8,'Tom Hiddleston',NULL),(9,'Anya Taylor-Joy',NULL),(10,'Matthew McConaughey',NULL),(11,'Zendaya',NULL),(12,'Rami Malek',NULL),(13,'Elizabeth Olsen',NULL),(14,'Kit Harington',NULL),(15,'Oscar Isaac',NULL);
/*!40000 ALTER TABLE `actors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderKey` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('09b40b84-36ca-4149-a0a9-9106cdf617c8','AndreCastanho','ANDRECASTANHO','andre@example.com','ANDRE@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEKMP+yEB1YplJ9+6WyTwAP0rKzUzzn5t7KMLUP8ve1MCNP1u0AKXoIgDcpP3NN57ew==','MYO53WR7CVZSTZVDCMFZEE2MFAP3BSUW','ba23b851-f8c3-4db0-b783-baf26558b713',NULL,0,0,NULL,1,0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `genres`
--

DROP TABLE IF EXISTS `genres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `genres` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genres`
--

LOCK TABLES `genres` WRITE;
/*!40000 ALTER TABLE `genres` DISABLE KEYS */;
INSERT INTO `genres` VALUES (1,'Drama'),(2,'Comedy'),(3,'Action'),(4,'Sci-Fi'),(5,'Thriller'),(6,'Fantasy'),(7,'Crime'),(8,'Adventure');
/*!40000 ALTER TABLE `genres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `refreshtokens`
--

DROP TABLE IF EXISTS `refreshtokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `refreshtokens` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Token` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `JwtId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `IsRevoked` tinyint(1) NOT NULL,
  `AddedtAt` datetime(6) NOT NULL,
  `ExpireAt` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RefreshTokens_UserId` (`UserId`),
  CONSTRAINT `FK_RefreshTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `refreshtokens`
--

LOCK TABLES `refreshtokens` WRITE;
/*!40000 ALTER TABLE `refreshtokens` DISABLE KEYS */;
INSERT INTO `refreshtokens` VALUES (1,'09b40b84-36ca-4149-a0a9-9106cdf617c8','e4d7b703-a55e-47a6-8f63-1f19106b92ae-4d447856-0d19-4be6-951f-e62b008e4001','cf2a840c-941e-4743-9db4-4b27f3ad33f5',0,'2025-10-16 17:13:10.468578','2026-04-16 17:13:10.468623'),(2,'09b40b84-36ca-4149-a0a9-9106cdf617c8','8f9e9794-cb54-4e6d-b418-e04e070aef02-3e0d1846-72f0-4216-8b1c-49f013d407a1','637cf622-51ee-42f0-9c03-3f4602bd4d70',0,'2025-10-17 18:26:18.814259','2026-04-17 18:26:18.814310');
/*!40000 ALTER TABLE `refreshtokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `seasonepisodes`
--

DROP TABLE IF EXISTS `seasonepisodes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `seasonepisodes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `EpisodeNumber` int NOT NULL,
  `Title` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `AirDate` datetime(6) NOT NULL,
  `Rating` double DEFAULT NULL,
  `SeasonId` int NOT NULL,
  `Duration` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_SeasonEpisodes_SeasonId` (`SeasonId`),
  CONSTRAINT `FK_SeasonEpisodes_Seasons_SeasonId` FOREIGN KEY (`SeasonId`) REFERENCES `seasons` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seasonepisodes`
--

LOCK TABLES `seasonepisodes` WRITE;
/*!40000 ALTER TABLE `seasonepisodes` DISABLE KEYS */;
INSERT INTO `seasonepisodes` VALUES (1,1,'Episode 1','2013-09-12 00:00:00.000000',8.6,1,52),(2,2,'Episode 2','2013-09-19 00:00:00.000000',8.7,1,53),(3,1,'Episode 1','2014-10-02 00:00:00.000000',8.9,2,68),(4,1,'Pilot','2008-01-20 00:00:00.000000',9,3,35),(5,2,'Cat\'s in the Bag...','2008-01-27 00:00:00.000000',8.7,3,51),(6,1,'Season 2 Premiere','2009-03-15 00:00:00.000000',9.1,4,60),(7,1,'The One Where It All Began','1994-09-22 00:00:00.000000',8.3,5,48),(8,2,'The One with the Sonogram','1994-09-29 00:00:00.000000',8.4,5,42),(9,1,'Season 2 Premiere','1995-09-21 00:00:00.000000',8.5,6,51),(10,1,'Chapter 1: The Mandalorian','2019-11-12 00:00:00.000000',8.9,7,43),(11,2,'Chapter 2: The Child','2019-11-15 00:00:00.000000',8.8,7,37),(12,1,'Episode 1','2019-12-20 00:00:00.000000',8.2,8,42),(13,2,'Episode 2','2019-12-27 00:00:00.000000',8.4,8,41),(14,1,'Episode 1','2021-12-17 00:00:00.000000',8.5,9,52),(15,1,'Episode 1','2011-04-17 00:00:00.000000',9,10,45),(16,2,'Episode 2','2011-04-24 00:00:00.000000',8.9,10,60),(17,1,'Episode 1','2012-04-01 00:00:00.000000',9.1,11,39),(18,1,'Episode 1','2021-06-09 00:00:00.000000',8.4,12,52),(19,2,'Episode 2','2021-06-16 00:00:00.000000',8.6,12,51),(20,3,'Episode 3','2021-06-23 00:00:00.000000',8.5,12,37),(21,1,'Episode 1','2020-10-23 00:00:00.000000',7.8,13,57),(22,2,'Episode 2','2020-10-30 00:00:00.000000',7.9,13,42),(23,1,'Episode 1','2022-08-21 00:00:00.000000',8,14,59),(24,2,'Episode 2','2022-08-28 00:00:00.000000',8.2,14,70),(25,3,'Episode 3','2022-09-04 00:00:00.000000',8.1,14,70),(26,1,'Episode 1','2015-06-24 00:00:00.000000',8.3,15,35),(27,2,'Episode 2','2015-07-01 00:00:00.000000',8.2,15,40),(28,1,'Episode 1','2019-06-16 00:00:00.000000',8.5,16,44),(29,2,'Episode 2','2019-06-23 00:00:00.000000',8.6,16,53),(30,1,'Episode 1','2019-07-26 00:00:00.000000',7.9,17,58),(31,2,'Episode 2','2019-08-02 00:00:00.000000',8,17,53),(32,1,'Episode 1','2021-01-15 00:00:00.000000',8.1,18,68),(33,2,'Episode 2','2021-01-22 00:00:00.000000',8.2,18,65),(34,1,'Episode 1','2014-01-12 00:00:00.000000',8,19,51),(35,2,'Episode 2','2014-01-19 00:00:00.000000',8.1,19,49),(36,1,'Episode 1','2015-02-08 00:00:00.000000',7.9,20,54),(37,1,'Episode 1','2015-08-28 00:00:00.000000',8.3,21,68),(38,1,'Episode 1','2015-12-14 00:00:00.000000',8.2,22,50),(39,1,'Episode 1','2023-01-15 00:00:00.000000',8.4,23,45),(40,1,'Episode 1','2010-07-25 00:00:00.000000',7.8,24,47),(41,2,'Episode 2','2010-08-01 00:00:00.000000',7.9,24,53),(42,1,'Episode 1','2011-07-25 00:00:00.000000',8,25,52),(43,1,'Episode 1','2011-07-25 00:00:00.000000',5,26,64),(44,2,'Episode 2','2011-12-25 00:00:00.000000',6.2,26,54),(45,1,'Episode 1','2012-07-25 00:00:00.000000',7.8,27,61);
/*!40000 ALTER TABLE `seasonepisodes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `seasons`
--

DROP TABLE IF EXISTS `seasons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `seasons` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SeasonNumber` int NOT NULL,
  `ReleaseDate` datetime(6) NOT NULL,
  `TvShowId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Seasons_TvShowId` (`TvShowId`),
  CONSTRAINT `FK_Seasons_TvShows_TvShowId` FOREIGN KEY (`TvShowId`) REFERENCES `tvshows` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seasons`
--

LOCK TABLES `seasons` WRITE;
/*!40000 ALTER TABLE `seasons` DISABLE KEYS */;
INSERT INTO `seasons` VALUES (1,1,'2013-09-12 00:00:00.000000',1),(2,2,'2014-10-02 00:00:00.000000',1),(3,1,'2008-01-20 00:00:00.000000',2),(4,2,'2009-03-15 00:00:00.000000',2),(5,1,'1994-09-22 00:00:00.000000',3),(6,2,'1995-09-21 00:00:00.000000',3),(7,1,'2019-11-12 00:00:00.000000',4),(8,1,'2019-12-20 00:00:00.000000',5),(9,2,'2021-12-17 00:00:00.000000',5),(10,1,'2011-04-17 00:00:00.000000',6),(11,2,'2012-04-01 00:00:00.000000',6),(12,1,'2016-07-15 00:00:00.000000',7),(13,2,'2017-10-27 00:00:00.000000',7),(14,1,'2021-06-09 00:00:00.000000',8),(15,1,'2020-10-23 00:00:00.000000',9),(16,1,'2022-08-21 00:00:00.000000',10),(17,1,'2015-06-24 00:00:00.000000',11),(18,1,'2019-06-16 00:00:00.000000',12),(19,1,'2019-07-26 00:00:00.000000',13),(20,1,'2021-01-15 00:00:00.000000',14),(21,1,'2014-01-12 00:00:00.000000',15),(22,1,'2015-02-08 00:00:00.000000',16),(23,1,'2015-08-28 00:00:00.000000',17),(24,1,'2015-12-14 00:00:00.000000',18),(25,1,'2023-01-15 00:00:00.000000',19),(26,1,'2010-07-25 00:00:00.000000',20),(27,2,'2011-07-25 00:00:00.000000',20);
/*!40000 ALTER TABLE `seasons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tvshowactors`
--

DROP TABLE IF EXISTS `tvshowactors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tvshowactors` (
  `TvShowId` int NOT NULL,
  `ActorId` int NOT NULL,
  PRIMARY KEY (`TvShowId`,`ActorId`),
  KEY `IX_TvShowActors_ActorId` (`ActorId`),
  CONSTRAINT `FK_TvShowActors_Actors_ActorId` FOREIGN KEY (`ActorId`) REFERENCES `actors` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_TvShowActors_TvShows_TvShowId` FOREIGN KEY (`TvShowId`) REFERENCES `tvshows` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tvshowactors`
--

LOCK TABLES `tvshowactors` WRITE;
/*!40000 ALTER TABLE `tvshowactors` DISABLE KEYS */;
INSERT INTO `tvshowactors` VALUES (1,1),(20,1),(2,2),(13,2),(16,2),(3,3),(12,3),(4,4),(19,4),(7,5),(19,5),(5,6),(6,6),(10,7),(4,8),(8,8),(5,9),(9,9),(9,10),(15,10),(20,10),(7,11),(12,11),(2,12),(11,12),(3,13),(14,13),(1,14),(6,14),(10,14),(8,15),(13,15),(17,15),(18,15);
/*!40000 ALTER TABLE `tvshowactors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tvshowgenres`
--

DROP TABLE IF EXISTS `tvshowgenres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tvshowgenres` (
  `TvShowId` int NOT NULL,
  `GenreId` int NOT NULL,
  PRIMARY KEY (`TvShowId`,`GenreId`),
  KEY `IX_TvShowGenres_GenreId` (`GenreId`),
  CONSTRAINT `FK_TvShowGenres_Genres_GenreId` FOREIGN KEY (`GenreId`) REFERENCES `genres` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_TvShowGenres_TvShows_TvShowId` FOREIGN KEY (`TvShowId`) REFERENCES `tvshows` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tvshowgenres`
--

LOCK TABLES `tvshowgenres` WRITE;
/*!40000 ALTER TABLE `tvshowgenres` DISABLE KEYS */;
INSERT INTO `tvshowgenres` VALUES (1,1),(2,1),(7,1),(9,1),(11,1),(12,1),(15,1),(16,1),(17,1),(19,1),(3,2),(8,2),(14,2),(1,3),(5,3),(13,3),(4,4),(7,4),(8,4),(14,4),(18,4),(6,5),(9,5),(10,5),(11,5),(13,5),(20,5),(5,6),(6,6),(10,6),(1,7),(2,7),(15,7),(16,7),(17,7),(20,7),(3,8),(4,8),(18,8),(19,8);
/*!40000 ALTER TABLE `tvshowgenres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tvshows`
--

DROP TABLE IF EXISTS `tvshows`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tvshows` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Title` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ReleaseDate` datetime(6) NOT NULL,
  `Rating` double DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tvshows`
--

LOCK TABLES `tvshows` WRITE;
/*!40000 ALTER TABLE `tvshows` DISABLE KEYS */;
INSERT INTO `tvshows` VALUES (1,'Peaky Blinders','British crime drama','2013-09-12 00:00:00.000000',9.1),(2,'Breaking Bad','Chemistry teacher turns to crime','2008-01-20 00:00:00.000000',9.5),(3,'Friends','Six friends navigate life in NYC','1994-09-22 00:00:00.000000',8.9),(4,'The Mandalorian','Star Wars bounty hunter saga','2019-11-12 00:00:00.000000',8.7),(5,'The Witcher','A monster hunter struggles with his destiny','2019-12-20 00:00:00.000000',5.2),(6,'Game of Thrones','Noble families vie for control of Westeros','2011-04-17 00:00:00.000000',9.3),(7,'Stranger Things','A group of kids uncover supernatural mysteries','2016-07-15 00:00:00.000000',7.1),(8,'Loki','God of Mischief faces the TVA','2021-06-09 00:00:00.000000',6),(9,'The Queen’s Gambit','Chess prodigy battles addiction and rivals','2020-10-23 00:00:00.000000',8.6),(10,'House of the Dragon','Targaryen civil war begins','2022-08-21 00:00:00.000000',8.8),(11,'Mr. Robot','Hacker tries to take down corporate America','2015-06-24 00:00:00.000000',4.7),(12,'Euphoria','Teens navigate love and addiction','2019-06-16 00:00:00.000000',8.4),(13,'The Boys','A group of vigilantes fight corrupt superheroes','2019-07-26 00:00:00.000000',6.9),(14,'WandaVision','Superhero sitcom blending reality and fantasy','2021-01-15 00:00:00.000000',5),(15,'True Detective','Detectives uncover dark truths','2014-01-12 00:00:00.000000',8.4),(16,'Better Call Saul','A lawyer\'s descent into moral ambiguity','2015-02-08 00:00:00.000000',7.2),(17,'Narcos','The story of Pablo Escobar and the DEA','2015-08-28 00:00:00.000000',8.8),(18,'The Expanse','A sci-fi political thriller set in space','2015-12-14 00:00:00.000000',5.7),(19,'The Last of Us','Survivors navigate a post-apocalyptic world','2023-01-15 00:00:00.000000',9.2),(20,'Sherlock','Modern adaptation of Sherlock Holmes','2010-07-25 00:00:00.000000',9.1);
/*!40000 ALTER TABLE `tvshows` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userfavorites`
--

DROP TABLE IF EXISTS `userfavorites`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userfavorites` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `TvShowId` int NOT NULL,
  PRIMARY KEY (`UserId`,`TvShowId`),
  KEY `IX_UserFavorites_TvShowId` (`TvShowId`),
  CONSTRAINT `FK_UserFavorites_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_UserFavorites_TvShows_TvShowId` FOREIGN KEY (`TvShowId`) REFERENCES `tvshows` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userfavorites`
--

LOCK TABLES `userfavorites` WRITE;
/*!40000 ALTER TABLE `userfavorites` DISABLE KEYS */;
INSERT INTO `userfavorites` VALUES ('09b40b84-36ca-4149-a0a9-9106cdf617c8',1),('09b40b84-36ca-4149-a0a9-9106cdf617c8',12);
/*!40000 ALTER TABLE `userfavorites` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-10-17 21:46:35
