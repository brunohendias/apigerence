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
-- Position to start replication or point-in-time recovery from
--

-- CHANGE MASTER TO MASTER_LOG_FILE='DESKTOP-AABFF8I-bin.000025', MASTER_LOG_POS=156;

--
-- Table structure for table `aluno_disciplina`
--

DROP TABLE IF EXISTS `aluno_disciplina`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aluno_disciplina` (
  `cod_aluno_disc` bigint unsigned NOT NULL AUTO_INCREMENT,
  `nota` float NOT NULL,
  `cod_aluno` bigint unsigned NOT NULL,
  `cod_serie_disc` bigint unsigned NOT NULL,
  `cod_bimestre` bigint unsigned NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`cod_aluno_disc`),
  KEY `aluno_disciplina_cod_aluno_foreign` (`cod_aluno`),
  KEY `aluno_disciplina_cod_serie_disc_foreign` (`cod_serie_disc`),
  CONSTRAINT `aluno_disciplina_cod_aluno_foreign` FOREIGN KEY (`cod_aluno`) REFERENCES `aluno` (`cod_aluno`),
  CONSTRAINT `aluno_disciplina_cod_serie_disc_foreign` FOREIGN KEY (`cod_serie_disc`) REFERENCES `serie_disciplina` (`cod_serie_disc`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aluno_disciplina`
--

LOCK TABLES `aluno_disciplina` WRITE;
/*!40000 ALTER TABLE `aluno_disciplina` DISABLE KEYS */;
INSERT INTO `aluno_disciplina` VALUES (1,20,5,1,1,NULL),(2,30,5,2,1,NULL),(3,40,5,3,1,NULL),(4,50,5,4,1,NULL),(5,60,5,5,1,NULL),(6,70,5,6,1,NULL),(7,80,5,7,1,NULL),(8,90,5,1,2,NULL),(9,100,5,2,2,NULL),(10,90,5,3,2,NULL),(11,80,5,4,2,NULL),(12,70,5,5,2,NULL),(13,60,5,6,2,NULL),(14,50,5,7,2,NULL),(15,100,5,10,3,NULL);
/*!40000 ALTER TABLE `aluno_disciplina` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-05-18 13:09:57
