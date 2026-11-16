-- =============================================================================
-- Club Deportivo - Datos de prueba (casos normales y casos borde)
--
-- Uso: ejecutar DESPUÉS de database.sql (mismo cliente, misma base).
--
--   * Las fechas son RELATIVAS a CURDATE() (variable @hoy): el juego conserva
--     su significado sin importar el día de ejecución (habilitaciones,
--     vencimientos de hoy / ayer / mañana, períodos que cubren hoy).
--   * El script REINICIA los datos: vacía las tablas y vuelve a sembrarlas con
--     identificadores determinísticos. No ejecutar sobre datos que se quieran
--     conservar.
--   * Secciones 1-7: carga de fixtures por INSERT (se ejecutan sin errores).
--   * Sección 8: llamadas reales a los Stored Procedures (también sin errores).
--   * Sección 9: casos que DEBEN FALLAR, comentados; descomentar de a uno.
--   * Sección 10: consultas de verificación con el resultado esperado.
--   * Contraseñas de prueba (hash SHA-256 en hexadecimal minúscula) indicadas
--     en el comentario de cada usuario.
-- =============================================================================

USE club_deportivo;
SET NAMES utf8mb4;
SET @hoy = CONVERT(CURDATE() USING utf8mb4);

-- =============================================================================
-- 0. REINICIO
-- =============================================================================
SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE pago;
TRUNCATE TABLE cuota;
TRUNCATE TABLE contrato;
TRUNCATE TABLE cliente;
TRUNCATE TABLE usuario;
TRUNCATE TABLE plan;
TRUNCATE TABLE actividad;
TRUNCATE TABLE promocion;
SET FOREIGN_KEY_CHECKS = 1;

-- =============================================================================
-- 1. USUARIOS
-- =============================================================================

-- User 'admin', Pass 'admin'. El sistema debe permitir cambiarlo o setearlo con valores personalizados al crear la base de datos. El hash corresponde a la contraseña 'admin' con SHA256.
-- Asegura que el usuario administrador exista aunque este script se ejecute luego de database.sql.
INSERT INTO usuario(id_usuario, nombre_usuario, password_hash, rol, activo)
SELECT 3, 'admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'admin', 1
FROM DUAL
WHERE NOT EXISTS (SELECT 1 FROM usuario WHERE nombre_usuario = 'admin');

INSERT INTO usuario (id_usuario, nombre_usuario, password_hash, rol, activo) VALUES
  -- Recepción activa; clave Recep1-2026.
  (1, 'recepcion1', '7bfa9a35e908c4a4ca6d264d9393954c72a791e1273ad7588f0141a0e7ae6afb', 'recepcion', 1),
  -- Segundo usuario de recepción activo; clave Recep2-2026.
  (2, 'recepcion2', '3935c99d636acd05af0da5ca86041e904376df7f78823f3abc4ec3d79778c284', 'recepcion', 1),
  -- Usuario INACTIVO: login y cobros por SP deben rechazarse; conserva pagos históricos.
  (4, 'exempleado', '0a2930722abc3ac58e53f2593d6026c6c5ae5c9e8924fe1d8805a8ca42ffefee', 'recepcion', 0),
  -- Nombre de usuario de 30 caracteres (largo máximo); clave Noche-2026.
  (5, 'recepcion_turno_noche_sabado_1', '590753e5109d753938d26b7d3c6c75136b485fb0b1caf6b0c533ef610595f9ac', 'recepcion', 1);

-- =============================================================================
-- 2. CATÁLOGOS (planes, promociones, actividades)
-- =============================================================================
INSERT INTO plan (id_plan, nombre, precio_mensual, fecha_creacion, fecha_baja) VALUES
  -- Plan estándar activo.
  (1, 'Básico', 15000.00, '2023-01-02 08:00:00', NULL),
  -- Plan estándar activo de precio medio.
  (2, 'Pleno', 25000.00, '2023-01-02 08:00:00', NULL),
  -- Precio con centavos distintos de cero.
  (3, 'Premium', 40000.50, '2023-06-01 08:00:00', NULL),
  -- Plan DADO DE BAJA: no se puede contratar, sí consultar contratos antiguos.
  (4, 'Clásico 2022', 8000.00, '2022-03-01 08:00:00', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 150 DAY), '08:00:00')),
  -- Precio mínimo permitido (> 0).
  (5, 'Simbólico', 0.01, '2025-01-01 08:00:00', NULL),
  -- Precio máximo de DECIMAL(10,2).
  (6, 'Elite', 99999999.99, '2025-01-01 08:00:00', NULL);

INSERT INTO promocion (id_promocion, nombre, n_cuotas, descuento_pct, fecha_creacion, fecha_baja) VALUES
  -- Promoción por defecto: 1 cuota, sin descuento, permite efectivo.
  (1, 'Sin promoción', 1, 0.00, '2023-01-02 08:00:00', NULL),
  -- 3 cuotas con tarjeta, 10% de descuento.
  (2, 'Trimestral 10%', 3, 10.00, '2023-01-02 08:00:00', NULL),
  -- 6 cuotas con tarjeta, 20% de descuento.
  (3, 'Semestral 20%', 6, 20.00, '2023-01-02 08:00:00', NULL),
  -- Descuento decimal: el importe puede requerir redondeo.
  (4, 'Trimestral 7,5%', 3, 7.50, '2025-01-01 08:00:00', NULL),
  -- Descuento máximo permitido: cuota de importe 0.00.
  (5, 'Beca total 100%', 1, 100.00, '2025-01-01 08:00:00', NULL),
  -- Promoción DADA DE BAJA: no contratable.
  (6, 'Semestral 15% (2025)', 6, 15.00, '2025-01-01 08:00:00', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 150 DAY), '08:00:00')),
  -- Más de una cuota con descuento 0: igual exige tarjeta.
  (7, 'Trimestral sin descuento', 3, 0.00, '2025-01-01 08:00:00', NULL);

INSERT INTO actividad (id_actividad, nombre, precio_diario, fecha_baja) VALUES
  -- Actividad activa.
  (1, 'Natación', 3500.00, NULL),
  -- Actividad activa de menor precio.
  (2, 'Musculación', 2500.00, NULL),
  -- Actividad activa.
  (3, 'Yoga', 3000.00, NULL),
  -- Precio mínimo permitido (> 0).
  (4, 'Pase simbólico', 0.01, NULL),
  -- Actividad DADA DE BAJA: no se puede cobrar; conserva pagos históricos.
  (5, 'Spinning', 2800.00, TIMESTAMP(DATE_SUB(@hoy, INTERVAL 120 DAY), '08:00:00'));

