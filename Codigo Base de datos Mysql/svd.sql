-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 25-11-2023 a las 20:22:15
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.0.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `svd`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `ObtenerUsuarios` ()   BEGIN
    SELECT `idusuario`,`idrol`,`nombre`,`telefono`,`email`,`Balance` FROM usuario;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_articulo` ()   BEGIN
    SELECT idcategoria AS ID ,codigo as Codigo,nombre AS Nombre,precio_venta As Precio ,stock as Cantidad,descripcion as Descripción FROM articulo;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_articulos` ()   BEGIN
    SELECT * FROM articulo;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_listar_articulos` ()   BEGIN
    SELECT idarticulo AS ID, idcategoria AS ID_Categoria, codigo AS Codigo, nombre AS Nombre, precio_venta AS Precio, stock AS Cantidad, descripcion AS Descripcion FROM articulo;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `articulo`
--

CREATE TABLE `articulo` (
  `idarticulo` int(11) NOT NULL,
  `idcategoria` int(11) NOT NULL,
  `codigo` varchar(50) DEFAULT NULL,
  `nombre` varchar(100) NOT NULL,
  `precio_venta` decimal(11,2) NOT NULL,
  `stock` int(11) NOT NULL,
  `descripcion` varchar(256) DEFAULT NULL,
  `estado` bit(1) DEFAULT b'1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `articulo`
--

INSERT INTO `articulo` (`idarticulo`, `idcategoria`, `codigo`, `nombre`, `precio_venta`, `stock`, `descripcion`, `estado`) VALUES
(2, 2, 'EL10001', 'Teléfono inteligente', 7599.99, 45, 'Teléfono de última generación', b'1'),
(3, 2, 'EL10002', 'Tablet', 4299.99, 29, 'Tablet con pantalla de alta resolución', b'1'),
(4, 2, 'EL10003', 'Auriculares inalámbricos', 1199.99, 100, 'Auriculares con tecnología Bluetooth', b'1'),
(5, 3, 'RO20001', 'Camiseta de algodón', 319.99, 195, 'Camiseta cómoda y transpirable', b'1'),
(6, 3, 'RO20002', 'Jeans ajustados', 739.99, 149, 'Jeans de diseño moderno', b'1'),
(7, 3, 'RO20003', 'Zapatillas deportivas', 2649.99, 100, 'Zapatillas ideales para el gimnasio', b'1'),
(8, 2, 'EL10004', 'Smartwatch', 51149.99, 40, 'Reloj inteligente con funciones avanzadas', b'1'),
(9, 2, 'EL10005', 'Cargador inalámbrico', 1229.99, 100, 'Cargador compatible con dispositivos compatibles con carga inalámbrica', b'1'),
(10, 2, 'EL10006', 'Altavoz Bluetooth', 4779.99, 60, 'Altavoz portátil con conectividad Bluetooth', b'1'),
(11, 3, 'AR20004', 'Vestido de verano', 1229.99, 80, 'Vestido ligero y cómodo para el verano', b'1'),
(12, 3, 'AR20005', 'Chaqueta de cuero', 3589.99, 50, 'Chaqueta de cuero genuino con diseño elegante', b'1'),
(13, 3, 'AR20006', 'Bufanda tejida', 514.99, 120, 'Bufanda suave y cálida para el invierno', b'1'),
(14, 6, 'Al30001', 'Café gourmet', 239.99, 200, 'Paquete de café de gran calidad', b'1'),
(15, 6, 'AL30002', 'Chocolate artesanal', 166.99, 150, 'Tableta de chocolate elaborada con ingredientes naturales', b'1'),
(16, 6, 'AL30003', 'Frutos secos surtidos', 128.99, 180, 'Mezcla de frutos secos para un snack saludable', b'1'),
(17, 4, 'HO40004', 'Set de utensilios de cocina', 49.99, 60, 'Colección completa de utensilios de cocina de alta calidad', b'1'),
(18, 4, 'HO40005', 'Cojines decorativos', 419.99, 100, 'Cojines con diseños variados para embellecer tu hogar', b'1'),
(19, 4, 'HO40006', 'Lámpara de pie moderna', 4679.99, 30, 'Lámpara elegante para iluminación ambiental en interiores', b'1'),
(20, 7, 'BE50004', 'Kit de maquillaje profesional', 3069.99, 47, 'Conjunto completo de maquillaje para lograr looks profesionales', b'1'),
(21, 7, 'BE50005', 'Cremas hidratantes orgánicas', 1629.99, 80, 'Cremas naturales para el cuidado de la piel', b'1'),
(22, 7, 'BE50006', 'Secador de cabello iónico', 3049.99, 40, 'Secador de pelo avanzado para un secado rápido y cuidado del cabello', b'1'),
(23, 5, 'DE60004', 'Pelota de fútbol profesional', 1524.99, 100, 'Pelota de fútbol de alta calidad para partidos profesionales', b'1'),
(24, 5, 'DE60005', 'Raqueta de tenis', 3249.99, 80, 'Raqueta diseñada para mejorar el rendimiento en la cancha', b'1'),
(25, 5, 'DE60006', 'Bicicleta de montaña', 10299.99, 30, 'Bicicleta resistente diseñada para terrenos difíciles', b'1'),
(26, 1, 'AR70001', 'Arroz blanco premium', 55.99, 198, 'Arroz de grano largo y suave, ideal para acompañar tus comidas', b'1'),
(27, 1, 'AR70002', 'Arroz integral orgánico', 34.99, 150, 'Arroz integral rico en nutrientes y fibra, perfecto para una alimentación saludable', b'1'),
(28, 1, 'AR70003', 'Arroz jazmín fragante', 86.49, 100, 'Arroz jazmín de aroma delicado, ideal para platos asiáticos', b'1'),
(29, 1, 'AR70004', 'Arroz basmati aromático', 57.99, 120, 'Arroz basmati de grano largo y fragante, perfecto para platos de la India', b'1'),
(30, 1, 'AR70005', 'Arroz negro gourmet', 128.99, 80, 'Arroz negro de sabor exquisito, ideal para platos gourmet y creativos', b'1'),
(31, 9, 'LB1001', 'El Gran Gatsby', 815.99, 25, 'Clásico de la literatura americana', b'1'),
(32, 9, 'LB1002', 'Cien años de soledad', 712.50, 18, 'Obra maestra de Gabriel García Márquez', b'1'),
(33, 9, 'LB1003', 'Harry Potter y la piedra filosofal', 610.75, 30, 'Inicio de la famosa saga de J.K. Rowling', b'1'),
(34, 8, 'JT2001', 'Muñeca Barbie', 219.99, 40, 'Clásico juguete para niñas', b'1'),
(35, 8, 'JT2002', 'Lego Creator', 929.99, 15, 'Set de construcción creativa para niños', b'1'),
(36, 8, 'JT2003', 'Carrusel musical', 514.50, 20, 'Juguete musical para bebés y niños pequeños', b'1'),
(37, 10, 'AU3004', 'Toyota Camry 2023', 1250000.00, 4, 'Sedán de alta calidad y rendimiento.', b'1'),
(38, 10, 'AU3005', 'Ford Mustang GT', 3450000.00, 3, 'Deportivo icónico con motor potente.', b'1'),
(39, 10, 'AU3006', 'Chevrolet Silverado 1500', 2350000.00, 4, 'Camioneta pickup versátil y resistente.', b'1'),
(40, 11, 'MU4001', 'Silla de comedor', 49.99, 20, 'Silla ergonómica para comedor', b'1'),
(41, 11, 'MU4002', 'Mesa de centro', 69.50, 15, 'Mesa de centro moderna con espacio de almacenamiento', b'1'),
(42, 11, 'MU4003', 'Sofá seccional', 349.99, 10, 'Sofá amplio y cómodo para la sala de estar', b'1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categoria`
--

