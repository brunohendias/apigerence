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
-- Table structure for table `inscricao`
--

DROP TABLE IF EXISTS `inscricao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inscricao` (
  `cod_insc` bigint unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(90) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `data_nasci` date NOT NULL,
  `email` varchar(90) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `telefone` varchar(14) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `cpf` char(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `rg` char(9) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `nom_mae` varchar(90) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `nom_pai` varchar(90) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `cod_serie` bigint unsigned NOT NULL,
  `cod_atencao` bigint unsigned NOT NULL,
  `cod_turno` bigint unsigned NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`cod_insc`),
  KEY `inscricao_cod_serie_foreign` (`cod_serie`),
  KEY `inscricao_cod_atencao_foreign` (`cod_atencao`),
  KEY `inscricao_cod_turno_foreign` (`cod_turno`),
  CONSTRAINT `inscricao_cod_atencao_foreign` FOREIGN KEY (`cod_atencao`) REFERENCES `atencao` (`cod_atencao`),
  CONSTRAINT `inscricao_cod_serie_foreign` FOREIGN KEY (`cod_serie`) REFERENCES `serie` (`cod_serie`),
  CONSTRAINT `inscricao_cod_turno_foreign` FOREIGN KEY (`cod_turno`) REFERENCES `turno` (`cod_turno`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inscricao`
--

LOCK TABLES `inscricao` WRITE;
/*!40000 ALTER TABLE `inscricao` DISABLE KEYS */;
INSERT INTO `inscricao` VALUES (1,'Antonio Julio Igor Porto','1998-01-01','antonioo_@pontofinalcafe.com.br','7798814-9617','55894258243','414345745','Vanessa Antonella Mariana','Raimundo Cauê Matheus Porto',1,1,1,NULL,NULL),(2,'Enzo Benício Pereira','1985-10-01','enzobeniciopereira-86@hotmail.com','9599657-6753','04644351105','214088121','Vitória Hadassa Sara','Mateus Francisco Carlos Eduardo Pereira',6,2,1,NULL,NULL),(3,'Fábio Sebastião João da Paz','1966-05-24','fabiosebastiaoapaz@centrovias.com.br','9399590-8256','58916582830','150119124','Valentina Isabella','Severino Jorge Marcos da Paz',6,3,1,NULL,NULL),(4,'Cláudio Sérgio Gabriel Jesus','1946-05-11','claudioseresus@obrativaengenharia.com.br','7998474-2388','53044879582','476568687','Sophia Bárbara Jaqueline','Daniel Erick Rodrigo Jesus',4,1,2,NULL,NULL),(5,'Aparecida Elisa Barros','1971-11-05','aparecidael5@escritorioindaia.com.br','9699633-1777','50293682569','155184738','Brenda Sara','Henrique Calebe Barros',4,5,2,NULL,NULL),(6,'Elias Diego Gomes','2002-06-23','eliasdiegogomes_@valepur.com.br','9299912-9232','91724891626','194264877','Laura Caroline','Igor Bruno Lucca Gomes',1,2,1,NULL,NULL),(7,'Thiago Luan Julio da Costa','1954-09-07','thiagoluanjula-91@gracomonline.com.br','5199765-6613','56886128515','312807594','Renata Benedita Letícia','Arthur Henry Bryan da Costa',1,4,1,NULL,NULL),(8,'Theo Manoel da Silva','2001-02-01','theomanosilva_@tirantea.com.br','6799306-3230','73749300623','287376357','Marcela Betina','Fábio Pedro Daniel da Silva',5,2,1,NULL,NULL),(9,'Clara Aline Sônia da Paz','1985-12-01','claraalinesoz_@delfrateinfo.com.br','6899306-6621','10326750711','421041547','Olivia Liz Melissa','Vitor Renato da Paz',5,1,1,NULL,NULL),(10,'Henrique Tiago Vitor da Silva','1954-05-05','hhenragovitordasilva@kframe.com.br','6599283-1881','49245917002','458350114','Carolina Rosa','Fábio Bernardo da Silva',10,3,1,NULL,NULL),(11,'Lúcia Allana Francisca da Conceição','1973-08-11','luciaalcadaconceicao@ime.unicamp.br','8499126-5139','63457636753','309943942','Evelyn Giovanna','Isaac Anderson Danilo da Conceição',10,2,1,NULL,NULL),(12,'Hadassa Vitória Ana Almeida','1944-02-25','hadassavieida@policiamilitar.br','8898739-6145','56573087941','227582469','Stefany Luciana','Enrico Daniel Cauê Almeida',8,4,2,NULL,NULL),(13,'Ana Brenda Tânia Mendes','1971-12-14','anabrendataniamendes_@icloud.con','9898881-3423','04834458008','198422957','Clarice Elisa Rita','Antonio Lorenzo Mendes',8,4,2,NULL,NULL),(14,'Murilo Ricardo João Novaes','1960-06-13','murilors_@sheilabenavente.com.br','9599117-7117','49821274684','464116946','Heloise Betina','Leonardo Roberto Henry Novaes',9,2,1,NULL,NULL),(15,'Kaique Ricardo Kevin Farias','1983-09-13','kkaiquericaarias@prositeweb.com.br','6899391-5589','29936758420','332663176','Alessandra Benedita','Bernardo Augusto Benício Farias',9,2,1,NULL,NULL),(16,'Carlos Emanuel Barbosa','1995-07-08','carlosemanuelbabarbosa@fanger.com.br','6999816-9375','24616174148','234650588','Yasmin Rosa','Anderson Thomas Barbosa',1,3,1,NULL,NULL),(17,'Victor Alexandre Vieira','1992-02-12','victoralexanieira_@negleribeiro.com','6899328-4658','29035973593','293095875','Fabiana Camila Emily','Enrico Emanuel Vieira',1,4,1,NULL,NULL),(18,'Emilly Maria Mariana das Neves','2002-06-27','emillymariamsneves@arganet.com.br','4399961-9186','55774249174','238120259','Rafaela Vitória','Davi Samuel das Neves',1,5,1,NULL,NULL),(19,'Gustavo Yuri Erick das Neves','1977-04-22','ggustavoyurierickdasneves@3cfast.com.br','6399260-5262','03965883526','317958161','Maria Francisca','Erick Cauã Caleb das Neves',6,2,1,NULL,NULL),(20,'Edson Anthony de Paula','1942-05-11','edsonanthouidorapetfarm.com.br','8699555-5412','48853126396','502745186','Stella Alice Mariah','Carlos Eduardo Emanuel Samuel de Paula',6,4,1,NULL,NULL),(21,'Antonio José Barros','1961-02-07','antoniojosebarros-72@kinouchi.com.br','9598891-9805','41696008603','399060698','Sônia Kamilly','Jorge Juan Barros',4,1,2,NULL,NULL),(22,'Victor Francisco Renato Nunes','1953-10-10','victorfrancitonunes@pelozo.com.br','6899317-7547','79261151779','160837881','Alana Laís','Samuel Leonardo Kevin Nunes',4,1,2,NULL,NULL),(23,'Carlos Eduardo Pietro da Cruz','1986-02-09','carloseduardodacruz@cuppari.com.br','4499209-4007','78785549355','190712478','Carolina Malu Sophia','Isaac Murilo Benjamin da Cruz',4,3,2,NULL,NULL),(24,'Fernando Daniel Caio Freitas','1950-07-03','fernandodanilcaiofreitas@engeco.com.br','9198875-7408','67766267071','164846761','Lívia Sônia Raquel','Caleb Leandro Julio Freitas',7,3,2,NULL,NULL),(25,'Sandra Luna Elaine Gonçalves','1950-10-17','sandralunaelagoncalves@lukin4.com.br','8299998-2517','24390141929','271078868','Emilly Eduarda Gabriela','Manuel Pedro Gonçalves',7,2,2,NULL,NULL),(26,'Arthur Luís Vitor da Silva','2002-08-09','aarthurluisvitordasilva@yaooh.com','8498890-8776','12611962790','324035834','Sophia Carla Eliane','Daniel Matheus da Silva',7,1,2,NULL,NULL),(27,'Diogo Severino Pinto','1949-12-17','diogoseverpinto@tpltransportes.com.br','2799939-7544','07107075683','214845023','Benedita Carla Agatha','Davi Giovanni Breno Pinto',2,2,1,NULL,NULL),(28,'Gabrielly Fernanda da Rocha','1947-11-23','gabriellyfe@caocarinho.com.br','6599751-2093','71410265765','327308278','Kamilly Vera Helena','Yago Vinicius Luís da Rocha',2,2,1,NULL,NULL),(29,'Vitória Giovanna Fabiana Ferreira','1960-11-01','vitoriagiovannrreira@trustsign.com.br','8699534-2177','41203512899','383483761','Benedita Laís Lavínia','Erick Bernardo Ferreira',2,5,1,NULL,NULL),(30,'Tereza Stefany Marli Moreira','1981-01-23','terezastefanymra@r7.com','6199323-6052','02836053755','235936546','Olivia Aurora Helena','Thomas Luís Nicolas Moreira',1,5,1,NULL,NULL);
/*!40000 ALTER TABLE `inscricao` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-05-24 11:27:47
