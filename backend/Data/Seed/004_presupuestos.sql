-- Presupuesto 1
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (1, 2650.00, 'Aprobado', '2025-07-01 10:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (1, 1, 1, 2500.00, 2500.00), (1, 3, 1, 150.00, 150.00);

-- Presupuesto 2
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (2, 1100.00, 'Pendiente', '2025-07-02 11:30:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (2, 1, 8, 85.00, 680.00), (2, 4, 4, 75.00, 300.00), (2, 3, 2, 50.00, 100.00);

-- Presupuesto 3
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (3, 1400.00, 'Aprobado', '2025-07-03 09:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (3, 2, 1, 800.00, 800.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (3, 2, 5, 120.00, 600.00);

-- Presupuesto 4
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (4, 80.00, 'Rechazado', '2025-07-05 14:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (4, 4, 1, 80.00, 80.00);

-- Presupuesto 5
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (1, 300.00, 'Pendiente', '2025-07-07 08:45:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (5, 3, 6, 50.00, 300.00);

-- Presupuesto 6
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (5, 3130.00, 'Pendiente', '2025-07-08 16:30:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (6, 1, 1, 2500.00, 2500.00), (6, 6, 2, 65.00, 130.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (6, 5, 5, 100.00, 500.00);

-- Presupuesto 7
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (6, 725.00, 'Aprobado', '2025-07-10 10:15:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (7, 1, 4, 85.00, 340.00), (7, 3, 4, 50.00, 200.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (7, 5, 1, 120.00, 120.00), (7, 6, 1, 65.00, 65.00);

-- Presupuesto 8
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (7, 2980.00, 'Aprobado', '2025-07-12 12:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (8, 1, 1, 2500.00, 2500.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (8, 2, 4, 120.00, 480.00);

-- Presupuesto 9
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (8, 550.00, 'Pendiente', '2025-07-15 09:30:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (9, 4, 6, 75.00, 450.00), (9, 3, 2, 50.00, 100.00);

-- Presupuesto 10
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (9, 1560.00, 'Rechazado', '2025-07-18 11:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (10, 2, 1, 800.00, 800.00), (10, 4, 2, 80.00, 160.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (10, 5, 6, 100.00, 600.00);

-- Presupuesto 11
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (10, 385.00, 'Aprobado', '2025-07-20 15:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (11, 1, 3, 85.00, 255.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (11, 6, 2, 65.00, 130.00);

-- Presupuesto 12
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (2, 2500.00, 'Aprobado', '2025-07-22 10:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (12, 1, 1, 2500.00, 2500.00);

-- Presupuesto 13
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (4, 715.00, 'Pendiente', '2025-07-25 13:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (13, 2, 3, 120.00, 360.00), (13, 4, 3, 75.00, 225.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (13, 6, 2, 65.00, 130.00);

-- Presupuesto 14
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (6, 1800.00, 'Aprobado', '2025-07-28 09:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (14, 2, 2, 800.00, 1600.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (14, 3, 4, 50.00, 200.00);

-- Presupuesto 15
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (3, 850.00, 'Rechazado', '2025-08-01 11:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (15, 1, 6, 85.00, 510.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (15, 5, 2, 120.00, 240.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (15, 3, 2, 50.00, 100.00);

-- Presupuesto 16
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (7, 1100.00, 'Aprobado', '2025-08-03 14:30:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (16, 5, 8, 100.00, 800.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (16, 3, 2, 150.00, 300.00);

-- Presupuesto 17
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (5, 455.00, 'Pendiente', '2025-08-05 08:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (17, 4, 5, 75.00, 375.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (17, 4, 1, 80.00, 80.00);

-- Presupuesto 18
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (9, 380.00, 'Aprobado', '2025-08-08 12:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (18, 3, 5, 50.00, 250.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (18, 6, 2, 65.00, 130.00);

-- Presupuesto 19
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (10, 2740.00, 'Rechazado', '2025-08-10 10:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (19, 1, 1, 2500.00, 2500.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (19, 2, 2, 120.00, 240.00);

-- Presupuesto 20
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (1, 745.00, 'Pendiente', '2025-08-12 15:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (20, 1, 5, 85.00, 425.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (20, 5, 1, 120.00, 120.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (20, 3, 4, 50.00, 200.00);

-- Presupuesto 21
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (3, 855.00, 'Aprobado', '2025-08-15 09:30:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (21, 4, 5, 75.00, 375.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (21, 2, 4, 120.00, 480.00);

-- Presupuesto 22
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (8, 1450.00, 'Pendiente', '2025-08-18 11:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (22, 2, 1, 800.00, 800.00), (22, 3, 1, 150.00, 150.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (22, 5, 5, 100.00, 500.00);

-- Presupuesto 23
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (6, 2500.00, 'Aprobado', '2025-08-20 14:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (23, 1, 1, 2500.00, 2500.00);

-- Presupuesto 24
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (7, 415.00, 'Rechazado', '2025-08-22 08:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (24, 1, 3, 85.00, 255.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (24, 4, 2, 80.00, 160.00);

-- Presupuesto 25
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (4, 1215.00, 'Pendiente', '2025-08-25 16:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (25, 2, 5, 120.00, 600.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (25, 5, 2, 120.00, 240.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (25, 4, 5, 75.00, 375.00);

-- Presupuesto 26
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (2, 530.00, 'Aprobado', '2025-08-28 10:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (26, 3, 8, 50.00, 400.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (26, 6, 2, 65.00, 130.00);

-- Presupuesto 27
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (9, 3000.00, 'Pendiente', '2025-09-01 12:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (27, 1, 1, 2500.00, 2500.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (27, 5, 5, 100.00, 500.00);

-- Presupuesto 28
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (10, 840.00, 'Aprobado', '2025-09-03 09:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (28, 1, 6, 85.00, 510.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (28, 6, 2, 65.00, 130.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (28, 3, 4, 50.00, 200.00);

-- Presupuesto 29
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (5, 2650.00, 'Rechazado', '2025-09-05 15:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (29, 1, 1, 2500.00, 2500.00), (29, 3, 1, 150.00, 150.00);

-- Presupuesto 30
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (8, 975.00, 'Aprobado', '2025-09-08 11:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (30, 2, 5, 120.00, 600.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (30, 4, 5, 75.00, 375.00);

-- Presupuesto 31
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (3, 420.00, 'Pendiente', '2025-09-10 08:30:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (31, 3, 6, 50.00, 300.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (31, 5, 1, 120.00, 120.00);

-- Presupuesto 32
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (1, 1375.00, 'Aprobado', '2025-09-12 14:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (32, 2, 1, 800.00, 800.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (32, 1, 5, 85.00, 425.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (32, 3, 1, 150.00, 150.00);

-- Presupuesto 33
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (6, 755.00, 'Rechazado', '2025-09-15 10:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (33, 4, 6, 75.00, 450.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (33, 5, 2, 120.00, 240.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (33, 6, 1, 65.00, 65.00);

-- Presupuesto 34
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (7, 505.00, 'Pendiente', '2025-09-18 12:30:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (34, 1, 5, 85.00, 425.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (34, 4, 1, 80.00, 80.00);

-- Presupuesto 35
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (4, 555.00, 'Aprobado', '2025-09-20 09:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (35, 2, 3, 120.00, 360.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (35, 6, 3, 65.00, 195.00);

-- Presupuesto 36
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (9, 2500.00, 'Pendiente', '2025-09-22 15:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (36, 1, 1, 2500.00, 2500.00);

-- Presupuesto 37
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (2, 550.00, 'Aprobado', '2025-09-25 10:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (37, 5, 4, 100.00, 400.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (37, 3, 1, 150.00, 150.00);

-- Presupuesto 38
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (10, 3230.00, 'Rechazado', '2025-09-28 11:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (38, 1, 1, 2500.00, 2500.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (38, 2, 5, 120.00, 600.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (38, 6, 2, 65.00, 130.00);

-- Presupuesto 39
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (5, 400.00, 'Pendiente', '2025-10-01 08:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (39, 3, 5, 50.00, 250.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (39, 4, 2, 75.00, 150.00);

-- Presupuesto 40
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (8, 1480.00, 'Aprobado', '2025-10-03 14:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (40, 2, 1, 800.00, 800.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (40, 1, 8, 85.00, 680.00);

-- Presupuesto 41
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (3, 1000.00, 'Pendiente', '2025-10-05 09:30:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (41, 5, 7, 100.00, 700.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (41, 3, 2, 150.00, 300.00);

-- Presupuesto 42
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (6, 280.00, 'Aprobado', '2025-10-08 12:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (42, 3, 4, 50.00, 200.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (42, 4, 1, 80.00, 80.00);

-- Presupuesto 43
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (1, 705.00, 'Rechazado', '2025-10-10 16:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (43, 2, 4, 120.00, 480.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (43, 4, 3, 75.00, 225.00);

-- Presupuesto 44
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (7, 2800.00, 'Pendiente', '2025-10-12 10:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (44, 1, 1, 2500.00, 2500.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (44, 5, 3, 100.00, 300.00);

-- Presupuesto 45
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (4, 620.00, 'Aprobado', '2025-10-15 08:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (45, 1, 5, 85.00, 425.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (45, 6, 3, 65.00, 195.00);

-- Presupuesto 46
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (9, 1250.00, 'Pendiente', '2025-10-18 13:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (46, 2, 1, 800.00, 800.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (46, 4, 6, 75.00, 450.00);

-- Presupuesto 47
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (2, 370.00, 'Aprobado', '2025-10-20 09:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (47, 3, 5, 50.00, 250.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (47, 5, 1, 120.00, 120.00);

-- Presupuesto 48
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (10, 940.00, 'Rechazado', '2025-10-22 15:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (48, 2, 5, 120.00, 600.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (48, 1, 4, 85.00, 340.00);

-- Presupuesto 49
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (5, 380.00, 'Pendiente', '2025-10-25 11:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (49, 4, 4, 75.00, 300.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (49, 4, 1, 80.00, 80.00);

-- Presupuesto 50
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (8, 2500.00, 'Aprobado', '2025-10-28 14:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (50, 1, 1, 2500.00, 2500.00);

-- Presupuesto 51
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (3, 455.00, 'Pendiente', '2025-11-01 10:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (51, 1, 3, 85.00, 255.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (51, 5, 2, 100.00, 200.00);

-- Presupuesto 52
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (6, 780.00, 'Aprobado', '2025-11-03 12:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (52, 3, 2, 150.00, 300.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (52, 2, 4, 120.00, 480.00);

-- Presupuesto 53
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (1, 250.00, 'Rechazado', '2025-11-05 09:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (53, 3, 5, 50.00, 250.00);

-- Presupuesto 54
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (7, 570.00, 'Pendiente', '2025-11-08 15:30:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (54, 4, 6, 75.00, 450.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (54, 5, 1, 120.00, 120.00);

-- Presupuesto 55
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (4, 1310.00, 'Aprobado', '2025-11-10 08:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (55, 2, 1, 800.00, 800.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (55, 1, 6, 85.00, 510.00);

-- Presupuesto 56
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (9, 400.00, 'Pendiente', '2025-11-12 11:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (56, 3, 8, 50.00, 400.00);

-- Presupuesto 57
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (2, 2660.00, 'Aprobado', '2025-11-14 14:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (57, 1, 1, 2500.00, 2500.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (57, 4, 2, 80.00, 160.00);

-- Presupuesto 58
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (10, 355.00, 'Rechazado', '2025-11-16 10:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (58, 4, 3, 75.00, 225.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (58, 6, 2, 65.00, 130.00);

-- Presupuesto 59
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (5, 760.00, 'Pendiente', '2025-11-18 09:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (59, 2, 3, 120.00, 360.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (59, 5, 4, 100.00, 400.00);

-- Presupuesto 60
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (8, 535.00, 'Aprobado', '2025-11-20 12:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (60, 1, 4, 85.00, 340.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (60, 6, 3, 65.00, 195.00);

-- Presupuesto 61
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (3, 1175.00, 'Pendiente', '2025-11-22 15:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (61, 2, 1, 800.00, 800.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (61, 4, 5, 75.00, 375.00);

-- Presupuesto 62
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (6, 150.00, 'Aprobado', '2025-11-25 08:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (62, 3, 3, 50.00, 150.00);

-- Presupuesto 63
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (1, 2500.00, 'Rechazado', '2025-11-27 10:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (63, 1, 1, 2500.00, 2500.00);

-- Presupuesto 64
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (7, 750.00, 'Pendiente', '2025-11-29 14:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (64, 5, 6, 100.00, 600.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (64, 3, 1, 150.00, 150.00);

-- Presupuesto 65
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (4, 455.00, 'Aprobado', '2025-12-01 09:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (65, 1, 3, 85.00, 255.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (65, 3, 4, 50.00, 200.00);

-- Presupuesto 66
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (9, 1750.00, 'Pendiente', '2025-12-03 11:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (66, 2, 2, 800.00, 1600.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (66, 3, 3, 50.00, 150.00);

-- Presupuesto 67
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (2, 495.00, 'Aprobado', '2025-12-05 08:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (67, 4, 5, 75.00, 375.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (67, 5, 1, 120.00, 120.00);

-- Presupuesto 68
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (10, 730.00, 'Rechazado', '2025-12-06 15:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (68, 2, 5, 120.00, 600.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (68, 6, 2, 65.00, 130.00);

-- Presupuesto 69
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (5, 725.00, 'Pendiente', '2025-12-07 10:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (69, 1, 5, 85.00, 425.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (69, 5, 3, 100.00, 300.00);

-- Presupuesto 70
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (8, 2500.00, 'Aprobado', '2025-12-08 12:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (70, 1, 1, 2500.00, 2500.00);

-- Presupuesto 71
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (3, 305.00, 'Pendiente', '2025-12-09 09:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (71, 4, 3, 75.00, 225.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (71, 4, 1, 80.00, 80.00);

-- Presupuesto 72
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (6, 870.00, 'Aprobado', '2025-12-10 14:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (72, 2, 6, 120.00, 720.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (72, 3, 1, 150.00, 150.00);

-- Presupuesto 73
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (1, 250.00, 'Rechazado', '2025-12-11 08:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (73, 3, 5, 50.00, 250.00);

-- Presupuesto 74
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (7, 640.00, 'Pendiente', '2025-12-12 16:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (74, 5, 4, 100.00, 400.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (74, 5, 2, 120.00, 240.00);

-- Presupuesto 75
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (4, 470.00, 'Aprobado', '2025-12-13 10:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (75, 1, 4, 85.00, 340.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (75, 6, 2, 65.00, 130.00);

-- Presupuesto 76
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (9, 2500.00, 'Pendiente', '2025-12-14 11:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (76, 1, 1, 2500.00, 2500.00);

-- Presupuesto 77
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (2, 300.00, 'Aprobado', '2025-12-15 09:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (77, 4, 4, 75.00, 300.00);

-- Presupuesto 78
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (10, 1160.00, 'Rechazado', '2025-12-16 13:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (78, 2, 1, 800.00, 800.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (78, 2, 3, 120.00, 360.00);

-- Presupuesto 79
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (5, 300.00, 'Pendiente', '2025-12-17 10:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (79, 3, 6, 50.00, 300.00);

-- Presupuesto 80
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (8, 825.00, 'Aprobado', '2025-12-18 14:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (80, 1, 5, 85.00, 425.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (80, 5, 4, 100.00, 400.00);

-- Presupuesto 81
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (3, 600.00, 'Pendiente', '2025-12-18 16:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (81, 2, 4, 120.00, 480.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (81, 5, 1, 120.00, 120.00);

-- Presupuesto 82
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (6, 455.00, 'Aprobado', '2025-12-19 09:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (82, 4, 5, 75.00, 375.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (82, 4, 1, 80.00, 80.00);

-- Presupuesto 83
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (1, 2650.00, 'Rechazado', '2025-12-19 11:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (83, 1, 1, 2500.00, 2500.00), (83, 3, 1, 150.00, 150.00);

-- Presupuesto 84
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (7, 490.00, 'Pendiente', '2025-12-19 15:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (84, 2, 3, 120.00, 360.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (84, 6, 2, 65.00, 130.00);

-- Presupuesto 85
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (4, 455.00, 'Aprobado', '2025-12-20 10:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (85, 1, 3, 85.00, 255.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (85, 3, 4, 50.00, 200.00);

-- Presupuesto 86
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (9, 620.00, 'Pendiente', '2025-12-20 14:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (86, 5, 5, 100.00, 500.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (86, 5, 1, 120.00, 120.00);

-- Presupuesto 87
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (2, 2500.00, 'Aprobado', '2025-12-21 09:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (87, 1, 1, 2500.00, 2500.00);

-- Presupuesto 88
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (10, 305.00, 'Rechazado', '2025-12-21 12:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (88, 4, 3, 75.00, 225.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (88, 4, 1, 80.00, 80.00);

-- Presupuesto 89
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (5, 1140.00, 'Pendiente', '2025-12-21 15:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (89, 2, 1, 800.00, 800.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (89, 1, 4, 85.00, 340.00);

-- Presupuesto 90
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (8, 540.00, 'Aprobado', '2025-12-22 10:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (90, 3, 6, 50.00, 300.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (90, 5, 2, 120.00, 240.00);

-- Presupuesto 91
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (3, 930.00, 'Pendiente', '2025-12-22 14:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (91, 3, 3, 150.00, 450.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (91, 2, 4, 120.00, 480.00);

-- Presupuesto 92
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (6, 300.00, 'Aprobado', '2025-12-23 09:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (92, 1, 2, 85.00, 170.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (92, 6, 2, 65.00, 130.00);

-- Presupuesto 93
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (1, 500.00, 'Rechazado', '2025-12-23 11:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (93, 5, 5, 100.00, 500.00);

-- Presupuesto 94
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (7, 495.00, 'Pendiente', '2025-12-23 15:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (94, 4, 5, 75.00, 375.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (94, 5, 1, 120.00, 120.00);

-- Presupuesto 95
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (4, 510.00, 'Aprobado', '2025-12-24 10:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (95, 2, 3, 120.00, 360.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (95, 3, 1, 150.00, 150.00);

-- Presupuesto 96
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (9, 1225.00, 'Pendiente', '2025-12-26 11:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (96, 2, 1, 800.00, 800.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (96, 1, 5, 85.00, 425.00);

-- Presupuesto 97
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (2, 250.00, 'Aprobado', '2025-12-27 09:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (97, 3, 5, 50.00, 250.00);

-- Presupuesto 98
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (10, 2500.00, 'Rechazado', '2025-12-28 10:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (98, 1, 1, 2500.00, 2500.00);

-- Presupuesto 99
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (5, 430.00, 'Pendiente', '2025-12-29 11:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (99, 4, 4, 75.00, 300.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (99, 6, 2, 65.00, 130.00);

-- Presupuesto 100
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (8, 580.00, 'Aprobado', '2025-12-30 10:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (100, 5, 5, 100.00, 500.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (100, 4, 1, 80.00, 80.00);

-- Presupuesto 101
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (3, 320.00, 'Pendiente', '2025-12-30 14:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (101, 3, 4, 50.00, 200.00);
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (101, 5, 1, 120.00, 120.00);

-- Presupuesto 102
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (6, 810.00, 'Aprobado', '2025-12-30 16:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (102, 1, 6, 85.00, 510.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (102, 5, 3, 100.00, 300.00);

-- Presupuesto 103
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (1, 360.00, 'Rechazado', '2025-12-31 09:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (103, 2, 3, 120.00, 360.00);

-- Presupuesto 104
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (7, 300.00, 'Pendiente', '2025-12-31 11:00:00+00');
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (104, 4, 4, 75.00, 300.00);

-- Presupuesto 105
INSERT INTO Presupuestos (ClienteId, Total, Estado, FechaCreacion) VALUES (4, 1280.00, 'Aprobado', '2025-12-31 14:00:00+00');
INSERT INTO PresupuestoProductos (PresupuestoId, ProductoId, Cantidad, PrecioUnitario, Subtotal) VALUES (105, 2, 1, 800.00, 800.00);
INSERT INTO PresupuestoServicios (PresupuestoId, ServicioId, Cantidad, PrecioUnitario, Subtotal) VALUES (105, 2, 4, 120.00, 480.00);
