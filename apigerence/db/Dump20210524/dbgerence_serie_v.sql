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
-- Table structure for table `serie_v`
--

DROP TABLE IF EXISTS `serie_v`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `serie_v` (
  `cod_serie_v` bigint unsigned NOT NULL AUTO_INCREMENT,
  `qtd_alunos` int NOT NULL DEFAULT '0',
  `limite_alunos` int NOT NULL DEFAULT '20',
  `cod_serie` bigint unsigned NOT NULL,
  `cod_turno` bigint unsigned NOT NULL,
  `cod_turma` bigint unsigned NOT NULL,
  `cod_prof` bigint unsigned DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`cod_serie_v`),
  KEY `serie_v_cod_serie_foreign` (`cod_serie`),
  KEY `serie_v_cod_turno_foreign` (`cod_turno`),
  KEY `serie_v_cod_turma_foreign` (`cod_turma`),
  KEY `serie_v_cod_prof_foreign` (`cod_prof`),
  CONSTRAINT `serie_v_cod_prof_foreign` FOREIGN KEY (`cod_prof`) REFERENCES `professor` (`cod_prof`),
  CONSTRAINT `serie_v_cod_serie_foreign` FOREIGN KEY (`cod_serie`) REFERENCES `serie` (`cod_serie`),
  CONSTRAINT `serie_v_cod_turma_foreign` FOREIGN KEY (`cod_turma`) REFERENCES `turma` (`cod_turma`),
  CONSTRAINT `serie_v_cod_turno_foreign` FOREIGN KEY (`cod_turno`) REFERENCES `turno` (`cod_turno`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `serie_v`
--

LOCK TABLES `serie_v` WRITE;
/*!40000 ALTER TABLE `serie_v` DISABLE KEYS */;
INSERT INTO `serie_v` VALUES (1,0,20,1,1,1,1,NULL,NULL),(2,0,20,1,1,2,10,NULL,NULL),(3,0,20,1,1,3,1,NULL,NULL),(4,0,20,2,1,1,2,NULL,NULL),(5,0,20,2,1,2,11,NULL,NULL),(6,0,20,3,2,1,2,NULL,NULL),(7,0,20,3,2,2,12,NULL,NULL),(8,0,20,3,2,3,3,NULL,NULL),(9,0,20,4,2,1,10,NULL,NULL),(10,0,20,4,2,2,4,NULL,NULL),(11,0,20,5,1,1,11,NULL,NULL),(12,0,20,5,1,2,4,NULL,NULL),(13,0,20,6,1,1,12,NULL,NULL),(14,0,20,6,1,2,5,NULL,NULL),(16,0,20,7,2,2,6,NULL,NULL),(17,0,20,7,2,3,11,NULL,NULL),(18,0,20,8,2,1,6,NULL,NULL),(19,0,20,8,2,2,12,NULL,NULL),(20,0,20,9,1,1,7,NULL,NULL),(21,0,20,9,1,2,10,NULL,NULL),(22,0,20,10,1,1,8,NULL,NULL),(23,0,20,10,1,2,11,NULL,NULL),(24,0,20,11,1,1,8,NULL,NULL),(25,0,20,11,1,2,12,NULL,NULL),(26,0,20,12,1,1,9,NULL,NULL),(27,0,20,12,1,2,10,NULL,NULL);
/*!40000 ALTER TABLE `serie_v` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-05-24 11:27:46
