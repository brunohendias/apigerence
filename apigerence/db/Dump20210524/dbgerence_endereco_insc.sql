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
-- Table structure for table `endereco_insc`
--

DROP TABLE IF EXISTS `endereco_insc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `endereco_insc` (
  `cod_endereco_insc` bigint unsigned NOT NULL AUTO_INCREMENT,
  `cod_insc` bigint unsigned NOT NULL,
  `estado` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `cidade` varchar(90) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `bairro` varchar(90) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `rua` varchar(90) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `numero` int NOT NULL,
  `cep` varchar(8) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`cod_endereco_insc`),
  KEY `endereco_insc_cod_insc_foreign` (`cod_insc`),
  CONSTRAINT `endereco_insc_cod_insc_foreign` FOREIGN KEY (`cod_insc`) REFERENCES `inscricao` (`cod_insc`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `endereco_insc`
--

LOCK TABLES `endereco_insc` WRITE;
/*!40000 ALTER TABLE `endereco_insc` DISABLE KEYS */;
INSERT INTO `endereco_insc` VALUES (1,1,'MG','Belo-Horizonte','Buritis','Jos?? Hemeterio',382,'35560000',NULL,NULL);
/*!40000 ALTER TABLE `endereco_insc` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-05-24 11:27:41
