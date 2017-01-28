DROP DATABASE if exists microStore;

CREATE DATABASE microStore;

USE microStore;

CREATE TABLE usuario
(
  usuario_id INT NOT NULL PRIMARY KEY,
  nombreUsuario NVARCHAR(100) NOT NULL,
  pass NVARCHAR(50) NOT NULL
  
);

CREATE TABLE articulo
(
  articulo_id INT NOT NULL PRIMARY KEY,
  nombreArticulo NVARCHAR(100) NOT NULL,
  precio DECIMAL(7,2) NOT NULL,
  cantidadDisponible INT NOT NULL
);

CREATE TABLE codigoRegalo
(
  codigo_id INT NOT NULL PRIMARY KEY
);


INSERT INTO usuario VALUES(100000,'David Espinoza Reyes','123456');
INSERT INTO usuario VALUES(100001,'Juan Hernandez Perez','123456');

INSERT INTO articulo VALUES(1,'Laptop',12599.00,25);
INSERT INTO articulo VALUES(2,'Mouse',199.00,50);
INSERT INTO articulo VALUES(3,'Bocinas',499.22,25);
INSERT INTO articulo VALUES(4,'Audifonos',100.00,30);
INSERT INTO articulo VALUES(5,'Portafolio',399.00,10);
INSERT INTO articulo VALUES(6,'Memoria',199.00,99);

INSERT INTO codigoRegalo VALUES(84193310);
INSERT INTO codigoRegalo VALUES(84925884);
INSERT INTO codigoRegalo VALUES(75410003);