-- =============================================================================
-- 3. CLIENTES
-- Los socios llevan carnet correlativo desde 1001; es_socio = 1 solo si tienen contrato.
-- Los clientes 50, 51, 52 y 19 (renovación) se completan en la sección 8 vía SP.
-- =============================================================================
INSERT INTO cliente (id_cliente, dni, nombre, apellido, telefono, nro_carnet, apto_fisico, es_socio, fecha_alta) VALUES
  -- Socia habilitada, pagó una actividad suelta antes de asociarse.
  (1, '30111222', 'Lucía', 'Gómez', '381-4111222', 1001, 1, 1, TIMESTAMP(DATE_SUB(@hoy, INTERVAL 60 DAY), '09:00:00')),
  -- Socio trimestral habilitado, mismo apellido que el cliente 38 (homónimo parcial).
  (2, '31222333', 'Martín', 'Pérez', '381-4222333', 1002, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Socia semestral en la cuota 4 de 6, habilitada.
  (3, '28333444', 'Ana', 'Rodríguez', '+54 381 4333444', 1003, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Habilitado hoy; cuota 2 adelantada excluye del listado.
  (4, '27444555', 'Diego', 'Fernández', '381-4444555', 1004, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Vence hoy sin cuota siguiente; empata en apellido con el cliente 7.
  (5, '33555666', 'Valeria', 'Castro', '381-4555666', 1005, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Vence hoy con cuota siguiente; apellido con tilde para el orden.
  (6, '29666777', 'Hernán', 'Álvarez', '381-4666777', 1006, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Vence hoy en la última cuota; teléfono NULL; empate de apellido con el 5.
  (7, '34777888', 'Sofía', 'Castro', NULL, 1007, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Venció ayer: no habilitado.
  (8, '35888999', 'Joaquín', 'Ramírez', '381-4888999', 1008, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Período inicia hoy: habilitada.
  (9, '36999000', 'Camila', 'Torres', '381-4999000', 1009, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 DAY), INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Cuota pagada pero inicia mañana: no habilitado hoy.
  (10, '37000111', 'Nicolás', 'Silva', '381-4000111', 1010, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(@hoy, INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Moroso: cuota vencida impaga; paga actividades por día.
  (11, '38111000', 'Florencia', 'Acosta', '381-4111000', 1011, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 20 DAY), INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Pagó tarde: cuota vencida pagada no habilita.
  (12, '39222111', 'Gabriel', 'Medina', '381-4222111', 1012, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 20 DAY), INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Único pago de la cuota anulado: no habilitada.
  (13, '40333222', 'Paula', 'Herrera', '381-4333222', 1013, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_SUB(@hoy, INTERVAL 5 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Vence hoy pero con pago anulado: fuera del listado.
  (14, '41444333', 'Ricardo', 'Vega', '381-4444333', 1014, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Vence hoy; pago de cuota 2 anulado; apellido con Ñ y tildes.
  (15, '42555444', 'Mariana', 'Ñúñez', '381-4555444', 1015, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Dos contratos contiguos: el segundo pagado lo excluye del listado.
  (16, '43666555', 'Esteban', 'Luna', '381-4666555', 1016, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Cuota con dos pagos anulados y uno vigente.
  (17, '44777666', 'Carolina', 'Díaz', '381-4777666', 1017, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_SUB(@hoy, INTERVAL 5 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Semestre completo terminado ayer; ex-socio.
  (18, '26888777', 'Tomás', 'Ortiz', '381-4888777', 1018, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 6 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Ex-socia vencida hace 40 días; se renueva por SP conservando carnet.
  (19, '25999888', 'Julieta', 'Sosa', '381-4999888', 1019, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Dos contratos sucesivos, un solo carnet.
  (20, '24000999', 'Federico', 'Paz', '381-4000999', 1020, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Contrato histórico con plan y promoción dados de baja.
  (21, '23111999', 'Lorena', 'Giménez', '381-4111999', 1021, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 6 MONTH), INTERVAL 200 DAY), INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Beca 100%: cuota de importe cero.
  (22, '45222333', 'Matías', 'Romero', '381-4222333', 1022, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Cuotas de 0.01 por redondeo.
  (23, '46333444', 'Brisa', 'Maldonado', '381-4333444', 1023, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Importe máximo de DECIMAL(10,2).
  (24, '47444555', 'Leandro', 'Cabrera', '381-4444555', 1024, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Contrato con inicio de fin de mes en año bisiesto.
  (25, '22555666', 'Elena', 'Figueroa', '381-4555666', 1025, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE '2024-01-31', INTERVAL 2 DAY)), '09:00:00')),
  -- Contrato con inicio el 31 de agosto.
  (26, '21666777', 'Raúl', 'Navarro', '381-4666777', 1026, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE '2025-08-31', INTERVAL 2 DAY)), '09:00:00')),
  -- Socio habilitado sin apto físico.
  (28, '48777888', 'Alejandro', 'Cabral', '381-4777888', 1027, 0, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- Contratada hoy; cuotas sin pagar.
  (29, '49888999', 'Brenda', 'Navarrete', '381-4888999', 1028, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(@hoy, INTERVAL 2 DAY)), '09:00:00')),
  -- No socio con apto; varias actividades y medios de pago.
  (30, '50999000', 'Ignacio', 'Fuentes', '381-4999111', NULL, 1, 0, TIMESTAMP(DATE_SUB(@hoy, INTERVAL 320 DAY), '09:00:00')),
  -- No socia sin apto: el pago por día se registra igual.
  (31, '51000111', 'Daniela', 'Pereyra', '381-4000222', NULL, 0, 0, TIMESTAMP(DATE_SUB(@hoy, INTERVAL 10 DAY), '09:00:00')),
  -- Cliente recién registrado hoy, sin pagos ni teléfono.
  (32, '52111222', 'Sebastián', 'Ibáñez', NULL, NULL, 0, 0, NOW()),
  -- Nombre con Ú y apellido con Ñ; paga la actividad de $0,01.
  (33, '53222333', 'Úrsula', 'Ñancufil', '381-4222444', NULL, 1, 0, TIMESTAMP(DATE_SUB(@hoy, INTERVAL 5 DAY), '09:00:00')),
  -- Nombre y apellido de 50 caracteres, apóstrofe y teléfono de 30.
  (34, '54333444', 'María de los Ángeles Guadalupe del Carmen Soledadx', 'O''Connor de la Vega y Fernández-Villanueva Pérezzz', '+54 (0381) 15-412-3456 int. 99', NULL, 1, 0, TIMESTAMP(DATE_SUB(@hoy, INTERVAL 30 DAY), '09:00:00')),
  -- DNI de 7 dígitos.
  (35, '8123456', 'Ramón', 'Aráoz', '381-4333555', NULL, 1, 0, TIMESTAMP(DATE_SUB(@hoy, INTERVAL 90 DAY), '09:00:00')),
  -- DNI con ceros a la izquierda (texto).
  (36, '00123456', 'Teresa', 'Lobo', '381-4444666', NULL, 0, 0, TIMESTAMP(DATE_SUB(@hoy, INTERVAL 90 DAY), '09:00:00')),
  -- DNI alfanumérico de 10 caracteres (largo máximo), extranjero.
  (37, 'AB12345678', 'Pierre', 'Dubois', '+33 1 23 45 67 89', NULL, 1, 0, TIMESTAMP(DATE_SUB(@hoy, INTERVAL 90 DAY), '09:00:00')),
  -- Homónimo de 39 con DNI distinto.
  (38, '20000001', 'Juan', 'Pérez', '381-4555777', NULL, 1, 0, TIMESTAMP(DATE_SUB(@hoy, INTERVAL 15 DAY), '09:00:00')),
  -- Homónimo de 38 con DNI distinto.
  (39, '20000002', 'Juan', 'Pérez', '381-4666888', NULL, 0, 0, TIMESTAMP(DATE_SUB(@hoy, INTERVAL 15 DAY), '09:00:00')),
  -- Su cuota vence mañana: figura en el listado de mañana.
  (40, '55444555', 'Martina', 'Quiroga', '381-4777999', 1029, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00')),
  -- SP: contrata, paga, se anula el pago y se vuelve a pagar.
  (50, '56555666', 'Bruno', 'Aguirre', '381-4888000', NULL, 1, 0, TIMESTAMP(DATE_SUB(@hoy, INTERVAL 3 DAY), '09:00:00')),
  -- SP: contrata trimestral y paga cuota vigente y adelantada.
  (51, '57666777', 'Natalia', 'Campos', '381-4999222', NULL, 1, 0, TIMESTAMP(DATE_SUB(@hoy, INTERVAL 3 DAY), '09:00:00')),
  -- SP: pago de actividad sin apto físico (advertencia).
  (52, '58777888', 'Gonzalo', 'Vidal', '381-4000333', NULL, 0, 0, TIMESTAMP(DATE_SUB(@hoy, INTERVAL 3 DAY), '09:00:00')),
  -- SP: paga cuota vencida (aviso de no habilita).
  (54, '59888999', 'Rosario', 'Peralta', '381-4111444', 1030, 1, 1, TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 20 DAY), INTERVAL 1 DAY), INTERVAL 2 DAY)), '09:00:00'));

-- =============================================================================
-- 4. CONTRATOS Y CUOTAS (condiciones congeladas; importe = ROUND(precio * (1 - dto/100), 2))
-- =============================================================================

-- Contrato 1 (cliente 1, plan 1, promoción 1, 1 cuota de 15000.00): Plan Básico sin promoción, 1 cuota, efectivo; pagada y vigente (período inició hace 10 días).
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (1, 1, 1, 1, 1, 15000.00, 0.00, DATE_SUB(@hoy, INTERVAL 10 DAY), TIMESTAMP(LEAST(@hoy, DATE_SUB(@hoy, INTERVAL 10 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (1, 1, DATE_SUB(@hoy, INTERVAL 10 DAY), DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 1 MONTH), INTERVAL 1 DAY), ROUND(15000.00 * (1 - 0.00 / 100), 2));

-- Contrato 2 (cliente 2, plan 2, promoción 2, 3 cuotas de 22500.00): Trimestral 10%: cuota 1 vigente y pagada; cuotas 2 y 3 futuras impagas.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (2, 2, 2, 2, 3, 25000.00, 10.00, DATE_SUB(@hoy, INTERVAL 10 DAY), TIMESTAMP(LEAST(@hoy, DATE_SUB(@hoy, INTERVAL 10 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (2, 1, DATE_SUB(@hoy, INTERVAL 10 DAY), DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 1 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 10.00 / 100), 2)),
  (2, 2, DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 1 MONTH), DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 2 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 10.00 / 100), 2)),
  (2, 3, DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 2 MONTH), DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 3 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 10.00 / 100), 2));

-- Contrato 3 (cliente 3, plan 2, promoción 3, 6 cuotas de 20000.00): Semestral 20% en curso: cuotas 1-4 pagadas (la 4 cubre hoy), 5 y 6 futuras impagas.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (3, 3, 2, 3, 6, 25000.00, 20.00, DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), TIMESTAMP(LEAST(@hoy, DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (3, 1, DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), DATE_SUB(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), INTERVAL 1 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 20.00 / 100), 2)),
  (3, 2, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), INTERVAL 1 MONTH), DATE_SUB(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), INTERVAL 2 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 20.00 / 100), 2)),
  (3, 3, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), INTERVAL 2 MONTH), DATE_SUB(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), INTERVAL 3 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 20.00 / 100), 2)),
  (3, 4, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), INTERVAL 3 MONTH), DATE_SUB(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), INTERVAL 4 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 20.00 / 100), 2)),
  (3, 5, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), INTERVAL 4 MONTH), DATE_SUB(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), INTERVAL 5 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 20.00 / 100), 2)),
  (3, 6, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), INTERVAL 5 MONTH), DATE_SUB(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), INTERVAL 6 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 20.00 / 100), 2));

