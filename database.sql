-- =============================================================================
-- Club Deportivo - Proyecto Integrador (DSOO, IFTS 29)
-- Script completo: tablas, triggers, vista y Stored Procedures.
--
-- Compatible con MariaDB 10.2+ y MySQL 8.
--
-- Ejecutar con un cliente que entienda DELIMITER (mysql, mariadb, Workbench,
-- HeidiSQL, DBeaver). El nombre de la base se puede cambiar en las dos
-- primeras sentencias.
--
-- Decisiones de diseño:
--   * contrato  = acuerdo con condiciones congeladas (precio, descuento, cuotas)
--   * cuota     = período mensual con vencimiento propio e importe pactado
--   * pago      = cobro de una cuota (socio) o de una actividad (no socio)
--   * Una cuota pagada tarde conserva su período original
--   * La habilitación del socio se calcula (vw_socio_habilitado), no se guarda
-- =============================================================================

CREATE DATABASE IF NOT EXISTS club_deportivo
  DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE club_deportivo;

SET NAMES utf8mb4;

-- =============================================================================
-- 1. TABLAS (el orden respeta las claves foráneas)
-- =============================================================================

CREATE TABLE IF NOT EXISTS cliente (
  id_cliente   INT NOT NULL AUTO_INCREMENT,
  dni          VARCHAR(10) NOT NULL,
  nombre       VARCHAR(50) NOT NULL,
  apellido     VARCHAR(50) NOT NULL,
  telefono     VARCHAR(30) DEFAULT NULL,
  nro_carnet   INT DEFAULT NULL,               -- NULL para no socios
  apto_fisico  TINYINT(1) NOT NULL DEFAULT 0,
  es_socio     TINYINT(1) NOT NULL DEFAULT 0,
  fecha_alta   DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (id_cliente),
  UNIQUE KEY uq_cliente_dni (dni),
  UNIQUE KEY uq_cliente_carnet (nro_carnet)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE IF NOT EXISTS usuario (
  id_usuario      INT NOT NULL AUTO_INCREMENT,
  nombre_usuario  VARCHAR(30) NOT NULL,
  password_hash   VARCHAR(255) NOT NULL,
  rol             VARCHAR(20) NOT NULL DEFAULT 'recepcion',
  activo          TINYINT(1) NOT NULL DEFAULT 1,
  PRIMARY KEY (id_usuario),
  UNIQUE KEY uq_usuario_nombre (nombre_usuario)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE IF NOT EXISTS plan (                -- catálogo inmutable: se da de baja, no se edita
  id_plan         INT NOT NULL AUTO_INCREMENT,
  nombre          VARCHAR(50) NOT NULL,
  precio_mensual  DECIMAL(10,2) NOT NULL,
  fecha_creacion  DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  fecha_baja      DATETIME DEFAULT NULL,
  PRIMARY KEY (id_plan),
  CONSTRAINT chk_plan_precio CHECK (precio_mensual > 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE IF NOT EXISTS actividad (           -- cartilla para no socios
  id_actividad   INT NOT NULL AUTO_INCREMENT,
  nombre         VARCHAR(50) NOT NULL,
  precio_diario  DECIMAL(10,2) NOT NULL,
  fecha_baja     DATETIME DEFAULT NULL,
  PRIMARY KEY (id_actividad),
  CONSTRAINT chk_actividad_precio CHECK (precio_diario > 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE IF NOT EXISTS promocion (           -- catálogo inmutable
  id_promocion    INT NOT NULL AUTO_INCREMENT,
  nombre          VARCHAR(50) NOT NULL,
  n_cuotas        INT NOT NULL,                   -- 1 (sin promoción), 3 o 6
  descuento_pct   DECIMAL(5,2) NOT NULL DEFAULT 0,
  fecha_creacion  DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  fecha_baja      DATETIME DEFAULT NULL,
  PRIMARY KEY (id_promocion),
  CONSTRAINT chk_promo_cuotas CHECK (n_cuotas >= 1),
  CONSTRAINT chk_promo_desc   CHECK (descuento_pct BETWEEN 0 AND 100)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE IF NOT EXISTS contrato (            -- acuerdo con condiciones congeladas
  id_contrato            INT NOT NULL AUTO_INCREMENT,
  id_cliente             INT NOT NULL,
  id_plan                INT NOT NULL,
  id_promocion           INT NOT NULL,
  n_cuotas               INT NOT NULL,            -- copiado de la promoción
  precio_pactado         DECIMAL(10,2) NOT NULL,  -- copiado del plan
  descuento_pct_pactado  DECIMAL(5,2) NOT NULL DEFAULT 0,
  fecha_inicio           DATE NOT NULL,
  fecha_creacion         DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (id_contrato),
  KEY idx_contrato_cliente (id_cliente),
  CONSTRAINT contrato_ibfk_1 FOREIGN KEY (id_cliente)   REFERENCES cliente (id_cliente),
  CONSTRAINT contrato_ibfk_2 FOREIGN KEY (id_plan)      REFERENCES plan (id_plan),
  CONSTRAINT contrato_ibfk_3 FOREIGN KEY (id_promocion) REFERENCES promocion (id_promocion),
  CONSTRAINT chk_contrato_cuotas CHECK (n_cuotas >= 1)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE IF NOT EXISTS cuota (               -- un período mensual con vencimiento propio
  id_cuota           INT NOT NULL AUTO_INCREMENT,
  id_contrato        INT NOT NULL,
  nro_cuota          INT NOT NULL,
  fecha_desde        DATE NOT NULL,
  fecha_vencimiento  DATE NOT NULL,
  importe            DECIMAL(10,2) NOT NULL,      -- importe pactado, nunca se modifica
  PRIMARY KEY (id_cuota),
  UNIQUE KEY uq_cuota_nro (id_contrato, nro_cuota),
  KEY idx_cuota_venc (fecha_vencimiento),
  CONSTRAINT cuota_ibfk_1 FOREIGN KEY (id_contrato) REFERENCES contrato (id_contrato),
  CONSTRAINT chk_cuota_fechas CHECK (fecha_vencimiento >= fecha_desde)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE IF NOT EXISTS pago (
  id_pago       INT NOT NULL AUTO_INCREMENT,
  id_cliente    INT NOT NULL,
  id_cuota      INT DEFAULT NULL,                 -- socio: cuota que se salda
  id_actividad  INT DEFAULT NULL,                 -- no socio: actividad del día
  id_usuario    INT NOT NULL,                     -- quién registró el cobro
  medio_pago    ENUM('EFECTIVO','TARJETA') NOT NULL,
  fecha_pago    DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  importe       DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (id_pago),
  UNIQUE KEY uq_pago_cuota (id_cuota),            -- una cuota se paga una sola vez
  CONSTRAINT pago_ibfk_1 FOREIGN KEY (id_cliente)   REFERENCES cliente (id_cliente),
  CONSTRAINT pago_ibfk_2 FOREIGN KEY (id_cuota)     REFERENCES cuota (id_cuota),
  CONSTRAINT pago_ibfk_3 FOREIGN KEY (id_actividad) REFERENCES actividad (id_actividad),
  CONSTRAINT pago_ibfk_4 FOREIGN KEY (id_usuario)   REFERENCES usuario (id_usuario),
  CONSTRAINT chk_pago_destino CHECK ((id_cuota IS NULL) <> (id_actividad IS NULL))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Promoción por defecto para contratos de una sola cuota
INSERT INTO promocion (nombre, n_cuotas, descuento_pct)
SELECT 'Sin promoción', 1, 0 FROM DUAL
WHERE NOT EXISTS (SELECT 1 FROM promocion WHERE nombre = 'Sin promoción');

-- =============================================================================
-- 2. TRIGGERS: protegen lo pactado (no se modifican precios, cuotas ni períodos)
-- =============================================================================

DELIMITER $$

DROP TRIGGER IF EXISTS trg_plan_inmutable$$
CREATE TRIGGER trg_plan_inmutable BEFORE UPDATE ON plan FOR EACH ROW
BEGIN
  IF NEW.precio_mensual <> OLD.precio_mensual THEN
    SIGNAL SQLSTATE '45000'
      SET MESSAGE_TEXT = 'El precio de un plan no se modifica: dar de baja y crear uno nuevo';
  END IF;
END$$

DROP TRIGGER IF EXISTS trg_promocion_inmutable$$
CREATE TRIGGER trg_promocion_inmutable BEFORE UPDATE ON promocion FOR EACH ROW
BEGIN
  IF NEW.n_cuotas <> OLD.n_cuotas OR NEW.descuento_pct <> OLD.descuento_pct THEN
    SIGNAL SQLSTATE '45000'
      SET MESSAGE_TEXT = 'Una promoción no se modifica: dar de baja y crear una nueva';
  END IF;
END$$

DROP TRIGGER IF EXISTS trg_contrato_inmutable$$
CREATE TRIGGER trg_contrato_inmutable BEFORE UPDATE ON contrato FOR EACH ROW
BEGIN
  IF NEW.precio_pactado <> OLD.precio_pactado
     OR NEW.descuento_pct_pactado <> OLD.descuento_pct_pactado
     OR NEW.n_cuotas <> OLD.n_cuotas
     OR NEW.id_plan <> OLD.id_plan
     OR NEW.id_promocion <> OLD.id_promocion THEN
    SIGNAL SQLSTATE '45000'
      SET MESSAGE_TEXT = 'Las condiciones pactadas de un contrato no se modifican';
  END IF;
END$$

-- Una cuota pagada tarde conserva su período original
DROP TRIGGER IF EXISTS trg_cuota_inmutable$$
CREATE TRIGGER trg_cuota_inmutable BEFORE UPDATE ON cuota FOR EACH ROW
BEGIN
  IF NEW.importe <> OLD.importe OR NEW.fecha_desde <> OLD.fecha_desde OR NEW.fecha_vencimiento <> OLD.fecha_vencimiento THEN
    SIGNAL SQLSTATE '45000'
      SET MESSAGE_TEXT = 'El importe y el período de una cuota no se modifican';
  END IF;
END$$

DELIMITER ;

-- =============================================================================
-- 3. VISTA DE HABILITACIÓN
-- Un socio figura solo si tiene una cuota PAGADA cuyo período cubre hoy.
-- =============================================================================

CREATE OR REPLACE VIEW vw_socio_habilitado AS
SELECT c.id_cliente, MAX(cu.fecha_vencimiento) AS habilitado_hasta
FROM cuota cu
JOIN pago pg     ON pg.id_cuota = cu.id_cuota
JOIN contrato c  ON c.id_contrato = cu.id_contrato
WHERE CURDATE() BETWEEN cu.fecha_desde AND cu.fecha_vencimiento
GROUP BY c.id_cliente;

-- =============================================================================
-- 4. STORED PROCEDURES
-- =============================================================================

DELIMITER $$

-- -----------------------------------------------------------------------------
-- sp_contratar_plan
-- Congela las condiciones, genera las cuotas y asigna el carnet en el primer
-- contrato, todo en una transacción. Si dos altas simultáneas generan el mismo
-- número de carnet, la clave única hace fallar a una y se reintenta.
-- -----------------------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_contratar_plan$$
CREATE PROCEDURE sp_contratar_plan(
  IN p_id_cliente   INT,
  IN p_id_plan      INT,
  IN p_id_promocion INT,
  IN p_fecha_inicio DATE            -- NULL = hoy
)
BEGIN
  DECLARE v_precio      DECIMAL(10,2);
  DECLARE v_n_cuotas    INT;
  DECLARE v_desc        DECIMAL(5,2);
  DECLARE v_importe     DECIMAL(10,2);
  DECLARE v_carnet      INT;
  DECLARE v_inicio      DATE;
  DECLARE v_id_contrato INT;
  DECLARE v_i           INT DEFAULT 1;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    RESIGNAL;
  END;

  SET v_inicio = COALESCE(p_fecha_inicio, CURDATE());

  IF NOT EXISTS (SELECT 1 FROM cliente WHERE id_cliente = p_id_cliente) THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El cliente no existe';
  END IF;

  SELECT precio_mensual INTO v_precio
  FROM plan WHERE id_plan = p_id_plan AND fecha_baja IS NULL;
  IF v_precio IS NULL THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Plan inexistente o dado de baja';
  END IF;

  SELECT n_cuotas, descuento_pct INTO v_n_cuotas, v_desc
  FROM promocion WHERE id_promocion = p_id_promocion AND fecha_baja IS NULL;
  IF v_n_cuotas IS NULL THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Promoción inexistente o dada de baja';
  END IF;

  -- No se superponen contratos: la nueva cobertura empieza después de la última cuota existente
  IF EXISTS (SELECT 1
             FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato
             WHERE c.id_cliente = p_id_cliente AND cu.fecha_vencimiento >= v_inicio) THEN
    SIGNAL SQLSTATE '45000'
      SET MESSAGE_TEXT = 'El cliente ya tiene cuotas que cubren esa fecha';
  END IF;

  SET v_importe = ROUND(v_precio * (1 - v_desc / 100), 2);

  START TRANSACTION;

  SELECT nro_carnet INTO v_carnet FROM cliente WHERE id_cliente = p_id_cliente;
  IF v_carnet IS NULL THEN
    SELECT COALESCE(MAX(nro_carnet), 0) + 1 INTO v_carnet FROM cliente;
  END IF;

  UPDATE cliente
     SET es_socio = 1, nro_carnet = v_carnet
   WHERE id_cliente = p_id_cliente;

  INSERT INTO contrato (id_cliente, id_plan, id_promocion, n_cuotas,
                        precio_pactado, descuento_pct_pactado, fecha_inicio)
  VALUES (p_id_cliente, p_id_plan, p_id_promocion, v_n_cuotas,
          v_precio, v_desc, v_inicio);
  SET v_id_contrato = LAST_INSERT_ID();

  WHILE v_i <= v_n_cuotas DO
    INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe)
    VALUES (v_id_contrato, v_i,
            DATE_ADD(v_inicio, INTERVAL (v_i - 1) MONTH),
            DATE_SUB(DATE_ADD(v_inicio, INTERVAL v_i MONTH), INTERVAL 1 DAY),
            v_importe);
    SET v_i = v_i + 1;
  END WHILE;

  COMMIT;

  SELECT v_id_contrato AS id_contrato, v_carnet AS nro_carnet,
         v_n_cuotas AS cuotas, v_importe AS importe_cuota;
END$$

-- -----------------------------------------------------------------------------
-- sp_listado_vencimientos_diario
-- Socios cuya cobertura termina en la fecha indicada (por omisión, hoy) y que
-- todavía no pagaron una cuota posterior.
-- -----------------------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_listado_vencimientos_diario$$
CREATE PROCEDURE sp_listado_vencimientos_diario(IN p_fecha DATE)   -- NULL = hoy
BEGIN
  DECLARE v_fecha DATE;
  SET v_fecha = COALESCE(p_fecha, CURDATE());

  SELECT cl.nro_carnet,
         cl.apellido,
         cl.nombre,
         cl.telefono,
         p.nombre                    AS plan,
         cu.nro_cuota,
         c.n_cuotas,
         cu.fecha_vencimiento,
         sig.id_cuota IS NOT NULL    AS tiene_cuota_siguiente,
         sig.importe                 AS importe_cuota_siguiente
  FROM cuota cu
  JOIN pago pg      ON pg.id_cuota    = cu.id_cuota          -- solo cuotas efectivamente pagadas
  JOIN contrato c   ON c.id_contrato  = cu.id_contrato
  JOIN cliente cl   ON cl.id_cliente  = c.id_cliente
  JOIN plan p       ON p.id_plan      = c.id_plan
  LEFT JOIN cuota sig ON sig.id_contrato = c.id_contrato
                     AND sig.nro_cuota   = cu.nro_cuota + 1
  WHERE cu.fecha_vencimiento = v_fecha
    AND NOT EXISTS (                                          -- excluye a quien ya pagó por adelantado
          SELECT 1
          FROM cuota cu2
          JOIN pago pg2     ON pg2.id_cuota   = cu2.id_cuota
          JOIN contrato c2  ON c2.id_contrato = cu2.id_contrato
          WHERE c2.id_cliente = c.id_cliente
            AND cu2.fecha_vencimiento > v_fecha)
  ORDER BY cl.apellido, cl.nombre;
END$$

-- -----------------------------------------------------------------------------
-- sp_registrar_pago_cuota
-- Registra el cobro de una cuota aplicando S5: guarda la fecha real de pago sin
-- tocar el período. El importe sale siempre de la cuota pactada. Con promoción
-- de más de una cuota exige tarjeta. Si la cuota ya venció, registra el pago
-- pero avisa que no habilita al socio.
-- -----------------------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_registrar_pago_cuota$$
CREATE PROCEDURE sp_registrar_pago_cuota(
  IN p_id_cuota   INT,
  IN p_id_usuario INT,              -- quién cobra
  IN p_medio_pago VARCHAR(10)       -- EFECTIVO o TARJETA
)
BEGIN
  DECLARE v_importe     DECIMAL(10,2);
  DECLARE v_desde       DATE;
  DECLARE v_venc        DATE;
  DECLARE v_id_cliente  INT;
  DECLARE v_n_cuotas    INT;
  DECLARE v_medio       VARCHAR(10);
  DECLARE v_hoy         DATE;
  DECLARE v_id_pago     INT;
  DECLARE v_aviso       VARCHAR(200);

  -- Doble cobro simultáneo: lo frena la clave única uq_pago_cuota
  DECLARE EXIT HANDLER FOR 1062
  BEGIN
    ROLLBACK;
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La cuota ya fue pagada';
  END;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    RESIGNAL;
  END;

  SET v_medio = UPPER(TRIM(p_medio_pago));
  SET v_hoy   = CURDATE();

  IF v_medio NOT IN ('EFECTIVO', 'TARJETA') THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Medio de pago inválido: use EFECTIVO o TARJETA';
  END IF;

  IF NOT EXISTS (SELECT 1 FROM usuario WHERE id_usuario = p_id_usuario AND activo = 1) THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Usuario inexistente o inactivo';
  END IF;

  SELECT cu.importe, cu.fecha_desde, cu.fecha_vencimiento, c.id_cliente, c.n_cuotas
    INTO v_importe, v_desde, v_venc, v_id_cliente, v_n_cuotas
  FROM cuota cu
  JOIN contrato c ON c.id_contrato = cu.id_contrato
  WHERE cu.id_cuota = p_id_cuota;

  IF v_importe IS NULL THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La cuota no existe';
  END IF;

  IF EXISTS (SELECT 1 FROM pago WHERE id_cuota = p_id_cuota) THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La cuota ya fue pagada';
  END IF;

  IF v_n_cuotas > 1 AND v_medio <> 'TARJETA' THEN
    SIGNAL SQLSTATE '45000'
      SET MESSAGE_TEXT = 'Los contratos con promoción de cuotas se abonan con tarjeta';
  END IF;

  START TRANSACTION;

  INSERT INTO pago (id_cliente, id_cuota, id_usuario, medio_pago, importe)
  VALUES (v_id_cliente, p_id_cuota, p_id_usuario, v_medio, v_importe);
  SET v_id_pago = LAST_INSERT_ID();

  COMMIT;

  -- S5: la cuota conserva su período; el aviso informa si el pago habilita hoy
  IF v_hoy > v_venc THEN
    SET v_aviso = 'Cuota vencida: el pago se registró pero no habilita al socio. Debe pagar la cuota vigente o contratar de nuevo.';
  ELSEIF v_hoy < v_desde THEN
    SET v_aviso = CONCAT('Cuota adelantada: habilita desde el ', DATE_FORMAT(v_desde, '%d/%m/%Y'), '.');
  ELSE
    SET v_aviso = CONCAT('Cuota vigente: socio habilitado hasta el ', DATE_FORMAT(v_venc, '%d/%m/%Y'), '.');
  END IF;

  SELECT v_id_pago                       AS id_pago,
         p_id_cuota                      AS id_cuota,
         v_importe                       AS importe,
         v_medio                         AS medio_pago,
         NOW()                           AS fecha_pago,
         v_desde                         AS periodo_desde,
         v_venc                          AS periodo_hasta,
         (v_hoy BETWEEN v_desde AND v_venc) AS habilita_hoy,
         v_aviso                         AS aviso;
END$$

-- -----------------------------------------------------------------------------
-- sp_registrar_pago_actividad
-- Cobra la actividad del día a un cliente sin cuota vigente, según la cartilla.
-- Un socio con cuota pagada que cubre hoy no abona por día.
-- La falta de apto físico advierte pero no bloquea el cobro.
-- -----------------------------------------------------------------------------
DROP PROCEDURE IF EXISTS sp_registrar_pago_actividad$$
CREATE PROCEDURE sp_registrar_pago_actividad(
  IN p_id_cliente   INT,
  IN p_id_actividad INT,
  IN p_id_usuario   INT,            -- quién cobra
  IN p_medio_pago   VARCHAR(10)     -- EFECTIVO o TARJETA
)
BEGIN
  DECLARE v_medio     VARCHAR(10);
  DECLARE v_importe   DECIMAL(10,2);
  DECLARE v_actividad VARCHAR(50);
  DECLARE v_nombre    VARCHAR(50);
  DECLARE v_apellido  VARCHAR(50);
  DECLARE v_dni       VARCHAR(10);
  DECLARE v_apto      TINYINT(1);
  DECLARE v_id_pago   INT;
  DECLARE v_aviso     VARCHAR(200);

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    RESIGNAL;
  END;

  SET v_medio = UPPER(TRIM(p_medio_pago));

  IF v_medio NOT IN ('EFECTIVO', 'TARJETA') THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Medio de pago inválido: use EFECTIVO o TARJETA';
  END IF;

  IF NOT EXISTS (SELECT 1 FROM usuario WHERE id_usuario = p_id_usuario AND activo = 1) THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Usuario inexistente o inactivo';
  END IF;

  SELECT nombre, apellido, dni, apto_fisico
    INTO v_nombre, v_apellido, v_dni, v_apto
  FROM cliente WHERE id_cliente = p_id_cliente;
  IF v_dni IS NULL THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El cliente no existe';
  END IF;

  SELECT nombre, precio_diario INTO v_actividad, v_importe
  FROM actividad WHERE id_actividad = p_id_actividad AND fecha_baja IS NULL;
  IF v_importe IS NULL THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Actividad inexistente o dada de baja';
  END IF;

  -- S6: el socio con cuota vigente no paga por día
  IF EXISTS (SELECT 1 FROM vw_socio_habilitado WHERE id_cliente = p_id_cliente) THEN
    SIGNAL SQLSTATE '45000'
      SET MESSAGE_TEXT = 'El cliente es socio habilitado: no abona la actividad por día';
  END IF;

  START TRANSACTION;

  INSERT INTO pago (id_cliente, id_actividad, id_usuario, medio_pago, importe)
  VALUES (p_id_cliente, p_id_actividad, p_id_usuario, v_medio, v_importe);
  SET v_id_pago = LAST_INSERT_ID();

  COMMIT;

  -- S7: el apto físico advierte pero no bloquea
  IF v_apto = 0 THEN
    SET v_aviso = 'Pago registrado. El cliente no tiene apto físico cargado.';
  ELSE
    SET v_aviso = 'Pago registrado.';
  END IF;

  SELECT v_id_pago    AS id_pago,
         v_dni        AS dni,
         v_apellido   AS apellido,
         v_nombre     AS nombre,
         v_actividad  AS actividad,
         v_importe    AS importe,
         v_medio      AS medio_pago,
         NOW()        AS fecha_pago,
         v_aviso      AS aviso;
END$$

DELIMITER ;

-- =============================================================================
-- 5. JUEGO DE PRUEBA (comentado: quitar los comentarios en una base vacía)
-- Las fechas del contrato son de ejemplo; las consultas de vencimiento usan
-- fechas explícitas, así que el resultado no depende del día de ejecución,
-- salvo vw_socio_habilitado y los avisos de pago, que usan CURDATE().
-- =============================================================================
/*
INSERT INTO usuario (nombre_usuario, password_hash, rol) VALUES ('recepcion1', 'hash_de_ejemplo', 'recepcion');
INSERT INTO plan (nombre, precio_mensual) VALUES ('Musculación', 20000);
INSERT INTO promocion (nombre, n_cuotas, descuento_pct) VALUES ('3 cuotas con tarjeta', 3, 10);
INSERT INTO actividad (nombre, precio_diario) VALUES ('Musculación', 3000);
INSERT INTO cliente (dni, nombre, apellido, telefono, apto_fisico) VALUES ('30111222', 'Ana', 'Pérez', '381-5550001', 1);
INSERT INTO cliente (dni, nombre, apellido, telefono) VALUES ('30333444', 'Luis', 'Gómez', '381-5550002');

-- Contratar el plan con la promoción de 3 cuotas (id 2): 3 cuotas de 18000
CALL sp_contratar_plan(1, 1, 2, '2026-11-10');
-- Repetir: error, ya tiene cuotas que cubren esa fecha
-- CALL sp_contratar_plan(1, 1, 2, '2026-11-10');

SELECT * FROM cuota;                                   -- 10/11-09/12, 10/12-09/01, 10/01-09/02

-- Pagos de cuotas
-- CALL sp_registrar_pago_cuota(1, 1, 'EFECTIVO');     -- error: exige tarjeta
CALL sp_registrar_pago_cuota(1, 1, 'TARJETA');
-- CALL sp_registrar_pago_cuota(1, 1, 'TARJETA');      -- error: la cuota ya fue pagada

-- Listado de vencimientos
CALL sp_listado_vencimientos_diario('2026-12-08');     -- vacío
CALL sp_listado_vencimientos_diario('2026-12-09');     -- aparece Ana, con cuota siguiente de 18000

-- Pagar por adelantado la cuota 2: ya no figura en el listado del 09/12
CALL sp_registrar_pago_cuota(2, 1, 'TARJETA');
CALL sp_listado_vencimientos_diario('2026-12-09');     -- vacío

-- Pago de actividad de un no socio
CALL sp_registrar_pago_actividad(2, 1, 1, 'EFECTIVO'); -- 3000, aviso de apto físico faltante

-- Triggers: ambos deben fallar
-- UPDATE plan SET precio_mensual = 25000 WHERE id_plan = 1;
-- UPDATE cuota SET importe = 1 WHERE id_cuota = 1;
*/