-- MySQL dump 10.13  Distrib 8.0.34, for macos13 (arm64)
--
-- Host: localhost    Database: blazor_cart
-- ------------------------------------------------------
-- Server version	8.2.0

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
-- Table structure for table `Products`
--

DROP TABLE IF EXISTS `Products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Products` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  `Description` longtext NOT NULL,
  `ImageURL` longtext NOT NULL,
  `Price` decimal(18,2) NOT NULL,
  `Qty` int NOT NULL,
  `CategoryId` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Products`
--

LOCK TABLES `Products` WRITE;
/*!40000 ALTER TABLE `Products` DISABLE KEYS */;
INSERT INTO `Products` VALUES (1,'Glossier - Beauty Kit','A kit provided by Glossier, containing skin care, hair care and makeup products','/Images/Beauty/Beauty1.png',100.00,100,1),(2,'Curology - Skin Care Kit','A kit provided by Curology, containing skin care products','/Images/Beauty/Beauty2.png',50.00,45,1),(3,'Cocooil - Organic Coconut Oil','A kit provided by Curology, containing skin care products','/Images/Beauty/Beauty3.png',20.00,30,1),(4,'Schwarzkopf - Hair Care and Skin Care Kit','A kit provided by Schwarzkopf, containing skin care and hair care products','/Images/Beauty/Beauty4.png',50.00,60,1),(5,'Skin Care Kit','Skin Care Kit, containing skin care and hair care products','/Images/Beauty/Beauty5.png',30.00,85,1),(6,'Air Pods','Air Pods - in-ear wireless headphones','/Images/Electronic/Electronics1.png',100.00,120,3),(7,'On-ear Golden Headphones','On-ear Golden Headphones - these headphones are not wireless','/Images/Electronic/Electronics2.png',40.00,200,3),(8,'On-ear Black Headphones','On-ear Black Headphones - these headphones are not wireless','/Images/Electronic/Electronics3.png',40.00,300,3),(9,'Sennheiser Digital Camera with Tripod','Sennheiser Digital Camera - High quality digital camera provided by Sennheiser - includes tripod','/Images/Electronic/Electronic4.png',600.00,20,3),(10,'Canon Digital Camera','Canon Digital Camera - High quality digital camera provided by Canon','/Images/Electronic/Electronic5.png',500.00,15,3),(11,'Nintendo Gameboy','Gameboy - Provided by Nintendo','/Images/Electronic/technology6.png',100.00,60,3),(12,'Black Leather Office Chair','Very comfortable black leather office chair','/Images/Furniture/Furniture1.png',50.00,212,2),(13,'Pink Leather Office Chair','Very comfortable pink leather office chair','/Images/Furniture/Furniture2.png',50.00,112,2),(14,'Lounge Chair','Very comfortable lounge chair','/Images/Furniture/Furniture3.png',70.00,90,2),(15,'Silver Lounge Chair','Very comfortable Silver lounge chair','/Images/Furniture/Furniture4.png',120.00,95,2),(16,'Porcelain Table Lamp','White and blue Porcelain Table Lamp','/Images/Furniture/Furniture6.png',15.00,100,2),(17,'Office Table Lamp','Office Table Lamp','/Images/Furniture/Furniture7.png',20.00,73,2),(18,'Puma Sneakers','Comfortable Puma Sneakers in most sizes','/Images/Shoes/Shoes1.png',100.00,50,4),(19,'Colorful Trainers','Colorful trainsers - available in most sizes','/Images/Shoes/Shoes2.png',150.00,60,4),(20,'Blue Nike Trainers','Blue Nike Trainers - available in most sizes','/Images/Shoes/Shoes3.png',200.00,70,4),(21,'Colorful Hummel Trainers','Colorful Hummel Trainers - available in most sizes','/Images/Shoes/Shoes4.png',120.00,120,4),(22,'Red Nike Trainers','Red Nike Trainers - available in most sizes','/Images/Shoes/Shoes5.png',200.00,100,4),(23,'Birkenstock Sandles','Birkenstock Sandles - available in most sizes','/Images/Shoes/Shoes6.png',50.00,150,4);
/*!40000 ALTER TABLE `Products` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-11 20:01:39