-- Contrato 4 (cliente 4, plan 1, promoción 4, 3 cuotas de 13875.00): Trimestral 7,5%: cuota 1 vence hoy y la 2 ya está pagada por adelantado (se excluye del listado de hoy).
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (4, 4, 1, 4, 3, 15000.00, 7.50, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (4, 1, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), @hoy, ROUND(15000.00 * (1 - 7.50 / 100), 2)),
  (4, 2, DATE_ADD(@hoy, INTERVAL 1 DAY), DATE_ADD(@hoy, INTERVAL 1 MONTH), ROUND(15000.00 * (1 - 7.50 / 100), 2)),
  (4, 3, DATE_ADD(DATE_ADD(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), DATE_ADD(@hoy, INTERVAL 2 MONTH), ROUND(15000.00 * (1 - 7.50 / 100), 2));

-- Contrato 5 (cliente 5, plan 2, promoción 1, 1 cuota de 25000.00): Cuota única que vence hoy, pagada; sin cuota siguiente.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (5, 5, 2, 1, 1, 25000.00, 0.00, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (5, 1, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), @hoy, ROUND(25000.00 * (1 - 0.00 / 100), 2));

-- Contrato 6 (cliente 6, plan 3, promoción 2, 3 cuotas de 36000.45): Trimestral con cuota 1 pagada que vence hoy y cuota 2 impaga.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (6, 6, 3, 2, 3, 40000.50, 10.00, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (6, 1, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), @hoy, ROUND(40000.50 * (1 - 10.00 / 100), 2)),
  (6, 2, DATE_ADD(@hoy, INTERVAL 1 DAY), DATE_ADD(@hoy, INTERVAL 1 MONTH), ROUND(40000.50 * (1 - 10.00 / 100), 2)),
  (6, 3, DATE_ADD(DATE_ADD(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), DATE_ADD(@hoy, INTERVAL 2 MONTH), ROUND(40000.50 * (1 - 10.00 / 100), 2));

-- Contrato 7 (cliente 7, plan 1, promoción 2, 3 cuotas de 13500.00): Trimestral con la última cuota (3 de 3) pagada y vencida hoy; sin cuota siguiente.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (7, 7, 1, 2, 3, 15000.00, 10.00, DATE_ADD(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (7, 1, DATE_ADD(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 1 DAY), DATE_SUB(@hoy, INTERVAL 2 MONTH), ROUND(15000.00 * (1 - 10.00 / 100), 2)),
  (7, 2, DATE_ADD(DATE_SUB(@hoy, INTERVAL 2 MONTH), INTERVAL 1 DAY), DATE_SUB(@hoy, INTERVAL 1 MONTH), ROUND(15000.00 * (1 - 10.00 / 100), 2)),
  (7, 3, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), @hoy, ROUND(15000.00 * (1 - 10.00 / 100), 2));

-- Contrato 8 (cliente 8, plan 1, promoción 1, 1 cuota de 15000.00): Cuota única vencida AYER y pagada: ya no habilita; figura en el listado de ayer.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (8, 8, 1, 1, 1, 15000.00, 0.00, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (8, 1, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), DATE_SUB(@hoy, INTERVAL 1 DAY), ROUND(15000.00 * (1 - 0.00 / 100), 2));

-- Contrato 9 (cliente 9, plan 1, promoción 1, 1 cuota de 15000.00): Cuota única que inicia HOY, pagada: habilitada (desde = hoy, borde inclusivo).
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (9, 9, 1, 1, 1, 15000.00, 0.00, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 DAY), INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 DAY), INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (9, 1, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 DAY), INTERVAL 1 DAY), DATE_SUB(DATE_ADD(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), ROUND(15000.00 * (1 - 0.00 / 100), 2));

-- Contrato 10 (cliente 10, plan 2, promoción 1, 1 cuota de 25000.00): Cuota única que inicia MAÑANA, pagada: todavía no habilita (adelantada).
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (10, 10, 2, 1, 1, 25000.00, 0.00, DATE_ADD(@hoy, INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(@hoy, INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (10, 1, DATE_ADD(@hoy, INTERVAL 1 DAY), DATE_ADD(@hoy, INTERVAL 1 MONTH), ROUND(25000.00 * (1 - 0.00 / 100), 2));

-- Contrato 11 (cliente 11, plan 2, promoción 1, 1 cuota de 25000.00): Cuota única vencida hace 20 días e impaga (moroso).
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (11, 11, 2, 1, 1, 25000.00, 0.00, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 20 DAY), INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 20 DAY), INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (11, 1, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 20 DAY), INTERVAL 1 DAY), DATE_SUB(@hoy, INTERVAL 20 DAY), ROUND(25000.00 * (1 - 0.00 / 100), 2));

-- Contrato 12 (cliente 12, plan 1, promoción 1, 1 cuota de 15000.00): Cuota única vencida hace 20 días y pagada tarde: conserva su período, no habilita.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (12, 12, 1, 1, 1, 15000.00, 0.00, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 20 DAY), INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 20 DAY), INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (12, 1, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 20 DAY), INTERVAL 1 DAY), DATE_SUB(@hoy, INTERVAL 20 DAY), ROUND(15000.00 * (1 - 0.00 / 100), 2));

-- Contrato 13 (cliente 13, plan 1, promoción 1, 1 cuota de 15000.00): Cuota vigente cuyo único pago fue anulado: sin habilitación.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (13, 13, 1, 1, 1, 15000.00, 0.00, DATE_SUB(@hoy, INTERVAL 5 DAY), TIMESTAMP(LEAST(@hoy, DATE_SUB(@hoy, INTERVAL 5 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (13, 1, DATE_SUB(@hoy, INTERVAL 5 DAY), DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 5 DAY), INTERVAL 1 MONTH), INTERVAL 1 DAY), ROUND(15000.00 * (1 - 0.00 / 100), 2));

-- Contrato 14 (cliente 14, plan 1, promoción 1, 1 cuota de 15000.00): Cuota única que vence hoy con pago anulado: no habilita ni figura en el listado.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (14, 14, 1, 1, 1, 15000.00, 0.00, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (14, 1, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), @hoy, ROUND(15000.00 * (1 - 0.00 / 100), 2));

-- Contrato 15 (cliente 15, plan 2, promoción 2, 3 cuotas de 22500.00): Trimestral: cuota 1 pagada vence hoy; el pago de la cuota 2 está anulado.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (15, 15, 2, 2, 3, 25000.00, 10.00, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (15, 1, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), @hoy, ROUND(25000.00 * (1 - 10.00 / 100), 2)),
  (15, 2, DATE_ADD(@hoy, INTERVAL 1 DAY), DATE_ADD(@hoy, INTERVAL 1 MONTH), ROUND(25000.00 * (1 - 10.00 / 100), 2)),
  (15, 3, DATE_ADD(DATE_ADD(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), DATE_ADD(@hoy, INTERVAL 2 MONTH), ROUND(25000.00 * (1 - 10.00 / 100), 2));

-- Contrato 16 (cliente 16, plan 1, promoción 1, 1 cuota de 15000.00): Contrato A: cuota única que vence hoy, pagada.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (16, 16, 1, 1, 1, 15000.00, 0.00, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (16, 1, DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), @hoy, ROUND(15000.00 * (1 - 0.00 / 100), 2));

-- Contrato 17 (cliente 16, plan 1, promoción 1, 1 cuota de 15000.00): Contrato B: inicia mañana, pagado por adelantado (se excluye del listado de hoy; borde de superposición: desde > vencimiento de A).
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (17, 16, 1, 1, 1, 15000.00, 0.00, DATE_ADD(@hoy, INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(@hoy, INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (17, 1, DATE_ADD(@hoy, INTERVAL 1 DAY), DATE_ADD(@hoy, INTERVAL 1 MONTH), ROUND(15000.00 * (1 - 0.00 / 100), 2));

-- Contrato 18 (cliente 17, plan 1, promoción 1, 1 cuota de 15000.00): Cuota vigente con dos pagos anulados y un tercero vigente (corrección de errores de caja).
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (18, 17, 1, 1, 1, 15000.00, 0.00, DATE_SUB(@hoy, INTERVAL 5 DAY), TIMESTAMP(LEAST(@hoy, DATE_SUB(@hoy, INTERVAL 5 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (18, 1, DATE_SUB(@hoy, INTERVAL 5 DAY), DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 5 DAY), INTERVAL 1 MONTH), INTERVAL 1 DAY), ROUND(15000.00 * (1 - 0.00 / 100), 2));

-- Contrato 19 (cliente 18, plan 2, promoción 3, 6 cuotas de 20000.00): Semestral completo (6/6 pagas) que terminó ayer: ex-socio.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (19, 18, 2, 3, 6, 25000.00, 20.00, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 6 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 6 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (19, 1, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 6 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), DATE_SUB(DATE_SUB(@hoy, INTERVAL 5 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 20.00 / 100), 2)),
  (19, 2, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 5 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), DATE_SUB(DATE_SUB(@hoy, INTERVAL 4 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 20.00 / 100), 2)),
  (19, 3, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 4 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 20.00 / 100), 2)),
  (19, 4, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), DATE_SUB(DATE_SUB(@hoy, INTERVAL 2 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 20.00 / 100), 2)),
  (19, 5, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 2 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 20.00 / 100), 2)),
  (19, 6, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), DATE_SUB(@hoy, INTERVAL 1 DAY), ROUND(25000.00 * (1 - 20.00 / 100), 2));

