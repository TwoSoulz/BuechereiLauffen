-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`buch`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`buch` (
  `ISBN` INT NOT NULL,
  `name` VARCHAR(45) NULL,
  `autor` VARCHAR(45) NULL,
  `verlag` VARCHAR(45) NULL,
  `titel` VARCHAR(45) NULL,
  `ausgeliehen` DATETIME NULL,
  `reserviert` DATETIME NULL,
  PRIMARY KEY (`ISBN`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`user` (
  `benutzer` VARCHAR(45) NOT NULL,
  `passwort` VARCHAR(45) NULL,
  PRIMARY KEY (`benutzer`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`kunden`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`kunden` (
  `idkunden` INT NOT NULL AUTO_INCREMENT,
  `vorname` VARCHAR(45) NULL,
  `nachname` VARCHAR(45) NULL,
  `straße` VARCHAR(45) NULL,
  `hausnummer` VARCHAR(45) NULL,
  `plz` VARCHAR(45) NULL,
  `ort` VARCHAR(45) NULL,
  `kundencol` VARCHAR(45) NULL,
  PRIMARY KEY (`idkunden`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`ausleihen`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`ausleihen` (
  `datum_ausgeliehen` DATETIME NULL,
  `kunden_idkunden` INT NOT NULL,
  `buch_ISBN` INT NOT NULL,
  INDEX `fk_ausleihen_kunden1_idx` (`kunden_idkunden` ASC),
  INDEX `fk_ausleihen_buch1_idx` (`buch_ISBN` ASC),
  CONSTRAINT `fk_ausleihen_kunden1`
    FOREIGN KEY (`kunden_idkunden`)
    REFERENCES `mydb`.`kunden` (`idkunden`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ausleihen_buch1`
    FOREIGN KEY (`buch_ISBN`)
    REFERENCES `mydb`.`buch` (`ISBN`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
