create database Finales
go
use Finales
go
create Table Usuarios
(
	UsuarioId int primary key identity(1,1),
	Nombre varchar(30),
	NombreUsuario varchar (max),
	Contrasena varchar (15)
	

);
go

select *   FROM Usuarios
SELECT * FROM FacturaDetalles

set dateformat dmy;

insert into Usuarios values('Clifford Jeffrey Millien','JAY','123456')

go
create Table Ropas
(
	RopaId int primary key identity(1,1),
	Descripcion varchar(max),
	Precio decimal,
	size varchar (5),
	Marca varchar(max),
	Inventario money

);
go
create table EntradaRopas
(
	EntradaId int primary key identity(1,1),
	Fecha date,
	Cantidad int,
	RopaId int,
	

);
go
create table Clientes 
(
	ClienteId int primary key identity(1,1),
	Nombre varchar(30),
	Direccion varchar(max),
	Cedula varchar(15),
	Telefono varchar(15),
	Devuelta money,

);
go
create table Facturas
(
	FacturaId int primary key identity(1,1),
	RopaId int,
	ClienteId int,
	Fecha date,
	Recibido money,
	ITBIS money,
	SubTotal money,
	Total money,
	Devuelta money
);
go
create table FacturaDetalles
(
	Id int primary key identity(1,1),
	FacturaId int,
	UsuarioId int,
	RopaId int,
	Cantidad int,
	Precio decimal,
	Importe int,
	Ropa varchar (15),
	ClienteId int
	
	

);
go


select *from Usuarios
select *from Ropas
select *from EntradaRopas
select *from Clientes
select *from Facturas
select *from FacturaDetalles