-- Contrato 20 (cliente 19, plan 1, promoción 2, 3 cuotas de 13500.00): Trimestral vencido hace 40 días, todo pago; el cliente se renueva por SP más abajo.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (20, 19, 1, 2, 3, 15000.00, 10.00, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (20, 1, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY), DATE_SUB(DATE_SUB(@hoy, INTERVAL 2 MONTH), INTERVAL 40 DAY), ROUND(15000.00 * (1 - 10.00 / 100), 2)),
  (20, 2, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 2 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY), DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 40 DAY), ROUND(15000.00 * (1 - 10.00 / 100), 2)),
  (20, 3, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY), DATE_SUB(@hoy, INTERVAL 40 DAY), ROUND(15000.00 * (1 - 10.00 / 100), 2));

-- Contrato 21 (cliente 20, plan 1, promoción 2, 3 cuotas de 13500.00): Contrato A histórico (vencido hace 40 días), completamente pagado.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (21, 20, 1, 2, 3, 15000.00, 10.00, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (21, 1, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY), DATE_SUB(DATE_SUB(@hoy, INTERVAL 2 MONTH), INTERVAL 40 DAY), ROUND(15000.00 * (1 - 10.00 / 100), 2)),
  (21, 2, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 2 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY), DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 40 DAY), ROUND(15000.00 * (1 - 10.00 / 100), 2)),
  (21, 3, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY), DATE_SUB(@hoy, INTERVAL 40 DAY), ROUND(15000.00 * (1 - 10.00 / 100), 2));

-- Contrato 22 (cliente 20, plan 2, promoción 1, 1 cuota de 25000.00): Contrato B vigente posterior al A: segundo contrato del mismo cliente (conserva carnet).
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (22, 20, 2, 1, 1, 25000.00, 0.00, DATE_SUB(@hoy, INTERVAL 10 DAY), TIMESTAMP(LEAST(@hoy, DATE_SUB(@hoy, INTERVAL 10 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (22, 1, DATE_SUB(@hoy, INTERVAL 10 DAY), DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 1 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 0.00 / 100), 2));

-- Contrato 23 (cliente 21, plan 4, promoción 6, 6 cuotas de 6800.00): Contrato histórico sobre plan y promoción dados de baja (condiciones congeladas).
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (23, 21, 4, 6, 6, 8000.00, 15.00, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 6 MONTH), INTERVAL 200 DAY), INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 6 MONTH), INTERVAL 200 DAY), INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (23, 1, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 6 MONTH), INTERVAL 200 DAY), INTERVAL 1 DAY), DATE_SUB(DATE_SUB(@hoy, INTERVAL 5 MONTH), INTERVAL 200 DAY), ROUND(8000.00 * (1 - 15.00 / 100), 2)),
  (23, 2, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 5 MONTH), INTERVAL 200 DAY), INTERVAL 1 DAY), DATE_SUB(DATE_SUB(@hoy, INTERVAL 4 MONTH), INTERVAL 200 DAY), ROUND(8000.00 * (1 - 15.00 / 100), 2)),
  (23, 3, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 4 MONTH), INTERVAL 200 DAY), INTERVAL 1 DAY), DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 200 DAY), ROUND(8000.00 * (1 - 15.00 / 100), 2)),
  (23, 4, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 200 DAY), INTERVAL 1 DAY), DATE_SUB(DATE_SUB(@hoy, INTERVAL 2 MONTH), INTERVAL 200 DAY), ROUND(8000.00 * (1 - 15.00 / 100), 2)),
  (23, 5, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 2 MONTH), INTERVAL 200 DAY), INTERVAL 1 DAY), DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 200 DAY), ROUND(8000.00 * (1 - 15.00 / 100), 2)),
  (23, 6, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 200 DAY), INTERVAL 1 DAY), DATE_SUB(@hoy, INTERVAL 200 DAY), ROUND(8000.00 * (1 - 15.00 / 100), 2));

-- Contrato 24 (cliente 22, plan 5, promoción 5, 1 cuota de 0.00): Beca 100% sobre plan de $0,01: cuota de importe 0.00.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (24, 22, 5, 5, 1, 0.01, 100.00, DATE_SUB(@hoy, INTERVAL 10 DAY), TIMESTAMP(LEAST(@hoy, DATE_SUB(@hoy, INTERVAL 10 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (24, 1, DATE_SUB(@hoy, INTERVAL 10 DAY), DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 1 MONTH), INTERVAL 1 DAY), ROUND(0.01 * (1 - 100.00 / 100), 2));

-- Contrato 25 (cliente 23, plan 5, promoción 4, 3 cuotas de 0.01): Plan de $0,01 con 7,5%: el redondeo da 0.01 por cuota.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (25, 23, 5, 4, 3, 0.01, 7.50, DATE_SUB(@hoy, INTERVAL 10 DAY), TIMESTAMP(LEAST(@hoy, DATE_SUB(@hoy, INTERVAL 10 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (25, 1, DATE_SUB(@hoy, INTERVAL 10 DAY), DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 1 MONTH), INTERVAL 1 DAY), ROUND(0.01 * (1 - 7.50 / 100), 2)),
  (25, 2, DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 1 MONTH), DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 2 MONTH), INTERVAL 1 DAY), ROUND(0.01 * (1 - 7.50 / 100), 2)),
  (25, 3, DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 2 MONTH), DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 3 MONTH), INTERVAL 1 DAY), ROUND(0.01 * (1 - 7.50 / 100), 2));

-- Contrato 26 (cliente 24, plan 6, promoción 7, 3 cuotas de 99999999.99): Importe máximo DECIMAL(10,2) y promoción trimestral sin descuento (igual exige tarjeta).
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (26, 24, 6, 7, 3, 99999999.99, 0.00, DATE_SUB(@hoy, INTERVAL 10 DAY), TIMESTAMP(LEAST(@hoy, DATE_SUB(@hoy, INTERVAL 10 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (26, 1, DATE_SUB(@hoy, INTERVAL 10 DAY), DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 1 MONTH), INTERVAL 1 DAY), ROUND(99999999.99 * (1 - 0.00 / 100), 2)),
  (26, 2, DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 1 MONTH), DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 2 MONTH), INTERVAL 1 DAY), ROUND(99999999.99 * (1 - 0.00 / 100), 2)),
  (26, 3, DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 2 MONTH), DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 10 DAY), INTERVAL 3 MONTH), INTERVAL 1 DAY), ROUND(99999999.99 * (1 - 0.00 / 100), 2));

