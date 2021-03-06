-- MySQL Script generated by MySQL Workbench
-- Thu Mar 22 17:27:37 2018
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema buecherei
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema buecherei
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `buecherei` DEFAULT CHARACTER SET latin1 ;
USE `buecherei` ;

-- -----------------------------------------------------
-- Table `buecherei`.`buecher_autor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `buecherei`.`buecher_autor` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Autor` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB
AUTO_INCREMENT = 37
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `buecherei`.`buecher_genre`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `buecherei`.`buecher_genre` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Genre` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB
AUTO_INCREMENT = 17
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `buecherei`.`buecher_verlage`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `buecherei`.`buecher_verlage` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Verlag` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB
AUTO_INCREMENT = 20
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `buecherei`.`buch`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `buecherei`.`buch` (
  `ISBN` VARCHAR(14) NOT NULL,
  `Titel` VARCHAR(45) NULL DEFAULT NULL,
  `buecher_autor_ID` INT(11) NOT NULL,
  `buecher_genre_ID` INT(11) NOT NULL,
  `verlage_ID` INT(11) NOT NULL,
  PRIMARY KEY (`ISBN`),
  INDEX `fk_Buecher_buecher_autor_idx` (`buecher_autor_ID` ASC),
  INDEX `fk_Buecher_buecher_genre1_idx` (`buecher_genre_ID` ASC),
  INDEX `fk_Buecher_verlage1_idx` (`verlage_ID` ASC),
  CONSTRAINT `fk_Buecher_buecher_autor`
    FOREIGN KEY (`buecher_autor_ID`)
    REFERENCES `buecherei`.`buecher_autor` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Buecher_buecher_genre1`
    FOREIGN KEY (`buecher_genre_ID`)
    REFERENCES `buecherei`.`buecher_genre` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Buecher_verlage1`
    FOREIGN KEY (`verlage_ID`)
    REFERENCES `buecherei`.`buecher_verlage` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `buecherei`.`leser`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `buecherei`.`leser` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Vorname` VARCHAR(45) NULL DEFAULT NULL,
  `Nachname` VARCHAR(45) NULL DEFAULT NULL,
  `Hausnummer` VARCHAR(45) NULL DEFAULT NULL,
  `Straße` VARCHAR(45) NULL DEFAULT NULL,
  `Ort` VARCHAR(45) NULL DEFAULT NULL,
  `PLZ` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `buecherei`.`ausleihen`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `buecherei`.`ausleihen` (
  `ausleihenid` INT(11) NOT NULL,
  `Leser_ID` INT(11) NOT NULL,
  `Buch_ISBN` VARCHAR(14) NOT NULL,
  PRIMARY KEY (`ausleihenid`, `Leser_ID`, `Buch_ISBN`),
  INDEX `fk_Leser_has_Buch_Buch2_idx` (`Buch_ISBN` ASC),
  INDEX `fk_Leser_has_Buch_Leser2_idx` (`Leser_ID` ASC),
  CONSTRAINT `fk_Leser_has_Buch_Buch2`
    FOREIGN KEY (`Buch_ISBN`)
    REFERENCES `buecherei`.`buch` (`ISBN`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Leser_has_Buch_Leser2`
    FOREIGN KEY (`Leser_ID`)
    REFERENCES `buecherei`.`leser` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `buecherei`.`mitarbeiter`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `buecherei`.`mitarbeiter` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Vorname` VARCHAR(45) NULL DEFAULT NULL,
  `Passwort` VARCHAR(32) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB
AUTO_INCREMENT = 13
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `buecherei`.`reservierungen`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `buecherei`.`reservierungen` (
  `reservierungs_id` INT(11) NOT NULL,
  `Leser_ID` INT(11) NOT NULL,
  `Buch_ISBN` VARCHAR(14) NOT NULL,
  PRIMARY KEY (`reservierungs_id`, `Leser_ID`, `Buch_ISBN`),
  INDEX `fk_Leser_has_Buch_Buch1_idx` (`Buch_ISBN` ASC),
  INDEX `fk_Leser_has_Buch_Leser1_idx` (`Leser_ID` ASC),
  CONSTRAINT `fk_Leser_has_Buch_Buch1`
    FOREIGN KEY (`Buch_ISBN`)
    REFERENCES `buecherei`.`buch` (`ISBN`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Leser_has_Buch_Leser1`
    FOREIGN KEY (`Leser_ID`)
    REFERENCES `buecherei`.`leser` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
