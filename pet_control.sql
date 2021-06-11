-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 11, 2021 at 05:32 AM
-- Server version: 10.4.19-MariaDB
-- PHP Version: 7.4.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pet_control`
--

-- --------------------------------------------------------

--
-- Table structure for table `cita`
--

CREATE TABLE `cita` (
  `Id` int(11) NOT NULL,
  `Fecha` date NOT NULL,
  `Hora` time NOT NULL,
  `Codigo` varchar(100) NOT NULL,
  `Fk_doctor` int(11) NOT NULL,
  `Fk_Mascota` int(11) NOT NULL,
  `Motivo` varchar(255) NOT NULL,
  `Notas` varchar(255) DEFAULT NULL,
  `Status` int(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `cita`
--

INSERT INTO `cita` (`Id`, `Fecha`, `Hora`, `Codigo`, `Fk_doctor`, `Fk_Mascota`, `Motivo`, `Notas`, `Status`) VALUES
(1, '2021-06-13', '15:30:00', 'CT0001', 2, 1, 'Tratamiento', 'Requiero factura', 0),
(25, '2021-06-11', '06:30:00', '237aa4c0', 2, 2, 'Corte de pelo y baño', 'Saludos', 0);

-- --------------------------------------------------------

--
-- Table structure for table `cliente`
--

CREATE TABLE `cliente` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) DEFAULT NULL,
  `Apellidos` varchar(200) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `Fk_tipo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `cliente`
--

INSERT INTO `cliente` (`Id`, `Nombre`, `Apellidos`, `Email`, `Password`, `Fk_tipo`) VALUES
(1, 'Mario', 'Villalpando', 'eltrunco@gmail.com', '123', 2),
(17, 'Trunco', 'Lopez', 'trunco@gmail.com', '123', 2),
(18, 'Christian', 'Ochoa', 'deadchri5h@gmail.com', '123', 2),
(19, 'Juan Pablo', 'Gutierrez', 'jp20110468@ceti.mx', '123', 2),
(20, 'Adriana', 'Espinosa', 'liloth00814@gmail.com', '123', 2);

-- --------------------------------------------------------

--
-- Table structure for table `doctor`
--

CREATE TABLE `doctor` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Apellidos` varchar(200) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `Fk_tipo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `doctor`
--

INSERT INTO `doctor` (`Id`, `Nombre`, `Apellidos`, `Email`, `Password`, `Fk_tipo`) VALUES
(1, 'Mario', 'Villalpando Montoya', 'mario@veterinaria.com', '123', 1),
(2, 'Juan Pablo', 'Rodríguez Gutíerrez', 'nito@veterinaria.com', '123', 1),
(3, 'Christian', 'Ochoa Hernández', 'chris@veterinaria.com', '123', 1),
(4, 'Adriana', 'Espinosa López', 'adriana@veterinaria.com', '123', 1),
(5, 'Luis', 'García Montoya', 'Luis@veterinaria.com', '123', 1);

-- --------------------------------------------------------

--
-- Table structure for table `emergencia`
--