-- Contrato 27 (cliente 25, plan 1, promoción 2, 3 cuotas de 13500.00): Inicio 31/01/2024 (año bisiesto): la cuota 2 empieza el 29/02, no el 31.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (27, 25, 1, 2, 3, 15000.00, 10.00, DATE '2024-01-31', TIMESTAMP(LEAST(@hoy, DATE '2024-01-31'), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (27, 1, DATE '2024-01-31', DATE_SUB(DATE_ADD(DATE '2024-01-31', INTERVAL 1 MONTH), INTERVAL 1 DAY), ROUND(15000.00 * (1 - 10.00 / 100), 2)),
  (27, 2, DATE_ADD(DATE '2024-01-31', INTERVAL 1 MONTH), DATE_SUB(DATE_ADD(DATE '2024-01-31', INTERVAL 2 MONTH), INTERVAL 1 DAY), ROUND(15000.00 * (1 - 10.00 / 100), 2)),
  (27, 3, DATE_ADD(DATE '2024-01-31', INTERVAL 2 MONTH), DATE_SUB(DATE_ADD(DATE '2024-01-31', INTERVAL 3 MONTH), INTERVAL 1 DAY), ROUND(15000.00 * (1 - 10.00 / 100), 2));

-- Contrato 28 (cliente 26, plan 1, promoción 2, 3 cuotas de 13500.00): Inicio 31/08/2025: cuotas inician 30/09 y 31/10 (recorte por fin de mes).
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (28, 26, 1, 2, 3, 15000.00, 10.00, DATE '2025-08-31', TIMESTAMP(LEAST(@hoy, DATE '2025-08-31'), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (28, 1, DATE '2025-08-31', DATE_SUB(DATE_ADD(DATE '2025-08-31', INTERVAL 1 MONTH), INTERVAL 1 DAY), ROUND(15000.00 * (1 - 10.00 / 100), 2)),
  (28, 2, DATE_ADD(DATE '2025-08-31', INTERVAL 1 MONTH), DATE_SUB(DATE_ADD(DATE '2025-08-31', INTERVAL 2 MONTH), INTERVAL 1 DAY), ROUND(15000.00 * (1 - 10.00 / 100), 2)),
  (28, 3, DATE_ADD(DATE '2025-08-31', INTERVAL 2 MONTH), DATE_SUB(DATE_ADD(DATE '2025-08-31', INTERVAL 3 MONTH), INTERVAL 1 DAY), ROUND(15000.00 * (1 - 10.00 / 100), 2));

-- Contrato 29 (cliente 28, plan 1, promoción 1, 1 cuota de 15000.00): Socio sin apto físico con cuota vigente pagada.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (29, 28, 1, 1, 1, 15000.00, 0.00, DATE_SUB(@hoy, INTERVAL 3 DAY), TIMESTAMP(LEAST(@hoy, DATE_SUB(@hoy, INTERVAL 3 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (29, 1, DATE_SUB(@hoy, INTERVAL 3 DAY), DATE_SUB(DATE_ADD(DATE_SUB(@hoy, INTERVAL 3 DAY), INTERVAL 1 MONTH), INTERVAL 1 DAY), ROUND(15000.00 * (1 - 0.00 / 100), 2));

-- Contrato 30 (cliente 29, plan 2, promoción 2, 3 cuotas de 22500.00): Trimestral contratado hoy y sin ningún pago.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (30, 29, 2, 2, 3, 25000.00, 10.00, @hoy, TIMESTAMP(LEAST(@hoy, @hoy), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (30, 1, @hoy, DATE_SUB(DATE_ADD(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 10.00 / 100), 2)),
  (30, 2, DATE_ADD(@hoy, INTERVAL 1 MONTH), DATE_SUB(DATE_ADD(@hoy, INTERVAL 2 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 10.00 / 100), 2)),
  (30, 3, DATE_ADD(@hoy, INTERVAL 2 MONTH), DATE_SUB(DATE_ADD(@hoy, INTERVAL 3 MONTH), INTERVAL 1 DAY), ROUND(25000.00 * (1 - 10.00 / 100), 2));

-- Contrato 31 (cliente 40, plan 1, promoción 1, 1 cuota de 15000.00): Cuota única que vence mañana, pagada: figura en el listado de mañana, no en el de hoy.
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (31, 40, 1, 1, 1, 15000.00, 0.00, DATE_ADD(DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (31, 1, DATE_ADD(DATE_ADD(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), DATE_ADD(@hoy, INTERVAL 1 DAY), ROUND(15000.00 * (1 - 0.00 / 100), 2));

-- Contrato 32 (cliente 54, plan 1, promoción 1, 1 cuota de 15000.00): Cuota única vencida hace 20 días e impaga; se paga luego por SP (aviso de cuota vencida).
INSERT INTO contrato (id_contrato, id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, descuento_pct_pactado, fecha_inicio, fecha_creacion)
VALUES (32, 54, 1, 1, 1, 15000.00, 0.00, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 20 DAY), INTERVAL 1 DAY), TIMESTAMP(LEAST(@hoy, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 20 DAY), INTERVAL 1 DAY)), '09:00:00'));
INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES
  (32, 1, DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 20 DAY), INTERVAL 1 DAY), DATE_SUB(@hoy, INTERVAL 20 DAY), ROUND(15000.00 * (1 - 0.00 / 100), 2));

-- =============================================================================
-- 5. PAGOS DE CUOTAS (importe tomado de la cuota pactada; fecha de pago explícita)
-- =============================================================================

-- Contrato 1, cuota 1: Pago en efectivo el día de inicio: habilitada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 10 DAY), '09:40:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 1 AND cu.nro_cuota = 1;

-- Contrato 2, cuota 1: Cuota 1 con tarjeta (obligatoria en promoción): habilitado.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'TARJETA', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 10 DAY), '10:05:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 2 AND cu.nro_cuota = 1;

-- Contrato 3, cuota 1: Cuota 1 pagada al inicio de su período.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'TARJETA', TIMESTAMP(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), '11:30:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 3 AND cu.nro_cuota = 1;
-- Contrato 3, cuota 2: Cuota 2 pagada al inicio de su período.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), INTERVAL 1 MONTH), '12:20:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 3 AND cu.nro_cuota = 2;
-- Contrato 3, cuota 3: Cuota 3 pagada al inicio de su período.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), INTERVAL 2 MONTH), '15:10:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 3 AND cu.nro_cuota = 3;
-- Contrato 3, cuota 4: Cuota 4 vigente pagada: habilitada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 10 DAY), INTERVAL 3 MONTH), '17:45:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 3 AND cu.nro_cuota = 4;

-- Contrato 4, cuota 1: Cuota 1 pagada; vence hoy (borde superior de habilitación).
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'TARJETA', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 20 DAY), '19:00:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 4 AND cu.nro_cuota = 1;
-- Contrato 4, cuota 2: Cuota 2 pagada por adelantado: excluye al socio del listado de vencimientos.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'TARJETA', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 3 DAY), '08:15:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 4 AND cu.nro_cuota = 2;

-- Contrato 5, cuota 1: Pago en efectivo; aparece en el listado de hoy sin cuota siguiente.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 20 DAY), '09:40:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 5 AND cu.nro_cuota = 1;

-- Contrato 6, cuota 1: Aparece en el listado de hoy con cuota siguiente e importe.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'TARJETA', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 25 DAY), '10:05:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 6 AND cu.nro_cuota = 1;

-- Contrato 7, cuota 1: Cuota 1 pagada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 1 DAY), '11:30:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 7 AND cu.nro_cuota = 1;
-- Contrato 7, cuota 2: Cuota 2 pagada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_ADD(DATE_SUB(@hoy, INTERVAL 2 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), '12:20:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 7 AND cu.nro_cuota = 2;
-- Contrato 7, cuota 3: Cuota 3 pagada; fin de contrato hoy.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'TARJETA', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 20 DAY), '15:10:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 7 AND cu.nro_cuota = 3;

-- Contrato 8, cuota 1: Pago a tiempo; el período terminó ayer (borde inferior).
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'EFECTIVO', TIMESTAMP(DATE_ADD(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), INTERVAL 3 DAY), '17:45:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 8 AND cu.nro_cuota = 1;

-- Contrato 9, cuota 1: Pago el mismo día de inicio.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'EFECTIVO', TIMESTAMP(@hoy, '19:00:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 9 AND cu.nro_cuota = 1;

-- Contrato 10, cuota 1: Pago adelantado; el período empieza mañana.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 1 DAY), '08:15:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 10 AND cu.nro_cuota = 1;

-- Contrato 12, cuota 1: Pago tardío: se registra pero no habilita.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 2 DAY), '09:40:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 12 AND cu.nro_cuota = 1;

-- Contrato 13, cuota 1: Pago anulado con motivo; la cuota queda impaga.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 5 DAY), '10:05:00'), cu.importe, 1, 'Error de carga: medio de pago incorrecto'
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 13 AND cu.nro_cuota = 1;

-- Contrato 14, cuota 1: Pago anulado: la cuota no cuenta como pagada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 15 DAY), '11:30:00'), cu.importe, 1, 'Pago rechazado por la caja'
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 14 AND cu.nro_cuota = 1;

-- Contrato 15, cuota 1: Cuota 1 pagada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'TARJETA', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 25 DAY), '12:20:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 15 AND cu.nro_cuota = 1;
-- Contrato 15, cuota 2: Pago anulado: no excluye al socio del listado de hoy.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'TARJETA', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 1 DAY), '15:10:00'), cu.importe, 1, 'Tarjeta rechazada por el banco'
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 15 AND cu.nro_cuota = 2;

-- Contrato 16, cuota 1: Pagada; vence hoy.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 20 DAY), '17:45:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 16 AND cu.nro_cuota = 1;

-- Contrato 17, cuota 1: Renovación pagada por adelantado en otro contrato.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'EFECTIVO', TIMESTAMP(@hoy, '19:00:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 17 AND cu.nro_cuota = 1;

-- Contrato 18, cuota 1: Primer intento, anulado.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 5 DAY), '08:15:00'), cu.importe, 1, 'Medio de pago mal cargado'
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 18 AND cu.nro_cuota = 1;
-- Contrato 18, cuota 1: Segundo intento, anulado.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'TARJETA', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 5 DAY), '09:40:00'), cu.importe, 1, 'Carga duplicada en turno noche'
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 18 AND cu.nro_cuota = 1;
-- Contrato 18, cuota 1: Pago vigente: la clave única solo considera pagos no anulados.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 4 DAY), '10:05:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 18 AND cu.nro_cuota = 1;

-- Contrato 19, cuota 1: Cuota 1 de 6 pagada al inicio de su período.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 6 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), '11:30:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 19 AND cu.nro_cuota = 1;
-- Contrato 19, cuota 2: Cuota 2 de 6 pagada al inicio de su período.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 5 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), '12:20:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 19 AND cu.nro_cuota = 2;
-- Contrato 19, cuota 3: Cuota 3 de 6 pagada al inicio de su período.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 4 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), '15:10:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 19 AND cu.nro_cuota = 3;
-- Contrato 19, cuota 4: Cuota 4 de 6 pagada al inicio de su período.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), '17:45:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 19 AND cu.nro_cuota = 4;
-- Contrato 19, cuota 5: Cuota 5 de 6 pagada al inicio de su período.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 2 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), '19:00:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 19 AND cu.nro_cuota = 5;
-- Contrato 19, cuota 6: Cuota 6 de 6 pagada al inicio de su período.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 1 DAY), INTERVAL 1 DAY), '08:15:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 19 AND cu.nro_cuota = 6;

-- Contrato 20, cuota 1: Cuota 1 de 3 pagada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY), '09:40:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 20 AND cu.nro_cuota = 1;
-- Contrato 20, cuota 2: Cuota 2 de 3 pagada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 2 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY), '10:05:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 20 AND cu.nro_cuota = 2;
-- Contrato 20, cuota 3: Cuota 3 de 3 pagada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY), '11:30:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 20 AND cu.nro_cuota = 3;

