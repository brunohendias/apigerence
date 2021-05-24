-- MySQL dump 10.13  Distrib 8.0.24, for Win64 (x86_64)
--
-- Host: localhost    Database: dbgerence
-- ------------------------------------------------------
-- Server version	8.0.24

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
-- Table structure for table `professor_v`
--

DROP TABLE IF EXISTS `professor_v`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `professor_v` (
  `cod_prof_v` bigint unsigned NOT NULL AUTO_INCREMENT,
  `cod_prof` bigint unsigned NOT NULL,
  `cod_atencao` bigint unsigned NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`cod_prof_v`),
  KEY `professor_v_cod_prof_foreign` (`cod_prof`),
  KEY `professor_v_cod_atencao_foreign` (`cod_atencao`),
  CONSTRAINT `professor_v_cod_atencao_foreign` FOREIGN KEY (`cod_atencao`) REFERENCES `atencao` (`cod_atencao`),
  CONSTRAINT `professor_v_cod_prof_foreign` FOREIGN KEY (`cod_prof`) REFERENCES `professor` (`cod_prof`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professor_v`
--

LOCK TABLES `professor_v` WRITE;
/*!40000 ALTER TABLE `professor_v` DISABLE KEYS */;
INSERT INTO `professor_v` VALUES (1,1,1,NULL,NULL),(2,1,2,NULL,NULL),(3,1,3,NULL,NULL),(4,2,1,NULL,NULL),(5,2,3,NULL,NULL),(6,2,4,NULL,NULL),(7,3,1,NULL,NULL),(8,3,2,NULL,NULL),(9,3,5,NULL,NULL),(10,4,1,NULL,NULL),(11,4,4,NULL,NULL),(12,4,4,NULL,NULL),(13,5,1,NULL,NULL),(14,5,3,NULL,NULL),(15,5,5,NULL,NULL),(16,6,1,NULL,NULL),(17,6,2,NULL,NULL),(18,6,3,NULL,NULL),(19,7,1,NULL,NULL),(20,7,2,NULL,NULL),(21,7,3,NULL,NULL),(22,8,1,NULL,NULL),(23,8,3,NULL,NULL),(24,8,3,NULL,NULL),(25,9,1,NULL,NULL),(26,9,2,NULL,NULL),(27,9,4,NULL,NULL),(28,10,1,NULL,NULL),(29,10,4,NULL,NULL),(30,10,5,NULL,NULL),(31,11,1,NULL,NULL),(32,11,2,NULL,NULL),(33,11,3,NULL,NULL),(34,12,1,NULL,NULL),(35,12,3,NULL,NULL),(36,12,4,NULL,NULL),(37,12,3,NULL,NULL);
/*!40000 ALTER TABLE `professor_v` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-05-24 11:27:50
