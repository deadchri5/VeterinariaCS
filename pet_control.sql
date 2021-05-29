-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 29-05-2021 a las 05:05:41
-- Versión del servidor: 10.4.14-MariaDB
-- Versión de PHP: 7.4.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `pet_control`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cita`
--

CREATE TABLE `cita` (
  `Id` int(11) NOT NULL,
  `Fecha` date NOT NULL,
  `Hora` time NOT NULL,
  `Codigo` varchar(100) NOT NULL,
  `Fk_doctor` int(11) NOT NULL,
  `Fk_Mascota` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `cita`
--

INSERT INTO `cita` (`Id`, `Fecha`, `Hora`, `Codigo`, `Fk_doctor`, `Fk_Mascota`) VALUES
(1, '2021-06-13', '15:30:00', 'CT0001', 2, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cliente`
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
-- Volcado de datos para la tabla `cliente`
--

INSERT INTO `cliente` (`Id`, `Nombre`, `Apellidos`, `Email`, `Password`, `Fk_tipo`) VALUES
(1, 'Mario', 'Villalpando', 'eltrunco@gmail.com', '123', 2),
(17, 'Trunco', 'Lopez', 'trunco@gmail.com', '123', 2),
(18, 'Christian', 'Ochoa', 'deadchri5h@gmail.com', '123', 2),
(19, 'Juan Pablo', 'Gutierrez', 'jp20110468@ceti.mx', '123', 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `doctor`
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
-- Volcado de datos para la tabla `doctor`
--

INSERT INTO `doctor` (`Id`, `Nombre`, `Apellidos`, `Email`, `Password`, `Fk_tipo`) VALUES
(1, 'Mario', 'Villalpando Montoya', 'mario@veterinaria.com', '123', 1),
(2, 'Juan Pablo', 'Rodríguez Gutíerrez', 'nito@veterinaria.com', '123', 1),
(3, 'Christian', 'Ochoa Hernández', 'chris@veterinaria.com', '123', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `emergencia`
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
-- Estructura de tabla para la tabla `mascota`
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
-- Volcado de datos para la tabla `mascota`
--

INSERT INTO `mascota` (`Id`, `Nombre`, `Sexo`, `Edad`, `Fk_tipo`, `Fk_dueno`, `Fk_cita`, `Fk_receta`) VALUES
(1, 'Bruno', 'Macho', 8, 1, 18, NULL, NULL),
(2, 'Marcelo', 'Macho', 5, 2, 19, NULL, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `receta`
--

CREATE TABLE `receta` (
  `Id` int(11) NOT NULL,
  `Medicamento` varchar(100) NOT NULL,
  `Dias_tratamiento` varchar(100) NOT NULL,
  `Fk_doctor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `typepet`
--

CREATE TABLE `typepet` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Tipo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `typepet`
--

INSERT INTO `typepet` (`Id`, `Nombre`, `Tipo`) VALUES
(1, 'Perro', 1),
(2, 'Gato', 2),
(3, 'Roedor', 3);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `typeuser`
--

CREATE TABLE `typeuser` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Tipo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `typeuser`
--

INSERT INTO `typeuser` (`Id`, `Nombre`, `Tipo`) VALUES
(1, 'Doctor', 1),
(2, 'Usuario', 2);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `cita`
--
ALTER TABLE `cita`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk-doctor` (`Fk_doctor`);

--
-- Indices de la tabla `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk-usuarios` (`Fk_tipo`);

--
-- Indices de la tabla `doctor`
--
ALTER TABLE `doctor`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk-doctores` (`Fk_tipo`);

--
-- Indices de la tabla `emergencia`
--
ALTER TABLE `emergencia`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk-doc` (`Fk_doctor`),
  ADD KEY `fk-recetilla` (`Fk_receta`);

--
-- Indices de la tabla `mascota`
--
ALTER TABLE `mascota`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk-tipom` (`Fk_tipo`),
  ADD KEY `fk-dueno` (`Fk_dueno`),
  ADD KEY `fk-cita` (`Fk_cita`),
  ADD KEY `fk-receta` (`Fk_receta`);

--
-- Indices de la tabla `receta`
--
ALTER TABLE `receta`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk-doctorcito` (`Fk_doctor`);

--
-- Indices de la tabla `typepet`
--
ALTER TABLE `typepet`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `typeuser`
--
ALTER TABLE `typeuser`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `cita`
--
ALTER TABLE `cita`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `cliente`
--
ALTER TABLE `cliente`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT de la tabla `doctor`
--
ALTER TABLE `doctor`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `emergencia`
--
ALTER TABLE `emergencia`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `receta`
--
ALTER TABLE `receta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `typepet`
--
ALTER TABLE `typepet`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `typeuser`
--
ALTER TABLE `typeuser`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `cita`
--
ALTER TABLE `cita`
  ADD CONSTRAINT `Fk_Mascota` FOREIGN KEY (`Id`) REFERENCES `mascota` (`Id`),
  ADD CONSTRAINT `fk-doctor` FOREIGN KEY (`Fk_doctor`) REFERENCES `doctor` (`Id`);

--
-- Filtros para la tabla `cliente`
--
ALTER TABLE `cliente`
  ADD CONSTRAINT `fk-usuarios` FOREIGN KEY (`Fk_tipo`) REFERENCES `typeuser` (`Id`);

--
-- Filtros para la tabla `doctor`
--
ALTER TABLE `doctor`
  ADD CONSTRAINT `fk-doctores` FOREIGN KEY (`Fk_tipo`) REFERENCES `typeuser` (`Id`);

--
-- Filtros para la tabla `emergencia`
--
ALTER TABLE `emergencia`
  ADD CONSTRAINT `fk-doc` FOREIGN KEY (`Fk_doctor`) REFERENCES `doctor` (`Id`),
  ADD CONSTRAINT `fk-recetilla` FOREIGN KEY (`Fk_receta`) REFERENCES `receta` (`Id`);

--
-- Filtros para la tabla `mascota`
--
ALTER TABLE `mascota`
  ADD CONSTRAINT `fk-cita` FOREIGN KEY (`Fk_cita`) REFERENCES `cita` (`Id`),
  ADD CONSTRAINT `fk-dueno` FOREIGN KEY (`Fk_dueno`) REFERENCES `cliente` (`Id`),
  ADD CONSTRAINT `fk-receta` FOREIGN KEY (`Fk_receta`) REFERENCES `receta` (`Id`),
  ADD CONSTRAINT `fk-tipom` FOREIGN KEY (`Fk_tipo`) REFERENCES `typepet` (`Id`);

--
-- Filtros para la tabla `receta`
--
ALTER TABLE `receta`
  ADD CONSTRAINT `fk-doctorcito` FOREIGN KEY (`Fk_doctor`) REFERENCES `doctor` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