-- Contrato 21, cuota 1: Cuota 1 de 3 pagada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY), '12:20:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 21 AND cu.nro_cuota = 1;
-- Contrato 21, cuota 2: Cuota 2 de 3 pagada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 2 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY), '15:10:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 21 AND cu.nro_cuota = 2;
-- Contrato 21, cuota 3: Cuota 3 de 3 pagada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 40 DAY), INTERVAL 1 DAY), '17:45:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 21 AND cu.nro_cuota = 3;

-- Contrato 22, cuota 1: Renovación pagada en efectivo.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 10 DAY), '19:00:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 22 AND cu.nro_cuota = 1;

-- Contrato 23, cuota 1: Cuota 1 de 6 pagada (importe pactado, no el de catálogo actual).
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 4, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 6 MONTH), INTERVAL 200 DAY), INTERVAL 1 DAY), '08:15:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 23 AND cu.nro_cuota = 1;
-- Contrato 23, cuota 2: Cuota 2 de 6 pagada (importe pactado, no el de catálogo actual).
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 4, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 5 MONTH), INTERVAL 200 DAY), INTERVAL 1 DAY), '09:40:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 23 AND cu.nro_cuota = 2;
-- Contrato 23, cuota 3: Cuota 3 de 6 pagada (importe pactado, no el de catálogo actual).
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 4, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 4 MONTH), INTERVAL 200 DAY), INTERVAL 1 DAY), '10:05:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 23 AND cu.nro_cuota = 3;
-- Contrato 23, cuota 4: Cuota 4 de 6 pagada (importe pactado, no el de catálogo actual).
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 4, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 3 MONTH), INTERVAL 200 DAY), INTERVAL 1 DAY), '11:30:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 23 AND cu.nro_cuota = 4;
-- Contrato 23, cuota 5: Cuota 5 de 6 pagada (importe pactado, no el de catálogo actual).
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 4, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 2 MONTH), INTERVAL 200 DAY), INTERVAL 1 DAY), '12:20:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 23 AND cu.nro_cuota = 5;
-- Contrato 23, cuota 6: Cuota 6 de 6 pagada (importe pactado, no el de catálogo actual).
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 4, 'TARJETA', TIMESTAMP(DATE_ADD(DATE_SUB(DATE_SUB(@hoy, INTERVAL 1 MONTH), INTERVAL 200 DAY), INTERVAL 1 DAY), '15:10:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 23 AND cu.nro_cuota = 6;

-- Contrato 24, cuota 1: Pago de importe 0.00; habilita.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 10 DAY), '17:45:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 24 AND cu.nro_cuota = 1;

-- Contrato 25, cuota 1: Cuota 1 de 0.01 con tarjeta; 2 y 3 impagas.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'TARJETA', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 10 DAY), '19:00:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 25 AND cu.nro_cuota = 1;

-- Contrato 26, cuota 1: Cuota de 99999999.99 pagada con tarjeta.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'TARJETA', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 10 DAY), '08:15:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 26 AND cu.nro_cuota = 1;

-- Contrato 27, cuota 1: Cuota 1 de 3 pagada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 4, 'TARJETA', TIMESTAMP(DATE '2024-01-31', '09:40:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 27 AND cu.nro_cuota = 1;
-- Contrato 27, cuota 2: Cuota 2 de 3 pagada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 4, 'TARJETA', TIMESTAMP(DATE_ADD(DATE '2024-01-31', INTERVAL 1 MONTH), '10:05:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 27 AND cu.nro_cuota = 2;
-- Contrato 27, cuota 3: Cuota 3 de 3 pagada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 4, 'TARJETA', TIMESTAMP(DATE_ADD(DATE '2024-01-31', INTERVAL 2 MONTH), '11:30:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 27 AND cu.nro_cuota = 3;

-- Contrato 28, cuota 1: Cuota 1 de 3 pagada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 4, 'TARJETA', TIMESTAMP(DATE '2025-08-31', '12:20:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 28 AND cu.nro_cuota = 1;
-- Contrato 28, cuota 2: Cuota 2 de 3 pagada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 4, 'TARJETA', TIMESTAMP(DATE_ADD(DATE '2025-08-31', INTERVAL 1 MONTH), '15:10:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 28 AND cu.nro_cuota = 2;
-- Contrato 28, cuota 3: Cuota 3 de 3 pagada.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 4, 'TARJETA', TIMESTAMP(DATE_ADD(DATE '2025-08-31', INTERVAL 2 MONTH), '17:45:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 28 AND cu.nro_cuota = 3;

-- Contrato 29, cuota 1: Cuota pagada; socio habilitado aunque falte apto.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 2, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 3 DAY), '19:00:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 29 AND cu.nro_cuota = 1;

-- Contrato 31, cuota 1: Pagada; habilitado hasta mañana.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT c.id_cliente, cu.id_cuota, NULL, 1, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 10 DAY), '08:15:00'), cu.importe, 0, NULL
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato WHERE cu.id_contrato = 31 AND cu.nro_cuota = 1;

-- =============================================================================
-- 6. PAGOS DE ACTIVIDADES (precio diario de cartilla)
-- =============================================================================
-- Cliente 1, actividad 1: Cliente 1 pagó por día ANTES de asociarse (no era socia).
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT 1, NULL, a.id_actividad, 1, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 40 DAY), '09:40:00'), a.precio_diario, 0, NULL
FROM actividad a WHERE a.id_actividad = 1;
-- Cliente 30, actividad 1: No socio, natación en efectivo.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT 30, NULL, a.id_actividad, 1, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 30 DAY), '10:05:00'), a.precio_diario, 0, NULL
FROM actividad a WHERE a.id_actividad = 1;
-- Cliente 30, actividad 2: No socio, musculación con tarjeta.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT 30, NULL, a.id_actividad, 2, 'TARJETA', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 14 DAY), '11:30:00'), a.precio_diario, 0, NULL
FROM actividad a WHERE a.id_actividad = 2;
-- Cliente 30, actividad 3: No socio, yoga hoy.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT 30, NULL, a.id_actividad, 1, 'EFECTIVO', TIMESTAMP(@hoy, '12:20:00'), a.precio_diario, 0, NULL
FROM actividad a WHERE a.id_actividad = 3;
-- Cliente 30, actividad 5: Actividad hoy dada de baja, cobrada cuando estaba vigente; usuario hoy inactivo.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT 30, NULL, a.id_actividad, 4, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 300 DAY), '15:10:00'), a.precio_diario, 0, NULL
FROM actividad a WHERE a.id_actividad = 5;
-- Cliente 31, actividad 1: No socia sin apto físico: pago registrado igual.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT 31, NULL, a.id_actividad, 2, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 2 DAY), '17:45:00'), a.precio_diario, 0, NULL
FROM actividad a WHERE a.id_actividad = 1;
-- Cliente 33, actividad 4: Actividad de importe mínimo 0.01.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT 33, NULL, a.id_actividad, 1, 'TARJETA', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 1 DAY), '19:00:00'), a.precio_diario, 0, NULL
FROM actividad a WHERE a.id_actividad = 4;
-- Cliente 34, actividad 2: Cobro del usuario de nombre de 30 caracteres.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT 34, NULL, a.id_actividad, 5, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 1 DAY), '08:15:00'), a.precio_diario, 0, NULL
FROM actividad a WHERE a.id_actividad = 2;
-- Cliente 38, actividad 3: Cobro registrado por el administrador.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT 38, NULL, a.id_actividad, 3, 'TARJETA', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 2 DAY), '09:40:00'), a.precio_diario, 0, NULL
FROM actividad a WHERE a.id_actividad = 3;
-- Cliente 11, actividad 2: Socio moroso (no habilitado) paga por día: permitido.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT 11, NULL, a.id_actividad, 1, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 1 DAY), '10:05:00'), a.precio_diario, 0, NULL
FROM actividad a WHERE a.id_actividad = 2;
-- Cliente 12, actividad 1: Socio con cuota vencida pagada tarde (no habilitado) paga por día: permitido.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT 12, NULL, a.id_actividad, 2, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 1 DAY), '11:30:00'), a.precio_diario, 0, NULL
FROM actividad a WHERE a.id_actividad = 1;
-- Cliente 18, actividad 3: Ex-socio vencido ayer paga por día: permitido.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT 18, NULL, a.id_actividad, 1, 'TARJETA', TIMESTAMP(@hoy, '12:20:00'), a.precio_diario, 0, NULL
FROM actividad a WHERE a.id_actividad = 3;
-- Cliente 35, actividad 1: Pago de actividad ANULADO con motivo.
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT 35, NULL, a.id_actividad, 1, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 5 DAY), '15:10:00'), a.precio_diario, 1, 'Cobro duplicado: la caja ya había registrado el pago'
FROM actividad a WHERE a.id_actividad = 1;
-- Cliente 35, actividad 1: Pago vigente que reemplaza al anulado (las actividades pueden repetirse).
INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion)
SELECT 35, NULL, a.id_actividad, 1, 'EFECTIVO', TIMESTAMP(DATE_SUB(@hoy, INTERVAL 5 DAY), '17:45:00'), a.precio_diario, 0, NULL
FROM actividad a WHERE a.id_actividad = 1;