CREATE TABLE `categoria` (
  `idcategoria` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `descripcion` varchar(256) DEFAULT NULL,
  `estado` bit(1) DEFAULT b'1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `categoria`
--

INSERT INTO `categoria` (`idcategoria`, `nombre`, `descripcion`, `estado`) VALUES
(1, 'Arroz', 'Arroz Campos', b'1'),
(2, 'Electrónica', 'Productos electrónicos y gadgets', b'1'),
(3, 'Ropa', 'Ropa y accesorios de moda', b'1'),
(4, 'Hogar', 'Artículos para el hogar y decoración', b'1'),
(5, 'Deportes', 'Equipos y artículos deportivos', b'1'),
(6, 'Alimentos', 'Productos alimenticios y comestibles', b'1'),
(7, 'Salud y Belleza', 'Productos de salud y belleza', b'1'),
(8, 'Juguetes', 'Juguetes y juegos para niños', b'1'),
(9, 'Libros', 'Libros y literatura', b'1'),
(10, 'Automóviles', 'Piezas y accesorios para automóviles', b'1'),
(11, 'Muebles', 'Muebles para el hogar y la oficina', b'1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalle_ingreso`
--

CREATE TABLE `detalle_ingreso` (
  `iddetalle_ingreso` int(11) NOT NULL,
  `idingreso` int(11) NOT NULL,
  `idarticulo` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `precio` decimal(11,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalle_venta`
--

CREATE TABLE `detalle_venta` (
  `iddetalle_venta` int(11) NOT NULL,
  `idventa` int(11) NOT NULL,
  `idarticulo` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `precio` decimal(11,2) NOT NULL,
  `descuento` decimal(11,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ingreso`
--

CREATE TABLE `ingreso` (
  `idingreso` int(11) NOT NULL,
  `idproveedor` int(11) NOT NULL,
  `idusuario` int(11) NOT NULL,
  `tipo_comprobante` varchar(20) NOT NULL,
  `serie_comprobante` varchar(7) DEFAULT NULL,
  `num_comprobante` varchar(10) NOT NULL,
  `fecha` datetime NOT NULL,
  `impuesto` decimal(4,2) NOT NULL,
  `total` decimal(11,2) NOT NULL,
  `estado` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persona`
--

CREATE TABLE `persona` (
  `idpersona` int(11) NOT NULL,
  `tipo_persona` varchar(20) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `tipo_documento` varchar(20) DEFAULT NULL,
  `num_documento` varchar(20) DEFAULT NULL,
  `direccion` varchar(70) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `rol`
--

CREATE TABLE `rol` (
  `idrol` int(11) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `descripcion` varchar(100) DEFAULT NULL,
  `estado` bit(1) DEFAULT b'1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `rol`
--

INSERT INTO `rol` (`idrol`, `nombre`, `descripcion`, `estado`) VALUES
(1, 'Usuario', 'Este rol es para lsa personas que quieren comprar en el sistemade ventas', b'1'),
(3, 'Admin', 'Administrador', b'0');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `idusuario` int(11) NOT NULL,
  `idrol` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `tipo_documento` varchar(20) DEFAULT NULL,
  `num_documento` varchar(20) DEFAULT NULL,
  `direccion` varchar(70) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `email` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `estado` bit(1) DEFAULT b'1',
  `Balance` int(25) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`idusuario`, `idrol`, `nombre`, `tipo_documento`, `num_documento`, `direccion`, `telefono`, `email`, `password`, `estado`, `Balance`) VALUES
(13, 3, 'Otto', NULL, NULL, 'Consuelo', '8494729732', 'ottorafaelg@gmail.com', '123', b'0', 1266922),
(14, 1, 'otto2', NULL, NULL, 'consueo', '21341', '21341', '123', b'1', 24510);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `venta`
--

CREATE TABLE `venta` (
  `idventa` int(11) NOT NULL,
  `idcliente` int(11) NOT NULL,
  `idusuario` int(11) NOT NULL,
  `tipo_comprobante` varchar(20) NOT NULL,
  `serie_comprobante` varchar(7) DEFAULT NULL,
  `num_comprobante` varchar(10) NOT NULL,
  `fecha_hora` datetime NOT NULL,
  `impuesto` decimal(4,2) NOT NULL,
  `total` decimal(11,2) NOT NULL,
  `estado` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `articulo`
--
ALTER TABLE `articulo`
  ADD PRIMARY KEY (`idarticulo`),
  ADD UNIQUE KEY `nombre` (`nombre`),
  ADD KEY `idcategoria` (`idcategoria`);

--
-- Indices de la tabla `categoria`
--
ALTER TABLE `categoria`
  ADD PRIMARY KEY (`idcategoria`),
  ADD UNIQUE KEY `nombre` (`nombre`);

--
-- Indices de la tabla `detalle_ingreso`
--
ALTER TABLE `detalle_ingreso`
  ADD PRIMARY KEY (`iddetalle_ingreso`),
  ADD KEY `idingreso` (`idingreso`),
  ADD KEY `idarticulo` (`idarticulo`);

--
-- Indices de la tabla `detalle_venta`
--
ALTER TABLE `detalle_venta`
  ADD PRIMARY KEY (`iddetalle_venta`),
  ADD KEY `idventa` (`idventa`),
  ADD KEY `idarticulo` (`idarticulo`);

--
-- Indices de la tabla `ingreso`
--
ALTER TABLE `ingreso`
  ADD PRIMARY KEY (`idingreso`),
  ADD KEY `idproveedor` (`idproveedor`),
  ADD KEY `idusuario` (`idusuario`);

--
-- Indices de la tabla `persona`
--
ALTER TABLE `persona`
  ADD PRIMARY KEY (`idpersona`);

--
-- Indices de la tabla `rol`
--
ALTER TABLE `rol`
  ADD PRIMARY KEY (`idrol`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`idusuario`),
  ADD KEY `idrol` (`idrol`);

--
-- Indices de la tabla `venta`
--
ALTER TABLE `venta`
  ADD PRIMARY KEY (`idventa`),
  ADD KEY `idcliente` (`idcliente`),
  ADD KEY `idusuario` (`idusuario`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `articulo`
--
ALTER TABLE `articulo`
  MODIFY `idarticulo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- AUTO_INCREMENT de la tabla `categoria`
--
ALTER TABLE `categoria`
  MODIFY `idcategoria` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `detalle_ingreso`
--
ALTER TABLE `detalle_ingreso`
  MODIFY `iddetalle_ingreso` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `detalle_venta`
--
ALTER TABLE `detalle_venta`
  MODIFY `iddetalle_venta` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ingreso`
--
ALTER TABLE `ingreso`
  MODIFY `idingreso` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `persona`
--
ALTER TABLE `persona`
  MODIFY `idpersona` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `rol`
--
ALTER TABLE `rol`
  MODIFY `idrol` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `idusuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT de la tabla `venta`
--
ALTER TABLE `venta`
  MODIFY `idventa` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `articulo`
--
ALTER TABLE `articulo`
  ADD CONSTRAINT `articulo_ibfk_1` FOREIGN KEY (`idcategoria`) REFERENCES `categoria` (`idcategoria`);

--
-- Filtros para la tabla `detalle_ingreso`
--
ALTER TABLE `detalle_ingreso`
  ADD CONSTRAINT `detalle_ingreso_ibfk_1` FOREIGN KEY (`idingreso`) REFERENCES `ingreso` (`idingreso`) ON DELETE CASCADE,
  ADD CONSTRAINT `detalle_ingreso_ibfk_2` FOREIGN KEY (`idarticulo`) REFERENCES `articulo` (`idarticulo`);

--
-- Filtros para la tabla `detalle_venta`
--
ALTER TABLE `detalle_venta`
  ADD CONSTRAINT `detalle_venta_ibfk_1` FOREIGN KEY (`idventa`) REFERENCES `venta` (`idventa`) ON DELETE CASCADE,
  ADD CONSTRAINT `detalle_venta_ibfk_2` FOREIGN KEY (`idarticulo`) REFERENCES `articulo` (`idarticulo`);

--
-- Filtros para la tabla `ingreso`
--
ALTER TABLE `ingreso`
  ADD CONSTRAINT `ingreso_ibfk_1` FOREIGN KEY (`idproveedor`) REFERENCES `persona` (`idpersona`),
  ADD CONSTRAINT `ingreso_ibfk_2` FOREIGN KEY (`idusuario`) REFERENCES `usuario` (`idusuario`);

--
-- Filtros para la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`idrol`) REFERENCES `rol` (`idrol`);

--
-- Filtros para la tabla `venta`
--
ALTER TABLE `venta`
  ADD CONSTRAINT `venta_ibfk_1` FOREIGN KEY (`idcliente`) REFERENCES `persona` (`idpersona`),
  ADD CONSTRAINT `venta_ibfk_2` FOREIGN KEY (`idusuario`) REFERENCES `usuario` (`idusuario`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