CREATE TABLE `emergencia` (
  `Id` int(11) NOT NULL,
  `Fecha` date NOT NULL,
  `Hora` time NOT NULL,
  `descripcion` longtext NOT NULL,
  `Tipo` varchar(100) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Edad` int(11) NOT NULL,
  `Sexo` varchar(20) NOT NULL,
  `Fk_receta` int(11) NOT NULL,
  `Fk_doctor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `mascota`
--

CREATE TABLE `mascota` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Sexo` varchar(20) NOT NULL,
  `Edad` int(11) NOT NULL,
  `Fk_tipo` int(11) NOT NULL,
  `Fk_dueno` int(11) NOT NULL,
  `Fk_cita` int(11) DEFAULT NULL,
  `Fk_receta` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `mascota`
--

INSERT INTO `mascota` (`Id`, `Nombre`, `Sexo`, `Edad`, `Fk_tipo`, `Fk_dueno`, `Fk_cita`, `Fk_receta`) VALUES
(1, 'Bruno', 'Macho', 8, 1, 18, 1, NULL),
(2, 'Patrick', 'Macho', 2, 1, 18, 25, NULL),
(20, 'Zicza', 'Hembra', 6, 1, 20, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `receta`
--

CREATE TABLE `receta` (
  `Id` int(11) NOT NULL,
  `Medicamento` varchar(100) NOT NULL,
  `Dias_tratamiento` varchar(100) NOT NULL,
  `Fk_doctor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `typepet`
--

CREATE TABLE `typepet` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Tipo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `typepet`
--

INSERT INTO `typepet` (`Id`, `Nombre`, `Tipo`) VALUES
(1, 'Perro', 1),
(2, 'Gato', 2),
(3, 'Roedor', 3),
(4, 'Reptil', 4),
(5, 'Ave', 5),
(6, 'Otro', 6);

-- --------------------------------------------------------

--
-- Table structure for table `typeuser`
--

CREATE TABLE `typeuser` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Tipo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `typeuser`
--

INSERT INTO `typeuser` (`Id`, `Nombre`, `Tipo`) VALUES
(1, 'Doctor', 1),
(2, 'Usuario', 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `cita`
--
ALTER TABLE `cita`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk-doctor` (`Fk_doctor`),
  ADD KEY `Fk_Mascota` (`Fk_Mascota`);

--
-- Indexes for table `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk-usuarios` (`Fk_tipo`);

--
-- Indexes for table `doctor`
--
ALTER TABLE `doctor`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk-doctores` (`Fk_tipo`);

--
-- Indexes for table `emergencia`
--
ALTER TABLE `emergencia`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk-doc` (`Fk_doctor`),
  ADD KEY `fk-recetilla` (`Fk_receta`);

--
-- Indexes for table `mascota`
--
ALTER TABLE `mascota`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk-tipom` (`Fk_tipo`),
  ADD KEY `fk-dueno` (`Fk_dueno`),
  ADD KEY `fk-cita` (`Fk_cita`),
  ADD KEY `fk-receta` (`Fk_receta`);

--
-- Indexes for table `receta`
--
ALTER TABLE `receta`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk-doctorcito` (`Fk_doctor`);

--
-- Indexes for table `typepet`
--
ALTER TABLE `typepet`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `typeuser`
--
ALTER TABLE `typeuser`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `cita`
--
ALTER TABLE `cita`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT for table `cliente`
--
ALTER TABLE `cliente`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `doctor`
--
ALTER TABLE `doctor`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `emergencia`
--
ALTER TABLE `emergencia`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `mascota`
--
ALTER TABLE `mascota`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `receta`
--
ALTER TABLE `receta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `typepet`
--
ALTER TABLE `typepet`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `typeuser`
--
ALTER TABLE `typeuser`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `cita`
--
ALTER TABLE `cita`
  ADD CONSTRAINT `cita_ibfk_1` FOREIGN KEY (`Fk_Mascota`) REFERENCES `mascota` (`Id`),
  ADD CONSTRAINT `fk-doctor` FOREIGN KEY (`Fk_doctor`) REFERENCES `doctor` (`Id`);

--
-- Constraints for table `cliente`
--
ALTER TABLE `cliente`
  ADD CONSTRAINT `fk-usuarios` FOREIGN KEY (`Fk_tipo`) REFERENCES `typeuser` (`Id`);

--
-- Constraints for table `doctor`
--
ALTER TABLE `doctor`
  ADD CONSTRAINT `fk-doctores` FOREIGN KEY (`Fk_tipo`) REFERENCES `typeuser` (`Id`);

--
-- Constraints for table `emergencia`
--
ALTER TABLE `emergencia`
  ADD CONSTRAINT `fk-doc` FOREIGN KEY (`Fk_doctor`) REFERENCES `doctor` (`Id`),
  ADD CONSTRAINT `fk-recetilla` FOREIGN KEY (`Fk_receta`) REFERENCES `receta` (`Id`);

--
-- Constraints for table `mascota`
--
ALTER TABLE `mascota`
  ADD CONSTRAINT `fk-cita` FOREIGN KEY (`Fk_cita`) REFERENCES `cita` (`Id`),
  ADD CONSTRAINT `fk-dueno` FOREIGN KEY (`Fk_dueno`) REFERENCES `cliente` (`Id`),
  ADD CONSTRAINT `fk-receta` FOREIGN KEY (`Fk_receta`) REFERENCES `receta` (`Id`),
  ADD CONSTRAINT `fk-tipom` FOREIGN KEY (`Fk_tipo`) REFERENCES `typepet` (`Id`);

--
-- Constraints for table `receta`
--
ALTER TABLE `receta`
  ADD CONSTRAINT `fk-doctorcito` FOREIGN KEY (`Fk_doctor`) REFERENCES `doctor` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