-- =============================================================================
-- 7. ESTADO FINAL DE FIXTURES
-- Habilitados hoy (vw_socio_habilitado): clientes 1-7, 9, 15, 16, 17, 20, 22, 23, 24, 28, 40.
-- NO habilitados: 8, 10, 11, 12, 13, 14, 18, 19, 21, 25, 26, 29 y no socios.
-- =============================================================================

-- =============================================================================
-- 8. USO DE LOS STORED PROCEDURES (flujos que deben tener éxito)
-- =============================================================================

-- 8.1 Cliente 50: alta de socio sin promoción. Carnet nuevo = MAX(nro_carnet) + 1 = 1031.
CALL sp_contratar_plan(50, 1, 1, NULL);
SELECT cu.id_cuota INTO @c50 FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato
 WHERE c.id_cliente = 50 AND cu.nro_cuota = 1;

-- 8.2 Pago en efectivo; medio con espacios y minúsculas (se normaliza con TRIM/UPPER). Aviso: vigente.
CALL sp_registrar_pago_cuota(@c50, 1, '  efectivo ');

-- 8.3 Anulación del pago (motivo con espacios laterales, se recorta); la cuota queda libre.
SELECT id_pago INTO @p50 FROM pago WHERE id_cuota = @c50 AND anulado = 0;
CALL sp_anular_pago(@p50, '  Cobro duplicado en caja  ');

-- 8.4 Nuevo pago de la misma cuota tras la anulación: permitido (solo cuenta el pago vigente).
CALL sp_registrar_pago_cuota(@c50, 1, 'EFECTIVO');

-- 8.5 Cliente 51: alta trimestral. Carnet nuevo = 1032.
CALL sp_contratar_plan(51, 2, 2, NULL);
SELECT cu.id_cuota INTO @c51a FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato
 WHERE c.id_cliente = 51 AND cu.nro_cuota = 1;
SELECT cu.id_cuota INTO @c51b FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato
 WHERE c.id_cliente = 51 AND cu.nro_cuota = 2;

-- 8.6 Cuota 1 con tarjeta: aviso de cuota vigente y habilita.
CALL sp_registrar_pago_cuota(@c51a, 2, 'TARJETA');

-- 8.7 Cuota 2 con tarjeta antes de su período: aviso de cuota adelantada (no habilita aún).
CALL sp_registrar_pago_cuota(@c51b, 2, 'tarjeta');

-- 8.8 Cliente 19 (ex-socia): renovación semestral con inicio hoy; conserva el carnet 1019 y no crea otro.
CALL sp_contratar_plan(19, 2, 3, NULL);

-- 8.9 Cliente 52 (no socio sin apto físico): pago por día; el aviso advierte la falta de apto pero cobra.
CALL sp_registrar_pago_actividad(52, 2, 2, ' tarjeta ');

-- 8.10 Cliente 54: pago de cuota vencida hace 20 días; se registra, aviso de que no habilita.
SELECT cu.id_cuota INTO @c54 FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato
 WHERE c.id_cliente = 54 AND cu.nro_cuota = 1;
CALL sp_registrar_pago_cuota(@c54, 1, 'Efectivo');

-- 8.11 Listados de vencimientos.
-- Hoy: Álvarez Hernán (con cuota siguiente), Castro Sofía (3 de 3, sin siguiente),
--      Castro Valeria (sin siguiente), Ñúñez Mariana (con siguiente). Excluidos: 4, 14, 16.
CALL sp_listado_vencimientos_diario(NULL);
-- Ayer: Ramírez Joaquín (8) y Ortiz Tomás (18, 6 de 6).
CALL sp_listado_vencimientos_diario(DATE_SUB(CURDATE(), INTERVAL 1 DAY));
-- Mañana: Quiroga Martina (40).
CALL sp_listado_vencimientos_diario(DATE_ADD(CURDATE(), INTERVAL 1 DAY));
-- Fecha lejana sin vencimientos: conjunto vacío.
CALL sp_listado_vencimientos_diario(DATE_ADD(CURDATE(), INTERVAL 20 YEAR));

-- =============================================================================
-- 9. CASOS QUE DEBEN FALLAR (descomentar de a uno; cada uno indica el error esperado)
-- =============================================================================

-- ---- 9.1 Restricciones de tabla ----------------------------------------------
-- DNI duplicado (cliente 1): ERROR 1062 uq_cliente_dni.
-- INSERT INTO cliente (dni, nombre, apellido) VALUES ('30111222', 'Repetido', 'Repetido');
-- Carnet duplicado: ERROR 1062 uq_cliente_carnet.
-- INSERT INTO cliente (dni, nombre, apellido, nro_carnet) VALUES ('60000001', 'Carnet', 'Repetido', 1001);
-- Campo obligatorio nulo: ERROR 1048 (apellido NOT NULL).
-- INSERT INTO cliente (dni, nombre, apellido) VALUES ('60000002', 'Sin', NULL);
-- DNI de 11 caracteres: ERROR 1406 en modo estricto (VARCHAR(10)).
-- INSERT INTO cliente (dni, nombre, apellido) VALUES ('12345678901', 'Dni', 'Largo');
-- Nombre de usuario duplicado: ERROR 1062 uq_usuario_nombre.
-- INSERT INTO usuario (nombre_usuario, password_hash) VALUES ('admin', 'x');
-- Plan con precio 0: ERROR 3819 chk_plan_precio.
-- INSERT INTO plan (nombre, precio_mensual) VALUES ('Gratis', 0);
-- Plan con precio negativo: ERROR 3819 chk_plan_precio.
-- INSERT INTO plan (nombre, precio_mensual) VALUES ('Negativo', -1);
-- Actividad con precio 0: ERROR 3819 chk_actividad_precio.
-- INSERT INTO actividad (nombre, precio_diario) VALUES ('Gratis', 0);
-- Promoción con 0 cuotas: ERROR 3819 chk_promo_cuotas.
-- INSERT INTO promocion (nombre, n_cuotas, descuento_pct) VALUES ('Cero', 0, 0);
-- Promoción con descuento 100.01: ERROR 3819 chk_promo_desc.
-- INSERT INTO promocion (nombre, n_cuotas, descuento_pct) VALUES ('Excede', 1, 100.01);
-- Promoción con descuento negativo: ERROR 3819 chk_promo_desc.
-- INSERT INTO promocion (nombre, n_cuotas, descuento_pct) VALUES ('Negativo', 1, -1);
-- Contrato con 0 cuotas: ERROR 3819 chk_contrato_cuotas.
-- INSERT INTO contrato (id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, fecha_inicio) VALUES (32, 1, 1, 0, 15000, CURDATE());
-- Contrato con cliente inexistente: ERROR 1452 (FK contrato_ibfk_1).
-- INSERT INTO contrato (id_cliente, id_plan, id_promocion, n_cuotas, precio_pactado, fecha_inicio) VALUES (9999, 1, 1, 1, 15000, CURDATE());
-- Cuota con vencimiento anterior al inicio: ERROR 3819 chk_cuota_fechas.
-- INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES (1, 9, CURDATE(), DATE_SUB(CURDATE(), INTERVAL 1 DAY), 1);
-- Cuota con número repetido en el mismo contrato: ERROR 1062 uq_cuota_nro.
-- INSERT INTO cuota (id_contrato, nro_cuota, fecha_desde, fecha_vencimiento, importe) VALUES (1, 1, CURDATE(), CURDATE(), 1);
-- Pago con cuota y actividad a la vez: ERROR 3819 chk_pago_destino.
-- INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, importe)
-- VALUES (1, (SELECT id_cuota FROM cuota WHERE id_contrato = 1 AND nro_cuota = 1), 1, 1, 'EFECTIVO', 1);
-- Pago sin cuota ni actividad: ERROR 3819 chk_pago_destino.
-- INSERT INTO pago (id_cliente, id_usuario, medio_pago, importe) VALUES (1, 1, 'EFECTIVO', 1);
-- Segundo pago vigente de una misma cuota: ERROR 1062 uq_pago_cuota.
-- INSERT INTO pago (id_cliente, id_cuota, id_usuario, medio_pago, importe)
-- VALUES (1, (SELECT id_cuota FROM cuota WHERE id_contrato = 1 AND nro_cuota = 1), 1, 'EFECTIVO', 15000);
-- Pago con usuario inexistente: ERROR 1452 (FK pago_ibfk_4).
-- INSERT INTO pago (id_cliente, id_actividad, id_usuario, medio_pago, importe) VALUES (1, 1, 9999, 'EFECTIVO', 1);
-- Medio de pago fuera del ENUM: ERROR 1265 en modo estricto.
-- INSERT INTO pago (id_cliente, id_actividad, id_usuario, medio_pago, importe) VALUES (1, 1, 1, 'CHEQUE', 1);

