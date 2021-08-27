/*
SQLyog Ultimate v9.62 
MySQL - 5.6.37-log : Database - user
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`softeng_user` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `softeng_user`;

/*Table structure for table `account` */

DROP TABLE IF EXISTS `account`;

CREATE TABLE `account` (
  `primekey` INT(11) NOT NULL AUTO_INCREMENT,
  `username` TINYTEXT NOT NULL,
  `passcode` TINYTEXT NOT NULL,
  `fullname` TINYTEXT NOT NULL,
  `gender` TINYTEXT NOT NULL,
  `course` TINYTEXT NOT NULL,
  `id` TINYTEXT NOT NULL,
  `member` TINYTEXT NOT NULL,
  `schoolyear` TINYTEXT,
  `semester` TINYTEXT,
  PRIMARY KEY (`primekey`),
  UNIQUE KEY `fullname` (`fullname`(50)),
  UNIQUE KEY `username` (`username`(15)),
  UNIQUE KEY `passcode` (`passcode`(15)),
  UNIQUE KEY `id` (`id`(8))
) ENGINE=INNODB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

/*Data for the table `account` */

INSERT  INTO `account`(`primekey`,`username`,`passcode`,`fullname`,`gender`,`course`,`id`,`member`,`schoolyear`,`semester`) VALUES (7,'du30','35AO378O69CO288O301O359O260O2E0O340O160O100O200O260O2E0O340O160O100O200O260O2E0O340O160O100O200O260O2E0O340O160O100O200O260O2E0O340O160O100O200O','RODRIGO R. DUTERTE','MALE','Batchelor of Science in Computer Engineering','3030','INSTRUCTOR','2019-2020','2nd'),(8,'caz','4A6O450O7F4O3D8O357O401O260O2E0O340O160O100O200O260O2E0O340O160O100O200O260O2E0O340O160O100O200O260O2E0O340O160O100O200O260O2E0O340O160O100O200O','ZACCRIO M. GARCIA','MALE','Batchelor of Science in Computer Engineering 4-B','192168','STUDENT','2019-2020','2nd'),(9,'max','50AO470O839O422O35AO43BO260O2E0O340O160O100O200O260O2E0O340O160O100O200O260O2E0O340O160O100O200O260O2E0O340O160O100O200O260O2E0O340O160O100O200O','MAX ANGELO  D. PERIN','MALE','Batchelor of Science in Computer Engineering','12345','INSTRUCTOR','2019-2020','2nd');

/*Table structure for table `addsubject` */

DROP TABLE IF EXISTS `addsubject`;

CREATE TABLE `addsubject` (
  `pkey` INT(11) NOT NULL AUTO_INCREMENT,
  `subId` INT(11) NOT NULL,
  `subCode` TINYTEXT NOT NULL,
  `subDescription` TINYTEXT NOT NULL,
  `lec` TEXT NOT NULL,
  `lab` TEXT NOT NULL,
  `unit` TEXT NOT NULL,
  `instructor` TINYTEXT NOT NULL,
  `schoolyear` TEXT NOT NULL,
  `semester` TINYTEXT NOT NULL,
  `studentName` TINYTEXT NOT NULL,
  PRIMARY KEY (`pkey`)
) ENGINE=INNODB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Data for the table `addsubject` */

INSERT  INTO `addsubject`(`pkey`,`subId`,`subCode`,`subDescription`,`lec`,`lab`,`unit`,`instructor`,`schoolyear`,`semester`,`studentName`) VALUES (1,8,'1111','test1','2','2','4','MAX ANGELO D. PERIN','2019-2020','2nd','ZACCRIO M. GARCIA'),(2,9,'222','test2','3','3','6','MAX ANGELO D. PERIN','2019-2020','2nd','ZACCRIO M. GARCIA');

/*Table structure for table `createsubject` */

DROP TABLE IF EXISTS `createsubject`;

CREATE TABLE `createsubject` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `subCode` TINYTEXT NOT NULL,
  `subDescription` TINYTEXT NOT NULL,
  `lec` TEXT NOT NULL,
  `lab` TEXT NOT NULL,
  `units` TEXT NOT NULL,
  `instructor` TINYTEXT NOT NULL,
  `schoolyear` TEXT NOT NULL,
  `semester` TINYTEXT NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=INNODB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

/*Data for the table `createsubject` */

INSERT  INTO `createsubject`(`id`,`subCode`,`subDescription`,`lec`,`lab`,`units`,`instructor`,`schoolyear`,`semester`) VALUES (8,'1111','test1','2','2','4','MAX ANGELO D. PERIN','2019-2020','2nd'),(9,'222','test2','3','3','6','MAX ANGELO D. PERIN','2019-2020','2nd');

/* Procedure structure for procedure `getuser` */

/*!50003 DROP PROCEDURE IF EXISTS  `getuser` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `getuser`(in p_username text, in p_passcode text)
    READS SQL DATA
BEGIN
    
    
    select *
    from account
    where username = p_username
    and passcode = p_passcode;
    END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