-- ---- 9.2 Triggers de inmutabilidad (todos: SQLSTATE 45000) -------------------
-- 'El precio de un plan no se modifica: dar de baja y crear uno nuevo'
-- UPDATE plan SET precio_mensual = precio_mensual + 1 WHERE id_plan = 1;
-- 'Una promoción no se modifica: dar de baja y crear una nueva'
-- UPDATE promocion SET n_cuotas = 12 WHERE id_promocion = 2;
-- UPDATE promocion SET descuento_pct = 50 WHERE id_promocion = 2;
-- 'Las condiciones pactadas de un contrato no se modifican'
-- UPDATE contrato SET precio_pactado = 1 WHERE id_contrato = 1;
-- UPDATE contrato SET descuento_pct_pactado = 99 WHERE id_contrato = 1;
-- UPDATE contrato SET n_cuotas = 9 WHERE id_contrato = 1;
-- UPDATE contrato SET id_plan = 2 WHERE id_contrato = 1;
-- UPDATE contrato SET id_promocion = 2 WHERE id_contrato = 1;
-- 'El importe y el período de una cuota no se modifican'
-- UPDATE cuota SET importe = 1 WHERE id_contrato = 1 AND nro_cuota = 1;
-- UPDATE cuota SET fecha_desde = DATE_SUB(fecha_desde, INTERVAL 1 DAY) WHERE id_contrato = 1 AND nro_cuota = 1;
-- UPDATE cuota SET fecha_vencimiento = DATE_ADD(fecha_vencimiento, INTERVAL 1 DAY) WHERE id_contrato = 1 AND nro_cuota = 1;
-- Estas modificaciones SÍ están permitidas (no tocan lo pactado):
-- UPDATE plan SET fecha_baja = NOW() WHERE id_plan = 6;
-- UPDATE promocion SET nombre = 'Trimestral 10% (renombrada)' WHERE id_promocion = 2;

-- ---- 9.3 sp_contratar_plan ---------------------------------------------------
-- 'El cliente no existe'
-- CALL sp_contratar_plan(9999, 1, 1, NULL);
-- 'Plan inexistente o dado de baja' (plan 4 de baja / plan 999 inexistente)
-- CALL sp_contratar_plan(32, 4, 1, NULL);
-- CALL sp_contratar_plan(32, 999, 1, NULL);
-- 'Promoción inexistente o dada de baja' (promoción 6 de baja)
-- CALL sp_contratar_plan(32, 1, 6, NULL);
-- 'El cliente ya tiene cuotas que cubren esa fecha' (cliente 1 está vigente)
-- CALL sp_contratar_plan(1, 1, 1, NULL);
-- Borde: inicio igual al vencimiento de la última cuota (cliente 8 venció ayer) también se rechaza.
-- CALL sp_contratar_plan(8, 1, 1, DATE_SUB(CURDATE(), INTERVAL 1 DAY));
-- Borde: inicio el día siguiente al vencimiento SÍ es válido (cliente 8, inicio hoy). Conserva carnet.
-- CALL sp_contratar_plan(8, 1, 1, CURDATE());
-- Contratación con inicio futuro (cliente 32, no socio): válida, cuotas desde esa fecha.
-- CALL sp_contratar_plan(32, 1, 1, DATE_ADD(CURDATE(), INTERVAL 15 DAY));

-- ---- 9.4 sp_registrar_pago_cuota ---------------------------------------------
-- 'Medio de pago inválido: use EFECTIVO o TARJETA'
-- CALL sp_registrar_pago_cuota((SELECT id_cuota FROM cuota WHERE id_contrato = 30 AND nro_cuota = 1), 1, 'CHEQUE');
-- 'Usuario inexistente o inactivo' (usuario 4 inactivo; 9999 inexistente)
-- CALL sp_registrar_pago_cuota((SELECT id_cuota FROM cuota WHERE id_contrato = 30 AND nro_cuota = 1), 4, 'TARJETA');
-- CALL sp_registrar_pago_cuota((SELECT id_cuota FROM cuota WHERE id_contrato = 30 AND nro_cuota = 1), 9999, 'TARJETA');
-- 'La cuota no existe'
-- CALL sp_registrar_pago_cuota(999999, 1, 'TARJETA');
-- 'La cuota ya fue pagada' (contrato 1, cuota 1 con pago vigente)
-- CALL sp_registrar_pago_cuota((SELECT id_cuota FROM cuota WHERE id_contrato = 1 AND nro_cuota = 1), 1, 'EFECTIVO');
-- 'Los contratos con promoción de cuotas se abonan con tarjeta' (contrato 30 es trimestral)
-- CALL sp_registrar_pago_cuota((SELECT id_cuota FROM cuota WHERE id_contrato = 30 AND nro_cuota = 1), 1, 'EFECTIVO');
-- Éxito con tarjeta (cliente 29): aviso de cuota vigente; deja de ser "contratada sin pagar".
-- CALL sp_registrar_pago_cuota((SELECT id_cuota FROM cuota WHERE id_contrato = 30 AND nro_cuota = 1), 1, 'TARJETA');
-- Cuota anulada y repagada (contrato 18, cuota 1) ya tiene pago vigente: 'La cuota ya fue pagada'.
-- CALL sp_registrar_pago_cuota((SELECT id_cuota FROM cuota WHERE id_contrato = 18 AND nro_cuota = 1), 1, 'EFECTIVO');
-- Cuota con único pago anulado (contrato 13): se puede volver a pagar.
-- CALL sp_registrar_pago_cuota((SELECT id_cuota FROM cuota WHERE id_contrato = 13 AND nro_cuota = 1), 1, 'EFECTIVO');

-- ---- 9.5 sp_registrar_pago_actividad -----------------------------------------
-- 'Medio de pago inválido: use EFECTIVO o TARJETA'
-- CALL sp_registrar_pago_actividad(32, 1, 1, 'CHEQUE');
-- 'Usuario inexistente o inactivo'
-- CALL sp_registrar_pago_actividad(32, 1, 4, 'EFECTIVO');
-- 'El cliente no existe'
-- CALL sp_registrar_pago_actividad(9999, 1, 1, 'EFECTIVO');
-- 'Actividad inexistente o dada de baja' (actividad 5 de baja / 999 inexistente)
-- CALL sp_registrar_pago_actividad(32, 5, 1, 'EFECTIVO');
-- CALL sp_registrar_pago_actividad(32, 999, 1, 'EFECTIVO');
-- 'El cliente es socio habilitado: no abona la actividad por día' (cliente 1)
-- CALL sp_registrar_pago_actividad(1, 1, 1, 'EFECTIVO');
-- Cliente con cuota pagada que inicia mañana (10): no está habilitado, el cobro se acepta.
-- CALL sp_registrar_pago_actividad(10, 1, 1, 'EFECTIVO');
-- Cliente con cuota pagada vencida ayer (8): no habilitado, se acepta.
-- CALL sp_registrar_pago_actividad(8, 2, 1, 'TARJETA');
-- Cliente con apto físico (32 no tiene; 30 sí): aviso 'Pago registrado.' sin advertencia.
-- CALL sp_registrar_pago_actividad(30, 3, 1, 'EFECTIVO');

-- ---- 9.6 sp_anular_pago ------------------------------------------------------
-- 'El identificador del pago es inválido' (0, negativo o NULL)
-- CALL sp_anular_pago(0, 'Motivo');
-- CALL sp_anular_pago(NULL, 'Motivo');
-- 'La causa de anulación es obligatoria' (NULL, vacía o solo espacios)
-- CALL sp_anular_pago(1, NULL);
-- CALL sp_anular_pago(1, '   ');
-- 'La causa de anulación no puede superar 200 caracteres' (201 caracteres)
-- CALL sp_anular_pago(1, REPEAT('x', 201));
-- Borde: exactamente 200 caracteres es válido.
-- CALL sp_anular_pago(1, REPEAT('x', 200));
-- 'El pago no existe'
-- CALL sp_anular_pago(999999, 'Motivo');
-- 'El pago ya fue anulado' (pago anulado del contrato 13)
-- CALL sp_anular_pago((SELECT id_pago FROM pago WHERE id_cuota = (SELECT id_cuota FROM cuota WHERE id_contrato = 13 AND nro_cuota = 1) LIMIT 1), 'Otra vez');

-- =============================================================================
-- 10. VERIFICACIÓN
-- =============================================================================

-- Habilitados hoy: clientes 1-7, 9, 15, 16, 17, 20, 22, 23, 24, 28, 40, más 50 y 51 (pagos por SP).
SELECT c.id_cliente, c.apellido, c.nombre, v.habilitado_hasta
FROM vw_socio_habilitado v JOIN cliente c ON c.id_cliente = v.id_cliente
ORDER BY c.id_cliente;

-- Carnets: únicos y correlativos desde 1001; los no socios en NULL.
SELECT id_cliente, apellido, nro_carnet, es_socio FROM cliente WHERE nro_carnet IS NOT NULL ORDER BY nro_carnet;

-- Un pago por cuota vigente (ninguna fila): cuotas con más de un pago no anulado.
SELECT id_cuota, COUNT(*) AS pagos_vigentes FROM pago WHERE id_cuota IS NOT NULL AND anulado = 0
GROUP BY id_cuota HAVING COUNT(*) > 1;

-- Importes de pago iguales al importe pactado de la cuota (ninguna fila).
SELECT p.id_pago FROM pago p JOIN cuota cu ON cu.id_cuota = p.id_cuota WHERE p.importe <> cu.importe;

-- Cuotas impagas (sin pago vigente): morosos, contratos nuevos y cuotas futuras.
SELECT c.id_cliente, cu.id_contrato, cu.nro_cuota, cu.fecha_desde, cu.fecha_vencimiento
FROM cuota cu JOIN contrato c ON c.id_contrato = cu.id_contrato
LEFT JOIN pago p ON p.id_cuota = cu.id_cuota AND p.anulado = 0
WHERE p.id_pago IS NULL ORDER BY c.id_cliente, cu.nro_cuota;
